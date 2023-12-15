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


            

            if(queryParser.formattedQuery.Contains("LOCATE(") || queryParser.formattedQuery.Contains("LOCATE (")){

                queryParser.formattedQuery = queryParser.formattedQuery.Replace("LOCATE", "INSTR");
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
