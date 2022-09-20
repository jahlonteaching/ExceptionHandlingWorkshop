using ExceptionHandlingWorkshop.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExceptionHandlingWorkshop
{
    [TestClass]
    public class UserReportTestsExcercise2
    {
        [TestMethod]
        public void Check_That_Exceptions_Are_Logged()
        {
            
            string filepath = "users.txt";
            ILog logger = Substitute.For<ILog>();
            IUserRepository userRepository = new UserRepository();
            IFileSystem fileSystem = Substitute.For<IFileSystem>();

            fileSystem.FileExists(filepath).Returns(true);
               
            fileSystem
                .When(x => x.Delete(filepath))
                .Do(x => { throw new UnauthorizedAccessException(); });

            UserReport userReport = new UserReport(logger, userRepository, fileSystem);

            try
            {
                userReport.SaveListOfUsers(filepath);
            }
            catch (Exception) { }

            try
            {
                logger.Received().LogException(Arg.Any<Exception>());
            }
            catch (ReceivedCallsException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Check_That_Method_Returns_False_When_Exception_Thrown()
        {
            string filepath = "users.txt";
            ILog logger = Substitute.For<ILog>();
            IUserRepository userRepository = new UserRepository();
            IFileSystem fileSystem = Substitute.For<IFileSystem>();
            fileSystem
                .When(x => x.FileExists(filepath))
                .Do(x => { throw new UnauthorizedAccessException(); });
            UserReport userReport = new UserReport(logger, userRepository, fileSystem);
            Assert.IsFalse(userReport.SaveListOfUsers(filepath));
        }
    }
}
