using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPP.Connectives;

namespace LPP
{
    abstract class Connective: Node
    {
        //field
        protected string _value;

        //constructor
        public Connective(string value)
        {
            this._value = value;
        }

        public string GetVal()
        {
            return this._value;
        }

        public override bool CalculateResult() { return true; }

        public override void DrawGraphHelper(ref string content)
        {
            if (this.LeftNode != null)
            {
                content += "node" + Index + " [ label = \"" + this.GetVal() + "\" ]\r\n";
                content += "node" + Index + " -- " + "node" + LeftNode.Index + "\r\n";
            }
            if (this.RightNode != null)
            {
                content += "node" + Index + " [ label = \"" + this.GetVal() + "\" ]\r\n";
                content += "node" + Index + " -- " + "node" + RightNode.Index + "\r\n";
            }
        }

        public override string ConvertOperator() { return ""; }

        public override string ToString()
        {
            return "";
        }
    }
}
