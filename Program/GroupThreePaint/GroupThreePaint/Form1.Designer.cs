namespace GroupThreePaint
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.pencilButton = new System.Windows.Forms.ToolStripButton();
            this.eraserButton = new System.Windows.Forms.ToolStripButton();
            this.colorButton = new System.Windows.Forms.ToolStripButton();
            this.brushSizeComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.openButton = new System.Windows.Forms.ToolStripButton();
            this.rectangleButton = new System.Windows.Forms.ToolStripButton();
            this.ellipseButton = new System.Windows.Forms.ToolStripButton();
            this.undoButton = new System.Windows.Forms.ToolStripButton();
            this.redoButton = new System.Windows.Forms.ToolStripButton();
            this.themeToggleButton = new System.Windows.Forms.ToolStripButton();
            this.clearButton = new System.Windows.Forms.ToolStripButton();
            this.zoomComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.drawingPanel = new GroupThreePaint.DoubleBufferedPanel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pencilButton,
            this.eraserButton,
            this.colorButton,
            this.brushSizeComboBox,
            this.saveButton,
            this.openButton,
            this.rectangleButton,
            this.ellipseButton,
            this.undoButton,
            this.redoButton,
            this.themeToggleButton,
            this.clearButton,
            this.zoomComboBox});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1350, 35);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // pencilButton
            // 
            this.pencilButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pencilButton.Image = ((System.Drawing.Image)(resources.GetObject("pencilButton.Image")));
            this.pencilButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pencilButton.Name = "pencilButton";
            this.pencilButton.Size = new System.Drawing.Size(32, 32);
            this.pencilButton.Text = "Pencil";
            this.pencilButton.Click += new System.EventHandler(this.PencilButton_Click);
            // 
            // eraserButton
            // 
            this.eraserButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.eraserButton.Image = ((System.Drawing.Image)(resources.GetObject("eraserButton.Image")));
            this.eraserButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.eraserButton.Name = "eraserButton";
            this.eraserButton.Size = new System.Drawing.Size(32, 32);
            this.eraserButton.Text = "Eraser";
            this.eraserButton.Click += new System.EventHandler(this.EraserButton_Click);
            // 
            // colorButton
            // 
            this.colorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.colorButton.Image = ((System.Drawing.Image)(resources.GetObject("colorButton.Image")));
            this.colorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(32, 32);
            this.colorButton.Text = "Color";
            this.colorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // brushSizeComboBox
            // 
            this.brushSizeComboBox.Items.AddRange(new object[] {
            "2",
            "4",
            "6",
            "8",
            "10",
            "12",
            "14",
            "16"});
            this.brushSizeComboBox.Name = "brushSizeComboBox";
            this.brushSizeComboBox.Size = new System.Drawing.Size(75, 35);
            this.brushSizeComboBox.Text = "2";
            this.brushSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.BrushSizeComboBox_SelectedIndexChanged);
            // 
            // saveButton
            // 
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(32, 32);
            this.saveButton.Text = "Save";
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // openButton
            // 
            this.openButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openButton.Image = ((System.Drawing.Image)(resources.GetObject("openButton.Image")));
            this.openButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(32, 32);
            this.openButton.Text = "Open";
            this.openButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // rectangleButton
            // 
            this.rectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("rectangleButton.Image")));
            this.rectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rectangleButton.Name = "rectangleButton";
            this.rectangleButton.Size = new System.Drawing.Size(32, 32);
            this.rectangleButton.Text = "Rectangle";
            this.rectangleButton.Click += new System.EventHandler(this.RectangleButton_Click);
            // 
            // ellipseButton
            // 
            this.ellipseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ellipseButton.Image = ((System.Drawing.Image)(resources.GetObject("ellipseButton.Image")));
            this.ellipseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ellipseButton.Name = "ellipseButton";
            this.ellipseButton.Size = new System.Drawing.Size(32, 32);
            this.ellipseButton.Text = "Ellipse";
            this.ellipseButton.Click += new System.EventHandler(this.EllipseButton_Click);
            // 
            // undoButton
            // 
            this.undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoButton.Image = ((System.Drawing.Image)(resources.GetObject("undoButton.Image")));
            this.undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(32, 32);
            this.undoButton.Text = "Undo";
            this.undoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // redoButton
            // 
            this.redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoButton.Image = ((System.Drawing.Image)(resources.GetObject("redoButton.Image")));
            this.redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(32, 32);
            this.redoButton.Text = "Redo";
            this.redoButton.Click += new System.EventHandler(this.RedoButton_Click);
            // 
            // themeToggleButton
            // 
            this.themeToggleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.themeToggleButton.Image = ((System.Drawing.Image)(resources.GetObject("themeToggleButton.Image")));
            this.themeToggleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.themeToggleButton.Name = "themeToggleButton";
            this.themeToggleButton.Size = new System.Drawing.Size(32, 32);
            this.themeToggleButton.Text = "Theme";
            this.themeToggleButton.Click += new System.EventHandler(this.ThemeToggleButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearButton.Image = ((System.Drawing.Image)(resources.GetObject("clearButton.Image")));
            this.clearButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(32, 32);
            this.clearButton.Text = "Clear";
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // zoomComboBox
            // 
            this.zoomComboBox.Items.AddRange(new object[] {
            "50%",
            "100%",
            "150%",
            "200%",
            "300%"});
            this.zoomComboBox.Name = "zoomComboBox";
            this.zoomComboBox.Size = new System.Drawing.Size(75, 35);
            this.zoomComboBox.Text = "100%";
            this.zoomComboBox.SelectedIndexChanged += new System.EventHandler(this.ZoomComboBox_SelectedIndexChanged);
            // 
            // drawingPanel
            // 
            this.drawingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingPanel.Location = new System.Drawing.Point(0, 35);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(1350, 687);
            this.drawingPanel.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 722);
            this.Controls.Add(this.drawingPanel);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Ingyenes Paint";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton pencilButton;
        private System.Windows.Forms.ToolStripButton eraserButton;
        private GroupThreePaint.DoubleBufferedPanel drawingPanel;
        private System.Windows.Forms.ToolStripButton colorButton;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ToolStripComboBox brushSizeComboBox;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.ToolStripButton openButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripButton rectangleButton;
        private System.Windows.Forms.ToolStripButton ellipseButton;
        private System.Windows.Forms.ToolStripButton undoButton;
        private System.Windows.Forms.ToolStripButton redoButton;
        private System.Windows.Forms.ToolStripButton themeToggleButton;
        private System.Windows.Forms.ToolStripButton clearButton;
        private System.Windows.Forms.ToolStripComboBox zoomComboBox;
    }
}