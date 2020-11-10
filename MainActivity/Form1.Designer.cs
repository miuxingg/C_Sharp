namespace MainActivity
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddCPT = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvShowAll = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnP4 = new System.Windows.Forms.Button();
            this.btnP3 = new System.Windows.Forms.Button();
            this.btnP2 = new System.Windows.Forms.Button();
            this.btnP1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowAll)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1111, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddCPT});
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.insertToolStripMenuItem.Text = "Insert";
            // 
            // mnuAddCPT
            // 
            this.mnuAddCPT.Name = "mnuAddCPT";
            this.mnuAddCPT.Size = new System.Drawing.Size(153, 22);
            this.mnuAddCPT.Text = "Add Computer";
            this.mnuAddCPT.Click += new System.EventHandler(this.mnuAddCPT_Click);
            // 
            // dgvShowAll
            // 
            this.dgvShowAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowAll.Location = new System.Drawing.Point(237, 65);
            this.dgvShowAll.Name = "dgvShowAll";
            this.dgvShowAll.Size = new System.Drawing.Size(790, 420);
            this.dgvShowAll.TabIndex = 7;
            this.dgvShowAll.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvShow_CellContentDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAll);
            this.groupBox1.Controls.Add(this.btnP4);
            this.groupBox1.Controls.Add(this.btnP3);
            this.groupBox1.Controls.Add(this.btnP2);
            this.groupBox1.Controls.Add(this.btnP1);
            this.groupBox1.Location = new System.Drawing.Point(21, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 420);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loại phòng";
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(21, 37);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(154, 51);
            this.btnAll.TabIndex = 10;
            this.btnAll.Text = "Tất cả";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click_1);
            // 
            // btnP4
            // 
            this.btnP4.Location = new System.Drawing.Point(21, 272);
            this.btnP4.Name = "btnP4";
            this.btnP4.Size = new System.Drawing.Size(154, 48);
            this.btnP4.TabIndex = 9;
            this.btnP4.Text = "Phòng không hút thuốc";
            this.btnP4.UseVisualStyleBackColor = true;
            this.btnP4.Click += new System.EventHandler(this.btnP4_Click_1);
            // 
            // btnP3
            // 
            this.btnP3.Location = new System.Drawing.Point(21, 212);
            this.btnP3.Name = "btnP3";
            this.btnP3.Size = new System.Drawing.Size(154, 49);
            this.btnP3.TabIndex = 8;
            this.btnP3.Text = "Phòng hút thuốc";
            this.btnP3.UseVisualStyleBackColor = true;
            this.btnP3.Click += new System.EventHandler(this.btnP3_Click_1);
            // 
            // btnP2
            // 
            this.btnP2.Location = new System.Drawing.Point(21, 153);
            this.btnP2.Name = "btnP2";
            this.btnP2.Size = new System.Drawing.Size(154, 52);
            this.btnP2.TabIndex = 7;
            this.btnP2.Text = "Phòng víp";
            this.btnP2.UseVisualStyleBackColor = true;
            this.btnP2.Click += new System.EventHandler(this.btnP2_Click_1);
            // 
            // btnP1
            // 
            this.btnP1.Location = new System.Drawing.Point(21, 96);
            this.btnP1.Name = "btnP1";
            this.btnP1.Size = new System.Drawing.Size(154, 50);
            this.btnP1.TabIndex = 6;
            this.btnP1.Text = "Phòng thường";
            this.btnP1.UseVisualStyleBackColor = true;
            this.btnP1.Click += new System.EventHandler(this.btnP1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 584);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvShowAll);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Quán của tôi";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowAll)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAddCPT;
        private System.Windows.Forms.DataGridView dgvShowAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnP4;
        private System.Windows.Forms.Button btnP3;
        private System.Windows.Forms.Button btnP2;
        private System.Windows.Forms.Button btnP1;
    }
}

