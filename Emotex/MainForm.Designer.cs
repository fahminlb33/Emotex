namespace Emotex
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmdTrain = new System.Windows.Forms.Button();
            this.cmdBenchmark = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSentiment = new System.Windows.Forms.TextBox();
            this.chkStopWords = new System.Windows.Forms.CheckBox();
            this.chkStemWords = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmdRocCurve = new System.Windows.Forms.Button();
            this.txtStats = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvLogs = new System.Windows.Forms.DataGridView();
            this.lblScores = new System.Windows.Forms.Label();
            this.lblProbabilities = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdCheck = new System.Windows.Forms.Button();
            this.lblSentimentResult = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 93);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(31, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(561, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Emotex: Implementasi Sentiment Analysis menggunakan Accord.NET dan Naive Bayes Cl" +
    "assifier";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(242, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Emotex";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(138, 109);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(355, 42);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "UNLOADED";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmdTrain
            // 
            this.cmdTrain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTrain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.cmdTrain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdTrain.Location = new System.Drawing.Point(285, 18);
            this.cmdTrain.Name = "cmdTrain";
            this.cmdTrain.Size = new System.Drawing.Size(88, 27);
            this.cmdTrain.TabIndex = 4;
            this.cmdTrain.Text = "Train";
            this.cmdTrain.UseVisualStyleBackColor = false;
            this.cmdTrain.Click += new System.EventHandler(this.cmdTrain_Click);
            // 
            // cmdBenchmark
            // 
            this.cmdBenchmark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBenchmark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.cmdBenchmark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBenchmark.Location = new System.Drawing.Point(379, 18);
            this.cmdBenchmark.Name = "cmdBenchmark";
            this.cmdBenchmark.Size = new System.Drawing.Size(88, 27);
            this.cmdBenchmark.TabIndex = 5;
            this.cmdBenchmark.Text = "Evaluate";
            this.cmdBenchmark.UseVisualStyleBackColor = false;
            this.cmdBenchmark.Click += new System.EventHandler(this.cmdBenchmark_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Enter sentiment:";
            // 
            // txtSentiment
            // 
            this.txtSentiment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSentiment.Location = new System.Drawing.Point(22, 37);
            this.txtSentiment.Name = "txtSentiment";
            this.txtSentiment.Size = new System.Drawing.Size(455, 23);
            this.txtSentiment.TabIndex = 7;
            // 
            // chkStopWords
            // 
            this.chkStopWords.AutoSize = true;
            this.chkStopWords.Location = new System.Drawing.Point(18, 13);
            this.chkStopWords.Name = "chkStopWords";
            this.chkStopWords.Size = new System.Drawing.Size(130, 19);
            this.chkStopWords.TabIndex = 2;
            this.chkStopWords.Text = "Remove stop words";
            this.chkStopWords.UseVisualStyleBackColor = true;
            // 
            // chkStemWords
            // 
            this.chkStemWords.AutoSize = true;
            this.chkStemWords.Location = new System.Drawing.Point(18, 38);
            this.chkStemWords.Name = "chkStemWords";
            this.chkStemWords.Size = new System.Drawing.Size(88, 19);
            this.chkStemWords.TabIndex = 3;
            this.chkStemWords.Text = "Stem words";
            this.chkStemWords.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(19, 169);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(589, 323);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tabPage1.Controls.Add(this.cmdRocCurve);
            this.tabPage1.Controls.Add(this.txtStats);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.chkStemWords);
            this.tabPage1.Controls.Add(this.chkStopWords);
            this.tabPage1.Controls.Add(this.cmdTrain);
            this.tabPage1.Controls.Add(this.cmdBenchmark);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(581, 295);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Training/Evaluation";
            // 
            // cmdRocCurve
            // 
            this.cmdRocCurve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRocCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRocCurve.Location = new System.Drawing.Point(473, 18);
            this.cmdRocCurve.Name = "cmdRocCurve";
            this.cmdRocCurve.Size = new System.Drawing.Size(88, 27);
            this.cmdRocCurve.TabIndex = 8;
            this.cmdRocCurve.Text = "ROC curve";
            this.cmdRocCurve.UseVisualStyleBackColor = true;
            this.cmdRocCurve.Click += new System.EventHandler(this.cmdRocCurve_Click);
            // 
            // txtStats
            // 
            this.txtStats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStats.Location = new System.Drawing.Point(18, 87);
            this.txtStats.Multiline = true;
            this.txtStats.Name = "txtStats";
            this.txtStats.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStats.Size = new System.Drawing.Size(543, 190);
            this.txtStats.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Statistics:";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.dgvLogs);
            this.tabPage4.Controls.Add(this.lblScores);
            this.tabPage4.Controls.Add(this.lblProbabilities);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.cmdCheck);
            this.tabPage4.Controls.Add(this.lblSentimentResult);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.txtSentiment);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(581, 295);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Classification";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "Logs:";
            // 
            // dgvLogs
            // 
            this.dgvLogs.AllowUserToAddRows = false;
            this.dgvLogs.AllowUserToDeleteRows = false;
            this.dgvLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogs.Location = new System.Drawing.Point(22, 155);
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.ReadOnly = true;
            this.dgvLogs.Size = new System.Drawing.Size(538, 121);
            this.dgvLogs.TabIndex = 14;
            // 
            // lblScores
            // 
            this.lblScores.AutoSize = true;
            this.lblScores.Location = new System.Drawing.Point(343, 99);
            this.lblScores.Name = "lblScores";
            this.lblScores.Size = new System.Drawing.Size(16, 15);
            this.lblScores.TabIndex = 13;
            this.lblScores.Text = "...";
            // 
            // lblProbabilities
            // 
            this.lblProbabilities.AutoSize = true;
            this.lblProbabilities.Location = new System.Drawing.Point(343, 81);
            this.lblProbabilities.Name = "lblProbabilities";
            this.lblProbabilities.Size = new System.Drawing.Size(16, 15);
            this.lblProbabilities.TabIndex = 12;
            this.lblProbabilities.Text = "...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(262, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Scores:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Probabilities:";
            // 
            // cmdCheck
            // 
            this.cmdCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCheck.Location = new System.Drawing.Point(483, 37);
            this.cmdCheck.Name = "cmdCheck";
            this.cmdCheck.Size = new System.Drawing.Size(72, 23);
            this.cmdCheck.TabIndex = 9;
            this.cmdCheck.Text = "Check";
            this.cmdCheck.UseVisualStyleBackColor = true;
            this.cmdCheck.Click += new System.EventHandler(this.cmdCheck_Click);
            // 
            // lblSentimentResult
            // 
            this.lblSentimentResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSentimentResult.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.lblSentimentResult.Location = new System.Drawing.Point(23, 71);
            this.lblSentimentResult.Name = "lblSentimentResult";
            this.lblSentimentResult.Size = new System.Drawing.Size(221, 53);
            this.lblSentimentResult.TabIndex = 8;
            this.lblSentimentResult.Text = "...";
            this.lblSentimentResult.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(622, 506);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "MainForm";
            this.Text = "Emotex - Emotion from Text";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button cmdTrain;
        private System.Windows.Forms.Button cmdBenchmark;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSentiment;
        private System.Windows.Forms.CheckBox chkStopWords;
        private System.Windows.Forms.CheckBox chkStemWords;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txtStats;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdCheck;
        private System.Windows.Forms.Label lblSentimentResult;
        private System.Windows.Forms.Button cmdRocCurve;
        private System.Windows.Forms.Label lblScores;
        private System.Windows.Forms.Label lblProbabilities;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvLogs;
    }
}

