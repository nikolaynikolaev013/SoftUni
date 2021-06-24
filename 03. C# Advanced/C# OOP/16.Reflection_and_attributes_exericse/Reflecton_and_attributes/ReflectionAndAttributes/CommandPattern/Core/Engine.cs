using System;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        public Engine(ICommandInterpreter interpreter)
        {
            this.Interpreter = interpreter;
        }

        public ICommandInterpreter Interpreter { get; set; }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                Console.WriteLine(this.Interpreter.Read(input));
            }
        }
    }
}
