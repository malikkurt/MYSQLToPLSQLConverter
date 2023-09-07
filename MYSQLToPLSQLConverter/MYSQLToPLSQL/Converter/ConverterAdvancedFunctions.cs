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

                if (queryParser.queryList[i].Contains("CONVERT(")) 
                {
                    string value, type;
                    string[] temp;

                    temp = queryParser.queryList[i].Split("(");
                    temp = temp[1].Split(")");

                    value = temp[0];
                    type = temp[1];

                    if (queryParser.queryList[i].Contains("USING"))
                    {

                    }
                    else
                    {
                        queryParser.queryList[i] = queryParser.queryList[i].Replace("CONVERT(", "CAST(");
                        queryParser.queryList[i] = queryParser.queryList[i].Replace(",", " AS ");

                    }
   
                }

                if (queryParser.queryList[i].Contains("IF("))
                {
                    string condition, value_if_true, value_if_false;
                    string[] temp;

                    temp = queryParser.queryList[i].Split("(");

                    temp = temp[1].Split(")");

                    temp = temp[0].Split(",");

                    condition = temp[0];
                    value_if_true = temp[1];
                    value_if_false = temp[2];


                    queryParser.queryList[i] = queryParser.queryList[i].Replace("IF(", "CASE WHEN ");
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(condition + ",", condition + " THEN ");
     
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(value_if_true + ",", value_if_true + " ELSE ");
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(value_if_false + ")", value_if_false + " END ");
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(",", "");
                    


                }

                if (queryLıne.Contains("IFNULL("))
                {
                    queryParser.queryList[i] = queryLıne.Replace("IFNULL(", "NVL(");
                }

                if (queryParser.queryList[i].Contains("CEILING("))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace("CEILING(", "CEIL(");
                }

            }
            _nextConverterHandler.Convert(queryParser);
        }
    }
}
