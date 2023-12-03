using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter.Converter
{
    internal class ConverterStringFunctions : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {

            if(queryParser.formattedQuery.Contains("CHAR_LENGTH(") || queryParser.formattedQuery.Contains("CHAR_LENGTH ("))
            {
                queryParser.formattedQuery = queryParser.formattedQuery.Replace("CHAR_LENGTH", "LENGTH");
            }

            if (queryParser.formattedQuery.Contains("CHARACTER_LENGTH(") || queryParser.formattedQuery.Contains("CHARACTER_LENGTH ("))
            {
                queryParser.formattedQuery = queryParser.formattedQuery.Replace("CHARACTER_LENGTH", "LENGTH");
            }

            //    if (currentQuery.Contains("CONCAT("))
            //    {
            //        if (currentQuery.Contains("GROUP_CONCAT("))
            //        {
            //            string distinct, orderBy, separator;
            //            string[] temp;

            //            temp = queryParser.queryList[i].Split("GROUP_CONCAT(");
            //            temp = temp[1].Split(")");

            //            string functionContent = temp[0].Trim();

            //            if (functionContent.Contains("DISTINCT"))
            //            {
            //                distinct = "DISTINCT ";
            //                functionContent = functionContent.Replace("DISTINCT", "").Trim();
            //            }
            //            else
            //            {
            //                distinct = "";
            //            }

            //            if (functionContent.Contains("ORDER BY"))
            //            {
            //                int orderByIndex = functionContent.IndexOf("ORDER BY");
            //                orderBy = "ORDER BY " + functionContent.Substring(orderByIndex + 8).Trim();
            //                functionContent = functionContent.Remove(orderByIndex).Trim();
            //            }
            //            else
            //            {
            //                orderBy = "";
            //            }

            //            if (functionContent.Contains("SEPARATOR"))
            //            {
            //                int separatorIndex = functionContent.IndexOf("SEPARATOR");
            //                separator = "SEPARATOR '" + functionContent.Substring(separatorIndex + 9).Trim() + "'";
            //                functionContent = functionContent.Remove(separatorIndex).Trim();
            //            }
            //            else
            //            {
            //                separator = "";
            //            }

            //            string convertedFunction = "LISTAGG(" + distinct + functionContent + ", " + separator + ")";
            //            if (!string.IsNullOrEmpty(orderBy))
            //            {
            //                convertedFunction += " WITHIN GROUP (" + orderBy + ")";
            //            }

            //            queryParser.queryList[i] = queryParser.queryList[i].Replace("GROUP_CONCAT(" + temp[0] + ")", convertedFunction);
            //        }
            //        else
            //        {
            //            string[] expressıon, temp;

            //            temp = currentQuery.Split("CONCAT(");
            //            temp = temp[1].Split(")");


            //            currentQuery = currentQuery.Replace("CONCAT(" + temp[0] + ")", " (" + temp[0].Replace(",", " ||") + ")");
            //            queryParser.queryList[i] = currentQuery.Replace("COLLATE utf8_unicode_ci", "");
            //        } 

            //    }


            //}

            if (queryParser.formattedQuery.Contains("LCASE(") || queryParser.formattedQuery.Contains("LCASE ("))
            {

                queryParser.formattedQuery = queryParser.formattedQuery.Replace("LCASE", "LOWER");

            }

            //if(queryParser.formattedQuery.Contains("LEFT(") || queryParser.formattedQuery.Contains("LEFT ("))
            //{
            //}

            ////if (currentQuery.Contains("LEFT("))
            ////{
            ////    queryParser.queryList[i] = currentQuery.Replace("LEFT(", "SUBSTR(");

            ////    string fırstunıt;
            ////    string[] temp;

            ////    temp = currentQuery.Split("(");

            ////    temp = temp[1].Split(",");

            ////    fırstunıt = temp[0];

            ////    queryParser.queryList[i] = currentQuery.Replace(fırstunıt, fırstunıt + ", 1");

            ////}

            if (queryParser.formattedQuery.Contains("LOCATE(") || queryParser.formattedQuery.Contains("LOCATE ("))
            {

                queryParser.formattedQuery = queryParser.formattedQuery.Replace("LOCATE", "INSTR");
            }

            //if(queryParser.formattedQuery.Contains("POSITION(") || queryParser.formattedQuery.Contains("POSITION ("))
            //{
            //    string subString, lastString;
            //    string[] temp;

            //    temp = queryParser.formattedQuery.Split("POSITION");
            //    temp = temp[1].Split();


            //}

            //    if (queryParser.queryList[i].Contains("POSITION("))
            //    {
            //        //queryParser.queryList[i] = queryParser.queryList[i].Replace(" POSITION(", " INSTR");

            //        //string subString, lastString;
            //        //string[] temp;


            //        //temp = queryParser.queryList[i].Split("(");
            //        //temp = temp[1].Split(")");
            //        ////temp = temp[0].Split(" ");

            //        //foreach (string s in temp)
            //        //{
            //        //    Console.WriteLine(s);
            //        //}

            //        //subString = temp[0];
            //        //lastString = temp[2];


            //        //queryParser.queryList[i] = queryParser.queryList[i].Replace(subString + " IN", lastString);

            //    }

            if (queryParser.formattedQuery.Contains("REPEAT(") || queryParser.formattedQuery.Contains("REPEAT ("))
            {
                string splitQuery =  tempQuery("REPEAT", queryParser.formattedQuery);

                string text, number;
                string[] temp;

                temp = splitQuery.Split("(");
                temp = temp[1].Split(",");
                text = temp[0];
                temp = temp[1].Split(")");
                number = temp[0];

                queryParser.formattedQuery = queryParser.formattedQuery.Replace("REPEAT" + splitQuery,"RPAD" + "(" + text + ", LENGTH(" + text + ") *" + number + ", " + text);


            }



            _nextConverterHandler.Convert(queryParser);
        }
    }
}
