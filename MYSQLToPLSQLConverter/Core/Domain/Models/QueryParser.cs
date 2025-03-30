namespace SqlConverter.Domain.Models
{
    public class QueryParser
    {
        public string OriginalQuery { get; private set; }
        public string FormattedQuery { get; set; }
        public List<string> QueryList { get; set; }

        public QueryParser(string query)
        {
            OriginalQuery = query;
            FormattedQuery = query;
            QueryList = new List<string>();
        }

        public void AddToQueryList(string query)
        {
            QueryList.Add(query);
        }

        public void UpdateFormattedQuery(string newQuery)
        {
            FormattedQuery = newQuery;
        }
    }
} 