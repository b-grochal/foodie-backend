﻿using Foodie.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Admins.Queries.GetAdmins
{
    public class GetAdminsQueryResponse : PagedResponse
    {
        public IEnumerable<AdminDto> Admins{ get; set; }
        public string Email { get; set; }
    }
}