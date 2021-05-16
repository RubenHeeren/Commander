using Commander.Models;
using System.Collections;
using System.Collections.Generic;

namespace Commander.Data
{
    interface ICommanderRepo
    {
        IEnumerable<Command> GetAppCommands();
        Command GetCommandById(int id);
    }
}
