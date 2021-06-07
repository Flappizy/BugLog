using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buglog.Model.IdentityModels;

namespace Buglog.Model.ViewModel
{
    public class ProfileModel
    {
        public ApplicationUser AppUser { get; set; }
        public IEnumerable<string> Roles { get; set; } = Enumerable.Empty<string>();
    }
}
