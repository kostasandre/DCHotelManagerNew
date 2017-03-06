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
        /// <param name="room">
        /// The billing.
        /// </param>
        /// <returns>
        /// The <see cref="Customer"/>.
        /// </returns>
        public Customer Create(Customer room)
        {
            this.dataBaseContext.Customers.Add(room);
            try
            {
                this.dataBaseContext.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return room;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="customersId"></param>
        /// <param name="entities"></param>
        /// <exception cref="ArgumentNullException">
        /// The customer is null
        /// </exception>
        public void Delete(int[] customersId)
        {
            foreach (var id in customersId)
            {
                var localCustomer = this.dataBaseContext.Customers.SingleOrDefault(x => x.Id == id);
                if (localCustomer == null)
                {
                    throw new ArgumentNullException();
                }

                this.dataBaseContext.Customers.Remove(localCustomer);
                this.dataBaseContext.SaveChanges();
            }
        }

        /// <summary>
        /// The read all list.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{Customer}"/>.
        /// </returns>
        public IEnumerable<Customer> ReadAllList()
        {
            return this.dataBaseContext.Customers.ToList();
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
            return context.Customers;
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