namespace GroupThreePaint
{
    public partial class Form1 : Form
    {
        private bool isDrawing = false;
        private Point lastPoint;
        private Bitmap drawingBitmap;
        private Graphics drawingGraphics;
        private Tool currentTool = Tool.Pencil;
        private Color currentColor = Color.Black; // Store the current color
        private int currentBrushSize = 2; // Store the current brush size

        public Form1()
        {
            InitializeComponent();
            drawingPanel.MouseDown += new MouseEventHandler(DrawingPanel_MouseDown);
            drawingPanel.MouseMove += new MouseEventHandler(DrawingPanel_MouseMove);
            drawingPanel.MouseUp += new MouseEventHandler(DrawingPanel_MouseUp);
            drawingPanel.Paint += new PaintEventHandler(DrawingPanel_Paint);

            drawingBitmap = new Bitmap(drawingPanel.Width, drawingPanel.Height);
            drawingGraphics = Graphics.FromImage(drawingBitmap);
            drawingGraphics.Clear(Color.White);
        }

        private void PencilButton_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Pencil;
        }

        private void EraserButton_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Eraser;
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                currentColor = colorDialog.Color; // Set the selected color
            }
        }

        private void BrushSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentBrushSize = int.Parse(brushSizeComboBox.SelectedItem.ToString()); // Update brush size
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "PNG Files|*.png|JPEG Files|*.jpg|BMP Files|*.bmp";
            saveFileDialog.DefaultExt = "png";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                drawingBitmap.Save(saveFileDialog.FileName);
            }
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "PNG Files|*.png|JPEG Files|*.jpg|BMP Files|*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var loadedImage = new Bitmap(openFileDialog.FileName))
                {
                    drawingGraphics.DrawImage(loadedImage, 0, 0, drawingPanel.Width, drawingPanel.Height);
                }
                drawingPanel.Invalidate();
            }
        }

        private void DrawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                lastPoint = e.Location;
            }
        }

        private void DrawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                if (currentTool == Tool.Pencil)
                {
                    using (Pen pen = new Pen(currentColor, currentBrushSize)) // Use the selected color and brush size
                    {
                        drawingGraphics.DrawLine(pen, lastPoint, e.Location);
                    }
                }
                else if (currentTool == Tool.Eraser)
                {
                    using (Pen pen = new Pen(Color.White, currentBrushSize))
                    {
                        drawingGraphics.DrawLine(pen, lastPoint, e.Location);
                    }
                }
                lastPoint = e.Location;
                drawingPanel.Invalidate();
            }
        }

        private void DrawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = false;
            }
        }

        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(drawingBitmap, Point.Empty);
        }
    }
}