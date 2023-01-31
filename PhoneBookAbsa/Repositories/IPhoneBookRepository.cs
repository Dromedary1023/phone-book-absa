namespace PhoneBookAbsa.Repositories
{
    public interface IPhoneBookRepository
    {
        public Task<List<PhoneBookAbsa.Models.PhoneBook>> ListAsync();
    }
}