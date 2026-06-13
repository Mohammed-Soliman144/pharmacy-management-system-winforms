using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //To Deal With DataTables and DataSet
using System.Data.SqlClient; //To Deal With SQL Server Databases and SqlParameter

namespace PharmacySystemV20._0._1.BAL
{
    class CLS_Items
    {
        //Create new Instance From Singleton Class CLS_ConnectionDB() DataAccessLayer
        readonly DAL.CLS_ConnectionDB Connection = DAL.CLS_ConnectionDB.NewInstance();

        /// <summary>
        /// DataTable Function to Select All Records From Items Table
        /// </summary>
        /// <returns>Items Table</returns>
        public DataTable ShowItemsTable()
        {
            /*Use DataTable Function from DAL.CLS_ConnectionDB to Select All Columns From Items Table
             * no any StoredProcedur Parameters in StoredProcedure so Initialize null value
             * Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
             */
            // return Connection.SelectData("[PharmacyDB].[dbo].[SP_ItemShow]", null);
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_ItemShow]", null);
        }

        /// <summary>
        /// Int Function to generate Item ID
        /// </summary>
        /// <returns>ItemID</returns>
        public string GenerateItemID()
        {
            //int ItemID without assignment any value
            int ItemID;

            //Initialize return value of DataTable Function From DAL Connection.SelectData("storedProcedureName",SqlParameter[])
            //Assignment the value from DataTable Function After Convert.ToInt32(Connection.SelectData("[DatabaseName].[dbo].[StoredProcedureName]", null).Rows[0][0].ToString())
            ItemID = Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastItemID]", null).Rows[0][0].ToString());

