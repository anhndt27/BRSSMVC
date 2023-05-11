
using Microsoft.AspNetCore.Identity;
using WebAppMVC.Core.Entity;

namespace WebAppMVC.Data.Entity
{
    public class User : BaseModels

    {
        public virtual UserProfile UserProfile { get; set; }

    }
}
