using Microsoft.AspNetCore.Http.HttpResults;
using ProjectVsoft.Models;
using ProjectVsoft.other;
using System.Data.SqlClient;

namespace ProjectVsoft.Repository
{
    public class UserLogin :IUserLogin
    {
        
        private readonly IConfiguration _configuration;
        public UserLogin(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> InsertUserLoginAsync(UserLoginDetails userLoginDetails)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SpInsertUserLogin2", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        string pwd = PasswordCrypt.SHA1Hashing(userLoginDetails.Password);
                        Console.WriteLine(pwd);


                        cmd.Parameters.AddWithValue("@Password", pwd);
                        cmd.Parameters.AddWithValue("@UserTypeId", userLoginDetails.UserTypeId);
                        cmd.Parameters.AddWithValue("@CreatedBy", userLoginDetails.CreatedBy);
                        cmd.Parameters.AddWithValue("@UpdatedBy", userLoginDetails.UpdatedBy);

                        await cmd.ExecuteNonQueryAsync();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return false;
                }
            }
        }
    }
}
