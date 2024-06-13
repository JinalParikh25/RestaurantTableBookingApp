﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantTableBookingApp.Core.ViewModels;
using RestaurantTableBookingApp.Data;
using RestaurantTableBookingApp.Service;

namespace RestaurantTableBookingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            this._restaurantService = restaurantService;
        }

        [HttpGet("restaurant")]
        [ProducesResponseType(200, Type = typeof(List<RestaurantModel>))]
        public async Task<ActionResult> GetAllRestaurants()
        {
            var restaurants = await _restaurantService.GetAllRestaurantsAsync();
            return Ok(restaurants);
        }

        [HttpGet("branches/{restaurantId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RestaurantBranchModel>))]
        [ProducesResponseType(400)]
        public async Task<ActionResult> GetRestaurantBranchesByRestaurantId(int restaurantId)
        {
            var branches = await _restaurantService.GetRestaurantBranchesByRestaurantIdAsync(restaurantId);

            if(branches == null)
            {
                return NotFound();
            }
            return Ok(branches);
        }

        [HttpGet("diningTables/{branchId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DiningTableWithTimeSlotsModel>))]
        [ProducesResponseType(400)]
        public async Task<ActionResult> GetDiningTablesByBranchAsync(int branchId)
        {
            var diningTables = await _restaurantService.GetDiningTablesByBranchAsync(branchId);

            if (diningTables == null)
            {
                return NotFound();
            }
            return Ok(diningTables);
        }


        [HttpGet("diningTables/{branchId}/{date}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DiningTableWithTimeSlotsModel>))]
        [ProducesResponseType(400)]
        public async Task<ActionResult> GetDiningTablesByBranchAsync(int branchId, DateTime date)
        {
            var diningTables = await _restaurantService.GetDiningTablesByBranchAsync(branchId, date);

            if (diningTables == null)
            {
                return NotFound();
            }
            return Ok(diningTables);
        }

       
    }
}
