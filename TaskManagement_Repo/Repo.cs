using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagement;
using System.Data.Entity;

namespace TaskManagement_Repo
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
       
        void SaveChanges();
    }

    public class Repository<T> : IRepository<T> where T : class
    {
         QuoteEntities Context = new QuoteEntities();

        public Repository()
        {

        }

        //public Repository(QuoteEntities context)
        //{
        //    Context = context;
        //}

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }


        public T GetByID(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            Context.SaveChanges();
            //Context.Entry(entity).State = EntityState.Modified;
        }

        public void Add(T entity)
        {

            Context.Set<T>().Add(entity);
            Context.SaveChanges();

        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
        }



        public void SaveChanges()
        {

            Context.SaveChanges();
        }


    }




}