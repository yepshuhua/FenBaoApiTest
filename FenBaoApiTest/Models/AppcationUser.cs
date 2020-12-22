using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FenBaoApiTest.Models
{
    public class AppcationUser:IdentityUser
    {
        public double Score { get; set; }
        public virtual ICollection<IdentityUserRole<string>> UserRoles { get; set; }
        public virtual ICollection<IdentityUserClaim<string>>  UserClaims{ get; set; }
        public virtual ICollection<IdentityUserLogin<string>>  UserLogins{ get; set; }
        public virtual ICollection<IdentityUserToken<string>>  UserTokens { get; set; }
    }
}
