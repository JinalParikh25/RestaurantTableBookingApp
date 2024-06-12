using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestaurantTableBookingApp.Core;

public partial class DiningTable
{
    [Key]
    public int Id { get; set; }

    public int RestaurantBranchId { get; set; }

    [Required]
    [StringLength(100)]
    [Unicode(false)]
    public string? SeatsName { get; set; }

    [Required]
    public int Capacity { get; set; }

    [ForeignKey("BranchId")]
    [InverseProperty("DiningTables")]
    public virtual RestaurantBranch Branch { get; set; } = null!;
}
