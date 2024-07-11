namespace GroupThreePaint
{
    partial class Form1
    {
        private ToolStrip toolStrip1;
        private ToolStripButton pencilButton;
        private ToolStripButton eraserButton;
        private DoubleBufferedPanel drawingPanel;
        private ToolStripButton colorButton;
        private ColorDialog colorDialog;

        private ToolStripComboBox brushSizeComboBox;

        private ToolStripButton saveButton;
        private ToolStripButton openButton;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;

        private ToolStripButton rectangleButton;
        private ToolStripButton ellipseButton;

        private ToolStripButton themeToggleButton;
        private ToolStripButton clearButton; // Add this line

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            toolStrip1 = new ToolStrip();
            pencilButton = new ToolStripButton();
            eraserButton = new ToolStripButton();
            colorButton = new ToolStripButton();
            brushSizeComboBox = new ToolStripComboBox();
            saveButton = new ToolStripButton();
            openButton = new ToolStripButton();
            rectangleButton = new ToolStripButton();
            ellipseButton = new ToolStripButton();
            undoButton = new ToolStripButton();
            redoButton = new ToolStripButton();
            themeToggleButton = new ToolStripButton();
            clearButton = new ToolStripButton();
            colorDialog = new ColorDialog();
            saveFileDialog = new SaveFileDialog();
            openFileDialog = new OpenFileDialog();
            drawingPanel = new DoubleBufferedPanel();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(28, 28);
            toolStrip1.Items.AddRange(new ToolStripItem[] { pencilButton, eraserButton, colorButton, brushSizeComboBox, saveButton, openButton, rectangleButton, ellipseButton, undoButton, redoButton, themeToggleButton, clearButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1350, 35);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // pencilButton
            // 
            pencilButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            pencilButton.Image = (Image)resources.GetObject("pencilButton.Image");
            pencilButton.Name = "pencilButton";
            pencilButton.Size = new Size(32, 32);
            pencilButton.Text = "Pencil";
            pencilButton.Click += PencilButton_Click;
            // 
            // eraserButton
            // 
            eraserButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            eraserButton.Image = (Image)resources.GetObject("eraserButton.Image");
            eraserButton.Name = "eraserButton";
            eraserButton.Size = new Size(32, 32);
            eraserButton.Text = "Eraser";
            eraserButton.Click += EraserButton_Click;
            // 
            // colorButton
            // 
            colorButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            colorButton.Image = (Image)resources.GetObject("colorButton.Image");
            colorButton.Name = "colorButton";
            colorButton.Size = new Size(32, 32);
            colorButton.Text = "Color";
            colorButton.Click += ColorButton_Click;
            // 
            // brushSizeComboBox
            // 
            brushSizeComboBox.Items.AddRange(new object[] { "2", "4", "6", "8", "10", "12", "14", "16" });
            brushSizeComboBox.Name = "brushSizeComboBox";
            brushSizeComboBox.Size = new Size(75, 35);
            brushSizeComboBox.Text = "2";
            brushSizeComboBox.SelectedIndexChanged += BrushSizeComboBox_SelectedIndexChanged;
            // 
            // saveButton
            // 
            saveButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            saveButton.Image = (Image)resources.GetObject("saveButton.Image");
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(32, 32);
            saveButton.Text = "Save";
            saveButton.Click += SaveButton_Click;
            // 
            // openButton
            // 
            openButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            openButton.Image = (Image)resources.GetObject("openButton.Image");
            openButton.Name = "openButton";
            openButton.Size = new Size(32, 32);
            openButton.Text = "Open";
            openButton.Click += OpenButton_Click;
            // 
            // rectangleButton
            // 
            rectangleButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            rectangleButton.Image = (Image)resources.GetObject("rectangleButton.Image");
            rectangleButton.Name = "rectangleButton";
            rectangleButton.Size = new Size(32, 32);
            rectangleButton.Text = "Rectangle";
            rectangleButton.Click += RectangleButton_Click;
            // 
            // ellipseButton
            // 
            ellipseButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ellipseButton.Image = (Image)resources.GetObject("ellipseButton.Image");
            ellipseButton.Name = "ellipseButton";
            ellipseButton.Size = new Size(32, 32);
            ellipseButton.Text = "Ellipse";
            ellipseButton.Click += EllipseButton_Click;
            // 
            // undoButton
            // 
            undoButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            undoButton.Image = (Image)resources.GetObject("undoButton.Image");
            undoButton.Name = "undoButton";
            undoButton.Size = new Size(32, 32);
            undoButton.Text = "Undo";
            undoButton.Click += UndoButton_Click;
            // 
            // redoButton
            // 
            redoButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            redoButton.Image = (Image)resources.GetObject("redoButton.Image");
            redoButton.Name = "redoButton";
            redoButton.Size = new Size(32, 32);
            redoButton.Text = "Redo";
            redoButton.Click += RedoButton_Click;
            // 
            // themeToggleButton
            // 
            themeToggleButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            themeToggleButton.Image = (Image)resources.GetObject("themeToggleButton.Image");
            themeToggleButton.Name = "themeToggleButton";
            themeToggleButton.Size = new Size(32, 32);
            themeToggleButton.Text = "Theme";
            themeToggleButton.Click += ThemeToggleButton_Click;
            // 
            // clearButton
            // 
            clearButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            clearButton.Image = (Image)resources.GetObject("clearButton.Image");
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(32, 32);
            clearButton.Text = "Clear";
            clearButton.Click += ClearButton_Click;
            // 
            // drawingPanel
            // 
            drawingPanel.Dock = DockStyle.Fill;
            drawingPanel.Location = new Point(0, 35);
            drawingPanel.Name = "drawingPanel";
            drawingPanel.Size = new Size(1350, 687);
            drawingPanel.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1350, 722);
            Controls.Add(drawingPanel);
            Controls.Add(toolStrip1);
            Name = "Form1";
            Text = "Ingyenes Paint";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private ToolStripButton undoButton;
        private ToolStripButton redoButton;
    }
}
