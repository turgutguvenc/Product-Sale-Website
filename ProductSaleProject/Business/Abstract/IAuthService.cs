using Business.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using Entities.ResponseModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<User>> Register(UserRegisterDto userRegisterDto);
        Task<IDataResult<User>> Login(UserLoginDto userLoginDto);
        Task<IResult> UserExists(string email);
        Task<IDataResult<AccessToken>> CreateAccessToken(User user);
    }
}
