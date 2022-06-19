using Arguments;
using Command.Base;
using Core.Command;
using Project.Model.Dto.User;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Project.Controllers
{
    [RoutePrefix("[controller]")]
    //[Route("[controller]")]
    public class UserController : ApiController
    {
        [Route("GetUserById")]
        //[HttpGet("GetUserById")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetUserById(GetUserByIdArgument argument)
        {
            GetUserByIdCommand command = new GetUserByIdCommand(argument);
            await new CommandFactory<GetUserByIdArgument>(command).Execute();
            var result = new UserDto()
            {
                Id = argument.Result.Id,
                FirstName = argument.Result.FirstName,
                MidleName = argument.Result.MidleName,
                SecondName = argument.Result.SecondName,
                PersonalAccountNumber = argument.Result.PersonalAccountNumber
            };
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
        }
    }
}
