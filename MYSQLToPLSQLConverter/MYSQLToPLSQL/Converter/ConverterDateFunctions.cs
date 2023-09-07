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
            for (int i = 0; i < queryParser.queryList.Count; i++)
            {
                string queryLıne = queryParser.queryList[i];

                if (queryLıne.Contains("CURDATE()"))
                {
                    queryParser.queryList[i] = queryLıne.Replace("CURDATE()", "TRUNC(SYSDATE)"); 
                }
                
                if (queryLıne.Contains("CURRENT_DATE") && !queryLıne.Contains("()"))
                {
                    queryParser.queryList[i] = queryLıne.Replace("CURRENT_DATE", "TRUNC(SYSDATE)"); 
                }
                
                if (queryLıne.Contains("CURRENT_DATE()"))
                {
                    queryParser.queryList[i] = queryLıne.Replace("CURRENT_DATE()", "TRUNC(SYSDATE)"); 
                }
                
                if (queryLıne.Contains("DATE("))
                {
                    if (queryLıne.Contains("SYSDATE("))
                    {
                        queryParser.queryList[i] = queryLıne.Replace("SYSDATE()", "SYSDATE");
                        continue;
                    }
                    if (queryLıne.Contains("ADDDATE("))
                    {
                        string date, days, value, addunit, ınterval;
                        string[] temp;

                        temp = queryLıne.Split("(");

                        temp = temp[1].Split(",");
                        date = temp[0];

                        temp = temp[1].Split(" ");
                        ınterval = temp[1];
                        value = temp[2];

                        temp = temp[3].Split(")");
                        addunit = temp[0];

                        queryLıne = queryLıne.Replace(",", " +");

                        if (value.ToString().Contains("'"))
                        {
                            queryLıne = queryLıne.Replace("ADDDATE(", "");
                            queryLıne = queryLıne.Replace(ınterval.ToString(), "NUMTODS" + ınterval.ToString());
                            queryLıne = queryLıne.Replace(value.ToString(), "(" + value.ToString());
                            queryParser.queryList[i] = queryLıne.Replace(addunit.ToString(), addunit.ToString());
                        }
                        else
                        {
                            queryLıne = queryLıne.Replace("ADDDATE(", "");
                            queryLıne = queryLıne.Replace(value.ToString(), "'" + value.ToString() + "'");
                            queryParser.queryList[i] = queryLıne.Replace(addunit.ToString() + ")", addunit.ToString());
                        }

                    }
                    else
                    {
                        queryParser.queryList[i] = queryLıne.Replace("DATE(", "TO_DATE(");

                    }
                    
                }

                if (queryLıne.Contains("DATEDIFF("))
                {
                    string date1, date2;
                    string[] temp;

                    temp = queryLıne.Split("(");
                    temp = temp[1].Split(",");
                    date1 = temp[0];
                    temp = temp[1].Split(")");
                    date2 = temp[0];

                    queryLıne = queryLıne.Replace("DATEDIFF", "");
                    queryLıne = queryLıne.Replace("("+ date1," "+date1);
                    queryLıne = queryLıne.Replace(date2+")",date2);
                    queryParser.queryList[i] = queryLıne.Replace(",", " -");
                    
             
                }

                if (queryLıne.Contains("DATE_ADD("))
                {
                    string date, ınterval, value, addunıt;
                    string[] temp;

                    temp = queryLıne.Split("(");

                    temp = temp[1].ToString().Split(",");

                    date = temp[0];

                    temp = temp[1].ToString().Split(" ");

                    value = temp[2];


                    queryLıne = queryLıne.Replace(",", " +");
                    queryParser.queryList[i] = queryLıne.Replace(" " + value.ToString(), " '" + value.ToString() + "'");

                }

                if (queryLıne.Contains("DATE_FORMAT("))
                {
                    queryParser.queryList[i] = queryLıne.Replace("DATE_FORMAT", "TO_CHAR"); 
                }
                
                if (queryLıne.Contains("DATE_SUB("))
                {
                    string date, value, ınterval, addunit;

                    string[] temp;

                    temp = queryLıne.Split("(");

                    temp = temp[1].Split(",");
                    date = temp[0];

                    temp = temp[1].Split(" ");
                    ınterval = temp[1];
                    value = temp[2];

                    temp = temp[3].Split(")");
                    addunit = temp[0];

                    queryLıne = queryLıne.Replace("DATE_SUB(", "");
                    queryLıne = queryLıne.Replace(",", " -");
                    queryLıne = queryLıne.Replace(" "+value.ToString(), " '" + value.ToString() + "'");
                    queryParser.queryList[i] = queryLıne.Replace(addunit.ToString() + ")",addunit.ToString() );

                }

                if (queryLıne.Contains("DAY("))
                {
                    string date;
                    string[] temp;

                    temp = queryLıne.Split("(");
                    temp = temp[1].Split(")");
                    date = temp[0];


                    queryLıne = queryLıne.Replace("DAY(","EXTRACT(");
                    queryParser.queryList[i] = queryLıne.Replace(date, "DAY FROM " + date);
                    
                }

                if (queryLıne.Contains("DAYNAME("))
                {
                    string date;
                    string[] temp;

                    temp = queryLıne.Split("("); 
                    temp = temp[1].Split(")");
                    date = temp[0];


                    queryLıne = queryLıne.Replace("DAYNAME(", "TO_CHAR(");
                    queryParser.queryList[i] = queryLıne.Replace(date, date+ ", 'DAY'");

                }

                if (queryLıne.Contains("DAYOFWEEK("))
                {
                    string date;
                    string[] temp;

                    temp = queryLıne.Split("(");
                    temp = temp[1].Split(")");
                    date = temp[0];


                    queryLıne = queryLıne.Replace("DAYOFWEEK(", "TO_NUMBER(TO_CHAR(");
                    queryParser.queryList[i] = queryLıne.Replace(date, date + ", 'D')");

                }

                if (queryLıne.Contains("DAYOFYEAR("))
                {
                    string date;
                    string[] temp;

                    temp = queryLıne.Split("(");
                    temp = temp[1].Split(")");
                    date = temp[0];


                    queryLıne = queryLıne.Replace("DAYOFYEAR(", "TO_NUMBER(TO_CHAR(");
                    queryParser.queryList[i] = queryLıne.Replace(date, date + ", 'DDD')");

                }

                if (queryLıne.Contains("HOUR("))
                {
                    string date;
                    string[] temp;

                    temp = queryLıne.Split("(");
                    temp = temp[1].Split(")");
                    date = temp[0];


                    queryParser.queryList[i] = queryParser.queryList[i].Replace("HOUR(", "EXTRACT(HOUR FROM ");
                }

                if (queryLıne.Contains("MICROSECOND("))
                {
                    string date;
                    string[] temp;

                    temp = queryLıne.Split("(");
                    temp = temp[1].Split(")");
                    date = temp[0];


                    queryLıne = queryLıne.Replace("MICROSECOND(", "TO_NUMBER(TO_CHAR(");
                    queryParser.queryList[i] = queryLıne.Replace(date,date + ", 'FF6')");

                }

                if (queryLıne.Contains("MINUTE("))
                {
                    string date;
                    string[] temp;

                    temp = queryLıne.Split("(");
                    temp = temp[1].Split(")");
                    date = temp[0];


                    queryParser.queryList[i] = queryLıne.Replace("MINUTE(", "EXTRACT(MINUTE FROM ");
                    

                }

                if (queryLıne.Contains("MONTH("))
                {
                    string date;
                    string[] temp;

                    temp = queryLıne.Split("(");
                    temp = temp[1].Split(")");
                    date = temp[0];

                    queryParser.queryList[i] = queryLıne.Replace("MONTH(", "EXTRACT(MONTH FROM ");

                }

                if (queryLıne.Contains("MONTHNAME("))
                {
                    string date;
                    string[] temp;

                    temp = queryLıne.Split("(");
                    temp = temp[1].Split(")");
                    date = temp[0];

                    queryLıne = queryLıne.Replace("MONTHNAME(", "TO_CHAR(");
                    queryParser.queryList[i] = queryLıne.Replace(date, date + ", 'Month'"); 
                    


                }

                if (queryLıne.Contains("QUARTER("))
                {
                    string date;
                    string[] temp;

                    temp = queryLıne.Split("(");
                    temp = temp[1].Split(")");
                    date = temp[0];

                    queryLıne = queryLıne.Replace("QUARTER(", "TO_NUMBER(TO_CHAR(");
                    queryParser.queryList[i] = queryLıne.Replace(date, date + ", 'Q'"); 

                }

                if (queryLıne.Contains("SUBDATE("))
                {
                    string date, ınterval, value, unıt;

                    string[] temp;

                    temp = queryLıne.Split("(");

                    temp = temp[1].Split(",");
                    date = temp[0];

                    temp = temp[1].Split(" ");
                    ınterval = temp[1];
                    value = temp[2];

                    temp = temp[3].Split(")");
                    unıt = temp[0];


                    queryParser.queryList[i] = queryLıne.Replace("SUBDATE(", "");
                    queryParser.queryList[i] = queryLıne.Replace(",", " -");
                    queryParser.queryList[i] = queryLıne.Replace(" " + value, "'" + value + "'");
                    queryParser.queryList[i] = queryLıne.Replace(unıt + ")", unıt);

                }

                if (queryLıne.Contains("TIME("))
                {
                    queryLıne = queryLıne.Replace("TIME(", "TO_TIMESTAMP(");
                }

                if (queryLıne.Contains("WEEK("))
                {
                    string date;
                    string[] temp;

                    temp = queryLıne.Split("(");
                    temp = temp[1].Split(")");
                    date = temp[0];


                    queryLıne = queryLıne.Replace("WEEK(", "TO_NUMBER(TO_CHAR(");
                    queryParser.queryList[i] = queryLıne.Replace(date, date + ", 'WW')");

                }

                if (queryLıne.Contains("YEAR("))
                {
                    string date;
                    string[] temp;

                    temp = queryLıne.Split("(");
                    temp = temp[1].Split(")");
                    date = temp[0];

                    queryParser.queryList[i] = queryLıne.Replace("YEAR(", "EXTRACT(YEAR FROM ");

                }

                if (queryLıne.Contains("NOW()"))
                {
                    queryParser.queryList[i] =  queryLıne.Replace("NOW()", "SYSDATE"); 
                }

            }

            _nextConverterHandler.Convert(queryParser);
        }
    }
}
