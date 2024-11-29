namespace WebApplicationDemo.Model
{
    public class PersonItems
    {
        public IList<PersonModel> Items { get; set; }
    }

    public class PersonModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public PersonBirthDate BirthDate { get; set; }
    }

    public class PersonBirthDate
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
    }

    public class DeletePersonResponse
    {
        public bool IsDelete { get; set; }
    }
}
