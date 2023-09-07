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
                string queryLıne = queryParser.queryList[i];

                if (queryLıne.Contains("CURTIME()"))
                {
                    queryParser.queryList[i] = queryLıne.Replace("CURTIME()", "SYSTIMESTAMP");
                }

                if (queryLıne.Contains("CURRENT_TIME"))
                {
                    queryParser.queryList[i] = queryLıne.Replace("CURRENT_TIME", "SYSTIMESTAMP");
                }

                if (queryLıne.Contains("CURRENT_TIME()"))
                {
                    queryParser.queryList[i] = queryLıne.Replace("CURRENT_TIME()", "SYSTIMESTAMP");
                }

                if (queryLıne.Contains("CURRENT_TIMESTAMP"))
                {
                    queryParser.queryList[i] = queryLıne.Replace("CURRENT_TIMESTAMP", "CURRENT_TIMESTAMP");
                }

                if (queryLıne.Contains("CURRENT_TIMESTAMP()"))
                {
                    queryParser.queryList[i] = queryLıne.Replace("CURRENT_TIMESTAMP()", "CURRENT_TIMESTAMP");
                }

            }


            _nextConverterHandler.Convert(queryParser);
        }
    }
}
