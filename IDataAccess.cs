namespace Employee
{
    public interface IDataAccess
    {
        void CreateEntity(EmployeeEntity employee);
        List<EmployeeEntity> ReadEntity();
        void UpdateEntity(EmployeeEntity Employee, string Query);
        void DeleteEntity(EmployeeEntity Employee, string Query);
    }
}
