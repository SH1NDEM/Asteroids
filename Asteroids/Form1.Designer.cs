namespace Asteroids
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
            SuspendLayout();
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(834, 511);
            MaximumSize = new Size(850, 550);
            MinimumSize = new Size(850, 550);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Asteroids";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }
    }
}
