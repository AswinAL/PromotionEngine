using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PromotionEngine.BL;
using PromotionEngine.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PromotionEngine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionEngineController : ControllerBase
    {
        public IPromotionBL BL { get; }
        public PromotionEngineController(IPromotionBL promotionBL)
        {
            BL = promotionBL;
        }


        // POST api/<PromotionEnigneController>
        [HttpPost]
        public IActionResult Post([FromBody] CartModel cart)
        {
            if (ModelState.IsValid && cart?.CartItems.Any() == true)
            {
                return Ok(BL.Apply(cart));
            }
            return BadRequest();
        }
    }
}
