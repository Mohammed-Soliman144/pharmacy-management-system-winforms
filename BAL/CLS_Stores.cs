using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //To Deal With DataTables and DataSet
using System.Data.SqlClient; //To Deal With SQL Server Databases and SqlParameter

namespace PharmacySystemV20._0._1.BAL
{
    class CLS_Stores
    {
        //Create new Instance From Singleton Class CLS_ConnectionDB() DataAccessLayer
        readonly DAL.CLS_ConnectionDB Connection = DAL.CLS_ConnectionDB.NewInstance();

        /// <summary>
        /// DataTable Function to Select All Columns From Stores Table
        /// </summary>
        /// <returns>StoresTable</returns>
        public DataTable ShowStoresTable()
        {
            /*Use DataTable Function from DAL.CLS_ConnectionDB to Select All Columns From Stores Table
             * no any StoredProcedur Parameters in StoredProcedure so Initialize null value
             * Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
             */
            // return Connection.SelectData("[PharmacyDB].[dbo].[SP_StoreShow]", null);
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_StoreShow]", null);
        }

        /// <summary>
        /// Int Function to generate Stores ID
        /// </summary>
        /// <returns>StoreID</returns>
        public string GenerateStoreID()
        {
            //int StoreID without assignment any value
            int StoreID;

            //Initialize return value of DataTable Function From DAL Connection.SelectData("storedProcedureName",SqlParameter[])
            //Assignment the value from DataTable Function After Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastStoreID]", null).Rows[0][0].ToString())
            StoreID = Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastStoreID]", null).Rows[0][0].ToString());

