using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ParrotWingsTransfer.API.Controllers
{
    public class TestUserNameController : ApiController
    {
        public string Get()
        {
            return $"{User.Identity.GetUserName()} {User.Identity.GetUserId()}";
        }
    }
}
