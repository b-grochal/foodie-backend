﻿using Foodie.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Domain.Exceptions
{
    public class ApplicationUserNotDeletedException : InternalServerErrorException
    {
        public ApplicationUserNotDeletedException(string applicationUserId) : base($"The application user with the indetifier {applicationUserId} was not deleted.") { }
    }
}
