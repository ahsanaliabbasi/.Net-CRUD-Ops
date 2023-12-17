using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {

            this.userRepository = userRepository;
        }


        // 

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] string? filterOn,[FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var Users = await userRepository.GetUsersAsync(filterOn,filterQuery,sortBy,isAscending,pageNumber,pageSize);

            var userDTO = new List<UsersDTO>();
            foreach (var user in Users)
            {
                userDTO.Add(new UsersDTO()
                {
                       QLID = user.QLID,
                       FirstName = user.FirstName,
                       LastName = user.LastName,
                       Email = user.Email,
                       Role = user.Role,
                       APM= user.APM,
                });
            }

            return Ok(userDTO);
        }


        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO createUserDTO) {

            var usermodel = new User
            {
                QLID = createUserDTO.QLID,
                FirstName = createUserDTO.FirstName,
                LastName = createUserDTO.LastName,
                Email = createUserDTO.Email,
                Role = createUserDTO.Role,
                APM = createUserDTO.APM,
                Password = createUserDTO.Password

            };

            var user = await userRepository.CreateUserAsync(usermodel);
             
            if (user == null)
            {
               
                // As we can't pass whole object to user like its password etc so we will convert it to DTO.

                var rUser = new UsersDTO
                {
                    QLID= usermodel.QLID,
                    FirstName = usermodel.FirstName,
                    LastName = usermodel.LastName,
                    Email = usermodel.Email,
                    Role = usermodel.Role,
                    APM = usermodel.APM
                };
                return Ok(rUser);
                

            }
            else
            {
                return BadRequest("User Already Exists.");
            }
        }

        [HttpPut("{QLID}")]
        public async Task<IActionResult> UpdateUser(string QLID,[FromBody] UsersDTO usersDTO)
        {

            var usermodel = new User
            {
                QLID = usersDTO.QLID,
                FirstName = usersDTO.FirstName,
                LastName = usersDTO.LastName,
                Email = usersDTO.Email,
                Role = usersDTO.Role,
                APM = usersDTO.APM
            };

            var user = await userRepository.UpdateUserAsync(QLID,usermodel);

            if(user == null)
            {
                return BadRequest("User Not Found!");
            }

            user.QLID = usersDTO.QLID;
            user.FirstName = usersDTO.FirstName;
            user.LastName = usersDTO.LastName;
            user.Email = usersDTO.Email;
            user.Role = usersDTO.Role;
            user.APM = usersDTO.APM;


            return Ok(user);



        }

        [HttpGet("{QLID}")]
        public async Task<IActionResult> GetSingleUser(string QLID)
        {
            var user = await userRepository.GetSingleUserAsync(QLID);

            if (user == null)
            {
                return BadRequest("User Not Found!");
            }
            // Converting the obtained DB to DTO to return it back to user.

            var myUserDTO = new UsersDTO
            {
                QLID = user.QLID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role,
                APM = user.APM
            };

            return Ok(myUserDTO);


        }

        [HttpDelete("QLID")]
        public async Task<IActionResult> DeleteUser(string QLID)
        {
            var user = await userRepository.DeleteUserAsync(QLID);

            if (user == null)
            {
                return BadRequest("User Not Found...");
            }
            
            var userDTO = new UsersDTO()
            {
                QLID=user.QLID,
                FirstName=user.FirstName,
                LastName=user.LastName,
                Email = user.Email,
                APM = user.APM,
                Role = user.Role
               
            };

            return Ok(new { Message="User Deleted Successfully."
                ,userDTO});

        }


    }
}
 