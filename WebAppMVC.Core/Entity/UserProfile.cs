using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Data.Entity;

namespace WebAppMVC.Core.Entity
{
    public class UserProfile : BaseModels
    {
        public virtual User User { get; set; }
    }
}
