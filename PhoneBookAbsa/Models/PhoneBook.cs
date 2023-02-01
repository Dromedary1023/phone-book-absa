namespace PhoneBookAbsa.Models
{
    public class PhoneBook
    {
        public int Id {get;}
        public string? Name {get;}
        public IList<Entry> Entries { get; }

        public PhoneBook()
        {
            Entries = new List<Entry>();
        }

        public PhoneBook(int id, string name, IList<Entry> entries)
        {
            Id = id;
            Name = name;
            Entries = entries?? new List<Entry>();
        }
    }
}