﻿using PT.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.BL.Repository
{
    public class RepositoryBase<T, ID> where T : class
    {
        protected internal static MyContext dbContext;

        public List<T> GetAll()
        {
            try
            {
                dbContext = new MyContext();
                return dbContext.Set<T>().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public virtual T GetByID(ID id)
        {
            try
            {
                dbContext = new MyContext();
                return dbContext.Set<T>().Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//dosya, veritabanı ve dönüşümde try catch olmalı
        public virtual int Insert(T entity)
        {
            try
            {
                dbContext = dbContext ?? new MyContext();
                dbContext.Set<T>().Add(entity);
                return dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual int Delete(T entity)
        {
            try
            {
                dbContext = dbContext ?? new MyContext();
                dbContext.Set<T>().Remove(entity);
                return dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual int Update()
        {
            try
            {
                dbContext = dbContext ?? new MyContext();
                return dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
