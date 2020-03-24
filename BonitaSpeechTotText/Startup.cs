using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BonitaSpeechTotText.Startup))]
namespace BonitaSpeechTotText
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
