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
                if (queryParser.queryList[i].Contains(" ?"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace("?", ":");
                }

            }
            _nextConverterHandler.Convert(queryParser);
        }

    }
}
