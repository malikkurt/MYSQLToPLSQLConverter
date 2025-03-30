using Serilog;
using SqlConverter.Core.Services.Converters;
using SqlConverter.Domain.Models;

namespace SqlConverter.Infrastructure.Converters
{
    public class DateFunctionsConverter : BaseConverterHandler
    {
        public DateFunctionsConverter(ILogger logger) : base(logger)
        {
        }

        protected override bool CanHandle(string query)
        {
            return query.Contains("ADDDATE") || 
                   query.Contains("CURDATE") || 
                   query.Contains("CURRENT_DATE") ||
                   query.Contains("DATE") ||
                   query.Contains("DATEDIFF") ||
                   query.Contains("DATE_ADD") ||
                   query.Contains("DATE_FORMAT") ||
                   query.Contains("DAY") ||
                   query.Contains("HOUR");
        }

        protected override void ConvertInternal(QueryParser queryParser)
        {
            var query = queryParser.FormattedQuery;

            if (query.Contains("ADDDATE"))
            {
                ConvertAddDate(queryParser);
            }
            else if (query.Contains("CURDATE") || query.Contains("CURRENT_DATE"))
            {
                queryParser.UpdateFormattedQuery(query.Replace("CURDATE()", "TRUNC(SYSDATE)")
                                                     .Replace("CURDATE ()", "TRUNC(SYSDATE)")
                                                     .Replace("CURRENT_DATE()", "TRUNC(SYSDATE)")
                                                     .Replace("CURRENT_DATE ()", "TRUNC(SYSDATE)"));
            }
            else if (query.Contains("DATE"))
            {
                queryParser.UpdateFormattedQuery(query.Replace("DATE (", "TO_DATE (")
                                                     .Replace("DATE(", "TO_DATE("));
            }
            else if (query.Contains("DATEDIFF"))
            {
                ConvertDateDiff(queryParser);
            }
            else if (query.Contains("DATE_ADD"))
            {
                ConvertDateAdd(queryParser);
            }
            else if (query.Contains("DATE_FORMAT"))
            {
                queryParser.UpdateFormattedQuery(query.Replace("DATE_FORMAT", "TO_CHAR"));
            }
            else if (query.Contains("DAY"))
            {
                ConvertDayFunctions(queryParser);
            }
            else if (query.Contains("HOUR"))
            {
                ConvertHour(queryParser);
            }
        }

        private void ConvertAddDate(QueryParser queryParser)
        {
            var query = queryParser.FormattedQuery;
            var splitQuery = query.Split("ADDDATE");
            var baseTemp = splitQuery[1];
            var temp = splitQuery[1].Split(")");
            temp = temp[0].Split(",");
            var date = temp[0].Remove(0, 1);
            temp = temp[1].Split("INTERVAL");
            temp = temp[1].Split(" ");
            var value = temp[1];
            var addunit = temp[2];

            queryParser.UpdateFormattedQuery(query.Replace(baseTemp, date + " + INTERVAL '" + value + "' " + addunit)
                                                 .Replace("ADDDATE", ""));
        }

        private void ConvertDateDiff(QueryParser queryParser)
        {
            var query = queryParser.FormattedQuery;
            var temp = query.Split("DATEDIFF");
            temp = temp[1].Split(')');
            temp = temp[0].Split(",");
            var date_1 = temp[0].Remove(0, 1);
            var date_2 = temp[1];

            queryParser.UpdateFormattedQuery(query.Replace("(" + date_1 + "," + date_2 + ")", date_1 + "-" + date_2)
                                                 .Replace("DATEDIFF", ""));
        }

        private void ConvertDateAdd(QueryParser queryParser)
        {
            var query = queryParser.FormattedQuery;
            var temp = query.Split("DATE_ADD");
            var baseTemp = temp[1];
            temp = temp[1].Split(")");
            temp = temp[0].Split("INTERVAL");
            temp = temp[1].Split(" ");
            var value = temp[1];
            var afterTemp = baseTemp.Replace(value, "'" + value + "'");

            queryParser.UpdateFormattedQuery(query.Replace(baseTemp, afterTemp));
        }

        private void ConvertDayFunctions(QueryParser queryParser)
        {
            var query = queryParser.FormattedQuery;

            if (query.Contains("DAYNAME"))
            {
                var temp = query.Split("DAYNAME");
                temp = temp[1].Split(")");
                var date = temp[0].Remove(0, 1);

                queryParser.UpdateFormattedQuery(query.Replace("DAYNAME", "TO_CHAR")
                                                     .Replace(date, date + ", 'DAY'"));
            }
            else if (query.Contains("DAYOFWEEK"))
            {
                var temp = query.Split("DAYOFWEEK");
                temp = temp[1].Split(")");
                var date = temp[0].Remove(0, 1);

                queryParser.UpdateFormattedQuery(query.Replace("DAYOFWEEK", "TO_NUMBER(TO_CHAR)")
                                                     .Replace(date, date + ", 'D')"));
            }
            else if (query.Contains("DAYOFYEAR"))
            {
                var temp = query.Split("DAYOFYEAR");
                temp = temp[1].Split(")");
                var date = temp[0].Remove(0, 1);

                queryParser.UpdateFormattedQuery(query.Replace("DAYOFYEAR", "TO_NUMBER(TO_CHAR)")
                                                     .Replace(date, date + ", 'DDD')"));
            }
            else if (query.Contains("DAY"))
            {
                var temp = query.Split("DAY");
                temp = temp[1].Split(")");
                var date = temp[0].Remove(0, 1);

                queryParser.UpdateFormattedQuery(query.Replace("DAY", "EXTRACT")
                                                     .Replace(date, "DAY FROM " + date));
            }
        }

        private void ConvertHour(QueryParser queryParser)
        {
            var query = queryParser.FormattedQuery;
            var temp = query.Split("HOUR");
            temp = temp[1].Split(")");
            var datetime = temp[0].Remove(0, 1);

            queryParser.UpdateFormattedQuery(query.Replace("HOUR", "EXTRACT")
                                                 .Replace(datetime, "HOUR FROM " + datetime));
        }
    }
} 