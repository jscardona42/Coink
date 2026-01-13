using Coink.Dtos;
using Coink.Interfaces;

public class LocationService
{
    private readonly ILocationRepository _repository;

    public LocationService(ILocationRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CountryDto>> GetCountriesAsync()
        => await _repository.GetCountriesAsync();

    public async Task<IEnumerable<DepartmentDto>> GetDepartmentsByCountryAsync(long countryId)
        => await _repository.GetDepartmentsByCountryAsync(countryId);

    public async Task<IEnumerable<MunicipalityDto>> GetMunicipalitiesByDepartmentAsync(long departmentId)
        => await _repository.GetMunicipalitiesByDepartmentAsync(departmentId);
}
