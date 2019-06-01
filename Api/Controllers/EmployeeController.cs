using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository _employeeRepo;

        public EmployeeController(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var employees = await _employeeRepo.GetAllAsync();
            return Newtonsoft.Json.JsonConvert.SerializeObject(employees);
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _employeeRepo.InsertAsync(employee);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee employee)
        {
            _employeeRepo.UpdateAsync(employee);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _employeeRepo.DeleteAsync(id);
            return Ok();
        }
    }
}