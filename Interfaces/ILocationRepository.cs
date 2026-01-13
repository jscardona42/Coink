using Coink.Dtos;

namespace Coink.Interfaces
{
    public interface ILocationRepository
    {
        Task<IEnumerable<CountryDto>> GetCountriesAsync();
        Task<IEnumerable<DepartmentDto>> GetDepartmentsByCountryAsync(long countryId);
        Task<IEnumerable<MunicipalityDto>> GetMunicipalitiesByDepartmentAsync(long departmentId);
    }

}
