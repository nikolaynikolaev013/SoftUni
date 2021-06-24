using System;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Commands
{
    public class HelloCommand : ICommand
    {
        public HelloCommand()
        {
        }

        public string Execute(string[] args)
        {
            return $"Hello, {args[0]}";
        }
    }
}
