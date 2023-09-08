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
            for (int i = 0; i < queryParser.queryList.Count; i++)
            {
                string currentQuery = queryParser.queryList[i];

                if (currentQuery.Contains("CONVERT(")) 
                {
                    string value, type;
                    string[] temp;

                    temp = currentQuery.Split("(");
                    temp = temp[1].Split(")");

                    if (currentQuery.Contains("USING"))
                    {

                    }
                    else
                    { 
                        currentQuery = currentQuery.Replace("CONVERT(", "CAST(");
                        queryParser.queryList[i] = currentQuery.Replace(",", " AS ");

                    }
   
                }

                if (currentQuery.Contains("IF("))
                {
                    string condition, value_if_true, value_if_false;
                    string[] temp;

                    temp = currentQuery.Split("(");

                    temp = temp[1].Split(")");

                    temp = temp[0].Split(",");

                    condition = temp[0];
                    value_if_true = temp[1];
                    value_if_false = temp[2];


                    currentQuery = currentQuery.Replace("IF(", "CASE WHEN ");
                    currentQuery = currentQuery.Replace(condition + ",", condition + " THEN ");
     
                    currentQuery = currentQuery.Replace(value_if_true + ",", value_if_true + " ELSE ");
                    currentQuery = currentQuery.Replace(value_if_false + ")", value_if_false + " END ");
                    queryParser.queryList[i] = currentQuery.Replace(",", "");
                    


                }

                if (currentQuery.Contains("IFNULL("))
                {
                    queryParser.queryList[i] = currentQuery.Replace("IFNULL(", "NVL(");
                }

                if (currentQuery.Contains("CEILING("))
                {
                    queryParser.queryList[i] = currentQuery.Replace("CEILING(", "CEIL(");
                }

            }
            _nextConverterHandler.Convert(queryParser);
        }
    }
}
