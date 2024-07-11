namespace GroupThreePaint
{
    partial class Form1
    {
        private ToolStrip toolStrip1;
        private ToolStripButton watercolorButton;
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            toolStrip1 = new ToolStrip();
            watercolorButton = new ToolStripButton();
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
            fillButton = new ToolStripButton();
            colorDialog = new ColorDialog();
            saveFileDialog = new SaveFileDialog();
            openFileDialog = new OpenFileDialog();
            drawingPanel = new DoubleBufferedPanel();
            errorProvider1 = new ErrorProvider(components);
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(28, 28);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2, toolStripButton3, watercolorButton, eraserButton, colorButton, brushSizeComboBox, saveButton, openButton, rectangleButton, ellipseButton, undoButton, redoButton, themeToggleButton, clearButton, fillButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1350, 35);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // watercolorButton
            // 
            watercolorButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            watercolorButton.Image = (Image)resources.GetObject("watercolorButton.Image");
            watercolorButton.Name = "watercolorButton";
            watercolorButton.Size = new Size(32, 32);
            watercolorButton.Text = "Watercolor";
            watercolorButton.Click += WatercolorButton_Click;
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
            // fillButton
            // 
            fillButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            fillButton.Image = (Image)resources.GetObject("fillButton.Image");
            fillButton.ImageTransparentColor = Color.Magenta;
            fillButton.Name = "fillButton";
            fillButton.Size = new Size(32, 32);
            fillButton.Text = "toolStripButton1";
            fillButton.Click += FillButton_Click;
            // 
            // drawingPanel
            // 
            drawingPanel.Dock = DockStyle.Fill;
            drawingPanel.Location = new Point(0, 35);
            drawingPanel.Name = "drawingPanel";
            drawingPanel.Size = new Size(1350, 687);
            drawingPanel.TabIndex = 1;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(32, 32);
            toolStripButton1.Text = "Pencil";
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(32, 32);
            toolStripButton2.Text = "Pen";
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(32, 32);
            toolStripButton3.Text = "Spray";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1350, 722);
            Controls.Add(drawingPanel);
            Controls.Add(toolStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Ingyenes Paint";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private ToolStripButton undoButton;
        private ToolStripButton redoButton;
        private ErrorProvider errorProvider1;
        private System.ComponentModel.IContainer components;
        private ToolStripButton fillButton;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
    }
}
