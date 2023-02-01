using System.Collections;
using PhoneBookAbsa.DTOs;
using PhoneBookAbsa.Models;

namespace PhoneBookAbsa.Tests.DTOTests
{
    public class PhoneBookDTOTests
    {
        [Theory]
        [ClassData(typeof(PhoneBookTestData))]
        public void PhoneBookConversion(PhoneBook pb)
        {
            var pbDTO = new PhoneBookDTO(pb);

            Assert.Equal(pb.Id, pbDTO.Id);
            Assert.Equal(pb.Name, pbDTO.Name);
        }

        public class PhoneBookTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                var r = (new Random()).Next(100);
                var pb = new PhoneBook
                {
                    Id = r,
                    Name = r.ToString()
                };
                

                yield return new object[] { pb };
                yield return new object[] { new PhoneBook() };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}