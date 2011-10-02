using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.IO;

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
            bool duplicateFlag = false;
            string path = getFolderPath("Please select a folder containing images:");
            if (path != null)
            {
                string[] extenstions = { "*.jpg", "*.jpeg", "*.jfif", "*.png" };
                foreach (string ext in extenstions)
                {
                    string[] filePaths = Directory.GetFiles(path, ext);
                    foreach (string filePath in filePaths)
                    {
                        object[] items = new object[imageList.Items.Count];
                        imageList.Items.CopyTo(items, 0);
                        List<string> alreadyAdded = new List<string>();
                        foreach (ImageItem item in items)
                            alreadyAdded.Add(item.filepath);
                        if (!alreadyAdded.Contains(filePath))
                            imageList.Items.Add(new ImageItem(new FileInfo(filePath).Name, filePath));
                        else duplicateFlag = true;
                    }
                }
                if (duplicateFlag)
                    MessageBox.Show(this, "Some duplicate images were detected and were not added to the queue.", "Duplicate Images");
            }
        }

        private void exportImages()
        {
            string path = getFolderPath("Please select a destination folder for the images:");
            if (path != null)
            {
                MessageBox.Show(path);
                new BatchSettings().Show(this);
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
            {
                removeButton.Enabled = true;
                ImageItem selImg = (ImageItem)imageList.SelectedItem;
                Bitmap selImgBitmap = new Bitmap(selImg.filepath);
                imagePreview.Image = selImgBitmap;
            }
            else
            {
                removeButton.Enabled = false;
                imagePreview.Image = null;
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (imageList.SelectedIndex < imageList.Items.Count && imageList.SelectedIndex >= 0)
            {
                int prevIndex = imageList.SelectedIndex;
                imageList.Items.RemoveAt(prevIndex);
                if (prevIndex > 0)
                    imageList.SelectedIndex = prevIndex - 1;
                else if (imageList.Items.Count > 0)
                    imageList.SelectedIndex = 0;
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

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "This will clear the queue and start fresh. Continue?", "New - Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.imageList.Items.Clear();
                this.imagePreview.Image = null;
                this.folderSelectDialog.Reset();
            }
        }
    }
}