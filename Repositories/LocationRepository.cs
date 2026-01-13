using Coink.Dtos;
using Coink.Interfaces;
using Dapper;
using Npgsql;
using System.Data;

public class LocationRepository : ILocationRepository
{
    private readonly IConfiguration _configuration;

    public LocationRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<IEnumerable<CountryDto>> GetCountriesAsync()
    {
        using IDbConnection conn = new NpgsqlConnection(
            _configuration.GetConnectionString("PostgresConnection")
        );

        var sql = @"
            SELECT
                id   AS ""Id"",
                name AS ""Name""
            FROM countries
            ORDER BY name;
        ";

        return await conn.QueryAsync<CountryDto>(sql);
    }

    public async Task<IEnumerable<DepartmentDto>> GetDepartmentsByCountryAsync(long countryId)
    {
        using IDbConnection conn = new NpgsqlConnection(
            _configuration.GetConnectionString("PostgresConnection")
        );

        var sql = @"
            SELECT
                id         AS ""Id"",
                name       AS ""Name"",
                country_id AS ""CountryId""
            FROM departments
            WHERE country_id = @CountryId
            ORDER BY name;
        ";

        return await conn.QueryAsync<DepartmentDto>(sql, new { CountryId = countryId });
    }

    public async Task<IEnumerable<MunicipalityDto>> GetMunicipalitiesByDepartmentAsync(long departmentId)
    {
        using IDbConnection conn = new NpgsqlConnection(
            _configuration.GetConnectionString("PostgresConnection")
        );

        var sql = @"
            SELECT
                id             AS ""Id"",
                name           AS ""Name"",
                department_id  AS ""DepartmentId""
            FROM municipalities
            WHERE department_id = @DepartmentId
            ORDER BY name;
        ";

        return await conn.QueryAsync<MunicipalityDto>(sql, new { DepartmentId = departmentId });
    }
}
