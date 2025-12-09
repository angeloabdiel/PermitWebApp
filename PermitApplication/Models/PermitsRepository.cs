using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;

namespace PermitApplication.Models
{
    /// <summary>
    /// Class to handle database operations related to permits and counties
    /// </summary>
    public class PermitsRepository
    {
        private readonly string _connectionString;

        /// <summary>
        /// Constructor to initialize the repository with a connection string
        /// </summary>
        /// <param name="connectionString"></param>
        public PermitsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Method to add a permit request in the database
        /// </summary>
        /// <param name="submitterUser"></param>
        /// <returns></returns>
        public async Task AddPermitRequest(SubmitterUser submitterUser)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("CreatePermitAndSubmitter", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Name", submitterUser.FirstName);
                    command.Parameters.AddWithValue("@Lastname", submitterUser.LastName);
                    command.Parameters.AddWithValue("@Address", submitterUser.Address.FullUSPSAddress);
                    command.Parameters.AddWithValue("@Type_ID", submitterUser.PermitType.PermitTypeID);
                    command.Parameters.AddWithValue("@County_ID", submitterUser.County.CountyID);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        /// <summary>
        /// Method to get data from the Counties table to populate the counties dropdown
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public async Task<DataTable> GetDataAsyncForCounties(string sql)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        /// <summary>
        /// Method to get data from the PermitTypes table to populate the permit types dropdown
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public async Task<DataTable> GetDataAsyncForPermitsTypes(string sql)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
    }
}
