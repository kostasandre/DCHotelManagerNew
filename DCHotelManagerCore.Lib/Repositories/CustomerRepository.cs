// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The billing repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DCHotelManagerCore.Lib.Repositories
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DCHotelManagerCore.Lib.DbContext;
    using DCHotelManagerCore.Lib.Models.Persistent;
    using DCHotelManagerCore.Lib.Repositories.Interfaces;

    using Microsoft.EntityFrameworkCore;

    #endregion

    /// <summary>
    /// The billing repository.
    /// </summary>
    public class CustomerRepository : IEntityRepository<Customer>
    {
        /// <summary>
        /// The data base context.
        /// </summary>
        private readonly DataBaseContext dataBaseContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        /// <param name="dataBaseContext">
        /// The data base context.
        /// </param>
        public CustomerRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="billing">
        /// The billing.
        /// </param>
        /// <returns>
        /// The <see cref="Customer"/>.
        /// </returns>
        public Customer Create(Customer billing)
        {
            this.dataBaseContext.Customers.Add(billing);
            try
            {
                this.dataBaseContext.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return billing;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// The customer is null
        /// </exception>
        public void Delete(int id)
        {
            var customer = this.dataBaseContext.Customers.SingleOrDefault(x => x.Id == id);
            this.dataBaseContext.Customers.Remove(customer);
            if (customer == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                this.dataBaseContext.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// The read all list.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{Customer}"/>.
        /// </returns>
        public IList<Customer> ReadAllList()
        {
            return this.dataBaseContext.Customers.Include("Bookings").ToList();
        }

        /// <summary>
        /// The read all query.
        /// </summary>
        /// <param name="context">
        /// The dataBaseContext.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<Customer> ReadAllQuery(DataBaseContext context)
        {
            return context.Customers.Include("Bookings");
        }

        /// <summary>
        /// The read one.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Customer"/>.
        /// </returns>
        public Customer ReadOne(int id)
        {
            var customer = this.dataBaseContext.Customers.Include("Bookings").SingleOrDefault(x => x.Id == id);
            return customer;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Update(Customer entity)
        {
            var customer = this.dataBaseContext.Customers.SingleOrDefault(x => x.Id == entity.Id);

            if (customer != null)
            {
                customer.Address = entity.Address;

                // customer.Bookings = entity.Bookings;
                customer.Email = entity.Email;
                customer.IdNumber = entity.IdNumber;
                customer.Name = entity.Name;
                customer.Phone = entity.Phone;
                customer.Surname = entity.Surname;
                customer.TaxId = entity.TaxId;
                customer.Updated = DateTime.Now;
                customer.UpdatedBy = Environment.MachineName;
            }

            try
            {
                this.dataBaseContext.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}