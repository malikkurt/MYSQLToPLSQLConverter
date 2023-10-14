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
            //for (int i = 0; i < queryParser.queryList.Count; i++)
            //{
            //    string currentQuery = queryParser.queryList[i];

            if (queryParser.formattedQuery.Contains("CURDATE()") || queryParser.formattedQuery.Contains("CURDATE ()"))
            {
                queryParser.formattedQuery = queryParser.formattedQuery.Replace("CURDATE()", "TRUNC(SYSDATE)");
                queryParser.formattedQuery = queryParser.formattedQuery.Replace("CURDATE ()", "TRUNC(SYSDATE)");
            }

            if(queryParser.formattedQuery.Contains("CURRENT_DATE()") || queryParser.formattedQuery.Contains("CURRENT_DATE ()")){
                queryParser.formattedQuery = queryParser.formattedQuery.Replace("CURRENT_DATE()", "TRUNC(SYSDATE)");
                queryParser.formattedQuery = queryParser.formattedQuery.Replace("CURRENT_DATE ()", "TRUNC(SYSDATE)");

            }



            //    if (currentQuery.Contains("DATE("))
            //    {
            //        if (currentQuery.Contains("SYSDATE("))
            //        {
            //            queryParser.queryList[i] = currentQuery.Replace("SYSDATE()", "SYSDATE");
            //            continue;
            //        }
            //        if (currentQuery.Contains("ADDDATE("))
            //        {
            //            string date, days, value, addunit, ınterval;
            //            string[] temp;

            //            temp = currentQuery.Split("(");

            //            temp = temp[1].Split(",");

            //            temp = temp[1].Split(" ");
            //            ınterval = temp[1];
            //            value = temp[2];

            //            temp = temp[3].Split(")");
            //            addunit = temp[0];

            //            currentQuery = currentQuery.Replace(",", " +");

            //            if (value.ToString().Contains("'"))
            //            {
            //                currentQuery = currentQuery.Replace("ADDDATE(", "");
            //                currentQuery = currentQuery.Replace(ınterval.ToString(), "NUMTODS" + ınterval.ToString());
            //                currentQuery = currentQuery.Replace(value.ToString(), "(" + value.ToString());
            //                queryParser.queryList[i] = currentQuery.Replace(addunit.ToString(), addunit.ToString());
            //            }
            //            else
            //            {
            //                currentQuery = currentQuery.Replace("ADDDATE(", "");
            //                currentQuery = currentQuery.Replace(value.ToString(), "'" + value.ToString() + "'");
            //                queryParser.queryList[i] = currentQuery.Replace(addunit.ToString() + ")", addunit.ToString());
            //            }

            //        }
            //        else
            //        {
            //            queryParser.queryList[i] = currentQuery.Replace("DATE(", "TO_DATE(");

            //        }

            //    }

            //    if (currentQuery.Contains("DATEDIFF("))
            //    {
            //        string date1, date2;
            //        string[] temp;

            //        temp = currentQuery.Split("(");
            //        temp = temp[1].Split(",");
            //        date1 = temp[0];
            //        temp = temp[1].Split(")");
            //        date2 = temp[0];

            //        currentQuery = currentQuery.Replace("DATEDIFF", "");
            //        currentQuery = currentQuery.Replace("("+ date1," "+date1);
            //        currentQuery = currentQuery.Replace(date2+")",date2);
            //        queryParser.queryList[i] = currentQuery.Replace(",", " -");


            //    }

            //    if (currentQuery.Contains("DATE_ADD("))
            //    {
            //        string date, ınterval, value, addunıt;
            //        string[] temp;

            //        temp = currentQuery.Split("(");

            //        temp = temp[1].ToString().Split(",");

            //        temp = temp[1].ToString().Split(" ");

            //        value = temp[2];


            //        currentQuery = currentQuery.Replace(",", " +");
            //        queryParser.queryList[i] = currentQuery.Replace(" " + value.ToString(), " '" + value.ToString() + "'");

            //    }

        

            if (queryParser.formattedQuery.Contains("DATE_FORMAT"))
            {
                queryParser.formattedQuery = queryParser.formattedQuery.Replace("DATE_FORMAT", "TO_CHAR");
            }


            //    if (currentQuery.Contains("DATE_SUB("))
            //    {
            //        string date, value, ınterval, addunit;

            //        string[] temp;

            //        temp = currentQuery.Split("(");

            //        temp = temp[1].Split(",");
            //        date = temp[0];

            //        temp = temp[1].Split(" ");
            //        ınterval = temp[1];
            //        value = temp[2];

            //        temp = temp[3].Split(")");
            //        addunit = temp[0];

            //        currentQuery = currentQuery.Replace("DATE_SUB(", "");
            //        currentQuery = currentQuery.Replace(",", " -");
            //        currentQuery = currentQuery.Replace(" "+value.ToString(), " '" + value.ToString() + "'");
            //        queryParser.queryList[i] = currentQuery.Replace(addunit.ToString() + ")",addunit.ToString() );

            //    }


            if (queryParser.formattedQuery.Contains("DAY"))
            {

                if (queryParser.formattedQuery.Contains("DAYNAME"))
                {
                    string date;
                    string[] temp;

                    temp = queryParser.formattedQuery.Split("DAYNAME");
                    temp = temp[1].Split(")");
                    date = temp[0].Remove(0,1);

                    queryParser.formattedQuery = queryParser.formattedQuery.Replace("DAYNAME", "TO_CHAR");
                    queryParser.formattedQuery = queryParser.formattedQuery.Replace(date, date + ", 'DAY'");

                }
                    
                if (queryParser.formattedQuery.Contains("DAYOFWEEK(") || queryParser.formattedQuery.Contains("DAYOFWEEK ("))
                {
                    string date;
                    string[] temp;

                    temp = queryParser.formattedQuery.Split("DAYOFWEEK");
                    temp = temp[1].Split(")");
                    date = temp[0].Remove(0, 1);

                    queryParser.formattedQuery = queryParser.formattedQuery.Replace("DAYOFWEEK", "TO_NUMBER(TO_CHAR");
                    queryParser.formattedQuery = queryParser.formattedQuery.Replace(date, date + ", 'D')");

                }

                if (queryParser.formattedQuery.Contains("DAYOFWEEK(") || queryParser.formattedQuery.Contains("DAYOFWEEK ("))
                {
                    string date;
                    string[] temp;

                    temp = queryParser.formattedQuery.Split("DAYOFWEEK");
                    temp = temp[1].Split(")");
                    date = temp[0].Remove(0, 1);

                    queryParser.formattedQuery = queryParser.formattedQuery.Replace("DAYOFWEEK", "TO_NUMBER(TO_CHAR");
                    queryParser.formattedQuery = queryParser.formattedQuery.Replace(date, date + ", 'D')");

                }

                if (queryParser.formattedQuery.Contains("DAYOFYEAR(") || queryParser.formattedQuery.Contains("DAYOFYEAR ("))
                {
                    string date;
                    string[] temp;

                    temp = queryParser.formattedQuery.Split("DAYOFYEAR");
                    temp = temp[1].Split(")");
                    date = temp[0].Remove(0, 1);

                    queryParser.formattedQuery = queryParser.formattedQuery.Replace("DAYOFYEAR", "TO_NUMBER(TO_CHAR");
                    queryParser.formattedQuery = queryParser.formattedQuery.Replace(date, date + ", 'DDD')");

                }

                else if (queryParser.formattedQuery.Contains("DAY(") || queryParser.formattedQuery.Contains("DAY ("))
                {
                    string date;
                    string[] temp;

                    temp = queryParser.formattedQuery.Split("DAY");
                    temp = temp[1].Split(")");
                    date = temp[0].Remove(0, 1);

                    queryParser.formattedQuery = queryParser.formattedQuery.Replace("DAY", "EXTRACT");
                    queryParser.formattedQuery = queryParser.formattedQuery.Replace(date,"DAY FROM "+date);
                }
            }

            

            //    if (currentQuery.Contains("HOUR("))
            //    {
            //        string date;
            //        string[] temp;

            //        temp = currentQuery.Split("(");
            //        temp = temp[1].Split(")");
            //        date = temp[0];


            //        queryParser.queryList[i] = queryParser.queryList[i].Replace("HOUR(", "EXTRACT(HOUR FROM ");
            //    }

            //    if (currentQuery.Contains("MICROSECOND("))
            //    {
            //        string date;
            //        string[] temp;

            //        temp = currentQuery.Split("(");
            //        temp = temp[1].Split(")");
            //        date = temp[0];


            //        currentQuery = currentQuery.Replace("MICROSECOND(", "TO_NUMBER(TO_CHAR(");
            //        queryParser.queryList[i] = currentQuery.Replace(date,date + ", 'FF6')");

            //    }

            //    if (currentQuery.Contains("MINUTE("))
            //    {
            //        string date;
            //        string[] temp;

            //        temp = currentQuery.Split("(");
            //        temp = temp[1].Split(")");
            //        date = temp[0];


            //        queryParser.queryList[i] = currentQuery.Replace("MINUTE(", "EXTRACT(MINUTE FROM ");


            //    }

            //    if (currentQuery.Contains("MONTH("))
            //    {
            //        string date;
            //        string[] temp;

            //        temp = currentQuery.Split("(");
            //        temp = temp[1].Split(")");
            //        date = temp[0];

            //        queryParser.queryList[i] = currentQuery.Replace("MONTH(", "EXTRACT(MONTH FROM ");

            //    }

            //    if (currentQuery.Contains("MONTHNAME("))
            //    {
            //        string date;
            //        string[] temp;

            //        temp = currentQuery.Split("(");
            //        temp = temp[1].Split(")");
            //        date = temp[0];

            //        currentQuery = currentQuery.Replace("MONTHNAME(", "TO_CHAR(");
            //        queryParser.queryList[i] = currentQuery.Replace(date, date + ", 'Month'"); 



            //    }

            //    if (currentQuery.Contains("QUARTER("))
            //    {
            //        string date;
            //        string[] temp;

            //        temp = currentQuery.Split("(");
            //        temp = temp[1].Split(")");
            //        date = temp[0];

            //        currentQuery = currentQuery.Replace("QUARTER(", "TO_NUMBER(TO_CHAR(");
            //        queryParser.queryList[i] = currentQuery.Replace(date, date + ", 'Q'"); 

            //    }

            //    if (currentQuery.Contains("SUBDATE("))
            //    {
            //        string date, ınterval, value, unıt;

            //        string[] temp;

            //        temp = currentQuery.Split("(");

            //        temp = temp[1].Split(",");
            //        date = temp[0];

            //        temp = temp[1].Split(" ");
            //        ınterval = temp[1];
            //        value = temp[2];

            //        temp = temp[3].Split(")");
            //        unıt = temp[0];


            //        queryParser.queryList[i] = currentQuery.Replace("SUBDATE(", "");
            //        queryParser.queryList[i] = currentQuery.Replace(",", " -");
            //        queryParser.queryList[i] = currentQuery.Replace(" " + value, "'" + value + "'");
            //        queryParser.queryList[i] = currentQuery.Replace(unıt + ")", unıt);

            //    }

            // TIME METODUNU TAŞIDIM BURDAN
      


            //    if (currentQuery.Contains("WEEK("))
            //    {
            //        string date;
            //        string[] temp;

            //        temp = currentQuery.Split("(");
            //        temp = temp[1].Split(")");
            //        date = temp[0];


            //        currentQuery = currentQuery.Replace("WEEK(", "TO_NUMBER(TO_CHAR(");
            //        queryParser.queryList[i] = currentQuery.Replace(date, date + ", 'WW')");

            //    }

            //    if (currentQuery.Contains("YEAR("))
            //    {
            //        string date;
            //        string[] temp;

            //        temp = currentQuery.Split("(");
            //        temp = temp[1].Split(")");
            //        date = temp[0];

            //        queryParser.queryList[i] = currentQuery.Replace("YEAR(", "EXTRACT(YEAR FROM ");

            //    }

            
            //}

            if (queryParser.formattedQuery.Contains("NOW()"))
            {
                queryParser.formattedQuery =  queryParser.formattedQuery.Replace("NOW()", "SYSDATE");
            }

            _nextConverterHandler.Convert(queryParser);
        }
    }
}
