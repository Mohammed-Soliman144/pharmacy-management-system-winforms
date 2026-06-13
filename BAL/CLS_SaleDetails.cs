using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data; //To Deal With DataTables and DataSet
using System.Data.SqlClient; //To Deal With SQL Server Databases and SqlParameter

namespace PharmacySystemV20._0._1.BAL
{
    class CLS_SaleDetails
    {
        //Create new Instance From Singleton Class CLS_ConnectionDB() DataAccessLayer
        readonly DAL.CLS_ConnectionDB Connection = DAL.CLS_ConnectionDB.NewInstance();

        /// <summary>
        /// Int Function to generate saleDetails ID
        /// </summary>
        /// <returns>saleDetailID</returns>
        public int GenerateSaleDetailID()
        {
            //Initialize return value of DataTable Function From DAL Connection.SelectData("storedProcedureName",SqlParameter[])
            //Assignment the value from DataTable Function After Convert.ToInt32(Connection.SelectData("[DatabaseName].[dbo].[StoredProcedureName]", null).Rows[0][0])
            //return int saleDetailID
            return Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastSaleDetailID]", null).Rows[0][0]);
        }

        /// <summary>
        /// DataTable Function to Select All Records From saleDetails Table
        /// </summary>
        /// <returns>saleDetails Table</returns>
        public DataTable ShowSaleDetailsTable()
        {
            /*Use DataTable Function from DAL.CLS_ConnectionDB to Select All Columns From saleDetails Table
             * no any StoredProcedur Parameters in StoredProcedure so Initialize null value
             * Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
             */
            // return Connection.SelectData("[PharmacyDB].[dbo].[SP_saleDetailShow]", null);
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_SaleDetailShow]", null);
        }

        /// <summary>
        /// Method To Add New Item to saleDetails Table Database
        /// </summary>
        /// <param name="saleDetailID">saleDetailID</param>
        /// <param name="saleDetailsaleID">saleDetailsaleID</param>
        /// <param name="saleDetailItemID">saleDetailItemID</param>
        /// <param name="saleDetailItemUnit">saleDetailItemUnit</param>
        /// <param name="saleDetailItemBalance">saleDetailItemBalance</param>
        /// <param name="saleStore">saleStore</param>
        /// <param name="saleBranch">saleBranch</param>
        /// <param name="saleNotes">saleNotes</param>
        /// <param name="saleTotalSaleAmount">saleTotalSaleAmount</param>
        /// <param name="saleDetailItemSalePrice">saleDetailItemSalePrice</param>
        /// <param name="saleDetailItemsalePrice">saleDetailItemsalePrice</param>
        /// <param name="saleDetailsaleQuantity">saleDetailsaleQuantity</param>
        /// <param name="saleDetailsaleExpiry">saleDetailsaleExpiry</param>
        /// <param name="saleDetailTotalSale">saleDetailTotalSale</param>
        /// <param name="saleDetailDiscound">saleDetailDiscound</param>
        /// <param name="saleDetailNetSale">saleDetailNetSale</param>
        /// <param name="saleDetailItemTax">saleDetailItemTax</param>
        /// <param name="saleDetailTotalTax">saleDetailTotalTax</param>
        /// <param name="saleDetailUnitEarn">saleDetailUnitEarn</param>
        /// <param name="saleDetailTotalEarn">saleDetailTotalEarn</param>
        /// <param name="saleDetailNotes">saleDetailNotes</param>
        /// <param name="PCNameWhoAdded">PCNameWhoAdded</param>
        /// <param name="saleDetailWhoAdded">saleDetailWhoAdded</param>
        /// <param name="saleDetailDate">saleDetailDate</param>
        /// <param name="saleDetailTime">saleDetailTime</param>
        public void SaveSaleDetail(int saleDetailID, int saleDetailsaleID, int saleDetailItemID, string saleDetailItemUnit, decimal saleDetailItemBalance,
                                  decimal saleDetailItemSalePrice, decimal saleDetailItemNetSalePrice, decimal saleDetailItemBuyPrice, decimal saleDetailsaleQuantity, string saleDetailsaleExpiry,
                                  decimal saleDetailSaleExpiryQty, decimal saleDetailTotalSale, decimal saleDetailNetSale, decimal saleDetailDiscound, decimal saleDetailTotalBuy,
                                  decimal saleDetailUnitTax, decimal saleDetailTotalTax, decimal saleDetailUnitEarn, decimal saleDetailTotalEarn,
                                  string saleDetailNotes, string pcNameWhoAdded, int saleDetailWhoAdded, string saleDetailDate, string saleDetailTime)
        {

            //Create New Instance From SqlParameter[] which length of it is equal counter of storedprocedureparameter
            SqlParameter[] SaveParam = new SqlParameter[24];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            SaveParam[0] = new SqlParameter("@SaleDetailID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[0].Value = saleDetailID;

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            SaveParam[1] = new SqlParameter("@SaleDetailsaleID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[1].Value = saleDetailsaleID;

            SaveParam[2] = new SqlParameter("@SaleDetailItemID", SqlDbType.Int);
            SaveParam[2].Value = saleDetailItemID;

            SaveParam[3] = new SqlParameter("@SaleDetailItemUnit", SqlDbType.NVarChar, 50);
            SaveParam[3].Value = saleDetailItemUnit;

            SaveParam[4] = new SqlParameter("@SaleDetailItemBalance", SqlDbType.Decimal);
            SaveParam[4].Value = saleDetailItemBalance;

            SaveParam[5] = new SqlParameter("@SaleDetailItemSalePrice", SqlDbType.Decimal);
            SaveParam[5].Value = saleDetailItemSalePrice;

            SaveParam[6] = new SqlParameter("@SaleDetailItemNetSalePrice", SqlDbType.Decimal);
            SaveParam[6].Value = saleDetailItemNetSalePrice;

            SaveParam[7] = new SqlParameter("@SaleDetailItemBuyPrice", SqlDbType.Decimal);
            SaveParam[7].Value = saleDetailItemBuyPrice;

            SaveParam[8] = new SqlParameter("@SaleDetailSaleQuantity", SqlDbType.Decimal);
            SaveParam[8].Value = saleDetailsaleQuantity;

            SaveParam[9] = new SqlParameter("@SaleDetailSaleExpiryDate", SqlDbType.NVarChar, 50);
            SaveParam[9].Value = saleDetailsaleExpiry;

            SaveParam[10] = new SqlParameter("@SaleDetailSaleExpiryQty", SqlDbType.Decimal);
            SaveParam[10].Value = saleDetailSaleExpiryQty;

            SaveParam[11] = new SqlParameter("@SaleDetailTotalSale", SqlDbType.Decimal);
            SaveParam[11].Value = saleDetailTotalSale;

            SaveParam[12] = new SqlParameter("@SaleDetailNetSale", SqlDbType.Decimal);
            SaveParam[12].Value = saleDetailNetSale;

            SaveParam[13] = new SqlParameter("@SaleDetailDiscound", SqlDbType.Decimal);
            SaveParam[13].Value = saleDetailDiscound;

            SaveParam[14] = new SqlParameter("@SaleDetailTotalBuy", SqlDbType.Decimal);
            SaveParam[14].Value = saleDetailTotalBuy;

            SaveParam[15] = new SqlParameter("@SaleDetailUnitTax", SqlDbType.Decimal);
            SaveParam[15].Value = saleDetailUnitTax;

            SaveParam[16] = new SqlParameter("@SaleDetailTotalTax", SqlDbType.Decimal);
            SaveParam[16].Value = saleDetailTotalTax;

            SaveParam[17] = new SqlParameter("@SaleDetailUnitEarn", SqlDbType.Decimal);
            SaveParam[17].Value = saleDetailUnitEarn;

            SaveParam[18] = new SqlParameter("@SaleDetailTotalEarn", SqlDbType.Decimal);
            SaveParam[18].Value = saleDetailTotalEarn;

            SaveParam[19] = new SqlParameter("@SaleDetailNotes", SqlDbType.NVarChar, 50); 
            SaveParam[19].Value = saleDetailNotes;

            SaveParam[20] = new SqlParameter("@PCNameWhoAdded", SqlDbType.NVarChar, 50);
            SaveParam[20].Value = pcNameWhoAdded;

            SaveParam[21] = new SqlParameter("@SaleDetailWhoAdded", SqlDbType.Int);
            SaveParam[21].Value = saleDetailWhoAdded;

            SaveParam[22] = new SqlParameter("@SaleDetailDate", SqlDbType.NVarChar, 50);
            SaveParam[22].Value = saleDetailDate;

            SaveParam[23] = new SqlParameter("@SaleDetailTime", SqlDbType.NVarChar, 50);
            SaveParam[23].Value = saleDetailTime;

            //Execute Command Insert into Table Branches by DAL.CLS_ConnectionDB
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_SaleDetailEdit]", SaveParam);
        }

        /// <summary>
        /// Method To Delete Record From saleDetails Table
        /// </summary>
        /// <param name="saleDetailID">saleID</param>
        public void DeleteSaleDetail(int saleDetailID)
        {
            //Create new instance from SqlParameter[]
            SqlParameter[] DeleteParam = new SqlParameter[1];

            DeleteParam[0] = new SqlParameter("@SaleDetailID", SqlDbType.Int);
            DeleteParam[0].Value = saleDetailID;

            //Execute Command To Delete Record from saleDetails Table
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_SaleDetailDelete]", DeleteParam);

        }

        /// <summary>
        /// Method To Update saleDetails Table by Modify saleDetailStatus Only (Deactivate saleDetail)
        /// </summary>
        /// <param name="saleDetailID">saleDetailID</param>
        /// <param name="saleDetailStatus">saleDetailStatus</param>
        /// <param name="pcNameWhoDeleted">pcNameWhoDeleted</param>
        /// <param name="saleDetailWhoDeleted">saleDetailWhoDeleted</param>
        public void DeactivateSaleDetail(int saleDetailID, bool saleDetailStatus, string pcNameWhoDeleted, int saleDetailWhoDeleted)
        {
            //Create New Instance From SqlParameter [] array
            SqlParameter[] DeleteParam = new SqlParameter[4];

            DeleteParam[0] = new SqlParameter("@SaleDetailID", SqlDbType.Int);
            DeleteParam[0].Value = saleDetailID;

            DeleteParam[1] = new SqlParameter("@SaleDetailStatus", SqlDbType.Bit);
            DeleteParam[1].Value = saleDetailStatus;

            DeleteParam[2] = new SqlParameter("@PcNameWhoDeleted", SqlDbType.NVarChar, 50);
            DeleteParam[2].Value = pcNameWhoDeleted;

            DeleteParam[3] = new SqlParameter("@SaleDetailWhoDeleted", SqlDbType.Int);
            DeleteParam[3].Value = saleDetailWhoDeleted;

            //Execute Command to Update saleBill table by In Activate saleBill
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_SaleDetailDeactivate]", DeleteParam);
        }


        /// <summary>
        /// Method To Update saleDetail Table IF Invoice Is Purchases Invoice
        /// </summary>
        /// <param name="saleDetailID">saleDetailID</param>
        /// <param name="saleDetailItemID">saleDetailItemID</param>
        /// <param name="saleDetailItemUnit">saleDetailItemUnit</param>
        /// <param name="saleDetailItemBalance">saleDetailItemBalance</param>
        /// <param name="saleDetailItemSalePrice">saleDetailItemSalePrice</param>
        /// <param name="saleDetailItemNetSalePrice">saleDetailItemNetSalePrice</param>
        /// <param name="saleDetailItemBuyPrice">saleDetailItemBuyPrice</param>
        /// <param name="saleDetailsaleQuantity">saleDetailsaleQuantity</param>
        /// <param name="saleDetailsaleExpiry">saleDetailsaleExpiry</param>
        /// <param name="saleDetailsaleExpiryQty">saleDetailsaleExpiryQty</param>
        /// <param name="saleDetailTotalsale">saleDetailTotalsale</param>
        /// <param name="saleDetailTotalNetSale">saleDetailTotalNetSale</param>
        /// <param name="saleDetailTotalBuy">saleDetailTotalBuy</param>
        /// <param name="saleDetailDiscound">saleDetailDiscound</param>
        /// <param name="saleDetailUnitTax">saleDetailUnitTax</param>
        /// <param name="saleDetailTotalTax">saleDetailTotalTax</param>
        /// <param name="saleDetailUnitEarn">saleDetailUnitEarn</param>
        /// <param name="saleDetailTotalEarn">saleDetailTotalEarn</param>
        /// <param name="saleDetailNotes">saleDetailNotes</param>
        /// <param name="pcNameWhoModified">pcNameWhoModified</param>
        /// <param name="saleDetailWhoModified">saleDetailWhoModified</param>
        public void UpdateSaleDetail(int saleDetailID, int saleDetailItemID, string saleDetailItemUnit, decimal saleDetailItemBalance,
                                     decimal saleDetailItemSalePrice, decimal saleDetailItemNetSalePrice, decimal saleDetailItemBuyPrice, decimal saleDetailsaleQuantity,
                                     string saleDetailsaleExpiry, decimal saleDetailsaleExpiryQty, decimal saleDetailTotalsale, decimal saleDetailTotalNetSale,
                                    decimal saleDetailTotalBuy, decimal saleDetailDiscound, decimal saleDetailUnitTax, decimal saleDetailTotalTax,
                                     decimal saleDetailUnitEarn, decimal saleDetailTotalEarn,
                                    string saleDetailNotes, string pcNameWhoModified, int saleDetailWhoModified)
        {

            //Create New Instance From SqlParameter[]
            SqlParameter[] UpdateParam = new SqlParameter[21];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            UpdateParam[0] = new SqlParameter("@SaleDetailID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[0].Value = saleDetailID;

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            UpdateParam[1] = new SqlParameter("@SaleDetailItemID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[1].Value = saleDetailItemID;

            UpdateParam[2] = new SqlParameter("@SaleDetailItemUnit", SqlDbType.NVarChar, 50);
            UpdateParam[2].Value = saleDetailItemUnit;

            UpdateParam[3] = new SqlParameter("@SaleDetailItemBalance", SqlDbType.Decimal);
            UpdateParam[3].Value = saleDetailItemBalance;

            UpdateParam[4] = new SqlParameter("@SaleDetailItemSalePrice", SqlDbType.Decimal);
            UpdateParam[4].Value = saleDetailItemSalePrice;

            UpdateParam[5] = new SqlParameter("@SaleDetailItemNetSalePrice", SqlDbType.Decimal);
            UpdateParam[5].Value = saleDetailItemNetSalePrice;

            UpdateParam[6] = new SqlParameter("@SaleDetailItemBuyPrice", SqlDbType.Decimal);
            UpdateParam[6].Value = saleDetailItemBuyPrice;

            UpdateParam[7] = new SqlParameter("@SaleDetailSaleQuantity", SqlDbType.Decimal);
            UpdateParam[7].Value = saleDetailsaleQuantity;

            UpdateParam[8] = new SqlParameter("@SaleDetailSaleExpiryDate", SqlDbType.NVarChar, 50);
            UpdateParam[8].Value = saleDetailsaleExpiry;

            UpdateParam[9] = new SqlParameter("@SaleDetailSaleExpiryQty", SqlDbType.Decimal);
            UpdateParam[9].Value = saleDetailsaleExpiryQty;

            UpdateParam[10] = new SqlParameter("@SaleDetailTotalSale", SqlDbType.Decimal);
            UpdateParam[10].Value = saleDetailTotalsale;

            UpdateParam[11] = new SqlParameter("@SaleDetailNetSale", SqlDbType.Decimal);
            UpdateParam[11].Value = saleDetailTotalNetSale;

            UpdateParam[12] = new SqlParameter("@SaleDetailTotalBuy", SqlDbType.Decimal);
            UpdateParam[12].Value = saleDetailTotalBuy;

            UpdateParam[13] = new SqlParameter("@SaleDetailDiscound", SqlDbType.Decimal);
            UpdateParam[13].Value = saleDetailDiscound;

            UpdateParam[14] = new SqlParameter("@SaleDetailUnitTax", SqlDbType.Decimal);
            UpdateParam[14].Value = saleDetailUnitTax;

            UpdateParam[15] = new SqlParameter("@SaleDetailTotalTax", SqlDbType.Decimal);
            UpdateParam[15].Value = saleDetailTotalTax;

            UpdateParam[16] = new SqlParameter("@SaleDetailUnitEarn", SqlDbType.Decimal);
            UpdateParam[16].Value = saleDetailUnitEarn;

            UpdateParam[17] = new SqlParameter("@SaleDetailTotalEarn", SqlDbType.Decimal);
            UpdateParam[17].Value = saleDetailTotalEarn;

            UpdateParam[18] = new SqlParameter("@SaleDetailNotes", SqlDbType.NVarChar, 50);
            UpdateParam[18].Value = saleDetailNotes;

            UpdateParam[19] = new SqlParameter("@PCNameWhoModified", SqlDbType.NVarChar, 50);
            UpdateParam[19].Value = pcNameWhoModified;

            UpdateParam[20] = new SqlParameter("@SaleDetailWhoModified", SqlDbType.Int);
            UpdateParam[20].Value = saleDetailWhoModified;

            //Execute Command to Update any Record of saleDetailUpdate Table by saleDetailUpdate
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_SaleDetailUpdate]", UpdateParam);
        }


        /// <summary>
        /// Method To Update saleDetail Table IF Invoice Is ReSales Invoice
        /// </summary>
        /// <param name="checkResaleItem">checkResaleItem Is true or 1</param>
        /// <param name="saleDetailID">saleDetailID</param>
        /// <param name="saleDetailResaleQty">saleDetailResaleQty</param>
        /// <param name="saleDetailResalePrice">saleDetailResalePrice</param>
        /// <param name="saleDetailResaleTotalsale">saleDetailResaleTotalsale</param>
        /// <param name="saleDetailResaleTotalSale">saleDetailResaleTotalSale</param>
        /// <param name="saleDetailResaleNotes">saleDetailResaleNotes</param>
        /// <param name="pcNameWhoModified">pcNameWhoModified</param>
        /// <param name="saleDetailWhoModified">saleDetailWhoModified</param>
        public void UpdatesaleDetail(bool checkResaleItem, int saleDetailResaleID, int saleDetailID, int saleDetailResaleQty, decimal saleDetailResalePrice,
                                    decimal saleDetailResaleTotalSale, decimal saleDetailResaleTotalBuy,
                                    string saleDetailResaleNotes, string pcNameWhoModified, int saleDetailWhoModified)
        {

            //Create New Instance From SqlParameter[]
            SqlParameter[] UpdateParam = new SqlParameter[10];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            UpdateParam[0] = new SqlParameter("@SaleDetailResaleItem", SqlDbType.Bit);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[0].Value = checkResaleItem;

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            UpdateParam[1] = new SqlParameter("@SaleDetailResaleID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[1].Value = saleDetailResaleID;

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            UpdateParam[2] = new SqlParameter("@SaleDetailID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[2].Value = saleDetailID;

            UpdateParam[3] = new SqlParameter("@SaleDetailResaleQuantity", SqlDbType.Int);
            UpdateParam[3].Value = saleDetailResaleQty;

            UpdateParam[4] = new SqlParameter("@SaleDetailResalePrice", SqlDbType.Decimal);
            UpdateParam[4].Value = saleDetailResalePrice;

            UpdateParam[5] = new SqlParameter("@SaleDetailResaleTotalsale", SqlDbType.Decimal);
            UpdateParam[5].Value = saleDetailResaleTotalSale;

            UpdateParam[6] = new SqlParameter("@SaleDetailReSaleTotalBuy", SqlDbType.Decimal);
            UpdateParam[6].Value = saleDetailResaleTotalBuy;

            UpdateParam[7] = new SqlParameter("@SaleDetailResaleNotes", SqlDbType.NVarChar, 50);
            UpdateParam[7].Value = saleDetailResaleNotes;

            UpdateParam[8] = new SqlParameter("@PCNameWhoModified", SqlDbType.NVarChar, 50);
            UpdateParam[8].Value = pcNameWhoModified;

            UpdateParam[9] = new SqlParameter("@SaleDetailWhoModified", SqlDbType.Int);
            UpdateParam[9].Value = saleDetailWhoModified;

            //Execute Command to Update any Record of saleDetailUpdate Table by saleDetailUpdate
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_SaleDetailResaleUpdate]", UpdateParam);
        }

        /// <summary>
        /// DataTable Function To Advanced Search in saleBillDetails Table 
        /// Recieve Five Parameters Column Name and Search Key and CheckSearchDate and Date1 and Date2
        /// Two Ways To Search Indentical (=) and Not Indentical (LIKE '%'+ @searchKey + '%';)
        /// </summary>
        /// <param name="ColumnName">ColumnName</param>
        /// <param name="SearchKey">SearchKey</param>
        /// <param name="checkDate">checkDate</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <returns>DataTable Of saleBillDetails Table</returns>
        public DataTable SearchSaleBillDetails(string columnName, string searchKey, bool checkDate, string startDate, string endDate)
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
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_SaleBillSearch]", SearchParam);
        }

    }
}
