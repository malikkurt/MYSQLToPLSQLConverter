using Serilog;
using SqlConverter.Core.Services.Converters;
using SqlConverter.Domain.Models;

namespace SqlConverter.Infrastructure.Converters
{
    public class QuestionConverter : BaseConverterHandler
    {
        public QuestionConverter(ILogger logger) : base(logger)
        {
        }

        protected override bool CanHandle(string query)
        {
            return query.Contains("?");
        }

        protected override void ConvertInternal(QueryParser queryParser)
        {
            var query = queryParser.FormattedQuery;
            _logger.Information("Converting question mark (?) to colon (:) in query");
            
            queryParser.UpdateFormattedQuery(query.Replace("?", ":"));
        }
    }
} 