using Business.Abstract;
using Business.ResponseModels.Concrete;
using Business.Security.Hashing;
using Business.Security.JWT;
using Entities.Concrete;
using Entities.Constants.Messages;
using Entities.DTOs;
using Entities.ResponseModels.Abstract;
using Entities.ResponseModels.Concrete;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService; 
            _tokenHelper = tokenHelper;
        }
        public async Task<IDataResult<AccessToken>> CreateAccessToken(User user)
        {
            var claims = await _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, SuccessMessages.AccessTokenCreated);
        }

        public async Task<IDataResult<User>> Login(UserLoginDto userLoginDto)
        {
            string email = userLoginDto.Email;
            var userToCheck = await _userService.GetByMail(email);
            Console.WriteLine(userToCheck);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(userToCheck, ErrorMessages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(userToCheck,ErrorMessages.PasswordError);
            }
            return new SuccessDataResult<User>(userToCheck, SuccessMessages.SuccessfulLogin);
        }

        public async Task<IDataResult<User>> Register(UserRegisterDto userRegisterDto)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            HashingHelper.CreatePasswordHash(userRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User()
            {
                Email = userRegisterDto.Email,
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            await _userService.Add(user);
            return new SuccessDataResult<User>(user, SuccessMessages.UserRegistered);
        }

        public async Task<IResult> UserExists(string email)
        {
            var user = await _userService.GetByMail(email);
            if(user != null)
            {
                return new ErrorResult(ErrorMessages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
