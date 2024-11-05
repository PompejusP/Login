namespace Web_FIA44_Login
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllersWithViews();

			builder.Services.AddSession(options =>
			{
				options.IdleTimeout = TimeSpan.FromMinutes(30);
				options.Cookie.HttpOnly = true;
				options.Cookie.IsEssential = true;
				options.Cookie.Name = ".Web_FIA44_Login.Session";
				options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
			
		});
			var app = builder.Build();

			app.MapControllerRoute(name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.UseStaticFiles();
			app.UseSession();

			app.UseRouting();
			app.Run();
		}
	}
}
