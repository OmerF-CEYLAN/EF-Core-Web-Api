using AutoMapper;
using DataLayer.Entities;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using System.Collections;
using static System.Net.WebRequestMethods;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        //HttpClient client = new HttpClient();

        //string url = "https://jsonplaceholder.typicode.com/users";

        //HttpResponseMessage response;

        public ValuesController(IUserService userService,IMapper mapper)
        {
            _userService =userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserResponseModel>> GetAllUsers()
        {
            //response = await client.GetAsync(url);
            //var users = await response.Content.ReadFromJsonAsync<List<User>>();

            var users = await _userService.GetAllAsync();
            return _mapper.Map<IEnumerable<UserResponseModel>>(users);
        }

        [HttpGet("{id}")]
        public async Task<UserResponseModel> GetUserById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            return _mapper.Map<UserResponseModel>(user);
        }

        [HttpPost]
        public async Task<UserResponseModel> PostTheUser(UserRequestModel userRequestModel)
        {
            //response = await client.PostAsJsonAsync(url, userRequestModel);
            //var user = await response.Content.ReadFromJsonAsync<User>();

            var user = _mapper.Map<User>(userRequestModel);
            var createdUser = await _userService.InsertUserAsync(user);
            return _mapper.Map<UserResponseModel>(createdUser);

        }

        [HttpPut]
        public async Task<UserResponseModel> UpdateTheUser(UserRequestModel userRequestModel)
        {
            var user = _mapper.Map<User>(userRequestModel);
            var updatedUser = await _userService.UpdateUserAsync(user);
            return _mapper.Map<UserResponseModel>(updatedUser);

        }

        [HttpDelete("{id}")]
        public async Task<UserResponseModel> DeleteUser(int id)
        {
            var deletedUser = await _userService.DeleteUserAsync(id);
            return _mapper.Map<UserResponseModel>(deletedUser);
        }

    }
}
