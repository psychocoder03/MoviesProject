//using MoviesProj.Models.User;

//namespace MoviesProj.Extensions
//{
//    public static class IdentityExtension
//    {
//        public static void ConfigureIdentity(this IServiceCollection services)
//        {
//            var builder = services.AddIdentity<User>(o =>
//            {
//                o.Password.RequireDigit = true;
//                o.Password.RequireLowercase = false;
//                o.Password.RequireUppercase = false;
//                o.Password.RequireNonAlphanumeric = false; 
//                o.Password.RequiredLength = 10;
//                o.User.RequireUniqueEmail = true;
//            })
//            .AddDefaultTokenProviders();
//        }
//    }
//}
