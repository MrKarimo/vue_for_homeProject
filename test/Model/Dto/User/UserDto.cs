using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Model.Dto.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MidleName { get; set; }
        public string SecondName { get; set; }
        public int? PersonalAccountNumber { get; set; }
    }
}
