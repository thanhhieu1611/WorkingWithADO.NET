using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hd0917093DAL.Models
{
    public class Customer
    {
        #region Properties
        public int CustId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        #endregion

        #region Constructor
        public Customer()
        {
        }
        #endregion

        #region Methods
        //Display each object
        public override string ToString()
        {
            return $"-> Customer #{this.CustId} is {this.FirstName} {this.LastName}.";
        }
        #endregion
    }
}
