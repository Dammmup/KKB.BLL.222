using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KKB.DAL.Interfaces;
using KKB.DAL.Model;
using LiteDB;
namespace KKB.DAL
{
    public class Repository<T> : IRepository<T> //Account
    {
        private readonly string connectionString = "";
        public Repository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public ReturnResult<T> Get()
        {
            ReturnResult<T> result = new ReturnResult<T>();
            try
            {
                using (var db = new LiteDatabase(connectionString))
                {
                    result.Datas = db.GetCollection<T>(typeof(T).Name)
                        .FindAll()
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                result.isError = true;
                result.Exception = ex;
               
            }
            return result;
        }
        public ReturnResult<T> Create(T data)
        {
            ReturnResult<T> result= new ReturnResult<T>();
            try
            {
                using (var db = new LiteDatabase(connectionString))
                {
                    var accounts = db.GetCollection<T>(typeof(T).Name);

                    accounts.Insert(data);
                }
            }
            catch (Exception ex)
            {
                result.isError= true;
                result.Exception = ex;
            }
         
            return result;
        }
        public ReturnResult<T> Update(T data)
        {
            ReturnResult<T> result=new ReturnResult<T>();
            try
            {
                using (var db = new LiteDatabase(connectionString))
                {
                    var clients = db.GetCollection<T>(typeof(T).Name);
                    result.isError = clients.Update(data);
                    
                }
            }
            catch (Exception ex)
            {
                result.isError = true;
                result.Exception = ex;
            }
            return result;
        }
        public ReturnResult<T> GetData(int id)
        {
            ReturnResult<T> result = new ReturnResult<T>();
            try
            {
                using (var db = new LiteDatabase(connectionString))
                {
                    result.Data = db.GetCollection<T>(typeof(T).Name)
                        .FindById(id);
                    
                }
            }
            catch (Exception ex)
            {

                result.isError = true;
                result.Exception = ex;
            }
            return result;
        }
    }
    public class RepoToSql
    {

    }
}
