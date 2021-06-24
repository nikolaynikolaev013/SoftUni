using System;
namespace Grand_Prix.IO.Contracts
{
    public interface IWriter
    {
        public void CustomWriteLine(string text);
        public void CustomWrite(string text);
    }
}
