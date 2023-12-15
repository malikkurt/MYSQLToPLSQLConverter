using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SqlConverter.Converter
{
    internal class ConverterStringFunctions : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {

            if (queryParser.formattedQuery.Contains("CHAR_LENGTH(") || queryParser.formattedQuery.Contains("CHAR_LENGTH ("))
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

            if (checkContains("LEFT", queryParser)) 
            {
                string splitQuery = tempQuery("LEFT", queryParser);

                string text, numberOfChars;

                string[] temp = splitQuery.Split("(");
                temp = temp[1].Split(")");
                temp = temp[0].Split(",");

                text = temp[0];
                numberOfChars = temp[1];

                queryParser.formattedQuery = queryParser.formattedQuery.Replace("LEFT" + splitQuery, "SUBSTR(" + text + ", 1," + numberOfChars);
                // burada gereksiz bir boşluk var bak buraya
            }

            if (queryParser.formattedQuery.Contains("LOCATE(") || queryParser.formattedQuery.Contains("LOCATE ("))
            {

                queryParser.formattedQuery = queryParser.formattedQuery.Replace("LOCATE", "INSTR");
            }

            if (checkContains("POSITION", queryParser))
            {
                string splitQuery = tempQuery("POSITION", queryParser);
                string subString, text;

                string[] temp = splitQuery.Split('(');
                temp = temp[1].Split(")");
                temp = temp[0].Split("IN");
                subString = temp[0];
                text = temp[1];

                queryParser.formattedQuery = queryParser.formattedQuery.Replace("POSITION" + splitQuery, "INSTR(" + text + "," + subString + ")");
                // Başında ve sonunda boşluk var istersen düzelt

            }

            if (checkContains("REPEAT", queryParser))
            {
                string splitQuery = tempQuery("REPEAT", queryParser);

                string text, number;
                string[] temp;

                temp = splitQuery.Split("(");
                temp = temp[1].Split(",");
                text = temp[0];
                temp = temp[1].Split(")");
                number = temp[0];

                queryParser.formattedQuery = queryParser.formattedQuery.Replace("REPEAT" + splitQuery, "RPAD" + "(" + text + ", LENGTH(" + text + ") *" + number + ", " + text);
            }

            if (checkContains("RIGHT", queryParser))
            {
                string splitQuery = tempQuery("RIGHT", queryParser);

                string text, numberOfChar;
                string[] temp;

                temp = splitQuery.Split("(");
                temp = temp[1].Split(",");
                text = temp[0];
                temp = temp[1].Split(")");
                numberOfChar = temp[0];

                queryParser.formattedQuery = queryParser.formattedQuery.Replace("RIGHT" + splitQuery, "SUBSTR" + "(" + text + ", GREATEST(-LENGTH(" + text + "), -" + numberOfChar);
            }

            if (checkContains("SPACE", queryParser))
            {
                string splitQuery = tempQuery("SPACE", queryParser);

                string number;
                string[] temp;

                temp = splitQuery.Split("(");
                temp = temp[1].Split(")");
                number = temp[0];

                queryParser.formattedQuery = queryParser.formattedQuery.Replace("SPACE" + splitQuery, "RPAD(' ', " + number + ")");

            }

            if (checkContains("SUBSTRING", queryParser))
            {
                queryParser.formattedQuery = queryParser.formattedQuery.Replace("SUBSTRING", "SUBSTR");
            }

            if (checkContains("UCASE", queryParser))
            {
                queryParser.formattedQuery = queryParser.formattedQuery.Replace("UCASE", "UPPER");
            }



            _nextConverterHandler.Convert(queryParser);

        }
    }
}

