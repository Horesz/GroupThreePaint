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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            toolStrip1 = new ToolStrip();
            pencilButton = new ToolStripButton();
            eraserButton = new ToolStripButton();
            colorButton = new ToolStripButton();
            colorDialog = new ColorDialog();
            drawingPanel = new DoubleBufferedPanel();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { pencilButton, eraserButton, colorButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(700, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // pencilButton
            // 
            pencilButton.Image = (Image)resources.GetObject("pencilButton.Image");
            pencilButton.Name = "pencilButton";
            pencilButton.Size = new Size(59, 22);
            pencilButton.Text = "Pencil";
            pencilButton.Click += PencilButton_Click;
            // 
            // eraserButton
            // 
            eraserButton.Image = (Image)resources.GetObject("eraserButton.Image");
            eraserButton.Name = "eraserButton";
            eraserButton.Size = new Size(58, 22);
            eraserButton.Text = "Eraser";
            eraserButton.Click += EraserButton_Click;
            // 
            // colorButton
            // 
            colorButton.Image = (Image)resources.GetObject("colorButton.Image");
            colorButton.Name = "colorButton";
            colorButton.Size = new Size(56, 22);
            colorButton.Text = "Color";
            colorButton.Click += ColorButton_Click;
            // 
            // drawingPanel
            // 
            drawingPanel.Dock = DockStyle.Fill;
            drawingPanel.Location = new Point(0, 25);
            drawingPanel.Name = "drawingPanel";
            drawingPanel.Size = new Size(700, 397);
            drawingPanel.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 422);
            Controls.Add(drawingPanel);
            Controls.Add(toolStrip1);
            Name = "Form1";
            Text = "Simple Paint App";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}