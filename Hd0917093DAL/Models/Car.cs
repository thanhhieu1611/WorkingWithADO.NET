using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hd0917093DAL.Models
{
    public class Car
    {
        #region Properties
        public int CarId { get; set; }
        public string Color { get; set; }
        public string Make { get; set; }
        public string PetName { get; set; }
        #endregion

        #region Constructor
        public Car()
        {
        }
        #endregion

        #region Methods
        //Display each object
        public override string ToString()
        {
            return $"-> Car #{this.CarId} is a {this.Make}.";
        }

        #endregion
    }//End class
}
