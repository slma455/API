using FormulaAPI.Core;
using FormulaAPI.Data;
using FormulaAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormulaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        public readonly IUnitOfWork unitOfWork;
        //private readonly ApiDbContext apicontext;
        public DriversController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task< IActionResult> Get()
        {
            return Ok(await unitOfWork.DriverRepository.All());
        }

        [HttpGet]
        [Route("/[controller]/[action]/{id}")]
        public async Task< IActionResult> Get(int id)
        {

            var driver = await unitOfWork.DriverRepository.GetById(id);
            if (driver == null) return NotFound();
            return Ok(driver);
        }

        [HttpPost]
        [Route("AddDriver")]
        public async Task< IActionResult> AddDriver(Driver driver)
        {
            await unitOfWork.DriverRepository.Add(driver);
            await unitOfWork.CompleteAsync();
            return Ok();
        }
        //[HttpDelete]
        //[Route("DeleteDriver")]
        //public async Task< IActionResult> DeleteDriver(int id)
        //{
        //    var driver = apicontext.drivers.FirstOrDefault(x => x.Id == id);
        //    if (driver != null) return NotFound();
        // apicontext.drivers.Remove(driver);
        //    await apicontext.SaveChangesAsync();

        //    return NoContent();
        //}
        [HttpDelete]
        [Route("DeleteDriver")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            var driver = await unitOfWork.DriverRepository.GetById(id);
            if (driver == null) return NotFound();

            await unitOfWork.DriverRepository.Delete(driver);
            await unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpPatch]
        [Route("UpdateDriver")]
        public async Task< IActionResult> UpdateDriver(Driver driver)
        {
            var existDriver = await unitOfWork.DriverRepository.GetById(driver.Id);
            if (existDriver == null) return NotFound();
            await unitOfWork.DriverRepository.Update(driver);
            await unitOfWork.CompleteAsync();
            return NoContent();
        }
    }

}
