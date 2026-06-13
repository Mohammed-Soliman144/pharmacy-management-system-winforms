using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //To Deal With DataTables and DataSet
using System.Data.SqlClient; //To Deal With SQL Server Databases and SqlParameter

namespace PharmacySystemV20._0._1.BAL
{
    class CLS_ItemOperations
    {
        //Create new Instance From Singleton Class CLS_ConnectionDB() DataAccessLayer
        readonly DAL.CLS_ConnectionDB Connection = DAL.CLS_ConnectionDB.NewInstance();

        /// <summary>
        /// DataTable Function to Select All Records From ItemOperations Table
        /// </summary>
        /// <returns>Items Table</returns>
        public DataTable ShowItemOperationTable()
        {
            /*Use DataTable Function from DAL.CLS_ConnectionDB to Select All Columns From Items Table
             * no any StoredProcedur Parameters in StoredProcedure so Initialize null value
             * Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
             */
            // return Connection.SelectData("[PharmacyDB].[dbo].[SP_ItemOperShow]", null);
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_ItemOperShow]", null);
        }

        /// <summary>
        /// Int Function to generate ItemOperation ID
        /// </summary>
        /// <returns>ItemID</returns>
        public int GenerateItemOperationID()
        {
            //return ItemOperationID
            //Initialize return value of DataTable Function From DAL Connection.SelectData("storedProcedureName",SqlParameter[])
            //Assignment the value from DataTable Function After Convert.ToInt32(Connection.SelectData("[DatabaseName].[dbo].[StoredProcedureName]", null).Rows[0][0].ToString())
            return Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastItemOperID]", null).Rows[0][0].ToString()); ;
        }


        /// <summary>
        /// Method To Add New Item to Item Operations Table Database
        /// </summary>
        /// <param name="itemOperID">itemOperID</param>
        /// <param name="itemOperName">itemOperName</param>
        /// <param name="itemOperBuyID">itemOperBuyID</param>
        /// <param name="itemOperReBuyID">itemOperReBuyID</param>
        /// <param name="itemOperSaleID">itemOperSaleID</param>
        /// <param name="itemOperReSaleID">itemOperReSaleID</param>
        /// <param name="itemOperCustomerID">itemOperCustomerID</param>
        /// <param name="itemOperSupplierID">itemOperSupplierID</param>
        /// <param name="itemOperBranchID">itemOperBranchID</param>
        /// <param name="itemOperStoreID">itemOperStoreID</param>
        /// <param name="itemOperItemID">itemOperItemID</param>
        /// <param name="itemOperItemName">itemOperItemName</param>
        /// <param name="itemOperItemBalance">itemOperItemBalance</param>
        /// <param name="itemOperQtyLarge">itemOperQtyLarge</param>
        /// <param name="itemOperQtyMedium">itemOperQtyMedium</param>
        /// <param name="itemOperQtySmall">itemOperQtySmall</param>
        /// <param name="itemOperExpiryDate">itemOperExpiryDate</param>
        /// <param name="itemOperQtyExpiry">itemOperQtyExpiry</param>
        /// <param name="itemOperSalePrc">itemOperSalePrc</param>
        /// <param name="itemOperNetSalePrc">itemOperNetSalePrc</param>
        /// <param name="itemOperTotalSalePrc">itemOperTotalSalePrc</param>
        /// <param name="itemOperTotalNetSalePrc">itemOperTotalNetSalePrc</param>
        /// <param name="itemOperBuyPrc">itemOperBuyPrc</param>
        /// <param name="itemOperTotalBuyPrc">itemOperTotalBuyPrc</param>
        /// <param name="itemOperDiscound">itemOperDiscound</param>
        /// <param name="itemOperEarn">itemOperEarn</param>
        /// <param name="itemOperTotalEarn">itemOperTotalEarn</param>
        /// <param name="itemOperTax">itemOperTax</param>
        /// <param name="itemOperTotalTax">itemOperTotalTax</param>
        /// <param name="itemOperNotes">itemOperNotes</param>
        /// <param name="pcNameWhoAdded">pcNameWhoAdded</param>
        /// <param name="itemOperWhoAdded">itemOperWhoAdded</param>
        /// <param name="itemOperDate">itemOperDate</param>
        /// <param name="itemOperTime">itemOperTime</param>
        public void SaveItemOperation(  int itemOperID, string itemOperName, int itemOperBuyID, int itemOperReBuyID, int itemOperSaleID,
                                        int itemOperReSaleID, int itemOperCustomerID, int itemOperSupplierID, int itemOperBranchID,
                                        int itemOperStoreID, int itemOperItemID, string itemOperItemName, decimal itemOperItemBalance,
                                        decimal itemOperQtyLarge, decimal itemOperQtyMedium, decimal itemOperQtySmall, string itemOperExpiryDate,
                                        decimal itemOperQtyExpiry, decimal itemOperSalePrc, decimal itemOperNetSalePrc, decimal itemOperTotalSalePrc,
                                        decimal itemOperTotalNetSalePrc, decimal itemOperBuyPrc, decimal itemOperTotalBuyPrc, decimal itemOperDiscound,
                                        decimal itemOperEarn, decimal itemOperTotalEarn, decimal itemOperTax, decimal itemOperTotalTax, 
                                        string itemOperNotes,string pcNameWhoAdded, int itemOperWhoAdded,
                                        string itemOperDate, string itemOperTime)
        {
            //Create New Instance From SqlParameter[] which length of it is equal counter of storedprocedureparameter
            SqlParameter[] SaveParam = new SqlParameter[34];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            SaveParam[0] = new SqlParameter("@OperID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[0].Value = itemOperID;

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            SaveParam[1] = new SqlParameter("@OperName", SqlDbType.NVarChar, 50);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[1].Value = itemOperName;

            SaveParam[2] = new SqlParameter("@OperBuyID", SqlDbType.Int);
            SaveParam[2].Value = itemOperBuyID;

            SaveParam[3] = new SqlParameter("@OperReBuyID", SqlDbType.Int);
            SaveParam[3].Value = itemOperReBuyID;

            SaveParam[4] = new SqlParameter("@OperSaleID", SqlDbType.Int);
            SaveParam[4].Value = itemOperSaleID;

            SaveParam[5] = new SqlParameter("@OperReSaleID", SqlDbType.Int);
            SaveParam[5].Value = itemOperReSaleID;

            SaveParam[6] = new SqlParameter("@OperSupplierID", SqlDbType.Int);
            SaveParam[6].Value = itemOperSupplierID;

            SaveParam[7] = new SqlParameter("@OperCustomerID", SqlDbType.Int);
            SaveParam[7].Value = itemOperCustomerID;

            SaveParam[8] = new SqlParameter("@OperBranchID", SqlDbType.Int);
            SaveParam[8].Value = itemOperBranchID;

            SaveParam[9] = new SqlParameter("@OperStoreID", SqlDbType.Int);
            SaveParam[9].Value = itemOperStoreID;

            SaveParam[10] = new SqlParameter("@OperItemID", SqlDbType.Int);
            SaveParam[10].Value = itemOperItemID;

            SaveParam[11] = new SqlParameter("@OperItemName", SqlDbType.NVarChar, 50);
            SaveParam[11].Value = itemOperItemName;

            SaveParam[12] = new SqlParameter("@OperItemBalance", SqlDbType.Decimal);
            SaveParam[12].Value = itemOperItemBalance;

            SaveParam[13] = new SqlParameter("@OperItemQtyLarge", SqlDbType.Decimal);
            SaveParam[13].Value = itemOperQtyLarge;

            SaveParam[14] = new SqlParameter("@OperItemQtyMedium", SqlDbType.Decimal);
            SaveParam[14].Value = itemOperQtyMedium;

            SaveParam[15] = new SqlParameter("@OperItemQtySmall", SqlDbType.Decimal);
            SaveParam[15].Value = itemOperQtySmall;

            SaveParam[16] = new SqlParameter("@OperItemExpiry", SqlDbType.NVarChar, 50);
            SaveParam[16].Value = itemOperExpiryDate;

            SaveParam[17] = new SqlParameter("@OperItemQtyExpiry", SqlDbType.Decimal);
            SaveParam[17].Value = itemOperQtyExpiry;

            SaveParam[18] = new SqlParameter("@OperItemSalePrice", SqlDbType.Decimal);
            SaveParam[18].Value = itemOperSalePrc;

            SaveParam[19] = new SqlParameter("@OperItemNetSalePrice", SqlDbType.Decimal);
            SaveParam[19].Value = itemOperNetSalePrc;

            SaveParam[20] = new SqlParameter("@OperItemTotalSalePrice", SqlDbType.Decimal);
            SaveParam[20].Value = itemOperTotalSalePrc;

            SaveParam[21] = new SqlParameter("@OperItemTotalNetSalePrice", SqlDbType.Decimal);
            SaveParam[21].Value = itemOperTotalNetSalePrc;

            SaveParam[22] = new SqlParameter("@OperItemBuyPrice", SqlDbType.Decimal);
            SaveParam[22].Value = itemOperBuyPrc;

            SaveParam[23] = new SqlParameter("@OperItemTotalBuyPrice", SqlDbType.Decimal);
            SaveParam[23].Value = itemOperTotalBuyPrc;

            SaveParam[24] = new SqlParameter("@OperItemDiscound", SqlDbType.Decimal);
            SaveParam[24].Value = itemOperDiscound;

            SaveParam[25] = new SqlParameter("@OperItemEarn", SqlDbType.Decimal);
            SaveParam[25].Value = itemOperEarn;

            SaveParam[26] = new SqlParameter("@OperItemTotalEarn", SqlDbType.Decimal);
            SaveParam[26].Value = itemOperTotalEarn;

            SaveParam[27] = new SqlParameter("@OperItemTax", SqlDbType.Decimal);
            SaveParam[27].Value = itemOperTax;

            SaveParam[28] = new SqlParameter("@OperItemTotalTax", SqlDbType.Decimal);
            SaveParam[28].Value = itemOperTotalTax;

            SaveParam[29] = new SqlParameter("@OperItemNotes", SqlDbType.NVarChar, 50);
            SaveParam[29].Value = itemOperNotes;

            SaveParam[30] = new SqlParameter("@PcNameWhoAdded", SqlDbType.NVarChar, 50);
            SaveParam[30].Value = pcNameWhoAdded;

            SaveParam[31] = new SqlParameter("@ItemOperWhoAdded", SqlDbType.Int);
            SaveParam[31].Value = itemOperWhoAdded;

            SaveParam[32] = new SqlParameter("@ItemOperDate", SqlDbType.NVarChar, 50);
            SaveParam[32].Value = itemOperDate;

            SaveParam[33] = new SqlParameter("@ItemOperTime", SqlDbType.NVarChar, 50);
            SaveParam[33].Value = itemOperTime;


            //Execute Command Insert into Table Item Operations by DAL.CLS_ConnectionDB
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemOperEdit]", SaveParam);
        }


        /// <summary>
        /// Method To Delete Record From Item Operations Table
        /// </summary>
        /// <param name="itemOperID">itemOperID</param>
        public void DeleteItemOperation(int itemOperID)
        {
            //Create new instance from SqlParameter[]
            SqlParameter[] DeleteParam = new SqlParameter[1];

            DeleteParam[0] = new SqlParameter("@OperID", SqlDbType.Int);
            DeleteParam[0].Value = itemOperID;

            //Execute Command To Delete Record from Item Operations Table
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemOperDelete]", DeleteParam);

        }

        /// <summary>
        /// Method To Update Item Operations Table by Modify itemOperStatus Only (Deactivate Item)
        /// </summary>
        /// <param name="itemOperID">itemOperID</param>
        /// <param name="itemOperStatus">itemOperStatus</param>
        /// <param name="pcNameWhoDeleted">pcNameWhoDeleted</param>
        /// <param name="itemOperWhoDeleted">itemOperWhoDeleted</param>
        public void DeactivateItemOperation(int itemOperID, bool itemOperStatus, string pcNameWhoDeleted, int itemOperWhoDeleted)
        {
            //Create New Instance From SqlParameter [] array
            SqlParameter[] DeleteParam = new SqlParameter[4];

            DeleteParam[0] = new SqlParameter("@OperID", SqlDbType.Int);
            DeleteParam[0].Value = itemOperID;

            DeleteParam[1] = new SqlParameter("@OperStatus", SqlDbType.Bit);
            DeleteParam[1].Value = itemOperStatus;

            DeleteParam[2] = new SqlParameter("@PcNameWhoDeleted", SqlDbType.NVarChar, 50);
            DeleteParam[2].Value = pcNameWhoDeleted;

            DeleteParam[3] = new SqlParameter("@ItemOperWhoDeleted", SqlDbType.Int);
            DeleteParam[3].Value = itemOperWhoDeleted;

            //Execute Command to Update StoreS table by In Activate Item Operations
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemOperDeactivate]", DeleteParam);
        }

        /// <summary>
        /// Method To Update Item Operations Table 
        /// </summary>
        /// <param name="itemOperID">itemOperID</param>
        /// <param name="itemOperName">itemOperName</param>
        /// <param name="itemOperBuyID">itemOperBuyID</param>
        /// <param name="itemOperReBuyID">itemOperReBuyID</param>
        /// <param name="itemOperSaleID">itemOperSaleID</param>
        /// <param name="itemOperReSaleID">itemOperReSaleID</param>
        /// <param name="itemOperCustomerID">itemOperCustomerID</param>
        /// <param name="itemOperSupplierID">itemOperSupplierID</param>
        /// <param name="itemOperBranchID">itemOperBranchID</param>
        /// <param name="itemOperStoreID">itemOperStoreID</param>
        /// <param name="itemOperItemID">itemOperItemID</param>
        /// <param name="itemOperItemName">itemOperItemName</param>
        /// <param name="itemOperItemBalance">itemOperItemBalance</param>
        /// <param name="itemOperQtyLarge">itemOperQtyLarge</param>
        /// <param name="itemOperQtyMedium">itemOperQtyMedium</param>
        /// <param name="itemOperQtySmall">itemOperQtySmall</param>
        /// <param name="itemOperExpiryDate">itemOperExpiryDate</param>
        /// <param name="itemOperQtyExpiry">itemOperQtyExpiry</param>
        /// <param name="itemOperSalePrc">itemOperSalePrc</param>
        /// <param name="itemOperNetSalePrc">itemOperNetSalePrc</param>
        /// <param name="itemOperTotalSalePrc">itemOperTotalSalePrc</param>
        /// <param name="itemOperTotalNetSalePrc">itemOperTotalNetSalePrc</param>
        /// <param name="itemOperBuyPrc">itemOperBuyPrc</param>
        /// <param name="itemOperTotalBuyPrc">itemOperTotalBuyPrc</param>
        /// <param name="itemOperDiscound">itemOperDiscound</param>
        /// <param name="itemOperEarn">itemOperEarn</param>
        /// <param name="itemOperTotalEarn">itemOperTotalEarn</param>
        /// <param name="itemOperTax">itemOperTax</param>
        /// <param name="itemOperTotalTax">itemOperTotalTax</param>
        /// <param name="itemOperNotes">itemOperNotes</param>
        /// <param name="pcNameWhoModified">pcNameWhoModified</param>
        /// <param name="itemOperWhoModified">itemOperWhoModified</param>
        public void UpdateItemOperation(int itemOperID, string itemOperName, int itemOperBuyID, int itemOperReBuyID, int itemOperSaleID,
                                        int itemOperReSaleID, int itemOperCustomerID, int itemOperSupplierID, int itemOperBranchID,
                                        int itemOperStoreID, int itemOperItemID, string itemOperItemName, decimal itemOperItemBalance,
                                        decimal itemOperQtyLarge, decimal itemOperQtyMedium, decimal itemOperQtySmall, string itemOperExpiryDate,
                                        decimal itemOperQtyExpiry, decimal itemOperSalePrc, decimal itemOperNetSalePrc, decimal itemOperTotalSalePrc,
                                        decimal itemOperTotalNetSalePrc, decimal itemOperBuyPrc, decimal itemOperTotalBuyPrc, decimal itemOperDiscound,
                                        decimal itemOperEarn, decimal itemOperTotalEarn, decimal itemOperTax, decimal itemOperTotalTax,
                                        string itemOperNotes, string pcNameWhoModified, int itemOperWhoModified)
        {

            //Create New Instance From SqlParameter[]
            SqlParameter[] UpdateParam = new SqlParameter[32];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            UpdateParam[0] = new SqlParameter("@OperID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[0].Value = itemOperID;

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            UpdateParam[1] = new SqlParameter("@OperName", SqlDbType.NVarChar, 50);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[1].Value = itemOperName;

            UpdateParam[2] = new SqlParameter("@OperBuyID", SqlDbType.Int);
            UpdateParam[2].Value = itemOperBuyID;

            UpdateParam[3] = new SqlParameter("@OperReBuyID", SqlDbType.Int);
            UpdateParam[3].Value = itemOperReBuyID;

            UpdateParam[4] = new SqlParameter("@OperSaleID", SqlDbType.Int);
            UpdateParam[4].Value = itemOperSaleID;

            UpdateParam[5] = new SqlParameter("@OperReSaleID", SqlDbType.Int);
            UpdateParam[5].Value = itemOperReSaleID;

            UpdateParam[6] = new SqlParameter("@OperSupplierID", SqlDbType.Int);
            UpdateParam[6].Value = itemOperSupplierID;

            UpdateParam[7] = new SqlParameter("@OperCustomerID", SqlDbType.Int);
            UpdateParam[7].Value = itemOperCustomerID;

            UpdateParam[8] = new SqlParameter("@OperBranchID", SqlDbType.Int);
            UpdateParam[8].Value = itemOperBranchID;

            UpdateParam[9] = new SqlParameter("@OperStoreID", SqlDbType.Int);
            UpdateParam[9].Value = itemOperStoreID;

            UpdateParam[10] = new SqlParameter("@OperItemID", SqlDbType.Int);
            UpdateParam[10].Value = itemOperItemID;

            UpdateParam[11] = new SqlParameter("@OperItemName", SqlDbType.NVarChar, 50);
            UpdateParam[11].Value = itemOperItemName;

            UpdateParam[12] = new SqlParameter("@OperItemBalance", SqlDbType.Decimal);
            UpdateParam[12].Value = itemOperItemBalance;

            UpdateParam[13] = new SqlParameter("@OperItemQtyLarge", SqlDbType.Decimal);
            UpdateParam[13].Value = itemOperQtyLarge;

            UpdateParam[14] = new SqlParameter("@OperItemQtyMedium", SqlDbType.Decimal);
            UpdateParam[14].Value = itemOperQtyMedium;

            UpdateParam[15] = new SqlParameter("@OperItemQtySmall", SqlDbType.Decimal);
            UpdateParam[15].Value = itemOperQtySmall;

            UpdateParam[16] = new SqlParameter("@OperItemExpiry", SqlDbType.NVarChar, 50);
            UpdateParam[16].Value = itemOperExpiryDate;

            UpdateParam[17] = new SqlParameter("@OperItemQtyExpiry", SqlDbType.Decimal);
            UpdateParam[17].Value = itemOperQtyExpiry;

            UpdateParam[18] = new SqlParameter("@OperItemSalePrice", SqlDbType.Decimal);
            UpdateParam[18].Value = itemOperSalePrc;

            UpdateParam[19] = new SqlParameter("@OperItemNetSalePrice", SqlDbType.Decimal);
            UpdateParam[19].Value = itemOperNetSalePrc;

            UpdateParam[20] = new SqlParameter("@OperItemTotalSalePrice", SqlDbType.Decimal);
            UpdateParam[20].Value = itemOperTotalSalePrc;

            UpdateParam[21] = new SqlParameter("@OperItemTotalNetSalePrice", SqlDbType.Decimal);
            UpdateParam[21].Value = itemOperTotalNetSalePrc;

            UpdateParam[22] = new SqlParameter("@OperItemBuyPrice", SqlDbType.Decimal);
            UpdateParam[22].Value = itemOperBuyPrc;

            UpdateParam[23] = new SqlParameter("@OperItemTotalBuyPrice", SqlDbType.Decimal);
            UpdateParam[23].Value = itemOperTotalBuyPrc;

            UpdateParam[24] = new SqlParameter("@OperItemDiscound", SqlDbType.Decimal);
            UpdateParam[24].Value = itemOperDiscound;

            UpdateParam[25] = new SqlParameter("@OperItemEarn", SqlDbType.Decimal);
            UpdateParam[25].Value = itemOperEarn;

            UpdateParam[26] = new SqlParameter("@OperItemTotalEarn", SqlDbType.Decimal);
            UpdateParam[26].Value = itemOperTotalEarn;

            UpdateParam[27] = new SqlParameter("@OperItemTax", SqlDbType.Decimal);
            UpdateParam[27].Value = itemOperTax;

            UpdateParam[28] = new SqlParameter("@OperItemTotalTax", SqlDbType.Decimal);
            UpdateParam[28].Value = itemOperTotalTax;

            UpdateParam[29] = new SqlParameter("@OperItemNotes", SqlDbType.NVarChar, 50);
            UpdateParam[29].Value = itemOperNotes;

            UpdateParam[30] = new SqlParameter("@PcNameWhoAdded", SqlDbType.NVarChar, 50);
            UpdateParam[30].Value = pcNameWhoModified;

            UpdateParam[31] = new SqlParameter("@ItemOperWhoAdded", SqlDbType.Int);
            UpdateParam[31].Value = itemOperWhoModified;


            //Execute Command to Update any Record of Items Table by Item Operations ID
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemOperUpdate]", UpdateParam);
        }


        /// <summary>
        /// DataTable Function To Advanced Search in Item Operations Table
        /// Recieve Two Parameters Column Name and Search Key
        /// Two Ways To Search Indentical (=) and Not Indentical (LIKE '%'+ @searchKey + '%';)
        /// </summary>
        /// <param name="ColumnName">ColumnName</param>
        /// <param name="SearchKey">SearchKey</param>
        /// <returns>DataTable</returns>
        public DataTable SearchItemOperation(string columnName, string searchKey)
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
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_ItemOperSearch]", SearchParam);
        }


        /// <summary>
        /// DataTable Function To Advanced Search in Expiry of Item Operations Table
        /// Recieve Two Parameters Column Name and Search Key
        /// Two Ways To Search Indentical (=) and Not Indentical (LIKE '%'+ @searchKey + '%';)
        /// </summary>
        /// <param name="ColumnName">ColumnName refers To Search by ItemID</param>
        /// <param name="SearchKey">SearchKey refers to ItemID of Items</param>
        /// <returns>DataTable</returns>
        public DataTable SearchItemExpiry(string columnName, string searchKey)
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
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_ItemOperExpirySearch]", SearchParam);
        }
    }
}
