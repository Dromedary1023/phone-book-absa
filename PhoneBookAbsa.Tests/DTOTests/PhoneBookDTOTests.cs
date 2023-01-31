using PhoneBookAbsa.DTOs;
using PhoneBookAbsa.Models;

namespace PhoneBookAbsa.Tests.DTOTests
{
    public class PhoneBookDTOTests
    {
        [Fact]
        public void PhoneBookConversion()
        {
            var pb = new PhoneBook
            {
                Id = 1,
                Name = "Test",
            };

            var pbDTO = new PhoneBookDTO(pb);

            Assert.Equal(1, pbDTO.Id);
            Assert.Equal("Test", pbDTO.Name);
        }
    }
}