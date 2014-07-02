using System;

namespace ReportSpace.CustomerDashboard.Core.Models
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UserProfile")]
    public class UserProfile : BaseObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int UserId { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string CompanyLogoFileName { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public virtual Membership Membership { get; set; }

        public virtual ICollection<Client> Clients { get; set; }

        public virtual ICollection<UserGroupMembership> UserGroupMemberships { get; set; }
        
        public new DateTime? Created { get; set; }

        public new DateTime? Updated { get; set; }
        
        public UserProfile()
        {
            Roles = new Collection<Role>();

            Clients = new Collection<Client>();
        }


    }
}