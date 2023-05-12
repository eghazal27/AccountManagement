using AccountManagement.Domain.DTOs;
using AccountManagement.Domain.Models;
using System.Text.Json.Serialization;

namespace AccountManagement.Models
{
    public class UserCreationDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerId { get; set; }
        public double InitialCredit { get; set; }
    }
    public class UserInformationDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<AccountInformationDto> Accounts { get; set; }
    }
    public class AccountInformationDto
    {
        public double Balance { get; set; }
        public List<TransactionDto> Transactions { get; set; }
    }

}
