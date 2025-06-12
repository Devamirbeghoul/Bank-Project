namespace DesktopLayer.Password_PinCode
{
    partial class fmSendRequestForChange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmSendRequestForChange));
            this.cbType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbInput1 = new System.Windows.Forms.Label();
            this.tbInput1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSend = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.epValidate = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epValidate)).BeginInit();
            this.SuspendLayout();
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
            this.cbType.Location = new System.Drawing.Point(108, 19);
            this.cbType.Name = "cbType";
            this.cbType.ShadowDecoration.Parent = this.cbType;
            this.cbType.Size = new System.Drawing.Size(229, 36);
            this.cbType.StartIndex = 0;
            this.cbType.TabIndex = 38;
            this.cbType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(41)))), ((int)(((byte)(47)))));
            this.label2.Location = new System.Drawing.Point(31, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 32);
            this.label2.TabIndex = 37;
            this.label2.Text = "Type:";
            // 
            // cbBy
            // 
            this.cbBy.BackColor = System.Drawing.Color.Transparent;
            this.cbBy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(157)))), ((int)(((byte)(96)))));
            this.cbBy.BorderRadius = 12;
            this.cbBy.BorderThickness = 2;
            this.cbBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBy.FocusedColor = System.Drawing.Color.Empty;
            this.cbBy.FocusedState.Parent = this.cbBy;
            this.cbBy.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBy.ForeColor = System.Drawing.Color.Black;
            this.cbBy.FormattingEnabled = true;
            this.cbBy.HoverState.Parent = this.cbBy;
            this.cbBy.ItemHeight = 30;
            this.cbBy.Items.AddRange(new object[] {
            "Email",
            "Phone"});
            this.cbBy.ItemsAppearance.Parent = this.cbBy;
            this.cbBy.Location = new System.Drawing.Point(84, 85);
            this.cbBy.Name = "cbBy";
            this.cbBy.ShadowDecoration.Parent = this.cbBy;
            this.cbBy.Size = new System.Drawing.Size(229, 36);
            this.cbBy.StartIndex = 0;
            this.cbBy.TabIndex = 40;
            this.cbBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cbBy.SelectedIndexChanged += new System.EventHandler(this.cbBy_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(41)))), ((int)(((byte)(47)))));
            this.label1.Location = new System.Drawing.Point(31, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 32);
            this.label1.TabIndex = 39;
            this.label1.Text = "By:";
            // 
            // lbInput1
            // 
            this.lbInput1.AutoSize = true;
            this.lbInput1.BackColor = System.Drawing.Color.Transparent;
            this.lbInput1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInput1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(41)))), ((int)(((byte)(47)))));
            this.lbInput1.Location = new System.Drawing.Point(31, 155);
            this.lbInput1.Name = "lbInput1";
            this.lbInput1.Size = new System.Drawing.Size(78, 32);
            this.lbInput1.TabIndex = 42;
            this.lbInput1.Text = "Email:";
            // 
            // tbInput1
            // 
            this.tbInput1.Animated = true;
            this.tbInput1.BackColor = System.Drawing.Color.Transparent;
            this.tbInput1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(157)))), ((int)(((byte)(96)))));
            this.tbInput1.BorderRadius = 12;
            this.tbInput1.BorderThickness = 2;
            this.tbInput1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbInput1.DefaultText = "";
            this.tbInput1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbInput1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbInput1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbInput1.DisabledState.Parent = this.tbInput1;
            this.tbInput1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbInput1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbInput1.FocusedState.Parent = this.tbInput1;
            this.tbInput1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInput1.ForeColor = System.Drawing.Color.Black;
            this.tbInput1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbInput1.HoverState.Parent = this.tbInput1;
            this.tbInput1.Location = new System.Drawing.Point(127, 150);
            this.tbInput1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbInput1.Name = "tbInput1";
            this.tbInput1.PasswordChar = '\0';
            this.tbInput1.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.tbInput1.PlaceholderText = "";
            this.tbInput1.SelectedText = "";
            this.tbInput1.ShadowDecoration.Parent = this.tbInput1;
            this.tbInput1.Size = new System.Drawing.Size(229, 38);
            this.tbInput1.TabIndex = 41;
            this.tbInput1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbInput1_KeyPress);
            this.tbInput1.Validating += new System.ComponentModel.CancelEventHandler(this.tbInput1_Validating);
            // 
            // btnSend
            // 
            this.btnSend.Animated = true;
            this.btnSend.AutoRoundedCorners = true;
            this.btnSend.BackColor = System.Drawing.Color.Transparent;
            this.btnSend.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(157)))), ((int)(((byte)(96)))));
            this.btnSend.BorderRadius = 19;
            this.btnSend.BorderThickness = 2;
            this.btnSend.CheckedState.Parent = this.btnSend;
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.CustomImages.Parent = this.btnSend;
            this.btnSend.FillColor = System.Drawing.Color.Transparent;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(41)))), ((int)(((byte)(47)))));
            this.btnSend.HoverState.Parent = this.btnSend;
            this.btnSend.Location = new System.Drawing.Point(256, 212);
            this.btnSend.Name = "btnSend";
            this.btnSend.ShadowDecoration.Parent = this.btnSend;
            this.btnSend.Size = new System.Drawing.Size(177, 41);
            this.btnSend.TabIndex = 44;
            this.btnSend.Text = "Send";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
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
            this.btnClose.Location = new System.Drawing.Point(12, 212);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(177, 41);
            this.btnClose.TabIndex = 43;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // epValidate
            // 
            this.epValidate.ContainerControl = this;
            this.epValidate.Icon = ((System.Drawing.Icon)(resources.GetObject("epValidate.Icon")));
            // 
            // fmSendRequestForChange
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(144)))));
            this.ClientSize = new System.Drawing.Size(445, 269);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbInput1);
            this.Controls.Add(this.tbInput1);
            this.Controls.Add(this.cbBy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "fmSendRequestForChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Send Request";
            this.Activated += new System.EventHandler(this.fmSendRequestForChange_Activated);
            this.Load += new System.EventHandler(this.fmSendRequestForChange_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epValidate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cbType;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cbBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbInput1;
        private Guna.UI2.WinForms.Guna2TextBox tbInput1;
        private Guna.UI2.WinForms.Guna2Button btnSend;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.ErrorProvider epValidate;
    }
}