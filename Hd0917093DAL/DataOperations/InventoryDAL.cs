using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//Import Configuration for System.Configuration.dll reference
using System.Configuration;
//Import ADO.Net data providers
using System.Data;
using System.Data.Common;
using static System.Console;
//Import models class
using Hd0917093DAL.Models;

namespace Hd0917093DAL.DataOperations
{
    public class InventoryDAL
    {
        # region Class level variables
        //Connection variable
        private DbProviderFactory factory;
        //private readonly string connectionString;
        private DbConnection connection;

        #endregion

        #region Constructor
        public InventoryDAL()
        {
            #region Get Connection from appSetting ex
            //Get Connection string/provider from *.config/appSetting.
            //string dataProvider = ConfigurationManager.AppSettings["provider"];
            //string connectionString = ConfigurationManager.AppSettings["connectionString"];
            #endregion

            //Get Connection string/provider from *.config/connectionStrings.
            string dataProvider = ConfigurationManager.AppSettings["provider"];
            string connectionString = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;

            //Get the factory provider
            factory = DbProviderFactories.GetFactory(dataProvider);

            //Now get the connection object
            connection = factory.CreateConnection();
            if (connection == null)
            {
                throw new NullReferenceException("Exception: Connection can't be null");
            }
            WriteLine($"Your connection object is a: {connection.GetType().Name}");
            connection.ConnectionString = connectionString;            
        }
        #endregion

        #region METHODS
        //Open connection
        private void OpenConnection()
        {
            connection.Open();
        }

        //Close Connection
        private void CloseConnection()
        {
            if (connection?.State != ConnectionState.Closed)
            {
                connection?.Close();
            }
        }

        //Get current inventory from Database
        public List<Car> GetAllInventory()
        {
            //This will hold the records
            List<Car> inventory = new List<Car>();

            using (connection)
            {
                OpenConnection();

                //Make command object
                DbCommand command = factory.CreateCommand();
                if (command == null)
                {
                    throw new NullReferenceException("Exception: Command can't be null");
                }
                WriteLine($"Your command object is a: {command.GetType().Name}");
                command.Connection = connection;
                command.CommandText = "Select * From Inventory";

                //Get Inventory data with data reader.
                using (DbDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    WriteLine($"Your data reader object is a: {dataReader.GetType().Name}");
                    WriteLine("\n**** Current Inventory ****");
                    while (dataReader.Read())
                    {
                        inventory.Add(new Car
                        {
                            CarId = (int)dataReader["CarId"],
                            Color = (string)dataReader["Color"],
                            Make = (string)dataReader["Make"],
                            PetName = (string)dataReader["PetName"]
                        });
                    }
                    dataReader.Close();
                }//end of using statement of data reader
                return inventory;
            }//end of using statement of connection
        }//End of GetAllInventory method

        //Get all customers from Database
        public List<Customer> GetAllCustomers()
        {
            //This will hold the records
            List<Customer> customerList = new List<Customer>();

            using (connection)
            {
                OpenConnection();

                //Make command object
                DbCommand command = factory.CreateCommand();
                if (command == null)
                {
                    throw new NullReferenceException("Exception: Command can't be null");
                }
                WriteLine($"Your command object is a: {command.GetType().Name}");
                command.Connection = connection;
                command.CommandText = "Select * From Customers";

                //Get Inventory data with data reader.
                using (DbDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    WriteLine($"Your data reader object is a: {dataReader.GetType().Name}");
                    WriteLine("\n**** Customer list ****");
                    while (dataReader.Read())
                    {
                        customerList.Add(new Customer
                        {
                            CustId = (int)dataReader["CustId"],
                            FirstName = (string)dataReader["FirstName"],
                            LastName = (string)dataReader["LastName"]
                        });
                    }
                    dataReader.Close();
                }//end of using statement of data reader
                return customerList;
            }//end of using statement of connection
        }//End of GetAllCustomers method   

        //Get all customers from Database
        public List<Order> GetAllOrders()
        {
            //This will hold the records
            List<Order> orderList = new List<Order>();

            using (connection)
            {
                OpenConnection();

                //Make command object
                DbCommand command = factory.CreateCommand();
                if (command == null)
                {
                    throw new NullReferenceException("Exception: Command can't be null");
                }
                WriteLine($"Your command object is a: {command.GetType().Name}");
                command.Connection = connection;
                command.CommandText = "Select * From Orders";

                //Get Inventory data with data reader.
                using (DbDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    WriteLine($"Your data reader object is a: {dataReader.GetType().Name}");
                    WriteLine("\n**** Order list ****");
                    while (dataReader.Read())
                    {
                        orderList.Add(new Order
                        {
                            OrderId = (int)dataReader["OrderId"],
                            CustId = (int)dataReader["CustId"],
                            CarId = (int)dataReader["CarId"]
                        });
                    }
                    dataReader.Close();
                }//end of using statement of data reader
                return orderList;
            }//end of using statement of connection
        }//End of GetAllCustomers method

        #endregion
    }
}
