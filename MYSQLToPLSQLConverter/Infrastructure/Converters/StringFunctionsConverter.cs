using Serilog;
using SqlConverter.Core.Services.Converters;
using SqlConverter.Domain.Models;

namespace SqlConverter.Infrastructure.Converters
{
    public class StringFunctionsConverter : BaseConverterHandler
    {
        public StringFunctionsConverter(ILogger logger) : base(logger)
        {
        }

        protected override bool CanHandle(string query)
        {
            return query.Contains("CHAR_LENGTH") ||
                   query.Contains("CHARACTER_LENGTH") ||
                   query.Contains("LCASE") ||
                   query.Contains("LEFT") ||
                   query.Contains("LOCATE") ||
                   query.Contains("POSITION") ||
                   query.Contains("REPEAT") ||
                   query.Contains("RIGHT") ||
                   query.Contains("SPACE") ||
                   query.Contains("SUBSTRING") ||
                   query.Contains("UCASE");
        }

        protected override void ConvertInternal(QueryParser queryParser)
        {
            var query = queryParser.FormattedQuery;

            if (query.Contains("CHAR_LENGTH") || query.Contains("CHARACTER_LENGTH"))
            {
                queryParser.UpdateFormattedQuery(query.Replace("CHAR_LENGTH", "LENGTH")
                                                     .Replace("CHARACTER_LENGTH", "LENGTH"));
            }
            else if (query.Contains("LCASE"))
            {
                queryParser.UpdateFormattedQuery(query.Replace("LCASE", "LOWER"));
            }
            else if (query.Contains("LEFT"))
            {
                ConvertLeft(queryParser);
            }
            else if (query.Contains("LOCATE"))
            {
                queryParser.UpdateFormattedQuery(query.Replace("LOCATE", "INSTR"));
            }
            else if (query.Contains("POSITION"))
            {
                ConvertPosition(queryParser);
            }
            else if (query.Contains("REPEAT"))
            {
                ConvertRepeat(queryParser);
            }
            else if (query.Contains("RIGHT"))
            {
                ConvertRight(queryParser);
            }
            else if (query.Contains("SPACE"))
            {
                ConvertSpace(queryParser);
            }
            else if (query.Contains("SUBSTRING"))
            {
                queryParser.UpdateFormattedQuery(query.Replace("SUBSTRING", "SUBSTR"));
            }
            else if (query.Contains("UCASE"))
            {
                queryParser.UpdateFormattedQuery(query.Replace("UCASE", "UPPER"));
            }
        }

        private void ConvertLeft(QueryParser queryParser)
        {
            var query = queryParser.FormattedQuery;
            var splitQuery = ExtractFunctionContent(query, "LEFT");
            var parameters = splitQuery.Split(",");
            var text = parameters[0];
            var numberOfChars = parameters[1];

            queryParser.UpdateFormattedQuery(query.Replace("LEFT" + splitQuery, 
                $"SUBSTR({text}, 1, {numberOfChars})"));
        }

        private void ConvertPosition(QueryParser queryParser)
        {
            var query = queryParser.FormattedQuery;
            var splitQuery = ExtractFunctionContent(query, "POSITION");
            var parameters = splitQuery.Split("IN");
            var subString = parameters[0];
            var text = parameters[1];

            queryParser.UpdateFormattedQuery(query.Replace("POSITION" + splitQuery, 
                $"INSTR({text}, {subString})"));
        }

        private void ConvertRepeat(QueryParser queryParser)
        {
            var query = queryParser.FormattedQuery;
            var splitQuery = ExtractFunctionContent(query, "REPEAT");
            var parameters = splitQuery.Split(",");
            var text = parameters[0];
            var number = parameters[1];

            queryParser.UpdateFormattedQuery(query.Replace("REPEAT" + splitQuery, 
                $"RPAD({text}, LENGTH({text}) * {number}, {text})"));
        }

        private void ConvertRight(QueryParser queryParser)
        {
            var query = queryParser.FormattedQuery;
            var splitQuery = ExtractFunctionContent(query, "RIGHT");
            var parameters = splitQuery.Split(",");
            var text = parameters[0];
            var numberOfChars = parameters[1];

            queryParser.UpdateFormattedQuery(query.Replace("RIGHT" + splitQuery, 
                $"SUBSTR({text}, GREATEST(-LENGTH({text}), -{numberOfChars})"));
        }

        private void ConvertSpace(QueryParser queryParser)
        {
            var query = queryParser.FormattedQuery;
            var splitQuery = ExtractFunctionContent(query, "SPACE");
            var number = splitQuery;

            queryParser.UpdateFormattedQuery(query.Replace("SPACE" + splitQuery, 
                $"RPAD(' ', {number})"));
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