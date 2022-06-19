using Arguments;
using Command.Base;
using Microsoft.EntityFrameworkCore;
using Model.Entity.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Command
{
    public class GetUserByIdCommand : BaseCommand<GetUserByIdArgument>
    {
        public GetUserByIdCommand(GetUserByIdArgument argument) : base(argument)
        {

        }

        public async override Task Execute(DbContext context)
        {
            Repository<User> repository = new Repository<User>(context);
            Arguments.Result = await repository.GetAsync(x => x.Id == Arguments.Id);
        }
    }
}
