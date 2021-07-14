using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public interface IParcelFileHandler
    {
        public Container Deserialize(string filePath);
    }
}
