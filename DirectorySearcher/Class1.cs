using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using Word = Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace LYHControl.DirectorySearcher
{
    
    public class DirectorySearcher : Control
    {
        private delegate void FileListDelegate(string sFilePath);

        private ListBox listBox;
        private string sKeyWord;
        private bool bSearching;
        private bool bDeferSearch;
        private int iFilesCount;
        private int iMatchFile;
        private Thread searchThread;
        private FileListDelegate fileListDelegate;
        private EventHandler onSearchComplete;
       
        public DirectorySearcher()
        {
            listBox = new ListBox();
            listBox.Dock = DockStyle.Fill;
            Controls.Add(listBox);

            fileListDelegate = new FileListDelegate(AddFiles);
            onSearchComplete = new EventHandler(OnSearchComplete);
            listBox.MouseDoubleClick += new MouseEventHandler(listBox_MouseDoubleClick);
        }       
        public bool IsSubDir { get; set; }
        public bool IsIgnoreCase { get; set; }
        public string FilePath { get; set; }
        public string SearchCriteria { get; set; }
        public string KeyWord
        {
            get
            {
                return sKeyWord;
            }
            set
            {
                bool wasSearching = Searching;
                    
                if (wasSearching)
                {
                    StopSearch();
                }

                listBox.Items.Clear();
                sKeyWord = value;

                if (wasSearching)
                {
                    BeginSearch();
                }
            }
        }
        public string LabelShow 
        {
            get 
            {
                return string.Format("相符的檔案: {0}  搜尋的檔案總數: {1}", iMatchFile, iFilesCount);
            } 
        
        }
        public bool Searching
        {
            get
            {
                return bSearching;
            }
        }

        public event EventHandler SearchComplete;

        private void AddFiles(string sFilePath) 
        {
            listBox.Items.Add(sFilePath);
        }

        public void BeginSearch()
        {
            // Create the search thread, which will begin the search. If already searching, do nothing.
            if (Searching) return;

            // Start the search if the handle has been created. Otherwise, defer it until the handle has been created.
            if (IsHandleCreated)
            {
                iFilesCount = 0;
                iMatchFile = 0;
                searchThread = new Thread(new ThreadStart(ThreadProcedure));
                bSearching = true;
                searchThread.Start();
            }
            else
            {
                bDeferSearch = true;
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {//如果handle被銷毀，但沒有重新創建它，會終止搜索
            if (!RecreatingHandle)
            {
                StopSearch();
            }
            base.OnHandleDestroyed(e);
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (bDeferSearch)
            {
                bDeferSearch = false;
                BeginSearch();
            }
        }

        /// <summary>
        /// This method is called by the background thread when it has finished the search.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSearchComplete(object sender, EventArgs e)
        {
            if (SearchComplete != null)
            {
                SearchComplete(sender, e);
            }
        }

        public void StopSearch()
        {
            if (!bSearching) return;

            if (searchThread.IsAlive)
            {
                searchThread.Abort();
                searchThread.Join();
            }

            searchThread = null;
            bSearching = false;
        }

        private void RecurseDirectory(string sSearchPath, string sSearchCriteria)
        {
            string[] ArrFile;
            // File systems like NTFS that have access permissions might result in exceptions when looking into directories without permission. Catch those exceptions and return.
            try
            {
                ArrFile = Directory.GetFiles(sSearchPath, sSearchCriteria);
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }
            catch (DirectoryNotFoundException)
            {
                return;
            }

            iFilesCount += ArrFile.Length;
            int count = 0;
            while (count < ArrFile.Length)
            {
                bool HasKeyWord = false;
                if (!sSearchCriteria.Contains("doc"))
                {
                    StreamReader reader = new StreamReader(ArrFile[count], Encoding.Default);
                    SerachKeyWord(reader.ReadToEnd(), ref HasKeyWord);
                }
                else
                {
                    Word.Application WordApp = new Word.Application();
                    Word.Document WordDoc = WordApp.Documents.Open(ArrFile[count], ReadOnly: true);
                   
                    for (int intA = 1; intA <= WordDoc.Paragraphs.Count; intA++)
                    {
                        string sContent = WordDoc.Paragraphs[intA].Range.Text;
                        SerachKeyWord(sContent, ref HasKeyWord);
                        if (HasKeyWord) break;
                    }

                    WordDoc.Close(false);
                    WordApp.Quit(false);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(WordDoc);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(WordApp);
                    WordDoc = null;
                    WordApp = null;
                }

                if (HasKeyWord)
                {
                    iMatchFile++;
                    IAsyncResult r = BeginInvoke(fileListDelegate, new object[] { ArrFile[count] });
                }
                count++;
            }

            if (IsSubDir)
            {
                string[] directories = Directory.GetDirectories(sSearchPath);
                foreach (string dir in directories)
                {
                    RecurseDirectory(dir, sSearchCriteria);
                }    
            }
        }
        private void SerachKeyWord(string sContect, ref bool HasKeyWord) 
        {
            int iTemp = 0;
            if (IsIgnoreCase)
            {
                iTemp = sContect.IndexOf(sKeyWord, StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                iTemp = sContect.IndexOf(sKeyWord);
            }

            if (iTemp >= 0) HasKeyWord = true;
        }
        
        private void ThreadProcedure()
        {
            string[] ArrSearchCriteria = SearchCriteria.Replace(" ", "").Split(',');
            foreach (string str in ArrSearchCriteria)
            {
                RecurseDirectory(FilePath, str);   
            }

            bSearching = false;
            BeginInvoke(onSearchComplete, new object[] { this, EventArgs.Empty });
        }

        private void listBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBox.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                string spath = listBox.Items[index].ToString();
                System.Diagnostics.Process.Start(@"C:\Windows\explorer.exe", @"/select, " + spath);
            }
        }
    }
}
