using System.Linq;
using System.Security.Claims;

namespace DatingApp.Extensions
{
	public static class ClaimsPrincipleExtensions
	{
		public static string GetUsername(this ClaimsPrincipal user)
		{
			return user.FindFirst(ClaimTypes.Name)?.Value;
		}

		public static int GetUserId(this ClaimsPrincipal user)
		{
			var claimValue = user.Claims.FirstOrDefault(e => e.Type == "userId");

			int.TryParse(claimValue?.Value, out int userId);

			return userId;
		}
	}
}
