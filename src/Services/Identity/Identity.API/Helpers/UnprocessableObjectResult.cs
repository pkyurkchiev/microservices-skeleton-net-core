using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Identity.API.Helpers
{
    public class UnprocessableObjectResult : ObjectResult
    {
        public UnprocessableObjectResult(ModelStateDictionary modelState)
            : base(new SerializableError(modelState))
        {
            if (modelState == null) throw new ArgumentNullException(nameof(modelState));

            StatusCode = 422;
        }
    }
}