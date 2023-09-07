using System;
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
            for (int i = 0; i < queryParser.queryList.Count; i++)
            {
                string queryLıne = queryParser.queryList[i];

                if (queryLıne.Contains("LCASE("))
                {
                    queryParser.queryList[i] = queryLıne.Replace("LCASE", "LOWER");
                }

                if (queryLıne.Contains("LEFT("))
                {
                    queryParser.queryList[i] = queryLıne.Replace("LEFT(", "SUBSTR(");

                    string fırstunıt;
                    string[] temp;

                    temp = queryLıne.Split("(");

                    temp = temp[1].Split(",");

                    fırstunıt = temp[0];

                    queryParser.queryList[i] = queryLıne.Replace(fırstunıt, fırstunıt + ", 1");

                }

                if (queryLıne.Contains("LOCATE("))
                {
                    queryParser.queryList[i] = queryLıne.Replace("LOCATE", "INSTR");
                }

                if (queryParser.queryList[i].Contains("POSITION("))
                {
                    //queryParser.queryList[i] = queryParser.queryList[i].Replace(" POSITION(", " INSTR");

                    //string subString, lastString;
                    //string[] temp;


                    //temp = queryParser.queryList[i].Split("(");
                    //temp = temp[1].Split(")");
                    ////temp = temp[0].Split(" ");

                    //foreach (string s in temp)
                    //{
                    //    Console.WriteLine(s);
                    //}
                   
                    //subString = temp[0];
                    //lastString = temp[2];

                    

                    //queryParser.queryList[i] = queryParser.queryList[i].Replace(subString + " IN", lastString);
                   


                }

                if (queryLıne.Contains("REPEAT("))
                {
                    string text, number;
                    string[] temp;

                    temp = queryLıne.Split("(");
                    temp = temp[1].Split(")");
                    temp = temp[0].Split(",");
                    text = temp[0];
                    number = temp[1];

                    queryLıne = queryLıne.Replace("REPEAT(", "RPAD(");
                    queryParser.queryList[i] = queryLıne.Replace(number + ")", " LENGTH(" +text+") * "+number+", "+ text);

                   
                }

                if (queryLıne.Contains("RIGHT("))
                {
                    string text, number;
                    string[] temp;

                    temp = queryLıne.Split("(");
                    temp = temp[1].Split(")");
                    temp = temp[0].Split(",");

                    text = temp[0];
                    number = temp[1];

                    Console.WriteLine(text);
                    Console.WriteLine(number);


                    queryLıne = queryLıne.Replace("RIGHT(", "SUBSTR(");
                    queryParser.queryList[i] = queryLıne.Replace(number, " GREATEST(-LENGTH("+text+"), -" +number +")");




                }
               
                if (queryLıne.Contains("SPACE("))
                {
                    queryParser.queryList[i] = queryLıne.Replace("SPACE(", "RPAD(' ', ");
                }
                
                if (queryLıne.Contains("SUBSTRING("))
                {
                    queryParser.queryList[i] = queryLıne.Replace("SUBSTRING", "SUBSTR");
                }

                if (queryLıne.Contains("UCASE("))
                {
                    queryParser.queryList[i] = queryLıne.Replace("UCASE", "UPPER");
                }

                if (queryLıne.Contains("COT("))
                {
                    string number;
                    string[] temp;

                    temp = queryLıne.Split("(");

                    temp = temp[1].Split(")");
                    number = temp[0];

                    queryParser.queryList[i] = queryLıne.Replace("COT("+ number + ")", "COS(" + number + ")/SIN(" + number + ")");

                }

                if (queryLıne.Contains("DEGREES("))
                {
                    string number;
                    string[] temp;

                    temp = queryLıne.Split("(");

                    temp = temp[1].Split(")");
                    number = temp[0];

                    queryLıne = queryLıne.Replace("DEGREES","");
                    queryParser.queryList[i] = queryLıne.Replace("(" + number + ")", "(" + number + ")" + " * 180/3.1415926535");

                }

                if (queryLıne.Contains("LOG10"))
                {
                    string number;
                    string[] temp;

                    temp = queryLıne.Split("(");
                    temp = temp[1].Split(")");

                    number = temp[0];

                    queryParser.queryList[i] = queryLıne.Replace("LOG10(" + number + ")", "LOG(10," + number + ")");
                }

                if (queryLıne.Contains("PI()"))
                {
                    queryParser.queryList[i] = queryLıne.Replace("PI()", "3.1415926535897931");
                }

                if (queryLıne.Contains("RADIANS("))
                {
                    string number;
                    string[] temp;

                    temp = queryLıne.Split("(");
                    temp = temp[1].Split(")");
                    number = temp[0];

                    queryParser.queryList[i] = queryLıne.Replace("(" + number + ")", "(" + number + ") * " + 3.1415926535 / 180);

                }

                if (queryLıne.Contains("RAND("))
                {
                    if (queryLıne.Contains("*"))
                    {
                        string seed;
                        string[] temp;

                        temp = queryLıne.Split('*');
                        temp = temp[1].Split(";");
                        seed = temp[0];

                        queryParser.queryList[i] = queryLıne.Replace("RAND()", "DBMS_RANDOM.VALUE");

                    }
                    else
                    {
                        string number;
                        string[] temp;

                        temp = queryLıne.Split("(");
                        temp = temp[1].Split(")");
                        number = temp[0];

                        queryParser.queryList[i] = queryLıne.Replace("RAND(" + number + ")", "DBMS_RANDOM.VALUE");
                    }

                }

                if (queryLıne.Contains("TRUNCATE("))
                {
                    queryParser.queryList[i] = queryLıne.Replace("TRUNCATE", "TRUNC");
                }


            }
            _nextConverterHandler.Convert(queryParser);
        }
    }
}
