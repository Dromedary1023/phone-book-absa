using Microsoft.EntityFrameworkCore;
using PhoneBookAbsa.Models;

namespace PhoneBookAbsa.DbContexts
{
    class PhoneBookDb : DbContext
    {
        protected override void OnConfiguring
        (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "PhoneBookDb");
        }

        public DbSet<PhoneBook> PhoneBooks => Set<PhoneBook>();
}
}