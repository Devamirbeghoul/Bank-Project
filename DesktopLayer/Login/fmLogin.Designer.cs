namespace DesktopLayer.Login
{
    partial class fmLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmLogin));
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.gbLogin = new Guna.UI2.WinForms.Guna2GroupBox();
            this.llbForgetPassword = new System.Windows.Forms.LinkLabel();
            this.cbType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbRememberMe = new System.Windows.Forms.CheckBox();
            this.lbInput2 = new System.Windows.Forms.Label();
            this.tbPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbInput1 = new System.Windows.Forms.Label();
            this.tbUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnGo = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.epValidate = new System.Windows.Forms.ErrorProvider(this.components);
            this.NextLogin = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.gbLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epValidate)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.Location = new System.Drawing.Point(0, 271);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(848, 477);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 1;
            this.guna2PictureBox1.TabStop = false;
            // 
            // gbLogin
            // 
            this.gbLogin.BackColor = System.Drawing.Color.Transparent;
            this.gbLogin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(160)))), ((int)(((byte)(116)))));
            this.gbLogin.BorderRadius = 10;
            this.gbLogin.BorderThickness = 2;
            this.gbLogin.Controls.Add(this.llbForgetPassword);
            this.gbLogin.Controls.Add(this.cbType);
            this.gbLogin.Controls.Add(this.label2);
            this.gbLogin.Controls.Add(this.cbRememberMe);
            this.gbLogin.Controls.Add(this.lbInput2);
            this.gbLogin.Controls.Add(this.tbPassword);
            this.gbLogin.Controls.Add(this.lbInput1);
            this.gbLogin.Controls.Add(this.tbUsername);
            this.gbLogin.Controls.Add(this.lbTitle);
            this.gbLogin.CustomBorderColor = System.Drawing.Color.Transparent;
            this.gbLogin.FillColor = System.Drawing.Color.Transparent;
            this.gbLogin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gbLogin.ForeColor = System.Drawing.Color.Black;
            this.gbLogin.Location = new System.Drawing.Point(171, 12);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.ShadowDecoration.Parent = this.gbLogin;
            this.gbLogin.Size = new System.Drawing.Size(507, 312);
            this.gbLogin.TabIndex = 26;
            // 
            // llbForgetPassword
            // 
            this.llbForgetPassword.AutoSize = true;
            this.llbForgetPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llbForgetPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbForgetPassword.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(157)))), ((int)(((byte)(96)))));
            this.llbForgetPassword.Location = new System.Drawing.Point(31, 281);
            this.llbForgetPassword.Name = "llbForgetPassword";
            this.llbForgetPassword.Size = new System.Drawing.Size(132, 21);
            this.llbForgetPassword.TabIndex = 37;
            this.llbForgetPassword.TabStop = true;
            this.llbForgetPassword.Text = "Forget Password?";
            this.llbForgetPassword.VisitedLinkColor = System.Drawing.Color.Green;
            this.llbForgetPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbForgetPassword_LinkClicked);
            // 
            // cbType
            // 
            this.cbType.BackColor = System.Drawing.Color.Transparent;
            this.cbType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(157)))), ((int)(((byte)(96)))));
            this.cbType.BorderRadius = 12;
            this.cbType.BorderThickness = 2;
            this.cbType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbType.FocusedColor = System.Drawing.Color.Empty;
            this.cbType.FocusedState.Parent = this.cbType;
            this.cbType.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbType.ForeColor = System.Drawing.Color.Black;
            this.cbType.FormattingEnabled = true;
            this.cbType.HoverState.Parent = this.cbType;
            this.cbType.ItemHeight = 30;
            this.cbType.Items.AddRange(new object[] {
            "User",
            "Client"});
            this.cbType.ItemsAppearance.Parent = this.cbType;
            this.cbType.Location = new System.Drawing.Point(128, 86);
            this.cbType.Name = "cbType";
            this.cbType.ShadowDecoration.Parent = this.cbType;
            this.cbType.Size = new System.Drawing.Size(229, 36);
            this.cbType.StartIndex = 0;
            this.cbType.TabIndex = 36;
            this.cbType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(41)))), ((int)(((byte)(47)))));
            this.label2.Location = new System.Drawing.Point(33, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 32);
            this.label2.TabIndex = 35;
            this.label2.Text = "Type:";
            // 
            // cbRememberMe
            // 
            this.cbRememberMe.AutoSize = true;
            this.cbRememberMe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRememberMe.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRememberMe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(41)))), ((int)(((byte)(47)))));
            this.cbRememberMe.Location = new System.Drawing.Point(226, 246);
            this.cbRememberMe.Name = "cbRememberMe";
            this.cbRememberMe.Size = new System.Drawing.Size(173, 34);
            this.cbRememberMe.TabIndex = 34;
            this.cbRememberMe.Text = "Remember Me.";
            this.cbRememberMe.UseVisualStyleBackColor = true;
            // 
            // lbInput2
            // 
            this.lbInput2.AutoSize = true;
            this.lbInput2.BackColor = System.Drawing.Color.Transparent;
            this.lbInput2.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInput2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(41)))), ((int)(((byte)(47)))));
            this.lbInput2.Location = new System.Drawing.Point(33, 206);
            this.lbInput2.Name = "lbInput2";
            this.lbInput2.Size = new System.Drawing.Size(121, 32);
            this.lbInput2.TabIndex = 33;
            this.lbInput2.Text = "Password:";
            // 
            // tbPassword
            // 
            this.tbPassword.Animated = true;
            this.tbPassword.BackColor = System.Drawing.Color.Transparent;
            this.tbPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(157)))), ((int)(((byte)(96)))));
            this.tbPassword.BorderRadius = 12;
            this.tbPassword.BorderThickness = 2;
            this.tbPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPassword.DefaultText = "";
            this.tbPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPassword.DisabledState.Parent = this.tbPassword;
            this.tbPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPassword.FocusedState.Parent = this.tbPassword;
            this.tbPassword.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.ForeColor = System.Drawing.Color.Black;
            this.tbPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPassword.HoverState.Parent = this.tbPassword;
            this.tbPassword.Location = new System.Drawing.Point(170, 200);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '\0';
            this.tbPassword.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.tbPassword.PlaceholderText = "";
            this.tbPassword.SelectedText = "";
            this.tbPassword.ShadowDecoration.Parent = this.tbPassword;
            this.tbPassword.Size = new System.Drawing.Size(229, 38);
            this.tbPassword.TabIndex = 32;
            this.tbPassword.UseSystemPasswordChar = true;
            this.tbPassword.Validating += new System.ComponentModel.CancelEventHandler(this.NoNullOrEmpty_Validating);
            // 
            // lbInput1
            // 
            this.lbInput1.AutoSize = true;
            this.lbInput1.BackColor = System.Drawing.Color.Transparent;
            this.lbInput1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInput1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(41)))), ((int)(((byte)(47)))));
            this.lbInput1.Location = new System.Drawing.Point(33, 148);
            this.lbInput1.Name = "lbInput1";
            this.lbInput1.Size = new System.Drawing.Size(130, 32);
            this.lbInput1.TabIndex = 31;
            this.lbInput1.Text = "Username:";
            // 
            // tbUsername
            // 
            this.tbUsername.Animated = true;
            this.tbUsername.BackColor = System.Drawing.Color.Transparent;
            this.tbUsername.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(157)))), ((int)(((byte)(96)))));
            this.tbUsername.BorderRadius = 12;
            this.tbUsername.BorderThickness = 2;
            this.tbUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbUsername.DefaultText = "";
            this.tbUsername.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbUsername.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbUsername.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbUsername.DisabledState.Parent = this.tbUsername;
            this.tbUsername.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbUsername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbUsername.FocusedState.Parent = this.tbUsername;
            this.tbUsername.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsername.ForeColor = System.Drawing.Color.Black;
            this.tbUsername.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbUsername.HoverState.Parent = this.tbUsername;
            this.tbUsername.Location = new System.Drawing.Point(170, 142);
            this.tbUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.PasswordChar = '\0';
            this.tbUsername.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.tbUsername.PlaceholderText = "";
            this.tbUsername.SelectedText = "";
            this.tbUsername.ShadowDecoration.Parent = this.tbUsername;
            this.tbUsername.Size = new System.Drawing.Size(229, 38);
            this.tbUsername.TabIndex = 28;
            this.tbUsername.Validating += new System.ComponentModel.CancelEventHandler(this.NoNullOrEmpty_Validating);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Yu Gothic UI", 27.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(41)))), ((int)(((byte)(47)))));
            this.lbTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbTitle.Location = new System.Drawing.Point(194, 11);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(116, 50);
            this.lbTitle.TabIndex = 27;
            this.lbTitle.Text = "Login";
            // 
            // btnGo
            // 
            this.btnGo.Animated = true;
            this.btnGo.AutoRoundedCorners = true;
            this.btnGo.BackColor = System.Drawing.Color.Transparent;
            this.btnGo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(157)))), ((int)(((byte)(96)))));
            this.btnGo.BorderRadius = 19;
            this.btnGo.BorderThickness = 2;
            this.btnGo.CheckedState.Parent = this.btnGo;
            this.btnGo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGo.CustomImages.Parent = this.btnGo;
            this.btnGo.FillColor = System.Drawing.Color.Transparent;
            this.btnGo.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(41)))), ((int)(((byte)(47)))));
            this.btnGo.HoverState.Parent = this.btnGo;
            this.btnGo.Location = new System.Drawing.Point(501, 330);
            this.btnGo.Name = "btnGo";
            this.btnGo.ShadowDecoration.Parent = this.btnGo;
            this.btnGo.Size = new System.Drawing.Size(177, 41);
            this.btnGo.TabIndex = 37;
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnClose
            // 
            this.btnClose.Animated = true;
            this.btnClose.AutoRoundedCorners = true;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(157)))), ((int)(((byte)(96)))));
            this.btnClose.BorderRadius = 19;
            this.btnClose.BorderThickness = 2;
            this.btnClose.CheckedState.Parent = this.btnClose;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.CustomImages.Parent = this.btnClose;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(41)))), ((int)(((byte)(47)))));
            this.btnClose.HoverState.Parent = this.btnClose;
            this.btnClose.Location = new System.Drawing.Point(171, 330);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(177, 41);
            this.btnClose.TabIndex = 36;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // epValidate
            // 
            this.epValidate.ContainerControl = this;
            this.epValidate.Icon = ((System.Drawing.Icon)(resources.GetObject("epValidate.Icon")));
            // 
            // NextLogin
            // 
            this.NextLogin.Interval = 1000;
            this.NextLogin.Tick += new System.EventHandler(this.NextLogin_Tick);
            // 
            // fmLogin
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(144)))));
            this.ClientSize = new System.Drawing.Size(848, 748);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbLogin);
            this.Controls.Add(this.guna2PictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "fmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.fmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epValidate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2GroupBox gbLogin;
        private System.Windows.Forms.Label lbTitle;
        private Guna.UI2.WinForms.Guna2TextBox tbUsername;
        private System.Windows.Forms.Label lbInput1;
        private System.Windows.Forms.Label lbInput2;
        private Guna.UI2.WinForms.Guna2TextBox tbPassword;
        private System.Windows.Forms.CheckBox cbRememberMe;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnGo;
        private System.Windows.Forms.ErrorProvider epValidate;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cbType;
        private System.Windows.Forms.LinkLabel llbForgetPassword;
        private System.Windows.Forms.Timer NextLogin;
    }
}