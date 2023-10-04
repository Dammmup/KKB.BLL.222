using AutoMapper;
using KKB.DAL;
using KKB.DAL.Interfaces;
using KKB.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.BLL.Model
{
    public abstract class Service<T>
    {
        protected readonly IRepository<Client> repo=null;
        protected readonly IMapper iMapper = null;
        public Service() { }
        public Service(string connectionString)
        {
            repo = new Repository<Client>(connectionString);
            iMapper = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Client, ClientDTO>().ReverseMap();
                    cfg.CreateMap<Account, AccountDTO>().ReverseMap();
                }).CreateMapper();
        }

    }
}
