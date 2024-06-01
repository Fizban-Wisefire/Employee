namespace Employee
{
    public class EmployeeEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Department {  get; set; }

        public EmployeeEntity(string name, int age, string department) 
        {
            Name = name;
            Age = age;
            Department = department;
        }
    }
}
