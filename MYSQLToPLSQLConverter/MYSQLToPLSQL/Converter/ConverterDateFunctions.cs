using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter.Converter
{
    public class ConverterDateFunctions : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {

            if (checkContains("ADDDATE", queryParser))
            {
                string splitQuery = tempQuery("ADDDATE", queryParser);

                string date, days, value, addunit;

                string[] temp = splitQuery.Split('(');

            }













            //    if(queryParser.formattedQuery.Contains("ADDDATE(") || queryParser.formattedQuery.Contains("ADDDATE ("))
            //    {
            //        string date, days, value, addunit, baseTemp;
            //        string[] temp;


            //        temp = queryParser.formattedQuery.Split("ADDDATE");
            //        baseTemp = temp[1];

            //        temp = temp[1].Split(")");
            //        temp = temp[0].Split(",");

            //        date = temp[0].Remove(0,1);

            //        temp = temp[1].Split("INTERVAL");
            //        temp = temp[1].Split(" ");
            //        value = temp[1];
            //        addunit = temp[2];

            //        queryParser.formattedQuery = queryParser.formattedQuery.Replace(baseTemp, date + " + INTERVAL '" + value + "' " + addunit );
            //        queryParser.formattedQuery = queryParser.formattedQuery.Replace("ADDDATE", "");


            //if (queryParser.formattedQuery.Contains("CURDATE()") || queryParser.formattedQuery.Contains("CURDATE ()"))
            //{
            //    queryParser.formattedQuery = queryParser.formattedQuery.Replace("CURDATE()", "TRUNC(SYSDATE)");
            //    queryParser.formattedQuery = queryParser.formattedQuery.Replace("CURDATE ()", "TRUNC(SYSDATE)");
            //}

            //if(queryParser.formattedQuery.Contains("CURRENT_DATE()") || queryParser.formattedQuery.Contains("CURRENT_DATE ()")){
            //    queryParser.formattedQuery = queryParser.formattedQuery.Replace("CURRENT_DATE()", "TRUNC(SYSDATE)");
            //    queryParser.formattedQuery = queryParser.formattedQuery.Replace("CURRENT_DATE ()", "TRUNC(SYSDATE)");

            //}

            //if (queryParser.formattedQuery.Contains("DATE"))
            //

            //    }
            //    if(queryParser.formattedQuery.Contains("SYSDATE(") || queryParser.formattedQuery.Contains("SYSDATE ("))
            //    {
            //        // BURAYA EKKLENTİ GELİCEK 
            //    }
            //    else if (queryParser.formattedQuery.Contains("DATE"))
            //    {
            //        queryParser.formattedQuery = queryParser.formattedQuery.Replace("DATE (", "TO_DATE (");
            //        queryParser.formattedQuery = queryParser.formattedQuery.Replace("DATE(", "TO_DATE(");

            //    }
            //}

            //if(queryParser.formattedQuery.Contains("DATEDIFF(") || queryParser.formattedQuery.Contains("DATEDIFF ("))
            //{
            //    string date_1, date_2;
            //    string[] temp;

            //    temp = queryParser.formattedQuery.Split("DATEDIFF");

            //    temp = temp[1].Split(')');

            //    temp = temp[0].Split(",");

            //    date_1 = temp[0].Remove(0, 1);
            //    date_2 = temp[1];


            //    queryParser.formattedQuery = queryParser.formattedQuery.Replace("(" + date_1 + "," + date_2 + ")", date_1 + "-" + date_2);
            //    queryParser.formattedQuery = queryParser.formattedQuery.Replace("DATEDIFF", "");


            //}

            //if (queryParser.formattedQuery.Contains("DATE_ADD"))
            //{
            //    string date, value, addunit,baseTemp,afterTemp;
            //    string[] temp;

            //    temp = queryParser.formattedQuery.Split("DATE_ADD");
            //    baseTemp = temp[1];


            //    temp = temp[1].Split(")");
            //    temp = temp[0].Split("INTERVAL");
            //    temp = temp[1].Split(" ");
            //    value = temp[1];


            //    afterTemp = baseTemp.Replace(value, "'" + value + "'");

            //    queryParser.formattedQuery = queryParser.formattedQuery.Replace(baseTemp, afterTemp);

            //}

            //if (queryParser.formattedQuery.Contains("DATE_FORMAT"))
            //{
            //    queryParser.formattedQuery = queryParser.formattedQuery.Replace("DATE_FORMAT", "TO_CHAR");
            //}

            ////    if (currentQuery.Contains("DATE_SUB("))
            ////    {
            ////        string date, value, ınterval, addunit;

            ////        string[] temp;

            ////        temp = currentQuery.Split("(");

            ////        temp = temp[1].Split(",");
            ////        date = temp[0];

            ////        temp = temp[1].Split(" ");
            ////        ınterval = temp[1];
            ////        value = temp[2];

            ////        temp = temp[3].Split(")");
            ////        addunit = temp[0];

            ////        currentQuery = currentQuery.Replace("DATE_SUB(", "");
            ////        currentQuery = currentQuery.Replace(",", " -");
            ////        currentQuery = currentQuery.Replace(" "+value.ToString(), " '" + value.ToString() + "'");
            ////        queryParser.queryList[i] = currentQuery.Replace(addunit.ToString() + ")",addunit.ToString() );

            ////    }


            //if (queryParser.formattedQuery.Contains("DAY"))
            //{

            //    if (queryParser.formattedQuery.Contains("DAYNAME"))
            //    {
            //        string date;
            //        string[] temp;

            //        temp = queryParser.formattedQuery.Split("DAYNAME");
            //        temp = temp[1].Split(")");
            //        date = temp[0].Remove(0,1);

            //        queryParser.formattedQuery = queryParser.formattedQuery.Replace("DAYNAME", "TO_CHAR");
            //        queryParser.formattedQuery = queryParser.formattedQuery.Replace(date, date + ", 'DAY'");

            //    }

            //    if (queryParser.formattedQuery.Contains("DAYOFWEEK(") || queryParser.formattedQuery.Contains("DAYOFWEEK ("))
            //    {
            //        string date;
            //        string[] temp;

            //        temp = queryParser.formattedQuery.Split("DAYOFWEEK");
            //        temp = temp[1].Split(")");
            //        date = temp[0].Remove(0, 1);

            //        queryParser.formattedQuery = queryParser.formattedQuery.Replace("DAYOFWEEK", "TO_NUMBER(TO_CHAR");
            //        queryParser.formattedQuery = queryParser.formattedQuery.Replace(date, date + ", 'D')");

            //    }

            //    if (queryParser.formattedQuery.Contains("DAYOFWEEK(") || queryParser.formattedQuery.Contains("DAYOFWEEK ("))
            //    {
            //        string date;
            //        string[] temp;

            //        temp = queryParser.formattedQuery.Split("DAYOFWEEK");
            //        temp = temp[1].Split(")");
            //        date = temp[0].Remove(0, 1);

            //        queryParser.formattedQuery = queryParser.formattedQuery.Replace("DAYOFWEEK", "TO_NUMBER(TO_CHAR");
            //        queryParser.formattedQuery = queryParser.formattedQuery.Replace(date, date + ", 'D')");

            //    }

            //    if (queryParser.formattedQuery.Contains("DAYOFYEAR(") || queryParser.formattedQuery.Contains("DAYOFYEAR ("))
            //    {
            //        string date;
            //        string[] temp;

            //        temp = queryParser.formattedQuery.Split("DAYOFYEAR");
            //        temp = temp[1].Split(")");
            //        date = temp[0].Remove(0, 1);

            //        queryParser.formattedQuery = queryParser.formattedQuery.Replace("DAYOFYEAR", "TO_NUMBER(TO_CHAR");
            //        queryParser.formattedQuery = queryParser.formattedQuery.Replace(date, date + ", 'DDD')");

            //    }

            //    else if (queryParser.formattedQuery.Contains("DAY(") || queryParser.formattedQuery.Contains("DAY ("))
            //    {
            //        string date;
            //        string[] temp;

            //        temp = queryParser.formattedQuery.Split("DAY");
            //        temp = temp[1].Split(")");
            //        date = temp[0].Remove(0, 1);

            //        queryParser.formattedQuery = queryParser.formattedQuery.Replace("DAY", "EXTRACT");
            //        queryParser.formattedQuery = queryParser.formattedQuery.Replace(date,"DAY FROM "+date);
            //    }
            //}

            //if(queryParser.formattedQuery.Contains("HOUR(") || queryParser.formattedQuery.Contains("HOUR ("))
            //{
            //    string datetıme;
            //    string[] temp;

            //    temp = queryParser.formattedQuery.Split("HOUR");
            //    temp = temp[1].Split(")");
            //    datetıme = temp[0].Remove(0,1);

            //    queryParser.formattedQuery = queryParser.formattedQuery.Replace("HOUR", "EXTRACT");
            //    queryParser.formattedQuery = queryParser.formattedQuery.Replace(datetıme, "HOUR FROM " + datetıme);
            //}

            ////    if (currentQuery.Contains("MICROSECOND("))
            ////    {
            ////        string date;
            ////        string[] temp;

            ////        temp = currentQuery.Split("(");
            ////        temp = temp[1].Split(")");
            ////        date = temp[0];


            ////        currentQuery = currentQuery.Replace("MICROSECOND(", "TO_NUMBER(TO_CHAR(");
            ////        queryParser.queryList[i] = currentQuery.Replace(date,date + ", 'FF6')");

            ////    }

            //if (queryParser.formattedQuery.Contains("MINUTE(") || queryParser.formattedQuery.Contains("MINUTE ("))
            //{
            //    string datetıme;
            //    string[] temp;

            //    temp = queryParser.formattedQuery.Split("MINUTE");
            //    temp = temp[1].Split(")");
            //    datetıme = temp[0].Remove(0, 1);

            //    queryParser.formattedQuery = queryParser.formattedQuery.Replace("MINUTE", "EXTRACT");
            //    queryParser.formattedQuery = queryParser.formattedQuery.Replace(datetıme, "MINUTE FROM " + datetıme);
            //}

            //if (queryParser.formattedQuery.Contains("MONTH(") || queryParser.formattedQuery.Contains("MONTH ("))
            //{
            //    string datetıme;
            //    string[] temp;

            //    temp = queryParser.formattedQuery.Split("MONTH");
            //    temp = temp[1].Split(")");
            //    datetıme = temp[0].Remove(0, 1);

            //    queryParser.formattedQuery = queryParser.formattedQuery.Replace("MONTH", "EXTRACT");
            //    queryParser.formattedQuery = queryParser.formattedQuery.Replace(datetıme, "MONTH FROM " + datetıme);
            //}

            //if (queryParser.formattedQuery.Contains("MONTHNAME(") || queryParser.formattedQuery.Contains("MONTHNAME ("))
            //{
            //    string datetıme;
            //    string[] temp;

            //    temp = queryParser.formattedQuery.Split("MONTHNAME");
            //    temp = temp[1].Split(")");
            //    datetıme = temp[0].Remove(0, 1);

            //    queryParser.formattedQuery = queryParser.formattedQuery.Replace("MONTHNAME", "TO_CHAR");
            //    queryParser.formattedQuery = queryParser.formattedQuery.Replace(datetıme, datetıme + ", 'Month'");
            //}

            //if (queryParser.formattedQuery.Contains("QUARTER(") || queryParser.formattedQuery.Contains("QUARTER ("))
            //{
            //    string datetıme;
            //    string[] temp;

            //    temp = queryParser.formattedQuery.Split("QUARTER");
            //    temp = temp[1].Split(")");
            //    datetıme = temp[0].Remove(0, 1);

            //    queryParser.formattedQuery = queryParser.formattedQuery.Replace("QUARTER", "TO_NUMBER(TO_CHAR");
            //    queryParser.formattedQuery = queryParser.formattedQuery.Replace(datetıme, datetıme + ", 'Q')");

            //}

            ////    if (currentQuery.Contains("SUBDATE("))
            ////    {
            ////        string date, ınterval, value, unıt;

            ////        string[] temp;

            ////        temp = currentQuery.Split("(");

            ////        temp = temp[1].Split(",");
            ////        date = temp[0];

            ////        temp = temp[1].Split(" ");
            ////        ınterval = temp[1];
            ////        value = temp[2];

            ////        temp = temp[3].Split(")");
            ////        unıt = temp[0];


            ////        queryParser.queryList[i] = currentQuery.Replace("SUBDATE(", "");
            ////        queryParser.queryList[i] = currentQuery.Replace(",", " -");
            ////        queryParser.queryList[i] = currentQuery.Replace(" " + value, "'" + value + "'");
            ////        queryParser.queryList[i] = currentQuery.Replace(unıt + ")", unıt);

            ////    }

            //// TIME METODUNU TAŞIDIM BURDAN

            //if (queryParser.formattedQuery.Contains("WEEK(") || queryParser.formattedQuery.Contains("WEEK ("))
            //{
            //    string datetıme;
            //    string[] temp;

            //    temp = queryParser.formattedQuery.Split("WEEK");
            //    temp = temp[1].Split(")");
            //    datetıme = temp[0].Remove(0, 1);

            //    queryParser.formattedQuery = queryParser.formattedQuery.Replace("WEEK", "TO_NUMBER(TO_CHAR");
            //    queryParser.formattedQuery = queryParser.formattedQuery.Replace(datetıme, datetıme + ", 'WW')");

            //}

            //if (queryParser.formattedQuery.Contains("YEAR(") || queryParser.formattedQuery.Contains("YEAR ("))
            //{
            //    string datetıme;
            //    string[] temp;

            //    temp = queryParser.formattedQuery.Split("YEAR");
            //    temp = temp[1].Split(")");
            //    datetıme = temp[0].Remove(0, 1);

            //    queryParser.formattedQuery = queryParser.formattedQuery.Replace("YEAR", "EXTRACT");
            //    queryParser.formattedQuery = queryParser.formattedQuery.Replace(datetıme, "YEAR FROM " + datetıme);
            //}

            //if (queryParser.formattedQuery.Contains("NOW()"))
            //{
            //    queryParser.formattedQuery =  queryParser.formattedQuery.Replace("NOW()", "SYSDATE");
            //}

            _nextConverterHandler.Convert(queryParser);
        }
    }
}

// 357 SATIR
