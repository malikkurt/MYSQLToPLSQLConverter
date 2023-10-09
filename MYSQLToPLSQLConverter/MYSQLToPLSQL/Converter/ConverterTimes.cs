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

            //if(queryParser.formattedQuery.Contains("CURTIME()") || queryParser.formattedQuery.Contains("CURTIME ()")){
                
            //    queryParser.formattedQuery = queryParser.formattedQuery.Replace("CURTIME", "SYSTIMESTAMP");
            //}

            //if (queryParser.formattedQuery.Contains("TIME"))
            //{
            //    if (queryParser.formattedQuery.Contains("CURTIME()") || queryParser.formattedQuery.Contains("CURTIME ()"))
            //    {

            //        queryParser.formattedQuery = queryParser.formattedQuery.Replace("CURTIME", "SYSTIMESTAMP");
            //    }


            //    else if (queryParser.formattedQuery.Contains("TIME(") || queryParser.formattedQuery.Contains("TIME ("))
            //    {
            //        queryParser.formattedQuery = queryParser.formattedQuery.Replace("TIME", "TO_TIMESTAMP");
            //    }


            //}

            
            // burdan yukarısı sorunlu ama yeni kodda


            //for (int i = 0; i < queryParser.queryList.Count; i++)
            //{
            //    string currentQuery = queryParser.queryList[i];

            //    if (currentQuery.Contains("CURTIME()"))
            //    {
            //        queryParser.queryList[i] = currentQuery.Replace("CURTIME()", "SYSTIMESTAMP");
            //    }

            //    if (currentQuery.Contains("CURRENT_TIME"))
            //    {
            //        queryParser.queryList[i] = currentQuery.Replace("CURRENT_TIME", "SYSTIMESTAMP");
            //    }

            //    if (currentQuery.Contains("CURRENT_TIME()"))
            //    {
            //        queryParser.queryList[i] = currentQuery.Replace("CURRENT_TIME()", "SYSTIMESTAMP");
            //    }

            //    if (currentQuery.Contains("CURRENT_TIMESTAMP"))
            //    {
            //        queryParser.queryList[i] = currentQuery.Replace("CURRENT_TIMESTAMP", "CURRENT_TIMESTAMP");
            //    }

            //    if (currentQuery.Contains("CURRENT_TIMESTAMP()"))
            //    {
            //        queryParser.queryList[i] = currentQuery.Replace("CURRENT_TIMESTAMP()", "CURRENT_TIMESTAMP");
            //    }

            //}


            //_nextConverterHandler.Convert(queryParser);
        }
    }
}
