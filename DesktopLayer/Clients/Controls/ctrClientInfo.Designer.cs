namespace DesktopLayer.Clients.Controls
{
    partial class ctrClientInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrPersonInfo1 = new DesktopLayer.People.Controls.ctrPersonInfo();
            this.gbAccountInfo = new System.Windows.Forms.GroupBox();
            this.lbBalance = new System.Windows.Forms.Label();
            this.lbAccountNumber = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbClientID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbAccountInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrPersonInfo1
            // 
            this.ctrPersonInfo1.BackColor = System.Drawing.Color.White;
            this.ctrPersonInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrPersonInfo1.Location = new System.Drawing.Point(0, -4);
            this.ctrPersonInfo1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrPersonInfo1.Name = "ctrPersonInfo1";
            this.ctrPersonInfo1.Size = new System.Drawing.Size(950, 327);
            this.ctrPersonInfo1.TabIndex = 0;
            // 
            // gbAccountInfo
            // 
            this.gbAccountInfo.Controls.Add(this.lbBalance);
            this.gbAccountInfo.Controls.Add(this.lbAccountNumber);
            this.gbAccountInfo.Controls.Add(this.label4);
            this.gbAccountInfo.Controls.Add(this.label3);
            this.gbAccountInfo.Controls.Add(this.lbClientID);
            this.gbAccountInfo.Controls.Add(this.label1);
            this.gbAccountInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAccountInfo.Location = new System.Drawing.Point(8, 315);
            this.gbAccountInfo.Name = "gbAccountInfo";
            this.gbAccountInfo.Size = new System.Drawing.Size(935, 90);
            this.gbAccountInfo.TabIndex = 2;
            this.gbAccountInfo.TabStop = false;
            this.gbAccountInfo.Text = "Account Information";
            // 
            // lbBalance
            // 
            this.lbBalance.AutoSize = true;
            this.lbBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBalance.Location = new System.Drawing.Point(780, 45);
            this.lbBalance.Name = "lbBalance";
            this.lbBalance.Size = new System.Drawing.Size(48, 25);
            this.lbBalance.TabIndex = 5;
            this.lbBalance.Text = "[???]";
            // 
            // lbAccountNumber
            // 
            this.lbAccountNumber.AutoSize = true;
            this.lbAccountNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAccountNumber.Location = new System.Drawing.Point(473, 45);
            this.lbAccountNumber.Name = "lbAccountNumber";
            this.lbAccountNumber.Size = new System.Drawing.Size(48, 25);
            this.lbAccountNumber.TabIndex = 4;
            this.lbAccountNumber.Text = "[???]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(689, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Balance:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(339, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Acc.Number:";
            // 
            // lbClientID
            // 
            this.lbClientID.AutoSize = true;
            this.lbClientID.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClientID.Location = new System.Drawing.Point(117, 45);
            this.lbClientID.Name = "lbClientID";
            this.lbClientID.Size = new System.Drawing.Size(48, 25);
            this.lbClientID.TabIndex = 1;
            this.lbClientID.Text = "[???]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(13, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Client ID :";
            // 
            // ctrClientInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbAccountInfo);
            this.Controls.Add(this.ctrPersonInfo1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ctrClientInfo";
            this.Size = new System.Drawing.Size(960, 420);
            this.gbAccountInfo.ResumeLayout(false);
            this.gbAccountInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private People.Controls.ctrPersonInfo ctrPersonInfo1;
        private System.Windows.Forms.GroupBox gbAccountInfo;
        private System.Windows.Forms.Label lbBalance;
        private System.Windows.Forms.Label lbAccountNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbClientID;
        private System.Windows.Forms.Label label1;
    }
}
