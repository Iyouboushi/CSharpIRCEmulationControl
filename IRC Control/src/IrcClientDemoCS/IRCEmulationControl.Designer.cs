namespace IrcClientDemoCS
{
    partial class IRCEmulationControl
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
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmulators = new System.Windows.Forms.ToolStripMenuItem();
            this.gameboyAdvanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVisualBoyAdvance = new System.Windows.Forms.ToolStripMenuItem();
            this.boycottAdvanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nesterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fceuxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sNESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zSNESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keySettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyBindingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyPressDelayToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.allowDemocracyModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rtbCommands = new System.Windows.Forms.RichTextBox();
            this.lblNick = new System.Windows.Forms.Label();
            this.txtNick = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.txtIRCServer = new System.Windows.Forms.TextBox();
            this.lblChannel = new System.Windows.Forms.Label();
            this.txtIRCChannel = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnPause = new System.Windows.Forms.Button();
            this.lblAnarchy = new System.Windows.Forms.Label();
            this.lblAnarchyPercent = new System.Windows.Forms.Label();
            this.lblDemocracy = new System.Windows.Forms.Label();
            this.lblDemocracyPercent = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstUsers
            // 
            this.lstUsers.BackColor = System.Drawing.Color.Black;
            this.lstUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstUsers.ForeColor = System.Drawing.Color.White;
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.Location = new System.Drawing.Point(564, 111);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(68, 169);
            this.lstUsers.TabIndex = 1;
            // 
            // txtSend
            // 
            this.txtSend.BackColor = System.Drawing.Color.Black;
            this.txtSend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSend.ForeColor = System.Drawing.Color.White;
            this.txtSend.Location = new System.Drawing.Point(12, 312);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(518, 20);
            this.txtSend.TabIndex = 2;
            this.txtSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSend_KeyDown);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.Black;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSend.Location = new System.Drawing.Point(535, 311);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(94, 23);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // rtbOutput
            // 
            this.rtbOutput.BackColor = System.Drawing.Color.Black;
            this.rtbOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbOutput.ForeColor = System.Drawing.Color.White;
            this.rtbOutput.Location = new System.Drawing.Point(15, 111);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(271, 170);
            this.rtbOutput.TabIndex = 4;
            this.rtbOutput.Text = "";
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.Black;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Location = new System.Drawing.Point(499, 29);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(130, 23);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEmulators,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(644, 25);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "mnuMenuBar";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuQuit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(39, 21);
            this.mnuFile.Text = "&File";
            // 
            // mnuQuit
            // 
            this.mnuQuit.Name = "mnuQuit";
            this.mnuQuit.Size = new System.Drawing.Size(100, 22);
            this.mnuQuit.Text = "&Quit";
            this.mnuQuit.Click += new System.EventHandler(this.mnuQuit_Click);
            // 
            // mnuEmulators
            // 
            this.mnuEmulators.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameboyAdvanceToolStripMenuItem,
            this.nESToolStripMenuItem,
            this.sNESToolStripMenuItem});
            this.mnuEmulators.Name = "mnuEmulators";
            this.mnuEmulators.Size = new System.Drawing.Size(78, 21);
            this.mnuEmulators.Text = "&Emulators";
            // 
            // gameboyAdvanceToolStripMenuItem
            // 
            this.gameboyAdvanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVisualBoyAdvance,
            this.boycottAdvanceToolStripMenuItem});
            this.gameboyAdvanceToolStripMenuItem.Name = "gameboyAdvanceToolStripMenuItem";
            this.gameboyAdvanceToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.gameboyAdvanceToolStripMenuItem.Text = "GBA/GB/GBC";
            // 
            // mnuVisualBoyAdvance
            // 
            this.mnuVisualBoyAdvance.Name = "mnuVisualBoyAdvance";
            this.mnuVisualBoyAdvance.Size = new System.Drawing.Size(180, 22);
            this.mnuVisualBoyAdvance.Text = "&VisualBoyAdvance";
            this.mnuVisualBoyAdvance.Click += new System.EventHandler(this.mnuVisualBoyAdvance_Click);
            // 
            // boycottAdvanceToolStripMenuItem
            // 
            this.boycottAdvanceToolStripMenuItem.Name = "boycottAdvanceToolStripMenuItem";
            this.boycottAdvanceToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.boycottAdvanceToolStripMenuItem.Text = "&BoycottAdvance";
            // 
            // nESToolStripMenuItem
            // 
            this.nESToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nesterToolStripMenuItem,
            this.fceuxToolStripMenuItem});
            this.nESToolStripMenuItem.Name = "nESToolStripMenuItem";
            this.nESToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.nESToolStripMenuItem.Text = "NES";
            // 
            // nesterToolStripMenuItem
            // 
            this.nesterToolStripMenuItem.Name = "nesterToolStripMenuItem";
            this.nesterToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.nesterToolStripMenuItem.Text = "&nester";
            // 
            // fceuxToolStripMenuItem
            // 
            this.fceuxToolStripMenuItem.Name = "fceuxToolStripMenuItem";
            this.fceuxToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.fceuxToolStripMenuItem.Text = "f&ceux";
            this.fceuxToolStripMenuItem.Click += new System.EventHandler(this.fceuxToolStripMenuItem_Click);
            // 
            // sNESToolStripMenuItem
            // 
            this.sNESToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zSNESToolStripMenuItem});
            this.sNESToolStripMenuItem.Name = "sNESToolStripMenuItem";
            this.sNESToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.sNESToolStripMenuItem.Text = "SNES";
            // 
            // zSNESToolStripMenuItem
            // 
            this.zSNESToolStripMenuItem.Name = "zSNESToolStripMenuItem";
            this.zSNESToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.zSNESToolStripMenuItem.Text = "&ZSNES";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keySettingsToolStripMenuItem,
            this.allowDemocracyModeToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(66, 21);
            this.settingsToolStripMenuItem.Text = "&Settings";
            // 
            // keySettingsToolStripMenuItem
            // 
            this.keySettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keyBindingsToolStripMenuItem,
            this.keyPressDelayToolStripMenuItem1});
            this.keySettingsToolStripMenuItem.Name = "keySettingsToolStripMenuItem";
            this.keySettingsToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.keySettingsToolStripMenuItem.Text = "Con&trol Settings";
            // 
            // keyBindingsToolStripMenuItem
            // 
            this.keyBindingsToolStripMenuItem.Name = "keyBindingsToolStripMenuItem";
            this.keyBindingsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.keyBindingsToolStripMenuItem.Text = "&Key Bindings";
            this.keyBindingsToolStripMenuItem.Click += new System.EventHandler(this.keyBindingsToolStripMenuItem_Click);
            // 
            // keyPressDelayToolStripMenuItem1
            // 
            this.keyPressDelayToolStripMenuItem1.Name = "keyPressDelayToolStripMenuItem1";
            this.keyPressDelayToolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.keyPressDelayToolStripMenuItem1.Text = "Ke&y Press Delay";
            this.keyPressDelayToolStripMenuItem1.Click += new System.EventHandler(this.keyPressDelayToolStripMenuItem1_Click);
            // 
            // allowDemocracyModeToolStripMenuItem
            // 
            this.allowDemocracyModeToolStripMenuItem.Checked = true;
            this.allowDemocracyModeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allowDemocracyModeToolStripMenuItem.Name = "allowDemocracyModeToolStripMenuItem";
            this.allowDemocracyModeToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.allowDemocracyModeToolStripMenuItem.Text = "Allow Democracy Mode";
            this.allowDemocracyModeToolStripMenuItem.Click += new System.EventHandler(this.allowDemocracyModeToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // rtbCommands
            // 
            this.rtbCommands.BackColor = System.Drawing.Color.Black;
            this.rtbCommands.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbCommands.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbCommands.ForeColor = System.Drawing.Color.White;
            this.rtbCommands.Location = new System.Drawing.Point(308, 111);
            this.rtbCommands.Name = "rtbCommands";
            this.rtbCommands.Size = new System.Drawing.Size(250, 170);
            this.rtbCommands.TabIndex = 7;
            this.rtbCommands.Text = "";
            // 
            // lblNick
            // 
            this.lblNick.AutoSize = true;
            this.lblNick.BackColor = System.Drawing.Color.Black;
            this.lblNick.Location = new System.Drawing.Point(12, 35);
            this.lblNick.Name = "lblNick";
            this.lblNick.Size = new System.Drawing.Size(53, 13);
            this.lblNick.TabIndex = 8;
            this.lblNick.Text = "IRC Nick:";
            // 
            // txtNick
            // 
            this.txtNick.BackColor = System.Drawing.Color.Black;
            this.txtNick.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNick.ForeColor = System.Drawing.Color.White;
            this.txtNick.Location = new System.Drawing.Point(80, 32);
            this.txtNick.Name = "txtNick";
            this.txtNick.Size = new System.Drawing.Size(100, 20);
            this.txtNick.TabIndex = 9;
            this.txtNick.Text = "BadGamerBot";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.ForeColor = System.Drawing.Color.Gray;
            this.lblServer.Location = new System.Drawing.Point(12, 64);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(62, 13);
            this.lblServer.TabIndex = 10;
            this.lblServer.Text = "IRC Server:";
            // 
            // txtIRCServer
            // 
            this.txtIRCServer.BackColor = System.Drawing.Color.Black;
            this.txtIRCServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIRCServer.ForeColor = System.Drawing.Color.White;
            this.txtIRCServer.Location = new System.Drawing.Point(80, 61);
            this.txtIRCServer.Name = "txtIRCServer";
            this.txtIRCServer.Size = new System.Drawing.Size(100, 20);
            this.txtIRCServer.TabIndex = 11;
            this.txtIRCServer.Text = "irc.esper.net";
            // 
            // lblChannel
            // 
            this.lblChannel.AutoSize = true;
            this.lblChannel.Location = new System.Drawing.Point(258, 35);
            this.lblChannel.Name = "lblChannel";
            this.lblChannel.Size = new System.Drawing.Size(70, 13);
            this.lblChannel.TabIndex = 12;
            this.lblChannel.Text = "IRC Channel:";
            // 
            // txtIRCChannel
            // 
            this.txtIRCChannel.BackColor = System.Drawing.Color.Black;
            this.txtIRCChannel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIRCChannel.ForeColor = System.Drawing.Color.White;
            this.txtIRCChannel.Location = new System.Drawing.Point(334, 32);
            this.txtIRCChannel.Name = "txtIRCChannel";
            this.txtIRCChannel.Size = new System.Drawing.Size(159, 20);
            this.txtIRCChannel.TabIndex = 13;
            this.txtIRCChannel.Text = "#BadGamingControl";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(258, 68);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 14;
            this.lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.Black;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.ForeColor = System.Drawing.Color.White;
            this.txtPassword.Location = new System.Drawing.Point(334, 61);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(159, 20);
            this.txtPassword.TabIndex = 15;
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.Color.Black;
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPause.ForeColor = System.Drawing.Color.White;
            this.btnPause.Location = new System.Drawing.Point(499, 58);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(130, 23);
            this.btnPause.TabIndex = 16;
            this.btnPause.Text = "Pause Control";
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // lblAnarchy
            // 
            this.lblAnarchy.AutoSize = true;
            this.lblAnarchy.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnarchy.ForeColor = System.Drawing.Color.White;
            this.lblAnarchy.Location = new System.Drawing.Point(304, 284);
            this.lblAnarchy.Name = "lblAnarchy";
            this.lblAnarchy.Size = new System.Drawing.Size(66, 19);
            this.lblAnarchy.TabIndex = 17;
            this.lblAnarchy.Text = "Anarchy";
            // 
            // lblAnarchyPercent
            // 
            this.lblAnarchyPercent.AutoSize = true;
            this.lblAnarchyPercent.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnarchyPercent.ForeColor = System.Drawing.Color.White;
            this.lblAnarchyPercent.Location = new System.Drawing.Point(366, 284);
            this.lblAnarchyPercent.Name = "lblAnarchyPercent";
            this.lblAnarchyPercent.Size = new System.Drawing.Size(44, 19);
            this.lblAnarchyPercent.TabIndex = 18;
            this.lblAnarchyPercent.Text = "100%";
            // 
            // lblDemocracy
            // 
            this.lblDemocracy.AutoSize = true;
            this.lblDemocracy.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDemocracy.ForeColor = System.Drawing.Color.White;
            this.lblDemocracy.Location = new System.Drawing.Point(413, 284);
            this.lblDemocracy.Name = "lblDemocracy";
            this.lblDemocracy.Size = new System.Drawing.Size(81, 19);
            this.lblDemocracy.TabIndex = 19;
            this.lblDemocracy.Text = "Democracy";
            // 
            // lblDemocracyPercent
            // 
            this.lblDemocracyPercent.AutoSize = true;
            this.lblDemocracyPercent.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDemocracyPercent.ForeColor = System.Drawing.Color.White;
            this.lblDemocracyPercent.Location = new System.Drawing.Point(499, 284);
            this.lblDemocracyPercent.Name = "lblDemocracyPercent";
            this.lblDemocracyPercent.Size = new System.Drawing.Size(28, 19);
            this.lblDemocracyPercent.TabIndex = 20;
            this.lblDemocracyPercent.Text = "0%";
            // 
            // IRCEmulationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(644, 347);
            this.Controls.Add(this.lblDemocracyPercent);
            this.Controls.Add(this.lblDemocracy);
            this.Controls.Add(this.lblAnarchyPercent);
            this.Controls.Add(this.lblAnarchy);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtIRCChannel);
            this.Controls.Add(this.lblChannel);
            this.Controls.Add(this.txtIRCServer);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.txtNick);
            this.Controls.Add(this.lblNick);
            this.Controls.Add(this.rtbCommands);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.rtbOutput);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.lstUsers);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.Gray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(660, 385);
            this.MinimumSize = new System.Drawing.Size(660, 385);
            this.Name = "IRCEmulationControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IRC Emulation Control - version 1.6";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuEmulators;
        private System.Windows.Forms.RichTextBox rtbCommands;
        private System.Windows.Forms.ToolStripMenuItem mnuQuit;
        private System.Windows.Forms.Label lblNick;
        private System.Windows.Forms.TextBox txtNick;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.TextBox txtIRCServer;
        private System.Windows.Forms.Label lblChannel;
        private System.Windows.Forms.TextBox txtIRCChannel;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.ToolStripMenuItem gameboyAdvanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuVisualBoyAdvance;
        private System.Windows.Forms.ToolStripMenuItem boycottAdvanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nesterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sNESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zSNESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fceuxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keySettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyBindingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyPressDelayToolStripMenuItem1;
        private System.Windows.Forms.Label lblAnarchy;
        private System.Windows.Forms.Label lblAnarchyPercent;
        private System.Windows.Forms.Label lblDemocracy;
        private System.Windows.Forms.Label lblDemocracyPercent;
        private System.Windows.Forms.ToolStripMenuItem allowDemocracyModeToolStripMenuItem;
    }
}

