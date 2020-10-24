using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hd0917093DAL.Models
{
    public class Order
    {
        #region Properties
        public int OrderId { get; set; }
        public int CustId { get; set; }
        public int CarId { get; set; }
        #endregion

        #region Constructor
        public Order()
        {
        }
        #endregion

        #region Methods
        //Display each object
        public override string ToString()
        {
            return $"-> Order #{this.OrderId} for customer #{this.CustId} of car #{this.CarId}.";
        }
        #endregion
    }
}
