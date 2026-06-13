using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data; //To Deal With DataTable and DataSet etc.....
using System.Data.SqlClient; //To Deal With Sql Server Database

namespace PharmacySystemV20._0._1.BAL
{
    class CLS_CustomerAccount
    {
        //Create new Instance From Singleton Class CLS_ConnectionDB() DataAccessLayer
        readonly DAL.CLS_ConnectionDB Connection = DAL.CLS_ConnectionDB.NewInstance();

        /// <summary>
        /// DataTable Function to Select All Columns From CustomerAccount Table
        /// </summary>
        /// <returns>CustomerAccountTable</returns>
        public DataTable ShowCustAccountTable()
        {
            /*Use DataTable Function from DAL.CLS_ConnectionDB to Select All Columns From CustomerAccount Table
             * no any StoredProcedur Parameters in StoredProcedure so Initialize null value
             * Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
             */
            // return Connection.SelectData("[PharmacyDB].[dbo].[SP_CustAccShow]", null);
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_CustAccShow]", null);
        }

        /// <summary>
        /// Int Function to generate CustomerAccount ID
        /// </summary>
        /// <returns>CustAccountID</returns>
        public int GenerateCustAccountID()
        {
            //Initialize return value of DataTable Function From DAL Connection.SelectData("storedProcedureName",SqlParameter[])
            //Assignment the value from DataTable Function After Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastCustAccID]", null).Rows[0][0])
            //return int CustomerAccount ID
            return Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastCustAccID]", null).Rows[0][0]);
        }

        /// <summary>
        /// Method To Add New CustomerAccount Or Save new CustomerAccount
        /// </summary>
        /// <param name="custAccID">custAccID</param>
        /// <param name="custID">custID</param>
        /// <param name="custAccBillID">custAccBillID</param>
        /// <param name="custAccCustomID">custAccCustomID</param>
        /// <param name="custAccName">custAccName</param>
        /// <param name="custAccDebit">custAccDebit</param>
        /// <param name="custAccCredit">custAccCredit</param>
        /// <param name="custAccBalance">custAccBalance</param>
        /// <param name="custAccNotes">custAccNotes</param>
        /// <param name="pcNameWhoAdded">pcNameWhoAdded</param>
        /// <param name="custAccWhoAdded">custAccWhoAdded</param>
        /// <param name="custAccDate">custAccDate</param>
        /// <param name="custAccTime">custAccTime</param>
        public void SaveCustAccount(int custAccID, int custID, int custAccBillID, string custAccCustomID, string custAccName, decimal custAccDebit,
                                    decimal custAccCredit, decimal custAccBalance, string custAccNotes,
                                    string pcNameWhoAdded, int custAccWhoAdded, string custAccDate, string custAccTime)
        {

            //Create New Instance From SqlParameter[] which length of it is equal counter of storedprocedureparameter
            SqlParameter[] SaveParam = new SqlParameter[13];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            SaveParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[0].Value = custAccID;

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            SaveParam[1] = new SqlParameter("@CustomerID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[1].Value = custID;

            SaveParam[2] = new SqlParameter("@CustAccBillID", SqlDbType.Int);
            SaveParam[2].Value = custAccBillID;

            SaveParam[3] = new SqlParameter("@CustAccCustomID", SqlDbType.NVarChar, 50);
            SaveParam[3].Value = custAccCustomID;

            SaveParam[4] = new SqlParameter("@CustAccName", SqlDbType.NVarChar, 50);
            SaveParam[4].Value = custAccName;

            SaveParam[5] = new SqlParameter("@CustAccDebit", SqlDbType.Decimal);
            SaveParam[5].Value = custAccDebit;

            SaveParam[6] = new SqlParameter("@CustAccCredit", SqlDbType.Decimal);
            SaveParam[6].Value = custAccCredit;

            SaveParam[7] = new SqlParameter("@CustAccBalance", SqlDbType.Decimal);
            SaveParam[7].Value = custAccBalance;

            SaveParam[8] = new SqlParameter("@CustAccNotes", SqlDbType.NVarChar, 400);
            SaveParam[8].Value = custAccNotes;

            SaveParam[9] = new SqlParameter("@PCNameWhoAdded ", SqlDbType.NVarChar, 50);
            SaveParam[9].Value = pcNameWhoAdded;

            SaveParam[10] = new SqlParameter("@CustAccWhoAdded", SqlDbType.Int);
            SaveParam[10].Value = custAccWhoAdded;

            SaveParam[11] = new SqlParameter("@Date", SqlDbType.NVarChar, 50);
            SaveParam[11].Value = custAccDate;

            SaveParam[12] = new SqlParameter("@Time", SqlDbType.NVarChar, 50);
            SaveParam[12].Value = custAccTime;

            //Execute Command Insert into Table CustomerAccount by DAL.CLS_ConnectionDB
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_CustAccEdit]", SaveParam);
        }

        /// <summary>
        /// Method To Delete Record From CustomerAccount Table by use Customet ID
        /// </summary>
        /// <param name="custID">custID refers to ==> Customet ID</param>
        public void DeleteCustAccount(int custID)
        {
            //Create new instance from SqlParameter[]
            SqlParameter[] DeleteParam = new SqlParameter[1];

            DeleteParam[0] = new SqlParameter("@CustomerID", SqlDbType.Int);
            DeleteParam[0].Value = custID;

            //Execute Command To Delete Record from CustomerAccount Table
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_CustAccDelete]", DeleteParam);

        }

        /// <summary>
        /// Method To Update CustomerAccount Table by Modify CustomerAccount Status Only (Deactivate CustomerAccount)
        /// Update CustomerAccount Table by use Customet ID
        /// </summary>
        /// <param name="custID">custID refers to ==> Customet ID</param>
        /// <param name="custAccStatus">custAccStatus</param>
        /// <param name="pcNameWhoDeleted">pcNameWhoDeleted</param>
        /// <param name="custAccWhoDeleted">custAccWhoDeleted</param>
        public void DeactivateCustAccount(int custID, bool custAccStatus, string pcNameWhoDeleted, int custAccWhoDeleted)
        {
            //Create New Instance From SqlParameter [] array
            SqlParameter[] DeleteParam = new SqlParameter[4];

            DeleteParam[0] = new SqlParameter("@CustomerID", SqlDbType.Int);
            DeleteParam[0].Value = custID;

            DeleteParam[1] = new SqlParameter("@CustAccStatus", SqlDbType.Bit);
            DeleteParam[1].Value = custAccStatus;

            DeleteParam[2] = new SqlParameter("@PCNameWhoDeleted", SqlDbType.NVarChar, 50);
            DeleteParam[2].Value = pcNameWhoDeleted;

            DeleteParam[3] = new SqlParameter("@CustAccWhoDeleted", SqlDbType.Int);
            DeleteParam[3].Value = custAccWhoDeleted;

            //Execute Command to Update Users table by In Activate CustomerAccount
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_CustAccDeactivate]", DeleteParam);
        }


        /// <summary>
        /// Method To Update CustomerAccount Table
        /// </summary>
        /// <param name="custAccID">custAccID</param>
        /// <param name="custID">custID</param>
        /// <param name="custAccBillID">custAccBillID</param>
        /// <param name="custAccCustomID">custAccCustomID</param>
        /// <param name="custAccName">custAccName</param>
        /// <param name="custAccDebit">custAccDebit</param>
        /// <param name="custAccCredit">custAccCredit</param>
        /// <param name="custAccBalance">custAccBalance</param>
        /// <param name="custAccNotes">custAccNotes</param>
        /// <param name="pcNameWhoModified">pcNameWhoModified</param>
        /// <param name="custAccWhoModified">custAccWhoModified</param>
        public void UpdateCustAccount(int custAccID, int custID, int custAccBillID, string custAccCustomID, string custAccName,
                                      decimal custAccDebit, decimal custAccCredit, decimal custAccBalance,
                                      string custAccNotes, string pcNameWhoModified, int custAccWhoModified)
        {
            //Create New Instance From SqlParameter[]
            SqlParameter[] UpdateParam = new SqlParameter[11];
            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            UpdateParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[0].Value = custAccID;

            UpdateParam[1] = new SqlParameter("@CustomerID", SqlDbType.Int);
            UpdateParam[1].Value = custID;

            UpdateParam[2] = new SqlParameter("@CustAccBillID", SqlDbType.Int);
            UpdateParam[2].Value = custAccBillID;

            UpdateParam[3] = new SqlParameter("@CustAccCustomID", SqlDbType.NVarChar, 50);
            UpdateParam[3].Value = custAccCustomID;

            UpdateParam[4] = new SqlParameter("@CustAccName", SqlDbType.NVarChar, 50);
            UpdateParam[4].Value = custAccName;

            UpdateParam[5] = new SqlParameter("@CustAccDebit", SqlDbType.Decimal);
            UpdateParam[5].Value = custAccDebit;

            UpdateParam[6] = new SqlParameter("@CustAccCredit", SqlDbType.Decimal);
            UpdateParam[6].Value = custAccCredit;

            UpdateParam[7] = new SqlParameter("@CustAccBalance", SqlDbType.Decimal);
            UpdateParam[7].Value = custAccBalance;

            UpdateParam[8] = new SqlParameter("@CustAccNotes", SqlDbType.NVarChar, 400);
            UpdateParam[8].Value = custAccNotes;

            UpdateParam[9] = new SqlParameter("@PCNameWhoModified", SqlDbType.NVarChar, 50);
            UpdateParam[9].Value = pcNameWhoModified;

            UpdateParam[10] = new SqlParameter("@CustAccWhoModified", SqlDbType.Int);
            UpdateParam[10].Value = custAccWhoModified;

            //Execute Command to Update any Record of CustomerAccount Table by CustomerAccountID
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_CustAccUpdate]", UpdateParam);
        }

        /// <summary>
        /// DataTable Function To Advanced Search in CustomerAccount Table
        /// Between Two Dates Receive Three Arguments (Column Name and Search Key and Optional searchKey1)
        /// Two Ways To Search Indentical (=) and Not Indentical (LIKE '%'+ @searchKey + '%';) 
        /// </summary>
        /// <param name="columnName">refers to Column Name Search by it</param>
        /// <param name="searchKey">refers to Customer ID</param>
        /// <param name="operaName">refers to Operation Name</param>
        /// <param name="searchDate1">refers to start Date of Balance</param>
        /// <param name="searchDate2">refers to End Date of Balance</param>
        /// <returns>DataTable</returns>
        public DataTable SearchCustAccount(string columnName, string searchKey, string operaName,
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
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_CustAccSearch]", SearchParam);
        }
    }
}
