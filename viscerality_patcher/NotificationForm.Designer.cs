namespace viscerality_patcher
{
    partial class NotificationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnExit = new Button();
            lblMessage = new Label();
            btnYes = new Button();
            btnNo = new Button();
            btnOk = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(29, 185, 84);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(148, 21);
            label1.TabIndex = 3;
            label1.Text = "Spotify Unblocker";
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.BackColor = Color.FromArgb(18, 18, 18);
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.ForeColor = Color.FromArgb(185, 29, 29);
            btnExit.Location = new Point(370, 0);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(30, 30);
            btnExit.TabIndex = 4;
            btnExit.Text = "X";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // lblMessage
            // 
            lblMessage.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMessage.Location = new Point(12, 52);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(376, 83);
            lblMessage.TabIndex = 5;
            lblMessage.Text = "visceral.ity";
            // 
            // btnYes
            // 
            btnYes.Anchor = AnchorStyles.Bottom;
            btnYes.BackColor = Color.FromArgb(33, 33, 33);
            btnYes.FlatAppearance.BorderSize = 0;
            btnYes.FlatStyle = FlatStyle.Flat;
            btnYes.Font = new Font("Segoe UI", 12F);
            btnYes.Location = new Point(114, 138);
            btnYes.Name = "btnYes";
            btnYes.Size = new Size(80, 30);
            btnYes.TabIndex = 6;
            btnYes.Text = "Yes";
            btnYes.UseVisualStyleBackColor = false;
            btnYes.Click += btnYes_Click;
            // 
            // btnNo
            // 
            btnNo.Anchor = AnchorStyles.Bottom;
            btnNo.BackColor = Color.FromArgb(33, 33, 33);
            btnNo.FlatAppearance.BorderSize = 0;
            btnNo.FlatStyle = FlatStyle.Flat;
            btnNo.Font = new Font("Segoe UI", 12F);
            btnNo.Location = new Point(198, 138);
            btnNo.Name = "btnNo";
            btnNo.Size = new Size(80, 30);
            btnNo.TabIndex = 7;
            btnNo.Text = "No";
            btnNo.UseVisualStyleBackColor = false;
            btnNo.Click += btnNo_Click;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom;
            btnOk.BackColor = Color.FromArgb(33, 33, 33);
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.Font = new Font("Segoe UI", 12F);
            btnOk.Location = new Point(114, 138);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(164, 30);
            btnOk.TabIndex = 8;
            btnOk.Text = "Okay";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += btnOk_Click;
            // 
            // NotificationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 18);
            ClientSize = new Size(400, 180);
            Controls.Add(btnOk);
            Controls.Add(btnNo);
            Controls.Add(btnYes);
            Controls.Add(lblMessage);
            Controls.Add(btnExit);
            Controls.Add(label1);
            ForeColor = Color.FromArgb(29, 185, 84);
            FormBorderStyle = FormBorderStyle.None;
            Name = "NotificationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NotificationForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnExit;
        private Label lblMessage;
        private Button btnYes;
        private Button btnNo;
        private Button btnOk;
    }
}