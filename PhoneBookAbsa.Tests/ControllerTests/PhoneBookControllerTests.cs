using System;
using Moq;
using Microsoft.AspNetCore.Mvc;

using PhoneBookAbsa.Controllers;
using PhoneBookAbsa.Models;
using PhoneBookAbsa.Repositories;
using PhoneBookAbsa.DTOs;
using System.Collections;

namespace PhoneBookAbsa.Tests.ControllerTests
{
    public class PhoneBookControllerTests
    {
        [Theory]
        [ClassData(typeof(PhoneBookTestData))]
        public async Task ReturnListOfPhoneBookDTOs(List<PhoneBook> phoneBooks)
        {
            // Arrange
            var mockPhoneBookRepo = new Mock<IPhoneBookRepository>();
            mockPhoneBookRepo.Setup(repo => repo.ListAsync())
                .ReturnsAsync(phoneBooks);
            var controller = new PhoneBookController(mockPhoneBookRepo.Object);

            // Act
            var results = await controller.Get();
            Assert.NotNull(results);
            Assert.Equal(phoneBooks.Count, results.Count);

            foreach(PhoneBook pb in phoneBooks)
            {
                var result = results.Where(d => d.Id == pb.Id).FirstOrDefault();
                Assert.NotNull(result);
                Assert.Equal(pb.Name, result.Name);
                foreach (Entry e in pb.Entries)
                {
                    var eDTO = result.Entries.Where(eDTO => eDTO.Id == e.Id).FirstOrDefault();
                    Assert.NotNull(eDTO);
                    Assert.Equal(e.Name, eDTO.Name);
                    Assert.Equal(e.PhoneNumber, eDTO.PhoneNumber);
                }
            }

        }

        public class PhoneBookTestData :  IEnumerable<object[]>
        { 
            public IEnumerator<object[]> GetEnumerator()
            {
                // Random List
                var count = (new Random()).Next(100);
                var phoneBooks = new List<PhoneBook>();

                for (int i = 1; i <= count; i ++)
                {
                    var r = (new Random()).Next(100);
                    var entries = new List<Entry>();
                    for (int j = 1; j <= r; j++)
                    {
                        entries.Add(new Entry(
                            id: j,
                            name: j.ToString(),
                            phoneNumber: (j * 100).ToString()));
                    }

                    phoneBooks.Add(new PhoneBook(
                        id: i,
                        name: i.ToString(),
                        entries: entries
                    ));
                }
                
                yield return new object[] { phoneBooks };
                yield return new object[] { new List<PhoneBook>() };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

    }
}

