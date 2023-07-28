using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;
using wbzf.Model.ViewModel;
using wbzf.Utility;

namespace wbzf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<ApplicationUser> _logger;
        private readonly Microsoft.AspNetCore.Identity.UI.Services.IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;

        public userController(IUnitOfWork unitOfWork, UserManager<ApplicationUser>
            userManager, IUserStore<ApplicationUser> userStore, ILogger<ApplicationUser> logger,
            Microsoft.AspNetCore.Identity.UI.Services.IEmailSender emailSender, RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork=unitOfWork;
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }
        [Authorize(Roles =SD.Admin,AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [Route("test")]
        public async Task<IActionResult> Post([FromBody] testData abc)
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == "jti").Value;
            string ApplicationUserId = email;
            return Json(new { success = true, message = "this is success message from : "+ abc.Name + ApplicationUserId});
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Post([FromBody] InputRegisterModel InputModel)
        {
            var user = CreateUser();
            user.Full_Name=InputModel.Full_Name;
            user.PhoneNumber=InputModel.PhoneNumber;
            user.Email=InputModel.Email;
            user.ProfessionId=InputModel.ProfessionId;
            user.Gender=InputModel.Gender;
            user.Mother_Name=InputModel.Mother_Name;
            await _userStore.SetUserNameAsync(user, InputModel.PhoneNumber, CancellationToken.None);

            var result = await _userManager.CreateAsync(user, InputModel.Password);
            if (result.Succeeded)
            {
                if (InputModel.Email != null)
                {
                    try
                    {
                        await _emailStore.SetEmailAsync(user, InputModel.Email, CancellationToken.None);
                        await _emailSender.SendEmailAsync(InputModel.Email, $"Donation Registration Successful : {InputModel.Full_Name}",
                        $"Your registration has been successfully completed . Please login with you Mobile no: {InputModel.PhoneNumber} as username and {InputModel.Password} as Password to login..");
                    }
                    catch (Exception ex)
                    {

                    }
                    

                }
                await _userManager.AddToRoleAsync(user, SD.Donor);
                //await _signInManager.SignInAsync(user, isPersistent: false);
                return Json(new { success = true, data = "success" });
            }
            else
            {

                string error = "";

                foreach (var item in result.Errors)
                {
                    error += string.Join(", ", item.Description);
                }
                return Json(new { success = false, data = error });
            }

        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var jwtconfig = _unitOfWork.company.getJWT();
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtconfig.Secret));

            var token = new JwtSecurityToken(
                issuer: jwtconfig.Issuer,
                audience: jwtconfig.Audience,
                expires: DateTime.Now.AddMinutes(10),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

    }

    public class testData
    {
        public string Name { get; set; }
       
    }
    
}

