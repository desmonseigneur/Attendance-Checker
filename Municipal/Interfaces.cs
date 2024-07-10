using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Municipal
{
        public interface IDatabaseService
        {
            void CheckInEmployee(string name, string dept, string pos, DateTime now);
            void UpdateEmployeeCheckout(string name, DateTime checkoutTime);
            string GetEmployeeID(string name); // Optional if needed in Form1
        }
}
