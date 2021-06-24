using System;
namespace _03.Raiding.IO
{
    public interface IWriter
    {
        void Write(string text);
        void WriteLine(string text);
    }
}
