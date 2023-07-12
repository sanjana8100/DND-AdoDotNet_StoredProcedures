using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNet_StoredProcedures
{
    internal class StoreProcedureOperations
    {
        SqlConnection sqlConnection;

        public StoreProcedureOperations(string connectionString)
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public bool AddUsingNonTransactionStoredProcedure(string name, string lastname, string Email, DateTime OrderDate, string OrderTotal)
        {
            try
            {
                sqlConnection.Open();

                string query = "AddNewCustomerOrder";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@FirstName", name);
                sqlCommand.Parameters.AddWithValue("@LastName", lastname);
                sqlCommand.Parameters.AddWithValue("@EmailId", Email);
                sqlCommand.Parameters.AddWithValue("@OrderDate", OrderDate);
                sqlCommand.Parameters.AddWithValue("@OrderTotal", OrderTotal);

                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine($"{result} number of rows affected.");
                    Console.WriteLine("Data added.");
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public bool AddUsingTransactionStoredProcedure(string name, string lastname, string Email, DateTime OrderDate, string OrderTotal)
        {
            try
            {
                sqlConnection.Open();

                string Query = "AddNewCustomerOrderUsingTransaction";
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection, sqlTransaction);

                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@FirstName", name);
                sqlCommand.Parameters.AddWithValue("@LastName", lastname);
                sqlCommand.Parameters.AddWithValue("@EmailId", Email);
                sqlCommand.Parameters.AddWithValue("@OrderDate", OrderDate);
                sqlCommand.Parameters.AddWithValue("@OrderTotal", OrderTotal);

                try                                                                
                {
                    int result = sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();  
                    
                    Console.WriteLine($"{result} number of rows affected.");
                    Console.WriteLine("Data added.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Rolling Back the Changes...");
                    sqlTransaction.Rollback();                                     
                    Console.WriteLine(e);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Something went wrong....");
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public bool Display()
        {
            try
            {
                sqlConnection.Open();

                List<Order> list = new List<Order>();
                
                string Query = "GetOrderDetails";
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Order order = new Order()
                    {
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        OrderDate = (DateTime)reader["OrderDate"],
                        OrderTotal = (decimal)reader["OrderTotal"]
                    };
                    list.Add(order);
                }

                foreach (Order order in list)
                {
                    Console.WriteLine($"FirstName: {order.FirstName}\t LastName: {order.LastName} \t OrderDate: {order.OrderDate} \t OrderTotal: {order.OrderTotal}");

                }
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Something went wrong");
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
