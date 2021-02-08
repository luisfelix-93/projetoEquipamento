using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetoLuisFE.Startup))]
namespace ProjetoLuisFE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
