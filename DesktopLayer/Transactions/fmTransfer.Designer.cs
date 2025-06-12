namespace DesktopLayer.Transactions
{
    partial class fmTransfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmTransfer));
            this.ctrClientInfoWithFilter1 = new DesktopLayer.Clients.Controls.ctrClientInfoWithFilter();
            this.epValidate = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnPerform = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.tbAmount = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbFrom = new System.Windows.Forms.Label();
            this.lbTo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnNextBack = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.epValidate)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrClientInfoWithFilter1
            // 
            this.ctrClientInfoWithFilter1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ctrClientInfoWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrClientInfoWithFilter1.btnAddVisible = true;
            this.ctrClientInfoWithFilter1.Filter = true;
            this.ctrClientInfoWithFilter1.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrClientInfoWithFilter1.Location = new System.Drawing.Point(1, -8);
            this.ctrClientInfoWithFilter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrClientInfoWithFilter1.Name = "ctrClientInfoWithFilter1";
            this.ctrClientInfoWithFilter1.Size = new System.Drawing.Size(954, 527);
            this.ctrClientInfoWithFilter1.TabIndex = 0;
            this.ctrClientInfoWithFilter1.ClientSelected += OnClientSelected;
            // 
            // epValidate
            // 
            this.epValidate.ContainerControl = this;
            this.epValidate.Icon = ((System.Drawing.Icon)(resources.GetObject("epValidate.Icon")));
            // 
            // btnPerform
            // 
            this.btnPerform.Animated = true;
            this.btnPerform.AutoRoundedCorners = true;
            this.btnPerform.BackColor = System.Drawing.Color.Transparent;
            this.btnPerform.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(157)))), ((int)(((byte)(96)))));
            this.btnPerform.BorderRadius = 19;
            this.btnPerform.BorderThickness = 2;
            this.btnPerform.CheckedState.Parent = this.btnPerform;
            this.btnPerform.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPerform.CustomImages.Parent = this.btnPerform;
            this.btnPerform.Enabled = false;
            this.btnPerform.FillColor = System.Drawing.Color.Transparent;
            this.btnPerform.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPerform.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(41)))), ((int)(((byte)(47)))));
            this.btnPerform.HoverState.Parent = this.btnPerform;
            this.btnPerform.Location = new System.Drawing.Point(770, 602);
            this.btnPerform.Name = "btnPerform";
            this.btnPerform.ShadowDecoration.Parent = this.btnPerform;
            this.btnPerform.Size = new System.Drawing.Size(177, 41);
            this.btnPerform.TabIndex = 52;
            this.btnPerform.Text = "Perform";
            this.btnPerform.Click += new System.EventHandler(this.btnPerform_Click);
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
            this.btnClose.Location = new System.Drawing.Point(587, 602);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(177, 41);
            this.btnClose.TabIndex = 51;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // tbAmount
            // 
            this.tbAmount.Animated = true;
            this.tbAmount.BackColor = System.Drawing.Color.Transparent;
            this.tbAmount.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(157)))), ((int)(((byte)(96)))));
            this.tbAmount.BorderRadius = 12;
            this.tbAmount.BorderThickness = 2;
            this.tbAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbAmount.DefaultText = "";
            this.tbAmount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbAmount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbAmount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbAmount.DisabledState.Parent = this.tbAmount;
            this.tbAmount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbAmount.Enabled = false;
            this.tbAmount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbAmount.FocusedState.Parent = this.tbAmount;
            this.tbAmount.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAmount.ForeColor = System.Drawing.Color.Black;
            this.tbAmount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbAmount.HoverState.Parent = this.tbAmount;
            this.tbAmount.Location = new System.Drawing.Point(126, 602);
            this.tbAmount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.PasswordChar = '\0';
            this.tbAmount.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.tbAmount.PlaceholderText = "";
            this.tbAmount.SelectedText = "";
            this.tbAmount.ShadowDecoration.Parent = this.tbAmount;
            this.tbAmount.Size = new System.Drawing.Size(229, 38);
            this.tbAmount.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 615);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 25);
            this.label1.TabIndex = 49;
            this.label1.Text = "Amount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(68, 534);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 25);
            this.label2.TabIndex = 53;
            this.label2.Text = "From:";
            // 
            // lbFrom
            // 
            this.lbFrom.AutoSize = true;
            this.lbFrom.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFrom.Location = new System.Drawing.Point(136, 534);
            this.lbFrom.Name = "lbFrom";
            this.lbFrom.Size = new System.Drawing.Size(51, 25);
            this.lbFrom.TabIndex = 60;
            this.lbFrom.Text = "[???]";
            this.lbFrom.Validating += new System.ComponentModel.CancelEventHandler(this.lbFrom_Validating);
            // 
            // lbTo
            // 
            this.lbTo.AutoSize = true;
            this.lbTo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTo.Location = new System.Drawing.Point(816, 534);
            this.lbTo.Name = "lbTo";
            this.lbTo.Size = new System.Drawing.Size(51, 25);
            this.lbTo.TabIndex = 62;
            this.lbTo.Text = "[???]";
            this.lbTo.Validating += new System.ComponentModel.CancelEventHandler(this.lbFrom_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(774, 534);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 25);
            this.label4.TabIndex = 61;
            this.label4.Text = "To:";
            // 
            // btnNextBack
            // 
            this.btnNextBack.Animated = true;
            this.btnNextBack.AutoRoundedCorners = true;
            this.btnNextBack.BackColor = System.Drawing.Color.Transparent;
            this.btnNextBack.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(157)))), ((int)(((byte)(96)))));
            this.btnNextBack.BorderRadius = 19;
            this.btnNextBack.BorderThickness = 2;
            this.btnNextBack.CheckedState.Parent = this.btnNextBack;
            this.btnNextBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextBack.CustomImages.Parent = this.btnNextBack;
            this.btnNextBack.FillColor = System.Drawing.Color.Transparent;
            this.btnNextBack.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(41)))), ((int)(((byte)(47)))));
            this.btnNextBack.HoverState.Parent = this.btnNextBack;
            this.btnNextBack.Location = new System.Drawing.Point(391, 527);
            this.btnNextBack.Name = "btnNextBack";
            this.btnNextBack.ShadowDecoration.Parent = this.btnNextBack;
            this.btnNextBack.Size = new System.Drawing.Size(177, 41);
            this.btnNextBack.TabIndex = 63;
            this.btnNextBack.Text = "Next";
            this.btnNextBack.Click += new System.EventHandler(this.btnNextBack_Click);
            // 
            // fmTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(959, 661);
            this.Controls.Add(this.btnNextBack);
            this.Controls.Add(this.lbTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPerform);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbAmount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrClientInfoWithFilter1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "fmTransfer";
            this.Text = "fmTransfer";
            this.Activated += new System.EventHandler(this.fmTransfer_Activated);
            this.Load += new System.EventHandler(this.fmTransfer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epValidate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Clients.Controls.ctrClientInfoWithFilter ctrClientInfoWithFilter1;
        private System.Windows.Forms.ErrorProvider epValidate;
        private Guna.UI2.WinForms.Guna2Button btnPerform;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2TextBox tbAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbFrom;
        private Guna.UI2.WinForms.Guna2Button btnNextBack;
    }
}