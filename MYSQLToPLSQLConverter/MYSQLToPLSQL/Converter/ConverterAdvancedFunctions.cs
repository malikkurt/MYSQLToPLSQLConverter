 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter.Converter
{
    internal class ConverterAdvancedFunctions : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {

            if(queryParser.formattedQuery.Contains("CONVERT(") || queryParser.formattedQuery.Contains("CONVERT ("))
            {
                if (queryParser.formattedQuery.Contains("USING"))
                {
                }
                else
                {
                    string[] temp = queryParser.formattedQuery.Split("CONVERT");
                    temp = temp[1].Split(")");

                    temp[0] = queryParser.formattedQuery.Replace(",", " AS");
                    queryParser.formattedQuery = temp[0].Replace("CONVERT", "CAST");
                    
                }

            }

            if (queryParser.formattedQuery.Contains("IF(") || queryParser.formattedQuery.Contains("IF (")) 
            {
                string condition, value_if_true, value_if_false;
                string[] temp, temp_1;

                temp = queryParser.formattedQuery.Split("IF");
                temp_1 = temp[1].Split(")");
                temp = temp_1[0].Split(",");
                condition = temp[0];
                value_if_true = temp[1];
                value_if_false = temp[2];

                queryParser.formattedQuery = queryParser.formattedQuery.Replace("IF" + temp_1[0], "CASE WHEN " + condition + " THEN" + value_if_true + "ELSE" + value_if_false);

            }

            if (queryParser.formattedQuery.Contains("IFNULL(") || queryParser.formattedQuery.Contains("IFNULL ("))
            {
                queryParser.formattedQuery = queryParser.formattedQuery.Replace("IFNULL", "NVL");
            }

            
            _nextConverterHandler.Convert(queryParser);
        }
    }
}
