using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data; //To Deal With DataTables and DataSet
using System.Data.SqlClient; //To Deal With SQL Server Databases and SqlParameter

namespace PharmacySystemV20._0._1.BAL
{
    class CLS_ReSaleBill
    {
        //Create new Instance From Singleton Class CLS_ConnectionDB() DataAccessLayer
        readonly DAL.CLS_ConnectionDB Connection = DAL.CLS_ConnectionDB.NewInstance();

        /// <summary>
        /// DataTable Function to Select All Records From ReSaleBill Table
        /// </summary>
        /// <returns>ReSaleBill Table</returns>
        public DataTable ShowReSaleBillTable()
        {
            /*Use DataTable Function from DAL.CLS_ConnectionDB to Select All Columns From ReSaleBill Table
             * no any StoredProcedur Parameters in StoredProcedure so Initialize null value
             * Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
             */
            // return Connection.SelectData("[PharmacyDB].[dbo].[SP_ReSaleShow]", null);
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_ReSaleShow]", null);
        }

        /// <summary>
        /// string Function to generate ReSaleBill ID
        /// </summary>
        /// <returns>ReSaleBillID</returns>
        public string GenerateReSaleBillID()
        {
            //int ItemID without assignment any value
            int ReSaleBillID;

            //Initialize return value of DataTable Function From DAL Connection.SelectData("storedProcedureName",SqlParameter[])
            //Assignment the value from DataTable Function After Convert.ToInt32(Connection.SelectData("[DatabaseName].[dbo].[StoredProcedureName]", null).Rows[0][0].ToString())
            ReSaleBillID = Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastReSaleID]", null).Rows[0][0].ToString());

