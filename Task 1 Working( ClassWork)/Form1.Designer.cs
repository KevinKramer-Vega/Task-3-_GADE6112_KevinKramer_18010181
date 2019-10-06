namespace Task_1_Working__ClassWork_
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
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.lblRound = new System.Windows.Forms.Label();
            this.gBoxMap = new System.Windows.Forms.GroupBox();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(774, 13);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(91, 43);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(881, 13);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(91, 43);
            this.btnPause.TabIndex = 0;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // lblRound
            // 
            this.lblRound.AutoSize = true;
            this.lblRound.Location = new System.Drawing.Point(772, 85);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(62, 17);
            this.lblRound.TabIndex = 1;
            this.lblRound.Text = "Round : ";
            // 
            // gBoxMap
            // 
            this.gBoxMap.Location = new System.Drawing.Point(13, 13);
            this.gBoxMap.Name = "gBoxMap";
            this.gBoxMap.Size = new System.Drawing.Size(746, 537);
            this.gBoxMap.TabIndex = 3;
            this.gBoxMap.TabStop = false;
            this.gBoxMap.Text = "Map";
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(775, 121);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(325, 429);
            this.txtInfo.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 577);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.gBoxMap);
            this.Controls.Add(this.lblRound);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label lblRound;
        private System.Windows.Forms.GroupBox gBoxMap;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Timer timer1;
    }
}

