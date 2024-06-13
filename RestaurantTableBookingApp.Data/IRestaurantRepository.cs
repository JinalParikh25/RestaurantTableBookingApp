using RestaurantTableBookingApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTableBookingApp.Data
{
    public interface IRestaurantRepository
    {
        Task<List<RestaurantModel>> GetAllRestaurantsAsync();
        Task<IEnumerable<RestaurantBranchModel>> GetRestaurantBranchesByRestaurantIdAsync(int restaurantId);

        /// <summary>
        /// LINQ query retrives dinning tables and their associated time slots for a specific branchId and date. 
        /// the result is sorted by Id and the MealType. The data is then projected into a list of DiningTableWithTimeSlotsModel view models and returned.
        /// </summary>
        /// <param name="branchId"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        Task<IEnumerable<DiningTableWithTimeSlotsModel>> GetDiningTablesByBranchAsync(int branchId,DateTime dateTime);

        /// <summary>
        /// LINQ query retrives dinning tables and their associated time slots for a specific branchId and date which are current and future.
        /// The result is sorted by Id and the MealType. The data is then projected into a list of DiningTablewithTimeSlotsModel view Models and 
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        Task<IEnumerable<DiningTableWithTimeSlotsModel>> GetDiningTablesByBranchAsync(int branchId);
    }

}
