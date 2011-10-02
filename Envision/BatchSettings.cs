using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace Envision
{
    public partial class BatchSettings : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public BatchSettings()
        {
            InitializeComponent();
            this.unitDimension.SelectedIndex = 0;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void imgQuality_ValueChanged(object sender, EventArgs e)
        {
            qualitypercent.Text = imgQuality.Value.ToString() + "%";
        }

        private void retainSize_CheckedChanged(object sender, EventArgs e)
        {
            if (retainSize.Checked)
            {
                imageSize.Enabled = false;
                unitDimension.Enabled = false;
            }
            else if (!retainSize.Checked)
            {
                imageSize.Enabled = true;
                unitDimension.Enabled = true;
            }
        }

        private void imageSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool allowFlag = false;
            char[] allowedChars = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '\b' };
            for (int i = 0; i < allowedChars.Length; i++)
                if (e.KeyChar == allowedChars[i])
                    allowFlag = true;
            if (!allowFlag)
                e.Handled = true;
        }

        private void imageSize_Leave(object sender, EventArgs e)
        {
            int intParsed;
            if (!int.TryParse(imageSize.Text, out intParsed))
                imageSize.Text = "1";
            else if(int.Parse(imageSize.Text) < 1)
                imageSize.Text = "1";

        }
    }
}