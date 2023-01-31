using PhoneBookAbsa.Models;

namespace PhoneBookAbsa.DTOs
{
    public class PhoneBookDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public PhoneBookDTO() { }
        public PhoneBookDTO(PhoneBook phoneBookItem) =>
        (Id, Name) = (phoneBookItem.Id, phoneBookItem.Name);    
    }
}