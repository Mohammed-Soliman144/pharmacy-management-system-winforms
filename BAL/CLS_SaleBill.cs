using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data; //To Deal With DataTables and DataSet
using System.Data.SqlClient; //To Deal With SQL Server Databases and SqlParameter

namespace PharmacySystemV20._0._1.BAL
{
    class CLS_SaleBill
    {
        //Create new Instance From Singleton Class CLS_ConnectionDB() DataAccessLayer
        readonly DAL.CLS_ConnectionDB Connection = DAL.CLS_ConnectionDB.NewInstance();

        /// <summary>
        /// DataTable Function to Select All Records From SalesBill Table
        /// </summary>
        /// <returns>SalesBill Table</returns>
        public DataTable ShowSaleBillTable()
        {
            /*Use DataTable Function from DAL.CLS_ConnectionDB to Select All Columns From saleBill Table
             * no any StoredProcedur Parameters in StoredProcedure so Initialize null value
             * Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
             */
            // return Connection.SelectData("[PharmacyDB].[dbo].[SP_SaleBillShow]", null);
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_SaleBillShow]", null);
        }

        /// <summary>
        /// string Function to generate SaleBill ID
        /// </summary>
        /// <returns>saleSaleID</returns>
        public string GenerateSaleBillID()
        {
            //int saleBillID without assignment any value
            int saleBillID;

            //Initialize return value of DataTable Function From DAL Connection.SelectData("storedProcedureName",SqlParameter[])
            //Assignment the value from DataTable Function After Convert.ToInt32(Connection.SelectData("[DatabaseName].[dbo].[StoredProcedureName]", null).Rows[0][0].ToString())
            saleBillID = Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastSaleBillID]", null).Rows[0][0].ToString());

