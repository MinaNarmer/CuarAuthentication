using System.Security.Claims;
using CuarAuthentication.Domain.Constants;
using CuarAuthentication.Domain.Helpers;
using CuarAuthentication.Domain.Seeds;
using Microsoft.AspNetCore;


namespace CuarAuthentication.API
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var host = CreateWebHostBuilder(args).Build();

			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;

				var httpContextAccessor = scope.ServiceProvider.GetService<IHttpContextAccessor>();

				httpContextAccessor.HttpContext = new DefaultHttpContext();

				var claimsIdentity = new ClaimsIdentity(new Claim[] {
														new Claim(ApplicationClaims.UserName, "superadmin"),
													});

				httpContextAccessor.HttpContext.User = new ClaimsPrincipal(claimsIdentity);

				AppSecurityContext.Configure(httpContextAccessor);

				await SeedApplicationDB.Initialize(services); // Insert default data
			}

			host.Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>();
	}
}
