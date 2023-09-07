
using BasicSQLFormatter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SqlConverter
{
    public class QueryParser
    {
        public List<string> queryList = new List<string>();
            public QueryParser(string _query)
            {
                string[] strings = _query.Split("\r\n");
                foreach (string s in strings)
                {
                    if (s == "")
                    {

                    }
                    else
                    {

                        queryList.Add(s.Replace(" (", "("));
                    }
                }
            }
    }
}
