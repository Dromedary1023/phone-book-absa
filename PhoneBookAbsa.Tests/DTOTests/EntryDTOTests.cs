using System.Collections;
using PhoneBookAbsa.DTOs;
using PhoneBookAbsa.Models;

namespace PhoneBookAbsa.Tests.DTOTests
{
    public class EntryDTOTests
    {
        [Theory]
        [ClassData(typeof(EntryTestData))]
        public void EntryConversion(Entry e)
        {
            var eDTO = new EntryDTO(e);

            Assert.Equal(e.Id, eDTO.Id);
            Assert.Equal(e.Name, eDTO.Name);
            Assert.Equal(e.PhoneNumber, eDTO.PhoneNumber);
        }

        public class EntryTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                var r = (new Random()).Next(100);
                var e = new Entry(
                    id: r,
                    name: r.ToString(),
                    phoneNumber: (r * 100).ToString());
                

                yield return new object[] { e };
                yield return new object[] { new Entry() };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}