using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DataAccessLayer;

namespace Api
{
    public class EmployeeRepository : SqlRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(string connectionString) : base(connectionString) { }

        public override async void DeleteAsync(int id)
        {
            using (var conn = GetOpenConnection())
            {
                var sql = "DELETE FROM Employee WHERE Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, System.Data.DbType.Int32);
                await conn.QueryFirstOrDefaultAsync<Employee>(sql, parameters);
            }
        }

        public override async Task<IEnumerable<Employee>> GetAllAsync()
        {
            using (var conn = GetOpenConnection())
            {
                var sql = "SELECT * FROM Employee";
                return await conn.QueryAsync<Employee>(sql);
            }
        }

        public override async Task<Employee> FindAsync(int id)
        {
            using (var conn = GetOpenConnection())
            {
                var sql = "SELECT * FROM Employee WHERE Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, System.Data.DbType.Int32);
                return await conn.QueryFirstOrDefaultAsync<Employee>(sql, parameters);
            }
        }

        public override async void InsertAsync(Employee entity)
        {
            using (var conn = GetOpenConnection())
            {
                var sql = "INSERT INTO Employee(Name) "
                    + "VALUES(@Name)";

                var parameters = new DynamicParameters();
                parameters.Add("@Name", entity.Name, System.Data.DbType.String);

                await conn.QueryAsync(sql, parameters);
            }
        }

        public override async void UpdateAsync(Employee entityToUpdate)
        {
            using (var conn = GetOpenConnection())
            {
                var existingEntity = await FindAsync(entityToUpdate.Id);

                var sql = "UPDATE Employee "
                    + "SET ";

                var parameters = new DynamicParameters();
                if (existingEntity.Name != entityToUpdate.Name)
                {
                    sql += "Name=@Name,";
                    parameters.Add("@Name", entityToUpdate.Name, DbType.String);
                }

                sql = sql.TrimEnd(',');

                sql += " WHERE Id=@Id";
                parameters.Add("@Id", entityToUpdate.Id, DbType.Int32);

                await conn.QueryAsync(sql, parameters);
            }
        }

        public Task<bool> MyCustomRepositoryMethodExampleAsync()
        {
            throw new NotImplementedException();
        }
    }
}
