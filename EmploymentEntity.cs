namespace Employee
{
    public class EmploymentEntity
    {
        // Employment Details Info

        public int detail_id { get; set; }
        public int employee_id { get; set; }
        public string department { get; set; }
        public string job_title { get; set; }
        public string supervisor { get; set; }
        public string employment_status { get; set; }
        public DateOnly date_of_hire { get; set; }
        public string employment_type { get; set; }

        public EmploymentEntity(int detail_id, int employee_id, string department, string job_title, string supervisor, string employment_status, DateOnly date_of_hire, string employment_type)
        {

            Console.WriteLine($"{department} {job_title} {supervisor} {employment_status} {date_of_hire} {employment_type}");

            this.detail_id = detail_id;
            this.employee_id = employee_id;
            this.department = department;
            this.job_title = job_title;
            this.supervisor = supervisor;
            this.employment_status = employment_status;
            this.date_of_hire = date_of_hire;
            this.employment_type = employment_type;

        }

    }
}
