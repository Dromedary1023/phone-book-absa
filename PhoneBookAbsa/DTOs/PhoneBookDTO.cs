using PhoneBookAbsa.Models;

namespace PhoneBookAbsa.DTOs
{
    public class PhoneBookDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IList<EntryDTO> Entries { get; set; }

        public PhoneBookDTO(PhoneBook pb) =>
        (Id, Name, Entries) = (
            pb.Id,
            pb.Name,
            pb.Entries
                .Select(e => new EntryDTO(e))
                .ToList()
            );    
    }
}