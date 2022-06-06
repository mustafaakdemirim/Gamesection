using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BussinessLogic.Abstract;
using Entity.POCO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GamesectionAPI.Controllers
{
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService gameService;

        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var result = gameService.GetGameAndImage();
            
            
            return Ok(result.Data);
        }
        
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var result = gameService.GetGameAndImage(id);
            switch (result.ResultType)
            {
                case Core.BLL.Constant.EntityResultType.Success:
                    var entity = result.Data.ToList()[0];
                    return Ok(entity);
                case Core.BLL.Constant.EntityResultType.Error:
                    break;
                case Core.BLL.Constant.EntityResultType.Notfound:
                    break;
                case Core.BLL.Constant.EntityResultType.NonValidation:
                    break;
                case Core.BLL.Constant.EntityResultType.Warning:
                    break;
                default:
                    break;
            }
            return Ok();
        }
        
        // GET: api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
