using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TechLifeForum;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.IO;
using InputManager;
using Microsoft.VisualBasic;

namespace IrcClientDemoCS
{
    public partial class IRCEmulationControl : Form
    {

        // Set a default sleep delay that happens when a button is pressed. 
        // The slower the delay the longer the button is held down.  
        // 100 ms seems to work with most.
        int sleepDelay = 100;

        // Set the default key bindings.
        // This is really bad code and needs to be changed later.
#region KeyBindings
        String Abutton = "HOME";
        String Bbutton = "END";
        String Cbutton = "I";
        String Lbutton = "INSERT";
        String Rbutton = "DELETE";
        String Xbutton = "P";
        String Ybutton = "O";
        String L1button = "INSERT";
        String R1button = "DELETE";
        String R2button = "T";
        String L2button = "E";
        String TriangleButton = "D";
        String SquareButton = "S";
        String CircleButton = "X";
        String StartButton = "PageUp";
        String SelectButton = "PageDown";
        String DpadUpButton = "UP";
        String DpadDownButton = "DOWN";
        String DpadLeftButton = "LEFT";
        String DpadRightButton = "RIGHT";
#endregion



        public IRCEmulationControl()
        {

            //Adding keyboard event handlers and installing the hook
            KeyboardHook.KeyDown += new KeyboardHook.KeyDownEventHandler(KeyboardHook_KeyDown);
            KeyboardHook.KeyUp += new KeyboardHook.KeyUpEventHandler(KeyboardHook_KeyUp);
            KeyboardHook.InstallHook();

           
            InitializeComponent();
            getEmulatorHandle();


            // If a settings.cfg exists, let's load in the saved settings.
            if (File.Exists("settings.cfg"))
            {

                StreamReader sr = new StreamReader("settings.cfg");
                string keystring = sr.ReadToEnd();
                sr.Close();

                string[] settings = keystring.Substring(0, keystring.LastIndexOf(',')).Split(',');
                int settingsCount = settings.Count();

                // Only load the settings if all 4 settings are present. 
                if (settingsCount == 4)
                {
                    txtNick.Text = settings[0].ToString(); 
                    txtIRCChannel.Text = settings[1].ToString();
                    txtIRCServer.Text = settings[2].ToString();
                    txtPassword.Text = settings[3].ToString();
                }

                // Only load the settings if all 4 settings are present. 
                if (settingsCount == 5)
                {
                    txtNick.Text = settings[0].ToString();
                    txtIRCChannel.Text = settings[1].ToString();
                    txtIRCServer.Text = settings[2].ToString();
                    txtPassword.Text = settings[3].ToString();
                    try
                    {
                        sleepDelay = Convert.ToInt32(settings[4]);
                    }
                    catch (Exception e)
                    {
                        sleepDelay = 100;
                    }
                }

                // TO DO: Load key bindings
                loadKeyConfig();

            }


        }
        IrcClient irc;

        private void txtSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSend.PerformClick();
        }

#region ConnectButton
        private void btnConnect_Click(object sender, EventArgs e)
        {
            string ircserver = txtIRCServer.Text;
            if (ircserver == "") { ircserver = "irc.esper.net"; }

            irc = new IrcClient(ircserver, 6667);

            if (txtNick.Text != "") { irc.Nick = txtNick.Text; }
            if (txtNick.Text == "") { irc.Nick = "BadGamingBot"; }


            if (txtIRCChannel.Text != "")
            {
                if (!txtIRCChannel.Text.StartsWith("#"))
                    txtIRCChannel.Text = "#" + txtIRCChannel.Text;
            }

            if (txtPassword.Text != "") { irc.ServerPass = txtPassword.Text; }

            rtbOutput.AppendText("Connecting to " + ircserver + " as " + irc.Nick + "\r\n");
            rtbOutput.ScrollToCaret();

            AddListeners();
            irc.Connect();

            txtIRCChannel.Enabled = false;
            txtIRCServer.Enabled = false;
            txtNick.Enabled = false;
            txtPassword.Enabled = false;
            txtPassword.PasswordChar = '*';

            btnSend.Enabled = true;
            btnPause.Enabled = true;
            txtSend.Enabled = true;

            // if the server is twitch, disable the scroll bars on the command list (potential for this to become gigantic)
            if ((txtIRCServer.Text == "199.9.252.26") || (txtIRCServer.Text == "irc.twitch.tv"))
                rtbCommands.ScrollBars = RichTextBoxScrollBars.None; 

            // Save all settings to a simple text file.
            StringBuilder ircSettings = new StringBuilder();

            ircSettings.Append(txtNick.Text + ",");
            ircSettings.Append(txtIRCChannel.Text + ",");
            ircSettings.Append(txtIRCServer.Text + ",");
            ircSettings.Append(txtPassword.Text + ",");
            ircSettings.Append(sleepDelay.ToString() + ",");
            
            StreamWriter sw = new StreamWriter("settings.cfg");
            sw.Write(ircSettings.ToString());
            sw.Flush();
            sw.Close();

            // Load the key bindings into memory to be used.


            // Start an idle timer.
            idleTimer = new System.Threading.Timer(new TimerCallback(TimerProc));
            idleTimer.Change(600000, 0);    // timer start running
        }
#endregion
        
