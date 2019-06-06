using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;
using System.Runtime.InteropServices;
using LPP.Predicate;
using LPP.Connectives;

namespace LPP
{
    class TruthTable
    {
        private Node _root;

        public TruthTable(Node root)
        {
            this._root = root;
        }

        public List<Predicate.PredicateVariable> GetUniqueFormulaList()
        {
            List<Predicate.PredicateVariable> temp = new List<Predicate.PredicateVariable>();
            this.PopulateListOfFormula(this._root, ref temp);
            // third party library, will try to do by myself
            List<Predicate.PredicateVariable> uniqueList = temp.DistinctBy(v => v.ToString()).ToList();
            return uniqueList;
        }
        
        private List<Predicate.PredicateVariable> GetFormulaList()
        {
            List<Predicate.PredicateVariable> temp = new List<Predicate.PredicateVariable>();
            this.PopulateListOfFormula(this._root, ref temp);
            return temp;
        }

        //using post order to calculate
        private void CalculateLogicExpressionHelper(Node root, ref bool result)
        {
            if (root != null)
            {
                this.CalculateLogicExpressionHelper(root.LeftNode, ref result);
                this.CalculateLogicExpressionHelper(root.RightNode, ref result);
                result = root.CalculateResult();
            }
        }

        //populate list of varible including the same variable
        private void PopulateListOfFormula(Node root, ref List<Predicate.PredicateVariable> variableList)
        {
            //tranverse through the tree using pre-order
            if (root != null)
            {
                if (root is Predicate.PredicateVariable v)
                {
                    variableList.Add(v);
                }
                this.PopulateListOfFormula(root.LeftNode, ref variableList);
                this.PopulateListOfFormula(root.RightNode, ref variableList);
            }
        }

        //create Table in true false form
        private List<MyCustomizeColumn> CreateTable()
        {
            List<MyCustomizeColumn> myTable = new List<MyCustomizeColumn>();
            List<Predicate.PredicateVariable> temp = this.GetUniqueFormulaList();
            List<Predicate.PredicateVariable> tempAllVariable = this.GetFormulaList();
            int totalVarible = temp.Count;
            int rows = Convert.ToInt32(Math.Pow(2, totalVarible));
            bool result = false;
            //populate column
            foreach(var v in temp)
            {
                 myTable.Add(new MyCustomizeColumn(v.ToString()));
            }
            myTable.Add(new MyCustomizeColumn(this._root.ToString()));
            //sort alphabetically
            myTable.Sort();
            this.MyCustomizeSort(myTable);
            for (int i = 0; i < rows; i++)
            {
                string neededValue = FunctionHelper.ConvertToBinary(i, totalVarible);
                for(int j = 0; j < myTable.Count; j++)
                {
                    if(j == myTable.Count - 1)
                    {
                        this.CalculateLogicExpressionHelper(this._root, ref result);
                        myTable[j].AddRow(result);
                        break;
                    }
                    myTable[j].AddRow(neededValue[j].ToString() != "0");
                    foreach(var v in tempAllVariable)
                    {
                        if(myTable[j].GetName() == v.ToString())
                        {
                            v.TruthValue = neededValue[j].ToString() != "0";
                        }
                    }
                }
            }
            return myTable;
        }

        //swap
        private void MyCustomizeSort(List<MyCustomizeColumn> l)
        {
            for(int i = 0; i < l.Count - 1; i++)
            {
                MyCustomizeColumn temp = l[i];
                l[i] = l[i + 1];
                l[i + 1] = temp;
            }
        }

        //get truth table
        public string GetTableInString()
        {
            List<MyCustomizeColumn> tempColumnList = this.CreateTable();
            string display = "";
            for(int i = -1; i < tempColumnList[0].GetRows().Count; i++)
            {
                foreach (var c in tempColumnList)
                {
                    if(i == -1)
                    {
                        if(c.GetName().Length > 10)
                        {
                            display += "*\t";
                        }
                        else
                        {
                            display += c.GetName() + "\t";
                        }
                    }
                    else
                    {
                        if (c.GetRows()[i])
                        {
                            display += "1\t";
                        }
                        else
                        {
                            display += "0\t";
                        }
                    }
                }
                display += "\r\n";
            }
            return display;
        }

