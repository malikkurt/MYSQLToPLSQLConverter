using SqlConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYSQLToPLSQLConverter.MYSQLToPLSQL.Converter
{
    internal class NumericFunctions : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {
            
            if(checkContains("CEILING", queryParser))
            {
                queryParser.formattedQuery = queryParser.formattedQuery.Replace("CEILING", "CEIL");
            }




        }
    }
}
