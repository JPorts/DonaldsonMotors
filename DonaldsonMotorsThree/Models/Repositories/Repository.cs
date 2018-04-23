using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree.Models.Repositories
{
    // Repository using generics for specific repositories to inherit form//
    public class Repository<T> where T : class
    {

        // Initialise Context //
        private ApplicationDbContext _context = new ApplicationDbContext();

        // Initialise generic DbSet // 
        protected DbSet<T> DbSet { get; set; }


        // Constructor //
        public Repository()
        {
            DbSet = _context.Set<T>();
        }

        // Repository base methods //
        public List<T> GetAll()
        {
            return DbSet.ToList();
        }

        public T Get(int id)
        {
            return DbSet.Find(id);
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }



    }
}