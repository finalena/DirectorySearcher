namespace Project1
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtSearchCriteria = new System.Windows.Forms.TextBox();
            this.chkSubDir = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKeyWord = new System.Windows.Forms.TextBox();
            this.chkIgnoreCase = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.directorySearcher = new LYHControl.DirectorySearcher.DirectorySearcher();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(483, 76);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(83, 22);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(376, 22);
            this.txtPath.TabIndex = 1;
            // 
            // txtSearchCriteria
            // 
            this.txtSearchCriteria.Location = new System.Drawing.Point(83, 50);
            this.txtSearchCriteria.Name = "txtSearchCriteria";
            this.txtSearchCriteria.Size = new System.Drawing.Size(376, 22);
            this.txtSearchCriteria.TabIndex = 2;
            // 
            // chkSubDir
            // 
            this.chkSubDir.AutoSize = true;
            this.chkSubDir.Location = new System.Drawing.Point(483, 28);
            this.chkSubDir.Name = "chkSubDir";
            this.chkSubDir.Size = new System.Drawing.Size(102, 16);
            this.chkSubDir.TabIndex = 5;
            this.chkSubDir.Text = "SubDirectory(&D)";
            this.chkSubDir.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "KeyWord";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "FileExtension";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "Path";
            // 
            // txtKeyWord
            // 
            this.txtKeyWord.Location = new System.Drawing.Point(83, 77);
            this.txtKeyWord.Name = "txtKeyWord";
            this.txtKeyWord.Size = new System.Drawing.Size(376, 22);
            this.txtKeyWord.TabIndex = 3;
            // 
            // chkIgnoreCase
            // 
            this.chkIgnoreCase.AutoSize = true;
            this.chkIgnoreCase.Location = new System.Drawing.Point(483, 52);
            this.chkIgnoreCase.Name = "chkIgnoreCase";
            this.chkIgnoreCase.Size = new System.Drawing.Size(93, 16);
            this.chkIgnoreCase.TabIndex = 6;
            this.chkIgnoreCase.Text = "IgnoreCase(&C)";
            this.chkIgnoreCase.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.directorySearcher);
            this.groupBox1.Location = new System.Drawing.Point(12, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 279);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Result";
            // 
            // directorySearcher
            // 
            this.directorySearcher.FilePath = null;
            this.directorySearcher.IsIgnoreCase = false;
            this.directorySearcher.IsSubDir = false;
            this.directorySearcher.KeyWord = null;
            this.directorySearcher.Location = new System.Drawing.Point(6, 16);
            this.directorySearcher.Name = "directorySearcher";
            this.directorySearcher.SearchCriteria = null;
            this.directorySearcher.Size = new System.Drawing.Size(559, 256);
            this.directorySearcher.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 404);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkIgnoreCase);
            this.Controls.Add(this.txtKeyWord);
            this.Controls.Add(this.chkSubDir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearchCriteria);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File-KeyWord-Search";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtPath;
        private LYHControl.DirectorySearcher.DirectorySearcher directorySearcher;
        private System.Windows.Forms.TextBox txtSearchCriteria;
        private System.Windows.Forms.CheckBox chkSubDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKeyWord;
        private System.Windows.Forms.CheckBox chkIgnoreCase;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

