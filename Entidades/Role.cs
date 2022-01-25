using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Tarea2
{
    [Index(nameof(Description), IsUnique = true)]
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }

    }
}