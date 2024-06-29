namespace Employee
{
    public class EmployeeEntity
    {

        // Employee Details Info

        public int employee_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateOnly date_of_birth { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }

        public EmployeeEntity(int employee_id, string first_name, string last_name, DateOnly date_of_birth, string gender, string address, string email, string phone_number) 
        {
            employee_id = employee_id;
            first_name = first_name;
            last_name = last_name;
            date_of_birth = date_of_birth;
            gender = gender;
            address = address;
            email = email;
            phone_number = phone_number;
        }
    }
}
