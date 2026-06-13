using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //To Deal With DataTables and DataSet
using System.Data.SqlClient; //To Deal With SQL Server Databases and SqlParameter

namespace PharmacySystemV20._0._1.BAL
{
    class CLS_BuyBill
    {
        //Create new Instance From Singleton Class CLS_ConnectionDB() DataAccessLayer
        readonly DAL.CLS_ConnectionDB Connection = DAL.CLS_ConnectionDB.NewInstance();

        /// <summary>
        /// DataTable Function to Select All Records From BuyBill Table
        /// </summary>
        /// <returns>BuyBill Table</returns>
        public DataTable ShowBuyBillTable()
        {
            /*Use DataTable Function from DAL.CLS_ConnectionDB to Select All Columns From BuyBill Table
             * no any StoredProcedur Parameters in StoredProcedure so Initialize null value
             * Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
             */
            // return Connection.SelectData("[PharmacyDB].[dbo].[SP_BuyBillShow]", null);
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_BuyBillShow]", null);
        }

        /// <summary>
        /// string Function to generate BuyBill ID
        /// </summary>
        /// <returns>buyBillID</returns>
        public string GenerateBuyBillID()
        {
            //int ItemID without assignment any value
            int buyBillID;

            //Initialize return value of DataTable Function From DAL Connection.SelectData("storedProcedureName",SqlParameter[])
            //Assignment the value from DataTable Function After Convert.ToInt32(Connection.SelectData("[DatabaseName].[dbo].[StoredProcedureName]", null).Rows[0][0].ToString())
            buyBillID = Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastBuyBillID]", null).Rows[0][0].ToString());

