using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace SoruSorApi.Controllers.ControllerContract
{
    public interface IUserController
    {
        public IActionResult GetUsers();
        public IActionResult AddUser([FromBody] UserDTO userDto);
    }
}
