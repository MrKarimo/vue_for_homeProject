using System.Net;

namespace Command.Base
{
    public abstract class BaseCommand <T> : ACommand
    {
        protected T Arguments = default(T);
        
        protected BaseCommand(T arguments)
        {
            Arguments = arguments;
        }
    }
}
