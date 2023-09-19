using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ZdalyTest.Models;
using ZdalyTest.Services;

namespace ZdalyTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly CsvService _csvService;

        public DataController(CsvService csvService)
        {
            _csvService = csvService;
        }

        [HttpGet("table")]
        public ActionResult<IEnumerable<Data>> GetTableData()
        {
            try
            {
                // Read data from the CSV file using your CsvService
                var tableData = _csvService.ReadDataFromCsv();

                // Select only the required columns
                var filteredData = tableData.Select(data => new
                {
                    data.STATION_ID,
                    data.SITE_NAME,
                    data.STATE,
                    data.CITY,
                    data.ADDRESS,
                    data.CLUSTER_MEDIAN_PRICE,
                    data.CLIENT_MARKET_PRICE
                });

                return Ok(filteredData);
            }
            catch (Exception ex)
            {
                // Handle any exceptions here (e.g., log or throw)
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
