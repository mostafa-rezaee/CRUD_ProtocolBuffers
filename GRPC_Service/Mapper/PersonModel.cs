namespace GRPC_Service.Mapper
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}
