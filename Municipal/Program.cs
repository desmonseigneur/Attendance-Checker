using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Municipal;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Municipal
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Build a configuration object from appsettings.json
            var configurationBuilder = new ConfigurationBuilder()
    .SetBasePath(@"C:\Users\jmasu\source\repos\Municipal\Municipal") // Replace with your actual path
    .AddJsonFile("appsettings.json", optional: false);

            IConfiguration configuration = configurationBuilder.Build();

            // Create an instance of the database service with configuration
            IDatabaseService databaseService = new MyDatabaseService(configuration);

            // Pass the database service to the Form1 constructor
            Application.Run(new Form1());
        }
    }
}