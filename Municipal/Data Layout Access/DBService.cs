public class DatabaseService
{
    public class DatabaseService : IDatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        public void CheckInEmployee(string name, string dept, string pos, DateTime now)
        {
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {
                con.Open();

                string query = "INSERT INTO employee_tb (employee_name, employee_department, employee_position, check_in) VALUES (@name, @dept, @pos, @checkIn)";
                MySqlCommand command = new MySqlCommand(query, con);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@dept", dept);
                command.Parameters.AddWithValue("@pos", pos);
                command.Parameters.AddWithValue("@checkIn", now);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateEmployeeCheckout(string name, DateTime checkoutTime)
        {
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {
                con.Open();

                string query = "UPDATE employee_tb SET check_out = @checkoutTime WHERE employee_name = @name";
                MySqlCommand command = new MySqlCommand(query, con);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@checkoutTime", checkoutTime);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    throw new Exception("Employee not found for checkout.");
                }
            }
        }

        public string GetEmployeeID(string name)
        {
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {
                con.Open();

                string query = "SELECT employee_id FROM employee_tb WHERE employee_name = @name ORDER BY employee_id DESC LIMIT 1"; // Retrieve only the first record
                MySqlCommand command = new MySqlCommand(query, con);
                command.Parameters.AddWithValue("@name", name);

                string employeeID = null;
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        employeeID = reader.GetInt32("employee_id").ToString();
                    }
                }

                return employeeID;
            }
        }
    }
}