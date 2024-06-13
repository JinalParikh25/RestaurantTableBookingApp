using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTableBookingApp.Core.ViewModels
{
    public class DiningTableWithTimeSlotsModel
    {
        public int BranchId { get; set; }
        public DateTime ReservationDay { get; set; }
        public string? TableName { get; set; }     
        public int Capacity { get; set; }
        public string MealType { get; set; } = string.Empty;
        public string TableStatus { get; set; } = null!;

        public int TimeSlotId { get; set; }
    }
}
