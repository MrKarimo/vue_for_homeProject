using Arguments.Command.Base;
using Model.Entity.Core;

namespace Arguments
{
    public class GetUserByIdArgument : BaseArgument<User>
    {
        public int Id { get; set; }
    }
}
