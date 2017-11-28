using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChuyenTinDriveData.Startup))]
namespace ChuyenTinDriveData
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
