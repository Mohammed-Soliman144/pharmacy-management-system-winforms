using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; /* using namespace To Deal With DataTable, DataSet and others */
using System.Data.SqlClient;
using System.Windows.Forms; /* using namespace To Deal With Sql Server Databases */

namespace PharmacySystemV20._0._1.DAL
{
    /// <summary>
    /// Data Access Layer Folder >> DAL
    /// Singleton Class >> CLS_Connection is Lazy Class
    /// this is a heavy singleton class used for connection Sql Server Database. 
    /// Used Lazy Class to reduce used space from memory
    /// this is class used for following tasks
    /// -1-  Connection to Sql Server Database by Constructor of class
    /// -2-  Function is Datatype is the same of Class to return new instance from Generic Class by Value using lazy loading
    /// -3-  Method To open Connection if Used Direct Conection to execute commands (by SqlCommand)
    /// -4-  Methof To Close Connection if used Direct Connection to execute Commands (by sqlCommand)
    /// -5-  Function To Select Data From Sql Server Database by used Stored Procedures
    /// -6-  Method To Execute Command on Sql Server Databases by used Stored procedures
    /// -7-  Method To Backup Database by used Stored procedures 
    /// -8-  Method To Restore Database
    /// -9-  Function To Select Table From Sql Server Databases
    ///-10-  Function To Return SqlDataAdapter which is connected Query 
    /// </summary>
    class CLS_ConnectionDB
    {
        #region Fields of class, Constructor and Fuction to return lazy instance from Class

        //Declare SqlConnection Variable with access modifier private static (Field of Class CLS_Connection)
        static readonly SqlConnection Con;

        /* Create new instance from class by used readonly to reduce used space from memory
         * by use Lazy<Generic Class> instance and used Lambda Expression () => to execute lazy inheritance from class
        */
        static readonly Lazy<CLS_ConnectionDB> CLS_Connect = new Lazy<CLS_ConnectionDB>(() => new CLS_ConnectionDB());

        /// <summary>
        /// Function Datatype CLS_Connection
        /// with the same class Datatype
        /// used for create new lazy instance from class
        /// </summary>
        /// <returns>Instance.Value because is generic class</returns>
        public static CLS_ConnectionDB NewInstance()
        {
            return CLS_Connect.Value;
        }

