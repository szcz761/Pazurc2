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
            this.Beep = new System.Windows.Forms.CheckBox();
            this.MinScore = new System.Windows.Forms.TextBox();
            this.TimeSleepS = new System.Windows.Forms.TextBox();
            this.SureChecked = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // GetHTMLButton
            // 
            this.GetHTMLButton.Location = new System.Drawing.Point(12, 258);
            this.GetHTMLButton.Name = "GetHTMLButton";
            this.GetHTMLButton.Size = new System.Drawing.Size(204, 23);
            this.GetHTMLButton.TabIndex = 0;
            this.GetHTMLButton.Text = "Get HTML";
            this.GetHTMLButton.UseVisualStyleBackColor = true;
            this.GetHTMLButton.Click += new System.EventHandler(this.GetHTMLButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 287);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(75, 154);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // ParseButton
            // 
            this.ParseButton.Location = new System.Drawing.Point(12, 447);
            this.ParseButton.Name = "ParseButton";
            this.ParseButton.Size = new System.Drawing.Size(204, 23);
            this.ParseButton.TabIndex = 4;
            this.ParseButton.Text = "Parse";
            this.ParseButton.UseVisualStyleBackColor = true;
            this.ParseButton.Click += new System.EventHandler(this.ParseButton_Click);
            // 
            // ScrollDownButton
            // 
            this.ScrollDownButton.Location = new System.Drawing.Point(12, 18);
            this.ScrollDownButton.Name = "ScrollDownButton";
            this.ScrollDownButton.Size = new System.Drawing.Size(204, 23);
            this.ScrollDownButton.TabIndex = 6;
            this.ScrollDownButton.Text = "Automat off";
            this.ScrollDownButton.UseVisualStyleBackColor = true;
            this.ScrollDownButton.Click += new System.EventHandler(this.ScrollDownButton_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(141, 287);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(75, 154);
            this.richTextBox2.TabIndex = 7;
            this.richTextBox2.Text = "";
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(12, 476);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(204, 23);
            this.CalculateButton.TabIndex = 8;
            this.CalculateButton.Text = "Find Sure Bets";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(12, 505);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(204, 190);
            this.richTextBox3.TabIndex = 9;
            this.richTextBox3.Text = "";
            // 
            // Beep
            // 
            this.Beep.AutoSize = true;
            this.Beep.Checked = true;
            this.Beep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Beep.Location = new System.Drawing.Point(165, 49);
            this.Beep.Name = "Beep";
            this.Beep.Size = new System.Drawing.Size(51, 17);
            this.Beep.TabIndex = 10;
            this.Beep.Text = "Beep";
            this.Beep.UseVisualStyleBackColor = true;
            this.Beep.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // MinScore
            // 
            this.MinScore.Location = new System.Drawing.Point(12, 47);
            this.MinScore.Name = "MinScore";
            this.MinScore.Size = new System.Drawing.Size(75, 20);
            this.MinScore.TabIndex = 11;
            this.MinScore.Text = "-0,1";
            this.MinScore.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // TimeSleepS
            // 
            this.TimeSleepS.Location = new System.Drawing.Point(93, 47);
            this.TimeSleepS.Name = "TimeSleepS";
            this.TimeSleepS.Size = new System.Drawing.Size(66, 20);
            this.TimeSleepS.TabIndex = 12;
            this.TimeSleepS.Text = "50";
            // 
            // SureChecked
            // 
            this.SureChecked.Location = new System.Drawing.Point(12, 73);
            this.SureChecked.Name = "SureChecked";
            this.SureChecked.Size = new System.Drawing.Size(204, 96);
            this.SureChecked.TabIndex = 13;
            this.SureChecked.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 697);
            this.Controls.Add(this.SureChecked);
            this.Controls.Add(this.TimeSleepS);
            this.Controls.Add(this.MinScore);
            this.Controls.Add(this.Beep);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.ScrollDownButton);
            this.Controls.Add(this.ParseButton);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.GetHTMLButton);
            this.Name = "Form1";
            this.Text = "7";
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.CheckBox Beep;
        private System.Windows.Forms.TextBox MinScore;
        private System.Windows.Forms.TextBox TimeSleepS;
        private System.Windows.Forms.RichTextBox SureChecked;
    }
}

