namespace Chess
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.new2PlayerGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endCurrentGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitView = new System.Windows.Forms.SplitContainer();
            this.lbl_Turn = new System.Windows.Forms.Label();
            this.lblBlackCheck = new System.Windows.Forms.Label();
            this.lblWhiteCheck = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitView)).BeginInit();
            this.splitView.Panel2.SuspendLayout();
            this.splitView.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(847, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.new2PlayerGameToolStripMenuItem,
            this.endCurrentGameToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.fileToolStripMenuItem.Text = "Game";
            // 
            // new2PlayerGameToolStripMenuItem
            // 
            this.new2PlayerGameToolStripMenuItem.Name = "new2PlayerGameToolStripMenuItem";
            this.new2PlayerGameToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.new2PlayerGameToolStripMenuItem.Text = "PVP Game";
            this.new2PlayerGameToolStripMenuItem.Click += new System.EventHandler(this.NewGame);
            // 
            // endCurrentGameToolStripMenuItem
            // 
            this.endCurrentGameToolStripMenuItem.Name = "endCurrentGameToolStripMenuItem";
            this.endCurrentGameToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.endCurrentGameToolStripMenuItem.Text = "End Game";
            this.endCurrentGameToolStripMenuItem.Click += new System.EventHandler(this.endCurrentGameToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(157, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 538);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(847, 24);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitView
            // 
            this.splitView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitView.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitView.IsSplitterFixed = true;
            this.splitView.Location = new System.Drawing.Point(0, 28);
            this.splitView.Margin = new System.Windows.Forms.Padding(4);
            this.splitView.Name = "splitView";
            // 
            // splitView.Panel1
            // 
            this.splitView.Panel1.BackColor = System.Drawing.Color.Gray;
            this.splitView.Panel1.Resize += new System.EventHandler(this.ResizeBoard);
            this.splitView.Panel1MinSize = 400;
            // 
            // splitView.Panel2
            // 
            this.splitView.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitView.Panel2.Controls.Add(this.lbl_Turn);
            this.splitView.Panel2.Controls.Add(this.lblBlackCheck);
            this.splitView.Panel2.Controls.Add(this.lblWhiteCheck);
            this.splitView.Panel2.Controls.Add(this.label3);
            this.splitView.Panel2.Controls.Add(this.txtLog);
            this.splitView.Panel2.Controls.Add(this.label1);
            this.splitView.Panel2.Controls.Add(this.label2);
            this.splitView.Panel2MinSize = 200;
            this.splitView.Size = new System.Drawing.Size(847, 510);
            this.splitView.SplitterDistance = 612;
            this.splitView.SplitterWidth = 5;
            this.splitView.TabIndex = 2;
            // 
            // lbl_Turn
            // 
            this.lbl_Turn.AutoSize = true;
            this.lbl_Turn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Turn.Location = new System.Drawing.Point(84, 39);
            this.lbl_Turn.Name = "lbl_Turn";
            this.lbl_Turn.Size = new System.Drawing.Size(0, 22);
            this.lbl_Turn.TabIndex = 7;
            // 
            // lblBlackCheck
            // 
            this.lblBlackCheck.AutoSize = true;
            this.lblBlackCheck.Location = new System.Drawing.Point(210, 44);
            this.lblBlackCheck.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBlackCheck.Name = "lblBlackCheck";
            this.lblBlackCheck.Size = new System.Drawing.Size(58, 16);
            this.lblBlackCheck.TabIndex = 6;
            this.lblBlackCheck.Text = "In Check";
            this.lblBlackCheck.Visible = false;
            // 
            // lblWhiteCheck
            // 
            this.lblWhiteCheck.AutoSize = true;
            this.lblWhiteCheck.Location = new System.Drawing.Point(18, 44);
            this.lblWhiteCheck.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWhiteCheck.Name = "lblWhiteCheck";
            this.lblWhiteCheck.Size = new System.Drawing.Size(58, 16);
            this.lblWhiteCheck.TabIndex = 6;
            this.lblWhiteCheck.Text = "In Check";
            this.lblWhiteCheck.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Moves:";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(21, 111);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(248, 324);
            this.txtLog.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "White";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(208, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Black";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 562);
            this.Controls.Add(this.splitView);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(861, 605);
            this.Name = "MainForm";
            this.Text = "Chess";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.windowClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitView.Panel2.ResumeLayout(false);
            this.splitView.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitView)).EndInit();
            this.splitView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lblBlackCheck;
        private System.Windows.Forms.Label lblWhiteCheck;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem new2PlayerGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endCurrentGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Turn;
    }
}