            //return StoreID.ToString("FormatName-000000");
            return StoreID.ToString("STOR-000000");
        }

        /// <summary>
        /// Method To Add New Stores Or Save new Store
        /// </summary>
        /// <param name="storeID">storeID</param>
        /// <param name="storeCode">storeCode</param>
        /// <param name="storeName">storeName</param>
        /// <param name="storePhone">storePhone</param>
        /// <param name="storeAddress">storeAddress</param>
        /// <param name="storeType">storeType</param>
        /// <param name="storePass">storePass</param>
        /// <param name="storeManager">storeManager</param>
        /// <param name="storeBranch">storeBranch</param>
        /// <param name="storeCapacity">storeCapacity</param>
        /// <param name="pcNameWhoAdded">pcNameWhoAdded</param>
        /// <param name="storeWhoAdded">storeWhoAdded</param>
        /// <param name="storeDate">storeDate</param>
        /// <param name="storeTime">storeTime</param>
        public void SaveStores (int storeID, string storeCode, string storeName, string storePhone,string storeAddress,
                                string storeType,string storePass, int storeManager, int storeBranch,
                                int storeCapacity, string pcNameWhoAdded, int storeWhoAdded, 
                                string storeDate, string storeTime)
        {
            //Create New Instance From SqlParameter[] which length of it is equal counter of storedprocedureparameter
            SqlParameter[] SaveParam = new SqlParameter[14];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            SaveParam[0] = new SqlParameter("@CustomID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[0].Value = storeID;

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            SaveParam[1] = new SqlParameter("@CustomID", SqlDbType.NVarChar, 50);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[1].Value = storeCode;

            SaveParam[2] = new SqlParameter("@Name", SqlDbType.NVarChar, 100);
            SaveParam[2].Value = storeName;

            SaveParam[3] = new SqlParameter("@Phone", SqlDbType.NVarChar, 25);
            SaveParam[3].Value = storePhone;

            SaveParam[4] = new SqlParameter("@Address", SqlDbType.NVarChar, 120);
            SaveParam[4].Value = storeAddress;

            SaveParam[5] = new SqlParameter("@Type", SqlDbType.NVarChar, 50);
            SaveParam[5].Value = storeType;

            SaveParam[6] = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
            SaveParam[6].Value = storePass;

            SaveParam[7] = new SqlParameter("@Manager", SqlDbType.Int);
            SaveParam[7].Value = storeManager;

            SaveParam[8] = new SqlParameter("@Branch", SqlDbType.Int);
            SaveParam[8].Value = storeBranch;

            SaveParam[9] = new SqlParameter("@Capacity", SqlDbType.Int);
            SaveParam[9].Value = storeCapacity;

            SaveParam[10] = new SqlParameter("@PCNameWhoAdded", SqlDbType.NVarChar, 50);
            SaveParam[10].Value = pcNameWhoAdded;

            SaveParam[11] = new SqlParameter("@StoreWhoAdded", SqlDbType.Int);
            SaveParam[11].Value = storeWhoAdded;

            SaveParam[12] = new SqlParameter("@Date", SqlDbType.NVarChar, 50);
            SaveParam[12].Value = storeDate;

            SaveParam[13] = new SqlParameter("@Time", SqlDbType.NVarChar, 50);
            SaveParam[13].Value = storeTime;

            //Execute Command Insert into Table Users by DAL.CLS_ConnectionDB
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_StoreEdit]", SaveParam);
        }

        /// <summary>
        /// Method To Delete Record From Stores Table
        /// </summary>
        /// <param name="storeID">storeID</param>
        public void DeleteStores(int storeID)
        {
            //Create new instance from SqlParameter[]
            SqlParameter[] DeleteParam = new SqlParameter[1];

            DeleteParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            DeleteParam[0].Value = storeID;

            //Execute Command To Delete Record from Stores Table
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_StoreDelete]", DeleteParam);

        }

        /// <summary>
        /// Method To Update Stores Table by Modify StoreStatus Only (Deactivate Store)
        /// </summary>
        /// <param name="storeID">storeID</param>
        /// <param name="storeStatus">storeStatus</param>
        /// <param name="pcNameWhoDeleted">pcNameWhoDeleted</param>
        /// <param name="storeWhoDeleted">storeWhoDeleted</param>
        public void DeactivateStores(int storeID, bool storeStatus, string pcNameWhoDeleted, int storeWhoDeleted)
        {
            //Create New Instance From SqlParameter [] array
            SqlParameter[] DeleteParam = new SqlParameter[4];

            DeleteParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            DeleteParam[0].Value = storeID;

            DeleteParam[1] = new SqlParameter("@Status", SqlDbType.Bit);
            DeleteParam[1].Value = storeStatus;

            DeleteParam[2] = new SqlParameter("@PCNameWhoDeleted", SqlDbType.NVarChar, 50);
            DeleteParam[2].Value = pcNameWhoDeleted;

            DeleteParam[3] = new SqlParameter("@StoreWhoDeleted", SqlDbType.Int);
            DeleteParam[3].Value = storeWhoDeleted;

            //Execute Command to Update StoreS table by In Activate Stores
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_StoreDeactivate]", DeleteParam);

        }

        /// <summary>
        /// Method To Update Stores Table 
        /// </summary>
        /// <param name="storeID">storeID</param>
        /// <param name="storeName">storeName</param>
        /// <param name="storePhone">storePhone</param>
        /// <param name="storeAddress">storeAddress</param>
        /// <param name="storeType">storeType</param>
        /// <param name="storePass">storePass</param>
        /// <param name="storeManager">storeManager</param>
        /// <param name="storeBranch">storeBranch</param>
        /// <param name="storeCapacity">storeCapacity</param>
        /// <param name="pcNameWhoModified">pcNameWhoModified</param>
        /// <param name="storeWhoModified">storeWhoModified</param>
        public void UpdateStores (int storeID, string storeName, string storePhone,string storeAddress,
                                  string storeType, string storePass, int storeManager, int storeBranch,
                                  int storeCapacity, string pcNameWhoModified, int storeWhoModified)
        {
            //Create New Instance From SqlParameter[]
            SqlParameter[] UpdateParam = new SqlParameter[11];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            UpdateParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[0].Value = storeID;

            UpdateParam[1] = new SqlParameter("@Name", SqlDbType.NVarChar, 100);
            UpdateParam[1].Value = storeName;

            UpdateParam[2] = new SqlParameter("@Phone", SqlDbType.NVarChar, 25);
            UpdateParam[2].Value = storePhone;

            UpdateParam[3] = new SqlParameter("@Address", SqlDbType.NVarChar, 120);
            UpdateParam[3].Value = storeAddress;

            UpdateParam[4] = new SqlParameter("@Type", SqlDbType.NVarChar, 50);
            UpdateParam[4].Value = storeType;

            UpdateParam[5] = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
            UpdateParam[5].Value = storePass;

            UpdateParam[6] = new SqlParameter("@Manager", SqlDbType.Int);
            UpdateParam[6].Value = storeManager;

            UpdateParam[7] = new SqlParameter("@Branch", SqlDbType.Int);
            UpdateParam[7].Value = storeBranch;

            UpdateParam[8] = new SqlParameter("@Capacity", SqlDbType.Int);
            UpdateParam[8].Value = storeCapacity;

            UpdateParam[9] = new SqlParameter("@PCNameWhoModified", SqlDbType.NVarChar, 50);
            UpdateParam[9].Value = pcNameWhoModified;

            UpdateParam[10] = new SqlParameter("@StoreWhoModified", SqlDbType.Int);
            UpdateParam[10].Value = storeWhoModified;

            //Execute Command to Update any Record of Stores Table by StoreID
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_StoreUpdate]", UpdateParam);
        }

        /// <summary>
        /// DataTable Function To Advanced Search in Stores Table
        /// Recieve Two Parameters Column Name and Search Key
        /// Two Ways To Search Indentical (=) and Not Indentical (LIKE '%'+ @searchKey + '%';)
        /// </summary>
        /// <param name="ColumnName">ColumnName</param>
        /// <param name="SearchKey">SearchKey</param>
        /// <returns>DataTable</returns>
        public DataTable SearchStores(string columnName, string searchKey)
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
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_StoreSearch]", SearchParam);
        }
    }
}
