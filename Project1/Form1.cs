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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.directorySearcher.SearchComplete += new EventHandler(directorySearcher_SearchComplete);
            this.btnSearch.Click += new EventHandler(Button_Click);
            this.chkIgnoreCase.Checked = true;
            this.txtSearchCriteria.Text = @"*.doc";
            this.txtPath.Text = @"D:\Users\yhlin\Desktop\國外部\國外部套表\word\SubFile";

            this.AcceptButton = this.btnSearch;
        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            if (sender.Equals(this.btnSearch))
            {
                if (!Directory.Exists(this.txtPath.Text.Trim()))
                {
                    MessageBox.Show("The file path does not exist.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.txtPath.Focus();
                    return;
                }
                if (this.txtSearchCriteria.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter the file extension.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.txtSearchCriteria.Focus();
                    return;
                }
                directorySearcher.IsSubDir = this.chkSubDir.Checked;
                directorySearcher.IsIgnoreCase = this.chkIgnoreCase.Checked;
                directorySearcher.FilePath = this.txtPath.Text.Trim();
                directorySearcher.SearchCriteria = this.txtSearchCriteria.Text.Trim();
                directorySearcher.KeyWord = this.txtKeyWord.Text.Trim();

                this.groupBox1.Text = "Result (Searching...)";
                this.Cursor = Cursors.AppStarting;
                directorySearcher.BeginSearch();
            }
        }

        private void directorySearcher_SearchComplete(object sender, System.EventArgs e)
        {
            this.groupBox1.Text = "Result (" + directorySearcher.LabelShow + ")";
            this.Cursor = Cursors.Default;
        }
    }
}
