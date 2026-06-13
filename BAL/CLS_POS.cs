using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //To Deal With DataTables and DataSet
using System.Data.SqlClient; //To Deal With SQL Server Databases and SqlParameter

namespace PharmacySystemV20._0._1.BAL
{
    class CLS_POS
    {
        //Create new Instance From Singleton Class CLS_ConnectionDB() DataAccessLayer
        readonly DAL.CLS_ConnectionDB Connection = DAL.CLS_ConnectionDB.NewInstance();

        /// <summary>
        /// DataTable Function to Select All Records From POS Table
        /// POS Refers To Point of Sales
        /// </summary>
        /// <returns>POS Table</returns>
        public DataTable ShowPOSTable()
        {
            /*Use DataTable Function from DAL.CLS_ConnectionDB to Select All Columns From POS Table
             * no any StoredProcedur Parameters in StoredProcedure so Initialize null value
             * Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
             */
            // return Connection.SelectData("[PharmacyDB].[dbo].[SP_POSShow]", null);
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_POSShow]", null);
        }

        /// <summary>
        /// Int Function to generate POSID
        /// </summary>
        /// <returns>POSID</returns>
        public int GeneratePOSID()
        {
            //Initialize return value of DataTable Function From DAL Connection.SelectData("storedProcedureName",SqlParameter[])
            //Assignment the value from DataTable Function After Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastPOSID]", null).Rows[0][0])
            //return int POSID
            return Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastPOSID]", null).Rows[0][0]);
        }

        /// <summary>
        /// Method To Add New POS Or Save new Point of Sale
        /// </summary>
        /// <param name="posID">posID</param>
        /// <param name="posCustomCode">posCustomCode</param>
        /// <param name="posName">posName</param>
        /// <param name="posBalance">posBalance</param>
        /// <param name="pcNameWhoAdded">pcNameWhoAdded</param>
        /// <param name="posWhoAdded">posWhoAdded</param>
        /// <param name="posDate">posDate</param>
        /// <param name="posTime">posTime</param>
        public void SavePOS (int posID, string posCustomCode, string posName, decimal posBalance,
                             string pcNameWhoAdded, int posWhoAdded, string posDate, string posTime)
        {
            //Create New Instance From SqlParameter[] which length of it is equal counter of storedprocedureparameter
            SqlParameter[] SaveParam = new SqlParameter[8];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            SaveParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[0].Value = posID;

            SaveParam[1] = new SqlParameter("@CustomCode", SqlDbType.NVarChar, 50);
            SaveParam[1].Value = posCustomCode;

            SaveParam[2] = new SqlParameter("@POSName", SqlDbType.NVarChar, 50);
            SaveParam[2].Value = posName;

            SaveParam[3] = new SqlParameter("@POSBalance", SqlDbType.Decimal);
            SaveParam[3].Value = posBalance;

            SaveParam[4] = new SqlParameter("@PCNameWhoAdded", SqlDbType.NVarChar, 50);
            SaveParam[4].Value = pcNameWhoAdded;

            SaveParam[5] = new SqlParameter("@POSWhoAdded", SqlDbType.Int);
            SaveParam[5].Value = posWhoAdded;

            SaveParam[6] = new SqlParameter("@Date", SqlDbType.NVarChar, 50);
            SaveParam[6].Value = posDate;

            SaveParam[7] = new SqlParameter("@Time", SqlDbType.NVarChar, 50);
            SaveParam[7].Value = posTime;

            //Execute Command Insert into Table Branches by DAL.CLS_ConnectionDB
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_POSEdit]", SaveParam);
        }

        /// <summary>
        /// Method To Delete Record From POS Table
        /// </summary>
        /// <param name="posID">posID</param>
        public void DeletePOS(int posID)
        {
            //Create new instance from SqlParameter[]
            SqlParameter[] DeleteParam = new SqlParameter[1];

            DeleteParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            DeleteParam[0].Value = posID;

            //Execute Command To Delete Record from POS Table
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_POSDelete]", DeleteParam);

        }

        /// <summary>
        /// Method To Update POS Table by Modify POSStatus Only (Deactivate POS)
        /// </summary>
        /// <param name="posID">posID</param>
        /// <param name="posStatus">posStatus</param>
        /// <param name="pcNameWhoDeleted">pcNameWhoDeleted</param>
        /// <param name="posWhoDeleted">posWhoDeleted</param>
        public void DeactivatePOS(int posID, bool posStatus, string pcNameWhoDeleted, int posWhoDeleted)
        {
            //Create New Instance From SqlParameter [] array
            SqlParameter[] DeleteParam = new SqlParameter[4];

            DeleteParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            DeleteParam[0].Value = posID;

            DeleteParam[1] = new SqlParameter("@POSStatus", SqlDbType.Bit);
            DeleteParam[1].Value = posStatus;

            DeleteParam[2] = new SqlParameter("@PCNameWhoDeleted", SqlDbType.NVarChar, 50);
            DeleteParam[2].Value = pcNameWhoDeleted;

            DeleteParam[3] = new SqlParameter("@POSWhoDeleted", SqlDbType.Int);
            DeleteParam[3].Value = posWhoDeleted;

            //Execute Command to Update POS table by In Activate POS Status
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_POSDeactivate]", DeleteParam);
        }

        /// <summary>
        /// Method To Update POS Table 
        /// </summary>
        /// <param name="posID">posID</param>
        /// <param name="posName">posName</param>
        /// <param name="posBalance">posBalance</param>
        /// <param name="pcNameWhoModified">pcNameWhoModified</param>
        /// <param name="posWhoModified">posWhoModified</param>
        public void UpdatePOS (int posID, string posName, decimal posBalance, string pcNameWhoModified, 
                               int posWhoModified)
        {
            //Create New Instance From SqlParameter[]
            SqlParameter[] UpdateParam = new SqlParameter[5];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            UpdateParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[0].Value = posID;

            UpdateParam[1] = new SqlParameter("@POSName", SqlDbType.NVarChar, 50);
            UpdateParam[1].Value = posName;

            UpdateParam[2] = new SqlParameter("@POSBalance", SqlDbType.Decimal);
            UpdateParam[2].Value = posBalance;

            UpdateParam[3] = new SqlParameter("@PCNameWhoModified", SqlDbType.NVarChar, 50);
            UpdateParam[3].Value = pcNameWhoModified;

            UpdateParam[4] = new SqlParameter("@POSWhoModified", SqlDbType.Int);
            UpdateParam[4].Value = posWhoModified;

            //Execute Command to Update any Record of POS Table by POSID
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_POSUpdate]", UpdateParam);
        }

        /// <summary>
        /// DataTable Function To Advanced Search in POS Table
        /// Recieve Two Parameters Column Name and Search Key
        /// Two Ways To Search Indentical (=) and Not Indentical (LIKE '%'+ @searchKey + '%';)
        /// </summary>
        /// <param name="ColumnName">ColumnName</param>
        /// <param name="SearchKey">SearchKey</param>
        /// <returns>DataTable</returns>
        public DataTable SearchPOS(string columnName, string searchKey)
        {
            //Create New Instance From SqlParameter[]
            SqlParameter[] SearchParam = new SqlParameter[2];
            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            SearchParam[0] = new SqlParameter("@ColumnName", SqlDbType.NVarChar, 25);
            //Initialize value of every element in array by Argument which received from form
            SearchParam[0].Value = columnName;

            SearchParam[1] = new SqlParameter("@SearchKey", SqlDbType.NVarChar, 100);
            SearchParam[1].Value = searchKey;

            //Return DataTable which like search key
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_POSSearch]", SearchParam);
        }
    }
}
