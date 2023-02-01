using System;
namespace PhoneBookAbsa.Models
{
	public class Entry
	{
        public int Id { get; }
        public string? Name { get; }
        public string? PhoneNumber { get; }

        public Entry() { }

        public Entry(int id, string name, string phoneNumber)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}

