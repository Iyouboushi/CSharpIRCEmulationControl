namespace IrcClientDemoCS
{
    partial class frmAbout
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
            this.btnOkay = new System.Windows.Forms.Button();
            this.lnklblEmail = new System.Windows.Forms.LinkLabel();
            this.lblKaiouTitle = new System.Windows.Forms.Label();
            this.lblByJamesIyou = new System.Windows.Forms.Label();
            this.lblVersionDate = new System.Windows.Forms.Label();
            this.lnklblWebsite = new System.Windows.Forms.LinkLabel();
            this.lblSeperator = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblUpdatedOn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOkay
            // 
            this.btnOkay.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOkay.Location = new System.Drawing.Point(96, 133);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(112, 27);
            this.btnOkay.TabIndex = 0;
            this.btnOkay.Text = "Continue";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // lnklblEmail
            // 
            this.lnklblEmail.AutoSize = true;
            this.lnklblEmail.Location = new System.Drawing.Point(98, 62);
            this.lnklblEmail.Name = "lnklblEmail";
            this.lnklblEmail.Size = new System.Drawing.Size(35, 13);
            this.lnklblEmail.TabIndex = 2;
            this.lnklblEmail.TabStop = true;
            this.lnklblEmail.Text = "E-mail";
            this.toolTip1.SetToolTip(this.lnklblEmail, "E-mail James");
            this.lnklblEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblEmail_LinkClicked);
            // 
            // lblKaiouTitle
            // 
            this.lblKaiouTitle.AutoSize = true;
            this.lblKaiouTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKaiouTitle.Location = new System.Drawing.Point(58, 12);
            this.lblKaiouTitle.Name = "lblKaiouTitle";
            this.lblKaiouTitle.Size = new System.Drawing.Size(191, 20);
            this.lblKaiouTitle.TabIndex = 3;
            this.lblKaiouTitle.Text = "C# IRC Emulation Control";
            // 
            // lblByJamesIyou
            // 
            this.lblByJamesIyou.AutoSize = true;
            this.lblByJamesIyou.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblByJamesIyou.Location = new System.Drawing.Point(80, 39);
            this.lblByJamesIyou.Name = "lblByJamesIyou";
            this.lblByJamesIyou.Size = new System.Drawing.Size(138, 16);
            this.lblByJamesIyou.TabIndex = 4;
            this.lblByJamesIyou.Text = "by: James Iyouboushi";
            // 
            // lblVersionDate
            // 
            this.lblVersionDate.AutoSize = true;
            this.lblVersionDate.Location = new System.Drawing.Point(71, 89);
            this.lblVersionDate.Name = "lblVersionDate";
            this.lblVersionDate.Size = new System.Drawing.Size(154, 13);
            this.lblVersionDate.TabIndex = 5;
            this.lblVersionDate.Text = "Created on: February 16, 2014 ";
            // 
            // lnklblWebsite
            // 
            this.lnklblWebsite.AutoSize = true;
            this.lnklblWebsite.Location = new System.Drawing.Point(158, 62);
            this.lnklblWebsite.Name = "lnklblWebsite";
            this.lnklblWebsite.Size = new System.Drawing.Size(46, 13);
            this.lnklblWebsite.TabIndex = 6;
            this.lnklblWebsite.TabStop = true;
            this.lnklblWebsite.Text = "Website";
            this.toolTip1.SetToolTip(this.lnklblWebsite, "Open James\' Site");
            this.lnklblWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblWebsite_LinkClicked);
            // 
            // lblSeperator
            // 
            this.lblSeperator.AutoSize = true;
            this.lblSeperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeperator.Location = new System.Drawing.Point(139, 60);
            this.lblSeperator.Name = "lblSeperator";
            this.lblSeperator.Size = new System.Drawing.Size(13, 15);
            this.lblSeperator.TabIndex = 7;
            this.lblSeperator.Text = "||";
            // 
            // lblUpdatedOn
            // 
            this.lblUpdatedOn.AutoSize = true;
            this.lblUpdatedOn.Location = new System.Drawing.Point(68, 103);
            this.lblUpdatedOn.Name = "lblUpdatedOn";
            this.lblUpdatedOn.Size = new System.Drawing.Size(155, 13);
            this.lblUpdatedOn.TabIndex = 9;
            this.lblUpdatedOn.Text = "Updated on: February 25, 2014";
            // 
            // frmAbout
            // 
            this.AcceptButton = this.btnOkay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOkay;
            this.ClientSize = new System.Drawing.Size(309, 176);
            this.Controls.Add(this.lblUpdatedOn);
            this.Controls.Add(this.lblSeperator);
            this.Controls.Add(this.lnklblWebsite);
            this.Controls.Add(this.lblVersionDate);
            this.Controls.Add(this.lblByJamesIyou);
            this.Controls.Add(this.lblKaiouTitle);
            this.Controls.Add(this.lnklblEmail);
            this.Controls.Add(this.btnOkay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(325, 214);
            this.MinimumSize = new System.Drawing.Size(325, 214);
            this.Name = "frmAbout";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About C# IRC Emulation Control";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOkay;
        private System.Windows.Forms.LinkLabel lnklblEmail;
        private System.Windows.Forms.Label lblKaiouTitle;
        private System.Windows.Forms.Label lblByJamesIyou;
        private System.Windows.Forms.Label lblVersionDate;
        private System.Windows.Forms.LinkLabel lnklblWebsite;
        private System.Windows.Forms.Label lblSeperator;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblUpdatedOn;
    }
}