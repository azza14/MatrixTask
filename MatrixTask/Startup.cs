using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MatrixTask.Startup))]
namespace MatrixTask
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
