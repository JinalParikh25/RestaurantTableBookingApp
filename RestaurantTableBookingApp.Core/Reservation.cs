using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestaurantTableBookingApp.Core;

public partial class Reservation
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public int TimeSlotId { get; set; }

    [Required]
    public DateOnly ReservationDate { get; set; }

    [Required]
    [StringLength(20)]
    [Unicode(false)]
    public string ReservationStatus { get; set; } = null!;


    [ForeignKey("TimeSlotId")]
    [InverseProperty("Reservations")]
    public virtual TimeSlot TimeSlot { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Reservations")]
    public virtual User User { get; set; } = null!;
}