        //convert binary to hexadecimal number
        public string GetTruthTableHashCode()
        {
            return FunctionHelper.ConvertBigBinaryToHex(this.CreateTable());
        }

        //get different with 1 and 0
        private void GetRowWithOutput(ref List<string> trueOutputList, ref List<string> falseOutputList)
        {
            trueOutputList = new List<string>();
            falseOutputList = new List<string>();
            List<MyCustomizeColumn> tempColumnList = this.CreateTable();
            //index last column
            int indexLastColumn = tempColumnList.Count - 1;
            for (int i = 0; i < tempColumnList[indexLastColumn].GetRows().Count; i++)
            {
                if (tempColumnList[indexLastColumn].GetRows()[i])
                {
                    string rows = "";
                    for (int j = 0; j < indexLastColumn; j++)
                    {
                        if(tempColumnList[j].GetRows()[i])
                        {
                            rows += "1";
                        }
                        else
                        {
                            rows += "0";
                        }
                    }
                    trueOutputList.Add(rows);
                }
                else
                {
                    string rows = "";
                    for (int j = 0; j < indexLastColumn; j++)
                    {
                        if (!tempColumnList[j].GetRows()[i])
                        {
                            rows += "0";
                        }
                        else
                        {
                            rows += "1";
                        }
                    }
                    falseOutputList.Add(rows);
                }
            }
        }

        //true false value
        private void GetRowWithOutput(ref List<MyCustomizeColumn> trueOutputList)
        {
            List<MyCustomizeColumn> tempColumnList = this.CreateTable();
            //clear all data but have the same structure
            trueOutputList = this.CreateTable();
            foreach(var c in trueOutputList)
            {
                c.ClearRow();
            }
            //index last column
            int indexLastColumn = tempColumnList.Count - 1;
            for (int i = 0; i < tempColumnList[indexLastColumn].GetRows().Count; i++)
            {
                if(tempColumnList[indexLastColumn].GetRows()[i])
                {
                    for (int j = 0; j < indexLastColumn; j++)
                    {
                        trueOutputList[j].AddRow(tempColumnList[j].GetRows()[i]);
                    }
                }
            }
        }

        //mizimize output helper
        private List<string> MinimizOutputHelper(List<string> inputList)
        {
            for (int i = 1; ; i++)
            {
                //avoid collection modified
                bool checkSimplified = false;
                List<string> nextList = new List<string>();
                //true output
                foreach (string str1 in new List<string>(inputList))
                {
                    foreach (string str2 in new List<string>(inputList))
                    {
                        if (FunctionHelper.CompareString(str1, str2) != "")
                        {
                            nextList.Add(FunctionHelper.CompareString(str1, str2));
                            checkSimplified = true;
                        }
                    }
                    if (checkSimplified == false)
                    {
                        nextList.Add(str1);
                    }
                    else
                    {
                        checkSimplified = false;
                    }
                }
                if (nextList.Count > 0)
                {
                    if((nextList.Count == inputList.Count) && nextList.SequenceEqual(inputList))
                    {
                        return nextList.Distinct().ToList();
                    }
                    else
                    {
                        inputList = nextList.Distinct().ToList();
                        nextList.Clear();
                    }
                }
            }
        }

        //generate the minimize table
        private List<MyCustomizeColumn> MinimizeHelper()
        {
            List<string> trueOutputList = new List<string>();
            List<string> falseOutputList = new List<string>();
            //get the structure of the table and clear data
            List<MyCustomizeColumn> temp = this.CreateTable();
            foreach(var c in temp)
            {
                c.ClearRow();
            }
            //get row with same output
            this.GetRowWithOutput(ref trueOutputList, ref falseOutputList);
            if(falseOutputList.Count > 0)
            {
                falseOutputList = this.MinimizOutputHelper(falseOutputList);
                //add to temp list
                foreach (string str1 in falseOutputList)
                {
                    for (int i = 0; i < str1.Length; i++)
                    {
                        temp[i].AddStringRow(str1[i].ToString());
                    }
                    temp[temp.Count - 1].AddStringRow("0");
                }
            }
            if (trueOutputList.Count > 0)
            {
                trueOutputList = this.MinimizOutputHelper(trueOutputList);
                //add to temp list
                foreach (string str1 in trueOutputList)
                {
                    for (int i = 0; i < str1.Length; i++)
                    {
                        temp[i].AddStringRow(str1[i].ToString());
                    }
                    temp[temp.Count - 1].AddStringRow("1");
                }
            }
            return temp;
        }

