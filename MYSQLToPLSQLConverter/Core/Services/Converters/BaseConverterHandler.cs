using SqlConverter.Domain.Interfaces;
using SqlConverter.Domain.Models;
using Serilog;

namespace SqlConverter.Core.Services.Converters
{
    public abstract class BaseConverterHandler : IConverterHandler
    {
        protected IConverterHandler _nextHandler;
        protected readonly ILogger _logger;

        protected BaseConverterHandler(ILogger logger)
        {
            _logger = logger;
        }

        public void SetNextHandler(IConverterHandler handler)
        {
            _nextHandler = handler;
        }

        public virtual void Convert(QueryParser queryParser)
        {
            try
            {
                if (CanHandle(queryParser.FormattedQuery))
                {
                    _logger.Information($"Converting query using {GetType().Name}");
                    ConvertInternal(queryParser);
                }
                else if (_nextHandler != null)
                {
                    _nextHandler.Convert(queryParser);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error in {GetType().Name} while converting query");
                throw;
            }
        }

        protected abstract bool CanHandle(string query);
        protected abstract void ConvertInternal(QueryParser queryParser);
    }
} 