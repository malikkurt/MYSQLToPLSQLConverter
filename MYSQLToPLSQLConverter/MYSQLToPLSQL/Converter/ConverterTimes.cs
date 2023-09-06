using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter.Converter
{
    internal class ConverterTimes : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {
            for (int i = 0; i < queryParser.queryList.Count; i++)
            {   
                if (queryParser.queryList[i].Contains("CURTIME()"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace("CURTIME()", "SYSTIMESTAMP");
                }

                if (queryParser.queryList[i].Contains("CURRENT_TIME"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace("CURRENT_TIME", "SYSTIMESTAMP");
                }

                if (queryParser.queryList[i].Contains("CURRENT_TIME()"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace("CURRENT_TIME()", "SYSTIMESTAMP");
                }

                if (queryParser.queryList[i].Contains("CURRENT_TIMESTAMP"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace("CURRENT_TIMESTAMP", "CURRENT_TIMESTAMP");
                }

                if (queryParser.queryList[i].Contains("CURRENT_TIMESTAMP()"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace("CURRENT_TIMESTAMP()", "CURRENT_TIMESTAMP");
                }

            }


            _nextConverterHandler.Convert(queryParser);
        }
    }
}