        private void loadKeyConfig()
        {
            if (File.Exists("keys.cfg"))
            {
                StreamReader sr = new StreamReader("keys.cfg");
                string keystring = sr.ReadToEnd();
                sr.Close();

                string[] keySettings = keystring.Substring(0, keystring.LastIndexOf(',')).Split(',');
                int keyCount = keySettings.Count();

                if (keyCount == 20)
                {
                    try
                    {
                        Abutton = keySettings[0].ToString();
                        Bbutton = keySettings[1].ToString();
                        Cbutton = keySettings[2].ToString();
                        Lbutton = keySettings[3].ToString();
                        Rbutton = keySettings[4].ToString();
                        Xbutton = keySettings[5].ToString();
                        Ybutton = keySettings[6].ToString();
                        L1button = keySettings[7].ToString();
                        L2button = keySettings[8].ToString();
                        R1button = keySettings[9].ToString();
                        R2button = keySettings[10].ToString();
                        TriangleButton = keySettings[11].ToString();
                        SquareButton = keySettings[12].ToString();
                        CircleButton = keySettings[13].ToString();
                        StartButton = keySettings[14].ToString();
                        SelectButton = keySettings[15].ToString();
                        DpadUpButton = keySettings[16].ToString();
                        DpadDownButton = keySettings[17].ToString();
                        DpadLeftButton = keySettings[18].ToString();
                        DpadRightButton = keySettings[19].ToString();
                    }
                    catch (Exception keyException)
                    {
                        rtbOutput.AppendText("Error in loading the key config. \r\n");
                        rtbOutput.AppendText(keyException.ToString() + "\r\n");
                        return;
                    }

                }


            }
        }

