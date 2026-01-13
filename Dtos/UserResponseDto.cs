namespace Coink.Dtos
{
    public class UserResponseDto
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public long MunicipalityId { get; set; }
        public string MunicipalityName { get; set; }

        public long DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public long CountryId { get; set; }
        public string CountryName { get; set; }
    }

}
