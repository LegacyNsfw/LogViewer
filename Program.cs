using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LogViewer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                MessageBox.Show("Usage:" + Environment.NewLine + "LogViewer <filename.csv>");
                return;
            }

            string path = args[0];

            if (!File.Exists(path))
            {
                MessageBox.Show("File not found:" + Environment.NewLine + "'" + path + "'");
                return;
            }

            CsvFile file;
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    file = CsvParser.Parse(reader);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to parse file '" + path + "'" + Environment.NewLine + ex.Message);
                return;
            }
                        
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LogForm form = new LogForm(file);
            form.Text = "LogViewer: " + Path.GetFileName(path);
            form.ShowInTaskbar = true;
            Application.Run(form);
        }
    }
}
