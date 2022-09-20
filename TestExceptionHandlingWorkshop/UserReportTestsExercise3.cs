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
    public class UserReportTestsExercise3
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
                .Do(x => { throw new NullReferenceException(); });
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
        public void Check_InvalidOperationException_Thrown()
        {
            string expectedMsg = "Could not create the report, check logs for more details";
            string filepath = "users.txt";
            ILog logger = Substitute.For<ILog>();
            IUserRepository userRepository = new UserRepository();
            IFileSystem fileSystem = Substitute.For<IFileSystem>();
            NullReferenceException exception = new NullReferenceException();
            fileSystem
                .When(x => x.FileExists(filepath))
                .Do(x => { throw exception; });
            UserReport userReport = new UserReport(logger, userRepository, fileSystem);
            InvalidOperationException ex = Assert.ThrowsException<InvalidOperationException>(() => userReport.SaveListOfUsers("users.txt"));
            Assert.AreEqual(expectedMsg, ex.Message);
            Assert.AreSame(exception, ex.InnerException);
        }
    }
}
