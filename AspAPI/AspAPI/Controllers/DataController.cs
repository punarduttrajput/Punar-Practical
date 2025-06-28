using AspAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AspAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly ILogger<DataController> _logger;
        public DataController(ILogger<DataController> logger)
        {
            _logger = logger;
        }

        /// <summary>  
        /// Retrieves data from the JSON file.  
        /// </summary>  
        /// <returns>Returns the data if found, otherwise returns a NotFound response.</returns>  
        [HttpGet]
        [Route("getdata")]
        public IActionResult GetData()
        {
            _logger.LogInformation("GetData action invoked.");
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "data.json");
            if (!System.IO.File.Exists(filePath))
            {
                _logger.LogWarning("Data file not found.");
                return NotFound(new { Message = "Data file not found." });
            }

            var jsonData = System.IO.File.ReadAllText(filePath);
            var data = JsonSerializer.Deserialize<ObservationModel>(jsonData);
            _logger.LogInformation("Data retrieved successfully.");
            return Ok(data);
        }

        /// <summary>  
        /// Saves the provided data to the JSON file.  
        /// </summary>  
        /// <param name="data">The data to save.</param>  
        /// <returns>Returns a success message or an error response.</returns>  
        [HttpPost]
        [Route("savedata")]
        public IActionResult SaveData([FromBody] ObservationModel data)
        {
            _logger.LogInformation("SaveData action invoked.");
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "data.json");
            try
            {
                var jsonData = JsonSerializer.Serialize(data);
                System.IO.File.WriteAllText(filePath, jsonData);
                _logger.LogInformation("Data saved successfully.");
                return Ok(new { Message = "Data saved successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving data.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Error saving data.", Error = ex.Message });
            }
        }

        /// <summary>  
        /// Updates the existing data in the JSON file.  
        /// </summary>  
        /// <param name="data">The data to update.</param>  
        /// <returns>Returns a success message or an error response.</returns>  
        [HttpPut]
        [Route("updatedata")]
        public IActionResult UpdateData([FromBody] ObservationModel data)
        {
            _logger.LogInformation("UpdateData action invoked.");
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "data.json");
            if (!System.IO.File.Exists(filePath))
            {
                _logger.LogWarning("Data file not found.");
                return NotFound(new { Message = "Data file not found." });
            }
            try
            {
                var jsonData = JsonSerializer.Serialize(data);
                System.IO.File.WriteAllText(filePath, jsonData);
                _logger.LogInformation("Data updated successfully.");
                return Ok(new { Message = "Data updated successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating data.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Error updating data.", Error = ex.Message });
            }
        }
    }
    }
