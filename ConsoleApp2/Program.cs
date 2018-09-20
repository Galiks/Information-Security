using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var M = "101111001110"; // 1000

            //var M = "101111001111"; //1001

            //var M = "111111001111"; //1110

            var G = "10011";

            //создание массивов

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

            BitArray bitArrayG = new BitArray(G.Length);

            for (int i = 0; i < bitArrayG.Length; i++)
            {
                if (G[i] == '1')
                {
                    bitArrayG[i] = true;
                }
                if (G[i] == '0')
                {
                    bitArrayG[i] = false;
                }
            }

            bitArrayM = NewMethod(bitArrayM, bitArrayG);

            foreach (var item in bitArrayM)
            {
                Console.WriteLine(item);
            }

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

        private static BitArray NewMethod(BitArray bitArrayM, BitArray bitArrayG)
        {
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

            return bitArrayM;
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
