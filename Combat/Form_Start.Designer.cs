namespace Combat
{
    partial class Form_Start
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
            this.labelSelectCount = new System.Windows.Forms.Label();
            this.numericSpaceShip = new System.Windows.Forms.NumericUpDown();
            this.buttonOK = new System.Windows.Forms.Button();
            this.radioButton640x480 = new System.Windows.Forms.RadioButton();
            this.radioButton1440x900 = new System.Windows.Forms.RadioButton();
            this.radioButton1900x1080 = new System.Windows.Forms.RadioButton();
            this.labelSelectSize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericSpaceShip)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSelectCount
            // 
            this.labelSelectCount.AutoSize = true;
            this.labelSelectCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.labelSelectCount.Location = new System.Drawing.Point(12, 9);
            this.labelSelectCount.Name = "labelSelectCount";
            this.labelSelectCount.Size = new System.Drawing.Size(270, 22);
            this.labelSelectCount.TabIndex = 0;
            this.labelSelectCount.Text = "Select the number of spaceships";
            // 
            // numericSpaceShip
            // 
            this.numericSpaceShip.Location = new System.Drawing.Point(85, 34);
            this.numericSpaceShip.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numericSpaceShip.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericSpaceShip.Name = "numericSpaceShip";
            this.numericSpaceShip.Size = new System.Drawing.Size(120, 20);
            this.numericSpaceShip.TabIndex = 1;
            this.numericSpaceShip.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(106, 170);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // radioButton640x480
            // 
            this.radioButton640x480.AutoSize = true;
            this.radioButton640x480.Location = new System.Drawing.Point(85, 83);
            this.radioButton640x480.Name = "radioButton640x480";
            this.radioButton640x480.Size = new System.Drawing.Size(60, 17);
            this.radioButton640x480.TabIndex = 3;
            this.radioButton640x480.Text = "640x40";
            this.radioButton640x480.UseVisualStyleBackColor = true;
            // 
            // radioButton1440x900
            // 
            this.radioButton1440x900.AutoSize = true;
            this.radioButton1440x900.Checked = true;
            this.radioButton1440x900.Location = new System.Drawing.Point(85, 107);
            this.radioButton1440x900.Name = "radioButton1440x900";
            this.radioButton1440x900.Size = new System.Drawing.Size(72, 17);
            this.radioButton1440x900.TabIndex = 4;
            this.radioButton1440x900.TabStop = true;
            this.radioButton1440x900.Text = "1440x900";
            this.radioButton1440x900.UseVisualStyleBackColor = true;
            // 
            // radioButton1900x1080
            // 
            this.radioButton1900x1080.AutoSize = true;
            this.radioButton1900x1080.Location = new System.Drawing.Point(85, 131);
            this.radioButton1900x1080.Name = "radioButton1900x1080";
            this.radioButton1900x1080.Size = new System.Drawing.Size(78, 17);
            this.radioButton1900x1080.TabIndex = 5;
            this.radioButton1900x1080.TabStop = true;
            this.radioButton1900x1080.Text = "1900x1080";
            this.radioButton1900x1080.UseVisualStyleBackColor = true;
            // 
            // labelSelectSize
            // 
            this.labelSelectSize.AutoSize = true;
            this.labelSelectSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.labelSelectSize.Location = new System.Drawing.Point(39, 57);
            this.labelSelectSize.Name = "labelSelectSize";
            this.labelSelectSize.Size = new System.Drawing.Size(215, 22);
            this.labelSelectSize.TabIndex = 6;
            this.labelSelectSize.Text = "Select the size of the map";
            // 
            // Form_Start
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 208);
            this.Controls.Add(this.labelSelectSize);
            this.Controls.Add(this.radioButton1900x1080);
            this.Controls.Add(this.radioButton1440x900);
            this.Controls.Add(this.radioButton640x480);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.numericSpaceShip);
            this.Controls.Add(this.labelSelectCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form_Start";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartDialog";
            ((System.ComponentModel.ISupportInitialize)(this.numericSpaceShip)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSelectCount;
        private System.Windows.Forms.Button buttonOK;
        public System.Windows.Forms.NumericUpDown numericSpaceShip;
        public System.Windows.Forms.RadioButton radioButton640x480;
        private System.Windows.Forms.Label labelSelectSize;
        public System.Windows.Forms.RadioButton radioButton1440x900;
        public System.Windows.Forms.RadioButton radioButton1900x1080;
    }
}