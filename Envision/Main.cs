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
    public partial class Main : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public Main()
        {
            InitializeComponent();
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            importImages();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            exportImages();
        }

        private void importImages()
        {
            string path = getFolderPath("Please select a folder containing images:");
            if (path != null)
            {
                MessageBox.Show(path);
            }
        }

        private void exportImages()
        {
            string path = getFolderPath("Please select a destination folder for the images:");
            if (path != null)
            {
                MessageBox.Show(path);
            }
        }

        /// <summary>
        /// Displays a Windows Explorer shell folder select dialog
        /// </summary>
        /// <param name="description">The description text to be displayed in the dialog</param>
        /// <returns>The folder path as a string</returns>
        private string getFolderPath(string description = null)
        {
            if (description != null)
                folderSelectDialog.Description = description;
            else folderSelectDialog.Description = string.Empty;
            DialogResult folder = folderSelectDialog.ShowDialog(this);
            if (folder == DialogResult.OK)
                return folderSelectDialog.SelectedPath;
            else return null;
        }

        private void imageList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (imageList.SelectedIndex < imageList.Items.Count && imageList.SelectedIndex >= 0)
                removeButton.Enabled = true;
            else
                removeButton.Enabled = false;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (imageList.SelectedIndex < imageList.Items.Count && imageList.SelectedIndex >= 0)
            {
                imageList.Items.RemoveAt(imageList.SelectedIndex);
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importImages();
        }

        private void runBatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportImages();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}