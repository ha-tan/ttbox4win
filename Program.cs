using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TTBox
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var args = Environment.GetCommandLineArgs();

            if (args.Length < 2)
            {
                DispError();
                return;
            }

            switch (args[1])
            {
                case "bk":
                    Application.Run(new BKForm());
                    break;
                case "copen":
                    Application.Run(new CopenForm());
                    break;
                default:
                    DispError();
                    break;
            }
        }

        static void DispError()
        {
            MessageBox.Show("引数に実行する機能名を指定してください。\n  機能名: bk",
                "TTBox for Windows エラー",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
