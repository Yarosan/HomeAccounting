﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DomainModels.Model
{
    [Table("NotificationMailBox")]
    public class NotificationMailBox
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Index("UQ_NotificationMailBox_MailBoxName",IsUnique = true)]
        public string MailBoxName { get; set; }
        [Required]
        [StringLength(50)]
        public string MailFrom { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [StringLength(1024)]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string Server { get; set; }
        [Required]
        public int Port { get; set; }
        public bool UseSsl { get; set; } = true;
    }
}

