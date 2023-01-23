namespace WindowsFormsApp_Lakopark
{
    partial class Form1
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
            this.panel_Street = new System.Windows.Forms.Panel();
            this.pictureBox_StreetName = new System.Windows.Forms.PictureBox();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Left = new System.Windows.Forms.Button();
            this.button_Right = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_StreetName)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Street
            // 
            this.panel_Street.Location = new System.Drawing.Point(197, 42);
            this.panel_Street.Name = "panel_Street";
            this.panel_Street.Size = new System.Drawing.Size(493, 283);
            this.panel_Street.TabIndex = 0;
            // 
            // pictureBox_StreetName
            // 
            this.pictureBox_StreetName.BackgroundImage = global::WindowsFormsApp_Lakopark.Properties.Resources.Puskás_Ferenc;
            this.pictureBox_StreetName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_StreetName.Location = new System.Drawing.Point(40, 42);
            this.pictureBox_StreetName.Name = "pictureBox_StreetName";
            this.pictureBox_StreetName.Size = new System.Drawing.Size(125, 150);
            this.pictureBox_StreetName.TabIndex = 1;
            this.pictureBox_StreetName.TabStop = false;
            // 
            // button_Save
            // 
            this.button_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Save.Location = new System.Drawing.Point(56, 198);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(96, 30);
            this.button_Save.TabIndex = 4;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Mentes_Click);
            // 
            // button_Left
            // 
            this.button_Left.BackgroundImage = global::WindowsFormsApp_Lakopark.Properties.Resources.balnyil;
            this.button_Left.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_Left.Location = new System.Drawing.Point(307, 331);
            this.button_Left.Name = "button_Left";
            this.button_Left.Size = new System.Drawing.Size(104, 66);
            this.button_Left.TabIndex = 5;
            this.button_Left.UseVisualStyleBackColor = true;
            this.button_Left.Click += new System.EventHandler(this.button_Balra_Click_1);
            // 
            // button_Right
            // 
            this.button_Right.BackgroundImage = global::WindowsFormsApp_Lakopark.Properties.Resources.jobbnyil;
            this.button_Right.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Right.Location = new System.Drawing.Point(455, 331);
            this.button_Right.Name = "button_Right";
            this.button_Right.Size = new System.Drawing.Size(104, 66);
            this.button_Right.TabIndex = 6;
            this.button_Right.UseVisualStyleBackColor = true;
            this.button_Right.Click += new System.EventHandler(this.button_Jobbra_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_Right);
            this.Controls.Add(this.button_Left);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.pictureBox_StreetName);
            this.Controls.Add(this.panel_Street);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_StreetName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Street;
        private System.Windows.Forms.PictureBox pictureBox_StreetName;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Left;
        private System.Windows.Forms.Button button_Right;
    }
}

