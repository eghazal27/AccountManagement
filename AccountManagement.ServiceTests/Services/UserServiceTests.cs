using AccountManagement.Domain.Models;
using AccountManagement.Infrastructure.Data.Repositories;
using AccountManagement.Models;
using AccountManagement.Service.Services;
using AccountManagement.Services;
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace AccountManagement.ServiceTests.Services
{
    [TestFixture]
    public class UserServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<IAccountService> _accountServiceMock;
        private UserService _userService;

        [SetUp]
        public void SetUp()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _accountServiceMock = new Mock<IAccountService>();
            _userService = new UserService(_userRepositoryMock.Object, _accountServiceMock.Object);
        }

        [Test]
        public void CreateUser_WhenUserDoesNotExist_ReturnsNewUser()
        {
            // Arrange
            var userCreationDto = new UserCreationDto
            {
                Name = "John",
                LastName = "Doe",
                Address = "123 Main St",
                PhoneNumber = "555-1234",
                CustomerId = "123456"
            };

            var existingUser = (User)null;
            var newUser = new User
            {
                Name = userCreationDto.Name,
                LastName = userCreationDto.LastName,
                Address = userCreationDto.Address,
                PhoneNumber = userCreationDto.PhoneNumber,
                CustomerId = userCreationDto.CustomerId,
                Accounts = new List<Account>()
            };
            var accountId = Guid.NewGuid().ToString();
            var account = new Account();

            _userRepositoryMock.Setup(repo => repo.GetById(userCreationDto.CustomerId)).Returns(existingUser);
            _accountServiceMock.Setup(service => service.GenerateAccount(userCreationDto, accountId)).Returns(account);

            // Act
            var result = _userService.CreateUser(userCreationDto);

            // Assert
            _userRepositoryMock.Verify(repo => repo.Add(newUser), Times.Once);
            Assert.AreEqual(newUser, result);
            Assert.AreEqual(newUser.Name, result.Name);
            Assert.AreEqual(newUser.LastName, result.LastName);
            Assert.AreEqual(newUser.Address, result.Address);
            Assert.AreEqual(newUser.PhoneNumber, result.PhoneNumber);
            Assert.AreEqual(newUser.CustomerId, result.CustomerId);
            Assert.AreEqual(1, result.Accounts.Count);
            Assert.AreEqual(account, result.Accounts.ToList().FirstOrDefault());
        }

        [Test]
        public void CreateUser_WhenUserExists_ReturnsExistingUser()
        {
            // Arrange
            var userCreationDto = new UserCreationDto
            {
                Name = "John",
                LastName = "Doe",
                Address = "123 Main St",
                PhoneNumber = "555-1234",
                CustomerId = "123456"
            };

            var existingUser = new User();

            _userRepositoryMock.Setup(repo => repo.GetById(userCreationDto.CustomerId)).Returns(existingUser);

            // Act
            var result = _userService.CreateUser(userCreationDto);

            // Assert
            _userRepositoryMock.Verify(repo => repo.Add(It.IsAny<User>()), Times.Never);
            Assert.AreEqual(existingUser, result);
        }

        [Test]
        public void GetUserInformation_WhenUserExists_ReturnsUserInformation()
        {
            // Arrange
            var customerId = "123456";
            var user = new User
            {
                Name = "John",
                LastName = "Doe",
                Address = "123 Main St",
                PhoneNumber = "555-1234",
                Accounts = new List<Account>()
                {
                    new Account
                    {
                        Balance = 100.0,
                        Transactions = new List<AccountTransaction>()
                        {
                            new AccountTransaction
                            {
                                Amount = 50.0,
                                TransactionDate = DateTime.Now,
                                TransactionType = TransactionType.Deposit
                            }
                        }
                    }
                }
            };

            _userRepositoryMock.Setup(repo => repo.GetById(customerId)).Returns(user);

            // Act
            var result = _userService.GetUserInformation(customerId);
            var resultFirstAccount = result.Accounts?.FirstOrDefault();
            var userFirstAccount = user.Accounts?.FirstOrDefault();

            var resultFirstTransaction = resultFirstAccount?.Transactions?.FirstOrDefault();
            var userFirstTransaction = userFirstAccount?.Transactions?.FirstOrDefault();


            // Assert
            _userRepositoryMock.Verify(repo => repo.GetById(customerId), Times.Once);
            Assert.NotNull(result);
            Assert.AreEqual(user.Name, result.Name);
            Assert.AreEqual(user.LastName, result.LastName);
            Assert.AreEqual(user.Address, result.Address);
            Assert.AreEqual(user.PhoneNumber, result.PhoneNumber);
            Assert.IsTrue(result.Accounts?.Any());
            Assert.AreEqual(userFirstAccount?.Balance, resultFirstAccount?.Balance);
            Assert.AreEqual(1, result.Accounts[0].Transactions.Count);
            Assert.AreEqual(userFirstTransaction?.Amount, resultFirstTransaction?.Amount);
            Assert.AreEqual(userFirstTransaction?.TransactionDate, resultFirstTransaction?.TransactionDate);
            Assert.AreEqual(userFirstTransaction?.TransactionType, resultFirstTransaction?.TransactionType);
        }

        [Test]
        public void GetUserInformation_WhenUserDoesNotExist_ReturnsNull()
        {
            // Arrange
            var customerId = "123456";
            var user = (User)null;

            _userRepositoryMock.Setup(repo => repo.GetById(customerId)).Returns(user);

            // Act
            var result = _userService.GetUserInformation(customerId);

            // Assert
            _userRepositoryMock.Verify(repo => repo.GetById(customerId), Times.Once);
            Assert.Null(result);
        }
    }

}
