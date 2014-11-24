using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Revision_Take1.Startup))]
namespace Revision_Take1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
