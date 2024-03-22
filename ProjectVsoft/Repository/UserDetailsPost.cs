using Microsoft.AspNetCore.Http.HttpResults;
using ProjectVsoft.Models;
using ProjectVsoft.other;
using System.Data.SqlClient;

namespace ProjectVsoft.Repository
{
    public class UserDetailsPost : IUserDetailsPost
    {
        private readonly IConfiguration _configuration;
        //private readonly IEmailSender _mail;
        public UserDetailsPost(IConfiguration configuration)
        {
            _configuration = configuration;
            //_mail = mail;
        }
        public async Task<bool> InsertUserAsync(UserDetails userDetails)
        {

            Dictionary<string, string> MailCredentials = new Dictionary<string, string>();
            Dictionary<string, string> MailContents;
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync();
                    using( SqlCommand cmd = new SqlCommand("SpInsertUserDetails", conn)) {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FirstName",userDetails.FirstName);
                        cmd.Parameters.AddWithValue("@LastName",userDetails.LastName);
                        cmd.Parameters.AddWithValue("@Email", userDetails.Email);
                        cmd.Parameters.AddWithValue("@PhoneNumber", userDetails.PhoneNumber);
                        cmd.Parameters.AddWithValue("@CreatedBy", userDetails.CreatedBy);
                        cmd.Parameters.AddWithValue("@UpdatedBy", userDetails.UpdatedBy);
                        cmd.Parameters.AddWithValue("@Status", userDetails.Status);
                        cmd.Parameters.AddWithValue("@Remark", userDetails.Remark);

                        string ToBeHashed = userDetails.FirstName + userDetails.Email;
                        string HashedPassword = PasswordCrypt.SHA1Hashing(ToBeHashed);
                        cmd.Parameters.AddWithValue("@Password", HashedPassword);
                        
                        int res = await cmd.ExecuteNonQueryAsync();
                        //if(res > 0)
                        //{
                        //    MailContents = await _mail.SendMessage(MailCredentials);
                        //    if (await _mail.SendEmail(MailContents))
                        //    {
                        //        MailContents.Clear();
                        //        MailCredentials.Clear();
                        //    }
                        //}
                        return res>0;
                    }

                }catch (Exception ex)
                {
                    Console.WriteLine($"something went wrong{ex.Message}");
                    return false;
                }
            }
        }
        //public async Task<bool> UserEmailExists(String Email)
        //{
        //    string ConnectionString = _configuration.GetConnectionString("MyDb");
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();
        //        string qry = "SELECT * FROM UserDetails WHERE Email=@Email";
        //        using (SqlCommand command = new SqlCommand(qry, connection))
        //        {
        //            command.Parameters.AddWithValue("@Email", Email);
        //            SqlDataReader sqlDataReader = await command.ExecuteReaderAsync();

        //            return sqlDataReader.HasRows;
        //        }
        //    }
        //}
    }
}