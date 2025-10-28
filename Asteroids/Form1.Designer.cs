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
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(832, 503);
            Margin = new Padding(3, 4, 3, 4);
            MaximumSize = new Size(850, 550);
            MinimumSize = new Size(850, 550);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Asteroids";
            ResumeLayout(false);
        }
    }
}
