using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GroupThreePaint
{
    public partial class Form1 : Form
    {
        private bool isDrawing = false;
        private Point lastPoint;
        private Point startPoint;
        private Bitmap drawingBitmap;
        private Graphics drawingGraphics;
        private Tool currentTool = Tool.Pencil;
        private Color currentColor = Color.Black;
        private int currentBrushSize = 2;

        private Stack<Bitmap> undoStack = new Stack<Bitmap>();
        private Stack<Bitmap> redoStack = new Stack<Bitmap>();

        private bool isDarkMode = false;

        private float zoomFactor = 1.0f;
        private Size originalSize;

        private bool eraserSelected = false;

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
            drawingPanel.AutoScroll = true;

            originalSize = drawingPanel.Size;
            drawingPanel.AutoScroll = true;
        }

        private void PencilButton_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Pencil;
            eraserSelected = false;
            drawingPanel.Invalidate();
        }

        private void PenButton_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Pen;
            eraserSelected = false;
            drawingPanel.Invalidate();
        }

        private void SprayButton_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Spray;
            eraserSelected = false;
            drawingPanel.Invalidate();
        }

        private void WatercolorButton_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Watercolor;
            eraserSelected = false;
            drawingPanel.Invalidate();
        }

        private void EraserButton_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Eraser;
            eraserSelected = true;
            drawingPanel.Invalidate();
        }

        private void RectangleButton_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Rectangle;
            eraserSelected = false;
            drawingPanel.Invalidate();
        }

        private void EllipseButton_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Ellipse;
            eraserSelected = false;
            drawingPanel.Invalidate();
        }

        private void FillButton_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Fill;
            eraserSelected = false;
            drawingPanel.Invalidate();
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                currentColor = colorDialog.Color;
            }
            eraserSelected = false;
            drawingPanel.Invalidate();
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
            eraserSelected = false;
            drawingPanel.Invalidate();
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
            eraserSelected = false;
            drawingPanel.Invalidate();
        }

        private void DrawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                startPoint = ScalePoint(e.Location);
                lastPoint = startPoint;

                if (currentTool == Tool.Fill)
                {
                    Color targetColor = drawingBitmap.GetPixel(startPoint.X, startPoint.Y);
                    FloodFill(startPoint, targetColor);
                    isDrawing = false;
                }
                else
                {
                    undoStack.Push(new Bitmap(drawingBitmap));
                    redoStack.Clear();
                    DrawAtPoint(startPoint);
                }

                drawingPanel.Invalidate();
            }
        }

        private void DrawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                Point currentPoint = ScalePoint(e.Location);
<<<<<<< Updated upstream
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
                        using (Pen pen = new Pen(Color.White, Math.Max(currentBrushSize*5, 5)))
                        {
                            g.DrawLine(pen, lastPoint, currentPoint);
                        }
                    }
                }
=======
                DrawLine(lastPoint, currentPoint);
