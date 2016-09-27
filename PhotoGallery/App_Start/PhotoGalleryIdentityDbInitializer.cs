using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PhotoGallery.Models;

namespace PhotoGallery.App_Start
{
    public class PhotoGalleryIdentityDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var connectionString = ((IObjectContextAdapter) context).ObjectContext.Connection.ConnectionString;
            InitializeIdentityForEF(context);
            base.Seed(context);
        }

        private void InitializeIdentityForEF(ApplicationDbContext context)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            //Create Role and User for the role.
            string freeUserRole = "FreeUser";
            RoleManager.Create(new IdentityRole(freeUserRole));

            string loginFreeUser = "freeuser@gmail.com";
            FreeUser freeUser = new FreeUser() { Email = loginFreeUser, UserName = loginFreeUser, Id = "1" };
            var result = UserManager.Create(freeUser, "Password1!");
            UserManager.AddToRole(freeUser.Id, "FreeUser");

            //Create another Role Admin and User for the role.
            string paidUserRole = "PaidUser";
            RoleManager.Create(new IdentityRole(paidUserRole));

            var paidUser = new PaidUser();
            string loginPaidUser = "paiduser@gmail.com";
            paidUser.Email = loginPaidUser;
            paidUser.UserName = loginPaidUser;
            paidUser.FirstName = "Anton";
            paidUser.LastName = "Fomenko";
            paidUser.Id = "2";
            UserManager.Create(paidUser, "Password1!");
            UserManager.AddToRole(paidUser.Id, paidUserRole);
        }
    }
}