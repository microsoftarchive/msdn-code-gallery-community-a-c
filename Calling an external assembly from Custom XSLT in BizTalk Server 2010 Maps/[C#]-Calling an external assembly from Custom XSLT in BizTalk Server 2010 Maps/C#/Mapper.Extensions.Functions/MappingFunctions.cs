using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace MapperExtensionsFunctions
{
    public class MappingFunctions
    {
        public MappingFunctions()
		{
		}

        public string ToDecimalPoint(string Input)
        {
            CultureInfo ciEN = new CultureInfo("en-US", false);

            double ConvertionDouble = double.Parse(Input, ciEN);
            string Output = string.Format("{0:0.000}", ConvertionDouble);
            return Output;
        }
    }
}
