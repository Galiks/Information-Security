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
                { "137 80 78 71 13 10 26 10", "PNG"},
                { "MSWordDoc", "DOC"},
            };

            List<string> files = new List<string>()
            {
                @"E:\Загрузки\CхемаБазы.jpg",
                @"E:\Загрузки\schedule_do_441.xls",
                @"E:\Загрузки\Задание.docx",
                @"E:\Загрузки\qwerty.xlsx",
                @"E:\Загрузки\Текст для КНиИт.doc",
            };


            //foreach (var filePath in files)
            //{
            //    if (end == true)
            //    {
            //        break;
            //    }
            //    using (StreamReader streamReader = new StreamReader(filePath))
            //    {
            //        string line = streamReader.ReadToEnd();

            //        //Console.WriteLine(line);

            //        foreach (var item in signature)
            //        {
            //            if (line.Contains(item.Key))
            //            {
            //                Console.WriteLine(item.Value);
            //                end = true;
            //            }
            //        }
            //    }

                //137 80 78 71 13 10 26 10

                byte[] result = null;
                using (FileStream fileStream = File.OpenRead(@"E:\Загрузки\CхемаБазы.jpg"))
                {
                    using (BinaryReader binaryReader = new BinaryReader(fileStream))
                    {
                        result = binaryReader.ReadBytes(16);

                        foreach (var item in signature)
                        {
                            if (item.ToString().Contains(item.Key))
                            {
                                Console.WriteLine(item.Value);
                                end = true;
                            }
                        }
                    }
                }
            //}

            Console.Read();
        }
    }
}
