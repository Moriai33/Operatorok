using System;
using System.Collections.Generic;
using System.Text;

namespace Operátorok
{
    public class Equation
    {
        public int FirstValue { get;}
        public int SecondValue { get; }
        public string Operator { get; }
        public string Result { get;}

        public Equation(int FirstValue, string Operator, int SecondValue, string Result)
        {
            this.FirstValue = FirstValue;
            this.Operator = Operator;
            this.SecondValue = SecondValue;
            this.Result = Result;
        }
    }
}
