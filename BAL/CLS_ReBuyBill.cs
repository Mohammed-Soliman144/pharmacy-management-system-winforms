using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //To Deal With DataTables and DataSet
using System.Data.SqlClient; //To Deal With SQL Server Databases and SqlParameter

namespace PharmacySystemV20._0._1.BAL
{
    class CLS_ReBuyBill
    {
        //Create new Instance From Singleton Class CLS_ConnectionDB() DataAccessLayer
        readonly DAL.CLS_ConnectionDB Connection = DAL.CLS_ConnectionDB.NewInstance();

        /// <summary>
        /// DataTable Function to Select All Records From ReBuyBill Table
        /// </summary>
        /// <returns>ReBuyBill Table</returns>
        public DataTable ShowReBuyBillTable()
        {
            /*Use DataTable Function from DAL.CLS_ConnectionDB to Select All Columns From ReBuyBill Table
             * no any StoredProcedur Parameters in StoredProcedure so Initialize null value
             * Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
             */
            // return Connection.SelectData("[PharmacyDB].[dbo].[SP_ReBuyShow]", null);
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_ReBuyShow]", null);
        }

        /// <summary>
        /// string Function to generate ReBuyBill ID
        /// </summary>
        /// <returns>reBuyBillID</returns>
        public string GenerateReBuyBillID()
        {
            //int ItemID without assignment any value
            int reBuyBillID;

            //Initialize return value of DataTable Function From DAL Connection.SelectData("storedProcedureName",SqlParameter[])
            //Assignment the value from DataTable Function After Convert.ToInt32(Connection.SelectData("[DatabaseName].[dbo].[StoredProcedureName]", null).Rows[0][0].ToString())
            reBuyBillID = Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastReBuyID]", null).Rows[0][0].ToString());

