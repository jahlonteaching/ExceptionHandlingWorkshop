using ExceptionHandlingWorkshop.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.Exceptions;
using System;

namespace TestExceptionHandlingWorkshop
{
    [TestClass]
    public class UserReportTestsExercise1
    {
        [TestMethod]
        public void Check_That_Exceptions_Are_Logged()
        {
            string filepath = "users.txt";
            ILog logger = Substitute.For<ILog>();
            IUserRepository userRepository = new UserRepository();
            IFileSystem fileSystem = Substitute.For<IFileSystem>();
            fileSystem
                .When(x => x.FileExists(filepath))
                .Do(x => { throw new Exception(); });
            UserReport userReport = new UserReport(logger, userRepository, fileSystem);

            try
            {
                userReport.SaveListOfUsers(filepath);
            }catch (Exception ex) { }

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
        public void Check_Exception_Thrown()
        {
            string filepath = "users.txt";
            ILog logger = Substitute.For<ILog>();
            IUserRepository userRepository = new UserRepository();
            IFileSystem fileSystem = Substitute.For<IFileSystem>();
            fileSystem
                .When(x => x.FileExists(filepath))
                .Do(x => { throw new Exception(); });
            UserReport userReport = new UserReport(logger, userRepository, fileSystem);
            Assert.ThrowsException<Exception>(() => userReport.SaveListOfUsers("users.txt"));
        }
    }
}