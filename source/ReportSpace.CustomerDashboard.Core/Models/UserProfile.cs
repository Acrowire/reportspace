using System;
using System.ComponentModel.Composition;

namespace ReportSpace.CustomerDashboard.Core.Models
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UserProfile")]
    [Export(typeof(IDataObject))]
    [ExportMetadata("BaseObjectName", "UserProfile")]
    public class UserProfile : BaseObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("UserId")]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string CompanyLogoFileName { get; set; }

        public EnumRole Role { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public virtual Membership Membership { get; set; }

        public virtual ICollection<Client> Clients { get; set; }

        public virtual ICollection<UserGroupMembership> UserGroupMemberships { get; set; }

        public virtual ICollection<UserFunction> UserFunctions { get; set; }

        public UserProfile()
        {
            Roles = new Collection<Role>();
            Clients = new Collection<Client>();
            UserFunctions = new Collection<UserFunction>();
        }


    }

    public enum EnumRole
    {
        Root = 0,
        Admin = 1,
        User = 2,

    }
    
    

}