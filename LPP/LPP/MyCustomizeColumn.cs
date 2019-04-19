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
        private List<string> _row;

        public MyCustomizeColumn(string name)
        {
            this._name = name;
            this._row = new List<string>();
        }

        public string GetName()
        {
            return this._name;
        }

        public List<string> GetRows()
        {
            return this._row;
        }

        public void AddRow(string s)
        {
            this._row.Add(s);
        }

        public int CompareTo(MyCustomizeColumn other)
        {
            return this._name.CompareTo(other._name);
        }
    }
}
