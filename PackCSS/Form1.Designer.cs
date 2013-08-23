namespace PackCSS
{
    partial class Form1
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.pnlDragTo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 144);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(260, 23);
            this.progressBar.TabIndex = 0;
            // 
            // pnlDragTo
            // 
            this.pnlDragTo.AllowDrop = true;
            this.pnlDragTo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlDragTo.Location = new System.Drawing.Point(12, 33);
            this.pnlDragTo.Name = "pnlDragTo";
            this.pnlDragTo.Size = new System.Drawing.Size(260, 105);
            this.pnlDragTo.TabIndex = 2;
            this.pnlDragTo.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlDragTo_DragDrop);
            this.pnlDragTo.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlDragTo_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Drag and Drop CSS file below.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 175);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlDragTo);
            this.Controls.Add(this.progressBar);
            this.Name = "Form1";
            this.Text = "PackCSS v1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Panel pnlDragTo;
        private System.Windows.Forms.Label label1;
    }
}

