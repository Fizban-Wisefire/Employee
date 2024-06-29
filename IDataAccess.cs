namespace Employee
{
    public interface IDataAccess
    {
        void CreateEntity(EmployeeEntity employee, EmploymentEntity employment);
        List<EmployeeEntity> ReadEntity(string offset);
        void UpdateEntity(EmployeeEntity Employee, string Query);
        void DeleteEntity(EmployeeEntity Employee, string Query);
    }
}
