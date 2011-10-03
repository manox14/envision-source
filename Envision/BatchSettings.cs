using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Threading;
using Kaliko.ImageLibrary;
using System.IO;

namespace Envision
{
    public partial class BatchSettings : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private long avgFileSize;
        private ListBox.ObjectCollection imageList;
        private ProgressBar progBar;
        private string outFolder;
        private FileInfo testImg;

        public BatchSettings(long avgFileSize, ListBox.ObjectCollection imageList, string outFolder)
        {
            InitializeComponent();
            this.imageList = imageList;
            this.unitDimension.SelectedIndex = 0;
            this.avgFileSize = avgFileSize;
            this.testImg = imageClosestInSize(avgFileSize);
            this.approxSize.Text = calcApproxFilesize();
            this.outFolder = outFolder;
        }

        /// <summary>
        /// Calculates the approximate filesize of each image according to the quality setting, based on the image closest to the average filesize
        /// </summary>
        /// <returns>String representing the approximate filesize</returns>
        private string calcApproxFilesize()
        {
            string type = testImg.Extension;
            KalikoImage testResize = new KalikoImage(testImg.FullName);
            MemoryStream outStream = new MemoryStream();

            // Determine filetype
            if (type.Equals(".jpg", StringComparison.OrdinalIgnoreCase) || type.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) || type.Equals(".jfif", StringComparison.OrdinalIgnoreCase))
                testResize.SaveJpg(outStream, this.imgQuality.Value);
            else if (type.Equals(".png", StringComparison.OrdinalIgnoreCase))
                testResize.SavePng(outStream, this.imgQuality.Value);
            else
                throw new NotSupportedException("Unsupported image type");

            testResize.Dispose();
            testResize = null;
            long finalSize = outStream.Length;

            // Display size in bytes
            if (finalSize < 1024)
                return finalSize.ToString() + " bytes";

            // Display size in kilobytes
            else if (finalSize < 1048576)
                return (finalSize / 1024).ToString() + " KB";

            // Display size in megabytes
            else
                return String.Format("{0:0.00}", ((double)finalSize / (double)1048576)) + " MB";
        }

        /// <summary>
        /// Finds the image file closest in filesize to the given size
        /// </summary>
        /// <param name="sizeBytes">The size (in bytes) to look for</param>
        /// <returns>The FileInfo object for the image file closest in filesize to the given size</returns>
        private FileInfo imageClosestInSize(long sizeBytes)
        {
            FileInfo closest = null;
            long closestDiff = -1;

            // Algorithm for finding the closest filesize
            for (int i = 0; i < imageList.Count; i++)
            {
                FileInfo thisFile = new FileInfo(((ImageItem)imageList[i]).filepath);
                long thisDiff = CalcDifference(sizeBytes, thisFile.Length);

                // If we've found a perfect match, return right now
                if (thisDiff == 0)
                    return closest;

                // If we don't have a closest difference yet, this is the closest
                else if (closest == null)
                {
                    closest = thisFile;
                    closestDiff = thisDiff;
                }

                // If this one is closer, make it the new hotness
                else if (thisDiff < closestDiff)
                {
                    closest = thisFile;
                    closestDiff = thisDiff;
                }

                // Not any closer, just continue
                else
                {
                    continue;
                }
            }

            return closest;
        }

        /// <summary>
        /// Calculates the difference between two numbers, regardless of pos/neg
        /// </summary>
        /// <returns>The difference between the two provided numbers as a positive 64-bit integer, or 0 if the two numbers are equal.</returns>
        private long CalcDifference(long num1, long num2)
        {
            if (num1 > num2)
                return num1 - num2;
            else if (num2 > num1)
                return num2 - num1;
            else
                return 0;
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

        // Only allow numbers to be entered into the size textbox
        private void imageSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (imageSize.Text.Length < 1 && e.KeyChar == '0')
            {
                e.Handled = true;
                return;
            }
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
            validateImgSize();
        }

        private void validateImgSize()
        {
            int intParsed;
            if (!int.TryParse(imageSize.Text, out intParsed))
                imageSize.Text = "1";
            else if (int.Parse(imageSize.Text) < 1)
                imageSize.Text = "1";
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            this.progBar = new ProgressBar();
            validateImgSize();
            ThreadStart runBatch = new ThreadStart(executeBatch);
            Thread batchThread = new Thread(runBatch);
            batchThread.Start();
            this.ShowProgressThreadSafe(this);
            this.DialogResult = DialogResult.OK;
            this.Close();
            this.Dispose();
        }

        // Thread-safe show progress:
        private delegate void ShowProgressCallback(Form parent);
        public void ShowProgressThreadSafe(Form parent)
        {
            if (this.InvokeRequired)
            {
                ShowProgressCallback d = new ShowProgressCallback(ShowProgressThreadSafe);
                this.Invoke(d, new object[] { parent });
            }
            else
            {
                this.progBar.ShowDialogThreadSafe(parent);
            }
        }

        /// <summary>
        /// Executes the batch operation - should be called from own thread
        /// </summary>
        /// <param name="progBar">The progress bar form instance which has been shown</param>
        private void executeBatch()
        {
            int i = 0;
            foreach (ImageItem img in imageList)
            {
                i++;
                processImage(img);
                double percent = (double)i / (double)imageList.Count * 100;
                progBar.SetProgress((int)percent);
            }
            progBar.allDone();
        }

        /// <summary>
        /// Processes a given image according to the settings provided
        /// </summary>
        /// <param name="filepath">Filepath of the image to be processed</param>
        private void processImage(ImageItem img)
        {
            string type = new FileInfo(img.filepath).Extension;
            string newPath = outFolder + "\\" + img.filename;

            KalikoImage image = new KalikoImage(img.filepath);
            ImageSize newSize = getNewImageSize(image);
            KalikoImage workingImg = image.GetThumbnailImage(newSize.Width, newSize.Height, ThumbnailMethod.Fit);
            
            image.Dispose();
            image = null;

            // Determine image type and save
            if (type.Equals(".jpg", StringComparison.OrdinalIgnoreCase) || type.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) || type.Equals(".jfif", StringComparison.OrdinalIgnoreCase))
                workingImg.SaveJpg(newPath, this.imgQuality.Value);
            else if (type.Equals(".png", StringComparison.OrdinalIgnoreCase))
                workingImg.SavePng(newPath, this.imgQuality.Value);
            else
                throw new NotSupportedException("Unsupported image type");
        }

        /// <summary>
        /// Calculates the new size for an image, keeping the width-height ratio the same
        /// </summary>
        /// <param name="image">The image to be resized</param>
        /// <returns>An ImageSize object containing the new height and width for the image</returns>
        private ImageSize getNewImageSize(KalikoImage image)
        {
            if (this.retainSize.Checked)
                return new ImageSize(image.Width, image.Height);
            else
            {
                // TODO: Implement resizing & scaling
                throw new NotImplementedException("Resizing and scaling not yet implemented");
            }
        }

        // A hack to enable the approx size to be calculated when bar is dropped
        private void imgQuality_MouseUp(object sender, MouseEventArgs e)
        {
            approxSize.Text = calcApproxFilesize();
        }

        // This is to help in case people decide to scroll using the mouse wheel
        private void imgQuality_Leave(object sender, EventArgs e)
        {
            approxSize.Text = calcApproxFilesize();
        }
    }
}