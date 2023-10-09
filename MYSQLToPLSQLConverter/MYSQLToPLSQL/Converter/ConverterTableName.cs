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

            if (queryParser.formattedQuery.Contains("_DBA_")){
                queryParser.formattedQuery = queryParser.formattedQuery.Replace("_DBA_", "_DBA.");
            }

            if (queryParser.formattedQuery.Contains("_DBA_"))
            {
                queryParser.formattedQuery = queryParser.formattedQuery.Replace("FRAMEWORK_", "FRAMEWORK.");
            }

            _nextConverterHandler.Convert(queryParser);
            }
        }
    }

