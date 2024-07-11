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
            originalSize = drawingPanel.Size;
            drawingPanel.AutoScroll = true;

            drawingBitmap = new Bitmap(drawingPanel.Width, drawingPanel.Height);
            drawingGraphics = Graphics.FromImage(drawingBitmap);
            drawingGraphics.Clear(Color.White);
            drawingPanel.AutoScroll = true;
        }

        private void PencilButton_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Pencil;
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
                startPoint = ScalePoint(e.Location);
                lastPoint = startPoint;
                undoStack.Push(new Bitmap(drawingBitmap));
                redoStack.Clear();
            }
        }

        private void DrawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                Point currentPoint = ScalePoint(e.Location);
                if (currentTool == Tool.Pencil)
                {
                    using (Graphics g = Graphics.FromImage(drawingBitmap))
                    using (Pen pen = new Pen(currentColor, currentBrushSize))
                    {
                        g.DrawLine(pen, lastPoint, currentPoint);
                    }
                }
                else if (currentTool == Tool.Eraser)
                {
                    using (Graphics g = Graphics.FromImage(drawingBitmap))
                    using (Pen pen = new Pen(Color.White, currentBrushSize * 5))
                    {
                        g.DrawLine(pen, lastPoint, currentPoint);
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

        private float zoomFactor = 1.0f;
        private Size originalSize;

        private void ZoomComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedZoom = zoomComboBox.SelectedItem.ToString();
            zoomFactor = float.Parse(selectedZoom.TrimEnd('%')) / 100f;
            UpdateDrawingPanelSize();
            drawingPanel.Invalidate();
        }

        private Point ScalePoint(Point p)
        {
            return new Point(
                (int)((p.X - drawingPanel.AutoScrollPosition.X) / zoomFactor),
                (int)((p.Y - drawingPanel.AutoScrollPosition.Y) / zoomFactor)
            );
        }


        private void UpdateDrawingPanelSize()
        {
            drawingPanel.AutoScrollMinSize = new Size(
                (int)(drawingBitmap.Width * zoomFactor),
                (int)(drawingBitmap.Height * zoomFactor)
            );
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