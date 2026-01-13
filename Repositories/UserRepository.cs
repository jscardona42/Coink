using Coink.Dtos;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;
using Coink.Interfaces;

namespace Coink.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task CreateUserAsync(UserDto user)
        {
            using var connection = new NpgsqlConnection(
                _configuration.GetConnectionString("PostgresConnection")
            );

            await connection.ExecuteAsync(
                "sp_create_user",
                new
                {
                    p_name = user.Name,
                    p_phone = user.Phone,
                    p_address = user.Address,
                    p_municipality_id = user.MunicipalityId
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<UserResponseDto>> GetUsersAsync()
        {
            using IDbConnection conn = new NpgsqlConnection(
                _configuration.GetConnectionString("PostgresConnection")
            );

            var sql = @"
            SELECT
                u.id            AS ""UserId"",
                u.name          AS ""UserName"",
                u.phone         AS ""Phone"",
                u.address       AS ""Address"",
                m.id            AS ""MunicipalityId"",
                m.name          AS ""MunicipalityName"",
                d.id            AS ""DepartmentId"",
                d.name          AS ""DepartmentName"",
                c.id            AS ""CountryId"",
                c.name          AS ""CountryName""
            FROM users u
            JOIN municipalities m ON m.id = u.municipality_id
            JOIN departments d    ON d.id = m.department_id
            JOIN countries c      ON c.id = d.country_id;
        ";

            return await conn.QueryAsync<UserResponseDto>(sql);
        }

    }
}