            //return ItemID.ToString("FormatName-000000");
            return ItemID.ToString("Item-000000");
        }

        /// <summary>
        /// Method To Add New Item to Items Table Database
        /// </summary>
        /// <param name="itemID">itemCode</param>
        /// <param name="itemCode">itemCode</param>
        /// <param name="itemName">itemName</param>
        /// <param name="itemEngName">itemEngName</param>
        /// <param name="itemBarcode1">itemBarcode1</param>
        /// <param name="itemBarcode2">itemBarcode2</param>
        /// <param name="itemBarcode3">itemBarcode3</param>
        /// <param name="itemManuDate">itemManuDate</param>
        /// <param name="itemExpDate">itemExpDate</param>
        /// <param name="itemDosageForm">itemDosageForm</param>
        /// <param name="itemGeneric">itemGeneric</param>
        /// <param name="itemClass">itemClass</param>
        /// <param name="itemGroup">itemGroup</param>
        /// <param name="itemCompany">itemCompany</param>
        /// <param name="itemPlace">itemPlace</param>
        /// <param name="itemLargeUnit">itemLargeUnit</param>
        /// <param name="itemLargeUnitNo">itemLargeUnitNo</param>
        /// <param name="itemLargeSalePrc">itemLargeSalePrc</param>
        /// <param name="itemLargeBuyPrc">itemLargeBuyPrc</param>
        /// <param name="itemLargeQty">itemLargeQty</param>
        /// <param name="itemMediumUnit">itemMediumUnit</param>
        /// <param name="itemMediumUnitNo">itemMediumUnitNo</param>
        /// <param name="itemMediumSalePrc">itemMediumSalePrc</param>
        /// <param name="itemMediumBuyPrc">itemMediumBuyPrc</param>
        /// <param name="itemMediumQty">itemMediumQty</param>
        /// <param name="itemSmallUnit">itemSmallUnit</param>
        /// <param name="itemSmallUnitNo">itemSmallUnitNo</param>
        /// <param name="itemSmallSalePrc">itemSmallSalePrc</param>
        /// <param name="itemSmallBuyPrc">itemSmallBuyPrc</param>
        /// <param name="itemSmallQty">itemSmallQty</param>
        /// <param name="itemMaxDiscound">itemMaxDiscound</param>
        /// <param name="itemDemandLimit">itemDemandLimit</param>
        /// <param name="itemMedicine">itemMedicine</param>
        /// <param name="itemAccessories">itemAccessories</param>
        /// <param name="itemLocal">itemLocal</param>
        /// <param name="itemImport">itemImport</param>
        /// <param name="itemExpiry">itemExpiry</param>
        /// <param name="itemDrug">itemDrug</param>
        /// <param name="itemRefragated">itemRefragated</param>
        /// <param name="itemUncommon">itemUncommon</param>
        /// <param name="pcNameWhoAdded">pcNameWhoAdded</param>
        /// <param name="itemWhoAdded">itemWhoAdded</param>
        /// <param name="itemStatus">itemStatus</param>
        /// <param name="itemDate">itemDate</param>
        /// <param name="itemTime">itemTime</param>
        public void SaveItems  (int itemID,string itemCode, string itemName, string itemEngName, string itemBarcode1, 
                                string itemBarcode2, string itemBarcode3, string itemManuDate, string itemExpDate,
                                int itemDosageForm, int itemGeneric, int itemClass, int itemGroup, int itemCompany,
                                int itemPlace, int itemLargeUnit, int itemLargeUnitNo, decimal itemLargeSalePrc,
                                decimal itemLargeBuyPrc, decimal itemLargeQty, int itemMediumUnit, int itemMediumUnitNo, 
                                decimal itemMediumSalePrc, decimal itemMediumBuyPrc, decimal itemMediumQty, 
                                int itemSmallUnit, int itemSmallUnitNo,decimal itemSmallSalePrc, decimal itemSmallBuyPrc, 
                                decimal itemSmallQty, decimal itemMaxDiscound, decimal itemDemandLimit, 
                                bool itemMedicine, bool itemAccessories, bool itemLocal, bool itemImport,
                                bool itemExpiry, bool itemDrug, bool itemRefragated, bool itemUncommon,
                                string pcNameWhoAdded, int itemWhoAdded, bool itemStatus, 
                                string itemDate, string itemTime)
        {
            //Create New Instance From SqlParameter[] which length of it is equal counter of storedprocedureparameter
            SqlParameter[] SaveParam = new SqlParameter[45];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            SaveParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[0].Value = itemID;

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            SaveParam[1] = new SqlParameter("@ItemCustomCode", SqlDbType.NVarChar, 50);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[1].Value = itemCode;

            SaveParam[2] = new SqlParameter("@ItemName", SqlDbType.NVarChar, 150);
            SaveParam[2].Value = itemName;

            SaveParam[3] = new SqlParameter("@ItemEngName", SqlDbType.NVarChar, 150);
            SaveParam[3].Value = itemEngName;

            SaveParam[4] = new SqlParameter("@ItemBarcode1", SqlDbType.NVarChar, 100);
            SaveParam[4].Value = itemBarcode1;

            SaveParam[5] = new SqlParameter("@ItemBarcode2", SqlDbType.NVarChar, 100);
            SaveParam[5].Value = itemBarcode2;

            SaveParam[6] = new SqlParameter("@ItemBarcode3", SqlDbType.NVarChar, 100);
            SaveParam[6].Value = itemBarcode3;

            SaveParam[7] = new SqlParameter("@ItemManuDate", SqlDbType.NVarChar, 50);
            SaveParam[7].Value = itemManuDate;

            SaveParam[8] = new SqlParameter("@ItemExpDate", SqlDbType.NVarChar, 50);
            SaveParam[8].Value = itemExpDate;

            SaveParam[9] = new SqlParameter("@ItemDosage", SqlDbType.Int);
            SaveParam[9].Value = itemDosageForm;

            SaveParam[10] = new SqlParameter("@ItemGeneric", SqlDbType.Int);
            SaveParam[10].Value = itemGeneric;

            SaveParam[11] = new SqlParameter("@ItemClass", SqlDbType.Int);
            SaveParam[11].Value = itemClass;

            SaveParam[12] = new SqlParameter("@ItemGroup", SqlDbType.Int);
            SaveParam[12].Value = itemGroup;

            SaveParam[13] = new SqlParameter("@ItemCompany", SqlDbType.Int);
            SaveParam[13].Value = itemCompany;

            SaveParam[14] = new SqlParameter("@ItemPlace", SqlDbType.Int);
            SaveParam[14].Value = itemPlace;

            SaveParam[15] = new SqlParameter("@ItemLUnit", SqlDbType.Int);
            SaveParam[15].Value = itemLargeUnit;

            SaveParam[16] = new SqlParameter("@ItemLUnitNo", SqlDbType.Int);
            SaveParam[16].Value = itemLargeUnitNo;

            SaveParam[17] = new SqlParameter("@ItemLUnitSalePRC", SqlDbType.Decimal);
            SaveParam[17].Value = itemLargeSalePrc;

            SaveParam[18] = new SqlParameter("@ItemLUnitBuyPRC", SqlDbType.Decimal);
            SaveParam[18].Value = itemLargeBuyPrc;

            SaveParam[19] = new SqlParameter("@ItemLUnitQTY", SqlDbType.Decimal);
            SaveParam[19].Value = itemLargeQty;

            SaveParam[20] = new SqlParameter("@ItemMUnit", SqlDbType.Int);
            SaveParam[20].Value = itemMediumUnit;

            SaveParam[21] = new SqlParameter("@ItemMUnitNo", SqlDbType.Int);
            SaveParam[21].Value = itemMediumUnitNo;

            SaveParam[22] = new SqlParameter("@ItemMUnitSalePRC", SqlDbType.Decimal);
            SaveParam[22].Value = itemMediumSalePrc;

            SaveParam[23] = new SqlParameter("@ItemMUnitBuyPRC", SqlDbType.Decimal);
            SaveParam[23].Value = itemMediumBuyPrc;

            SaveParam[24] = new SqlParameter("@ItemMUnitQTY", SqlDbType.Decimal);
            SaveParam[24].Value = itemMediumQty;

            SaveParam[25] = new SqlParameter("@ItemSUnit", SqlDbType.Int);
            SaveParam[25].Value = itemSmallUnit;

            SaveParam[26] = new SqlParameter("@ItemSUnitNo", SqlDbType.Int);
            SaveParam[26].Value = itemSmallUnitNo;

            SaveParam[27] = new SqlParameter("@ItemSUnitSalePRC", SqlDbType.Decimal);
            SaveParam[27].Value = itemSmallSalePrc;

            SaveParam[28] = new SqlParameter("@ItemSUnitBuyPRC", SqlDbType.Decimal);
            SaveParam[28].Value = itemSmallBuyPrc;

            SaveParam[29] = new SqlParameter("@ItemSUnitQTY", SqlDbType.Decimal);
            SaveParam[29].Value = itemSmallQty;

            SaveParam[30] = new SqlParameter("@ItemDemandedLimit", SqlDbType.Decimal);
            SaveParam[30].Value = itemDemandLimit;

            SaveParam[31] = new SqlParameter("@ItemMaxDiscound", SqlDbType.Decimal);
            SaveParam[31].Value = itemMaxDiscound;

            SaveParam[32] = new SqlParameter("@ItemMedicine", SqlDbType.Bit);
            SaveParam[32].Value = itemMedicine;

            SaveParam[33] = new SqlParameter("@ItemAccessories", SqlDbType.Bit);
            SaveParam[33].Value = itemAccessories;

            SaveParam[34] = new SqlParameter("@ItemLocal", SqlDbType.Bit);
            SaveParam[34].Value = itemLocal;

            SaveParam[35] = new SqlParameter("@ItemImport", SqlDbType.Bit);
            SaveParam[35].Value = itemImport;

            SaveParam[36] = new SqlParameter("@ItemExpiry", SqlDbType.Bit);
            SaveParam[36].Value = itemExpiry;

            SaveParam[37] = new SqlParameter("@ItemDrug", SqlDbType.Bit);
            SaveParam[37].Value = itemDrug;

            SaveParam[38] = new SqlParameter("@ItemRefragated", SqlDbType.Bit);
            SaveParam[38].Value = itemRefragated;

            SaveParam[39] = new SqlParameter("@ItemUncommon", SqlDbType.Bit);
            SaveParam[39].Value = itemUncommon;

            SaveParam[40] = new SqlParameter("@PcNameAdded", SqlDbType.NVarChar, 50);
            SaveParam[40].Value = pcNameWhoAdded;

            SaveParam[41] = new SqlParameter("@ItemWhoAdded", SqlDbType.Int);
            SaveParam[41].Value = itemWhoAdded;

            SaveParam[42] = new SqlParameter("@ItemStatus", SqlDbType.Bit);
            SaveParam[42].Value = itemStatus;

            SaveParam[43] = new SqlParameter("@Date", SqlDbType.NVarChar, 50);
            SaveParam[43].Value = itemDate;

            SaveParam[44] = new SqlParameter("@Time", SqlDbType.NVarChar, 50);
            SaveParam[44].Value = itemTime;


            //Execute Command Insert into Table Branches by DAL.CLS_ConnectionDB
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemEdit]", SaveParam);
        }

        /// <summary>
        /// Method To Delete Record From Items Table
        /// </summary>
        /// <param name="itemID">itemID</param>
        public void DeleteItems(int itemID)
        {
            //Create new instance from SqlParameter[]
            SqlParameter[] DeleteParam = new SqlParameter[1];

            DeleteParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            DeleteParam[0].Value = itemID;

            //Execute Command To Delete Record from Items Table
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemDelete]", DeleteParam);

        }

        /// <summary>
        /// Method To Update Items Table by Modify itemStatus Only (Deactivate Item)
        /// </summary>
        /// <param name="itemID">itemID</param>
        /// <param name="itemStatus">itemStatus</param>
        /// <param name="pcNameWhoDeleted">pcNameWhoDeleted</param>
        /// <param name="itemWhoDeleted">itemWhoDeleted</param>
        public void DeactivateItems(int itemID, bool itemStatus, string pcNameWhoDeleted, int itemWhoDeleted)
        {
            //Create New Instance From SqlParameter [] array
            SqlParameter[] DeleteParam = new SqlParameter[4];

            DeleteParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            DeleteParam[0].Value = itemID;

            DeleteParam[1] = new SqlParameter("@Status", SqlDbType.Bit);
            DeleteParam[1].Value = itemStatus;

            DeleteParam[2] = new SqlParameter("@PcNameWhoDeleted", SqlDbType.NVarChar, 50);
            DeleteParam[2].Value = pcNameWhoDeleted;

            DeleteParam[3] = new SqlParameter("@ItemWhoDeleted", SqlDbType.Int);
            DeleteParam[3].Value = itemWhoDeleted;

            //Execute Command to Update StoreS table by In Activate Items
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemDeactivate]", DeleteParam);
        }

        /// <summary>
        /// Method To Update Items Table 
        /// </summary>
        /// <param name="itemID">itemID</param>
        /// <param name="itemName">itemName</param>
        /// <param name="itemEngName">itemEngName</param>
        /// <param name="itemBarcode1">itemBarcode1</param>
        /// <param name="itemBarcode2">itemBarcode2</param>
        /// <param name="itemBarcode3">itemBarcode3</param>
        /// <param name="itemManuDate">itemManuDate</param>
        /// <param name="itemExpDate">itemExpDate</param>
        /// <param name="itemDosageForm">itemDosageForm</param>
        /// <param name="itemGeneric">itemGeneric</param>
        /// <param name="itemClass">itemClass</param>
        /// <param name="itemGroup">itemGroup</param>
        /// <param name="itemCompany">itemCompany</param>
        /// <param name="itemPlace">itemPlace</param>
        /// <param name="itemLargeUnit">itemLargeUnit</param>
        /// <param name="itemLargeUnitNo">itemLargeUnitNo</param>
        /// <param name="itemLargeSalePrc">itemLargeSalePrc</param>
        /// <param name="itemLargeBuyPrc">itemLargeBuyPrc</param>
        /// <param name="itemLargeQty">itemLargeQty</param>
        /// <param name="itemMediumUnit">itemMediumUnit</param>
        /// <param name="itemMediumUnitNo">itemMediumUnitNo</param>
        /// <param name="itemMediumSalePrc">itemMediumSalePrc</param>
        /// <param name="itemMediumBuyPrc">itemMediumBuyPrc</param>
        /// <param name="itemMediumQty">itemMediumQty</param>
        /// <param name="itemSmallUnit">itemSmallUnit</param>
        /// <param name="itemSmallUnitNo">itemSmallUnitNo</param>
        /// <param name="itemSmallSalePrc">itemSmallSalePrc</param>
        /// <param name="itemSmallBuyPrc">itemSmallBuyPrc</param>
        /// <param name="itemSmallQty">itemSmallQty</param>
        /// <param name="itemMaxDiscound">itemMaxDiscound</param>
        /// <param name="itemDemandLimit">itemDemandLimit</param>
        /// <param name="itemMedicine">itemMedicine</param>
        /// <param name="itemAccessories">itemAccessories</param>
        /// <param name="itemLocal">itemLocal</param>
        /// <param name="itemImport">itemImport</param>
        /// <param name="itemExpiry">itemExpiry</param>
        /// <param name="itemDrug">itemDrug</param>
        /// <param name="itemRefragated">itemRefragated</param>
        /// <param name="itemUncommon">itemUncommon</param>
        /// <param name="pcNameWhoModified">pcNameWhoModified</param>
        /// <param name="itemWhoModified">itemWhoModified</param>
        public void UpdateItems(int itemID, string itemName, string itemEngName, string itemBarcode1,
                                string itemBarcode2, string itemBarcode3, string itemManuDate, string itemExpDate,
                                int itemDosageForm, int itemGeneric, int itemClass, int itemGroup, int itemCompany,
                                int itemPlace, int itemLargeUnit, int itemLargeUnitNo, decimal itemLargeSalePrc,
                                decimal itemLargeBuyPrc, decimal itemLargeQty, int itemMediumUnit, int itemMediumUnitNo,
                                decimal itemMediumSalePrc, decimal itemMediumBuyPrc, decimal itemMediumQty,
                                int itemSmallUnit, int itemSmallUnitNo, decimal itemSmallSalePrc, decimal itemSmallBuyPrc,
                                decimal itemSmallQty, decimal itemMaxDiscound, decimal itemDemandLimit,
                                bool itemMedicine, bool itemAccessories, bool itemLocal, bool itemImport,
                                bool itemExpiry, bool itemDrug, bool itemRefragated, bool itemUncommon,
                                string pcNameWhoModified, int itemWhoModified)
        {

            //Create New Instance From SqlParameter[]
            SqlParameter[] UpdateParam = new SqlParameter[41];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            UpdateParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[0].Value = itemID;

            UpdateParam[1] = new SqlParameter("@ItemName", SqlDbType.NVarChar, 150);
            UpdateParam[1].Value = itemName;

            UpdateParam[2] = new SqlParameter("@ItemEngName", SqlDbType.NVarChar, 150);
            UpdateParam[2].Value = itemEngName;

            UpdateParam[3] = new SqlParameter("@ItemBarcode1", SqlDbType.NVarChar, 100);
            UpdateParam[3].Value = itemBarcode1;

            UpdateParam[4] = new SqlParameter("@ItemBarcode2", SqlDbType.NVarChar, 100);
            UpdateParam[4].Value = itemBarcode2;

            UpdateParam[5] = new SqlParameter("@ItemBarcode3", SqlDbType.NVarChar, 100);
            UpdateParam[5].Value = itemBarcode3;

            UpdateParam[6] = new SqlParameter("@ItemManuDate", SqlDbType.NVarChar, 50);
            UpdateParam[6].Value = itemManuDate;

            UpdateParam[7] = new SqlParameter("@ItemExpDate", SqlDbType.NVarChar, 50);
            UpdateParam[7].Value = itemExpDate;

            UpdateParam[8] = new SqlParameter("@ItemDosage", SqlDbType.Int);
            UpdateParam[8].Value = itemDosageForm;

            UpdateParam[9] = new SqlParameter("@ItemGeneric", SqlDbType.Int);
            UpdateParam[9].Value = itemGeneric;

            UpdateParam[10] = new SqlParameter("@ItemClass", SqlDbType.Int);
            UpdateParam[10].Value = itemClass;

            UpdateParam[11] = new SqlParameter("@ItemGroup", SqlDbType.Int);
            UpdateParam[11].Value = itemGroup;

            UpdateParam[12] = new SqlParameter("@ItemCompany", SqlDbType.Int);
            UpdateParam[12].Value = itemCompany;

            UpdateParam[13] = new SqlParameter("@ItemPlace", SqlDbType.Int);
            UpdateParam[13].Value = itemPlace;

            UpdateParam[14] = new SqlParameter("@ItemLUnit", SqlDbType.Int);
            UpdateParam[14].Value = itemLargeUnit;

            UpdateParam[15] = new SqlParameter("@ItemLUnitNo", SqlDbType.Int);
            UpdateParam[15].Value = itemLargeUnitNo;

            UpdateParam[16] = new SqlParameter("@ItemLUnitSalePRC", SqlDbType.Decimal);
            UpdateParam[16].Value = itemLargeSalePrc;

            UpdateParam[17] = new SqlParameter("@ItemLUnitBuyPRC", SqlDbType.Decimal);
            UpdateParam[17].Value = itemLargeBuyPrc;

            UpdateParam[18] = new SqlParameter("@ItemLUnitQTY", SqlDbType.Decimal);
            UpdateParam[18].Value = itemLargeQty;

            UpdateParam[19] = new SqlParameter("@ItemMUnit", SqlDbType.Int);
            UpdateParam[19].Value = itemMediumUnit;

            UpdateParam[20] = new SqlParameter("@ItemMUnitNo", SqlDbType.Int);
            UpdateParam[20].Value = itemMediumUnitNo;

            UpdateParam[21] = new SqlParameter("@ItemMUnitSalePRC", SqlDbType.Decimal);
            UpdateParam[21].Value = itemMediumSalePrc;

            UpdateParam[22] = new SqlParameter("@ItemMUnitBuyPRC", SqlDbType.Decimal);
            UpdateParam[22].Value = itemMediumBuyPrc;

            UpdateParam[23] = new SqlParameter("@ItemMUnitQTY", SqlDbType.Decimal);
            UpdateParam[23].Value = itemMediumQty;


            UpdateParam[24] = new SqlParameter("@ItemSUnit", SqlDbType.Int);
            UpdateParam[24].Value = itemSmallUnit;

            UpdateParam[25] = new SqlParameter("@ItemSUnitNo", SqlDbType.Int);
            UpdateParam[25].Value = itemSmallUnitNo;

            UpdateParam[26] = new SqlParameter("@ItemSUnitSalePRC", SqlDbType.Decimal);
            UpdateParam[26].Value = itemSmallSalePrc;

            UpdateParam[27] = new SqlParameter("@ItemSUnitBuyPRC", SqlDbType.Decimal);
            UpdateParam[27].Value = itemSmallBuyPrc;

            UpdateParam[28] = new SqlParameter("@ItemSUnitQTY", SqlDbType.Decimal);
            UpdateParam[28].Value = itemSmallQty;

            UpdateParam[29] = new SqlParameter("@ItemDemandedLimit", SqlDbType.Decimal);
            UpdateParam[29].Value = itemDemandLimit;

            UpdateParam[30] = new SqlParameter("@ItemMaxDiscound", SqlDbType.Decimal);
            UpdateParam[30].Value = itemMaxDiscound;

            UpdateParam[31] = new SqlParameter("@ItemMedicine", SqlDbType.Bit);
            UpdateParam[31].Value = itemMedicine;

            UpdateParam[32] = new SqlParameter("@ItemAccessories", SqlDbType.Bit);
            UpdateParam[32].Value = itemAccessories;

            UpdateParam[33] = new SqlParameter("@ItemLocal", SqlDbType.Bit);
            UpdateParam[33].Value = itemLocal;

            UpdateParam[34] = new SqlParameter("@ItemImport", SqlDbType.Bit);
            UpdateParam[34].Value = itemImport;

            UpdateParam[35] = new SqlParameter("@ItemExpiry", SqlDbType.Bit);
            UpdateParam[35].Value = itemExpiry;

            UpdateParam[36] = new SqlParameter("@ItemDrug", SqlDbType.Bit);
            UpdateParam[36].Value = itemDrug;

            UpdateParam[37] = new SqlParameter("@ItemRefragated", SqlDbType.Bit);
            UpdateParam[37].Value = itemRefragated;

            UpdateParam[38] = new SqlParameter("@ItemUncommon", SqlDbType.Bit);
            UpdateParam[38].Value = itemUncommon;

            UpdateParam[39] = new SqlParameter("@PcNameModified", SqlDbType.NVarChar, 50);
            UpdateParam[39].Value = pcNameWhoModified;

            UpdateParam[40] = new SqlParameter("@ItemWhoModified", SqlDbType.Int);
            UpdateParam[40].Value = itemWhoModified;

            //Execute Command to Update any Record of Items Table by ItemID
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemUpdate]", UpdateParam);
        }

        /// <summary>
        /// Update Quantity of Items Table in three different units
        /// ItemLargeUnit - ItemMediumUnit - ItemSmallUnit
        /// </summary>
        /// <param name="itemID">itemID</param>
        /// <param name="itemLargeQty">itemLargeQty</param>
        /// <param name="itemMediumQty">itemMediumQty</param>
        /// <param name="itemSmallQty">itemSmallQty</param>
        /// <param name="pcNameWhoModified">pcNameWhoModified</param>
        /// <param name="itemWhoModified">itemWhoModified</param>
        public void UpdateItems (int itemID, decimal itemLargeQty, decimal itemMediumQty,
                                 decimal itemSmallQty,string pcNameWhoModified, int itemWhoModified)
        {

            //Create New Instance From SqlParameter[]
            SqlParameter[] UpdateParam = new SqlParameter[6];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            UpdateParam[0] = new SqlParameter("@ItemID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[0].Value = itemID;

            UpdateParam[1] = new SqlParameter("@ItemLUnitQTY", SqlDbType.Decimal);
            UpdateParam[1].Value = itemLargeQty;

            UpdateParam[2] = new SqlParameter("@ItemMUnitQTY", SqlDbType.Decimal);
            UpdateParam[2].Value = itemMediumQty;

            UpdateParam[3] = new SqlParameter("@ItemSUnitQTY", SqlDbType.Decimal);
            UpdateParam[3].Value = itemSmallQty;

            UpdateParam[4] = new SqlParameter("@PcNameModified", SqlDbType.NVarChar, 50);
            UpdateParam[4].Value = pcNameWhoModified;

            UpdateParam[5] = new SqlParameter("@ItemWhoModified", SqlDbType.Int);
            UpdateParam[5].Value = itemWhoModified;

            //Execute Command to Update Quantity of Items Table by ItemID
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemQuantityUpdate]", UpdateParam);
        }

        /// <summary>
        /// Update BuyPrice of Items Table in three different units
        /// ItemLargeUnit - ItemMediumUnit - ItemSmallUnit
        /// </summary>
        /// <param name="itemID">itemID</param>
        /// <param name="itemLargeBuyPrice">itemLargeBuyPrice</param>
        /// <param name="itemMediumBuyPrice">itemMediumBuyPrice</param>
        /// <param name="itemSmallBuyPrice">itemSmallBuyPrice</param>
        /// <param name="pcNameWhoModified">pcNameWhoModified</param>
        /// <param name="itemWhoModified">itemWhoModified</param>
        public void UpdateItemBuyPrice (int itemID, decimal itemLargeBuyPrice, decimal itemMediumBuyPrice,
                                 decimal itemSmallBuyPrice, string pcNameWhoModified, int itemWhoModified)
        {

            //Create New Instance From SqlParameter[]
            SqlParameter[] UpdateParam = new SqlParameter[6];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            UpdateParam[0] = new SqlParameter("@ItemID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[0].Value = itemID;

            UpdateParam[1] = new SqlParameter("@ItemLUnitBuyPRC", SqlDbType.Decimal);
            UpdateParam[1].Value = itemLargeBuyPrice;

            UpdateParam[2] = new SqlParameter("@ItemMUnitBuyPRC", SqlDbType.Decimal);
            UpdateParam[2].Value = itemMediumBuyPrice;

            UpdateParam[3] = new SqlParameter("@ItemSUnitBuyPRC", SqlDbType.Decimal);
            UpdateParam[3].Value = itemSmallBuyPrice;

            UpdateParam[4] = new SqlParameter("@PcNameModified", SqlDbType.NVarChar, 50);
            UpdateParam[4].Value = pcNameWhoModified;

            UpdateParam[5] = new SqlParameter("@ItemWhoModified", SqlDbType.Int);
            UpdateParam[5].Value = itemWhoModified;

            //Execute Command to Update BuyPrice of Items Table by ItemID
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemBuyPriceUpdate]", UpdateParam);
        }

        /// <summary>
        /// DataTable Function To Advanced Search in Items Table
        /// Recieve Two Parameters Column Name and Search Key
        /// Two Ways To Search Indentical (=) and Not Indentical (LIKE '%'+ @searchKey + '%';)
        /// </summary>
        /// <param name="ColumnName">ColumnName</param>
        /// <param name="SearchKey">SearchKey</param>
        /// <returns>DataTable</returns>
        public DataTable SearchItems(string columnName, string searchKey)
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
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_ItemSearch]", SearchParam);
        }

        /// <summary>
        /// DataTable Function To Search in Quantity of Items Table By ItemID
        /// Recieve Two Parameters Column Name and Search Key
        /// To Get Sum Of Quantity of Large Unit - Medium Unit - Small Unit
        /// </summary>
        /// <param name="ColumnName">ColumnName</param>
        /// <param name="SearchKey">SearchKey</param>
        /// <returns>DataTable</returns>
        public DataTable SearchItemQuantity(string columnName, string searchKey)
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
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_ItemQuantitySearch]", SearchParam);
        }
    }
}
