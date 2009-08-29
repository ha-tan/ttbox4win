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
    public partial class PathLinkForm : Form
    {
        public PathLinkForm()
        {
            InitializeComponent();

            this.DragEnter += form1_DragEnter;
            this.DragDrop += form1_DragDrop;
        }

        public void form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        public void form1_DragDrop(object sender, DragEventArgs e)
        {
            var fnames = (string[])e.Data.GetData(DataFormats.FileDrop);
            Array.Sort(fnames);

            foreach (var fname in fnames)
            {
                var bname = Path.GetFileName(fname);

                if (textBox1.Text.Length > 0)
                    textBox1.Text += "\r\n";

                textBox1.Text += "○ " + bname + "\r\n";
                textBox1.Text += "<" + fname + ">\r\n";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text;

            if (text.Length > 0)
                Clipboard.SetText(text);

            Environment.Exit(0);
        }
    }
}
