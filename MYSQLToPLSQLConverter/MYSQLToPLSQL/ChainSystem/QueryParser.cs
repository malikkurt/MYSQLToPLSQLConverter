using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicSQLFormatter;


namespace SqlConverter
{
    public class QueryParser
    {

        public string formattedQuery;
            public QueryParser(string _query)
            {
            formattedQuery = new SQLFormatter(_query).Format();
                
            }
    }
}
