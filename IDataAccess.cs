namespace Employee
{
    public interface IDataAccess
    {
        void CreateEntity(EmployeeEntity employee, EmploymentEntity employment);
        List<EmployeeEntity> ReadEmployeeEntity(string offset);
        List<EmploymentEntity> ReadEmploymentEntity(string offset);
        void UpdateEntity(EmployeeEntity Employee, string Query);
        void DeleteEntity(EmployeeEntity Employee, string Query);
    }
}
