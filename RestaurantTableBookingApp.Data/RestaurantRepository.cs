using Microsoft.EntityFrameworkCore;
using RestaurantTableBookingApp.Core;
using RestaurantTableBookingApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTableBookingApp.Data
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantTableBookingDBContext _dBContext;

        public RestaurantRepository(RestaurantTableBookingDBContext dBContext)
        {
            this._dBContext = dBContext;
        }
        public async Task<List<RestaurantModel>> GetAllRestaurantsAsync()
        {
           var restaurants = await _dBContext.Restaurant
                                   .Select(x => new RestaurantModel()
                                   {
                                       Id = x.Id,
                                       Name = x.Name,
                                       Address = x.Address,
                                       Email = x.Email,
                                       Phone = x.Phone,
                                       ImageUrl = x.ImageUrl,
                                   }).ToListAsync();

            return restaurants;
        }

        public async Task<IEnumerable<DiningTableWithTimeSlotsModel>> GetDiningTablesByBranchAsync(int branchId, DateTime dateTime)
        {
                var diningTables = await _dBContext.DiningTable
                                        .Where(x => x.RestaurantBranchId == branchId)
                                        .SelectMany(x => x.TimeSlots,
                                            (x,TimeSlot) => new DiningTableWithTimeSlotsModel()
                                            {
                                                BranchId = x.RestaurantBranchId,
                                                Capacity = x.Capacity,
                                                TableName = x.TableName,
                                                MealType = TimeSlot.MealType,
                                                ReservationDay = TimeSlot.ReservationDay,
                                                TableStatus = TimeSlot.TableStatus,
                                                TimeSlotId = TimeSlot.Id
                                            }).Where(x => x.ReservationDay == dateTime.Date)
                                            .OrderBy(x => x.TimeSlotId)
                                            .ThenBy(x => x.MealType)
                                            .ToListAsync();

              return diningTables;
        }

        public async Task<IEnumerable<DiningTableWithTimeSlotsModel>> GetDiningTablesByBranchAsync(int branchId)
        {
            var dinningTables = await _dBContext.DiningTable
                                        .Where(x => x.RestaurantBranchId == branchId)
                                        //.Select(x => new DiningTableWithTimeSlotsModel()
                                        //{
                                        //    BranchId = x.Id
                                        //}).ToListAsync();
                                        .SelectMany(x => x.TimeSlots,
                                            (x, TimeSlot) => new DiningTableWithTimeSlotsModel()
                                            {
                                                BranchId = x.RestaurantBranchId,
                                                Capacity = x.Capacity,
                                                TableName = x.TableName,
                                                MealType = TimeSlot.MealType,
                                                ReservationDay = TimeSlot.ReservationDay,
                                                TableStatus = TimeSlot.TableStatus,
                                                TimeSlotId = TimeSlot.Id
                                            })
                                            .Where(x => x.ReservationDay >= DateTime.Now.Date)
                                            .OrderBy(x => x.TimeSlotId)
                                            .ThenBy(x => x.MealType)
                                            .ToListAsync();

            return dinningTables;
        }

        public async Task<IEnumerable<RestaurantBranchModel>> GetRestaurantBranchesByRestaurantIdAsync(int restaurantId)
        {
            var restaurantBranches = await _dBContext.RestaurantBranch
                                        .Where( x => x.RestaurantId == restaurantId)
                                        .Select(x => new RestaurantBranchModel()
                                        {
                                            Id  = x.Id,
                                            RestaurantId = restaurantId,
                                            Name = x.Name,
                                            Address = x.Address,
                                            Email = x.Email,
                                            Phone = x.Phone,
                                            ImageUrl = x.ImageUrl,
                                        }).ToListAsync();

            return restaurantBranches;
        }
    }
}
