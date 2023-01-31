using System;
using Moq;
using Microsoft.AspNetCore.Mvc;

using PhoneBookAbsa.Controllers;
using PhoneBookAbsa.Models;
using PhoneBookAbsa.Repositories;
using PhoneBookAbsa.DTOs;

namespace PhoneBookAbsa.Tests.ControllerTests
{
	public class PhoneBookControllerTests
	{
		[Fact]
		public async Task ReturnsListOfPhoneBookDTOs()
		{
            // Arrange
			var mockPhoneBookRepo = new Mock<IPhoneBookRepository>();
			mockPhoneBookRepo.Setup(repo => repo.ListAsync())
				.ReturnsAsync(GetTestPhoneBooks());
            var controller = new PhoneBookController(mockPhoneBookRepo.Object);

            // Act
            var result = await controller.Get();

            // Assert
            Assert.IsType<ActionResult<List<PhoneBookDTO>>>(result);

		}

        private List<PhoneBook> GetTestPhoneBooks()
        {
            return new List<PhoneBook>
            {
                new PhoneBook
                {
                    Id = 1,
                    Name ="Adelle Blanchard",
                },
                new PhoneBook
                {
                    Id = 2,
                    Name ="Cary Dumas",
                }
            };
        }
    }
}

