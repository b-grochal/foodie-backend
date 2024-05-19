﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Foodie.Common.Results
{
    public sealed record Error
    {
        public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);
        
        public static readonly Error NullValue = new("Error.NullValue", "Null value was provided", ErrorType.Failure);

        private Error(string code, string description, ErrorType type, IReadOnlyCollection<ErrorDetail> details = null)
        {
            Code = code;
            Description = description;
            Type = type;
            Details = details;
        }

        public string Code { get; }

        public string Description { get; }

        public ErrorType Type { get; }

        public IReadOnlyCollection<ErrorDetail> Details { get; }

        public static Error NotFound(string code, string description) =>
            new(code, description, ErrorType.NotFound);

        public static Error Validation(string code, string description, IReadOnlyCollection<ErrorDetail> details) =>
            new(code, description, ErrorType.Validation, details);

        public static Error Conflict(string code, string description) =>
            new(code, description, ErrorType.Conflict);

        public static Error Failure(string code, string description) =>
            new(code, description, ErrorType.Failure);

        public static Error Unauthorized(string code, string description) =>
            new(code, description, ErrorType.Unauthorized);
    }
}
