using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace viscerality_patcher
{
    public partial class NotificationForm : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public DialogResult Result { get; private set; } = DialogResult.None;

        public NotificationForm()
        {
            InitializeComponent();

            // Hook the MouseDown event for dragging the form
            this.MouseDown += NotificationForm_MouseDown;
            lblMessage.MouseDown += NotificationForm_MouseDown; // Allow dragging by label too, if you want
        }

        /// <summary>
        /// Constructor to create notification with message, title and buttons
        /// </summary>
        /// <param name="message">Message to display</param>
        /// <param name="title">Window title</param>
        /// <param name="buttons">Buttons to show (OK or YesNo)</param>
        public NotificationForm(string message, string title, MessageBoxButtons buttons) : this()
        {
            this.Text = title;
            lblMessage.Text = message;

            // Hide all buttons first
            btnYes.Visible = false;
            btnNo.Visible = false;
            btnOk.Visible = false;

            if (buttons == MessageBoxButtons.OK)
            {
                btnOk.Visible = true;
                btnOk.SetBounds((this.ClientSize.Width - btnOk.Width) / 2, btnOk.Top, btnOk.Width, btnOk.Height);
                this.AcceptButton = btnOk;
            }
            else if (buttons == MessageBoxButtons.YesNo)
            {
                btnYes.Visible = true;
                btnNo.Visible = true;

                int spacing = 10;
                int totalWidth = btnYes.Width + btnNo.Width + spacing;

                btnYes.SetBounds((this.ClientSize.Width - totalWidth) / 2, btnYes.Top, btnYes.Width, btnYes.Height);
                btnNo.SetBounds(btnYes.Right + spacing, btnNo.Top, btnNo.Width, btnNo.Height);

                this.AcceptButton = btnYes;
                this.CancelButton = btnNo;
            }
        }

#pragma warning disable CS8622
        private void NotificationForm_MouseDown(object sender, MouseEventArgs e)
#pragma warning restore CS8622
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            Result = DialogResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Result = DialogResult.No;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Result = DialogResult.OK;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NotificationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
