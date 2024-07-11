using System;

namespace GroupThreePaint
{
    public partial class Form1 : Form
    {
        private bool isDrawing = false;
        private Point lastPoint;
        private Point startPoint; // For shapes
        private Bitmap drawingBitmap;
        private Graphics drawingGraphics;
        private Tool currentTool = Tool.Pencil;
        private Color currentColor = Color.Black; // Store the current color
        private int currentBrushSize = 2; // Store the current brush size

        private Stack<Bitmap> undoStack = new Stack<Bitmap>(); // Undo stack
        private Stack<Bitmap> redoStack = new Stack<Bitmap>(); // Redo stack

        private bool isDarkMode = false; // Track the current theme

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

        private void PenButton_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Pen;
        }

        private void SprayButton_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Spray;
        }

        private void WatercolorButton_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Watercolor;
        }

        private void EraserButton_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Eraser;
        }

        private void RectangleButton_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Rectangle;
        }

        private void EllipseButton_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Ellipse;
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
            currentBrushSize = int.Parse(brushSizeComboBox.SelectedItem.ToString());
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "PNG Files|*.png|JPEG Files|*.jpg|BMP Files|*.bmp";
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
                using (Bitmap openedBitmap = new Bitmap(openFileDialog.FileName))
                {
                    drawingGraphics.DrawImage(openedBitmap, Point.Empty);
                }
                drawingPanel.Invalidate();
            }
        }

        private void DrawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                startPoint = e.Location;
                lastPoint = e.Location;
                undoStack.Push(new Bitmap(drawingBitmap)); // Save the current state for undo
                redoStack.Clear(); // Clear the redo stack
            }
        }

        private Random random = new Random();
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
                else if (currentTool == Tool.Pen)
                {
                    using (SolidBrush brush = new SolidBrush(currentColor))
                    {
                        // Interpoláció a pontok között
                        float distance = Math.Max(Math.Abs(e.X - lastPoint.X), Math.Abs(e.Y - lastPoint.Y));
                        for (float i = 0; i <= distance; i++)
                        {
                            float t = i / distance;
                            int x = (int)(lastPoint.X + t * (e.X - lastPoint.X));
                            int y = (int)(lastPoint.Y + t * (e.Y - lastPoint.Y));
                            drawingGraphics.FillRectangle(brush, x, y, currentBrushSize, currentBrushSize);
                        }
                    }
                }
                else if (currentTool == Tool.Spray)
                {
                    using (SolidBrush brush = new SolidBrush(currentColor))
                    {
                        int sprayRadius = currentBrushSize * 2; // Állítható sugárméret
                        int sprayDensity = 50; // Pontok száma a spray-ben, állítható érték

                        for (int i = 0; i < sprayDensity; i++)
                        {
                            double angle = random.NextDouble() * 2 * Math.PI;
                            double radius = random.NextDouble() * sprayRadius;
                            int x = (int)(e.X + radius * Math.Cos(angle));
                            int y = (int)(e.Y + radius * Math.Sin(angle));
                            drawingGraphics.FillRectangle(brush, x, y, 1, 1);
                        }
                    }
                }
                else if (currentTool == Tool.Watercolor)
                {
                    int brushRadius = currentBrushSize * 2; // Ecset sugara
                    int density = 30; // Az ecset pontjainak száma, állítható érték
                    int layers = 5; // Rétegek száma a vízfesték hatás eléréséhez

                    float distance = Math.Max(Math.Abs(e.X - lastPoint.X), Math.Abs(e.Y - lastPoint.Y));
                    for (float i = 0; i <= distance; i += 0.5f) // Kis lépésekkel haladunk, hogy folytonos legyen a vonal
                    {
                        float t = i / distance;
                        int interpolatedX = (int)(lastPoint.X + t * (e.X - lastPoint.X));
                        int interpolatedY = (int)(lastPoint.Y + t * (e.Y - lastPoint.Y));

                        for (int layer = 0; layer < layers; layer++)
                        {
                            using (SolidBrush brush = new SolidBrush(Color.FromArgb(50 / (layer + 1), currentColor)))
                            {
                                for (int j = 0; j < density; j++)
                                {
                                    double angle = random.NextDouble() * 2 * Math.PI;
                                    double radius = random.NextDouble() * brushRadius;
                                    int x = (int)(interpolatedX + radius * Math.Cos(angle));
                                    int y = (int)(interpolatedY + radius * Math.Sin(angle));
                                    drawingGraphics.FillEllipse(brush, x, y, 4, 3);
                                }
                            }
                        }
                    }
                }
                else if (currentTool == Tool.Eraser)
                {
                    using (Pen pen = new Pen(Color.White, currentBrushSize * 5)) // Adjust the eraser size
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

                if (currentTool == Tool.Rectangle || currentTool == Tool.Ellipse)
                {
                    var endPoint = e.Location;
                    var rect = GetRectangle(startPoint, endPoint);

                    using (Pen pen = new Pen(currentColor, currentBrushSize))
                    {
                        if (currentTool == Tool.Rectangle)
                        {
                            drawingGraphics.DrawRectangle(pen, rect);
                        }
                        else if (currentTool == Tool.Ellipse)
                        {
                            drawingGraphics.DrawEllipse(pen, rect);
                        }
                    }

                    drawingPanel.Invalidate();
                }
            }
        }

        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(drawingBitmap, Point.Empty);
        }

        private Rectangle GetRectangle(Point p1, Point p2)
        {
            int x = Math.Min(p1.X, p2.X);
            int y = Math.Min(p1.Y, p2.Y);
            int width = Math.Abs(p1.X - p2.X);
            int height = Math.Abs(p1.Y - p2.Y);
            return new Rectangle(x, y, width, height);
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            if (undoStack.Count > 0)
            {
                redoStack.Push(new Bitmap(drawingBitmap)); // Save the current state for redo
                drawingBitmap = undoStack.Pop(); // Restore the previous state
                drawingGraphics = Graphics.FromImage(drawingBitmap);
                drawingPanel.Invalidate();
            }
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            if (redoStack.Count > 0)
            {
                undoStack.Push(new Bitmap(drawingBitmap)); // Save the current state for undo
                drawingBitmap = redoStack.Pop(); // Restore the redo state
                drawingGraphics = Graphics.FromImage(drawingBitmap);
                drawingPanel.Invalidate();
            }
        }

        private void ThemeToggleButton_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            if (isDarkMode)
            {
                this.BackColor = Color.Black;
                this.ForeColor = Color.White;
                toolStrip1.BackColor = Color.Black;
                toolStrip1.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = Color.White;
                this.ForeColor = Color.Black;
                toolStrip1.ForeColor = Color.Black;
                isDarkMode = !isDarkMode;
            }

            drawingPanel.Invalidate();
        }

        private void ClearButton_Click(object sender, EventArgs e) // Add this method
        {
            undoStack.Push(new Bitmap(drawingBitmap)); // Save the current state for undo
            redoStack.Clear(); // Clear the redo stack
            drawingGraphics.Clear(Color.White); // Clear the drawing area
            drawingPanel.Invalidate();
        }
    }
}