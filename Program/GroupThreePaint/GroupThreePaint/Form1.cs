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
        private void Form1_Resize(object sender, EventArgs e)
        {
            // Create a new bitmap with the new size
            Bitmap newBitmap = new Bitmap(drawingPanel.Width, drawingPanel.Height);
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                g.Clear(Color.White);
                // Draw the old bitmap onto the new one, preserving the content
                g.DrawImage(drawingBitmap, 0, 0);
            }

            // Replace the old bitmap and graphics
            drawingBitmap.Dispose();
            drawingGraphics.Dispose();
            drawingBitmap = newBitmap;
            drawingGraphics = Graphics.FromImage(drawingBitmap);

            // Redraw the panel
            drawingPanel.Invalidate();
        }
        public Form1(Size? customSize = null)
        {
            InitializeComponent();

            if (customSize.HasValue)
            {
                this.Size = customSize.Value;
            }

            // Set the drawing panel to fill the entire form
            drawingPanel.Dock = DockStyle.Fill;

            drawingPanel.MouseDown += new MouseEventHandler(DrawingPanel_MouseDown);
            drawingPanel.MouseMove += new MouseEventHandler(DrawingPanel_MouseMove);
            drawingPanel.MouseUp += new MouseEventHandler(DrawingPanel_MouseUp);
            drawingPanel.Paint += new PaintEventHandler(DrawingPanel_Paint);

            // Create the initial bitmap
            CreateNewBitmap();

            // Add resize event handler
            this.Resize += new EventHandler(Form1_Resize);
        }

        private void CreateNewBitmap()
        {
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
                // Create a new bitmap with the panel's size
                using (Bitmap saveBitmap = new Bitmap(drawingPanel.Width, drawingPanel.Height))
                {
                    // Draw the current bitmap onto the new one, stretching it to fit
                    using (Graphics g = Graphics.FromImage(saveBitmap))
                    {
                        g.DrawImage(drawingBitmap, 0, 0, drawingPanel.Width, drawingPanel.Height);
                    }
                    saveBitmap.Save(saveFileDialog.FileName);
                }
            }
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "PNG Files|*.png|JPEG Files|*.jpg|BMP Files|*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (Bitmap openedBitmap = new Bitmap(openFileDialog.FileName))
                {
                    drawingBitmap = new Bitmap(drawingPanel.Width, drawingPanel.Height);
                    drawingGraphics = Graphics.FromImage(drawingBitmap);
                    drawingGraphics.DrawImage(openedBitmap, 0, 0, drawingPanel.Width, drawingPanel.Height);
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