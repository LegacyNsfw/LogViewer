using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogViewer
{
    public class CsvFile
    {
        private ReadOnlyList<string> headers;
        private ReadOnlyList<ReadOnlyList<string>> rows;

        public ReadOnlyList<string> Headers { get { return this.headers; } }
        public ReadOnlyList<ReadOnlyList<string>> Rows { get { return this.rows; } }

        public CsvFile(ReadOnlyList<string> headers, ReadOnlyList<ReadOnlyList<string>> rows)
        {
            this.headers = headers;
            this.rows = rows;
        }
    }
}
