using System;
namespace _04.Wild_Farm.IO
{
    public interface IWriter
    {
        void Write(string text);
        void WriteLine(string text);
    }
}
