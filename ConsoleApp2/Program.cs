using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //var M = "101111001110"; // 1000

            //var M = "101111001111"; //1001

            //var M = "111111001111"; //1110

            string pathToFile = @"E:\Documents\GitHub\Information-Security\TextFile1.txt";

            var G = "10011";

            string input = "";

            using (StreamReader reader = new StreamReader(pathToFile))
            {
                input = reader.ReadToEnd();
            }

            Console.WriteLine(input);

            //string tempStr = InputStr(input);

            //Console.WriteLine(tempStr);

            //Console.WriteLine();

            ////Console.WriteLine(CRC(tempStr, G));

            //Console.WriteLine();
            //Dictionary<string, string> transition = DictInitial();

            //var result = CRC(tempStr, G);

            //Console.WriteLine(result.Length);

            //var temp = new StringBuilder(result);

            //while (temp.Length % 4 != 0)
            //{
            //    temp.Insert(0, "0");
            //}

            //Console.WriteLine(temp);

            //string result2 = "";

            //string temp2 = temp.ToString();

            //for (int i = 0; i < temp2.Length; i += 4)
            //{
            //    result2 += transition[temp2.Substring(i, 4)];
            //}

            //Console.WriteLine(result2);

            //Console.WriteLine("!!!!!!!!!!!!!");

            //Console.WriteLine(CRC(tempStr, G));

            #region Версия взята из интернета
            //byte[] source = { 1};

            //UInt32[] crc_table = new UInt32[256];
            //UInt32 crc;

            //for (UInt32 i = 0; i < 256; i++)
            //{
            //    crc = i;
            //    for (UInt32 j = 0; j < 8; j++)
            //        crc = (crc & 1) != 0 ? (crc >> 1) ^ 0xEDB88320 : crc >> 1;

            //    crc_table[i] = crc;
            //};

            //crc = 0xFFFFFFFF;

            //foreach (byte s in source)
            //{
            //    crc = crc_table[(crc ^ s) & 0xFF] ^ (crc >> 8);
            //}

            //crc ^= 0xFFFFFFFF;

            //Console.WriteLine(crc);
            #endregion

            Console.ReadKey();
        }

        private static string InputStr(string str)
        {
            string tempStr = "";

            var a = str.ToCharArray().Select(i => Convert.ToString(i, 2));
            foreach (var ch in a)
            {
                tempStr += ch;
            }

            return tempStr;
        }

        private static Dictionary<string, string> DictInitial()
        {
            Dictionary<string, string> transition = new Dictionary<string, string>();

            transition.Add("0000", "0");
            transition.Add("0001", "1");
            transition.Add("0010", "2");
            transition.Add("0011", "3");
            transition.Add("0100", "4");
            transition.Add("0101", "5");
            transition.Add("0110", "6");
            transition.Add("0111", "7");
            transition.Add("1000", "8");
            transition.Add("1001", "9");
            transition.Add("1010", "a");
            transition.Add("1011", "b");
            transition.Add("1100", "c");
            transition.Add("1101", "d");
            transition.Add("1110", "e");
            transition.Add("1111", "f");
            return transition;
        }

        private static string CRC(string M, string G)
        {

            BitArray bitArrayM = InBitArray(M);

            BitArray bitArrayG = InBitArray(G);

            while (bitArrayM.Length >= bitArrayG.Length)
            {

                var bitArrayTemp = new BitArray(bitArrayG.Length);

                for (int i = 0; i < bitArrayTemp.Length; i++)
                {
                    bitArrayTemp[i] = bitArrayM[i] ^ bitArrayG[i];
                }

                var newBitArrayTemp = new BitArray(bitArrayTemp.Length - IndexForNewArray(bitArrayTemp));

                for (int i = IndexForNewArray(bitArrayTemp), j = 0; i < bitArrayTemp.Length; i++, j++)
                {
                    newBitArrayTemp[j] = bitArrayTemp[i];
                }

                var bitArrayMTemp = new BitArray(bitArrayM.Length - bitArrayG.Length + newBitArrayTemp.Length);

                for (int i = 0; i < newBitArrayTemp.Length; i++)
                {
                    bitArrayMTemp[i] = newBitArrayTemp[i];
                }

                for (int i = bitArrayG.Length, j = newBitArrayTemp.Length; i < bitArrayM.Length; i++, j++)
                {
                    bitArrayMTemp[j] = bitArrayM[i];
                }

                bitArrayM = new BitArray(bitArrayMTemp);
            }

            string temp = InString(bitArrayM);

            foreach (var item in temp)
            {
                M += item;
            }

            return M;
        }

        private static BitArray InBitArray(string M)
        {
            BitArray bitArrayM = new BitArray(M.Length);

            for (int i = 0; i < bitArrayM.Length; i++)
            {
                if (M[i] == '1')
                {
                    bitArrayM[i] = true;
                }
                if (M[i] == '0')
                {
                    bitArrayM[i] = false;
                }
            }

            return bitArrayM;
        }

        private static string InString(BitArray bitArrayM)
        {
            string temp = "";

            foreach (var item in bitArrayM)
            {
                if ((bool)item == true)
                {
                    temp += "1";
                }
                if ((bool)item == false)
                {
                    temp += "0";
                }
            }

            return temp;
        }

        private static int IndexForNewArray(BitArray bitArrayTemp)
        {
            for (int i = 0; i < bitArrayTemp.Length; i++)
            {
                if (bitArrayTemp[i] == true)
                {
                    return i;
                }
            }

            return bitArrayTemp.Length;
        }

    }
}
