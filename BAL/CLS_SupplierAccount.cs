using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //To Deal With DataTable and DataSet etc.....
using System.Data.SqlClient; //To Deal With Sql Server Database

namespace PharmacySystemV20._0._1.BAL
{
    class CLS_SupplierAccount
    {
        //Create new Instance From Singleton Class CLS_ConnectionDB() DataAccessLayer
        readonly DAL.CLS_ConnectionDB Connection = DAL.CLS_ConnectionDB.NewInstance();

        /// <summary>
        /// DataTable Function to Select All Columns From SupplierAccount Table
        /// </summary>
        /// <returns>SupplierAccountTable</returns>
        public DataTable ShowSupAccountTable()
        {
            /*Use DataTable Function from DAL.CLS_ConnectionDB to Select All Columns From SupplierAccount Table
             * no any StoredProcedur Parameters in StoredProcedure so Initialize null value
             * Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
             */
            // return Connection.SelectData("[PharmacyDB].[dbo].[SP_SupAccShow]", null);
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_SupAccShow]", null);
        }

        /// <summary>
        /// Int Function to generate SupplierAccount ID
        /// </summary>
        /// <returns>SupAccountID</returns>
        public int GenerateSupAccountID()
        {
            //Initialize return value of DataTable Function From DAL Connection.SelectData("storedProcedureName",SqlParameter[])
            //Assignment the value from DataTable Function After Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastSupAccID]", null).Rows[0][0])
            //return int SupplierAccount ID
            return Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastSupAccID]", null).Rows[0][0]);
        }

        /// <summary>
        /// Method To Add New SupplierAccount Or Save new SupplierAccount
        /// </summary>
        /// <param name="supAccID">supAccID</param>
        /// <param name="supID">supID</param>
        /// <param name="supAccBillID">supAccBillID</param>
        /// <param name="supAccCustomID">supAccCustomID</param>
        /// <param name="supAccName">supAccName</param>
        /// <param name="supAccDebit">supAccDebit</param>
        /// <param name="supAccCredit">supAccCredit</param>
        /// <param name="supAccBalance">supAccBalance</param>
        /// <param name="supAccNotes">supAccNotes</param>
        /// <param name="pcNameWhoAdded">pcNameWhoAdded</param>
        /// <param name="supAccWhoAdded">supAccWhoAdded</param>
        /// <param name="supAccDate">supAccDate</param>
        /// <param name="supAccTime">supAccTime</param>
        public void SaveSupAccount (int supAccID, int supID, int supAccBillID, string supAccCustomID, string supAccName, decimal supAccDebit,
                                    decimal supAccCredit, decimal supAccBalance, string supAccNotes,
                                    string pcNameWhoAdded, int supAccWhoAdded, string supAccDate, string supAccTime)
        {
            //Create New Instance From SqlParameter[] which length of it is equal counter of storedprocedureparameter
            SqlParameter[] SaveParam = new SqlParameter[13];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            SaveParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[0].Value = supAccID;

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            SaveParam[1] = new SqlParameter("@SupplierID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[1].Value = supID;

            SaveParam[2] = new SqlParameter("@SupAccBillID", SqlDbType.Int);
            SaveParam[2].Value = supAccBillID;

            SaveParam[3] = new SqlParameter("@SupAccCustomID", SqlDbType.NVarChar, 50);
            SaveParam[3].Value = supAccCustomID;

            SaveParam[4] = new SqlParameter("@SupAccName", SqlDbType.NVarChar, 50);
            SaveParam[4].Value = supAccName;

            SaveParam[5] = new SqlParameter("@SupAccDebit", SqlDbType.Decimal);
            SaveParam[5].Value = supAccDebit;

            SaveParam[6] = new SqlParameter("@SupAccCredit", SqlDbType.Decimal);
            SaveParam[6].Value = supAccCredit;

            SaveParam[7] = new SqlParameter("@SupAccBalance", SqlDbType.Decimal);
            SaveParam[7].Value = supAccBalance;

            SaveParam[8] = new SqlParameter("@SupAccNotes", SqlDbType.NVarChar, 400);
            SaveParam[8].Value = supAccNotes;

            SaveParam[9] = new SqlParameter("@PCNameWhoAdded ", SqlDbType.NVarChar, 50);
            SaveParam[9].Value = pcNameWhoAdded;

            SaveParam[10] = new SqlParameter("@SupAccWhoAdded", SqlDbType.Int);
            SaveParam[10].Value = supAccWhoAdded;

            SaveParam[11] = new SqlParameter("@Date", SqlDbType.NVarChar, 50);
            SaveParam[11].Value = supAccDate;

            SaveParam[12] = new SqlParameter("@Time", SqlDbType.NVarChar, 50);
            SaveParam[12].Value = supAccTime;

            //Execute Command Insert into Table SupplierAccount by DAL.CLS_ConnectionDB
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_SupAccEdit]", SaveParam);
        }

        /// <summary>
        /// Method To Delete Record From SupplierAccount Table by Supplier ID
        /// </summary>
        /// <param name="supID">supID refers to ==> Supplier ID</param>
        public void DeleteSupAccount(int supID)
        {
            //Create new instance from SqlParameter[]
            SqlParameter[] DeleteParam = new SqlParameter[1];

            DeleteParam[0] = new SqlParameter("@SupplierID", SqlDbType.Int);
            DeleteParam[0].Value = supID;

            //Execute Command To Delete Record from SupplierAccount Table
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_SupAccDelete]", DeleteParam);

        }

        /// <summary>
        /// Method To Update SupplierAccount Table by Modify SupplierAccount Status Only (Deactivate SupplierAccount)
        /// Update SupplierAccount Table by Supplier ID
        /// </summary>
        /// <param name="supID">supID refers to ==> Supplier ID</param>
        /// <param name="supAccStatus">supAccStatus</param>
        /// <param name="pcNameWhoDeleted">pcNameWhoDeleted</param>
        /// <param name="supAccWhoDeleted">supAccWhoDeleted</param>
        public void DeactivateSupAccount(int supID, bool supAccStatus, string pcNameWhoDeleted, int supAccWhoDeleted)
        {
            //Create New Instance From SqlParameter [] array
            SqlParameter[] DeleteParam = new SqlParameter[4];

            DeleteParam[0] = new SqlParameter("@SupplierID", SqlDbType.Int);
            DeleteParam[0].Value = supID;

            DeleteParam[1] = new SqlParameter("@SupAccStatus", SqlDbType.Bit);
            DeleteParam[1].Value = supAccStatus;

            DeleteParam[2] = new SqlParameter("@PCNameWhoDeleted", SqlDbType.NVarChar, 50);
            DeleteParam[2].Value = pcNameWhoDeleted;

            DeleteParam[3] = new SqlParameter("@SupAccWhoDeleted", SqlDbType.Int);
            DeleteParam[3].Value = supAccWhoDeleted;

            //Execute Command to Update Users table by In Activate SupplierAccount
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_SupAccDeactivate]", DeleteParam);

        }


        /// <summary>
        /// Method To Update SupplierAccount Table
        /// </summary>
        /// <param name="supAccID">supAccID</param>
        /// <param name="supID">supID</param>
        /// <param name="supAccBillID">supAccBillID</param>
        /// <param name="supAccCustomID">supAccCustomID</param>
        /// <param name="supAccName">supAccName</param>
        /// <param name="supAccDebit">supAccDebit</param>
        /// <param name="supAccCredit">supAccCredit</param>
        /// <param name="supAccBalance">supAccBalance</param>
        /// <param name="supAccNotes">supAccNotes</param>
        /// <param name="pcNameWhoModified">pcNameWhoModified</param>
        /// <param name="supAccWhoModified">supAccWhoModified</param>
        public void UpdateSupAccount (int supAccID, int supID, int supAccBillID, string supAccCustomID, string supAccName, 
                                      decimal supAccDebit,decimal supAccCredit, decimal supAccBalance, 
                                      string supAccNotes, string pcNameWhoModified, int supAccWhoModified)
        {
            //Create New Instance From SqlParameter[]
            SqlParameter[] UpdateParam = new SqlParameter[11];
            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            UpdateParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[0].Value = supAccID;

            UpdateParam[1] = new SqlParameter("@SupplierID", SqlDbType.Int);
            UpdateParam[1].Value = supID;

            UpdateParam[2] = new SqlParameter("@SupAccBillID", SqlDbType.Int);
            UpdateParam[2].Value = supAccBillID;

            UpdateParam[3] = new SqlParameter("@SupAccCustomID", SqlDbType.NVarChar, 50);
            UpdateParam[3].Value = supAccCustomID;

            UpdateParam[4] = new SqlParameter("@SupAccName", SqlDbType.NVarChar, 50);
            UpdateParam[4].Value = supAccName;

            UpdateParam[5] = new SqlParameter("@SupAccDebit", SqlDbType.Decimal);
            UpdateParam[5].Value = supAccDebit;

            UpdateParam[6] = new SqlParameter("@SupAccCredit", SqlDbType.Decimal);
            UpdateParam[6].Value = supAccCredit;

            UpdateParam[7] = new SqlParameter("@SupAccBalance", SqlDbType.Decimal);
            UpdateParam[7].Value = supAccBalance;

            UpdateParam[8] = new SqlParameter("@SupAccNotes", SqlDbType.NVarChar, 400);
            UpdateParam[8].Value = supAccNotes;

            UpdateParam[9] = new SqlParameter("@PCNameWhoModified", SqlDbType.NVarChar, 50);
            UpdateParam[9].Value = pcNameWhoModified;

            UpdateParam[10] = new SqlParameter("@SupAccWhoModified", SqlDbType.Int);
            UpdateParam[10].Value = supAccWhoModified;

            //Execute Command to Update any Record of SupplierAccount Table by SupplierAccountID
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_SupAccUpdate]", UpdateParam);
        }

        /// <summary>
        /// DataTable Function To Advanced Search in SupplierAccount Table
        /// Between Two Dates Receive Three Arguments (Column Name and Search Key and Optional searchKey1)
        /// Two Ways To Search Indentical (=) and Not Indentical (LIKE '%'+ @searchKey + '%';) 
        /// </summary>
        /// <param name="columnName">refers to Column Name Search by it</param>
        /// <param name="searchKey">refers to Supplier ID</param>
        /// <param name="operaName">refers to Operation Name</param>
        /// <param name="searchDate1">refers to start Date of Balance</param>
        /// <param name="searchDate2">refers to End Date of Balance</param>
        /// <returns>DataTable</returns>
        public DataTable SearchSupAccount(string columnName, string searchKey, string operaName, 
                                          string searchDate1, string searchDate2)
        {
            //Create New Instance From SqlParameter[]
            SqlParameter[] SearchParam = new SqlParameter[5];
            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            SearchParam[0] = new SqlParameter("@ColumnName", SqlDbType.NVarChar, 25);
            //Initialize value of every element in array by Argument which received from form
            SearchParam[0].Value = columnName;

            SearchParam[1] = new SqlParameter("@SearchKey", SqlDbType.NVarChar, 100);
            SearchParam[1].Value = searchKey;

            SearchParam[2] = new SqlParameter("@OperaName", SqlDbType.NVarChar, 100);
            SearchParam[2].Value = operaName;

            SearchParam[3] = new SqlParameter("@SearchDate1", SqlDbType.NVarChar, 100);
            SearchParam[3].Value = searchDate1;

            SearchParam[4] = new SqlParameter("@SearchDate2", SqlDbType.NVarChar, 100);
            SearchParam[4].Value = searchDate2;

            //Return DataTable which like search key 
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_SupAccSearch]", SearchParam);
        }
    }
}
