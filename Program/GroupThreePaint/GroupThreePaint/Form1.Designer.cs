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

        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.ToolStripButton openButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;

        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.pencilButton = new System.Windows.Forms.ToolStripButton();
            this.eraserButton = new System.Windows.Forms.ToolStripButton();
            this.colorButton = new System.Windows.Forms.ToolStripButton();
            this.brushSizeComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.saveButton = new System.Windows.Forms.ToolStripButton(); // Add save button
            this.openButton = new System.Windows.Forms.ToolStripButton(); // Add open button
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog(); // Add save file dialog
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog(); // Add open file dialog
            this.drawingPanel = new DoubleBufferedPanel(); // Use DoubleBufferedPanel here
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        this.pencilButton,
        this.eraserButton,
        this.colorButton,
        this.brushSizeComboBox,
        this.saveButton, // Add save button to the ToolStrip
        this.openButton}); // Add open button to the ToolStrip
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // pencilButton
            // 
            this.pencilButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.pencilButton.Name = "pencilButton";
            this.pencilButton.Size = new System.Drawing.Size(50, 24);
            this.pencilButton.Text = "Pencil";
            this.pencilButton.Click += new System.EventHandler(this.PencilButton_Click);
            // 
            // eraserButton
            // 
            this.eraserButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.eraserButton.Name = "eraserButton";
            this.eraserButton.Size = new System.Drawing.Size(54, 24);
            this.eraserButton.Text = "Eraser";
            this.eraserButton.Click += new System.EventHandler(this.EraserButton_Click);
            // 
            // colorButton
            // 
            this.colorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(48, 24);
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
            this.brushSizeComboBox.Size = new System.Drawing.Size(75, 27);
            this.brushSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.BrushSizeComboBox_SelectedIndexChanged);
            this.brushSizeComboBox.SelectedIndex = 0; // Set default brush size
                                                      // 
                                                      // saveButton
                                                      // 
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(45, 24);
            this.saveButton.Text = "Save";
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // openButton
            // 
            this.openButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(51, 24);
            this.openButton.Text = "Open";
            this.openButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // drawingPanel
            // 
            this.drawingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingPanel.Location = new System.Drawing.Point(0, 27);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(800, 423);
            this.drawingPanel.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.drawingPanel);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Simple Paint App";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

    }
}