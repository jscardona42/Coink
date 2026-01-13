using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/locations")]
public class LocationsController : ControllerBase
{
    private readonly LocationService _service;

    public LocationsController(LocationService service)
    {
        _service = service;
    }

    [HttpGet("countries")]
    public async Task<IActionResult> GetCountries()
        => Ok(await _service.GetCountriesAsync());

    [HttpGet("countries/{countryId}/departments")]
    public async Task<IActionResult> GetDepartments(long countryId)
        => Ok(await _service.GetDepartmentsByCountryAsync(countryId));

    [HttpGet("departments/{departmentId}/municipalities")]
    public async Task<IActionResult> GetMunicipalities(long departmentId)
        => Ok(await _service.GetMunicipalitiesByDepartmentAsync(departmentId));
}