            //return ItemID.ToString("FormatName-000000");
            return buyBillID.ToString("INVP-000000");
        }


        /// <summary>
        /// Method To Add New Bill to BuyBill Table Database
        /// </summary>
        /// <param name="buyID">buyID</param>
        /// <param name="buyCustomCode">buyCustomCode</param>
        /// <param name="buySupplier">buySupplier</param>
        /// <param name="buySupplierNo">buySupplierNo</param>
        /// <param name="buyPayType">buyPayType</param>
        /// <param name="buyStore">buyStore</param>
        /// <param name="buyBranch">buyBranch</param>
        /// <param name="buyNotes">buyNotes</param>
        /// <param name="buyInvoiceDate">buyInvoiceDate</param>
        /// <param name="buyTotalSaleAmount">buyTotalSaleAmount</param>
        /// <param name="buyTotalBuyAmount">buyTotalBuyAmount</param>
        /// <param name="buyItemCount">buyItemCount</param>
        /// <param name="buyTotalEarn">buyTotalEarn</param>
        /// <param name="buyTotalTax">buyTotalTax</param>
        /// <param name="buyTotalDiscound">buyTotalDiscound</param>
        /// <param name="buyTotalExpenses">buyTotalExpenses</param>
        /// <param name="buyTotalAmount">buyTotalAmount</param>
        /// <param name="buyTotalPaid">buyTotalPaid</param>
        /// <param name="buyTotalRemain">buyTotalRemain</param>
        /// <param name="pcNameWhoAdded">pcNameWhoAdded</param>
        /// <param name="buyWhoAdded">buyWhoAdded</param>
        /// <param name="buyDate">buyDate</param>
        /// <param name="buyTime">buyTime</param>
        public void SaveBuyBill(int buyID, string buyCustomCode, int buySupplier, string buySupplierNo, string buyPayType,
                                int buyStore, int buyBranch, string buyNotes, string buyInvoiceDate, decimal buyTotalSaleAmount,
                                decimal buyTotalBuyAmount, int buyItemCount, decimal buyTotalEarn, decimal buyTotalTax, 
                                decimal buyTotalDiscound, decimal buyTotalExpenses, decimal buyTotalAmount,
                                decimal buyTotalPaid, decimal buyTotalRemain, string pcNameWhoAdded, int buyWhoAdded,
                                string buyDate, string buyTime)
        {
            //Create New Instance From SqlParameter[] which length of it is equal counter of storedprocedureparameter
            SqlParameter[] SaveParam = new SqlParameter[23];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            SaveParam[0] = new SqlParameter("@BuyBillID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[0].Value = buyID;

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            SaveParam[1] = new SqlParameter("@BuyBillCustomID", SqlDbType.NVarChar, 50);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[1].Value = buyCustomCode;

            SaveParam[2] = new SqlParameter("@BuyBillSupplier", SqlDbType.Int);
            SaveParam[2].Value = buySupplier;

            SaveParam[3] = new SqlParameter("@BuyBillSupplierNo", SqlDbType.NVarChar, 50);
            SaveParam[3].Value = buySupplierNo;

            SaveParam[4] = new SqlParameter("@BuyBillPayType", SqlDbType.NVarChar, 50);
            SaveParam[4].Value = buyPayType;

            SaveParam[5] = new SqlParameter("@BuyBillStore", SqlDbType.Int);
            SaveParam[5].Value = buyStore;

            SaveParam[6] = new SqlParameter("@BuyBillBranch", SqlDbType.Int);
            SaveParam[6].Value = buyBranch;

            SaveParam[7] = new SqlParameter("@BuyBillNotes", SqlDbType.NVarChar, 100);
            SaveParam[7].Value = buyNotes;

            SaveParam[8] = new SqlParameter("@BuyBillINVDate", SqlDbType.NVarChar, 50);
            SaveParam[8].Value = buyInvoiceDate;

            SaveParam[9] = new SqlParameter("@BuyBillTotalSaleAmount", SqlDbType.Decimal);
            SaveParam[9].Value = buyTotalSaleAmount;

            SaveParam[10] = new SqlParameter("@BuyBillTotalBuyAmount", SqlDbType.Decimal);
            SaveParam[10].Value = buyTotalBuyAmount;

            SaveParam[11] = new SqlParameter("@BuyBillItemCount", SqlDbType.Int);
            SaveParam[11].Value = buyItemCount;

            SaveParam[12] = new SqlParameter("@BuyBillTotalEarn", SqlDbType.Decimal);
            SaveParam[12].Value = buyTotalEarn;

            SaveParam[13] = new SqlParameter("@BuyBillTotalTax", SqlDbType.Decimal);
            SaveParam[13].Value = buyTotalTax;

            SaveParam[14] = new SqlParameter("@BuyBillTotalDiscound", SqlDbType.Decimal);
            SaveParam[14].Value = buyTotalDiscound;

            SaveParam[15] = new SqlParameter("@BuyBillTotalExpenses", SqlDbType.Decimal);
            SaveParam[15].Value = buyTotalExpenses;

            SaveParam[16] = new SqlParameter("@BuyBillTotalAmount", SqlDbType.Decimal);
            SaveParam[16].Value = buyTotalAmount;

            SaveParam[17] = new SqlParameter("@BuyBillTotalPaid", SqlDbType.Decimal);
            SaveParam[17].Value = buyTotalPaid;

            SaveParam[18] = new SqlParameter("@BuyBillTotalRemain", SqlDbType.Decimal);
            SaveParam[18].Value = buyTotalRemain;

            SaveParam[19] = new SqlParameter("@PcNameWhoAdded", SqlDbType.NVarChar, 50);
            SaveParam[19].Value = pcNameWhoAdded;

            SaveParam[20] = new SqlParameter("@BuyBillWhoAdded", SqlDbType.Int);
            SaveParam[20].Value = buyWhoAdded;

            SaveParam[21] = new SqlParameter("@BuyBillDate", SqlDbType.NVarChar, 50);
            SaveParam[21].Value = buyDate;

            SaveParam[22] = new SqlParameter("@BuyBillTime", SqlDbType.NVarChar, 50);
            SaveParam[22].Value = buyTime;


            //Execute Command Insert into Table Branches by DAL.CLS_ConnectionDB
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_BuyBillEdit]", SaveParam);
        }

        /// <summary>
        /// Method To Delete Record From BuyBill Table
        /// </summary>
        /// <param name="buyID">buyID</param>
        public void DeleteBuyBill(int buyID)
        {
            //Create new instance from SqlParameter[]
            SqlParameter[] DeleteParam = new SqlParameter[1];

            DeleteParam[0] = new SqlParameter("@BuyBillID", SqlDbType.Int);
            DeleteParam[0].Value = buyID;

            //Execute Command To Delete Record from BuyBill Table
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_BuyBillDelete]", DeleteParam);

        }

        /// <summary>
        /// Method To Update BuyBill Table by Modify BuyBillStatus Only (Deactivate BuyBill)
        /// </summary>
        /// <param name="buyID">buyID</param>
        /// <param name="buyStatus">buyStatus</param>
        /// <param name="pcNameWhoDeleted">pcNameWhoDeleted</param>
        /// <param name="buyWhoDeleted">buyWhoDeleted</param>
        public void DeactivateBuyBill(int buyID, bool buyStatus, string pcNameWhoDeleted, int buyWhoDeleted)
        {
            //Create New Instance From SqlParameter [] array
            SqlParameter[] DeleteParam = new SqlParameter[4];

            DeleteParam[0] = new SqlParameter("@BuyBillID", SqlDbType.Int);
            DeleteParam[0].Value = buyID;

            DeleteParam[1] = new SqlParameter("@BuyBillStatus", SqlDbType.Bit);
            DeleteParam[1].Value = buyStatus;

            DeleteParam[2] = new SqlParameter("@PcNameWhoDeleted", SqlDbType.NVarChar, 50);
            DeleteParam[2].Value = pcNameWhoDeleted;

            DeleteParam[3] = new SqlParameter("@BuyBillWhoDeleted", SqlDbType.Int);
            DeleteParam[3].Value = buyWhoDeleted;

            //Execute Command to Update BuyBill table by In Activate BuyBill
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_BuyBillDeactivate]", DeleteParam);
        }


        /// <summary>
        /// Method To Update BuyBill Table 
        /// </summary>
        /// <param name="buyID">buyID</param>
        /// <param name="buySupplier">buySupplier</param>
        /// <param name="buySupplierNo">buySupplierNo</param>
        /// <param name="buyPayType">buyPayType</param>
        /// <param name="buyStore">buyStore</param>
        /// <param name="buyBranch">buyBranch</param>
        /// <param name="buyNotes">buyNotes</param>
        /// <param name="buyInvoiceDate">buyInvoiceDate</param>
        /// <param name="buyTotalSaleAmount">buyTotalSaleAmount</param>
        /// <param name="buyTotalBuyAmount">buyTotalBuyAmount</param>
        /// <param name="buyItemCount">buyItemCount</param>
        /// <param name="buyTotalEarn">buyTotalEarn</param>
        /// <param name="buyTotalTax">buyTotalTax</param>
        /// <param name="buyTotalDiscound">buyTotalDiscound</param>
        /// <param name="buyTotalExpenses">buyTotalExpenses</param>
        /// <param name="buyTotalAmount">buyTotalAmount</param>
        /// <param name="buyTotalPaid">buyTotalPaid</param>
        /// <param name="buyTotalRemain">buyTotalRemain</param>
        /// <param name="pcNameWhoModified">pcNameWhoModified</param>
        /// <param name="buyWhoModified">buyWhoModified</param>
        public void UpdateBuyBill(int buyID, int buySupplier, string buySupplierNo, string buyPayType,
                                  int buyStore, int buyBranch, string buyNotes, string buyInvoiceDate, decimal buyTotalSaleAmount,
                                  decimal buyTotalBuyAmount, int buyItemCount, decimal buyTotalEarn, decimal buyTotalTax,
                                  decimal buyTotalDiscound, decimal buyTotalExpenses, decimal buyTotalAmount,
                                  decimal buyTotalPaid, decimal buyTotalRemain, string pcNameWhoModified, int buyWhoModified)
        {

            //Create New Instance From SqlParameter[]
            SqlParameter[] UpdateParam = new SqlParameter[20];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            UpdateParam[0] = new SqlParameter("@BuyBillID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[0].Value = buyID;

            UpdateParam[1] = new SqlParameter("@BuyBillSupplier", SqlDbType.Int);
            UpdateParam[1].Value = buySupplier;

            UpdateParam[2] = new SqlParameter("@BuyBillSupplierNo", SqlDbType.NVarChar, 50);
            UpdateParam[2].Value = buySupplierNo;

            UpdateParam[3] = new SqlParameter("@BuyBillPayType", SqlDbType.NVarChar, 50);
            UpdateParam[3].Value = buyPayType;

            UpdateParam[4] = new SqlParameter("@BuyBillStore", SqlDbType.Int);
            UpdateParam[4].Value = buyStore;

            UpdateParam[5] = new SqlParameter("@BuyBillBranch", SqlDbType.Int);
            UpdateParam[5].Value = buyBranch;

            UpdateParam[6] = new SqlParameter("@BuyBillNotes", SqlDbType.NVarChar, 100);
            UpdateParam[6].Value = buyNotes;

            UpdateParam[7] = new SqlParameter("@BuyBillINVDate", SqlDbType.NVarChar, 50);
            UpdateParam[7].Value = buyInvoiceDate;

            UpdateParam[8] = new SqlParameter("@BuyBillTotalSaleAmount", SqlDbType.Decimal);
            UpdateParam[8].Value = buyTotalSaleAmount;

            UpdateParam[9] = new SqlParameter("@BuyBillTotalBuyAmount", SqlDbType.Decimal);
            UpdateParam[9].Value = buyTotalBuyAmount;

            UpdateParam[10] = new SqlParameter("@BuyBillItemCount", SqlDbType.Int);
            UpdateParam[10].Value = buyItemCount;

            UpdateParam[11] = new SqlParameter("@BuyBillTotalEarn", SqlDbType.Decimal);
            UpdateParam[11].Value = buyTotalEarn;

            UpdateParam[12] = new SqlParameter("@BuyBillTotalTax", SqlDbType.Decimal);
            UpdateParam[12].Value = buyTotalTax;

            UpdateParam[13] = new SqlParameter("@BuyBillTotalDiscound", SqlDbType.Decimal);
            UpdateParam[13].Value = buyTotalDiscound;

            UpdateParam[14] = new SqlParameter("@BuyBillTotalExpenses", SqlDbType.Decimal);
            UpdateParam[14].Value = buyTotalExpenses;

            UpdateParam[15] = new SqlParameter("@BuyBillTotalAmount", SqlDbType.Decimal);
            UpdateParam[15].Value = buyTotalAmount;

            UpdateParam[16] = new SqlParameter("@BuyBillTotalPaid", SqlDbType.Decimal);
            UpdateParam[16].Value = buyTotalPaid;

            UpdateParam[17] = new SqlParameter("@BuyBillTotalRemain", SqlDbType.Decimal);
            UpdateParam[17].Value = buyTotalRemain;

            UpdateParam[18] = new SqlParameter("@PcNameWhoModified", SqlDbType.NVarChar, 50);
            UpdateParam[18].Value = pcNameWhoModified;

            UpdateParam[19] = new SqlParameter("@BuyBillWhoModified", SqlDbType.Int);
            UpdateParam[19].Value = buyWhoModified;

            //Execute Command to Update any Record of BuyBillUpdate Table by BuyBillUpdate
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_BuyBillUpdate]", UpdateParam);
        }

        /// <summary>
        /// DataTable Function To Advanced Search in BuyBill Table 
        /// Recieve Five Parameters Column Name and Search Key and CheckSearchDate and Date1 and Date2
        /// Two Ways To Search Indentical (=) and Not Indentical (LIKE '%'+ @searchKey + '%';)
        /// </summary>
        /// <param name="ColumnName">ColumnName</param>
        /// <param name="SearchKey">SearchKey</param>
        /// <param name="checkDate">checkDate</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <returns>DataTable Of BuyBill Table</returns>
        public DataTable SearchBuyBill(string columnName, string searchKey, bool checkDate, string startDate, string endDate)
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

            //Return DataTable which like search key //SP_BuyBillSearch
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_BuyBillTotalSearch]", SearchParam);
        }
    }
}
