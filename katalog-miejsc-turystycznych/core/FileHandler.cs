using System;
using System.Collections.Generic;
using System.Text;

namespace core
{
    internal interface FileHandler
    {
        string ReadFile(string filename);

        void WriteToFile(string filename, string content);
    }
}
