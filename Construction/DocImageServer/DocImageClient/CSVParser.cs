using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocImageClient
{
    class CSVParser
    {

        private OpenFileDialog ofd;


        public CSVParser(OpenFileDialog ofd)
        {
            this.ofd = ofd;
        }


        public List<string[]> ParseCsv()
        {
            // string[,]
            using (TextFieldParser parser = new TextFieldParser(ofd.FileName))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                List<string[]> resultList = new List<string[]>();
                parser.ReadLine();
                while (!parser.EndOfData)
                {
                    //Process row
                    resultList.Add(parser.ReadFields());
                }
                return resultList;
            }


        }


    }
}
