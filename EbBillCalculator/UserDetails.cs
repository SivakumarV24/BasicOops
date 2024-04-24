using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace EbBillCalculator
{
    public class UserDetails
    {
        /// <summary>
        /// This class Used for store userDatails.
        /// </summary>
        private static int s_id=1000;
        public UserDetails()
        {
            s_id++;
            MeterId="EB"+s_id;

        }
        public string MeterId { get; set; }
        public string UserName { get; set; }
        public double PhoneNumber { get; set; }
        public string MailId { get; set; }
    }
}