            //return ItemID.ToString("FormatName-000000");
            return ReSaleBillID.ToString("INRS-000000");
        }


        /// <summary>
        /// Method To Add New Bill to ReSaleBill Table Database
        /// </summary>
        /// <param name="ReSaleID">ReSaleID</param>
        /// <param name="ReSaleCustomCode">ReSaleCustomCode</param>
        /// <param name="ReSaleTotalSaleAmount">ReSaleTotalSaleAmount</param>
        /// <param name="ReSaleTotalBuyAmount">ReSaleTotalBuyAmount</param>
        /// <param name="ReSaleItemCount">ReSaleItemCount</param>
        /// <param name="ReSaleNotes">ReSaleNotes</param>
        /// <param name="ReSaleTotalRequired">ReSaleTotalRequired</param>
        /// <param name="ReSaleTotalPaid">ReSaleTotalPaid</param>
        /// <param name="ReSaleTotalRemain">ReSaleTotalRemain</param>
        /// <param name="pcNameWhoAdded">pcNameWhoAdded</param>
        /// <param name="ReSaleWhoAdded">ReSaleWhoAdded</param>
        /// <param name="ReSaleDate">ReSaleDate</param>
        /// <param name="ReSaleTime">ReSaleTime</param>
        public void SaveReSaleBill(int ReSaleID, string ReSaleCustomCode, decimal ReSaleTotalSaleAmount,
                                  decimal ReSaleTotalBuyAmount, int ReSaleItemCount, string ReSaleNotes,
                                  decimal ReSaleTotalRequired, decimal ReSaleTotalPaid, decimal ReSaleTotalRemain,
                                  string pcNameWhoAdded, int ReSaleWhoAdded,
                                  string ReSaleDate, string ReSaleTime)
        {

            //Create New Instance From SqlParameter[] which length of it is equal counter of storedprocedureparameter
            SqlParameter[] SaveParam = new SqlParameter[13];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            SaveParam[0] = new SqlParameter("@ReSaleBillID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[0].Value = ReSaleID;

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            SaveParam[1] = new SqlParameter("@ReSaleCustomID", SqlDbType.NVarChar, 50);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[1].Value = ReSaleCustomCode;

            SaveParam[2] = new SqlParameter("@ReSaleBillTotalSaleAmount", SqlDbType.Decimal);
            SaveParam[2].Value = ReSaleTotalSaleAmount;

            SaveParam[3] = new SqlParameter("@ReSaleBillTotalBuyAmount", SqlDbType.Decimal);
            SaveParam[3].Value = ReSaleTotalBuyAmount;

            SaveParam[4] = new SqlParameter("@ReSaleBillItemCount", SqlDbType.Int);
            SaveParam[4].Value = ReSaleItemCount;

            SaveParam[5] = new SqlParameter("@ReSaleBillNotes", SqlDbType.NVarChar, 100);
            SaveParam[5].Value = ReSaleNotes;

            SaveParam[6] = new SqlParameter("@ReSaleBillTotalRequired", SqlDbType.Decimal);
            SaveParam[6].Value = ReSaleTotalRequired;

            SaveParam[7] = new SqlParameter("@ReSaleBillTotalPaid", SqlDbType.Decimal);
            SaveParam[7].Value = ReSaleTotalPaid;

            SaveParam[8] = new SqlParameter("@ReSaleBillTotalRemain", SqlDbType.Decimal);
            SaveParam[8].Value = ReSaleTotalRemain;

            SaveParam[9] = new SqlParameter("@PcNameWhoAdded", SqlDbType.NVarChar, 50);
            SaveParam[9].Value = pcNameWhoAdded;

            SaveParam[10] = new SqlParameter("@ReSaleBillWhoAdded", SqlDbType.Int);
            SaveParam[10].Value = ReSaleWhoAdded;

            SaveParam[11] = new SqlParameter("@ReSaleBillDate", SqlDbType.NVarChar, 50);
            SaveParam[11].Value = ReSaleDate;

            SaveParam[12] = new SqlParameter("@ReSaleBillTime", SqlDbType.NVarChar, 50);
            SaveParam[12].Value = ReSaleTime;

            //Execute Command Insert into Table ReSaleBill by DAL.CLS_ConnectionDB
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ReSaleEdit]", SaveParam);
        }

        /// <summary>
        /// Method To Delete Record From ReSaleBill Table
        /// </summary>
        /// <param name="ReSaleID">ReSaleID</param>
        public void DeleteReSaleBill(int ReSaleID)
        {
            //Create new instance from SqlParameter[]
            SqlParameter[] DeleteParam = new SqlParameter[1];

            DeleteParam[0] = new SqlParameter("@ReSaleBillID", SqlDbType.Int);
            DeleteParam[0].Value = ReSaleID;

            //Execute Command To Delete Record from ReSaleBill Table
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ReSaleDelete]", DeleteParam);

        }

        /// <summary>
        /// Method To Update ReSaleBill Table by Modify ReSaleBillStatus Only (Deactivate ReSaleBill)
        /// </summary>
        /// <param name="ReSaleID">ReSaleID</param>
        /// <param name="ReSaleStatus">ReSaleStatus</param>
        /// <param name="pcNameWhoDeleted">pcNameWhoDeleted</param>
        /// <param name="ReSaleWhoDeleted">ReSaleWhoDeleted</param>
        public void DeactivateReSaleBill(int ReSaleID, bool ReSaleStatus, string pcNameWhoDeleted, int ReSaleWhoDeleted)
        {
            //Create New Instance From SqlParameter [] array
            SqlParameter[] DeleteParam = new SqlParameter[4];

            DeleteParam[0] = new SqlParameter("@ReSaleBillID", SqlDbType.Int);
            DeleteParam[0].Value = ReSaleID;

            DeleteParam[1] = new SqlParameter("@ReSaleBillStatus", SqlDbType.Bit);
            DeleteParam[1].Value = ReSaleStatus;

            DeleteParam[2] = new SqlParameter("@PcNameWhoDeleted", SqlDbType.NVarChar, 50);
            DeleteParam[2].Value = pcNameWhoDeleted;

            DeleteParam[3] = new SqlParameter("@ReSaleBillWhoDeleted", SqlDbType.Int);
            DeleteParam[3].Value = ReSaleWhoDeleted;

            //Execute Command to Update ReSaleBill table by In Activate ReSaleBillStatus
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ReSaleDeactivate]", DeleteParam);
        }

        /// <summary>
        /// Method To Update ReSaleBill Table 
        /// </summary>
        /// <param name="ReSaleID">ReSaleID</param>
        /// <param name="ReSaleTotalSaleAmount">ReSaleTotalSaleAmount</param>
        /// <param name="ReSaleTotalBuyAmount">ReSaleTotalBuyAmount</param>
        /// <param name="ReSaleItemCount">ReSaleItemCount</param>
        /// <param name="ReSaleNotes">ReSaleNotes</param>
        /// <param name="pcNameWhoModified">pcNameWhoModified</param>
        /// <param name="ReSaleWhoModified">ReSaleWhoModified</param>
        public void UpdateReSaleBill(int ReSaleID, decimal ReSaleTotalSaleAmount, decimal ReSaleTotalBuyAmount,
                                    int ReSaleItemCount, string ReSaleNotes, string pcNameWhoModified,
                                    int ReSaleWhoModified)
        {
            //Create New Instance From SqlParameter[]
            SqlParameter[] UpdateParam = new SqlParameter[7];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            UpdateParam[0] = new SqlParameter("@ReSaleBillID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[0].Value = ReSaleID;

            UpdateParam[1] = new SqlParameter("@ReSaleBillTotalSaleAmount", SqlDbType.Decimal);
            UpdateParam[1].Value = ReSaleTotalSaleAmount;

            UpdateParam[2] = new SqlParameter("@ReSaleBillTotalBuyAmount", SqlDbType.Decimal);
            UpdateParam[2].Value = ReSaleTotalBuyAmount;

            UpdateParam[3] = new SqlParameter("@ReSaleBillItemCount", SqlDbType.Int);
            UpdateParam[3].Value = ReSaleItemCount;

            UpdateParam[4] = new SqlParameter("@ReSaleBillNotes", SqlDbType.NVarChar, 100);
            UpdateParam[4].Value = ReSaleNotes;

            UpdateParam[5] = new SqlParameter("@PcNameWhoModified", SqlDbType.NVarChar, 50);
            UpdateParam[5].Value = pcNameWhoModified;

            UpdateParam[6] = new SqlParameter("@ReSaleBillWhoModified", SqlDbType.Int);
            UpdateParam[6].Value = ReSaleWhoModified;


            //Execute Command to Update any Record of ReSaleBillUpdate Table by ReSaleBillUpdate
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ReSaleUpdate]", UpdateParam);
        }

        /// <summary>
        /// DataTable Function To Advanced Search in ReSaleBill Table
        /// Recieve Two Parameters Column Name and Search Key
        /// Two Ways To Search Indentical (=) and Not Indentical (LIKE '%'+ @searchKey + '%';)
        /// </summary>
        /// <param name="ColumnName">ColumnName</param>
        /// <param name="SearchKey">SearchKey</param>
        /// <returns>DataTable</returns>
        public DataTable SearchReSaleBill(string columnName, string searchKey)
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
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_ReSaleBillTotalSearch]", SearchParam);
        }


        /// <summary>
        /// DataTable Function To Advanced Search in ReSaleBill Table 
        /// Recieve Five Parameters Column Name and Search Key and CheckSearchDate and Date1 and Date2
        /// Two Ways To Search Indentical (=) and Not Indentical (LIKE '%'+ @searchKey + '%';)
        /// </summary>
        /// <param name="ColumnName">ColumnName</param>
        /// <param name="SearchKey">SearchKey</param>
        /// <param name="checkDate">checkDate</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <returns>DataTable Of BuyBill Table</returns>
        public DataTable SearchReSaleBill(string columnName, string searchKey, bool checkDate, string startDate, string endDate)
        {
            //Create New Instance From SqlParameter[]
            SqlParameter[] SearchParam = new SqlParameter[5];
            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            SearchParam[0] = new SqlParameter("@ColumnName", SqlDbType.NVarChar, 25);
            //Initialize value of every element in array by Argument which received from form
            SearchParam[0].Value = columnName;

            SearchParam[1] = new SqlParameter("@SearchKey", SqlDbType.NVarChar, 100);
            SearchParam[1].Value = searchKey;

            SearchParam[2] = new SqlParameter("@CheckSearchDate", SqlDbType.Bit);
            SearchParam[2].Value = checkDate;

            SearchParam[3] = new SqlParameter("@SearchDate1", SqlDbType.NVarChar, 50);
            SearchParam[3].Value = startDate;

            SearchParam[4] = new SqlParameter("@SearchDate2", SqlDbType.NVarChar, 50);
            SearchParam[4].Value = endDate;

            //Return DataTable which like search key //SP_ReSaleBillSearch
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_ReSaleBillSearch]", SearchParam);
        }
    }
}
