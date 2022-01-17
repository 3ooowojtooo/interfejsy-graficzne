using System;
using System.Collections.Generic;
using System.Text;

namespace core
{
    public interface FileHandler
    {
        string ReadFile(string filename);

        void WriteToFile(string filename, string content);
    }
}
