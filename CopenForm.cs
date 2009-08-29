using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;

namespace TTBox
{
    public partial class CopenForm : Form
    {
        public CopenForm()
        {
            InitializeComponent();

            if (!Clipboard.ContainsText())
                return;

            var emptyLinePattern = new Regex("^\\s*$");
            var angleBracketPattern = new Regex("<(.*)>");

            foreach (var line in Clipboard.GetText().Split('\n', '\r'))
            {
                if (emptyLinePattern.Match(line).Success)
                    continue;

                var m = angleBracketPattern.Match(line);
                var cmd = (m.Success) ? m.Groups[1].Value : line;

                Process.Start(cmd);
            }
            Environment.Exit(0);
        }
    }
}
