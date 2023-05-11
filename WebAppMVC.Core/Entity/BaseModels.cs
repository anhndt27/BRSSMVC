using Microsoft.AspNetCore.Identity;

namespace WebAppMVC.Data.Entity
{
    public abstract class BaseModels : IdentityUser
    {
        public Int64 ID { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string IP { get; set; }
    }
}
