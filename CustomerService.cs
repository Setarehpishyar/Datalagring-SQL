using ProjectManagementApp.Data;
using ProjectManagementApp.Models;
using System.Linq;

namespace ProjectManagementApp.Services
{
    public class CustomerService
    {
        private readonly AppDbContext _context;

        public CustomerService(AppDbContext context)
        {
            _context = context;
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public IQueryable<Customer> GetCustomers()
        {
            return _context.Customers;
        }
    }
}