        private void AddListeners()
        {
            // hopefully these are self explanitory
            // you can also subscribe to events
            // using a regular method that accepted
            // the required parameters

            irc.ChannelMessage += (c, u, m) =>
            {

                if (controlPause)
                    return;

                string message = m.ToUpper();
                message = message.Replace(":", "");


                // Check to see if it's a command. If it is, display it to the command box
                // and then pass the command along to the emulation control.
                switch (message)
                {
                    case "A":
                    case "B":
                    case "L":
                    case "R":
                    case "R1":
                    case "R2":
                    case "L1":
                    case "L2":
                    case "X":
                    case "Y":
                    case "START":
                    case "SELECT":
                    case "AB":
                    case "BA":
                        rtbCommands.AppendText(u + ": " + message + "\r\n");
                        rtbCommands.ScrollToCaret();
                        controlEmulator(message, u);
                        break;

                    case "RIGHT2":
                        rtbCommands.AppendText(u + ": \u2192 \u2192 \r\n");
                        rtbCommands.ScrollToCaret();
                        controlEmulator(message, u);
                        break;

                    case "UP":
                        rtbCommands.AppendText(u + ": \u2191 \r\n");
                        rtbCommands.ScrollToCaret();
                        controlEmulator(message, u);
                        break;

                    case "LEFT":
                        rtbCommands.AppendText(u + ": \u2190 \r\n");
                        rtbCommands.ScrollToCaret();
                        controlEmulator(message, u);
                        break;

                    case "LEFT2":
                        rtbCommands.AppendText(u + ": \u2190 \u2190 \r\n");
                        rtbCommands.ScrollToCaret();
                        controlEmulator(message, u);
                        break;

                    case "DOWN":
                        rtbCommands.AppendText(u + ": \u2193 \r\n");
                        rtbCommands.ScrollToCaret();
                        controlEmulator(message, u);
                        break;

                    case "RIGHT":
                        rtbCommands.AppendText(u + ": \u2192 \r\n");
                        rtbCommands.ScrollToCaret();
                        controlEmulator(message, u);
                        break;

                    case "DOWNA":
                        rtbCommands.AppendText(u + ": \u2193 A \r\n");
                        rtbCommands.ScrollToCaret();
                        controlEmulator(message, u);
                        break;

                    case "DOWNB":
                        rtbCommands.AppendText(u + ": \u2193 B \r\n");
                        rtbCommands.ScrollToCaret();
                        controlEmulator(message, u);
                        break;
                    case "O":
                    case "CIRCLE":
                        rtbCommands.AppendText(u +": O \r\n");
                        controlEmulator(message, u);
                        break;
                    case "TRIANGLE":
                        rtbCommands.AppendText(u + ": ▲ \r\n");
                        controlEmulator(message, u);
                        break;
                    case "SQUARE":
                        rtbCommands.AppendText(u + ": [] \r\n");
                        controlEmulator(message, u);
                        break;


                    // TODO: Anarchy vs Democracy bar
                    case "ANARCHY":
                    case "DEMOCRACY":
                        break;
                        
                    // If it's not a command, output the text to the IRC output box.
                    default:
                        rtbOutput.AppendText(u + ": " + m + "\r\n");
                        rtbOutput.ScrollToCaret();
                        break;
                }
            };
            irc.ServerMessage += (m) =>
            {
                try
                {

                    rtbOutput.AppendText(m + "\n");
                    rtbOutput.ScrollToCaret();
                    Thread.Sleep(100);
                }
                catch (Exception ex)
                {
                    rtbOutput.AppendText("Error found: " + ex.ToString());
                }
            };
            irc.UpdateUsers += (c, u) =>
            {
                lstUsers.Items.Clear();
                if (txtIRCServer.Text != "199.9.252.26")
                {
                    int NumberOfChannelUsers = lstUsers.Items.Count;
                    if (NumberOfChannelUsers <= 50) { lstUsers.Items.AddRange(u); }
                }
                else
                {
                    lstUsers.Enabled = false;
                    lstUsers.BackColor = System.Drawing.Color.Black;
                }

            };
            irc.ExceptionThrown += (ex) =>
            {
                rtbOutput.AppendText(ex.Message);
            };
            irc.OnConnect += () =>
            {
                // once we're connected show it and enable the send button
                rtbOutput.AppendText("Connected!\n");
                String ircChannel = txtIRCChannel.Text;

                if (txtIRCChannel.Text == "") { ircChannel = "#BadGamingControl"; }

                irc.JoinChannel(ircChannel);
                btnSend.Enabled = true;
            };
        }

        // Send a line of text to the channel.
        // Can't do commands via this.
        private void btnSend_Click(object sender, EventArgs e)
        {
            String ircChannel = txtIRCChannel.Text;
            if (txtIRCChannel.Text == "") { ircChannel = "#BadGamingControl"; }


            if (txtSend.Text.ToUpper() == "/HANDLE")
            {
                rtbOutput.AppendText("command: /HANDLE \r\n");
                rtbOutput.AppendText("The current window handle is: " + handle.ToString() + "\r\n");
                txtSend.Clear();
                txtSend.Focus();
                return;
            }

            if (txtSend.Text.ToUpper().StartsWith("/SETEMU"))
            {
                string[] commandString;
                commandString = txtSend.Text.Split(new char[] { ' ' });


                rtbOutput.AppendText("command: /SETEMU \r\n");

                if (commandString.Count() >= 2)
                {
                    emulatorRunning = windowHandle = commandString[1].ToString();
                    getEmulatorHandle();

                    rtbOutput.AppendText(emulatorRunning + " selected as the emulator\r\n");
                    rtbOutput.ScrollToCaret();
                }

                txtSend.Clear();
                txtSend.Focus();
                return;

            }

                try
                {
                    irc.SendMessage(ircChannel, txtSend.Text);
                    rtbOutput.AppendText("You:\t" + txtSend.Text + "\r");
                }
                catch (Exception exception)
                {
                    rtbOutput.AppendText("Error in sending message. Are you connected? \r");
                }

            txtSend.Clear();
            txtSend.Focus();

         

        }

        // Pause button. 
        private void btnPause_Click(object sender, EventArgs e)
        {
            if (controlPause)
            {
                btnPause.Text = "Pause Control";
                controlPause = false;
                return;
            }
            if (!controlPause)
            {
                btnPause.Text = "Resume Control";
                controlPause = true;
                return;
            }
        }


