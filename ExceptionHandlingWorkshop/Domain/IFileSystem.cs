using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlingWorkshop.Domain
{
    public interface IFileSystem
    {
        public bool FileExists(string filePath);
        public void Delete(string filePath);
        public void WriteAllLines(string filePath, IEnumerable<string> exportData);
    }
}
