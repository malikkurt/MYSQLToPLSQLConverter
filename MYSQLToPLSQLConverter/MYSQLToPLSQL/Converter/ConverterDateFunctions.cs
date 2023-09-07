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

                if (queryParser.queryList[i].Contains("CURDATE()"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace("CURDATE()", "TRUNC(SYSDATE)"); 
                }
                
                if (queryParser.queryList[i].Contains("CURRENT_DATE") && !queryParser.queryList[i].Contains("()"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace("CURRENT_DATE", "TRUNC(SYSDATE)"); 
                }
                
                if (queryParser.queryList[i].Contains("CURRENT_DATE()"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace("CURRENT_DATE()", "TRUNC(SYSDATE)"); 
                }
                
                if (queryParser.queryList[i].Contains("DATE("))
                {
                    if (queryParser.queryList[i].Contains("SYSDATE("))
                    {
                        queryParser.queryList[i] = queryParser.queryList[i].Replace("SYSDATE()", "SYSDATE");
                        continue;
                    }
                    if (queryParser.queryList[i].Contains("ADDDATE("))
                    {
                        string date, days, value, addunit, ınterval;
                        string[] temp;

                        temp = queryParser.queryList[i].Split("(");

                        temp = temp[1].Split(",");
                        date = temp[0];

                        temp = temp[1].Split(" ");
                        ınterval = temp[1];
                        value = temp[2];

                        temp = temp[3].Split(")");
                        addunit = temp[0];

                        queryParser.queryList[i] = queryParser.queryList[i].Replace(",", " +");

                        if (value.ToString().Contains("'"))
                        {
                            queryParser.queryList[i] = queryParser.queryList[i].Replace("ADDDATE(", "");
                            queryParser.queryList[i] = queryParser.queryList[i].Replace(ınterval.ToString(), "NUMTODS" + ınterval.ToString());
                            queryParser.queryList[i] = queryParser.queryList[i].Replace(value.ToString(), "(" + value.ToString());
                            queryParser.queryList[i] = queryParser.queryList[i].Replace(addunit.ToString(), addunit.ToString());
                        }
                        else
                        {
                            queryParser.queryList[i] = queryParser.queryList[i].Replace("ADDDATE(", "");
                            queryParser.queryList[i] = queryParser.queryList[i].Replace(value.ToString(), "'" + value.ToString() + "'");
                            queryParser.queryList[i] = queryParser.queryList[i].Replace(addunit.ToString() + ")", addunit.ToString());
                        }

                    }
                    else
                    {
                        queryParser.queryList[i] = queryParser.queryList[i].Replace("DATE(", "TO_DATE(");

                    }
                    
                }

                if (queryParser.queryList[i].Contains("DATEDIFF("))
                {
                    string date1, date2;
                    string[] temp;

                    temp = queryParser.queryList[i].Split("(");
                    temp = temp[1].Split(",");
                    date1 = temp[0];
                    temp = temp[1].Split(")");
                    date2 = temp[0];

                    queryParser.queryList[i] = queryParser.queryList[i].Replace("DATEDIFF", "");
                    queryParser.queryList[i] = queryParser.queryList[i].Replace("("+ date1," "+date1);
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(date2+")",date2);
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(",", " -");
                    
             
                }

                if (queryParser.queryList[i].Contains("DATE_ADD("))
                {
                    //string date, ınterval, value, addunıt;
                    //string[] temp;

                    //temp = queryParser.queryList[i].Split("(");

                    //temp = temp[1].ToString().Split(",");

                    //date = temp[0];

                    //temp = temp[1].ToString().Split(" ");

                    //value = temp[2];



                    //queryParser.queryList[i] = queryParser.queryList[i].Replace(" " + value.ToString(), " '" + value.ToString() + "'");

                }

                if (queryParser.queryList[i].Contains("DATE_FORMAT("))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace("DATE_FORMAT", "TO_CHAR"); 
                }
                
                if (queryParser.queryList[i].Contains("DATE_SUB("))
                {
                    string date, value, ınterval, addunit;

                    string[] temp;

                    temp = queryParser.queryList[i].Split("(");

                    temp = temp[1].Split(",");
                    date = temp[0];

                    temp = temp[1].Split(" ");
                    ınterval = temp[1];
                    value = temp[2];

                    temp = temp[3].Split(")");
                    addunit = temp[0];

                    queryParser.queryList[i] = queryParser.queryList[i].Replace("DATE_SUB(", "");
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(",", " -");
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(" "+value.ToString(), " '" + value.ToString() + "'");
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(addunit.ToString() + ")",addunit.ToString() );

                }

                if (queryParser.queryList[i].Contains("DAY("))
                {
                    string date;
                    string[] temp;

                    temp = queryParser.queryList[i].Split("(");
                    temp = temp[1].Split(")");
                    date = temp[0];


                    queryParser.queryList[i] = queryParser.queryList[i].Replace("DAY(","EXTRACT(");
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(date, "DAY FROM " + date);
                    
                }

                if (queryParser.queryList[i].Contains("DAYNAME("))
                {
                    string date;
                    string[] temp;

                    temp = queryParser.queryList[i].Split("("); 
                    temp = temp[1].Split(")");
                    date = temp[0];


                    queryParser.queryList[i] = queryParser.queryList[i].Replace("DAYNAME(", "TO_CHAR(");
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(date, date+ ", 'DAY'");

                }

                if (queryParser.queryList[i].Contains("DAYOFWEEK("))
                {
                    string date;
                    string[] temp;

                    temp = queryParser.queryList[i].Split("(");
                    temp = temp[1].Split(")");
                    date = temp[0];


                    queryParser.queryList[i] = queryParser.queryList[i].Replace("DAYOFWEEK(", "TO_NUMBER(TO_CHAR(");
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(date, date + ", 'D')");

                }

                if (queryParser.queryList[i].Contains("DAYOFYEAR("))
                {
                    string date;
                    string[] temp;

                    temp = queryParser.queryList[i].Split("(");
                    temp = temp[1].Split(")");
                    date = temp[0];


                    queryParser.queryList[i] = queryParser.queryList[i].Replace("DAYOFYEAR(", "TO_NUMBER(TO_CHAR(");
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(date, date + ", 'DDD')");

                }

                if (queryParser.queryList[i].Contains("HOUR("))
                {
                    string date;
                    string[] temp;

                    temp = queryParser.queryList[i].Split("(");
                    temp = temp[1].Split(")");
                    date = temp[0];


                    queryParser.queryList[i] = queryParser.queryList[i].Replace("HOUR(", "EXTRACT(HOUR FROM ");
                }

                if (queryParser.queryList[i].Contains("MICROSECOND("))
                {
                    string date;
                    string[] temp;

                    temp = queryParser.queryList[i].Split("(");
                    temp = temp[1].Split(")");
                    date = temp[0];


                    queryParser.queryList[i] = queryParser.queryList[i].Replace("MICROSECOND(", "TO_NUMBER(TO_CHAR(");
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(date,date + ", 'FF6')");

                }

                if (queryParser.queryList[i].Contains("MINUTE("))
                {
                    string date;
                    string[] temp;

                    temp = queryParser.queryList[i].Split("(");
                    temp = temp[1].Split(")");
                    date = temp[0];


                    queryParser.queryList[i] = queryParser.queryList[i].Replace("MINUTE(", "EXTRACT(MINUTE FROM ");
                    

                }

                if (queryParser.queryList[i].Contains("MONTH("))
                {
                    string date;
                    string[] temp;

                    temp = queryParser.queryList[i].Split("(");
                    temp = temp[1].Split(")");
                    date = temp[0];

                    queryParser.queryList[i] = queryParser.queryList[i].Replace("MONTH(", "EXTRACT(MONTH FROM ");

                }

                if (queryParser.queryList[i].Contains("MONTHNAME("))
                {
                    string date;
                    string[] temp;

                    temp = queryParser.queryList[i].Split("(");
                    temp = temp[1].Split(")");
                    date = temp[0];

                    queryParser.queryList[i] = queryParser.queryList[i].Replace("MONTHNAME(", "TO_CHAR(");
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(date, date + ", 'Month'"); 
                    


                }

                if (queryParser.queryList[i].Contains("QUARTER("))
                {
                    string date;
                    string[] temp;

                    temp = queryParser.queryList[i].Split("(");
                    temp = temp[1].Split(")");
                    date = temp[0];

                    queryParser.queryList[i] = queryParser.queryList[i].Replace("QUARTER(", "TO_NUMBER(TO_CHAR(");
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(date, date + ", 'Q'"); 

                }

                if (queryParser.queryList[i].Contains("SUBDATE("))
                {
                    string date, ınterval, value, unıt;

                    string[] temp;

                    temp = queryParser.queryList[i].Split("(");

                    temp = temp[1].Split(",");
                    date = temp[0];

                    temp = temp[1].Split(" ");
                    ınterval = temp[1];
                    value = temp[2];

                    temp = temp[3].Split(")");
                    unıt = temp[0];


                    queryParser.queryList[i] = queryParser.queryList[i] = queryParser.queryList[i].Replace("SUBDATE(", "");
                    queryParser.queryList[i] = queryParser.queryList[i] = queryParser.queryList[i].Replace(",", " -");
                    queryParser.queryList[i] = queryParser.queryList[i] = queryParser.queryList[i].Replace(" " + value, "'" + value + "'");
                    queryParser.queryList[i] = queryParser.queryList[i] = queryParser.queryList[i].Replace(unıt + ")", unıt);

                }

                if (queryParser.queryList[i].Contains("TIME("))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace("TIME(", "TO_TIMESTAMP(");
                }

                if (queryParser.queryList[i].Contains("WEEK("))
                {
                    string date;
                    string[] temp;

                    temp = queryParser.queryList[i].Split("(");
                    temp = temp[1].Split(")");
                    date = temp[0];


                    queryParser.queryList[i] = queryParser.queryList[i].Replace("WEEK(", "TO_NUMBER(TO_CHAR(");
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(date, date + ", 'WW')");

                }

                if (queryParser.queryList[i].Contains("YEAR("))
                {
                    string date;
                    string[] temp;

                    temp = queryParser.queryList[i].Split("(");
                    temp = temp[1].Split(")");
                    date = temp[0];

                    queryParser.queryList[i] = queryParser.queryList[i].Replace("YEAR(", "EXTRACT(YEAR FROM ");

                }

                if (queryParser.queryList[i].Contains("NOW()"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace("NOW()", "SYSDATE"); 
                }

            }

            _nextConverterHandler.Convert(queryParser);
        }
    }
}
