using Serilog;
using SqlConverter.Core.Services.Converters;
using SqlConverter.Domain.Models;

namespace SqlConverter.Infrastructure.Converters
{
    public class NumericFunctionsConverter : BaseConverterHandler
    {
        private const double PI = 3.1415926535897931;

        public NumericFunctionsConverter(ILogger logger) : base(logger)
        {
        }

        protected override bool CanHandle(string query)
        {
            return query.Contains("CEILING") ||
                   query.Contains("COT") ||
                   query.Contains("DEGREES") ||
                   query.Contains("PI") ||
                   query.Contains("RADIANS") ||
                   query.Contains("TRUNCATE");
        }

        protected override void ConvertInternal(QueryParser queryParser)
        {
            var query = queryParser.FormattedQuery;

            if (query.Contains("CEILING"))
            {
                queryParser.UpdateFormattedQuery(query.Replace("CEILING", "CEIL"));
            }
            else if (query.Contains("COT"))
            {
                ConvertCot(queryParser);
            }
            else if (query.Contains("DEGREES"))
            {
                ConvertDegrees(queryParser);
            }
            else if (query.Contains("PI"))
            {
                ConvertPi(queryParser);
            }
            else if (query.Contains("RADIANS"))
            {
                ConvertRadians(queryParser);
            }
            else if (query.Contains("TRUNCATE"))
            {
                queryParser.UpdateFormattedQuery(query.Replace("TRUNCATE", "TRUNC"));
            }
        }

        private void ConvertCot(QueryParser queryParser)
        {
            var query = queryParser.FormattedQuery;
            var splitQuery = ExtractFunctionContent(query, "COT");
            var number = splitQuery;

            queryParser.UpdateFormattedQuery(query.Replace("COT" + splitQuery, 
                $"COS({number})/SIN({number})"));
        }

        private void ConvertDegrees(QueryParser queryParser)
        {
            var query = queryParser.FormattedQuery;
            var splitQuery = ExtractFunctionContent(query, "DEGREES");
            var number = splitQuery;

            queryParser.UpdateFormattedQuery(query.Replace("DEGREES" + splitQuery, 
                $"({number}) * 180/{PI}"));
        }

        private void ConvertPi(QueryParser queryParser)
        {
            var query = queryParser.FormattedQuery;
            var splitQuery = ExtractFunctionContent(query, "PI");

            queryParser.UpdateFormattedQuery(query.Replace("PI" + splitQuery, 
                PI.ToString()));
        }

        private void ConvertRadians(QueryParser queryParser)
        {
            var query = queryParser.FormattedQuery;
            var splitQuery = ExtractFunctionContent(query, "RADIANS");
            var number = splitQuery;

            queryParser.UpdateFormattedQuery(query.Replace("RADIANS" + splitQuery, 
                $"({number}) * {PI}/180"));
        }

        private string ExtractFunctionContent(string query, string functionName)
        {
            var startIndex = query.IndexOf(functionName + "(");
            if (startIndex == -1) return string.Empty;

            var contentStart = startIndex + functionName.Length + 1;
            var bracketCount = 1;
            var contentEnd = contentStart;

            while (bracketCount > 0 && contentEnd < query.Length)
            {
                if (query[contentEnd] == '(') bracketCount++;
                if (query[contentEnd] == ')') bracketCount--;
                contentEnd++;
            }

            return query.Substring(contentStart, contentEnd - contentStart - 1);
        }
    }
} 