        // MENU OPTIONS
        // TODO:  Add more emulator options.
        private void mnuQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuVisualBoyAdvance_Click(object sender, EventArgs e)
        {
            emulatorRunning = "VisualBoyAdvance";
            uncheckAllMenus();
            mnuVisualBoyAdvance.Checked = true;
            getEmulatorHandle();

            rtbOutput.AppendText("VisualBoyAdvance selected as the emulator\r\n");
            rtbOutput.ScrollToCaret();
        }
       
        private void boycottAdvanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            emulatorRunning = "BoycottAdvance";
            uncheckAllMenus();
            boycottAdvanceToolStripMenuItem.Checked = true;
            getEmulatorHandle();

            rtbOutput.AppendText("BoycottAdvance selected as the emulator\r\n");
            rtbOutput.ScrollToCaret();
        }

        private void nesterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            emulatorRunning = "nester";
            uncheckAllMenus();
            nesterToolStripMenuItem.Checked = true;
            getEmulatorHandle();

            rtbOutput.AppendText("nester selected as the emulator\r\n");
            rtbOutput.ScrollToCaret();
        }

        private void zSNESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            emulatorRunning = "ZSNES";
            uncheckAllMenus();
            zSNESToolStripMenuItem.Checked = true;
            getEmulatorHandle();

            rtbOutput.AppendText("ZSNES selected as the emulator\r\n");
            rtbOutput.ScrollToCaret();
        }

        private void fceuxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            emulatorRunning = "FCEUX";
            uncheckAllMenus();
            fceuxToolStripMenuItem.Checked = true;
            getEmulatorHandle();

            rtbOutput.AppendText("fceux selected as the emulator\r\n");
            rtbOutput.ScrollToCaret();
        }

        // Unchecks all the emulator options. 
        private void uncheckAllMenus()
        {
            mnuVisualBoyAdvance.Checked = false;
            boycottAdvanceToolStripMenuItem.Checked = false;
            nesterToolStripMenuItem.Checked = false;
            zSNESToolStripMenuItem.Checked = false;
            fceuxToolStripMenuItem.Checked = false;
        }

        // Creates and shows the About form.
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmAbout frmAbout = new frmAbout())
            {
                frmAbout.ShowDialog();
                Show();
            }
        }

        // Bring up the config form for setting up the key bindings.
#region KeyBindingsMenuOption
        private void keyBindingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Load the config form
         
            DialogResult dialogResult = new DialogResult();
            frmSetKeyBindings keyBindings = new frmSetKeyBindings();

            dialogResult = keyBindings.ShowDialog();

            if (dialogResult == DialogResult.OK)
                loadKeyConfig();

        }
#endregion




        // Set the key press delay that the control uses for sending keys to the emulator. 
        // Longer delay means the button is held down longer. 100 ms is default.
#region KeyPressDelaySetting
        private void keyPressDelayToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            String timeDelay = Microsoft.VisualBasic.Interaction.InputBox("Insert the key press delay between controller button presses sent to the emulator. The time is in ms. Longer times may make the button repeat on certain games. Lower times may not make anything happen. 100 is default.",
                "Key Press Delay", sleepDelay.ToString());


            if (timeDelay == "")
            {
                MessageBox.Show("Error! The time delay cannot be empty!", "Error!");
                return;
            }
            if ((timeDelay == "0") || (timeDelay.Contains("-")))
            {
                MessageBox.Show("Error! The time delay cannot be 0 or negative.", "Error!");
                return;
            }

            try
            {
                sleepDelay = Convert.ToInt32(timeDelay);
                rtbOutput.AppendText("The key press delay has been set to: " + sleepDelay + "ms.  This setting will be saved when you connect.\r\n");
                return;
            }
            catch (Exception pressException)
            {
                MessageBox.Show("There was an error with this time set. Make sure it's not negative, 0, and you don't include any text other than the number.");
                return;
            }
        }
#endregion
        
#region keyboardhooks
        void KeyboardHook_KeyUp(int vkCode)
        {
            //Everytime the users releases a certain key up,
            //your application will go to this line
            //Use the vKCode argument to determine which key has been released
        }

        void KeyboardHook_KeyDown(int vkCode)
        {
            //Everytime the users holds a certain key down,
            //your application will go to this line
            //Use the vKCode argument to determine which key is held down
        }
#endregion



 







    }
}