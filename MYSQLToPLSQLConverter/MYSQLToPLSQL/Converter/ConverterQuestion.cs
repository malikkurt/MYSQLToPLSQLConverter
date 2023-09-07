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
                string queryLıne = queryParser.queryList[i];

                if (queryLıne.Contains(" ?"))
                {
                    queryParser.queryList[i] = queryLıne.Replace("?", ":");
                }

            }
            _nextConverterHandler.Convert(queryParser);
        }

    }
}
