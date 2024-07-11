namespace GroupThreePaint
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            newBlankPageBTN = new Button();
            welcomeLabel = new Label();
            pictureBox2 = new PictureBox();
            ExitBTN = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // newBlankPageBTN
            // 
            newBlankPageBTN.BackColor = Color.Transparent;
            newBlankPageBTN.Location = new Point(194, 310);
            newBlankPageBTN.Name = "newBlankPageBTN";
            newBlankPageBTN.Size = new Size(129, 33);
            newBlankPageBTN.TabIndex = 0;
            newBlankPageBTN.Text = "Új rajzfelület nyitása";
            newBlankPageBTN.UseVisualStyleBackColor = false;
            newBlankPageBTN.Click += button1_Click;
            // 
            // welcomeLabel
            // 
            welcomeLabel.AutoSize = true;
            welcomeLabel.BackColor = Color.Transparent;
            welcomeLabel.Location = new Point(12, 19);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(99, 23);
            welcomeLabel.TabIndex = 2;
            welcomeLabel.Text = "welcomeLabel";
            welcomeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(-1, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(511, 491);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // ExitBTN
            // 
            ExitBTN.BackColor = Color.Transparent;
            ExitBTN.Location = new Point(220, 421);
            ExitBTN.Name = "ExitBTN";
            ExitBTN.Size = new Size(65, 44);
            ExitBTN.TabIndex = 6;
            ExitBTN.Text = "Kilépés";
            ExitBTN.UseVisualStyleBackColor = false;
            ExitBTN.Click += ExitBTN_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(-1, 210);
            label1.Name = "label1";
            label1.Size = new Size(46, 23);
            label1.TabIndex = 7;
            label1.Text = "label1";
            label1.Click += label1_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(489, 477);
            Controls.Add(label1);
            Controls.Add(ExitBTN);
            Controls.Add(welcomeLabel);
            Controls.Add(newBlankPageBTN);
            Controls.Add(pictureBox2);
            Font = new Font("Bahnschrift SemiBold Condensed", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 5, 3, 5);
            Name = "Form2";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button newBlankPageBTN;
        private Label welcomeLabel;
        private PictureBox pictureBox2;
        private Button ExitBTN;
        private Label label1;
    }
}