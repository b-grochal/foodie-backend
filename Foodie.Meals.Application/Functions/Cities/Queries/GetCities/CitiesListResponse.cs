﻿using Foodie.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Cities.Queries.GetCities
{
    public class CitiesListResponse : PagedResponse
    {
        public IEnumerable<CityResponse> Cities { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}