using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter.Converter
{
    public class ConverterTableName : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {
            // currentQuery kodunu buraya koymadım zaten bütün text için geçerli bu kod

            for (int i = 0; i < queryParser.queryList.Count; i++)
            {
                if (queryParser.queryList[i].Contains("_DBA_"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace("_DBA_", "_DBA.");
                }

                if (queryParser.queryList[i].Contains("FRAMEWORK_"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace("FRAMEWORK_", "FRAMEWORK.");

                }

                
            }
            //_nextConverterHandler.Convert(queryParser);
        }
    }
}
