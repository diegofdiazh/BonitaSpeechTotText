using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using BonitaSpeechTotText.Models.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BonitaSpeechTotText.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public bool IsRecepcionista { get; set; }
        public bool IsSupterminal { get; set; }
        public bool IsSupbodega { get; set; }
        public bool IsAuxdian { get; set; }
        public bool IsDigitador { get; set; }
        public string UsernameBonita { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public virtual DbSet<Pieza> Piezas { get; set; }
        public virtual DbSet<Camion> Camions { get; set; }
        public virtual DbSet<PiezaCamion> PiezaCamions { get; set; }
        public virtual DbSet<Turno> Turnos { get; set; }
        public virtual DbSet<Envios> Envios { get; set; }
        public ApplicationDbContext()
            : base("ModelAppTeechToText", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}