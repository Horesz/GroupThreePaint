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
            openExistImageBTN = new Button();
            welcomeLabel = new Label();
            pictureBox2 = new PictureBox();
            ExitBTN = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // newBlankPageBTN
            // 
            newBlankPageBTN.BackColor = Color.Transparent;
            newBlankPageBTN.Location = new Point(12, 302);
            newBlankPageBTN.Name = "newBlankPageBTN";
            newBlankPageBTN.Size = new Size(129, 33);
            newBlankPageBTN.TabIndex = 0;
            newBlankPageBTN.Text = "Új rajzfelület nyitása";
            newBlankPageBTN.UseVisualStyleBackColor = false;
            newBlankPageBTN.Click += button1_Click;
            // 
            // openExistImageBTN
            // 
            openExistImageBTN.BackColor = Color.Transparent;
            openExistImageBTN.ForeColor = Color.Black;
            openExistImageBTN.Location = new Point(186, 302);
            openExistImageBTN.Name = "openExistImageBTN";
            openExistImageBTN.Size = new Size(186, 33);
            openExistImageBTN.TabIndex = 1;
            openExistImageBTN.Text = "Meglévő kép megnyitása";
            openExistImageBTN.UseVisualStyleBackColor = false;
            openExistImageBTN.Click += button2_Click;
            // 
            // welcomeLabel
            // 
            welcomeLabel.AutoSize = true;
            welcomeLabel.BackColor = Color.Transparent;
            welcomeLabel.Location = new Point(29, 91);
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
            pictureBox2.Size = new Size(435, 480);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // ExitBTN
            // 
            ExitBTN.BackColor = Color.Transparent;
            ExitBTN.Location = new Point(228, 421);
            ExitBTN.Name = "ExitBTN";
            ExitBTN.Size = new Size(65, 44);
            ExitBTN.TabIndex = 6;
            ExitBTN.Text = "Kilépés";
            ExitBTN.UseVisualStyleBackColor = false;
            ExitBTN.Click += ExitBTN_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(433, 477);
            Controls.Add(ExitBTN);
            Controls.Add(welcomeLabel);
            Controls.Add(openExistImageBTN);
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
        private Button openExistImageBTN;
        private Label welcomeLabel;
        private PictureBox pictureBox2;
        private Button ExitBTN;
    }
}