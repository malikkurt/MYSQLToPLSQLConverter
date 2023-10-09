﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter.Converter
{
    internal class ConverterSmallDiff : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {

            if (queryParser.formattedQuery.Contains("LCASE(") || queryParser.formattedQuery.Contains("LCASE (")){

                queryParser.formattedQuery = queryParser.formattedQuery.Replace("LCASE", "LOWER");

            }   

            //    if (currentQuery.Contains("LEFT("))
            //    {
            //        queryParser.queryList[i] = currentQuery.Replace("LEFT(", "SUBSTR(");

            //        string fırstunıt;
            //        string[] temp;

            //        temp = currentQuery.Split("(");

            //        temp = temp[1].Split(",");

            //        fırstunıt = temp[0];

            //        queryParser.queryList[i] = currentQuery.Replace(fırstunıt, fırstunıt + ", 1");

            //    }

            if(queryParser.formattedQuery.Contains("LOCATE(") || queryParser.formattedQuery.Contains("LOCATE (")){

                queryParser.formattedQuery = queryParser.formattedQuery.Replace("LOCATE", "INSTR");
            }

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

            //    if (currentQuery.Contains("REPEAT("))
            //    {
            //        string text, number;
            //        string[] temp;

            //        temp = currentQuery.Split("(");
            //        temp = temp[1].Split(")");
            //        temp = temp[0].Split(",");
            //        text = temp[0];
            //        number = temp[1];

            //        currentQuery = currentQuery.Replace("REPEAT(", "RPAD(");
            //        queryParser.queryList[i] = currentQuery.Replace(number + ")", " LENGTH(" +text+") * "+number+", "+ text);

                   
            //    }

            //    if (currentQuery.Contains("RIGHT("))
            //    {
            //        string text, number;
            //        string[] temp;

            //        temp = currentQuery.Split("(");
            //        temp = temp[1].Split(")");
            //        temp = temp[0].Split(",");

            //        text = temp[0];
            //        number = temp[1];

            //        Console.WriteLine(text);
            //        Console.WriteLine(number);


            //        currentQuery = currentQuery.Replace("RIGHT(", "SUBSTR(");
            //        queryParser.queryList[i] = currentQuery.Replace(number, " GREATEST(-LENGTH("+text+"), -" +number +")");

            //    }
               
            if(queryParser.formattedQuery.Contains("SPACE(") || queryParser.formattedQuery.Contains("SPACE (")){

                queryParser.formattedQuery = queryParser.formattedQuery.Replace("SPACE(", "RPAD(' ',");
                queryParser.formattedQuery = queryParser.formattedQuery.Replace("SPACE (", "RPAD(' ',");
            }

            if(queryParser.formattedQuery.Contains("SUBSTRING(") || queryParser.formattedQuery.Contains("SUBSTRING ("))
            {
                queryParser.formattedQuery = queryParser.formattedQuery.Replace("SUBSTRING", "SUBSTR");
            }

            if(queryParser.formattedQuery.Contains("UCASE(") || queryParser.formattedQuery.Contains("UCASE ("))
            {
                queryParser.formattedQuery = queryParser.formattedQuery.Replace("UCASE", "UPPER");
            }
                
            if(queryParser.formattedQuery.Contains("UCASE(") || queryParser.formattedQuery.Contains("UCASE ("))
            {
                queryParser.formattedQuery = queryParser.formattedQuery.Replace("UCASE", "UPPER");
            }
            

            //    if (currentQuery.Contains("COT("))
            //    {
            //        string number;
            //        string[] temp;

            //        temp = currentQuery.Split("(");

            //        temp = temp[1].Split(")");
            //        number = temp[0];

            //        queryParser.queryList[i] = currentQuery.Replace("COT("+ number + ")", "COS(" + number + ")/SIN(" + number + ")");

            //    }

            //    if (currentQuery.Contains("DEGREES("))
            //    {
            //        string number;
            //        string[] temp;

            //        temp = currentQuery.Split("(");

            //        temp = temp[1].Split(")");
            //        number = temp[0];

            //        currentQuery = currentQuery.Replace("DEGREES","");
            //        queryParser.queryList[i] = currentQuery.Replace("(" + number + ")", "(" + number + ")" + " * 180/3.1415926535");

            //    }

            //    if (currentQuery.Contains("LOG10"))
            //    {
            //        string number;
            //        string[] temp;

            //        temp = currentQuery.Split("(");
            //        temp = temp[1].Split(")");

            //        number = temp[0];

            //        queryParser.queryList[i] = currentQuery.Replace("LOG10(" + number + ")", "LOG(10," + number + ")");
            //    }

            if(queryParser.formattedQuery.Contains("PI()") || queryParser.formattedQuery.Contains("PI ()"))
            {
                queryParser.formattedQuery = queryParser.formattedQuery.Replace("PI()","3.1415926535897931");
            }

            //    if (currentQuery.Contains("RADIANS("))
            //    {
            //        string number;
            //        string[] temp;

            //        temp = currentQuery.Split("(");
            //        temp = temp[1].Split(")");
            //        number = temp[0];

            //        queryParser.queryList[i] = currentQuery.Replace("(" + number + ")", "(" + number + ") * " + 3.1415926535 / 180);

            //    }

            //    if (currentQuery.Contains("RAND("))
            //    {
            //        if (currentQuery.Contains("*"))
            //        {
            //            string seed;
            //            string[] temp;

            //            temp = currentQuery.Split('*');
            //            temp = temp[1].Split(";");
            //            seed = temp[0];

            //            queryParser.queryList[i] = currentQuery.Replace("RAND()", "DBMS_RANDOM.VALUE");

            //        }
            //        else
            //        {
            //            string number;
            //            string[] temp;

            //            temp = currentQuery.Split("(");
            //            temp = temp[1].Split(")");
            //            number = temp[0];

            //            queryParser.queryList[i] = currentQuery.Replace("RAND(" + number + ")", "DBMS_RANDOM.VALUE");
            //        }

            //    }

            

           if(queryParser.formattedQuery.Contains("TRUNCATE(") || queryParser.formattedQuery.Contains("TRUNCATE ("))
            {
                queryParser.formattedQuery = queryParser.formattedQuery.Replace("TRUNCATE", "TRUNC");
            }


           
            _nextConverterHandler.Convert(queryParser);
        }
    }
}
