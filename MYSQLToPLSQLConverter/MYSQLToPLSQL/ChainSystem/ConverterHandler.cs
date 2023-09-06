using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter
{
    public abstract class ConverterHandler
    {
        protected ConverterHandler _nextConverterHandler;
    
        public void setNextConverterHandler(ConverterHandler nextConverterHandler)
        {
            this._nextConverterHandler = nextConverterHandler;
        }
        public abstract void Convert(QueryParser queryParser);

    }
}
