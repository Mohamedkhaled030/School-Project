using System.Security.Claims;

namespace Shcool.Data.Helper
{
    public class CliamStory
    {
        public static List<Claim> ClaimList = new List<Claim>()
        {
            new Claim("Create Studend","false"),
            new Claim("Edite Studend","false"),
            new Claim("Delete Studend","false"),

        };
    }
}
