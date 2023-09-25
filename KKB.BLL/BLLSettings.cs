using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KKB.BLL.Model;
using KKB.DAL.Model;

namespace KKB.BLL
{
    public static class BLLSettings
    {
        public static MapperConfiguration Init()
        {
            return new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Client, ClientDTO>().ReverseMap();
                });
        }
    }
}
