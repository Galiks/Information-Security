using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signature
{
    class Program
    {
        static void Main(string[] args)
        {
            bool end = false;

            Dictionary<string, string> signature = new Dictionary<string, string>()
            {
                { @"word/document", "DOCX" },
                { @"Excel.Sheet" , "XLS"},
                { @"workbook.xml", "XLSX"},
                { "13780787113102610", "PNG"}, //137 80 78 71 13 10 26 10
                { "MSWordDoc", "DOC"},
            };

            List<string> files = new List<string>()
            {
                @"E:\Загрузки\CхемаБазы.jpg",
                @"E:\Загрузки\Dogovor.docx",
                @"E:\Загрузки\schedule_do_441.xls",
                @"E:\Загрузки\xlsx.docx",
            };


            foreach (var filePath in files)
            {
                end = false;

                using (StreamReader streamReader = new StreamReader(filePath))
                {
                    string line = streamReader.ReadToEnd();

                    //Console.WriteLine(line);

                    foreach (var item in signature)
                    {
                        if (line.Contains(item.Key))
                        {
                            Console.WriteLine(item.Value);
                            end = true;
                        }
                    }
                }

                //137 80 78 71 13 10 26 10

                if (!end)
                {
                    byte[] result = null;
                    using (FileStream fileStream = File.OpenRead(filePath))
                    {
                        using (BinaryReader binaryReader = new BinaryReader(fileStream))
                        {
                            result = binaryReader.ReadBytes(16);

                            string sign = "";

                            foreach (var item in result)
                            {
                                sign += item.ToString();
                            }

                            //Console.WriteLine(sign);

                            foreach (var item in signature)
                            {
                                if (sign.Contains(item.Key))
                                {
                                    Console.WriteLine(item.Value);
                                    continue;
                                }
                            }
                        }
                    }
                }
            }

            Console.Read();
        }
    }
}
