using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogViewer
{
    class CsvParser
    {
        private TextReader reader;
        private CsvFile file;
        
        public static CsvFile Parse(TextReader reader)
        {
            CsvParser parser = new CsvParser(reader);
            parser.Parse();
            return parser.file;
        }

        private CsvParser(TextReader reader)
        {
            this.reader = reader;
        }

        private void Parse()
        {
            string headerString = this.reader.ReadLine();
            string[] headers = headerString.Split(',');

            string rowString;
            List<ReadOnlyList<string>> rows = new List<ReadOnlyList<string>>();

            while ((rowString = this.reader.ReadLine()) != null)
            {
                string[] rowValues = rowString.Split(',');
                ReadOnlyList<string> row = new ReadOnlyList<string>(rowValues);
                rows.Add(row);
            }

            ReadOnlyList<string> readOnlyHeaders = new ReadOnlyList<string>(headers);
            ReadOnlyList<ReadOnlyList<string>> readOnlyRows = new ReadOnlyList<ReadOnlyList<string>>(rows);
            this.file = new CsvFile(readOnlyHeaders, readOnlyRows);
        }
    }
}
