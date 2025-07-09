using System;
using System.Drawing;
using System.Windows.Forms;

namespace viscerality_patcher
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Button btnPatch;
        private Button btnExit;
        private Label label1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnPatch = new Button();
            btnExit = new Button();
            label1 = new Label();
            label2 = new Label();
            txtLog = new TextBox();
            btnUnpatch = new Button();
            SuspendLayout();
            // 
            // btnPatch
            // 
            btnPatch.Anchor = AnchorStyles.Bottom;
            btnPatch.BackColor = Color.FromArgb(33, 33, 33);
            btnPatch.FlatAppearance.BorderSize = 0;
            btnPatch.FlatStyle = FlatStyle.Flat;
            btnPatch.Font = new Font("Segoe UI", 12F);
            btnPatch.Location = new Point(108, 240);
            btnPatch.Name = "btnPatch";
            btnPatch.Size = new Size(120, 40);
            btnPatch.TabIndex = 0;
            btnPatch.Text = "Patch Spotify";
            btnPatch.UseVisualStyleBackColor = false;
            btnPatch.Click += btnPatch_Click;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.BackColor = Color.FromArgb(18, 18, 18);
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.ForeColor = Color.FromArgb(185, 29, 29);
            btnExit.Location = new Point(460, 10);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(30, 30);
            btnExit.TabIndex = 1;
            btnExit.Text = "X";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(15, 15);
            label1.Name = "label1";
            label1.Size = new Size(148, 21);
            label1.TabIndex = 2;
            label1.Text = "Spotify Unblocker";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(408, 270);
            label2.Name = "label2";
            label2.Size = new Size(82, 21);
            label2.TabIndex = 3;
            label2.Text = "visceral.ity";
            label2.Click += label2_Click;
            // 
            // txtLog
            // 
            txtLog.BackColor = Color.FromArgb(33, 33, 33);
            txtLog.BorderStyle = BorderStyle.None;
            txtLog.ForeColor = Color.FromArgb(29, 185, 84);
            txtLog.Location = new Point(15, 64);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.Size = new Size(470, 130);
            txtLog.TabIndex = 4;
            txtLog.TextChanged += txtLog_TextChanged;
            // 
            // btnUnpatch
            // 
            btnUnpatch.Anchor = AnchorStyles.Bottom;
            btnUnpatch.BackColor = Color.FromArgb(33, 33, 33);
            btnUnpatch.FlatAppearance.BorderSize = 0;
            btnUnpatch.FlatStyle = FlatStyle.Flat;
            btnUnpatch.Font = new Font("Segoe UI", 12F);
            btnUnpatch.Location = new Point(234, 240);
            btnUnpatch.Name = "btnUnpatch";
            btnUnpatch.Size = new Size(120, 40);
            btnUnpatch.TabIndex = 5;
            btnUnpatch.Text = "Unpatch";
            btnUnpatch.UseVisualStyleBackColor = false;
            btnUnpatch.Click += btnUnpatch_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 18);
            ClientSize = new Size(500, 300);
            Controls.Add(btnUnpatch);
            Controls.Add(txtLog);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnExit);
            Controls.Add(btnPatch);
            ForeColor = Color.FromArgb(29, 185, 84);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        private Label label2;
        private TextBox txtLog;
        private Button btnUnpatch;
    }
}
