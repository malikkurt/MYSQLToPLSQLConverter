using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter
{
    public class ConverterQuestion : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {

            if (queryParser.formattedQuery.Contains("?"))
            {
                queryParser.formattedQuery = queryParser.formattedQuery.Replace("?", ":");
            }
            
            _nextConverterHandler.Convert(queryParser);
        }

    }
}
