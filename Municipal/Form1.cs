using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Municipal;
using MySql.Data.MySqlClient; //MySQL DB Access


namespace Municipal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false; // Ensures maximize is disabled even if the border style allows it
        }
        private MySqlConnection GetConnection() // Creates a connection string to the MySQL database
        {
            string connstring = "server=localhost;port=3306;database=municipaldb;uid=root;password=Edelwe!ss00;";
            return new MySqlConnection(connstring);
        }
        public class Employee // Represents an employee with properties for name, department, and position
        {
            [Required]
            public string Name { get; set; }
            [StringLength(60)]
            public string Department { get; set; }
            [StringLength(50)]
            public string Position { get; set; }
        }
        private void CheckIn_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee // Create an Employee object from the textbox data
            {
                Name = NameBox.Text,
                Department = DeptBox.Text,
                Position = PosBox.Text
            };

            if (ValidateEmployee(employee)) // Assuming a separate validation function exists (not shown here)
            {
                InsertEmployee(employee); // Insert valid data into database
            }
        }
        private bool ValidateEmployee(Employee employee) // Validates the employee object (assuming data annotations are used)
        {
            ValidationContext context = new ValidationContext(employee);
            List<ValidationResult> results = new List<ValidationResult>();
            Validator.TryValidateObject(employee, context, results, true);

            if (results.Count > 0)
            {
                StringBuilder errorMessage = new StringBuilder();
                errorMessage.AppendLine("Please fix the following errors:");
                foreach (ValidationResult result in results)
                {
                    // Don't clear the StringBuilder inside the loop
                    errorMessage.AppendLine($"- {result.ErrorMessage}");
                }
                MessageBox.Show(errorMessage.ToString(), "Validation Error");
                return false;
            }
            return true;
        }
        private void InsertEmployee(Employee employee) // Inserts a new employee record into the database
        {
            using (MySqlConnection con = GetConnection())
            {
                con.Open();

                string query = "INSERT INTO employee_tb (employee_name, employee_department, employee_position, check_in) VALUES (@name, @dept, @pos, @checkIn)";
                MySqlCommand command = new MySqlCommand(query, con);
                command.Parameters.AddWithValue("@name", employee.Name);
                command.Parameters.AddWithValue("@dept", employee.Department);
                command.Parameters.AddWithValue("@pos", employee.Position);
                command.Parameters.AddWithValue("@checkIn", DateTime.Now);

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Employee checked in successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking in employee: " + ex.Message);
                }
            }
        }
        private void CheckOut_Click(object sender, EventArgs e)
        {
            string name = NameBox.Text;

            // Check for empty/whitespace
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter the employee name to check out.");
                return;
            }            
            string expectedCaseName = StandardizeCase(name); // Standardize the case of the name (e.g., title case)
            if (name != expectedCaseName)
            {
                MessageBox.Show("Incorrect name format. Please enter the name in the correct case.");
                NameBox.Select(0, name.Length); // Select all text for easy correction
                return;
            }

            DateTime checkoutTime = DateTime.Now;
            UpdateEmployeeCheckout(expectedCaseName, checkoutTime);
        }
        private string StandardizeCase(string name) // Converts the name to the desired case format (e.g., title case)
        {            
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo; 
            return textInfo.ToTitleCase(name.ToLower()); // Convert to lowercase then to title case
        }
        private void UpdateEmployeeCheckout(string name, DateTime checkoutTime) // Updates the checkout time for the employee with the given name
        {
            using (MySqlConnection con = GetConnection())
            {
                con.Open();

                string query = "UPDATE employee_tb SET check_out = @checkoutTime WHERE employee_id = @employeeID"; // Find the employee ID based on the name
                MySqlCommand command = new MySqlCommand(query, con);
                command.Parameters.AddWithValue("@employeeID", GetEmployeeID(name));
                command.Parameters.AddWithValue("@checkoutTime", checkoutTime);

                try
                {
                    int rowsAffected = command.ExecuteNonQuery(); // Assuming only one record is returned due to the order by descending employee ID
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Employee checked out successfully!");
                    }
                    else
                    {
                        // Check data type or employee existence
                        string checkQuery = "SELECT employee_name FROM employee_tb WHERE employee_name = @name";
                        MySqlCommand checkCommand = new MySqlCommand(checkQuery, con);
                        checkCommand.Parameters.AddWithValue("@name", name);

                        using (MySqlDataReader reader = checkCommand.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                MessageBox.Show("Employee not found."); // Employee doesn't exist
                            }
                            else
                            {
                                MessageBox.Show("Invalid data type entered. Please enter a valid employee name."); // Data type mismatch
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking out employee: " + ex.Message);
                }
            }
        }
        private string GetEmployeeID(string name) // Gets the employee ID based on the employee name (assuming unique names)
        {
            using (MySqlConnection con = GetConnection())
            {
                con.Open();

                string query = "SELECT employee_id FROM employee_tb WHERE employee_name = @name ORDER BY employee_id DESC";
                MySqlCommand command = new MySqlCommand(query, con);
                command.Parameters.AddWithValue("@name", name);

                string employeeID = null;
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read(); // Assuming only one record is returned due to the sort
                        int id = reader.GetInt32("employee_id");
                        employeeID = id.ToString();
                    }
                }
                return employeeID;
            }
        }
    }
}