using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.BLL.Model
{
   public class ShortAccount
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public double Balance { get; set; }
        public int Currence { get; set; }
    }
}
