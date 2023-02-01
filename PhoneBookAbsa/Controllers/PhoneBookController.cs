using PhoneBookAbsa.Models;
using PhoneBookAbsa.Repositories;
using PhoneBookAbsa.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace PhoneBookAbsa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        readonly IPhoneBookRepository _phoneBookRepository;
        public PhoneBookController(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }

        [HttpGet]
        public async Task<List<PhoneBookDTO>> Get()
        {
            var phoneBooks = await _phoneBookRepository.ListAsync();
            var phoneBookDTOs = new List<PhoneBookDTO>();
            foreach(PhoneBook pb in phoneBooks)
            {
                phoneBookDTOs.Add(new PhoneBookDTO(pb));
            }

            return phoneBookDTOs;
        }
    }
}