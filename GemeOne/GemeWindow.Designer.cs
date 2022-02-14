
namespace GemeOne
{
    partial class GemeWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainWindow = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.MainWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // MainWindow
            // 
            this.MainWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainWindow.Location = new System.Drawing.Point(13, 13);
            this.MainWindow.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MainWindow.MinimumSize = new System.Drawing.Size(128, 72);
            this.MainWindow.Name = "MainWindow";
            this.MainWindow.Size = new System.Drawing.Size(775, 425);
            this.MainWindow.TabIndex = 0;
            this.MainWindow.TabStop = false;
            // 
            // GemeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainWindow);
            this.Name = "GemeWindow";
            this.Text = "GemeWindow";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textbox1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.MainWindow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox MainWindow;
    }
}

