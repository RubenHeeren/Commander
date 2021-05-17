using Commander.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    /// <summary>
    /// In your context class you can specify (among other things) which tables Entity Framework should generate.
    /// </summary>
    public class CommanderContext : DbContext
    {
        // : base = call constructor on the class this class is inheriting from.
        public CommanderContext(DbContextOptions<CommanderContext> options) : base(options) 
        {

        }

        public DbSet<Command> Commands { get; set; }
    }
}
