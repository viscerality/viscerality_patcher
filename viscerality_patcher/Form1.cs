using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace viscerality_patcher
{
    public partial class Form1 : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;
        private static Mutex? mutex;

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public Form1()
        {
            if (!EnsureSingleInstance())
            {
                MessageBox.Show("Another instance of Viscerality Patcher is already running.", "Instance Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(0);
                return;
            }

            InitializeComponent();
            this.MouseDown += Form1_MouseDown;
            this.StartPosition = FormStartPosition.CenterScreen;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.ReadOnly = true;

            // Show Discord invite message on startup
            this.Shown += (s, e) =>
            {
                using var dlg = new NotificationForm(
                    "Thanks for using Viscerality Patcher! This is a free tool maintained by the community.\n\nIf you like it, please consider joining our Discord to get support, report bugs, or stay updated!",
                    "Join Our Discord",
                    MessageBoxButtons.OK);
                dlg.ShowDialog();

                // Open Discord invite link after clicking OK
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "https://discord.gg/gFpmqJCt",
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open Discord link:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
        }

        private bool EnsureSingleInstance()
        {
            bool createdNew;
            mutex = new Mutex(true, "VisceralityPatcherMutex", out createdNew);
            return createdNew;
        }

        private void Form1_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnPatch_Click(object sender, EventArgs e)
        {
            btnPatch.Enabled = false;
            txtLog.Clear();
            await PatchSpotifyAsync();
            btnPatch.Enabled = true;
        }

        private async Task PatchSpotifyAsync()
        {
            Log("Starting patch process...");

            string spotifyDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Spotify");
            string dpapiPath = Path.Combine(spotifyDir, "dpapi.dll");
            string configPath = Path.Combine(spotifyDir, "config.ini");

            if (!Directory.Exists(spotifyDir))
            {
                Log("Spotify folder not found. Please ensure Spotify is installed.");
                ShowMessage("Spotify folder not found. Please ensure Spotify is installed.", "Error");
                return;
            }
            else
            {
                Log($"Spotify directory found: {spotifyDir}");
            }

            var runningSpotify = Process.GetProcessesByName("Spotify");
            if (runningSpotify.Length > 0)
            {
                Log($"Found {runningSpotify.Length} running Spotify process(es).");
                if (!ConfirmDialog("Spotify is running and must be closed to apply the patch.\nClose Spotify now?", "Confirm"))
                {
                    Log("User cancelled patching because Spotify is running.");
                    ShowMessage("Patch cancelled because Spotify is running.", "Cancelled");
                    return;
                }

                foreach (var proc in runningSpotify)
                {
                    try
                    {
                        Log($"Attempting to kill process ID {proc.Id}...");
                        proc.Kill();
                        await Task.Run(() => proc.WaitForExit(5000));
                        Log($"Process ID {proc.Id} terminated.");
                    }
                    catch (Exception ex)
                    {
                        Log($"Failed to kill process ID {proc.Id}: {ex.Message}");
                    }
                }
            }

            if (File.Exists(dpapiPath) && File.Exists(configPath))
            {
                if (!ConfirmDialog("Spotify appears already patched.\nOverwrite patch?", "Confirm"))
                {
                    Log("User chose not to overwrite existing patch.");
                    return;
                }
                else
                {
                    Log("User chose to overwrite existing patch.");
                }
            }

            try
            {
                Log("Extracting dpapi.dll...");
                await Task.Run(() => ExtractResourceToFile("viscerality_patcher.dpapi.dll", dpapiPath));

                Log("Extracting config.ini...");
                await Task.Run(() => ExtractResourceToFile("viscerality_patcher.config.ini", configPath));

                Log("Spotify patched successfully!");
                ShowMessage("Spotify patched successfully!", "Success");
            }
            catch (Exception ex)
            {
                Log($"Error patching Spotify: {ex.Message}");
                ShowMessage($"Error patching Spotify:\n{ex.Message}", "Error");
            }
        }

        private async Task UnpatchSpotifyAsync()
        {
            Log("Starting unpatch process...");

            string spotifyDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Spotify");
            string dpapiPath = Path.Combine(spotifyDir, "dpapi.dll");
            string configPath = Path.Combine(spotifyDir, "config.ini");

            if (!Directory.Exists(spotifyDir))
            {
                Log("Spotify folder not found. Cannot unpatch.");
                ShowMessage("Spotify folder not found. Cannot unpatch.", "Error");
                return;
            }

            var runningSpotify = Process.GetProcessesByName("Spotify");
            if (runningSpotify.Length > 0)
            {
                Log($"Found {runningSpotify.Length} running Spotify process(es).");
                if (!ConfirmDialog("Spotify is running and must be closed to unpatch.\nClose Spotify now?", "Confirm"))
                {
                    Log("User cancelled unpatching because Spotify is running.");
                    ShowMessage("Unpatch cancelled because Spotify is running.", "Cancelled");
                    return;
                }

                foreach (var proc in runningSpotify)
                {
                    try
                    {
                        Log($"Attempting to kill process ID {proc.Id}...");
                        proc.Kill();
                        await Task.Run(() => proc.WaitForExit(5000));
                        Log($"Process ID {proc.Id} terminated.");
                    }
                    catch (Exception ex)
                    {
                        Log($"Failed to kill process ID {proc.Id}: {ex.Message}");
                    }
                }
            }

            try
            {
                if (File.Exists(dpapiPath))
                {
                    File.Delete(dpapiPath);
                    Log("Deleted dpapi.dll");
                }
                else
                {
                    Log("dpapi.dll not found.");
                }

                if (File.Exists(configPath))
                {
                    File.Delete(configPath);
                    Log("Deleted config.ini");
                }
                else
                {
                    Log("config.ini not found.");
                }

                Log("Spotify unpatched successfully!");
                ShowMessage("Spotify unpatched successfully!", "Success");
            }
            catch (Exception ex)
            {
                Log($"Error unpatching Spotify: {ex.Message}");
                ShowMessage($"Error unpatching Spotify:\n{ex.Message}", "Error");
            }
        }

        private void ExtractResourceToFile(string resourceName, string outputPath)
        {
            var asm = Assembly.GetExecutingAssembly();
            var resourceNames = asm.GetManifestResourceNames();

            if (Array.IndexOf(resourceNames, resourceName) < 0)
                throw new Exception($"Resource '{resourceName}' not found.");

            using var stream = asm.GetManifestResourceStream(resourceName) ?? throw new Exception($"Resource '{resourceName}' not found.");
            using var fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write);
            stream.CopyTo(fs);
        }

        private void Log(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Log(message)));
                return;
            }
            txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }

        private bool ConfirmDialog(string message, string title)
        {
            using var dlg = new NotificationForm(message, title, MessageBoxButtons.YesNo);
            dlg.ShowDialog();
            return dlg.Result == DialogResult.Yes;
        }

        private void ShowMessage(string message, string title)
        {
            using var dlg = new NotificationForm(message, title, MessageBoxButtons.OK);
            dlg.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void txtLog_TextChanged(object sender, EventArgs e)
        {
            if (txtLog.Lines.Length > 1000)
            {
                var lines = txtLog.Lines;
                txtLog.Lines = lines[(lines.Length - 1000)..];
            }
        }

        private async void btnUnpatch_Click(object sender, EventArgs e)
        {
            btnUnpatch.Enabled = false;
            txtLog.Clear();
            await UnpatchSpotifyAsync();
            btnUnpatch.Enabled = true;
        }

        private void label2_Click(object sender, EventArgs e) { }
    }
}
