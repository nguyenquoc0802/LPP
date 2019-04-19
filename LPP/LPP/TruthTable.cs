using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;

namespace LPP
{
    class TruthTable
    {
        private Node _root;
        private List<MyCustomizeColumn> _columnList;

        public TruthTable(Node root)
        {
            this._root = root;
            this._columnList = new List<MyCustomizeColumn>();
        }

        public List<Variable> GetUniqueVariableList()
        {
            List<Variable> temp = new List<Variable>();
            this.PopulateListOfVariable(this._root, ref temp);
            // third party library, will try to do by myself
            List<Variable> uniqueList = temp.DistinctBy(v => v.ToString()).ToList();
            return uniqueList;
        }
        
        private List<Variable> GetVariableList()
        {
            List<Variable> temp = new List<Variable>();
            this.PopulateListOfVariable(this._root, ref temp);
            return temp;
        }

        // convert to binary
        private string ConvertToBinary(int inputNo, int maxNo)
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
        private void PopulateListOfVariable(Node root, ref List<Variable> variableList)
        {
            //tranverse through the tree using pre-order
            if (root != null)
            {
                if (root is Variable v)
                {
                    variableList.Add(v);
                }
                this.PopulateListOfVariable(root.LeftNode, ref variableList);
                this.PopulateListOfVariable(root.RightNode, ref variableList);
            }
        }

        // get matrix 
        public string[,] GetTruthTableMatrix()
        {
            List<Variable> temp = this.GetUniqueVariableList();
            // all node in case of matching node and in the order from left to right
            List<Variable> allNode = this.GetVariableList();
            int totalVariable = temp.Count;
            bool result = false;
            // create matrix with row = 2 ^ n, and column = n + 1(n = totalVariable)
            int rows = Convert.ToInt32(Math.Pow(2, totalVariable));
            string[,] matrix = new string[rows, totalVariable + 1];
            for (int i = 0; i < rows; i++)
            {
                string needValue = this.ConvertToBinary(i, temp.Count);
                for (int j = 0; j < totalVariable; j++)
                {
                    matrix[i, j] = needValue[j].ToString();
                    // check if there is any matching node and set truth value to them
                    foreach (var c in allNode)
                    {
                        if (c.ToString() == temp[j].ToString())
                        {
                            if (needValue[j].ToString() == "0")
                            {
                                c.TruthValue = false;
                            }
                            else
                            {
                                c.TruthValue = true;
                            }
                        }
                    }
                }
                this.CalculateLogicExpressionHelper(this._root, ref result);
                if (result == false)
                {
                    matrix[i, matrix.GetLength(1) - 1] = "0";
                }
                else
                {
                    matrix[i, matrix.GetLength(1) - 1] = "1";
                }
            }
            return matrix;
        }

        private void PopulateColumn()
        {
            string[,] matrix = this.GetTruthTableMatrix();
            List<Variable> temp = this.GetUniqueVariableList();
            foreach(var v in temp)
            {
                MyCustomizeColumn newColumnVariable = new MyCustomizeColumn(v.ToString());
                this._columnList.Add(newColumnVariable);
            }
            //add proposition
            MyCustomizeColumn newColumn = new MyCustomizeColumn(this._root.ToString());
            this._columnList.Add(newColumn);
            for(int column = 0; column < matrix.GetLength(1); column++)
            {
                for(int row = 0; row < matrix.GetLength(0); row++)
                {
                    this._columnList[column].AddRow(matrix[row, column]);
                }
            }
            this._columnList.Sort();
            this.MyCustomizeSort();
        }

        private void MyCustomizeSort()
        {
            for(int i = 0; i < this._columnList.Count - 1; i++)
            {
                MyCustomizeColumn temp = this._columnList[i];
                this._columnList[i] = this._columnList[i + 1];
                this._columnList[i + 1] = temp;
            }
        }

        public string GetTableInString()
        {
            this.PopulateColumn();
            string display = "";
            for(int i = -1; i < this._columnList[0].GetRows().Count; i++)
            {
                foreach (var c in this._columnList)
                {
                    if(i == -1)
                    {
                        display += c.GetName() + "\t";
                    }
                    else
                    {
                        display += c.GetRows()[i] + "\t";
                    }
                }
                display += "\r\n";
            }
            return display;
        }
    }
} 
