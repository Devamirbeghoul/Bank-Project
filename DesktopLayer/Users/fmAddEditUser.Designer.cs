namespace DesktopLayer.Users
{
    partial class fmAddEditUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmAddEditUser));
            this.tcPerformAddEditUser = new System.Windows.Forms.TabControl();
            this.tpPersonInfo = new System.Windows.Forms.TabPage();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.ctrPersonInfoWithFilter1 = new DesktopLayer.People.Controls.ctrPersonInfoWithFilter();
            this.tpLoginInfo = new System.Windows.Forms.TabPage();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lbTitleV2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2GroupBox7 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.rbWorker = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbAdmin = new Guna.UI2.WinForms.Guna2RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.tbConfirmPasword = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.cbIsActive = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbUserID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.epValidate = new System.Windows.Forms.ErrorProvider(this.components);
            this.tcPerformAddEditUser.SuspendLayout();
            this.tpPersonInfo.SuspendLayout();
            this.tpLoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.guna2GroupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epValidate)).BeginInit();
            this.SuspendLayout();
            // 
            // tcPerformAddEditUser
            // 
            this.tcPerformAddEditUser.Controls.Add(this.tpPersonInfo);
            this.tcPerformAddEditUser.Controls.Add(this.tpLoginInfo);
            this.tcPerformAddEditUser.Location = new System.Drawing.Point(-54, -132);
            this.tcPerformAddEditUser.Name = "tcPerformAddEditUser";
            this.tcPerformAddEditUser.SelectedIndex = 0;
            this.tcPerformAddEditUser.Size = new System.Drawing.Size(1130, 665);
            this.tcPerformAddEditUser.TabIndex = 49;
            // 
            // tpPersonInfo
            // 
            this.tpPersonInfo.BackColor = System.Drawing.Color.White;
            this.tpPersonInfo.Controls.Add(this.lbTitle);
            this.tpPersonInfo.Controls.Add(this.btnNext);
            this.tpPersonInfo.Controls.Add(this.ctrPersonInfoWithFilter1);
            this.tpPersonInfo.Location = new System.Drawing.Point(4, 30);
            this.tpPersonInfo.Name = "tpPersonInfo";
            this.tpPersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpPersonInfo.Size = new System.Drawing.Size(1122, 631);
            this.tpPersonInfo.TabIndex = 0;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI Historic", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(157)))), ((int)(((byte)(96)))));
            this.lbTitle.Location = new System.Drawing.Point(374, 111);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(269, 50);
            this.lbTitle.TabIndex = 52;
            this.lbTitle.Text = "Add New User";
            // 
            // btnNext
            // 
            this.btnNext.Animated = true;
            this.btnNext.BorderThickness = 1;
            this.btnNext.CheckedState.Parent = this.btnNext;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.CustomImages.Parent = this.btnNext;
            this.btnNext.FillColor = System.Drawing.Color.Transparent;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.Black;
            this.btnNext.HoverState.Parent = this.btnNext;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnNext.ImageSize = new System.Drawing.Size(30, 30);
            this.btnNext.Location = new System.Drawing.Point(870, 579);
            this.btnNext.Name = "btnNext";
            this.btnNext.ShadowDecoration.Parent = this.btnNext;
            this.btnNext.Size = new System.Drawing.Size(120, 33);
            this.btnNext.TabIndex = 50;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrPersonInfoWithFilter1
            // 
            this.ctrPersonInfoWithFilter1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ctrPersonInfoWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrPersonInfoWithFilter1.btnAddVisible = true;
            this.ctrPersonInfoWithFilter1.Filter = true;
            this.ctrPersonInfoWithFilter1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrPersonInfoWithFilter1.Location = new System.Drawing.Point(41, 166);
            this.ctrPersonInfoWithFilter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrPersonInfoWithFilter1.Name = "ctrPersonInfoWithFilter1";
            this.ctrPersonInfoWithFilter1.Size = new System.Drawing.Size(978, 433);
            this.ctrPersonInfoWithFilter1.TabIndex = 49;
            // 
            // tpLoginInfo
            // 
            this.tpLoginInfo.BackColor = System.Drawing.Color.White;
            this.tpLoginInfo.Controls.Add(this.guna2PictureBox1);
            this.tpLoginInfo.Controls.Add(this.lbTitleV2);
            this.tpLoginInfo.Controls.Add(this.label3);
            this.tpLoginInfo.Controls.Add(this.guna2GroupBox7);
            this.tpLoginInfo.Controls.Add(this.label2);
            this.tpLoginInfo.Controls.Add(this.btnBack);
            this.tpLoginInfo.Controls.Add(this.tbConfirmPasword);
            this.tpLoginInfo.Controls.Add(this.tbPassword);
            this.tpLoginInfo.Controls.Add(this.tbUserName);
            this.tpLoginInfo.Controls.Add(this.cbIsActive);
            this.tpLoginInfo.Controls.Add(this.label8);
            this.tpLoginInfo.Controls.Add(this.label4);
            this.tpLoginInfo.Controls.Add(this.lbUserID);
            this.tpLoginInfo.Controls.Add(this.label1);
            this.tpLoginInfo.Location = new System.Drawing.Point(4, 30);
            this.tpLoginInfo.Name = "tpLoginInfo";
            this.tpLoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpLoginInfo.Size = new System.Drawing.Size(1122, 631);
            this.tpLoginInfo.TabIndex = 1;
            this.tpLoginInfo.Text = "tabPage2";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.Location = new System.Drawing.Point(590, 213);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(391, 258);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 70;
            this.guna2PictureBox1.TabStop = false;
            // 
            // lbTitleV2
            // 
            this.lbTitleV2.AutoSize = true;
            this.lbTitleV2.Font = new System.Drawing.Font("Segoe UI Historic", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitleV2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(157)))), ((int)(((byte)(96)))));
            this.lbTitleV2.Location = new System.Drawing.Point(154, 111);
            this.lbTitleV2.Name = "lbTitleV2";
            this.lbTitleV2.Size = new System.Drawing.Size(269, 50);
            this.lbTitleV2.TabIndex = 69;
            this.lbTitleV2.Text = "Add New User";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(480, 580);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 25);
            this.label3.TabIndex = 68;
            this.label3.Text = "Permissions:";
            // 
            // guna2GroupBox7
            // 
            this.guna2GroupBox7.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox7.BorderRadius = 10;
            this.guna2GroupBox7.Controls.Add(this.rbWorker);
            this.guna2GroupBox7.Controls.Add(this.rbAdmin);
            this.guna2GroupBox7.CustomBorderColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox7.FillColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox7.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox7.Location = new System.Drawing.Point(607, 566);
            this.guna2GroupBox7.Name = "guna2GroupBox7";
            this.guna2GroupBox7.ShadowDecoration.Parent = this.guna2GroupBox7;
            this.guna2GroupBox7.Size = new System.Drawing.Size(383, 52);
            this.guna2GroupBox7.TabIndex = 67;
            // 
            // rbWorker
            // 
            this.rbWorker.Animated = true;
            this.rbWorker.AutoSize = true;
            this.rbWorker.Checked = true;
            this.rbWorker.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbWorker.CheckedState.BorderThickness = 0;
            this.rbWorker.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbWorker.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbWorker.CheckedState.InnerOffset = -4;
            this.rbWorker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbWorker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbWorker.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbWorker.Location = new System.Drawing.Point(224, 14);
            this.rbWorker.Name = "rbWorker";
            this.rbWorker.Size = new System.Drawing.Size(78, 25);
            this.rbWorker.TabIndex = 3;
            this.rbWorker.TabStop = true;
            this.rbWorker.Text = "Worker";
            this.rbWorker.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbWorker.UncheckedState.BorderThickness = 2;
            this.rbWorker.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbWorker.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbWorker.UseVisualStyleBackColor = true;
            // 
            // rbAdmin
            // 
            this.rbAdmin.Animated = true;
            this.rbAdmin.AutoSize = true;
            this.rbAdmin.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbAdmin.CheckedState.BorderThickness = 0;
            this.rbAdmin.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbAdmin.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbAdmin.CheckedState.InnerOffset = -4;
            this.rbAdmin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbAdmin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAdmin.Location = new System.Drawing.Point(81, 14);
            this.rbAdmin.Name = "rbAdmin";
            this.rbAdmin.Size = new System.Drawing.Size(73, 25);
            this.rbAdmin.TabIndex = 2;
            this.rbAdmin.TabStop = true;
            this.rbAdmin.Text = "Admin";
            this.rbAdmin.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbAdmin.UncheckedState.BorderThickness = 2;
            this.rbAdmin.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbAdmin.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbAdmin.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(100, 360);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 25);
            this.label2.TabIndex = 66;
            this.label2.Text = "Password:";
            // 
            // btnBack
            // 
            this.btnBack.Animated = true;
            this.btnBack.BorderThickness = 1;
            this.btnBack.CheckedState.Parent = this.btnBack;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.CustomImages.Parent = this.btnBack;
            this.btnBack.FillColor = System.Drawing.Color.Transparent;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Black;
            this.btnBack.HoverState.Parent = this.btnBack;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBack.ImageSize = new System.Drawing.Size(30, 30);
            this.btnBack.Location = new System.Drawing.Point(62, 592);
            this.btnBack.Name = "btnBack";
            this.btnBack.ShadowDecoration.Parent = this.btnBack;
            this.btnBack.Size = new System.Drawing.Size(120, 33);
            this.btnBack.TabIndex = 66;
            this.btnBack.Text = "Back";
            this.btnBack.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // tbConfirmPasword
            // 
            this.tbConfirmPasword.BackColor = System.Drawing.Color.White;
            this.tbConfirmPasword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbConfirmPasword.Location = new System.Drawing.Point(286, 407);
            this.tbConfirmPasword.Name = "tbConfirmPasword";
            this.tbConfirmPasword.Size = new System.Drawing.Size(202, 29);
            this.tbConfirmPasword.TabIndex = 64;
            this.tbConfirmPasword.UseSystemPasswordChar = true;
            this.tbConfirmPasword.Validating += new System.ComponentModel.CancelEventHandler(this.tbConfirmPasword_Validating);
            // 
            // tbPassword
            // 
            this.tbPassword.BackColor = System.Drawing.Color.White;
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPassword.Location = new System.Drawing.Point(221, 358);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(202, 29);
            this.tbPassword.TabIndex = 63;
            this.tbPassword.UseSystemPasswordChar = true;
            this.tbPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbPassword_Validating);
            // 
            // tbUserName
            // 
            this.tbUserName.BackColor = System.Drawing.Color.White;
            this.tbUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUserName.Location = new System.Drawing.Point(221, 312);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(202, 29);
            this.tbUserName.TabIndex = 62;
            this.tbUserName.Validating += new System.ComponentModel.CancelEventHandler(this.tbUserName_Validating);
            // 
            // cbIsActive
            // 
            this.cbIsActive.AutoSize = true;
            this.cbIsActive.Checked = true;
            this.cbIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsActive.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIsActive.Location = new System.Drawing.Point(384, 442);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(104, 29);
            this.cbIsActive.TabIndex = 65;
            this.cbIsActive.Text = "Is Active";
            this.cbIsActive.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(100, 406);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(180, 25);
            this.label8.TabIndex = 59;
            this.label8.Text = "Confirm Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(100, 314);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 25);
            this.label4.TabIndex = 57;
            this.label4.Text = "UserName:";
            // 
            // lbUserID
            // 
            this.lbUserID.AutoSize = true;
            this.lbUserID.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(157)))), ((int)(((byte)(96)))));
            this.lbUserID.Location = new System.Drawing.Point(287, 268);
            this.lbUserID.Name = "lbUserID";
            this.lbUserID.Size = new System.Drawing.Size(50, 25);
            this.lbUserID.TabIndex = 56;
            this.lbUserID.Text = "[???]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(100, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 25);
            this.label1.TabIndex = 54;
            this.label1.Text = "User ID:";
            // 
            // btnClose
            // 
            this.btnClose.Animated = true;
            this.btnClose.BorderThickness = 1;
            this.btnClose.CheckedState.Parent = this.btnClose;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.CustomImages.Parent = this.btnClose;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.HoverState.Parent = this.btnClose;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnClose.ImageSize = new System.Drawing.Size(30, 30);
            this.btnClose.Location = new System.Drawing.Point(694, 539);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(120, 33);
            this.btnClose.TabIndex = 54;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Animated = true;
            this.btnSave.BorderThickness = 1;
            this.btnSave.CheckedState.Parent = this.btnSave;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.CustomImages.Parent = this.btnSave;
            this.btnSave.Enabled = false;
            this.btnSave.FillColor = System.Drawing.Color.Transparent;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.HoverState.Parent = this.btnSave;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSave.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSave.Location = new System.Drawing.Point(820, 539);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShadowDecoration.Parent = this.btnSave;
            this.btnSave.Size = new System.Drawing.Size(120, 33);
            this.btnSave.TabIndex = 55;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // epValidate
            // 
            this.epValidate.ContainerControl = this;
            this.epValidate.Icon = ((System.Drawing.Icon)(resources.GetObject("epValidate.Icon")));
            // 
            // fmAddEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(955, 584);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tcPerformAddEditUser);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "fmAddEditUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New User";
            this.Activated += new System.EventHandler(this.fmAddEditUser_Activated);
            this.Load += new System.EventHandler(this.fmAddEditUser_Load);
            this.tcPerformAddEditUser.ResumeLayout(false);
            this.tpPersonInfo.ResumeLayout(false);
            this.tpPersonInfo.PerformLayout();
            this.tpLoginInfo.ResumeLayout(false);
            this.tpLoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.guna2GroupBox7.ResumeLayout(false);
            this.guna2GroupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epValidate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tcPerformAddEditUser;
        private System.Windows.Forms.TabPage tpPersonInfo;
        private System.Windows.Forms.TabPage tpLoginInfo;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private People.Controls.ctrPersonInfoWithFilter ctrPersonInfoWithFilter1;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.TextBox tbConfirmPasword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.CheckBox cbIsActive;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbUserID;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider epValidate;
        private System.Windows.Forms.Label lbTitleV2;
        private Guna.UI2.WinForms.Guna2RadioButton rbWorker;
        private Guna.UI2.WinForms.Guna2RadioButton rbAdmin;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}