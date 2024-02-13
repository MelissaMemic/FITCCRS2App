using FITCCRS2App.Services;
using FITCCRS2App.Services.Services.BaseServices;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FITCCApp.Controllers
{
    [Route("[controller]")]
    public class BaseCRUDController<T, TSearch, TInsert, TUpdate> : BaseController<T, TSearch> where T : class where TSearch : class
    {
        protected new readonly ICRUDService<T, TSearch, TInsert, TUpdate> _service;

        public BaseCRUDController(ILogger<BaseController<T, TSearch>> logger, ICRUDService<T, TSearch, TInsert, TUpdate> service)
            : base(logger, service)
        {
            _service = service;
        }

        [HttpPost]
        public virtual async Task<IActionResult> Insert([FromBody] TInsert insert)
        {
            try
            {
                var result = await _service.Insert(insert);
                return Ok(result); 
            }
            catch (DuplicateEntityException ex)
            {
                return BadRequest(new { message = ex.Message }); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" }); 
            }
        }
        [HttpPut("{id}")]
        public virtual async Task<T> Update(int id, [FromBody] TUpdate update)
        {
            return await _service.Update(id, update);
        }

        [HttpDelete("{id}")]
        public virtual async Task<bool> Delete(int id)
        {
            return await _service.DeleteAsync(id);
        }
  


    }
}
