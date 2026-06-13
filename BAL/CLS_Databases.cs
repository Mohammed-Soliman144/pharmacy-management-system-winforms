using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; // To deal with DataTable and DataSet
using System.Data.SqlClient; // to deal with Sql Server Database


namespace PharmacySystemV20._0._1.BAL
{
    class CLS_Databases
    {

        //readonly Create new Instance From Singleton Class CLS_ConnectionDB() DataAccessLayer
        readonly DAL.CLS_ConnectionDB Connection = DAL.CLS_ConnectionDB.NewInstance();

        /// <summary>
        /// Execute Command of storedProcedure Backup Database from DAL
        /// </summary>
        /// <param name="path">Path Argument</param>
        public void BackupDB(string path,string databaseName)
        {

            //Create new Instance From Array of SqlParameter[]
            SqlParameter[] backParam = new SqlParameter[2];

            //Define all elements of array by new SqlParameter ("@ParamName",SqlDbType.DataType,Size)
            backParam[0] = new SqlParameter("@filePath", SqlDbType.NVarChar, 150);
            //Initailize Value of All Elements of array
            backParam[0].Value = path;

            backParam[1] = new SqlParameter("@dbName", SqlDbType.NVarChar, 150);
            backParam[1].Value = databaseName;

            //Execute Command of storedprocedure Backup Database from DAL
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_Backup]", backParam);
        }

        /// <summary>
        /// Execute Command of storedProcedure Restore Database from DAL
        /// </summary>
        /// <param name="path">Path Argument</param>
        public void RestoreDB(string path)
        {
            //Implementation of Method RestoreDB from Sealed Class CLS_ConnectionSettings
            Connection.RestoreDB(path);
        }

        /// <summary>
        /// Get All Servers Name From sys.servers
        /// No any Parameters of storedProcedure
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAllServers()
        {
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_GetServers]", null);
        }

        /// <summary>
        /// Get All database Name From sys.databases
        /// No any Parameters of storedProcedure
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAllDatabases()
        {
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_GetDatabases]", null);
        }
    }
}
