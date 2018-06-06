// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="Repository.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree.Models.Repositories
{
    // Repository using generics for specific repositories to inherit form//
    /// <summary>
    /// Class Repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> where T : class
    {

        // Initialise Context //
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context = new ApplicationDbContext();


        // Initialise Generic DbSet // 
        /// <summary>
        /// Gets or sets the database set.
        /// </summary>
        /// <value>The database set.</value>
        protected DbSet<T> DbSet { get; set; }


        // Constructor //
        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}" /> class.
        /// </summary>
        public Repository()
        {
            DbSet = _context.Set<T>();
        }



        // Repository base methods //
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>List&lt;T&gt;.</returns>
        public virtual List<T> GetAll()
        {
            return DbSet.ToList();
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        public virtual T Get(int id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Add(T entity)
        {
            DbSet.Add(entity);
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }



    }
}