            //return saleBillID.ToString("FormatName-000000");
            return saleBillID.ToString("INVS-000000");
        }

        /// <summary>
        /// Method To Add New Bill to SaleBill Table Database
        /// </summary>
        /// <param name="saleID">saleID</param>
        /// <param name="saleCustomCode">saleCustomCode</param>
        /// <param name="saleCustomer">saleCustomer</param>
        /// <param name="salePayType">salePayType</param>
        /// <param name="saleStore">saleStore</param>
        /// <param name="saleBranch">saleBranch</param>
        /// <param name="saleNotes">saleNotes</param>
        /// <param name="saleInvoiceDate">saleInvoiceDate</param>
        /// <param name="saleTotalSaleAmount">saleTotalSaleAmount</param>
        /// <param name="saleNetsaleAmount">saleNetsaleAmount</param>
        /// <param name="saleTotalsaleAmount">saleTotalsaleAmount</param>
        /// <param name="saleItemCount">saleItemCount</param>
        /// <param name="saleTotalEarn">saleTotalEarn</param>
        /// <param name="saleTotalTax">saleTotalTax</param>
        /// <param name="saleTotalDiscound">saleTotalDiscound</param>
        /// <param name="saleTotalExpenses">saleTotalExpenses</param>
        /// <param name="saleTotalAmount">saleTotalAmount</param>
        /// <param name="saleTotalPaid">saleTotalPaid</param>
        /// <param name="saleTotalRemain">saleTotalRemain</param>
        /// <param name="pcNameWhoAdded">pcNameWhoAdded</param>
        /// <param name="saleWhoAdded">saleWhoAdded</param>
        /// <param name="saleDate">saleDate</param>
        /// <param name="saleTime">saleTime</param>
        public void SaveSaleBill(int saleID, string saleCustomCode, int saleCustomer, string salePayType,
                                int saleStore, int saleBranch, string saleNotes, string saleInvoiceDate, decimal saleTotalSaleAmount,
                                decimal saleNetsaleAmount, decimal saleTotalBuyAmount, int saleItemCount, decimal saleTotalEarn, decimal saleTotalTax,
                                decimal saleTotalDiscound, decimal saleTotalExpenses, decimal saleTotalAmount,
                                decimal saleTotalPaid, decimal saleTotalRemain, string pcNameWhoAdded, int saleWhoAdded,
                                string saleDate, string saleTime)
        {
            //Create New Instance From SqlParameter[] which length of it is equal counter of storedprocedureparameter
            SqlParameter[] SaveParam = new SqlParameter[23];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            SaveParam[0] = new SqlParameter("@SaleBillID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[0].Value = saleID;

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            SaveParam[1] = new SqlParameter("@SaleBillCustomID", SqlDbType.NVarChar, 50);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[1].Value = saleCustomCode;

            SaveParam[2] = new SqlParameter("@SaleBillCustomer", SqlDbType.Int);
            SaveParam[2].Value = saleCustomer;

            SaveParam[3] = new SqlParameter("@SaleBillPayType", SqlDbType.NVarChar, 50);
            SaveParam[3].Value = salePayType;

            SaveParam[4] = new SqlParameter("@SaleBillStore", SqlDbType.Int);
            SaveParam[4].Value = saleStore;

            SaveParam[5] = new SqlParameter("@SaleBillBranch", SqlDbType.Int);
            SaveParam[5].Value = saleBranch;

            SaveParam[6] = new SqlParameter("@SaleBillINVDate", SqlDbType.NVarChar, 50);
            SaveParam[6].Value = saleInvoiceDate;

            SaveParam[7] = new SqlParameter("@SaleBillNotes", SqlDbType.NVarChar, 100);
            SaveParam[7].Value = saleNotes;

            SaveParam[8] = new SqlParameter("@SaleBillTotalDiscound", SqlDbType.NVarChar, 50);
            SaveParam[8].Value = saleTotalDiscound;

            SaveParam[9] = new SqlParameter("@SaleBillTotalSaleAmount", SqlDbType.Decimal);
            SaveParam[9].Value = saleTotalSaleAmount;

            SaveParam[10] = new SqlParameter("@SaleBillNetSaleAmount", SqlDbType.Decimal);
            SaveParam[10].Value = saleNetsaleAmount;

            SaveParam[11] = new SqlParameter("@SaleBillTotalBuyAmount", SqlDbType.Decimal);
            SaveParam[11].Value = saleTotalBuyAmount;

            SaveParam[12] = new SqlParameter("@SaleBillItemCount", SqlDbType.Int);
            SaveParam[12].Value = saleItemCount;

            SaveParam[13] = new SqlParameter("@SaleBillTotalEarn", SqlDbType.Decimal);
            SaveParam[13].Value = saleTotalEarn;

            SaveParam[14] = new SqlParameter("@SaleBillTotalTax", SqlDbType.Decimal);
            SaveParam[14].Value = saleTotalTax;

            SaveParam[15] = new SqlParameter("@SaleBillTotalExpenses", SqlDbType.Decimal);
            SaveParam[15].Value = saleTotalExpenses;

            SaveParam[16] = new SqlParameter("@SaleBillTotalAmount", SqlDbType.Decimal);
            SaveParam[16].Value = saleTotalAmount;

            SaveParam[17] = new SqlParameter("@SaleBillTotalPaid", SqlDbType.Decimal);
            SaveParam[17].Value = saleTotalPaid;

            SaveParam[18] = new SqlParameter("@SaleBillTotalRemain", SqlDbType.Decimal);
            SaveParam[18].Value = saleTotalRemain;

            SaveParam[19] = new SqlParameter("@PcNameWhoAdded", SqlDbType.NVarChar, 50);
            SaveParam[19].Value = pcNameWhoAdded;

            SaveParam[20] = new SqlParameter("@SaleBillWhoAdded", SqlDbType.Int);
            SaveParam[20].Value = saleWhoAdded;

            SaveParam[21] = new SqlParameter("@SaleBillDate", SqlDbType.NVarChar, 50);
            SaveParam[21].Value = saleDate;

            SaveParam[22] = new SqlParameter("@SaleBillTime", SqlDbType.NVarChar, 50);
            SaveParam[22].Value = saleTime;


            //Execute Command Insert into Table Branches by DAL.CLS_ConnectionDB
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_SaleBillEdit]", SaveParam);
        }

        /// <summary>
        /// Method To Delete Record From SaleBill Table
        /// </summary>
        /// <param name="saleID">saleID</param>
        public void DeleteSaleBill(int saleID)
        {
            //Create new instance from SqlParameter[]
            SqlParameter[] DeleteParam = new SqlParameter[1];

            DeleteParam[0] = new SqlParameter("@SaleBillID", SqlDbType.Int);
            DeleteParam[0].Value = saleID;

            //Execute Command To Delete Record from SaleBill Table
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_SaleBillDelete]", DeleteParam);

        }

        /// <summary>
        /// Method To Update SaleBill Table by Modify SaleBillStatus Only (Deactivate SaleBill)
        /// </summary>
        /// <param name="saleID">saleID</param>
        /// <param name="saleStatus">saleStatus</param>
        /// <param name="pcNameWhoDeleted">pcNameWhoDeleted</param>
        /// <param name="saleWhoDeleted">saleWhoDeleted</param>
        public void DeactivatesaleBill(int saleID, bool saleStatus, string pcNameWhoDeleted, int saleWhoDeleted)
        {
            //Create New Instance From SqlParameter [] array
            SqlParameter[] DeleteParam = new SqlParameter[4];

            DeleteParam[0] = new SqlParameter("@SaleBillID", SqlDbType.Int);
            DeleteParam[0].Value = saleID;

            DeleteParam[1] = new SqlParameter("@SaleBillStatus", SqlDbType.Bit);
            DeleteParam[1].Value = saleStatus;

            DeleteParam[2] = new SqlParameter("@PcNameWhoDeleted", SqlDbType.NVarChar, 50);
            DeleteParam[2].Value = pcNameWhoDeleted;

            DeleteParam[3] = new SqlParameter("@SaleBillWhoDeleted", SqlDbType.Int);
            DeleteParam[3].Value = saleWhoDeleted;

            //Execute Command to Update SaleBill table by In Activate SaleBill
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_SaleBillDeactivate]", DeleteParam);
        }


        /// <summary>
        /// Method To Update saleBill Table 
        /// </summary>
        /// <param name="saleID">saleID</param>
        /// <param name="saleSupplier">saleSupplier</param>
        /// <param name="saleSupplierNo">saleSupplierNo</param>
        /// <param name="salePayType">salePayType</param>
        /// <param name="saleStore">saleStore</param>
        /// <param name="saleBranch">saleBranch</param>
        /// <param name="saleNotes">saleNotes</param>
        /// <param name="saleInvoiceDate">saleInvoiceDate</param>
        /// <param name="saleTotalSaleAmount">saleTotalSaleAmount</param>
        /// <param name="saleTotalsaleAmount">saleTotalsaleAmount</param>
        /// <param name="saleItemCount">saleItemCount</param>
        /// <param name="saleTotalEarn">saleTotalEarn</param>
        /// <param name="saleTotalTax">saleTotalTax</param>
        /// <param name="saleTotalDiscound">saleTotalDiscound</param>
        /// <param name="saleTotalExpenses">saleTotalExpenses</param>
        /// <param name="saleTotalAmount">saleTotalAmount</param>
        /// <param name="saleTotalPaid">saleTotalPaid</param>
        /// <param name="saleTotalRemain">saleTotalRemain</param>
        /// <param name="pcNameWhoModified">pcNameWhoModified</param>
        /// <param name="saleWhoModified">saleWhoModified</param>
        public void UpdatesaleBill(int saleID, int saleCustomer, string salePayType,
                                  int saleStore, int saleBranch, string saleNotes, string saleInvoiceDate, decimal saleTotalSaleAmount,
                                  decimal saleNetSaleAmount, decimal saleTotalBuyAmount, int saleItemCount, decimal saleTotalEarn, decimal saleTotalTax,
                                  decimal saleTotalDiscound, decimal saleTotalExpenses, decimal saleTotalAmount,
                                  decimal saleTotalPaid, decimal saleTotalRemain, string pcNameWhoModified, int saleWhoModified)
        {

            //Create New Instance From SqlParameter[]
            SqlParameter[] UpdateParam = new SqlParameter[20];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            UpdateParam[0] = new SqlParameter("@SaleBillID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[0].Value = saleID;

            UpdateParam[1] = new SqlParameter("@SaleBillCustomer", SqlDbType.Int);
            UpdateParam[1].Value = saleCustomer;

            UpdateParam[2] = new SqlParameter("@SaleBillPayType", SqlDbType.NVarChar, 50);
            UpdateParam[2].Value = salePayType;

            UpdateParam[3] = new SqlParameter("@SaleBillStore", SqlDbType.Int);
            UpdateParam[3].Value = saleStore;

            UpdateParam[4] = new SqlParameter("@SaleBillBranch", SqlDbType.Int);
            UpdateParam[4].Value = saleBranch;

            UpdateParam[5] = new SqlParameter("@SaleBillNotes", SqlDbType.NVarChar, 100);
            UpdateParam[5].Value = saleNotes;

            UpdateParam[6] = new SqlParameter("@SaleBillINVDate", SqlDbType.NVarChar, 50);
            UpdateParam[6].Value = saleInvoiceDate;

            UpdateParam[7] = new SqlParameter("@SaleBillTotalSaleAmount", SqlDbType.Decimal);
            UpdateParam[7].Value = saleTotalSaleAmount;

            UpdateParam[8] = new SqlParameter("@SaleBillNetSaleAmount", SqlDbType.Decimal);
            UpdateParam[8].Value = saleNetSaleAmount;

            UpdateParam[9] = new SqlParameter("@SaleBillTotalBuyAmount", SqlDbType.Decimal);
            UpdateParam[9].Value = saleTotalBuyAmount;

            UpdateParam[10] = new SqlParameter("@SaleBillItemCount", SqlDbType.Int);
            UpdateParam[10].Value = saleItemCount;

            UpdateParam[11] = new SqlParameter("@SaleBillTotalEarn", SqlDbType.Decimal);
            UpdateParam[11].Value = saleTotalEarn;

            UpdateParam[12] = new SqlParameter("@SaleBillTotalTax", SqlDbType.Decimal);
            UpdateParam[12].Value = saleTotalTax;

            UpdateParam[13] = new SqlParameter("@SaleBillTotalDiscound", SqlDbType.Decimal);
            UpdateParam[13].Value = saleTotalDiscound;

            UpdateParam[14] = new SqlParameter("@SaleBillTotalExpenses", SqlDbType.Decimal);
            UpdateParam[14].Value = saleTotalExpenses;

            UpdateParam[15] = new SqlParameter("@SaleBillTotalAmount", SqlDbType.Decimal);
            UpdateParam[15].Value = saleTotalAmount;

            UpdateParam[16] = new SqlParameter("@SaleBillTotalPaid", SqlDbType.Decimal);
            UpdateParam[16].Value = saleTotalPaid;

            UpdateParam[17] = new SqlParameter("@SaleBillTotalRemain", SqlDbType.Decimal);
            UpdateParam[17].Value = saleTotalRemain;

            UpdateParam[18] = new SqlParameter("@PcNameWhoModified", SqlDbType.NVarChar, 50);
            UpdateParam[18].Value = pcNameWhoModified;

            UpdateParam[19] = new SqlParameter("@SaleBillWhoModified", SqlDbType.Int);
            UpdateParam[19].Value = saleWhoModified;

            //Execute Command to Update any Record of saleBillUpdate Table by saleBillUpdate
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_SaleBillUpdate]", UpdateParam);
        }

        /// <summary>
        /// DataTable Function To Advanced Search in saleBill Table 
        /// Recieve Five Parameters Column Name and Search Key and CheckSearchDate and Date1 and Date2
        /// Two Ways To Search Indentical (=) and Not Indentical (LIKE '%'+ @searchKey + '%';)
        /// </summary>
        /// <param name="ColumnName">ColumnName</param>
        /// <param name="SearchKey">SearchKey</param>
        /// <param name="checkDate">checkDate</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <returns>DataTable Of saleBill Table</returns>
        public DataTable SearchSaleBill(string columnName, string searchKey, bool checkDate, string startDate, string endDate)
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

            //Return DataTable which like search key //SP_saleBillSearch
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_SaleBillTotalSearch]", SearchParam);
        }
    }
}
