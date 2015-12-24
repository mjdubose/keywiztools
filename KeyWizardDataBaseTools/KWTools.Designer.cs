namespace KeyWizardDataBaseTools
{
    partial class KWTools
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
                SQL.Dispose();
                keywiz.Dispose();

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
            this.btnKeyWizUpdate = new System.Windows.Forms.Button();
            this.txtDisplay = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.updateKeyWizardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doTermedEmployeeKeySearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnDoTermedEmployeeKeyList = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnKeysToFile = new System.Windows.Forms.Button();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker4 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnKeyWizUpdate
            // 
            this.btnKeyWizUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKeyWizUpdate.Location = new System.Drawing.Point(635, 502);
            this.btnKeyWizUpdate.Name = "btnKeyWizUpdate";
            this.btnKeyWizUpdate.Size = new System.Drawing.Size(234, 23);
            this.btnKeyWizUpdate.TabIndex = 0;
            this.btnKeyWizUpdate.Text = "Update Key Wizard from CSV";
            this.btnKeyWizUpdate.UseVisualStyleBackColor = true;
            this.btnKeyWizUpdate.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDisplay
            // 
            this.txtDisplay.Location = new System.Drawing.Point(48, 54);
            this.txtDisplay.Multiline = true;
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDisplay.Size = new System.Drawing.Size(887, 430);
            this.txtDisplay.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(966, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripMenuItem2,
            this.toolStripSeparator2,
            this.updateKeyWizardToolStripMenuItem,
            this.doTermedEmployeeKeySearchToolStripMenuItem,
            this.toolStripSeparator3,
            this.quitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(469, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(472, 22);
            this.toolStripMenuItem2.Text = "Import Employee and Key Records to SQL Server using Key Wizard Database";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(469, 6);
            // 
            // updateKeyWizardToolStripMenuItem
            // 
            this.updateKeyWizardToolStripMenuItem.Name = "updateKeyWizardToolStripMenuItem";
            this.updateKeyWizardToolStripMenuItem.Size = new System.Drawing.Size(472, 22);
            this.updateKeyWizardToolStripMenuItem.Text = "Update SQL Server and Key Wizard Employee List from CSV";
            this.updateKeyWizardToolStripMenuItem.Click += new System.EventHandler(this.updateKeyWizardToolStripMenuItem_Click);
            // 
            // doTermedEmployeeKeySearchToolStripMenuItem
            // 
            this.doTermedEmployeeKeySearchToolStripMenuItem.Name = "doTermedEmployeeKeySearchToolStripMenuItem";
            this.doTermedEmployeeKeySearchToolStripMenuItem.Size = new System.Drawing.Size(472, 22);
            this.doTermedEmployeeKeySearchToolStripMenuItem.Text = "Do Termed \\ Transferred Employees Key Search ";
            this.doTermedEmployeeKeySearchToolStripMenuItem.Click += new System.EventHandler(this.doTermedEmployeeKeySearchToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(469, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(472, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btnDoTermedEmployeeKeyList
            // 
            this.btnDoTermedEmployeeKeyList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoTermedEmployeeKeyList.Location = new System.Drawing.Point(635, 531);
            this.btnDoTermedEmployeeKeyList.Name = "btnDoTermedEmployeeKeyList";
            this.btnDoTermedEmployeeKeyList.Size = new System.Drawing.Size(234, 23);
            this.btnDoTermedEmployeeKeyList.TabIndex = 3;
            this.btnDoTermedEmployeeKeyList.Text = "Display Termed/Transfer Employee Key List";
            this.btnDoTermedEmployeeKeyList.UseVisualStyleBackColor = true;
            this.btnDoTermedEmployeeKeyList.Click += new System.EventHandler(this.btnDoTermedEmployeeKeyList_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // btnKeysToFile
            // 
            this.btnKeysToFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKeysToFile.Location = new System.Drawing.Point(63, 502);
            this.btnKeysToFile.Name = "btnKeysToFile";
            this.btnKeysToFile.Size = new System.Drawing.Size(218, 23);
            this.btnKeysToFile.TabIndex = 4;
            this.btnKeysToFile.Text = "Write Termed\\Transferred Keys to File";
            this.btnKeysToFile.UseVisualStyleBackColor = true;
            this.btnKeysToFile.Click += new System.EventHandler(this.btnKeysToFile_Click);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            // 
            // backgroundWorker4
            // 
            this.backgroundWorker4.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker4_DoWork);
            // 
            // KWTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 557);
            this.Controls.Add(this.btnKeysToFile);
            this.Controls.Add(this.btnDoTermedEmployeeKeyList);
            this.Controls.Add(this.txtDisplay);
            this.Controls.Add(this.btnKeyWizUpdate);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KWTools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Key Wizard Tools";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KWTools_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKeyWizUpdate;
        private System.Windows.Forms.TextBox txtDisplay;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem updateKeyWizardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doTermedEmployeeKeySearchToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnDoTermedEmployeeKeyList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnKeysToFile;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.ComponentModel.BackgroundWorker backgroundWorker4;
    }
}

