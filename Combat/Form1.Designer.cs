namespace Combat
{
    partial class Form_CombatScreen
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.combatImage = new System.Windows.Forms.PictureBox();
            this.cancelSelect = new System.Windows.Forms.Button();
            this.labelDamage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.combatImage)).BeginInit();
            this.SuspendLayout();
            // 
            // combatImage
            // 
            this.combatImage.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.combatImage.Location = new System.Drawing.Point(93, 12);
            this.combatImage.Name = "combatImage";
            this.combatImage.Size = new System.Drawing.Size(1366, 768);
            this.combatImage.TabIndex = 0;
            this.combatImage.TabStop = false;
            this.combatImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.combatImage_MouseClick);
            // 
            // cancelSelect
            // 
            this.cancelSelect.Location = new System.Drawing.Point(12, 12);
            this.cancelSelect.Name = "cancelSelect";
            this.cancelSelect.Size = new System.Drawing.Size(75, 23);
            this.cancelSelect.TabIndex = 1;
            this.cancelSelect.Text = "Cancel Select";
            this.cancelSelect.UseVisualStyleBackColor = true;
            this.cancelSelect.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cancelSelect_MouseClick);
            // 
            // labelDamage
            // 
            this.labelDamage.AutoSize = true;
            this.labelDamage.Location = new System.Drawing.Point(12, 38);
            this.labelDamage.Name = "labelDamage";
            this.labelDamage.Size = new System.Drawing.Size(0, 13);
            this.labelDamage.TabIndex = 2;
            // 
            // Form_CombatScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(12, 12);
            this.ClientSize = new System.Drawing.Size(664, 485);
            this.Controls.Add(this.labelDamage);
            this.Controls.Add(this.cancelSelect);
            this.Controls.Add(this.combatImage);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "Form_CombatScreen";
            this.Text = "CombatScreen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.combatImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox combatImage;
        private System.Windows.Forms.Button cancelSelect;
        private System.Windows.Forms.Label labelDamage;
    }
}

