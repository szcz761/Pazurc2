namespace Pazurc2
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
            this.GetHTMLButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ParseButton = new System.Windows.Forms.Button();
            this.ScrollDownButton = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // GetHTMLButton
            // 
            this.GetHTMLButton.Location = new System.Drawing.Point(12, 47);
            this.GetHTMLButton.Name = "GetHTMLButton";
            this.GetHTMLButton.Size = new System.Drawing.Size(217, 23);
            this.GetHTMLButton.TabIndex = 0;
            this.GetHTMLButton.Text = "Get HTML";
            this.GetHTMLButton.UseVisualStyleBackColor = true;
            this.GetHTMLButton.Click += new System.EventHandler(this.GetHTMLButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 76);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(75, 154);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // ParseButton
            // 
            this.ParseButton.Location = new System.Drawing.Point(12, 236);
            this.ParseButton.Name = "ParseButton";
            this.ParseButton.Size = new System.Drawing.Size(217, 23);
            this.ParseButton.TabIndex = 4;
            this.ParseButton.Text = "Parse";
            this.ParseButton.UseVisualStyleBackColor = true;
            this.ParseButton.Click += new System.EventHandler(this.ParseButton_Click);
            // 
            // ScrollDownButton
            // 
            this.ScrollDownButton.Location = new System.Drawing.Point(12, 18);
            this.ScrollDownButton.Name = "ScrollDownButton";
            this.ScrollDownButton.Size = new System.Drawing.Size(217, 23);
            this.ScrollDownButton.TabIndex = 6;
            this.ScrollDownButton.Text = "Scroll Down";
            this.ScrollDownButton.UseVisualStyleBackColor = true;
            this.ScrollDownButton.Click += new System.EventHandler(this.ScrollDownButton_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(154, 76);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(75, 154);
            this.richTextBox2.TabIndex = 7;
            this.richTextBox2.Text = "";
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(12, 265);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(217, 23);
            this.CalculateButton.TabIndex = 8;
            this.CalculateButton.Text = "Find Sure Bets";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(12, 294);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(217, 190);
            this.richTextBox3.TabIndex = 9;
            this.richTextBox3.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 697);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.ScrollDownButton);
            this.Controls.Add(this.ParseButton);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.GetHTMLButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GetHTMLButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button ParseButton;
        private System.Windows.Forms.Button ScrollDownButton;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.RichTextBox richTextBox3;
    }
}

