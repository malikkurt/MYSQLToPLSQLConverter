using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter
{
    public class ConverterQuestion : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {
            for (int i = 0; i < queryParser.queryList.Count; i++)
            {
                string currentQuery = queryParser.queryList[i];

                if (currentQuery.Contains(" ?"))
                {
                    queryParser.queryList[i] = currentQuery.Replace("?", ":");
                }

            }
            _nextConverterHandler.Convert(queryParser);
        }

    }
}
