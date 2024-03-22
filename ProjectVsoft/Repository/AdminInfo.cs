using ProjectVsoft.Models;
using System.Data.SqlClient;

namespace ProjectVsoft.Repository
{
    public class AdminInfo : IAdminInfo
    {
        private readonly IConfiguration _configuration;
        public AdminInfo(IConfiguration configuration)
        {
                _configuration = configuration;
        }
        //Task<IEnumerable<AdminLoginDetails>> GetAdminInfoAsync();
        public async Task<IEnumerable<AdminLoginDetails>> GetAdminInfoAsync()
        {   List<AdminLoginDetails> result = new List<AdminLoginDetails>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString)) 
            {
                await con.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("select * from AdminLoginDetails", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        
                        while (reader.Read())
                        {
                            AdminLoginDetails ald = new AdminLoginDetails();
                            ald.AdminLoginId = Convert.ToInt32(reader["AdminLoginId"]);
                            ald.Password = reader["Password"].ToString();
                            ald.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                            ald.CreatedBy = Convert.ToInt32(reader["CreatedBy"]);
                            ald.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
                            ald.UpdatedBy = Convert.ToInt32(reader["UpdatedBy"]);
                            result.Add(ald);
                        }
                        return result;
                    }
                    
                }
               
            }
        }
        


    }
}