        //print
        public string MinimizeTruthTable()
        {
            string display = "";
            List<MyCustomizeColumn> temp = this.MinimizeHelper();
            //column name
            for(int i = -1; i < temp[0].GetStringRows().Count; i++)
            {
                foreach (var c in temp)
                {
                    if (i == -1)
                    {
                        if(c.GetName().Length > 10)
                        {
                            display += "*\t";
                        }
                        else
                        {
                            display += c.GetName() + "\t";
                        }
                    }
                    else
                    {
                        display += c.GetStringRows()[i] + "\t";
                    }
                }
                display += "\r\n";
            }
            return display;
        }

        //print disjunctive normal form
        public string DisjunctiveNormalForm()
        {
            string resultInfix = "";
            List<MyCustomizeColumn> truthList = new List<MyCustomizeColumn>();
            this.GetRowWithOutput(ref truthList);
            for(int i = 0; i < truthList[0].GetRows().Count; i++)
            {
                resultInfix += "(";
                //omit the last column(logic expression)
                for (int j = 0; j < truthList.Count - 1; j++)
                {
                    bool value = truthList[j].GetRows()[i];
                    if (value)
                    {
                        resultInfix += truthList[j].GetName();
                    }
                    else
                    {
                        resultInfix += "~" + truthList[j].GetName();
                    }
                    if (j != truthList.Count - 2)
                    {
                        resultInfix += " & ";
                    }
                }
                if(i == truthList[0].GetRows().Count - 1)
                {
                    resultInfix += ")";
                }
                else
                {
                    resultInfix += ") | ";
                }
            }
            return resultInfix;
        }

        //print disjunctive helper()
        private void SimplifiedTableDisjunctiveFormHelper(ref List<MyCustomizeColumn> trueOutputList)
        {
            List<MyCustomizeColumn> temp = this.MinimizeHelper();
            trueOutputList = this.CreateTable();
            foreach(var c in trueOutputList)
            {
                c.ClearRow();
            }
            //list with output 1
            for(int i = 0; i < temp[0].GetStringRows().Count; i++)
            {
                if(temp[temp.Count - 1].GetStringRows()[i] == "1")
                {
                    for(int j = 0; j < temp.Count - 1; j++)
                    {
                        string s = temp[j].GetStringRows()[i];
                        trueOutputList[j].AddStringRow(s);
                    }
                }
            }
        }

        //print disjunctive normal form of simplified truth table
        public string SimplifiedTableDisjunctiveForm()
        {
            string result = "";
            List<MyCustomizeColumn> temp = new List<MyCustomizeColumn>();
            this.SimplifiedTableDisjunctiveFormHelper(ref temp);
            List<string> row = new List<string>();
            for (int i = 0; i < temp[0].GetStringRows().Count; i++)
            {
                result += "(";
                //omit the last column(logic expression)
                for (int j = 0; j < temp.Count - 1; j++)
                {
                    //add row depend on 1 or 0
                    if (temp[j].GetStringRows()[i] == "1")
                    {
                        row.Add(temp[j].GetName());
                    }
                    else if (temp[j].GetStringRows()[i] == "0")
                    {
                        row.Add("~" + temp[j].GetName());
                    }
                }
                //display row
                for(int value = 0; value < row.Count; value++)
                {
                    if(value == row.Count - 1)
                    {
                        result += row[value];
                    }
                    else
                    {
                        result += row[value] + " & ";
                    }
                }
                row.Clear();
                if (i == temp[0].GetStringRows().Count - 1)
                {
                    result += ")";
                }
                else
                {
                    result += ") | ";
                }
            }


            return result;
        }

        
    }
} 
