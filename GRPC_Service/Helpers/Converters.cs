using GRPC_Service.Protos;

namespace GRPC_Service.Helpers
{
    public static class Converters
    {
        public static PersonModel ConvertToProtoPerson(this Entities.Person? data)
        {
            return data != null ? new PersonModel
            {
                Id = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                NationalCode = data.NationalCode,
                BirthDate = new Date
                {
                    Year = data.BirthDate.Year,
                    Month = data.BirthDate.Month,
                    Day = data.BirthDate.Day,
                }
            } : new PersonModel();
        }

        public static Entities.Person ConvertToPerson(this PersonModel? data)
        {
            return data != null ? new Entities.Person
            {
                Id = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                NationalCode = data.NationalCode,
                BirthDate = new DateOnly(data.BirthDate.Year, data.BirthDate.Month, data.BirthDate.Day)
            } : new Entities.Person();
        }

    }
}
