using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace api_rest_test.Domain.Persistence
{
    public class DAC
    {
        private string connetionString = "Data Source=localhost;Initial Catalog=bootcampDemo-1.0;User ID=sa;Password=bootcamp";

        public SqlConnection connection;

        public DAC() {
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                Console.WriteLine("connection.Open");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ~DAC()
        {
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Console.WriteLine("connection.Close");
            }
        }
    }
}
