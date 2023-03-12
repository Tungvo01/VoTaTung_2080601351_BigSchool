using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VoTaTung_2080601351_BigSchool.Startup))]
namespace VoTaTung_2080601351_BigSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
