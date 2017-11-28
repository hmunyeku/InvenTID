using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvenTID_App.Models
{
    [Table("PERMISSIONS")]
    public class PERMISSION
    {
        [Key]
        public int PermissionId { get; set; }

        [Required]
        [StringLength(50)]
        public string PermissionDescription { get; set; }

        public virtual List<ApplicationRole> ROLES { get; set; }
    }

    public enum ParameterType
    {
        ShortString = 1,
        LongString = 2,
        SmallInteger = 3,
        Bool = 4,
        RadioInteger = 5
    }

    [Table("PARAMETERS")]
    public class PARAMETER
    {
        [Key]
        public int ID { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public string Value { get; set; }
        public long MemberID { get; set; }
        public ParameterType TypeID { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public PARAMETER()
        {
        }
    }

    public enum AuditEventType
    {
        Default = 1,
        Info = 2,
        Success = 3,
        Warning = 4,
        Error = 5
    }

    [Table("AUDITEVENTS")]
    public class AUDITEVENT
    {
        [Key]
        public long EventID { get; set; }
        public AuditEventType EventType { get; set; }
        [StringLength(255)]
        public string MemberEmail { get; set; }
        [StringLength(64)]
        public string IPAddress { get; set; }
        public string Details { get; set; }
        public string Description { get; set; }
        public DateTime? Created { get; set; }
    }

}