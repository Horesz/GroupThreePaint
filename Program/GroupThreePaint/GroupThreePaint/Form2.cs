using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupThreePaint
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            welcomeLabel.Text = "Üdvözöllek a Jólvanazúgy Bt. Rajzolós Software-ében!";
            label1.Text = "Huber Evelin,Sándor Dániel, Márton Gergely, Sinka Barnabás, Huszár Félix";
            this.StartPosition = FormStartPosition.Manual;

            // Center the form on the primary screen
            this.Location = new Point(
                (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2
            );
        }
        private Size GetCustomSize()
        {
            Form sizeForm = new Form();
            sizeForm.Text = "Set Canvas Size";
            sizeForm.Size = new Size(300, 150);
            sizeForm.StartPosition = FormStartPosition.CenterParent;

            Label widthLabel = new Label() { Left = 20, Top = 20, Text = "Width:" };
            TextBox widthBox = new TextBox() { Left = 120, Top = 20, Text = "800" };
            Label heightLabel = new Label() { Left = 20, Top = 50, Text = "Height:" };
            TextBox heightBox = new TextBox() { Left = 120, Top = 50, Text = "600" };
            Button okButton = new Button() { Text = "OK", Left = 100, Top = 80 };

            okButton.Click += (sender, e) => { sizeForm.DialogResult = DialogResult.OK; };

            sizeForm.Controls.AddRange(new Control[] { widthLabel, widthBox, heightLabel, heightBox, okButton });

            if (sizeForm.ShowDialog() == DialogResult.OK)
            {
                int width = int.Parse(widthBox.Text);
                int height = int.Parse(heightBox.Text);
                return new Size(width, height);
            }

            return new Size(800, 600); // Default size if dialog is cancelled
        }


        //new Blank page
        private void button1_Click(object sender, EventArgs e)
        {
            Size canvasSize = GetCustomSize();
            Form1 paintForm = new Form1();
            paintForm.Size = canvasSize;
            paintForm.Show();
            this.Hide(); // Hide Form2
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void ExitBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