            //return ItemID.ToString("FormatName-000000");
            return reBuyBillID.ToString("INRP-000000");
        }


        /// <summary>
        /// Method To Add New Bill to ReBuyBill Table Database
        /// </summary>
        /// <param name="reBuyID">reBuyID</param>
        /// <param name="reBuyCustomCode">reBuyCustomCode</param>
        /// <param name="reBuyTotalSaleAmount">reBuyTotalSaleAmount</param>
        /// <param name="reBuyTotalBuyAmount">reBuyTotalBuyAmount</param>
        /// <param name="reBuyItemCount">reBuyItemCount</param>
        /// <param name="reBuyNotes">reBuyNotes</param>
        /// <param name="reBuyTotalRequired">reBuyTotalRequired</param>
        /// <param name="reBuyTotalPaid">reBuyTotalPaid</param>
        /// <param name="reBuyTotalRemain">reBuyTotalRemain</param>
        /// <param name="pcNameWhoAdded">pcNameWhoAdded</param>
        /// <param name="reBuyWhoAdded">reBuyWhoAdded</param>
        /// <param name="reBuyDate">reBuyDate</param>
        /// <param name="reBuyTime">reBuyTime</param>
        public void SaveReBuyBill(int reBuyID, string reBuyCustomCode, decimal reBuyTotalSaleAmount, 
                                  decimal reBuyTotalBuyAmount,int reBuyItemCount, string reBuyNotes,
                                  decimal reBuyTotalRequired, decimal reBuyTotalPaid, decimal reBuyTotalRemain,
                                  string pcNameWhoAdded, int reBuyWhoAdded,
                                  string reBuyDate, string reBuyTime)
        {
            //Create New Instance From SqlParameter[] which length of it is equal counter of storedprocedureparameter
            SqlParameter[] SaveParam = new SqlParameter[13];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            SaveParam[0] = new SqlParameter("@ReBuyBillID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[0].Value = reBuyID;

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            SaveParam[1] = new SqlParameter("@ReBuyCustomID", SqlDbType.NVarChar, 50);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[1].Value = reBuyCustomCode;

            SaveParam[2] = new SqlParameter("@ReBuyBillTotalSaleAmount", SqlDbType.Decimal);
            SaveParam[2].Value = reBuyTotalSaleAmount;

            SaveParam[3] = new SqlParameter("@ReBuyBillTotalBuyAmount", SqlDbType.Decimal);
            SaveParam[3].Value = reBuyTotalBuyAmount;

            SaveParam[4] = new SqlParameter("@ReBuyBillItemCount", SqlDbType.Int);
            SaveParam[4].Value = reBuyItemCount;

            SaveParam[5] = new SqlParameter("@ReBuyBillNotes", SqlDbType.NVarChar, 100);
            SaveParam[5].Value = reBuyNotes;

            SaveParam[6] = new SqlParameter("@ReBuyBillTotalRequired", SqlDbType.Decimal);
            SaveParam[6].Value = reBuyTotalRequired;

            SaveParam[7] = new SqlParameter("@ReBuyBillTotalPaid", SqlDbType.Decimal);
            SaveParam[7].Value = reBuyTotalPaid;

            SaveParam[8] = new SqlParameter("@ReBuyBillTotalRemain", SqlDbType.Decimal);
            SaveParam[8].Value = reBuyTotalRemain;

            SaveParam[9] = new SqlParameter("@PcNameWhoAdded", SqlDbType.NVarChar, 50);
            SaveParam[9].Value = pcNameWhoAdded;

            SaveParam[10] = new SqlParameter("@ReBuyBillWhoAdded", SqlDbType.Int);
            SaveParam[10].Value = reBuyWhoAdded;

            SaveParam[11] = new SqlParameter("@ReBuyBillDate", SqlDbType.NVarChar, 50);
            SaveParam[11].Value = reBuyDate;

            SaveParam[12] = new SqlParameter("@ReBuyBillTime", SqlDbType.NVarChar, 50);
            SaveParam[12].Value = reBuyTime;

            //Execute Command Insert into Table ReBuyBill by DAL.CLS_ConnectionDB
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ReBuyEdit]", SaveParam);
        }

        /// <summary>
        /// Method To Delete Record From ReBuyBill Table
        /// </summary>
        /// <param name="reBuyID">reBuyID</param>
        public void DeleteReBuyBill(int reBuyID)
        {
            //Create new instance from SqlParameter[]
            SqlParameter[] DeleteParam = new SqlParameter[1];

            DeleteParam[0] = new SqlParameter("@ReBuyBillID", SqlDbType.Int);
            DeleteParam[0].Value = reBuyID;

            //Execute Command To Delete Record from ReBuyBill Table
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ReBuyDelete]", DeleteParam);

        }

        /// <summary>
        /// Method To Update ReBuyBill Table by Modify ReBuyBillStatus Only (Deactivate ReBuyBill)
        /// </summary>
        /// <param name="reBuyID">reBuyID</param>
        /// <param name="reBuyStatus">reBuyStatus</param>
        /// <param name="pcNameWhoDeleted">pcNameWhoDeleted</param>
        /// <param name="reBuyWhoDeleted">reBuyWhoDeleted</param>
        public void DeactivateReBuyBill(int reBuyID, bool reBuyStatus, string pcNameWhoDeleted, int reBuyWhoDeleted)
        {
            //Create New Instance From SqlParameter [] array
            SqlParameter[] DeleteParam = new SqlParameter[4];

            DeleteParam[0] = new SqlParameter("@ReBuyBillID", SqlDbType.Int);
            DeleteParam[0].Value = reBuyID;

            DeleteParam[1] = new SqlParameter("@ReBuyBillStatus", SqlDbType.Bit);
            DeleteParam[1].Value = reBuyStatus;

            DeleteParam[2] = new SqlParameter("@PcNameWhoDeleted", SqlDbType.NVarChar, 50);
            DeleteParam[2].Value = pcNameWhoDeleted;

            DeleteParam[3] = new SqlParameter("@ReBuyBillWhoDeleted", SqlDbType.Int);
            DeleteParam[3].Value = reBuyWhoDeleted;

            //Execute Command to Update ReBuyBill table by In Activate ReBuyBillStatus
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ReBuyDeactivate]", DeleteParam);
        }

        /// <summary>
        /// Method To Update ReBuyBill Table 
        /// </summary>
        /// <param name="reBuyID">reBuyID</param>
        /// <param name="reBuyTotalSaleAmount">reBuyTotalSaleAmount</param>
        /// <param name="reBuyTotalBuyAmount">reBuyTotalBuyAmount</param>
        /// <param name="reBuyItemCount">reBuyItemCount</param>
        /// <param name="reBuyNotes">reBuyNotes</param>
        /// <param name="pcNameWhoModified">pcNameWhoModified</param>
        /// <param name="reBuyWhoModified">reBuyWhoModified</param>
        public void UpdateReBuyBill(int reBuyID, decimal reBuyTotalSaleAmount, decimal reBuyTotalBuyAmount,
                                    int reBuyItemCount, string reBuyNotes, string pcNameWhoModified,
                                    int reBuyWhoModified)
        {

            //Create New Instance From SqlParameter[]
            SqlParameter[] UpdateParam = new SqlParameter[7];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            UpdateParam[0] = new SqlParameter("@ReBuyBillID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[0].Value = reBuyID;

            UpdateParam[1] = new SqlParameter("@ReBuyBillTotalSaleAmount", SqlDbType.Decimal);
            UpdateParam[1].Value = reBuyTotalSaleAmount;

            UpdateParam[2] = new SqlParameter("@ReBuyBillTotalBuyAmount", SqlDbType.Decimal);
            UpdateParam[2].Value = reBuyTotalBuyAmount;

            UpdateParam[3] = new SqlParameter("@ReBuyBillItemCount", SqlDbType.Int);
            UpdateParam[3].Value = reBuyItemCount;

            UpdateParam[4] = new SqlParameter("@ReBuyBillNotes", SqlDbType.NVarChar, 100);
            UpdateParam[4].Value = reBuyNotes;

            UpdateParam[5] = new SqlParameter("@PcNameWhoModified", SqlDbType.NVarChar, 50);
            UpdateParam[5].Value = pcNameWhoModified;

            UpdateParam[6] = new SqlParameter("@ReBuyBillWhoModified", SqlDbType.Int);
            UpdateParam[6].Value = reBuyWhoModified;


            //Execute Command to Update any Record of ReBuyBillUpdate Table by ReBuyBillUpdate
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ReBuyUpdate]", UpdateParam);
        }

        /// <summary>
        /// DataTable Function To Advanced Search in ReBuyBill Table
        /// Recieve Two Parameters Column Name and Search Key
        /// Two Ways To Search Indentical (=) and Not Indentical (LIKE '%'+ @searchKey + '%';)
        /// </summary>
        /// <param name="ColumnName">ColumnName</param>
        /// <param name="SearchKey">SearchKey</param>
        /// <returns>DataTable</returns>
        public DataTable SearchReBuyBill(string columnName, string searchKey)
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
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_ReBuyBillTotalSearch]", SearchParam);
        }


        /// <summary>
        /// DataTable Function To Advanced Search in ReBuyBill Table 
        /// Recieve Five Parameters Column Name and Search Key and CheckSearchDate and Date1 and Date2
        /// Two Ways To Search Indentical (=) and Not Indentical (LIKE '%'+ @searchKey + '%';)
        /// </summary>
        /// <param name="ColumnName">ColumnName</param>
        /// <param name="SearchKey">SearchKey</param>
        /// <param name="checkDate">checkDate</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <returns>DataTable Of BuyBill Table</returns>
        public DataTable SearchReBuyBill (string columnName, string searchKey, bool checkDate, string startDate, string endDate)
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

            //Return DataTable which like search key //SP_ReBuyBillSearch
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_ReBuyBillSearch]", SearchParam);
        }
    }
}
