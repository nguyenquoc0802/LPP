using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LPP.Connectives;
using LPP.Semantic_Tableaux;
using LPP.Predicate;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace LPP
{
    static class FunctionHelper
    {
        //evaluate formular
        public static bool EvaluateFormula(string proposition)
        {
            Regex pattern = new Regex("[@!]");
            return pattern.IsMatch(proposition);
        }

        //convert int to binary in string form
        public static string ConvertToBinary(int inputNo, int maxNo)
        {
            List<bool> temp = new List<bool>();
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
                if(tempList[tempList.Count - 1].GetRows()[i])
                {
                    lastLine += "1";
                }
                else
                {
                    lastLine += "0";
                }
            }
            return lastLine;
        }

        public static string ConvertBigBinaryToHex(List<MyCustomizeColumn> tempList)
        {
            string bigBinary = HashCodeHelper(tempList);
            string strHex = Convert.ToInt64(bigBinary, 2).ToString("X");
            return strHex;
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

        public static string ReverseString(string str1)
        {
            char[] stringChar = str1.ToArray();
            Array.Reverse(stringChar);
            return new string(stringChar);
        }

        public static int PriorityDeterminer(string c)
        {
            if(c == "~")
            {
                return 5;
            }
            else if(c == "&")
            {
                return 4;
            }
            else if(c == "|")
            {
                return 3;
            }
            else if(c == ">")
            {
                return 2;
            }
            else
            {
                return 1;
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

        public static string TrimInputPropositions(string inputProposition)
        {
            Regex pattern = new Regex("[,.()]");
            char[] result = pattern.Replace(inputProposition, string.Empty).Where(c => !char.IsWhiteSpace(c)).ToArray();
            return new string(result);
        }

        public static bool IsOperator(string c)
        {
            if(c == "&" || c == "|" || c == ">" || c == "=" || c == "~")
            {
                return true;
            }
            return false;
        }

        //preorder, help create content of for drawing the tree
        public static string DrawTreeHelper(Node root, ref string content)
        {
            if (root != null)
            {
                root.DrawGraphHelper(ref content);
                DrawTreeHelper(root.LeftNode, ref content);
                DrawTreeHelper(root.RightNode, ref content);
            }
            return content;
        }

        //set index for each node
        public static void SetIndexHelper(Node root, ref int index)
        {
            if (root != null)
            {
                root.Index = index;
                index++;
                SetIndexHelper(root.LeftNode, ref index);
                SetIndexHelper(root.RightNode, ref index);
            }
        }

        public static bool IsClosed(List<Node> _logicFormulas)
        {
            foreach (var f in _logicFormulas)
            {
                if(f is Variable v1)
                {
                    foreach (var f1 in _logicFormulas)
                    {
                        if (f1 is Negation n)
                        {
                            if(n.RightNode is Variable v2)
                            {
                                if(v1.ToString() == v2.ToString())
                                {
                                    if (CompareList(v1.GetVariables(), v2.GetVariables()))
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        public static bool CompareList(List<PredicateVariable> p1, List<PredicateVariable> p2)
        {
            if(p1.Count != p2.Count)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < p1.Count; i++)
                {
                    if (p1[i].ToString() != p2[i].ToString())
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }
    }
}
