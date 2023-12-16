using SqlConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter.Converter
{
    internal class ConverterNumericFunctions : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {
            
            if(checkContains("CEILING", queryParser))
            {
                queryParser.formattedQuery = queryParser.formattedQuery.Replace("CEILING", "CEIL");
            }

            if(checkContains("COT", queryParser))
            {
                string splitQuery = tempQuery("COT", queryParser);
                string number;

                string[] temp = splitQuery.Split("(");
                temp = temp[1].Split(")");

                number = temp[0];

                queryParser.formattedQuery = queryParser.formattedQuery.Replace("COT" + splitQuery, "COS(" + number + ")/SIN(" + number + ")");
            }

            if(checkContains("DEGREES", queryParser))
            {
                string splitQuery = tempQuery("DEGREES", queryParser);
                string number;

                string[] temp = splitQuery.Split("(");
                temp = temp[1].Split(")");

                number = temp[0];

                queryParser.formattedQuery = queryParser.formattedQuery.Replace("DEGREES" + splitQuery, "(" + number + ") * 180/3.1415926535");
            }

            // DIV FONKSİYONU

            if(checkContains("PI", queryParser))
            {
                string splitQuery = tempQuery("PI", queryParser);

                queryParser.formattedQuery = queryParser.formattedQuery.Replace("PI" + splitQuery, "3.1415926535897931");
            }

            if (checkContains("RADIANS", queryParser))
            {
                string splitQuery = tempQuery("RADIANS", queryParser);
                string number;

                string[] temp = splitQuery.Split(")");
                temp = temp[0].Split("(");

                number = temp[1];

                queryParser.formattedQuery = queryParser.formattedQuery.Replace("RADIANS" + splitQuery, "(" + number + ") * 3.1415926535/180");
            }

            // RAND FONKSİYONU 

            if(checkContains("TRUNCATE", queryParser))
            {
                queryParser.formattedQuery = queryParser.formattedQuery.Replace("TRUNCATE", "TRUNC");
            }
        }
    }
}
