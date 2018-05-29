using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace DonaldsonMotorsThree.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public abstract class User : IdentityUser
    {
        private ApplicationUserManager userManager;
        // Declare User Properties // 
      
        [Display(Name= "First Name")]
        public string FirstName { get; set; }

        [Display(Name="Surname")]
        public string LastName { get; set; }

        [Display(Name="Address")]
        public string AddressLine1 { get; set; }

        [Display(Name="Address Line 2")]
        public string AddressLine2 { get; set; }

        public string Town { get; set; }
        
        public string Postcode { get; set; }
     
        public string TelephoneNumber { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int CustomerId { get; set; }


        [NotMapped]
        public string currentRole
        {
            get
            {
                if (userManager == null)
                {
                    userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
                }
                return userManager.GetRoles(Id).Single();

            }
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {

            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole():base(){ }

        public ApplicationRole(string roleName) : base(roleName) { }
    }


}