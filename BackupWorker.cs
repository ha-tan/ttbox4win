using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace TTBox
{
    class BackupWorker
    {
        private string mPrefix;

        public BackupWorker()
        {
            mPrefix = DateTime.Now.ToString("yyyyMMdd");
        }

        public void Execute(string fname)
        {
            if (!File.Exists(fname))
                return;

            string src = Path.GetFullPath(fname);

            string bname = Path.GetFileName(src);
            string dname = Path.GetDirectoryName(src) + "\\old";
            
            if (!Directory.Exists(dname))
                Directory.CreateDirectory(dname);

            string dst = MakeDstPath(dname, bname, 0);
            for (int i = 1; File.Exists(dst); i++)
            {
                dst = MakeDstPath(dname, bname, i);
            }

            Debug.WriteLine(dst);
            File.Copy(src, dst);
        }

        private string MakeDstPath(string dname, string bname, int i)
        {
            string s = (i == 0) ? "_" : ("_" + i + "_");
            return dname + "\\" + mPrefix + s + bname;
        }
    }
}
