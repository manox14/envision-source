using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace Envision
{
    public partial class ProgressBar : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public ProgressBar()
        {
            InitializeComponent();
        }

        // Thread-safe progress bar value-setting:

        private delegate void SetProgressCallback(int percent, string filname);
        public void SetProgress(int percent, string filename)
        {
            if (this.InvokeRequired)
            {
                SetProgressCallback d = new SetProgressCallback(SetProgress);
                this.Invoke(d, new object[] { percent, filename });
            }
            else
            {
                this.progress.Value = percent;
                this.percentLabel.Text = percent.ToString() + "%";
                this.filename.Text = filename;
                if (TaskbarManager.IsPlatformSupported)
                    TaskbarManager.Instance.SetProgressValue(percent, 100);
                
            }
        }

        // Thread-safe show dialog:

        private delegate void ShowDialogCallback(Form parent);
        public void ShowDialogThreadSafe(Form parent)
        {
            if (this.InvokeRequired)
            {
                ShowDialogCallback d = new ShowDialogCallback(ShowDialogThreadSafe);
                this.Invoke(d);
            }
            else
            {
                this.ShowDialog(parent);
            }
        }

        // Thread-safe cleanup:

        private delegate void AllDoneCallback();
        public void allDone()
        {
            if (this.InvokeRequired)
            {
                AllDoneCallback d = new AllDoneCallback(allDone);
                this.Invoke(d);
            }
            else
            {
                this.Close();
                this.Dispose();
            }
        }

        private void ProgressBar_Deactivate(object sender, EventArgs e)
        {
            if (TaskbarManager.IsPlatformSupported)
            {
                TaskbarManager.Instance.SetProgressValue(0, 100);
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
            }
        }
    }
}