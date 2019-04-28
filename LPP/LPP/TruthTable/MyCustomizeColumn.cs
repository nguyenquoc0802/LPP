using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP
{
    class MyCustomizeColumn: IComparable<MyCustomizeColumn> 
    {
        private string _name;
        private List<bool> _row;
        private List<string> _stringRow;

        public MyCustomizeColumn(string name)
        {
            this._name = name;
            this._row = new List<bool>();
            this._stringRow = new List<string>();
        }

        public string GetName()
        {
            return this._name;
        }

        public List<bool> GetRows()
        {
            return this._row;
        }

        public List<string> GetStringRows()
        {
            return this._stringRow;
        }

        public void AddRow(bool v)
        {
            this._row.Add(v);
        }

        public void AddStringRow(string s)
        {
            this._stringRow.Add(s);
        }

        public void ClearRow()
        {
            this._row.Clear();
        }

        public int CompareTo(MyCustomizeColumn other)
        {
            return this._name.CompareTo(other._name);
        }
    }
}
