using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetApp.Service
{
    public class AdminAreaAuthorization : IControllerModelConvention
    {
        private readonly string Area;
        private readonly string Policy;
        public AdminAreaAuthorization(string area, string policy)
        {
            Area = area;
            Policy = policy;
        }

        public void Apply(ControllerModel controller)
        {
            if (controller.Attributes.Any(x =>
            x is AreaAttribute && (x as AreaAttribute).RouteValue.Equals(Area, StringComparison.OrdinalIgnoreCase)) ||
            controller.RouteValues.Any(y => y.Key.Equals("area", StringComparison.OrdinalIgnoreCase) && y.Value.Equals(Area, StringComparison.OrdinalIgnoreCase)))
            {
                controller.Filters.Add(new AuthorizeFilter(Policy));
            }
        }
    }
}

