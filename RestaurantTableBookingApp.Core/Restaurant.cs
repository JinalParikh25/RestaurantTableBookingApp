﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestaurantTableBookingApp.Core;

public partial class Restaurant
{
    [Key]
    public int Id { get; set; }

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

    [InverseProperty("Restaurant")]
    public virtual ICollection<RestaurantBranch> RestaurantBranches { get; set; } = new List<RestaurantBranch>();
}
