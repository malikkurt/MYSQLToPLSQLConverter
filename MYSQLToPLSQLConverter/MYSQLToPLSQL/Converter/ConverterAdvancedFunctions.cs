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
                string[] temp = queryParser.formattedQuery.Split("CONVERT");
                temp = temp[1].Split(")");
                
                queryParser.formattedQuery = queryParser.formattedQuery.Replace(temp,"");

            }


            //if (currentquery.contains("convert("))
            //{
            //    string value, type;
            //    string[] temp;

            //    temp = currentquery.split("(");
            //    temp = temp[1].split(")");

            //    if (currentquery.contains("usıng"))
            //    {

            //    }
            //    else
            //    {
            //        currentquery = currentquery.replace("convert(", "cast(");
            //        queryparser.querylist[i] = currentquery.replace(",", " as ");

            //    }

            //}

            //    if (currentQuery.Contains("IF("))
            //    {
            //        string condition, value_if_true, value_if_false;
            //        string[] temp;

            //        temp = currentQuery.Split("(");

            //        temp = temp[1].Split(")");

            //        temp = temp[0].Split(",");

            //        condition = temp[0];
            //        value_if_true = temp[1];
            //        value_if_false = temp[2];


            //        currentQuery = currentQuery.Replace("IF(", "CASE WHEN ");
            //        currentQuery = currentQuery.Replace(condition + ",", condition + " THEN ");

            //        currentQuery = currentQuery.Replace(value_if_true + ",", value_if_true + " ELSE ");
            //        currentQuery = currentQuery.Replace(value_if_false + ")", value_if_false + " END ");
            //        queryParser.queryList[i] = currentQuery.Replace(",", "");



            //    }

            if (queryParser.formattedQuery.Contains("IFNULL(") || queryParser.formattedQuery.Contains("IFNULL ("))
            {
                queryParser.formattedQuery = queryParser.formattedQuery.Replace("IFNULL", "NVL");
            }

            if(queryParser.formattedQuery.Contains("CEILING(") || queryParser.formattedQuery.Contains("CEILING ("))
            {
                queryParser.formattedQuery = queryParser.formattedQuery.Replace("CEILING", "CEIL");
            }

            

            _nextConverterHandler.Convert(queryParser);
        }
    }
}
