using PhoneBookAbsa.Models;
using PhoneBookAbsa.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace PhoneBookAbsa.Repositories
{
    public class PhoneBookRepository : IPhoneBookRepository
    {
        public Task<List<PhoneBook>> ListAsync()
        {
            using (var context = new PhoneBookDb())
            {
                return
                    context.PhoneBooks
                    .ToListAsync();
            }
        }
    }
}