        /// <summary>
        /// Constructor of Class which is the first object is executing when Inheritance from class
        /// Used for Connection with Sql Server Database by Windows Authentication or Sql Server Authentication
        /// </summary>
        static CLS_ConnectionDB()
        {
            ////Used Conditional Statement Swicth to check type of Connection
            //switch (Properties.Settings.Default.SecurityType)
            //{
            //    case true: // Windows Authentication which Trusted_Connection is true
            //        //Con = new SqlConnection(@"Data Source = " + Properties.Settings.Default.ServerName + ";" +
            //                                //"Initial Catalog = " + Properties.Settings.Default.DatabaseName + "; "
            //                              //+ "Trusted_Connection = " + Properties.Settings.Default.SecurityType + " ");
            //        Con = new SqlConnection(@"Data Source = " + "" + ";" +
            //                                "Initial Catalog = " + Properties.Settings.Default.DatabaseName + "; "
            //                              + "Trusted_Connection = " + Properties.Settings.Default.SecurityType + " ");
            //        break;

            //    case false: // Sql Server Authentication which integrated Security is False so need to User ID and Password
            //        Con = new SqlConnection(@"Server = " + Properties.Settings.Default.ServerName + "; Database = " + Properties.Settings.Default.DatabaseName + ";"
            //                                + "Integrated Security = " + Properties.Settings.Default.SecurityType + ";"
            //                                + "User ID = " + Properties.Settings.Default.User_ID + ";"
            //                                + "Password = " + Properties.Settings.Default.Password + " ");
            //        break;
            //}

            try
            {
                
                Con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PharmacyDB;Integrated Security=True;");

                Con.Open();
                MessageBox.Show("Connected Successfully");
                Con.Close();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Functions and Methods

        /// <summary>
        /// Void Method to Check and Open Connection
        /// </summary>
        public void OpenConnection()
        {
            //check SqlConnection.State == ConnectionState.Closed
            if (Con.State == ConnectionState.Closed)
            {
                //Open Connection
                Con.Open();
            }
        }

        /// <summary>
        /// Void Method to Check and Close Connection
        /// </summary>
        public void CloseConnection()
        {
            if (Con.State == ConnectionState.Open)
            {
                //Close Connection
                Con.Close();
            }
        }

        /// <summary>
        /// DataTable Function to SelectData with access modifier public 
        /// </summary>
        /// <param name="storedProcedureName">storedProcedureName</param>
        /// <param name="sqlParam">sqlParam</param>
        /// <returns>DataTable</returns>
        public DataTable SelectData(string storedProcedureName, SqlParameter[] sqlParam)
        {
            //Create new Instance from SqlCommand
            SqlCommand Command = new SqlCommand();
            //Initialize CommandType of SqlCommand is StoredProcedure
            Command.CommandType = CommandType.StoredProcedure;
            //Initialize CommandText of SqlCommand is StoredProcedureName
            Command.CommandText = storedProcedureName;
            //Initialize Connection of SqlCommand is SqlConnection
            Command.Connection = Con;

            // if SqlParameter[] is not equal null
            if (sqlParam != null)
            {
                //load parameters of command by method AddRange(arrayParam);
                Command.Parameters.AddRange(sqlParam);
            }
            //Create new Instance from SqlDataAdapter
            SqlDataAdapter Adapter = new SqlDataAdapter(Command);
            //Create new Instance From DataTable
            DataTable DT = new DataTable();

            //Clear DataTable
            DT.Clear();

            //Fill Datatable by SqlDataAdapter
             Adapter.Fill(DT);

            //Return DataTable
            return DT;
        }

        /// <summary>
        /// Void Method To Execuete Commands Insert into , Update , Delete From
        /// </summary>
        /// <param name="storedProcedureName">storedProcedureName</param>
        /// <param name="Param">sqlParam</param>
        public void ExecuteCommands(string storedProcedureName, SqlParameter[] sqlParam)
        {
            //Create new Instance from SqlCommand
            SqlCommand Command = new SqlCommand();
            //Initialize CommandType of SqlCommand is StoredProcedure
            Command.CommandType = CommandType.StoredProcedure;
            //Initialize CommandText of SqlCommand is StoredProcedureName
            Command.CommandText = storedProcedureName;
            //Initialize Connection of SqlCommand is SqlConnection
            Command.Connection = Con;

            // if SqlParameter[] is not equal null
            if (sqlParam != null)
            {
                //Use For loop to load Command by parameters with method Add(Param[i])
                for (int i = 0; i <= sqlParam.Length - 1; i++)
                {
                    Command.Parameters.Add(sqlParam[i]);
                }
            }

            //Check and Open Connection (Direct Connection)
            OpenConnection();
            //SqlCommand.ExecuteNonQuery();
            Command.ExecuteNonQuery();
            //Check and Close Connection (Direct Connection)
            CloseConnection();
        }

        /// <summary>
        /// DataTable Function To return Table From Database
        /// </summary>
        /// <param name="selectQuery">selectQuery</param>
        /// <returns>DataTable</returns>
        public DataTable SelectTable(string selectQuery)
        {
            //Create new Instance From SqlDataAdapter(selectQuery,Connection);
            SqlDataAdapter Adapter = new SqlDataAdapter(selectQuery, Con);
            //Create new Instance From DataTable
            DataTable DT = new DataTable();
            //Clear DataTable
            DT.Clear();
            //Fill Datatable by SqlDataAdapter
            Adapter.Fill(DT);
            //Return DataTable
            return DT;
        }

        /// <summary>
        /// SqlDataAdapter Function To return SqlDataAdapter
        /// </summary>
        /// <param name="query">query</param>
        /// <returns>SqlDataAdapter</returns>
        public SqlDataAdapter GetAdapter(string query)
        {
            //Create new instance From SqlDataAdapter(query, Con)
            SqlDataAdapter Adapter = new SqlDataAdapter(query, Con);
            //Return Adapter;
            return Adapter;
        }

        /// <summary>
        /// void Method TO restore Database
        /// </summary>
        /// <param name="restorePath">RestorePath</param>
        public void RestoreDB(string restorePath)
        {
            //Create new SqlCommand load by Restore Query, SqlConnection
            SqlCommand Cmd = new SqlCommand(@"ALTER DATABASE " + Properties.Settings.Default.DatabaseName + " SET SINGLE_USER WITH ROLLBACK;"
                                            + "RESTORE DATABASE " + Properties.Settings.Default.DatabaseName + " FROM DISK = " + restorePath + " WITH REPLACE;"
                                            + "ALTER DATABASE " + Properties.Settings.Default.DatabaseName + " SET MULTI_USER;", Con);
            //Open Connection Direct Connection
            OpenConnection();
            //ExecuteNonQuery of Command
            Cmd.ExecuteNonQuery();
            //Close Connection Direct Connection
            CloseConnection();
        }

        #endregion
    }
}
