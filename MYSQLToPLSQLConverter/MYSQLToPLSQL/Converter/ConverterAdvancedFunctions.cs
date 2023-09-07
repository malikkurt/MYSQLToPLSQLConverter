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
                string queryLıne = queryParser.queryList[i];

                if (queryLıne.Contains("CONVERT(")) 
                {
                    string value, type;
                    string[] temp;

                    temp = queryLıne.Split("(");
                    temp = temp[1].Split(")");

                    value = temp[0];
                    type = temp[1];

                    if (queryLıne.Contains("USING"))
                    {

                    }
                    else
                    { 
                        queryLıne = queryLıne.Replace("CONVERT(", "CAST(");
                        queryParser.queryList[i] = queryLıne.Replace(",", " AS ");

                    }
   
                }

                if (queryLıne.Contains("IF("))
                {
                    string condition, value_if_true, value_if_false;
                    string[] temp;

                    temp = queryLıne.Split("(");

                    temp = temp[1].Split(")");

                    temp = temp[0].Split(",");

                    condition = temp[0];
                    value_if_true = temp[1];
                    value_if_false = temp[2];


                    queryLıne = queryLıne.Replace("IF(", "CASE WHEN ");
                    queryLıne = queryLıne.Replace(condition + ",", condition + " THEN ");
     
                    queryLıne = queryLıne.Replace(value_if_true + ",", value_if_true + " ELSE ");
                    queryLıne = queryLıne.Replace(value_if_false + ")", value_if_false + " END ");
                    queryParser.queryList[i] = queryLıne.Replace(",", "");
                    


                }

                if (queryLıne.Contains("IFNULL("))
                {
                    queryParser.queryList[i] = queryLıne.Replace("IFNULL(", "NVL(");
                }

                if (queryLıne.Contains("CEILING("))
                {
                    queryParser.queryList[i] = queryLıne.Replace("CEILING(", "CEIL(");
                }

            }
            _nextConverterHandler.Convert(queryParser);
        }
    }
}
