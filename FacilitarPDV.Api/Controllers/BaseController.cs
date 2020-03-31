using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace FacilitarPDV.Api.Controllers
{
    public class BaseController : Controller
    {
        public BaseController() { }

        public async Task<IActionResult> Response(object result, List<string> notifications)
        {
            if (notifications.Count == 0)
            {
                try
                {
                    return Ok(new
                    {
                        success = true,
                        data = result
                    });
                }
                catch (Exception ex)
                {
                    return BadRequest(new
                    {
                        success = false,
                        errors = new[] { ex.Message }
                    });
                }
            }
            else
            {
                return BadRequest(new
                {
                    success = false,
                    errors = new[] { notifications.ToArray() }
                });
            }
        }
    }
}
