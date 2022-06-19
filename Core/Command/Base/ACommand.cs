using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Command.Base
{
    public abstract class ACommand
    {
        public abstract Task Execute(DbContext context);
    }
}
