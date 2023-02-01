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
            Assert.Equal(pb.Entries.Count, pbDTO.Entries.Count);

            foreach (Entry e in pb.Entries)
            {
                var eDTO = pbDTO.Entries.Where(eDTO => eDTO.Id == e.Id).FirstOrDefault();
                Assert.NotNull(eDTO);
                Assert.Equal(e.Name, eDTO.Name);
                Assert.Equal(e.PhoneNumber, eDTO.PhoneNumber);
            }
        }

        public class PhoneBookTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                var r = (new Random()).Next(100);
                var entries = new List<Entry>();
                for (int i = 1; i <= r; i++)
                {
                    entries.Add(new Entry(
                        id: i,
                        name: i.ToString(),
                        phoneNumber: (i * 100).ToString()));
                }
                var pb = new PhoneBook(
                    id: r,
                    name: r.ToString(),
                    entries: entries
                );
               

                yield return new object[] { pb };
                yield return new object[] { new PhoneBook() };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}