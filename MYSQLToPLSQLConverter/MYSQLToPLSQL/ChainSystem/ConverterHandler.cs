using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter
{
    public abstract class ConverterHandler
    {
        protected ConverterHandler _nextConverterHandler;

        public void setNextConverterHandler(ConverterHandler nextConverterHandler)
        {
            this._nextConverterHandler = nextConverterHandler;
        }
        public abstract void Convert(QueryParser queryParser);

        public string tempQuery(string keywords, QueryParser queryParser)
        {
            string[] temp;

            temp = queryParser.formattedQuery.Split(keywords);
            temp = temp[1].Split(")");

            return temp[0] += ")";
        }

        public bool checkContains(string keywords, QueryParser queryParser)
        {
            bool checkedContains = queryParser.formattedQuery.Contains(keywords + "(") || queryParser.formattedQuery.Contains(keywords + " (");

            return checkedContains;
        }



    }
}
