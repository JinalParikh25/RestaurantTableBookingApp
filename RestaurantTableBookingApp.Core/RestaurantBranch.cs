using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestaurantTableBookingApp.Core;

public partial class RestaurantBranch
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int RestaurantId { get; set; }

    [Required]  
    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(200)]
    [Unicode(false)]
    public string Address { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Email { get; set; }

    [Column("ImageURL")]
    [StringLength(500)]
    [Unicode(false)]
    public string? ImageUrl { get; set; }

    [InverseProperty("Branch")]
    public virtual ICollection<DiningTable> DiningTables { get; set; } = new List<DiningTable>();

    [ForeignKey("RestaurantId")]
    [InverseProperty("RestaurantBranches")]
    public virtual Restaurant Restaurant { get; set; } = null!;

    [InverseProperty("Branch")]
    public virtual ICollection<TimeSlot> TimeSlots { get; set; } = new List<TimeSlot>();
}
