using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using LYHControl.DirectorySearcher;

namespace Project1
{
    /// 參考資料:https://docs.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-use-a-background-thread-to-search-for-files?view=netframeworkdesktop-4.8
    /// StreamReader.ReadToEnd() returning an empty string: https://stackoverflow.com/questions/2572963/streamreader-readtoend-returning-an-empty-string
    /// C#的字節與流: https://www.cnblogs.com/supersnowyao/p/8327727.html
    /// 一文搞懂IO流: https://segmentfault.com/a/1190000023565967
    public partial class Form1 : Form
    {
        string FormText = "";
        public Form1()
        {
            InitializeComponent();
            FormText = this.Text;
            this.btnSearch.NotifyDefault(true);
            this.Activated += new EventHandler(Form1_Activated);
            this.directorySearcher.SearchComplete += new EventHandler(directorySearcher_SearchComplete);
            this.btnSearch.Click += new EventHandler(Button_Click);
            this.chkIgnoreCase.Checked = true;
            this.txtSearchCriteria.Text = @"*.txt";
            this.txtPath.Text = @"D:\Users\yhlin\Desktop\";
            //this.txtSearchCriteria.Text = @"*.doc";
            //this.txtPath.Text = @"D:\Users\yhlin\Desktop\國外部\國外部套表\word\Qualcomm\";
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            this.btnSearch.Focus();
        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            if (sender.Equals(this.btnSearch))
            {
                if (!Directory.Exists(this.txtPath.Text.Trim()))
                {
                    MessageBox.Show("路徑不存在", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.txtPath.Focus();
                    return;
                }
                if (this.txtSearchCriteria.Text.Trim() == "")
                {
                    MessageBox.Show("請輸入附檔名", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.txtSearchCriteria.Focus();
                    return;
                }
                directorySearcher.IsSubDir = this.chkSubDir.Checked;
                directorySearcher.IsIgnoreCase = this.chkIgnoreCase.Checked;
                directorySearcher.FilePath = this.txtPath.Text.Trim();
                directorySearcher.SearchCriteria = this.txtSearchCriteria.Text.Trim();
                directorySearcher.KeyWord = this.txtKeyWord.Text.Trim();

                this.Text = FormText + "(Searching...)";
                this.Cursor = Cursors.AppStarting;
                directorySearcher.BeginSearch();
            }
        }

        private void directorySearcher_SearchComplete(object sender, System.EventArgs e)
        {
            this.Text = FormText;
            this.Cursor = Cursors.Default;
            this.groupBox1.Text = "尋找結果 (" + directorySearcher.LabelShow + ")";
        }
    }
}
