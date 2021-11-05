using AutoMapper;
using MetroDocs.Domain;
using MetroDocs.Domain.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartupAttribute(typeof(MetroDocs.Startup))]
namespace MetroDocs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            CookieAuthenticationOptions options = new CookieAuthenticationOptions();
            options.AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie;          
            options.LoginPath = new PathString("/account/login");
            app.UseCookieAuthentication(options);
            ConfigureAuth(app);

            Mapper.Initialize(cfg =>
            {
                cfg.ValidateInlineMaps = false;
                cfg.CreateMap<AgreementViewModel, Agreement>();
                cfg.CreateMap<ContactInfoViewModel, ContactInfo>();
                cfg.CreateMap<AgreementDocument, AgreementDocumentViewModel>();
            });
        }
    }
}
