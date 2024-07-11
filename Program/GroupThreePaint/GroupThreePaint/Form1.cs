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

            originalSize = drawingPanel.Size;
            drawingPanel.AutoScroll = true;
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

        private void FillButton_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Fill;
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
                startPoint = ScalePoint(e.Location);
                lastPoint = startPoint;
                undoStack.Push(new Bitmap(drawingBitmap));
                redoStack.Clear();

                if (currentTool == Tool.Fill)
                {
                    Color targetColor = drawingBitmap.GetPixel(e.Location.X, e.Location.Y);
                    FloodFill(e.Location, targetColor);
                    isDrawing = false;
                    drawingPanel.Invalidate();
                }
            }
        }

        private Random random = new Random();
        private void DrawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                Point currentPoint = ScalePoint(e.Location);
                using (Graphics g = Graphics.FromImage(drawingBitmap))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.Clip = new Region(new Rectangle(0, 0, drawingBitmap.Width, drawingBitmap.Height));

                    if (currentTool == Tool.Pencil)
                    {
                        using (Pen pen = new Pen(currentColor, currentBrushSize))
                        {
                            g.DrawLine(pen, lastPoint, currentPoint);
                        }
                    }
                    else if (currentTool == Tool.Pen)
                    {
                        using (SolidBrush brush = new SolidBrush(currentColor))
                        {
                            float distance = (float)Math.Sqrt(Math.Pow(currentPoint.X - lastPoint.X, 2) + Math.Pow(currentPoint.Y - lastPoint.Y, 2));
                            for (float i = 0; i <= distance; i++)
                            {
                                float t = i / distance;
                                int x = (int)Math.Round(lastPoint.X + t * (currentPoint.X - lastPoint.X));
                                int y = (int)Math.Round(lastPoint.Y + t * (currentPoint.Y - lastPoint.Y));
                                g.FillRectangle(brush, x, y, currentBrushSize, currentBrushSize);
                            }
                        }
                    }
                    else if (currentTool == Tool.Spray)
                    {
                        using (SolidBrush brush = new SolidBrush(currentColor))
                        {
                            int sprayRadius = currentBrushSize * 2;
                            int sprayDensity = 50;

                            for (int i = 0; i < sprayDensity; i++)
                            {
                                double angle = random.NextDouble() * 2 * Math.PI;
                                double radius = random.NextDouble() * sprayRadius;
                                int x = (int)Math.Round(currentPoint.X + radius * Math.Cos(angle));
                                int y = (int)Math.Round(currentPoint.Y + radius * Math.Sin(angle));
                                g.FillRectangle(brush, x, y, 1, 1);
                            }
                        }
                    }
                    else if (currentTool == Tool.Watercolor)
                    {
                        int brushRadius = currentBrushSize * 2;
                        int density = 30;
                        int layers = 5;

                        float distance = (float)Math.Sqrt(Math.Pow(currentPoint.X - lastPoint.X, 2) + Math.Pow(currentPoint.Y - lastPoint.Y, 2));
                        for (float i = 0; i <= distance; i += 0.5f)
                        {
                            float t = i / distance;
                            int interpolatedX = (int)Math.Round(lastPoint.X + t * (currentPoint.X - lastPoint.X));
                            int interpolatedY = (int)Math.Round(lastPoint.Y + t * (currentPoint.Y - lastPoint.Y));

                            for (int layer = 0; layer < layers; layer++)
                            {
                                using (SolidBrush brush = new SolidBrush(Color.FromArgb(50 / (layer + 1), currentColor)))
                                {
                                    for (int j = 0; j < density; j++)
                                    {
                                        double angle = random.NextDouble() * 2 * Math.PI;
                                        double radius = random.NextDouble() * brushRadius;
                                        int x = (int)Math.Round(interpolatedX + radius * Math.Cos(angle));
                                        int y = (int)Math.Round(interpolatedY + radius * Math.Sin(angle));

                                        // Ensure x and y are within the bitmap's boundaries
                                        x = Math.Max(0, Math.Min(x, drawingBitmap.Width - 1));
                                        y = Math.Max(0, Math.Min(y, drawingBitmap.Height - 1));

                                        // Ensure the ellipse doesn't exceed the bitmap's boundaries
                                        int width = Math.Min(4, drawingBitmap.Width - x);
                                        int height = Math.Min(3, drawingBitmap.Height - y);

                                        if (width > 0 && height > 0)
                                        {
                                            g.FillEllipse(brush, x, y, width, height);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (currentTool == Tool.Eraser)
                    {
                        using (Pen pen = new Pen(Color.White, currentBrushSize * 5))
                        {
                            g.DrawLine(pen, lastPoint, currentPoint);
                        }
                    }
                }
                lastPoint = currentPoint;
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
                    Point endPoint = ScalePoint(e.Location);
                    var rect = GetRectangle(startPoint, endPoint);

                    using (Graphics g = Graphics.FromImage(drawingBitmap))
                    using (Pen pen = new Pen(currentColor, currentBrushSize))
                    {
                        if (currentTool == Tool.Rectangle)
                        {
                            g.DrawRectangle(pen, rect);
                        }
                        else if (currentTool == Tool.Ellipse)
                        {
                            g.DrawEllipse(pen, rect);
                        }
                    }

                    drawingPanel.Invalidate();
                }
            }
        }

        private Point ScalePoint(Point p)
        {
            return new Point(
                (int)((p.X - drawingPanel.AutoScrollPosition.X) / zoomFactor),
                (int)((p.Y - drawingPanel.AutoScrollPosition.Y) / zoomFactor)
            );
        }

        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(drawingPanel.AutoScrollPosition.X, drawingPanel.AutoScrollPosition.Y);
            e.Graphics.ScaleTransform(zoomFactor, zoomFactor);
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
                drawingPanel.BackColor = Color.Black;
            }
            else
            {
                this.BackColor = Color.White;
                this.ForeColor = Color.Black;
                toolStrip1.BackColor = Color.White;
                toolStrip1.ForeColor = Color.Black;
                drawingPanel.BackColor = Color.White;
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

        private float zoomFactor = 1.0f;
        private Size originalSize;

        private void ZoomComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedZoom = zoomComboBox.SelectedItem.ToString();
            zoomFactor = float.Parse(selectedZoom.TrimEnd('%')) / 100f;
            UpdateDrawingPanelSize();
            drawingPanel.Invalidate();
        }

        private void UpdateDrawingPanelSize()
        {
            drawingPanel.Size = new Size(
                (int)(originalSize.Width * zoomFactor),
                (int)(originalSize.Height * zoomFactor)
            );
        }

        private void FloodFill(Point pt, Color targetColor)
        {
            Color replacementColor = currentColor;
            if (targetColor == replacementColor)
                return;

            Queue<Point> pixels = new Queue<Point>();
            pixels.Enqueue(pt);

            while (pixels.Count > 0)
            {
                Point temp = pixels.Dequeue();
                int y1 = temp.Y;

                while (y1 >= 0 && drawingBitmap.GetPixel(temp.X, y1) == targetColor)
                {
                    y1--;
                }

                y1++;
                bool spanLeft = false;
                bool spanRight = false;

                while (y1 < drawingBitmap.Height && drawingBitmap.GetPixel(temp.X, y1) == targetColor)
                {
                    drawingBitmap.SetPixel(temp.X, y1, replacementColor);

                    if (!spanLeft && temp.X > 0 && drawingBitmap.GetPixel(temp.X - 1, y1) == targetColor)
                    {
                        pixels.Enqueue(new Point(temp.X - 1, y1));
                        spanLeft = true;
                    }
                    else if (spanLeft && temp.X - 1 >= 0 && drawingBitmap.GetPixel(temp.X - 1, y1) != targetColor)
                    {
                        spanLeft = false;
                    }

                    if (!spanRight && temp.X < drawingBitmap.Width - 1 && drawingBitmap.GetPixel(temp.X + 1, y1) == targetColor)
                    {
                        pixels.Enqueue(new Point(temp.X + 1, y1));
                        spanRight = true;
                    }
                    else if (spanRight && temp.X < drawingBitmap.Width - 1 && drawingBitmap.GetPixel(temp.X + 1, y1) != targetColor)
                    {
                        spanRight = false;
                    }

                    y1++;
                }
            }
        }
    }
}
