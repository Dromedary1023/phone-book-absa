using PhoneBookAbsa.Models;

namespace PhoneBookAbsa.DTOs
{
    public class EntryDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }

        public EntryDTO() { }
        public EntryDTO(Entry entry) =>
        (Id, Name, PhoneNumber) = (entry.Id, entry.Name, entry.PhoneNumber);
    }
}