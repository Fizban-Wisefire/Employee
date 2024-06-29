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
            detail_id = detail_id;
            employee_id = employee_id;
            department = department;
            job_title = job_title;
            supervisor = supervisor;
            employment_status = employment_status;
            date_of_hire = date_of_hire;
            employment_type = employment_type;

        }

    }
}
