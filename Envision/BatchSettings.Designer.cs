namespace Envision
{
    partial class BatchSettings
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
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.kryptonPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.qualitypercent = new System.Windows.Forms.Label();
            this.imgQuality = new ComponentFactory.Krypton.Toolkit.KryptonTrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.retainSize = new System.Windows.Forms.CheckBox();
            this.executeButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cancelButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.unitDimension = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.imageSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.approxSize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.kryptonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unitDimension)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonManager
            // 
            this.kryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.SparkleOrange;
            // 
            // kryptonPanel
            // 
            this.kryptonPanel.Controls.Add(this.executeButton);
            this.kryptonPanel.Controls.Add(this.cancelButton);
            this.kryptonPanel.Controls.Add(this.unitDimension);
            this.kryptonPanel.Controls.Add(this.imageSize);
            this.kryptonPanel.Controls.Add(this.kryptonPanel1);
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.Size = new System.Drawing.Size(531, 262);
            this.kryptonPanel.TabIndex = 0;
            // 
            // qualitypercent
            // 
            this.qualitypercent.BackColor = System.Drawing.Color.Transparent;
            this.qualitypercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qualitypercent.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.qualitypercent.Location = new System.Drawing.Point(20, 148);
            this.qualitypercent.Name = "qualitypercent";
            this.qualitypercent.Size = new System.Drawing.Size(484, 18);
            this.qualitypercent.TabIndex = 8;
            this.qualitypercent.Text = "100%";
            this.qualitypercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imgQuality
            // 
            this.imgQuality.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.HeaderCalendar;
            this.imgQuality.DrawBackground = true;
            this.imgQuality.LargeChange = 10;
            this.imgQuality.Location = new System.Drawing.Point(23, 118);
            this.imgQuality.Maximum = 100;
            this.imgQuality.Minimum = 1;
            this.imgQuality.Name = "imgQuality";
            this.imgQuality.Size = new System.Drawing.Size(481, 27);
            this.imgQuality.SmallChange = 10;
            this.imgQuality.TabIndex = 7;
            this.imgQuality.TickFrequency = 10;
            this.imgQuality.TickStyle = System.Windows.Forms.TickStyle.None;
            this.imgQuality.TrackBarSize = ComponentFactory.Krypton.Toolkit.PaletteTrackBarSize.Large;
            this.imgQuality.Value = 100;
            this.imgQuality.VolumeControl = true;
            this.imgQuality.ValueChanged += new System.EventHandler(this.imgQuality_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Image Quality";
            // 
            // retainSize
            // 
            this.retainSize.AutoSize = true;
            this.retainSize.BackColor = System.Drawing.Color.Transparent;
            this.retainSize.Checked = true;
            this.retainSize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.retainSize.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.retainSize.Location = new System.Drawing.Point(23, 33);
            this.retainSize.Name = "retainSize";
            this.retainSize.Size = new System.Drawing.Size(123, 17);
            this.retainSize.TabIndex = 5;
            this.retainSize.Text = "Retain Original Sizes";
            this.retainSize.UseVisualStyleBackColor = false;
            this.retainSize.CheckedChanged += new System.EventHandler(this.retainSize_CheckedChanged);
            // 
            // executeButton
            // 
            this.executeButton.Location = new System.Drawing.Point(430, 222);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(98, 36);
            this.executeButton.TabIndex = 4;
            this.executeButton.Values.Text = "Execute";
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(326, 222);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(98, 36);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Values.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // unitDimension
            // 
            this.unitDimension.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unitDimension.DropDownWidth = 121;
            this.unitDimension.Enabled = false;
            this.unitDimension.Items.AddRange(new object[] {
            "px (height)",
            "px (width)",
            "% (height)",
            "% (width)"});
            this.unitDimension.Location = new System.Drawing.Point(92, 58);
            this.unitDimension.Name = "unitDimension";
            this.unitDimension.Size = new System.Drawing.Size(121, 21);
            this.unitDimension.TabIndex = 2;
            // 
            // imageSize
            // 
            this.imageSize.Enabled = false;
            this.imageSize.Location = new System.Drawing.Point(26, 58);
            this.imageSize.Name = "imageSize";
            this.imageSize.Size = new System.Drawing.Size(60, 20);
            this.imageSize.TabIndex = 1;
            this.imageSize.Text = "100";
            this.imageSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.imageSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.imageSize_KeyPress);
            this.imageSize.Leave += new System.EventHandler(this.imageSize_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Image Size";
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.approxSize);
            this.kryptonPanel1.Controls.Add(this.label3);
            this.kryptonPanel1.Controls.Add(this.retainSize);
            this.kryptonPanel1.Controls.Add(this.qualitypercent);
            this.kryptonPanel1.Controls.Add(this.label2);
            this.kryptonPanel1.Controls.Add(this.imgQuality);
            this.kryptonPanel1.Controls.Add(this.label1);
            this.kryptonPanel1.Location = new System.Drawing.Point(3, 2);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.HeaderCalendar;
            this.kryptonPanel1.Size = new System.Drawing.Size(525, 214);
            this.kryptonPanel1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(20, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 39);
            this.label3.TabIndex = 9;
            this.label3.Text = "Approx Filesize:\r\n(based on quality)";
            // 
            // approxSize
            // 
            this.approxSize.BackColor = System.Drawing.Color.Transparent;
            this.approxSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.approxSize.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.approxSize.Location = new System.Drawing.Point(126, 166);
            this.approxSize.Name = "approxSize";
            this.approxSize.Size = new System.Drawing.Size(378, 39);
            this.approxSize.TabIndex = 10;
            this.approxSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BatchSettings
            // 
            this.AcceptButton = this.executeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(531, 262);
            this.ControlBox = false;
            this.Controls.Add(this.kryptonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "BatchSettings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Batch Image Settings";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.kryptonPanel.ResumeLayout(false);
            this.kryptonPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unitDimension)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox unitDimension;
        private System.Windows.Forms.TextBox imageSize;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton executeButton;
        private ComponentFactory.Krypton.Toolkit.KryptonButton cancelButton;
        private System.Windows.Forms.CheckBox retainSize;
        private System.Windows.Forms.Label qualitypercent;
        private ComponentFactory.Krypton.Toolkit.KryptonTrackBar imgQuality;
        private System.Windows.Forms.Label label2;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.Label approxSize;
        private System.Windows.Forms.Label label3;
    }
}

