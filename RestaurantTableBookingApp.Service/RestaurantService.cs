using RestaurantTableBookingApp.Core.ViewModels;
using RestaurantTableBookingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTableBookingApp.Service
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            this._restaurantRepository = restaurantRepository;
        }

        public Task<List<RestaurantModel>> GetAllRestaurantsAsync()
        {
            return _restaurantRepository.GetAllRestaurantsAsync();
        }

        public Task<IEnumerable<DiningTableWithTimeSlotsModel>> GetDiningTablesByBranchAsync(int branchId, DateTime dateTime)
        {
            return _restaurantRepository.GetDiningTablesByBranchAsync(branchId,dateTime);
        }

        public Task<IEnumerable<DiningTableWithTimeSlotsModel>> GetDiningTablesByBranchAsync(int branchId)
        {
            return _restaurantRepository.GetDiningTablesByBranchAsync(branchId);
        }

        public Task<IEnumerable<RestaurantBranchModel>> GetRestaurantBranchesByRestaurantIdAsync(int restaurantId)
        {
            return _restaurantRepository.GetRestaurantBranchesByRestaurantIdAsync(restaurantId);
        }
    }
}
