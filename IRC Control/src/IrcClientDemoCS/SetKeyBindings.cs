using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace IrcClientDemoCS
{
    public partial class frmSetKeyBindings : Form
    {
        public frmSetKeyBindings()
        {
            InitializeComponent();
            getCurrentKeyBindings();
        }


        void getCurrentKeyBindings()
        {
            // Load the settings.
            if (File.Exists("keys.cfg"))
            {
                StreamReader sr = new StreamReader("keys.cfg");
                string keystring = sr.ReadToEnd();
                sr.Close();

                string[] keySettings = keystring.Substring(0, keystring.LastIndexOf(',')).Split(',');
                int keyCount = keySettings.Count();
                
                if (keyCount == 20)
                {
                    txtAButton.Text = keySettings[0].ToString().ToUpper();
                    txtBButton.Text = keySettings[1].ToString().ToUpper();
                    txtCButton.Text = keySettings[2].ToString().ToUpper();
                    txtLButton.Text = keySettings[3].ToString().ToUpper();
                    txtRButton.Text = keySettings[4].ToString().ToUpper();
                    txtXButton.Text = keySettings[5].ToString().ToUpper();
                    txtYButton.Text = keySettings[6].ToString().ToUpper();
                    txtL1Button.Text = keySettings[7].ToString().ToUpper();
                    txtL2Button.Text = keySettings[8].ToString().ToUpper();
                    txtR1button.Text = keySettings[9].ToString().ToUpper();
                    txtR2button.Text = keySettings[10].ToString().ToUpper();
                    txtTriangleButton.Text = keySettings[11].ToString().ToUpper();
                    txtSquareButton.Text = keySettings[12].ToString().ToUpper();
                    txtCircleButton.Text = keySettings[13].ToString().ToUpper();
                    txtStartButton.Text = keySettings[14].ToString().ToUpper();
                    txtSelectButton.Text = keySettings[15].ToString().ToUpper();
                    txtDpadUp.Text = keySettings[16].ToString().ToUpper();
                    txtDpadDown.Text = keySettings[17].ToString().ToUpper();
                    txtDpadLeft.Text = keySettings[18].ToString().ToUpper();
                    txtDpadRight.Text = keySettings[19].ToString().ToUpper(); 
                }
            }

        }

        private void saveKeyConfig()
        {

            // Save all settings to a simple text file.
            StringBuilder keySettings = new StringBuilder();

            keySettings.Append(txtAButton.Text + ",");
            keySettings.Append(txtBButton.Text + ",");
            keySettings.Append(txtCButton.Text + ",");
            keySettings.Append(txtLButton.Text + ",");
            keySettings.Append(txtRButton.Text + ",");
            keySettings.Append(txtXButton.Text + ",");
            keySettings.Append(txtYButton.Text + ",");
            keySettings.Append(txtL1Button.Text + ",");
            keySettings.Append(txtL2Button.Text + ",");
            keySettings.Append(txtR1button.Text + ",");
            keySettings.Append(txtR2button.Text + ",");
            keySettings.Append(txtTriangleButton.Text + ",");
            keySettings.Append(txtSquareButton.Text + ",");
            keySettings.Append(txtCircleButton.Text + ",");
            keySettings.Append(txtStartButton.Text + ",");
            keySettings.Append(txtSelectButton.Text + ",");
            keySettings.Append(txtDpadUp.Text + ",");
            keySettings.Append(txtDpadDown.Text + ",");
            keySettings.Append(txtDpadLeft.Text + ",");
            keySettings.Append(txtDpadRight.Text + ",");

            StreamWriter sw = new StreamWriter("keys.cfg");
            sw.Write(keySettings.ToString());
            sw.Flush();
            sw.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            saveKeyConfig();
        }

    }
}
