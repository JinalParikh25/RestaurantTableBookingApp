using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestaurantTableBookingApp.Core;

public partial class TimeSlot
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int BranchId { get; set; }

    [Required]
    public DateOnly ReservationDay { get; set; }

    [Required]
    [StringLength(100)]
    [Unicode(false)]
    public string MealType { get; set; } = null!;

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string TableStatus { get; set; } = null!;

    [ForeignKey("BranchId")]
    [InverseProperty("TimeSlots")]
    public virtual RestaurantBranch Branch { get; set; } = null!;

    [InverseProperty("TimeSlot")]
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
