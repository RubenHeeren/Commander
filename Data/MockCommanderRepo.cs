using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAppCommands()
        {
            var commands = new List<Command>
            {
                new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle" },
                new Command { Id = 1, HowTo = "Cut bread", Line = "Get a knife", Platform = "Yeyeye" },
                new Command { Id = 2, HowTo = "Niffaoniffo", Line = "Kill niffo", Platform = "Niffo" }
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle" };
        }
    }
}
