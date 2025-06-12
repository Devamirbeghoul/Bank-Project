namespace DesktopLayer.Main
{
    partial class fmMainClients
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmMainClients));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnAccount = new Guna.UI2.WinForms.Guna2Button();
            this.tcScreens = new System.Windows.Forms.TabControl();
            this.tbInitial = new System.Windows.Forms.TabPage();
            this.tpAccount = new System.Windows.Forms.TabPage();
            this.guna2GroupBox9 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnTransferHistory = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2GroupBox10 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnBasicHistory = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2GroupBox3 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPersonalLoginHistory = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChangePassword = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAccountInfo = new Guna.UI2.WinForms.Guna2CircleButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tcScreens.SuspendLayout();
            this.tpAccount.SuspendLayout();
            this.guna2GroupBox9.SuspendLayout();
            this.guna2GroupBox10.SuspendLayout();
            this.guna2GroupBox3.SuspendLayout();
            this.guna2GroupBox1.SuspendLayout();
            this.guna2GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(157)))), ((int)(((byte)(96)))));
            this.splitContainer1.Panel1.Controls.Add(this.btnClose);
            this.splitContainer1.Panel1.Controls.Add(this.btnAccount);
            this.splitContainer1.Panel1.Click += new System.EventHandler(this.splitContainer1_Panel1_Click);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.tcScreens);
            this.splitContainer1.Size = new System.Drawing.Size(975, 571);
            this.splitContainer1.SplitterDistance = 232;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Animated = true;
            this.btnClose.AutoRoundedCorners = true;
            this.btnClose.BorderRadius = 24;
            this.btnClose.CheckedState.Parent = this.btnClose;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.CustomImages.Parent = this.btnClose;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.HoverState.Parent = this.btnClose;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnClose.ImageSize = new System.Drawing.Size(35, 35);
            this.btnClose.Location = new System.Drawing.Point(12, 508);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(213, 51);
            this.btnClose.TabIndex = 3;
            this.btnClose.Tag = "1";
            this.btnClose.Text = "Logout";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAccount
            // 
            this.btnAccount.Animated = true;
            this.btnAccount.AutoRoundedCorners = true;
            this.btnAccount.BorderRadius = 24;
            this.btnAccount.CheckedState.Parent = this.btnAccount;
            this.btnAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccount.CustomImages.Parent = this.btnAccount;
            this.btnAccount.FillColor = System.Drawing.Color.Transparent;
            this.btnAccount.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccount.ForeColor = System.Drawing.Color.White;
            this.btnAccount.HoverState.Parent = this.btnAccount;
            this.btnAccount.Image = ((System.Drawing.Image)(resources.GetObject("btnAccount.Image")));
            this.btnAccount.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAccount.ImageSize = new System.Drawing.Size(35, 35);
            this.btnAccount.Location = new System.Drawing.Point(12, 162);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.ShadowDecoration.Parent = this.btnAccount;
            this.btnAccount.Size = new System.Drawing.Size(213, 51);
            this.btnAccount.TabIndex = 2;
            this.btnAccount.Tag = "1";
            this.btnAccount.Text = "Account";
            this.btnAccount.Click += new System.EventHandler(this.btn_Click);
            // 
            // tcScreens
            // 
            this.tcScreens.Controls.Add(this.tbInitial);
            this.tcScreens.Controls.Add(this.tpAccount);
            this.tcScreens.Controls.Add(this.tabPage1);
            this.tcScreens.Location = new System.Drawing.Point(-301, -52);
            this.tcScreens.Name = "tcScreens";
            this.tcScreens.SelectedIndex = 0;
            this.tcScreens.Size = new System.Drawing.Size(1471, 623);
            this.tcScreens.TabIndex = 4;
            // 
            // tbInitial
            // 
            this.tbInitial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.tbInitial.Location = new System.Drawing.Point(4, 28);
            this.tbInitial.Name = "tbInitial";
            this.tbInitial.Padding = new System.Windows.Forms.Padding(3);
            this.tbInitial.Size = new System.Drawing.Size(1463, 591);
            this.tbInitial.TabIndex = 1;
            this.tbInitial.Text = "tabPage2";
            // 
            // tpAccount
            // 
            this.tpAccount.BackColor = System.Drawing.Color.White;
            this.tpAccount.Controls.Add(this.guna2GroupBox9);
            this.tpAccount.Controls.Add(this.guna2GroupBox10);
            this.tpAccount.Controls.Add(this.guna2GroupBox3);
            this.tpAccount.Controls.Add(this.guna2GroupBox1);
            this.tpAccount.Controls.Add(this.guna2GroupBox2);
            this.tpAccount.Location = new System.Drawing.Point(4, 28);
            this.tpAccount.Name = "tpAccount";
            this.tpAccount.Padding = new System.Windows.Forms.Padding(3);
            this.tpAccount.Size = new System.Drawing.Size(1463, 591);
            this.tpAccount.TabIndex = 0;
            this.tpAccount.Text = "tabPage1";
            // 
            // guna2GroupBox9
            // 
            this.guna2GroupBox9.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox9.BorderRadius = 10;
            this.guna2GroupBox9.Controls.Add(this.label9);
            this.guna2GroupBox9.Controls.Add(this.btnTransferHistory);
            this.guna2GroupBox9.CustomBorderColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox9.FillColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox9.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox9.Location = new System.Drawing.Point(650, 406);
            this.guna2GroupBox9.Name = "guna2GroupBox9";
            this.guna2GroupBox9.ShadowDecoration.Parent = this.guna2GroupBox9;
            this.guna2GroupBox9.Size = new System.Drawing.Size(246, 118);
            this.guna2GroupBox9.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(52, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 25);
            this.label9.TabIndex = 1;
            this.label9.Text = "Transfer History";
            // 
            // btnTransferHistory
            // 
            this.btnTransferHistory.Animated = true;
            this.btnTransferHistory.CheckedState.Parent = this.btnTransferHistory;
            this.btnTransferHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransferHistory.CustomImages.Parent = this.btnTransferHistory;
            this.btnTransferHistory.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.btnTransferHistory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTransferHistory.ForeColor = System.Drawing.Color.White;
            this.btnTransferHistory.HoverState.Parent = this.btnTransferHistory;
            this.btnTransferHistory.Image = ((System.Drawing.Image)(resources.GetObject("btnTransferHistory.Image")));
            this.btnTransferHistory.ImageSize = new System.Drawing.Size(30, 30);
            this.btnTransferHistory.Location = new System.Drawing.Point(94, 14);
            this.btnTransferHistory.Name = "btnTransferHistory";
            this.btnTransferHistory.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnTransferHistory.ShadowDecoration.Parent = this.btnTransferHistory;
            this.btnTransferHistory.Size = new System.Drawing.Size(59, 52);
            this.btnTransferHistory.TabIndex = 0;
            this.btnTransferHistory.Click += new System.EventHandler(this.btnTransferHistory_Click);
            // 
            // guna2GroupBox10
            // 
            this.guna2GroupBox10.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox10.BorderRadius = 10;
            this.guna2GroupBox10.Controls.Add(this.label10);
            this.guna2GroupBox10.Controls.Add(this.btnBasicHistory);
            this.guna2GroupBox10.CustomBorderColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox10.FillColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox10.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox10.Location = new System.Drawing.Point(398, 406);
            this.guna2GroupBox10.Name = "guna2GroupBox10";
            this.guna2GroupBox10.ShadowDecoration.Parent = this.guna2GroupBox10;
            this.guna2GroupBox10.Size = new System.Drawing.Size(246, 118);
            this.guna2GroupBox10.TabIndex = 37;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(64, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 25);
            this.label10.TabIndex = 1;
            this.label10.Text = "Basic History";
            // 
            // btnBasicHistory
            // 
            this.btnBasicHistory.Animated = true;
            this.btnBasicHistory.CheckedState.Parent = this.btnBasicHistory;
            this.btnBasicHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBasicHistory.CustomImages.Parent = this.btnBasicHistory;
            this.btnBasicHistory.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.btnBasicHistory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBasicHistory.ForeColor = System.Drawing.Color.White;
            this.btnBasicHistory.HoverState.Parent = this.btnBasicHistory;
            this.btnBasicHistory.Image = ((System.Drawing.Image)(resources.GetObject("btnBasicHistory.Image")));
            this.btnBasicHistory.ImageSize = new System.Drawing.Size(30, 30);
            this.btnBasicHistory.Location = new System.Drawing.Point(94, 14);
            this.btnBasicHistory.Name = "btnBasicHistory";
            this.btnBasicHistory.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnBasicHistory.ShadowDecoration.Parent = this.btnBasicHistory;
            this.btnBasicHistory.Size = new System.Drawing.Size(59, 52);
            this.btnBasicHistory.TabIndex = 0;
            this.btnBasicHistory.Click += new System.EventHandler(this.btnBasicHistory_Click);
            // 
            // guna2GroupBox3
            // 
            this.guna2GroupBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox3.BorderRadius = 10;
            this.guna2GroupBox3.Controls.Add(this.label3);
            this.guna2GroupBox3.Controls.Add(this.btnPersonalLoginHistory);
            this.guna2GroupBox3.CustomBorderColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox3.FillColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox3.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox3.Location = new System.Drawing.Point(526, 282);
            this.guna2GroupBox3.Name = "guna2GroupBox3";
            this.guna2GroupBox3.ShadowDecoration.Parent = this.guna2GroupBox3;
            this.guna2GroupBox3.Size = new System.Drawing.Size(246, 118);
            this.guna2GroupBox3.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(62, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Login History";
            // 
            // btnPersonalLoginHistory
            // 
            this.btnPersonalLoginHistory.Animated = true;
            this.btnPersonalLoginHistory.CheckedState.Parent = this.btnPersonalLoginHistory;
            this.btnPersonalLoginHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPersonalLoginHistory.CustomImages.Parent = this.btnPersonalLoginHistory;
            this.btnPersonalLoginHistory.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.btnPersonalLoginHistory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPersonalLoginHistory.ForeColor = System.Drawing.Color.White;
            this.btnPersonalLoginHistory.HoverState.Parent = this.btnPersonalLoginHistory;
            this.btnPersonalLoginHistory.Image = ((System.Drawing.Image)(resources.GetObject("btnPersonalLoginHistory.Image")));
            this.btnPersonalLoginHistory.ImageSize = new System.Drawing.Size(30, 30);
            this.btnPersonalLoginHistory.Location = new System.Drawing.Point(94, 14);
            this.btnPersonalLoginHistory.Name = "btnPersonalLoginHistory";
            this.btnPersonalLoginHistory.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnPersonalLoginHistory.ShadowDecoration.Parent = this.btnPersonalLoginHistory;
            this.btnPersonalLoginHistory.Size = new System.Drawing.Size(59, 52);
            this.btnPersonalLoginHistory.TabIndex = 0;
            this.btnPersonalLoginHistory.Click += new System.EventHandler(this.btnPersonalLoginHistory_Click);
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.BorderRadius = 10;
            this.guna2GroupBox1.Controls.Add(this.label1);
            this.guna2GroupBox1.Controls.Add(this.btnChangePassword);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox1.Location = new System.Drawing.Point(650, 158);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.ShadowDecoration.Parent = this.guna2GroupBox1;
            this.guna2GroupBox1.Size = new System.Drawing.Size(246, 118);
            this.guna2GroupBox1.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Change Password";
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Animated = true;
            this.btnChangePassword.CheckedState.Parent = this.btnChangePassword;
            this.btnChangePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePassword.CustomImages.Parent = this.btnChangePassword;
            this.btnChangePassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.btnChangePassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnChangePassword.ForeColor = System.Drawing.Color.White;
            this.btnChangePassword.HoverState.Parent = this.btnChangePassword;
            this.btnChangePassword.Image = ((System.Drawing.Image)(resources.GetObject("btnChangePassword.Image")));
            this.btnChangePassword.ImageSize = new System.Drawing.Size(30, 30);
            this.btnChangePassword.Location = new System.Drawing.Point(94, 14);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnChangePassword.ShadowDecoration.Parent = this.btnChangePassword;
            this.btnChangePassword.Size = new System.Drawing.Size(59, 52);
            this.btnChangePassword.TabIndex = 0;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox2.BorderRadius = 10;
            this.guna2GroupBox2.Controls.Add(this.label2);
            this.guna2GroupBox2.Controls.Add(this.btnAccountInfo);
            this.guna2GroupBox2.CustomBorderColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox2.Location = new System.Drawing.Point(398, 158);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.ShadowDecoration.Parent = this.guna2GroupBox2;
            this.guna2GroupBox2.Size = new System.Drawing.Size(246, 118);
            this.guna2GroupBox2.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(101, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Info";
            // 
            // btnAccountInfo
            // 
            this.btnAccountInfo.Animated = true;
            this.btnAccountInfo.CheckedState.Parent = this.btnAccountInfo;
            this.btnAccountInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccountInfo.CustomImages.Parent = this.btnAccountInfo;
            this.btnAccountInfo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.btnAccountInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAccountInfo.ForeColor = System.Drawing.Color.White;
            this.btnAccountInfo.HoverState.Parent = this.btnAccountInfo;
            this.btnAccountInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnAccountInfo.Image")));
            this.btnAccountInfo.ImageSize = new System.Drawing.Size(30, 30);
            this.btnAccountInfo.Location = new System.Drawing.Point(94, 14);
            this.btnAccountInfo.Name = "btnAccountInfo";
            this.btnAccountInfo.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnAccountInfo.ShadowDecoration.Parent = this.btnAccountInfo;
            this.btnAccountInfo.Size = new System.Drawing.Size(59, 52);
            this.btnAccountInfo.TabIndex = 0;
            this.btnAccountInfo.Click += new System.EventHandler(this.btnAccountInfo_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1463, 597);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // fmMainClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(247)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(975, 571);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fmMainClients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menue";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fmMain_FormClosed);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tcScreens.ResumeLayout(false);
            this.tpAccount.ResumeLayout(false);
            this.guna2GroupBox9.ResumeLayout(false);
            this.guna2GroupBox9.PerformLayout();
            this.guna2GroupBox10.ResumeLayout(false);
            this.guna2GroupBox10.PerformLayout();
            this.guna2GroupBox3.ResumeLayout(false);
            this.guna2GroupBox3.PerformLayout();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.guna2GroupBox2.ResumeLayout(false);
            this.guna2GroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tcScreens;
        private System.Windows.Forms.TabPage tpAccount;
        private System.Windows.Forms.TabPage tbInitial;
        private Guna.UI2.WinForms.Guna2Button btnAccount;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.TabPage tabPage1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CircleButton btnChangePassword;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2CircleButton btnAccountInfo;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox3;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2CircleButton btnPersonalLoginHistory;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox9;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2CircleButton btnTransferHistory;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox10;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2CircleButton btnBasicHistory;
    }
}