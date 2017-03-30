using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MathAcademy.Startup))]
namespace MathAcademy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
