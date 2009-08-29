using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TTBox
{
    public partial class BKForm : Form
    {
        public BKForm()
        {
            InitializeComponent();

            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            backgroundWorker1.ProgressChanged += backgroungWorker1_ProgressChanged;

            var fnames = new List<string>();
            fnames.AddRange(Environment.GetCommandLineArgs());
            fnames.RemoveAt(0); // remove ttbox.exe.
            fnames.RemoveAt(0); // remove bk.

            backgroundWorker1.RunWorkerAsync(fnames);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var fnames = (List<string>)e.Argument;
            var worker = (BackgroundWorker)sender;
            var backup = new BackupWorker();

            foreach (var fname in fnames)
            {
                worker.ReportProgress(0, fname);
                backup.Execute(fname);
            }
        }
        
        private void backgroungWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var fname = (string)e.UserState;
            textBox1.Text += Path.GetFileName(fname) + "をバックアップしています...\r\n";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            textBox1.Text += "\r\nバックアップを終了しました。アプリケーションを終了します。\r\n";
            Update();
            System.Threading.Thread.Sleep(1000);
            Environment.Exit(0);
        }
    }
}