>>>>>>> Stashed changes
                lastPoint = currentPoint;
                drawingPanel.Invalidate();
            }

            if (eraserSelected)
            {
                drawingPanel.Invalidate();
            }
        }

        private void DrawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                isDrawing = false;
                drawingPanel.Invalidate();
            }
        }


        private void DrawAtPoint(Point point)
        {
            using (Graphics g = Graphics.FromImage(drawingBitmap))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                if (currentTool == Tool.Pencil || currentTool == Tool.Pen)
                {
                    using (SolidBrush brush = new SolidBrush(currentColor))
                    {
                        g.FillEllipse(brush, point.X - currentBrushSize / 2, point.Y - currentBrushSize / 2, currentBrushSize, currentBrushSize);
                    }
                }
                else if (currentTool == Tool.Spray)
                {
                    int particleCount = 50 + (currentBrushSize * 2); // Increase number of particles based on brush size
                    int radius = currentBrushSize; // Spray radius based on brush size

                    Random rand = new Random();
                    for (int i = 0; i < particleCount; i++)
                    {
                        int offsetX = rand.Next(-radius, radius);
                        int offsetY = rand.Next(-radius, radius);
                        double distance = Math.Sqrt(offsetX * offsetX + offsetY * offsetY);
                        if (distance <= radius)
                        {
                            g.FillEllipse(new SolidBrush(currentColor), point.X + offsetX, point.Y + offsetY, 1, 1);
                        }
                    }
                }
                else if (currentTool == Tool.Watercolor)
                {
                    int size = currentBrushSize * 2;
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(64, currentColor))) // Semi-transparent color
                    {
                        g.FillEllipse(brush, point.X - size / 2, point.Y - size / 2, size, size);
                    }
                }
                // Add other tool types here as needed
            }
        }


        private void DrawLine(Point from, Point to)
        {
            using (Graphics g = Graphics.FromImage(drawingBitmap))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                if (currentTool == Tool.Pencil || currentTool == Tool.Pen)
                {
                    using (Pen pen = new Pen(currentColor, currentBrushSize))
                    {
                        g.DrawLine(pen, from, to);
                    }
                }
                else if (currentTool == Tool.Eraser)
                {
                    using (Pen pen = new Pen(Color.White, currentBrushSize * 5))
                    {
                        g.DrawLine(pen, from, to);
                    }
                }
                else if (currentTool == Tool.Spray)
                {
                    // Spray tool: Draw at multiple points along the line
                    float distance = (float)Math.Sqrt((to.X - from.X) * (to.X - from.X) + (to.Y - from.Y) * (to.Y - from.Y));
                    float stepX = (to.X - from.X) / distance;
                    float stepY = (to.Y - from.Y) / distance;

                    for (float i = 0; i < distance; i += currentBrushSize)
                    {
                        Point sprayPoint = new Point((int)(from.X + i * stepX), (int)(from.Y + i * stepY));
                        DrawAtPoint(sprayPoint);
                    }
                }
                else if (currentTool == Tool.Watercolor)
                {
                    // Watercolor tool: Draw semi-transparent circles along the line
                    float distance = (float)Math.Sqrt((to.X - from.X) * (to.X - from.X) + (to.Y - from.Y) * (to.Y - from.Y));
                    float stepX = (to.X - from.X) / distance;
                    float stepY = (to.Y - from.Y) / distance;

                    for (float i = 0; i < distance; i += currentBrushSize)
                    {
                        Point waterColorPoint = new Point((int)(from.X + i * stepX), (int)(from.Y + i * stepY));
                        DrawAtPoint(waterColorPoint);
                    }
                }
                // Add other tool types here as needed
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
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            e.Graphics.TranslateTransform(drawingPanel.AutoScrollPosition.X, drawingPanel.AutoScrollPosition.Y);
            e.Graphics.ScaleTransform(zoomFactor, zoomFactor);
            e.Graphics.DrawImage(drawingBitmap, Point.Empty);

            if (eraserSelected)
            {
                DrawEraserOutline(e.Graphics);
            }

        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            if (undoStack.Count > 0)
            {
                redoStack.Push(new Bitmap(drawingBitmap));
                drawingBitmap = undoStack.Pop();
                drawingGraphics = Graphics.FromImage(drawingBitmap);
                drawingPanel.Invalidate();
            }
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            if (redoStack.Count > 0)
            {
                undoStack.Push(new Bitmap(drawingBitmap));
                drawingBitmap = redoStack.Pop();
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

        private void ClearButton_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(drawingBitmap));
            redoStack.Clear();
            drawingGraphics.Clear(Color.White);
            drawingPanel.Invalidate();
        }

        private void ZoomComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedZoom = zoomComboBox.SelectedItem.ToString();
            float newZoomFactor = float.Parse(selectedZoom.TrimEnd('%')) / 100f;
            ZoomAroundCenter(newZoomFactor);
        }

        private void ZoomAroundCenter(float newZoomFactor)
        {
            Point centerPoint = new Point(
                drawingPanel.Width / 2 - drawingPanel.AutoScrollPosition.X,
                drawingPanel.Height / 2 - drawingPanel.AutoScrollPosition.Y
            );

            Point scaledCenterPoint = new Point(
                (int)(centerPoint.X / zoomFactor),
                (int)(centerPoint.Y / zoomFactor)
            );

            zoomFactor = newZoomFactor;
            UpdateDrawingPanelSize();

            Point newCenterPoint = new Point(
                (int)(scaledCenterPoint.X * zoomFactor),
                (int)(scaledCenterPoint.Y * zoomFactor)
            );

            drawingPanel.AutoScrollPosition = new Point(
                newCenterPoint.X - drawingPanel.Width / 2,
                newCenterPoint.Y - drawingPanel.Height / 2
            );

            drawingPanel.Invalidate();
        }

        private void UpdateDrawingPanelSize()
        {
            int scaledWidth = (int)(drawingBitmap.Width * zoomFactor);
            int scaledHeight = (int)(drawingBitmap.Height * zoomFactor);
            drawingPanel.AutoScrollMinSize = new Size(scaledWidth, scaledHeight);
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
        private void DrawEraserOutline(Graphics g)
        {
            Point mousePosition = drawingPanel.PointToClient(Cursor.Position);
            Point scaledPosition = ScalePoint(mousePosition);
            int eraserSize = Math.Max(currentBrushSize*5, 5);

            using (Pen outlinePen = new Pen(Color.Black, 1))
            {
                outlinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                g.DrawEllipse(outlinePen, scaledPosition.X - eraserSize / 2, scaledPosition.Y - eraserSize / 2, eraserSize, eraserSize);
            }
        }
    }


}