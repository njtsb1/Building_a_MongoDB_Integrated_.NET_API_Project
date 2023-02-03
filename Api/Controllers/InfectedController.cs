using Api.Data.Collections;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectedController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infected> _infectedsCollection;

        public InfectedController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectedsCollection = _mongoDB.DB.GetCollection<Infected>(typeof(Infected).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfected([FromBody] InfectedDto dto)
        {
            var infected = new Infected(dto.Birthdate, dto.Sex, dto.Latitude, dto.Longitude);

            _infectedsCollection.InsertOne(infected);
            
            return StatusCode(201, "infected successfully added");
        }

        [HttpGet]
        public ActionResult ObterInfecteds()
        {
            var infecteds = _infectedsCollection.Find(Builders<Infected>.Filter.Empty).ToList();
            
            return Ok(infecteds);
        }
    }
}
