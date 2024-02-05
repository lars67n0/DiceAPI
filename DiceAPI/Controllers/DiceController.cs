using Microsoft.AspNetCore.Mvc;
using DiceLib;
using DiceAPI.Repository;

namespace DiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiceController : Controller
    {
        private DiceRep _diceRep;

        public DiceController(DiceRep diceRep)
        {
            _diceRep = diceRep;
        }

        // Get All
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<List<Dice>> Get()
        {
            List<Dice> result = _diceRep.GetAll();
            if (result.Count < 1) { return NoContent(); }
            return Ok(result);
        }
        // Get By Id
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("id")]
        public ActionResult<Dice> Get(int Id)
        {
            Dice? found = _diceRep.GetById(Id);
            if (found == null) { return NotFound(); }
            return Ok(found);
        }
        // Create New
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public ActionResult<Dice> Post([FromBody] Dice newDice)
        {
            try
            {
                Dice createDice = _diceRep.Add(newDice);
                return Created($"api/Dice/{createDice.Id}", createDice);
            }

            catch (ArgumentNullException ex) { return BadRequest(ex.Message); }

            catch (ArgumentOutOfRangeException ex) { return BadRequest(ex.Message); }

            catch (ArgumentException ex) { return BadRequest(ex.Message); }

        }
        // Update 
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Dice> put(int id, Dice newDice)
        {
            try
            {
                Dice? Update = _diceRep.Update(id, newDice);
                if (Update == null) { return NotFound(); }
                return Ok(Update);
            }

            catch (ArgumentNullException ex) { return BadRequest(ex.Message); }

            catch (ArgumentOutOfRangeException ex) { return BadRequest(ex.Message); }

            catch (ArgumentException ex) { return BadRequest(ex.Message); }

        }
    }
}
