namespace EmployeesMiniApp.DAL
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Salary { get; set; }

        public override string ToString()
        {
            string id = Id.ToString();
            string firstName = FirstName.ToString();
            string lastName = LastName.ToString();
            string salary = Salary.ToString();
            return $"{id + new string(' ', 3 - id.Length)}|" +
                $"{firstName + new string(' ', 20 - firstName.Length)}|" +
                $"{lastName + new string(' ', 20 - lastName.Length)}|" +
                $"{salary + new string(' ', 10 - salary.Length)}|";
        }
    }
}