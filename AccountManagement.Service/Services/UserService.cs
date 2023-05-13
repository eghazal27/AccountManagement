// UserService.cs

using AccountManagement.Models;
using AccountManagement.Infrastructure.Data.Repositories;
using AccountManagement.Domain.Models;
using AccountManagement.Domain.DTOs;
using AccountManagement.Service.Excpetions;
using AccountManagement.Service.Services;

namespace AccountManagement.Services
{
    public interface IUserService
    {
        User CreateUser(UserCreationDto userCreationDto);
        UserInformationDto GetUserInformation(string customerId);
        List<UserInformationDto> GetAllUserInformation();
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountService _accountService;

        public UserService(IUserRepository userRepository, IAccountService accountService)
        {
            _userRepository = userRepository;
            _accountService = accountService;
        }

        public User CreateUser(UserCreationDto userCreationDto)
        {
            //Check If user exists, return existing user.
            var user = _userRepository.GetById(userCreationDto.CustomerId);

            user ??= new User()
                {
                    Name = userCreationDto.Name,
                    LastName = userCreationDto.LastName,
                    Address = userCreationDto.Address,
                    PhoneNumber = userCreationDto.PhoneNumber,
                    CustomerId = userCreationDto.CustomerId,
                };

            var accountId = Guid.NewGuid().ToString();
            user.Accounts = new List<Account>()
            {
                _accountService.GenerateAccount(userCreationDto, accountId)
            };


            _userRepository.Add(user);

            return user;
        }
        public UserInformationDto GetUserInformation(string customerId)
        {
            var user = _userRepository.GetById(customerId);

            if (user==null) return null;

            var userInformation = new UserInformationDto
            {
                Name = user.Name,
                LastName = user.LastName,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                Accounts = new List<AccountInformationDto>()
            };

            foreach (var account in user.Accounts)
            {
                var accountInformation = new AccountInformationDto
                {
                    Balance = account.Balance,
                    Transactions = new List<TransactionDto>()
                };

                foreach (var transaction in account.Transactions)
                {
                    var transactionDto = new TransactionDto
                    {
                        Amount = transaction.Amount,
                        TransactionDate = transaction.TransactionDate,
                        TransactionType = transaction.TransactionType
                    };

                    accountInformation.Transactions.Add(transactionDto);
                }

                userInformation.Accounts.Add(accountInformation);
            }

            return userInformation;
        }
        public List<UserInformationDto> GetAllUserInformation()
        {
            var users = _userRepository.GetAll();

            var userInformationList = new List<UserInformationDto>();

            foreach (var user in users)
            {
                var userInformation = new UserInformationDto
                {
                    Name = user.Name,
                    LastName = user.LastName,
                    Address = user.Address,
                    PhoneNumber = user.PhoneNumber,
                    Accounts = new List<AccountInformationDto>()
                };

                foreach (var account in user.Accounts)
                {
                    var accountInformation = new AccountInformationDto
                    {
                        Balance = account.Balance,
                        Transactions = new List<TransactionDto>()
                    };

                    foreach (var transaction in account.Transactions)
                    {
                        var transactionDto = new TransactionDto
                        {
                            Amount = transaction.Amount,
                            TransactionDate = transaction.TransactionDate,
                            TransactionType = transaction.TransactionType
                        };

                        accountInformation.Transactions.Add(transactionDto);
                    }

                    userInformation.Accounts.Add(accountInformation);
                }

                userInformationList.Add(userInformation);
            }

            return userInformationList;
        }
    }
}
