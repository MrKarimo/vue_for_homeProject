using Microsoft.AspNetCore.Mvc;
using Model.Entity.Core;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Command.Base
{
    public class CommandFactory<T>
    {
        private BaseCommand<T> _command { get; set; } 

        public CommandFactory(BaseCommand<T> command)
        {
            _command = command;
        }

        public async Task Execute()
        {
            if(_command != null)
            {
                using (UtilityBillsContext context = new UtilityBillsContext())
                {
                    await _command.Execute(context);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
