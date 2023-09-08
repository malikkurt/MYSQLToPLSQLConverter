using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter.Converter
{
    internal class ConverterSQLReferences : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {
            for (int i = 0; i < queryParser.queryList.Count; i++)
            {
                string currentQuery = queryParser.queryList[i];

                if (currentQuery.Contains("CHAR_LENGTH("))
                {
                    queryParser.queryList[i] = currentQuery.Replace("CHAR_LENGTH(", "LENGTH(");
                }

                if (currentQuery.Contains("CHARACTER_LENGTH("))
                {
                    queryParser.queryList[i] = currentQuery.Replace("CHARACTER_LENGTH(", "LENGTH(");
                }
                
                if (currentQuery.Contains("CONCAT("))
                {
                    if (currentQuery.Contains("GROUP_CONCAT("))
                    {
                        string distinct, orderBy, separator;
                        string[] temp;

                        temp = queryParser.queryList[i].Split("GROUP_CONCAT(");
                        temp = temp[1].Split(")");

                        string functionContent = temp[0].Trim();

                        if (functionContent.Contains("DISTINCT"))
                        {
                            distinct = "DISTINCT ";
                            functionContent = functionContent.Replace("DISTINCT", "").Trim();
                        }
                        else
                        {
                            distinct = "";
                        }

                        if (functionContent.Contains("ORDER BY"))
                        {
                            int orderByIndex = functionContent.IndexOf("ORDER BY");
                            orderBy = "ORDER BY " + functionContent.Substring(orderByIndex + 8).Trim();
                            functionContent = functionContent.Remove(orderByIndex).Trim();
                        }
                        else
                        {
                            orderBy = "";
                        }

                        if (functionContent.Contains("SEPARATOR"))
                        {
                            int separatorIndex = functionContent.IndexOf("SEPARATOR");
                            separator = "SEPARATOR '" + functionContent.Substring(separatorIndex + 9).Trim() + "'";
                            functionContent = functionContent.Remove(separatorIndex).Trim();
                        }
                        else
                        {
                            separator = "";
                        }

                        string convertedFunction = "LISTAGG(" + distinct + functionContent + ", " + separator + ")";
                        if (!string.IsNullOrEmpty(orderBy))
                        {
                            convertedFunction += " WITHIN GROUP (" + orderBy + ")";
                        }

                        queryParser.queryList[i] = queryParser.queryList[i].Replace("GROUP_CONCAT(" + temp[0] + ")", convertedFunction);
                    }
                    else
                    {
                        string[] expressıon, temp;

                        temp = currentQuery.Split("CONCAT(");
                        temp = temp[1].Split(")");

                        
                        currentQuery = currentQuery.Replace("CONCAT(" + temp[0] + ")", " (" + temp[0].Replace(",", " ||") + ")");
                        queryParser.queryList[i] = currentQuery.Replace("COLLATE utf8_unicode_ci", "");
                    }

                }

                _nextConverterHandler.Convert(queryParser);
            }
        }
    }
}
