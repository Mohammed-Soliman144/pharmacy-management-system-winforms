using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //To Deal With DataTables and DataSet
using System.Data.SqlClient; //To Deal With SQL Server Databases and SqlParameter

namespace PharmacySystemV20._0._1.BAL
{
    class CLS_Branches
    {
        //Create new Instance From Singleton Class CLS_ConnectionDB() DataAccessLayer
        readonly DAL.CLS_ConnectionDB Connection = DAL.CLS_ConnectionDB.NewInstance();

        /// <summary>
        /// DataTable Function to Select All Records From Branches Table
        /// </summary>
        /// <returns>Branches Table</returns>
        public DataTable ShowBranchesTable()
        {
            /*Use DataTable Function from DAL.CLS_ConnectionDB to Select All Columns From Branches Table
             * no any StoredProcedur Parameters in StoredProcedure so Initialize null value
             * Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
             */
            // return Connection.SelectData("[PharmacyDB].[dbo].[SP_BranchShow]", null);
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_BranchShow]", null);
        }


        /// <summary>
        /// Int Function to generate Branch ID
        /// </summary>
        /// <returns>BranchID</returns>
        public string GenerateBranchID()
        {
            //int BranchID without assignment any value
            int BranchID;

            //Initialize return value of DataTable Function From DAL Connection.SelectData("storedProcedureName",SqlParameter[])
            //Assignment the value from DataTable Function After Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastStoreID]", null).Rows[0][0].ToString())
            BranchID = Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastBranID]", null).Rows[0][0].ToString());

