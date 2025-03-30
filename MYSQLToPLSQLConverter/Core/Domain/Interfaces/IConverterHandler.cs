using SqlConverter.Domain.Models;

namespace SqlConverter.Domain.Interfaces
{
    public interface IConverterHandler
    {
        void SetNextHandler(IConverterHandler handler);
        void Convert(QueryParser queryParser);
        bool CanHandle(string query);
    }
} 