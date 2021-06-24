using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {

        public CommandInterpreter()
        {
        }

        public string Read(string args)
        {
            string[] tokens = args.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string command = tokens[0];
            string commandName = command + "Command";

            string[] leftArgs = tokens.Skip(1).ToArray();

            var type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => x.GetInterfaces()
                                    .Any(t => t.Name == nameof(ICommand)))
                .FirstOrDefault(x => x.Name == commandName);

            if (type == null)
            {
                throw new InvalidOperationException("The command is not valid!");
            }

            ICommand obj = Activator.CreateInstance(type) as ICommand;

            return obj.Execute(leftArgs);
        }
    }
}
