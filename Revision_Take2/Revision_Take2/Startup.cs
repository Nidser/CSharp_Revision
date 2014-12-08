using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Revision_Take2.Startup))]
namespace Revision_Take2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