            //return BranchID.ToString("FormatName-000000");
            return BranchID.ToString("Bran-000000");
        }


        /// <summary>
        /// Method To Add New Branches Or Save new Branch
        /// </summary>
        /// <param name="branchID">branchID</param> 
        /// <param name="branchCode">branchCode</param>
        /// <param name="branchName">branchName</param>
        /// <param name="branchPhone1">branchPhone1</param>
        /// <param name="branchPhone2">branchPhone2</param>
        /// <param name="branchFax">branchFax</param>
        /// <param name="branchEmail">branchEmail</param>
        /// <param name="branchAddress">branchAddress</param>
        /// <param name="branchManager">branchManager</param>
        /// <param name="pcNameWhoAdded">pcNameWhoAdded</param>
        /// <param name="branchWhoAdded">branchWhoAdded</param>
        /// <param name="branchDate">branchDate</param>
        /// <param name="branchTime">branchTime</param>
        public void SaveBranches(int branchID, string branchCode, string branchName, string branchPhone1, string branchPhone2,
                                 string branchFax, string branchEmail, string branchAddress, int branchManager,
                                 string pcNameWhoAdded, int branchWhoAdded, string branchDate, string branchTime)
        {
            //Create New Instance From SqlParameter[] which length of it is equal counter of storedprocedureparameter
            SqlParameter[] SaveParam = new SqlParameter[13];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            SaveParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[0].Value = branchID;


            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            SaveParam[1] = new SqlParameter("@CustomID", SqlDbType.NVarChar, 50);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[1].Value = branchCode;

            SaveParam[2] = new SqlParameter("@BranName", SqlDbType.NVarChar, 100);
            SaveParam[2].Value = branchName;

            SaveParam[3] = new SqlParameter("@BranPhoneN1", SqlDbType.NVarChar, 25);
            SaveParam[3].Value = branchPhone1;

            SaveParam[4] = new SqlParameter("@BranPhoneN2", SqlDbType.NVarChar, 25);
            SaveParam[4].Value = branchPhone2;

            SaveParam[5] = new SqlParameter("@BranFax", SqlDbType.NVarChar, 25);
            SaveParam[5].Value = branchFax;

            SaveParam[6] = new SqlParameter("@BranEmail", SqlDbType.VarChar, 80);
            SaveParam[6].Value = branchEmail;

            SaveParam[7] = new SqlParameter("@BranAddress", SqlDbType.NVarChar, 120);
            SaveParam[7].Value = branchAddress;

            SaveParam[8] = new SqlParameter("@BranManager", SqlDbType.Int);
            SaveParam[8].Value = branchManager;

            SaveParam[9] = new SqlParameter("@PCNameWhoAdded", SqlDbType.NVarChar, 50);
            SaveParam[9].Value = pcNameWhoAdded;

            SaveParam[10] = new SqlParameter("@BranWhoAdded", SqlDbType.Int);
            SaveParam[10].Value = branchWhoAdded;

            SaveParam[11] = new SqlParameter("@Date", SqlDbType.NVarChar, 50);
            SaveParam[11].Value = branchDate;

            SaveParam[12] = new SqlParameter("@Time", SqlDbType.NVarChar, 50);
            SaveParam[12].Value = branchTime;

            //Execute Command Insert into Table Branches by DAL.CLS_ConnectionDB
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_BranchEdit]", SaveParam);
        }

        /// <summary>
        /// Method To Delete Record From Branches Table
        /// </summary>
        /// <param name="branchID">branchID</param>
        public void DeleteBranches(int branchID)
        {
            //Create new instance from SqlParameter[]
            SqlParameter[] DeleteParam = new SqlParameter[1];

            DeleteParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            DeleteParam[0].Value = branchID;

            //Execute Command To Delete Record from Stores Table
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_BranchDelete]", DeleteParam);

        }


        /// <summary>
        /// Method To Update Branches Table by Modify BranchStatus Only (Deactivate Branch)
        /// </summary>
        /// <param name="branchID">branchID</param>
        /// <param name="branchStatus">branchStatus</param>
        /// <param name="pcNameWhoDeleted">pcNameWhoDeleted</param>
        /// <param name="branchWhoDeleted">branchWhoDeleted</param>
        public void DeactivateBranches(int branchID, bool branchStatus, string pcNameWhoDeleted, int branchWhoDeleted)
        {
            //Create New Instance From SqlParameter [] array
            SqlParameter[] DeleteParam = new SqlParameter[4];

            DeleteParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            DeleteParam[0].Value = branchID;

            DeleteParam[1] = new SqlParameter("@Status", SqlDbType.Bit);
            DeleteParam[1].Value = branchStatus;

            DeleteParam[2] = new SqlParameter("@PCNameWhoDeleted", SqlDbType.NVarChar, 50);
            DeleteParam[2].Value = pcNameWhoDeleted;

            DeleteParam[3] = new SqlParameter("@BranWhoDeleted", SqlDbType.Int);
            DeleteParam[3].Value = branchWhoDeleted;

            //Execute Command to Update StoreS table by In Activate Stores
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_BranchDeactivate]", DeleteParam);
        }

        /// <summary>
        /// Method To Update Branches Table 
        /// </summary>
        /// <param name="branchID">branchID</param>
        /// <param name="branchName">branchName</param>
        /// <param name="branchPhone1">branchPhone1</param>
        /// <param name="branchPhone2">branchPhone2</param>
        /// <param name="branchFax">branchFax</param>
        /// <param name="branchEmail">branchEmail</param>
        /// <param name="branchAddress">branchAddress</param>
        /// <param name="branchManager">branchManager</param>
        /// <param name="pcNameWhoModified">pcNameWhoModified</param>
        /// <param name="branchWhoModified">branchWhoModified</param>
        public void UpdateBranches(int branchID, string branchName, string branchPhone1, string branchPhone2,
                                 string branchFax, string branchEmail, string branchAddress, int branchManager,  
                                 string pcNameWhoModified, int branchWhoModified)
        {
            //Create New Instance From SqlParameter[]
            SqlParameter[] UpdateParam = new SqlParameter[10];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            UpdateParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[0].Value = branchID;

            UpdateParam[1] = new SqlParameter("@BranName", SqlDbType.NVarChar, 100);
            UpdateParam[1].Value = branchName;

            UpdateParam[2] = new SqlParameter("@BranPhoneN1", SqlDbType.NVarChar, 25);
            UpdateParam[2].Value = branchPhone1;

            UpdateParam[3] = new SqlParameter("@BranPhoneN2", SqlDbType.NVarChar, 25);
            UpdateParam[3].Value = branchPhone2;

            UpdateParam[4] = new SqlParameter("@BranFax", SqlDbType.NVarChar, 25);
            UpdateParam[4].Value = branchFax;

            UpdateParam[5] = new SqlParameter("@BranEmail", SqlDbType.VarChar, 80);
            UpdateParam[5].Value = branchEmail;

            UpdateParam[6] = new SqlParameter("@BranAddress", SqlDbType.NVarChar, 120);
            UpdateParam[6].Value = branchAddress;

            UpdateParam[7] = new SqlParameter("@BranManager", SqlDbType.Int);
            UpdateParam[7].Value = branchManager;

            UpdateParam[8] = new SqlParameter("@PCNameWhoModified", SqlDbType.NVarChar, 50);
            UpdateParam[8].Value = pcNameWhoModified;

            UpdateParam[9] = new SqlParameter("@BranWhoModified ", SqlDbType.Int);
            UpdateParam[9].Value = branchWhoModified;

            //Execute Command to Update any Record of Stores Table by StoreID
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_BranchUpdate]", UpdateParam);
        }

        /// <summary>
        /// DataTable Function To Advanced Search in Branches Table
        /// Recieve Two Parameters Column Name and Search Key
        /// Two Ways To Search Indentical (=) and Not Indentical (LIKE '%'+ @searchKey + '%';)
        /// </summary>
        /// <param name="ColumnName">ColumnName</param>
        /// <param name="SearchKey">SearchKey</param>
        /// <returns>DataTable</returns>
        public DataTable SearchBranches(string columnName, string searchKey)
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
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_BranchSearch]", SearchParam);
        }
    }
}
