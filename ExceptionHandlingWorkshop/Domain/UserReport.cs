using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlingWorkshop.Domain
{
    public class UserReport
    {
        private readonly IUserRepository _userRepository;
        private readonly IFileSystem _fileSystem;
        private readonly ILog _logger;

        public UserReport(ILog logger, IUserRepository userRepository, IFileSystem fileSystem)
        {
            _logger = logger;
            _userRepository = userRepository;
            _fileSystem = fileSystem;
        }

        public bool SaveListOfUsers(string filePath)
        {
            var allUsers = _userRepository.GetAllUsers();
            var exportData = allUsers.Select(user => $"{user.FirstName} {user.LastName}");

            
            if (_fileSystem.FileExists(filePath))
            {
                _fileSystem.Delete(filePath);
            }

            _fileSystem.WriteAllLines(filePath, exportData);

            return true;
        }

    }
}
