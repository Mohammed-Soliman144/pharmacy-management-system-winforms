using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //To Deal With DataTables and DataSet
using System.Data.SqlClient; //To Deal With SQL Server Databases and SqlParameter

namespace PharmacySystemV20._0._1.BAL
{
    class CLS_BuyDetails
    {
        //Create new Instance From Singleton Class CLS_ConnectionDB() DataAccessLayer
        readonly DAL.CLS_ConnectionDB Connection = DAL.CLS_ConnectionDB.NewInstance();

        /// <summary>
        /// Int Function to generate BuyDetails ID
        /// </summary>
        /// <returns>BuyDetailID</returns>
        public int GenerateBuyDetailID()
        {
            //Initialize return value of DataTable Function From DAL Connection.SelectData("storedProcedureName",SqlParameter[])
            //Assignment the value from DataTable Function After Convert.ToInt32(Connection.SelectData("[DatabaseName].[dbo].[StoredProcedureName]", null).Rows[0][0])
            //return int BuyDetailID
            return Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastBuyDetailID]", null).Rows[0][0]);
        }

        /// <summary>
        /// DataTable Function to Select All Records From BuyDetails Table
        /// </summary>
        /// <returns>BuyDetails Table</returns>
        public DataTable ShowBuyDetailsTable()
        {
            /*Use DataTable Function from DAL.CLS_ConnectionDB to Select All Columns From BuyDetails Table
             * no any StoredProcedur Parameters in StoredProcedure so Initialize null value
             * Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
             */
            // return Connection.SelectData("[PharmacyDB].[dbo].[SP_BuyDetailShow]", null);
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_BuyDetailShow]", null);
        }

        /// <summary>
        /// Method To Add New Item to BuyDetails Table Database
        /// </summary>
        /// <param name="buyDetailID">buyDetailID</param>
        /// <param name="buyDetailBuyID">buyDetailBuyID</param>
        /// <param name="buyDetailItemID">buyDetailItemID</param>
        /// <param name="buyDetailItemUnit">buyDetailItemUnit</param>
        /// <param name="buyDetailItemBalance">buyDetailItemBalance</param>
        /// <param name="buyStore">buyStore</param>
        /// <param name="buyBranch">buyBranch</param>
        /// <param name="buyNotes">buyNotes</param>
        /// <param name="buyTotalSaleAmount">buyTotalSaleAmount</param>
        /// <param name="buyDetailItemSalePrice">buyDetailItemSalePrice</param>
        /// <param name="buyDetailItemBuyPrice">buyDetailItemBuyPrice</param>
        /// <param name="buyDetailBuyQuantity">buyDetailBuyQuantity</param>
        /// <param name="buyDetailBuyExpiry">buyDetailBuyExpiry</param>
        /// <param name="buyDetailTotalSale">buyDetailTotalSale</param>
        /// <param name="buyDetailDiscound">buyDetailDiscound</param>
        /// <param name="buyDetailTotalBuy">buyDetailTotalBuy</param>
        /// <param name="buyDetailItemTax">buyDetailItemTax</param>
        /// <param name="buyDetailTotalTax">buyDetailTotalTax</param>
        /// <param name="buyDetailUnitEarn">buyDetailUnitEarn</param>
        /// <param name="buyDetailTotalEarn">buyDetailTotalEarn</param>
        /// <param name="buyDetailNotes">buyDetailNotes</param>
        /// <param name="PCNameWhoAdded">PCNameWhoAdded</param>
        /// <param name="buyDetailWhoAdded">buyDetailWhoAdded</param>
        /// <param name="buyDetailDate">buyDetailDate</param>
        /// <param name="buyDetailTime">buyDetailTime</param>
        public void SaveBuyDetail(int buyDetailID, int buyDetailBuyID, int buyDetailItemID, string buyDetailItemUnit, decimal buyDetailItemBalance,
                                  decimal buyDetailItemSalePrice, decimal buyDetailItemBuyPrice, decimal buyDetailBuyQuantity, string buyDetailBuyExpiry,
                                  decimal buyDetailTotalSale, decimal buyDetailDiscound, decimal buyDetailTotalBuy,
                                  decimal buyDetailItemTax, decimal buyDetailTotalTax, decimal buyDetailUnitEarn, decimal buyDetailTotalEarn,
                                  string buyDetailNotes, string pcNameWhoAdded, int buyDetailWhoAdded, string buyDetailDate, string buyDetailTime)
        {

            //Create New Instance From SqlParameter[] which length of it is equal counter of storedprocedureparameter
            SqlParameter[] SaveParam = new SqlParameter[21];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            SaveParam[0] = new SqlParameter("@BuyDetailID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[0].Value = buyDetailID;

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            SaveParam[1] = new SqlParameter("@BuyDetailBuyID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[1].Value = buyDetailBuyID;

            SaveParam[2] = new SqlParameter("@BuyDetailItemID", SqlDbType.Int);
            SaveParam[2].Value = buyDetailItemID;

            SaveParam[3] = new SqlParameter("@BuyDetailItemUnit", SqlDbType.NVarChar, 50);
            SaveParam[3].Value = buyDetailItemUnit;

            SaveParam[4] = new SqlParameter("@BuyDetailItemBalance", SqlDbType.Decimal);
            SaveParam[4].Value = buyDetailItemBalance;

            SaveParam[5] = new SqlParameter("@BuyDetailItemSalePrice", SqlDbType.Decimal);
            SaveParam[5].Value = buyDetailItemSalePrice;

            SaveParam[6] = new SqlParameter("@BuyDetailItemBuyPrice", SqlDbType.Decimal);
            SaveParam[6].Value = buyDetailItemBuyPrice;

            SaveParam[7] = new SqlParameter("@BuyDetailBuyQuantity", SqlDbType.Decimal);
            SaveParam[7].Value = buyDetailBuyQuantity;

            SaveParam[8] = new SqlParameter("@BuyDetailBuyExpiry", SqlDbType.NVarChar, 50);
            SaveParam[8].Value = buyDetailBuyExpiry;

            SaveParam[9] = new SqlParameter("@BuyDetailTotalSale", SqlDbType.Decimal);
            SaveParam[9].Value = buyDetailTotalSale;

            SaveParam[10] = new SqlParameter("@BuyDetailDiscound", SqlDbType.Decimal);
            SaveParam[10].Value = buyDetailDiscound;

            SaveParam[11] = new SqlParameter("@BuyDetailTotalBuy", SqlDbType.Decimal);
            SaveParam[11].Value = buyDetailTotalBuy;

            SaveParam[12] = new SqlParameter("@BuyDetailItemTax", SqlDbType.Decimal);
            SaveParam[12].Value = buyDetailItemTax;

            SaveParam[13] = new SqlParameter("@BuyDetailTotalTax", SqlDbType.Decimal);
            SaveParam[13].Value = buyDetailTotalTax;

            SaveParam[14] = new SqlParameter("@BuyDetailUnitEarn", SqlDbType.Decimal);
            SaveParam[14].Value = buyDetailUnitEarn;

            SaveParam[15] = new SqlParameter("@BuyDetailTotalEarn", SqlDbType.Decimal);
            SaveParam[15].Value = buyDetailTotalEarn;

            SaveParam[16] = new SqlParameter("@BuyDetailNotes", SqlDbType.NVarChar, 50);
            SaveParam[16].Value = buyDetailNotes;

            SaveParam[17] = new SqlParameter("@PCNameWhoAdded", SqlDbType.NVarChar, 50);
            SaveParam[17].Value = pcNameWhoAdded;

            SaveParam[18] = new SqlParameter("@BuyDetailWhoAdded", SqlDbType.Int);
            SaveParam[18].Value = buyDetailWhoAdded;

            SaveParam[19] = new SqlParameter("@BuyDetailDate", SqlDbType.NVarChar, 50);
            SaveParam[19].Value = buyDetailDate;

            SaveParam[20] = new SqlParameter("@BuyDetailTime", SqlDbType.NVarChar, 50);
            SaveParam[20].Value = buyDetailTime;


            //Execute Command Insert into Table Branches by DAL.CLS_ConnectionDB
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_BuyDetailEdit]", SaveParam);
        }

        /// <summary>
        /// Method To Delete Record From BuyDetails Table
        /// </summary>
        /// <param name="buyDetailID">buyID</param>
        public void DeleteBuyDetail(int buyDetailID)
        {
            //Create new instance from SqlParameter[]
            SqlParameter[] DeleteParam = new SqlParameter[1];

            DeleteParam[0] = new SqlParameter("@BuyDetailID", SqlDbType.Int);
            DeleteParam[0].Value = buyDetailID;

            //Execute Command To Delete Record from BuyDetails Table
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_BuyDetailDelete]", DeleteParam);

        }

        /// <summary>
        /// Method To Update BuyDetails Table by Modify BuyDetailStatus Only (Deactivate BuyDetail)
        /// </summary>
        /// <param name="buyDetailID">buyDetailID</param>
        /// <param name="buyDetailStatus">buyDetailStatus</param>
        /// <param name="pcNameWhoDeleted">pcNameWhoDeleted</param>
        /// <param name="buyDetailWhoDeleted">buyDetailWhoDeleted</param>
        public void DeactivateBuyDetail(int buyDetailID, bool buyDetailStatus, string pcNameWhoDeleted, int buyDetailWhoDeleted)
        {
            //Create New Instance From SqlParameter [] array
            SqlParameter[] DeleteParam = new SqlParameter[4];

            DeleteParam[0] = new SqlParameter("@BuyDetailID", SqlDbType.Int);
            DeleteParam[0].Value = buyDetailID;

            DeleteParam[1] = new SqlParameter("@BuyDetailStatus", SqlDbType.Bit);
            DeleteParam[1].Value = buyDetailStatus;

            DeleteParam[2] = new SqlParameter("@PcNameWhoDeleted", SqlDbType.NVarChar, 50);
            DeleteParam[2].Value = pcNameWhoDeleted;

            DeleteParam[3] = new SqlParameter("@BuyDetailWhoDeleted", SqlDbType.Int);
            DeleteParam[3].Value = buyDetailWhoDeleted;

            //Execute Command to Update BuyBill table by In Activate BuyBill
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_BuyDetailDeactivate]", DeleteParam);
        }


        /// <summary>
        /// Method To Update BuyDetail Table IF Invoice Is Purchases Invoice
        /// </summary>
        /// <param name="buyDetailID">buyDetailID</param>
        /// <param name="buyDetailItemID">buyDetailItemID</param>
        /// <param name="buyDetailItemUnit">buyDetailItemUnit</param>
        /// <param name="buyDetailItemBalance">buyDetailItemBalance</param>
        /// <param name="buyDetailItemSalePrice">buyDetailItemSalePrice</param>
        /// <param name="buyDetailItemBuyPrice">buyDetailItemBuyPrice</param>
        /// <param name="buyDetailBuyQuantity">buyDetailBuyQuantity</param>
        /// <param name="buyDetailBuyExpiry">buyDetailBuyExpiry</param>
        /// <param name="buyDetailTotalSale">buyDetailTotalSale</param>
        /// <param name="buyDetailDiscound">buyDetailDiscound</param>
        /// <param name="buyDetailTotalBuy">buyDetailTotalBuy</param>
        /// <param name="buyDetailItemTax">buyDetailItemTax</param>
        /// <param name="buyDetailTotalTax">buyDetailTotalTax</param>
        /// <param name="buyDetailUnitEarn">buyDetailUnitEarn</param>
        /// <param name="buyDetailTotalEarn">buyDetailTotalEarn</param>
        /// <param name="buyDetailNotes">buyDetailNotes</param>
        /// <param name="pcNameWhoModified">pcNameWhoModified</param>
        /// <param name="buyDetailWhoModified">buyDetailWhoModified</param>
        public void UpdateBuyDetail(int buyDetailID, int buyDetailItemID, string buyDetailItemUnit, decimal buyDetailItemBalance, decimal buyDetailItemSalePrice, decimal buyDetailItemBuyPrice, 
                                    decimal buyDetailBuyQuantity, string buyDetailBuyExpiry,
                                    decimal buyDetailTotalSale, decimal buyDetailDiscound, decimal buyDetailTotalBuy,
                                    decimal buyDetailItemTax, decimal buyDetailTotalTax, decimal buyDetailUnitEarn, decimal buyDetailTotalEarn,
                                    string buyDetailNotes, string pcNameWhoModified, int buyDetailWhoModified)
        {
            //Create New Instance From SqlParameter[]
            SqlParameter[] UpdateParam = new SqlParameter[18];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            UpdateParam[0] = new SqlParameter("@BuyDetailID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[0].Value = buyDetailID;

            UpdateParam[1] = new SqlParameter("@BuyDetailItemID", SqlDbType.Int);
            UpdateParam[1].Value = buyDetailItemID;

            UpdateParam[2] = new SqlParameter("@BuyDetailItemUnit", SqlDbType.NVarChar, 50);
            UpdateParam[2].Value = buyDetailItemUnit;

            UpdateParam[3] = new SqlParameter("@BuyDetailItemBalance", SqlDbType.Decimal);
            UpdateParam[3].Value = buyDetailItemBalance;

            UpdateParam[4] = new SqlParameter("@BuyDetailItemSalePrice", SqlDbType.Decimal);
            UpdateParam[4].Value = buyDetailItemSalePrice;

            UpdateParam[5] = new SqlParameter("@BuyDetailItemBuyPrice", SqlDbType.Decimal);
            UpdateParam[5].Value = buyDetailItemBuyPrice;

            UpdateParam[6] = new SqlParameter("@BuyDetailBuyQuantity", SqlDbType.Decimal);
            UpdateParam[6].Value = buyDetailBuyQuantity;

            UpdateParam[7] = new SqlParameter("@BuyDetailBuyExpiry", SqlDbType.NVarChar, 50);
            UpdateParam[7].Value = buyDetailBuyExpiry;

            UpdateParam[8] = new SqlParameter("@BuyDetailTotalSale", SqlDbType.Decimal);
            UpdateParam[8].Value = buyDetailTotalSale;

            UpdateParam[9] = new SqlParameter("@BuyDetailDiscound", SqlDbType.Decimal);
            UpdateParam[9].Value = buyDetailDiscound;

            UpdateParam[10] = new SqlParameter("@BuyDetailTotalBuy", SqlDbType.Decimal);
            UpdateParam[10].Value = buyDetailTotalBuy;

            UpdateParam[11] = new SqlParameter("@BuyDetailItemTax", SqlDbType.Decimal);
            UpdateParam[11].Value = buyDetailItemTax;

            UpdateParam[12] = new SqlParameter("@BuyDetailTotalTax", SqlDbType.Decimal);
            UpdateParam[12].Value = buyDetailTotalTax;

            UpdateParam[13] = new SqlParameter("@BuyDetailUnitEarn", SqlDbType.Decimal);
            UpdateParam[13].Value = buyDetailUnitEarn;

            UpdateParam[14] = new SqlParameter("@BuyDetailTotalEarn", SqlDbType.Decimal);
            UpdateParam[14].Value = buyDetailTotalEarn;

            UpdateParam[15] = new SqlParameter("@BuyDetailNotes", SqlDbType.NVarChar, 50);
            UpdateParam[15].Value = buyDetailNotes;

            UpdateParam[16] = new SqlParameter("@PCNameWhoModified", SqlDbType.NVarChar, 50);
            UpdateParam[16].Value = pcNameWhoModified;

            UpdateParam[17] = new SqlParameter("@BuyDetailWhoModified", SqlDbType.Int);
            UpdateParam[17].Value = buyDetailWhoModified;

            //Execute Command to Update any Record of BuyDetailUpdate Table by BuyDetailUpdate
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_BuyDetailUpdate]", UpdateParam);
        }


        /// <summary>
        /// Method To Update BuyDetail Table IF Invoice Is RePurchases Invoice
        /// </summary>
        /// <param name="checkRebuyItem">checkRebuyItem Is true or 1</param>
        /// <param name="buyDetailID">buyDetailID</param>
        /// <param name="buyDetailRebuyQty">buyDetailRebuyQty</param>
        /// <param name="buyDetailRebuyPrice">buyDetailRebuyPrice</param>
        /// <param name="buyDetailRebuyTotalBuy">buyDetailRebuyTotalBuy</param>
        /// <param name="buyDetailRebuyTotalSale">buyDetailRebuyTotalSale</param>
        /// <param name="buyDetailRebuyNotes">buyDetailRebuyNotes</param>
        /// <param name="pcNameWhoModified">pcNameWhoModified</param>
        /// <param name="buyDetailWhoModified">buyDetailWhoModified</param>
        public void UpdateBuyDetail(bool checkRebuyItem, int buyDetailRebuyID, int buyDetailID, int buyDetailRebuyQty, decimal buyDetailRebuyPrice,
                                    decimal buyDetailRebuyTotalBuy, decimal buyDetailRebuyTotalSale,
                                    string buyDetailRebuyNotes, string pcNameWhoModified, int buyDetailWhoModified)
        {

            //Create New Instance From SqlParameter[]
            SqlParameter[] UpdateParam = new SqlParameter[10];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            UpdateParam[0] = new SqlParameter("@BuyDetailReBuyItem", SqlDbType.Bit);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[0].Value = checkRebuyItem;

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            UpdateParam[1] = new SqlParameter("@BuyDetailReBuyID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[1].Value = buyDetailRebuyID;

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            UpdateParam[2] = new SqlParameter("@BuyDetailID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[2].Value = buyDetailID;

            UpdateParam[3] = new SqlParameter("@BuyDetailReBuyQuantity", SqlDbType.Int);
            UpdateParam[3].Value = buyDetailRebuyQty;

            UpdateParam[4] = new SqlParameter("@BuyDetailReBuyPrice", SqlDbType.Decimal);
            UpdateParam[4].Value = buyDetailRebuyPrice;

            UpdateParam[5] = new SqlParameter("@BuyDetailReBuyTotalBuy", SqlDbType.Decimal);
            UpdateParam[5].Value = buyDetailRebuyTotalBuy;

            UpdateParam[6] = new SqlParameter("@BuyDetailReBuyTotalSale", SqlDbType.Decimal);
            UpdateParam[6].Value = buyDetailRebuyTotalSale;

            UpdateParam[7] = new SqlParameter("@BuyDetailReBuyNotes", SqlDbType.NVarChar, 50);
            UpdateParam[7].Value = buyDetailRebuyNotes;

            UpdateParam[8] = new SqlParameter("@PCNameWhoModified", SqlDbType.NVarChar, 50);
            UpdateParam[8].Value = pcNameWhoModified;

            UpdateParam[9] = new SqlParameter("@BuyDetailWhoModified", SqlDbType.Int);
            UpdateParam[9].Value = buyDetailWhoModified;

            //Execute Command to Update any Record of BuyDetailUpdate Table by BuyDetailUpdate
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_BuyDetailReBuyUpdate]", UpdateParam);
        }
 
        /// <summary>
        /// DataTable Function To Advanced Search in BuyBillDetails Table 
        /// Recieve Five Parameters Column Name and Search Key and CheckSearchDate and Date1 and Date2
        /// Two Ways To Search Indentical (=) and Not Indentical (LIKE '%'+ @searchKey + '%';)
        /// </summary>
        /// <param name="ColumnName">ColumnName</param>
        /// <param name="SearchKey">SearchKey</param>
        /// <param name="checkDate">checkDate</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <returns>DataTable Of BuyBillDetails Table</returns>
        public DataTable SearchBuyBillDetails(string columnName, string searchKey, bool checkDate, string startDate, string endDate)
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
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_BuyBillSearch]", SearchParam);
        }

    }
}
