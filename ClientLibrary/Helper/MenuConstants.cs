using ClientLibrary.Models.Landing;
using ClientLibrary.Helper;

namespace ClientLibrary.Helper
{
    public static class MenuConstants
    {
        public static readonly IReadOnlyList<MenuActionModel> AccountActions = new List<MenuActionModel>
        {
            new("Mi actividad", RouteConstants.ClientDashboard),
            new("Mi perfil", RouteConstants.Profile),
            new("Panel profesional", RouteConstants.ProfessionalDashboard),
            new("Panel administrador", RouteConstants.AdminDashboard),
            new("Cerrar sesión", RouteConstants.Logout),
            new("Iniciar sesión", RouteConstants.Login),
            new("Registrarse", RouteConstants.Register)
        };

        public static readonly SearchConfig SearchBarConfig = new("Buscar servicios hogareños en ServicioAhora!", "Buscar");

        public static readonly IReadOnlyList<string> FooterContact = new List<string>
        {
            "Tel: +54 11 5555 1111",
            "Email: hola@servicioahora.com",
            "Horario: Lunes a domingo 8 a 22 h"
        };

        public static readonly IReadOnlyList<NavLinkModel> PrimaryNavLinks = new List<NavLinkModel>
        {
            new("Inicio", RouteConstants.Home),
            new("Servicios", RouteConstants.Search),
            new("Profesionales", RouteConstants.Professionals),
            new("Contacto", RouteConstants.Contact)
        };

        public static readonly IReadOnlyList<FooterGroupModel> FooterGroups = new List<FooterGroupModel>
        {
            new("Explorá más", new []
            {
                new FooterLinkModel("Servicios", RouteConstants.Search),
                new FooterLinkModel("Profesionales", RouteConstants.Professionals),
                new FooterLinkModel("Contacto", RouteConstants.Contact)
            })
        };
    }
}
