using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace LPP
{
    static class FunctionHelper
    {
        //convert int to binary in string form
        public static string ConvertToBinary(int inputNo, int maxNo)
        {
            char[] binaryNo = new char[maxNo];
            string convertBinary = Convert.ToString(inputNo, 2);
            int index = convertBinary.Length - 1;
            for (int i = maxNo - 1; i >= 0; i--)
            {
                if (index >= 0)
                {
                    binaryNo[i] = convertBinary[index];
                    index--;
                }
                else
                {
                    binaryNo[i] = '0';

                }
            }
            return new string(binaryNo);
        }

        private static string HashCodeHelper(List<MyCustomizeColumn> tempList)
        {
            string lastLine = "";
            for (int i = tempList[0].GetRows().Count - 1; i >= 0; i--)
            {
                lastLine += tempList[tempList.Count - 1].GetRows()[i];
            }
            return lastLine;
        }

        public static string ConvertBigBinaryToHex(List<MyCustomizeColumn> tempList)
        {
            string bigBinary = HashCodeHelper(tempList);

            string output = "";

            for (int i = 0; i <= bigBinary.Length - 4; i += 4)
            {  
                output += Convert.ToInt32(bigBinary.Substring(i, 4), 2).ToString("X");
            }
            return output;
        }

        //compare two binary and produce new binary with * as a bit if necessary
        public static string CompareString(string first, string second)
        {
            StringBuilder result = new StringBuilder(first);
            int count = 0;
            int index = -1;
            //compare for to find number of different bit
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                {
                    count++;
                    index = i;
                }
            }
            //if count = 1, then there is one different bit -> return new binary by replacing the different bit with *
            if (count == 1)
            {
                result[index] = '*';
                return result.ToString();
            }
            else
            {
                return "";
            }
        }

        public static int CountOne(string str1)
        {
            int no1 = str1.Replace("0", "").Replace("*", "").Length;
            return no1;
        }

        public static int CountZero(string str1)
        {
            int no0 = str1.Replace("1", "").Replace("*", "").Length;
            return no0;
        }

        
    }
}
