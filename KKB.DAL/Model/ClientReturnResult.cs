using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.DAL.Model
{

    public class ReturnResult<T>
    {
        public T Data { get; set; }
        public List<T> Datas { get; set; }
        public Exception Exception { get; set; }
        public bool isError { get; set; } = false;
    }

}
