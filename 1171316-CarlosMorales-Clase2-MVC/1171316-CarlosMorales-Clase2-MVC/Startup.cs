using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_1171316_CarlosMorales_Clase2_MVC.Startup))]
namespace _1171316_CarlosMorales_Clase2_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
