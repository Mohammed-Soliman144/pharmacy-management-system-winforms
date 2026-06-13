using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //To Deal With DataTables and DataSet
using System.Data.SqlClient; //To Deal With SQL Server Databases and SqlParameter

namespace PharmacySystemV20._0._1.BAL
{
    class CLS_POSDetails
    {
        //Create new Instance From Singleton Class CLS_ConnectionDB() DataAccessLayer
        readonly DAL.CLS_ConnectionDB Connection = DAL.CLS_ConnectionDB.NewInstance();

        /// <summary>
        /// DataTable Function to Select All Records From POSDetails Table
        /// POSDetail Refers To Details of POS
        /// </summary>
        /// <returns>POSDetails Table</returns>
        //public DataTable ShowPOSDetailTable()
        //{
        //    /*Use DataTable Function from DAL.CLS_ConnectionDB to Select All Columns From POS Table
        //     * no any StoredProcedur Parameters in StoredProcedure so Initialize null value
        //     * Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
        //     */
        //    // return Connection.SelectData("[PharmacyDB].[dbo].[SP_POSShow]", null);
        //    return Connection.SelectData("[PharmacyDB].[dbo].[SP_POSShow]", null);
        //}

        /// <summary>
        /// Int Function to generate POSDetailID
        /// </summary>
        /// <returns>POSDetailID</returns>
        public int GeneratePOSDetailID()
        {
            //Initialize return value of DataTable Function From DAL Connection.SelectData("storedProcedureName",SqlParameter[])
            //Assignment the value from DataTable Function After Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastPOSDetailID]", null).Rows[0][0])
            //return int POSDetailID
            return Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastPOSDetailID]", null).Rows[0][0]);
        }

        /// <summary>
        /// Method To Add New POS Details Or Save new POS Details 
        /// </summary>
        /// <param name="posDetailID">posDetailID</param>
        /// <param name="posDetailPillID">posDetailPillID</param>
        /// <param name="posDetailPillName">posDetailPillName</param>
        /// <param name="posDetailPillCode">posDetailPillCode</param>
        /// <param name="posDetailPOSID">posDetailPOSID</param>
        /// <param name="posDetailPayType">posDetailPayType</param>
        /// <param name="posDetailDemanded">posDetailDemanded</param>
        /// <param name="posDetailPaid">posDetailPaid</param>
        /// <param name="posDetailRemained">posDetailRemained</param>
        /// <param name="pcNameWhoAdded">pcNameWhoAdded</param>
        /// <param name="posDetailWhoAdded">posDetailWhoAdded</param>
        /// <param name="posDetailDate">posDetailDate</param>
        /// <param name="posDetailTime">posDetailTime</param>
        public void SavePOSDetail (int posDetailID, int posDetailPillID, string posDetailPillName, string posDetailPillCode,
                                   int posDetailPOSID, string posDetailPayType, decimal posDetailDemanded, decimal posDetailPaid, decimal posDetailRemained, 
                                   string pcNameWhoAdded, int posDetailWhoAdded, string posDetailDate, string posDetailTime)
        {
            //Create New Instance From SqlParameter[] which length of it is equal counter of storedprocedureparameter
            SqlParameter[] SaveParam = new SqlParameter[13];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            SaveParam[0] = new SqlParameter("@POSDetailID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[0].Value = posDetailID;

            SaveParam[1] = new SqlParameter("@PillID", SqlDbType.Int);
            SaveParam[1].Value = posDetailPillID;

            SaveParam[2] = new SqlParameter("@PillName", SqlDbType.NVarChar, 50);
            SaveParam[2].Value = posDetailPillName;

            SaveParam[3] = new SqlParameter("@PillCustomCode", SqlDbType.NVarChar, 50);
            SaveParam[3].Value = posDetailPillCode;

            SaveParam[4] = new SqlParameter("@POSID", SqlDbType.Int);
            SaveParam[4].Value = posDetailPOSID;

            SaveParam[5] = new SqlParameter("@POSDetailPayType", SqlDbType.NVarChar, 50);
            SaveParam[5].Value = posDetailPayType;

            SaveParam[6] = new SqlParameter("@POSDetailDemanded", SqlDbType.Decimal);
            SaveParam[6].Value = posDetailDemanded;

            SaveParam[7] = new SqlParameter("@POSDetailPaid", SqlDbType.Decimal);
            SaveParam[7].Value = posDetailPaid;

            SaveParam[8] = new SqlParameter("@POSDetailRemained", SqlDbType.Decimal);
            SaveParam[8].Value = posDetailRemained;

            SaveParam[9] = new SqlParameter("@PCNameWhoAdded", SqlDbType.NVarChar, 50);
            SaveParam[9].Value = pcNameWhoAdded;

            SaveParam[10] = new SqlParameter("@POSDetailWhoAdded", SqlDbType.Int);
            SaveParam[10].Value = posDetailWhoAdded;

            SaveParam[11] = new SqlParameter("@Date", SqlDbType.NVarChar, 50);
            SaveParam[11].Value = posDetailDate;

            SaveParam[12] = new SqlParameter("@Time", SqlDbType.NVarChar, 50);
            SaveParam[12].Value = posDetailTime;

            //Execute Command Insert into Table POS Details by DAL.CLS_ConnectionDB
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_POSDetailEdit]", SaveParam);
        }

        /// <summary>
        /// Method To Delete Record From POS Details Table
        /// </summary>
        /// <param name="posDetailID">posDetailID</param>
        public void DeletePOSDetail(int posDetailID)
        {
            //Create new instance from SqlParameter[]
            SqlParameter[] DeleteParam = new SqlParameter[1];

            DeleteParam[0] = new SqlParameter("@POSDetailID", SqlDbType.Int);
            DeleteParam[0].Value = posDetailID;

            //Execute Command To Delete Record from POS Details Table
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_POSDetailDeleted]", DeleteParam);

        }

        /// <summary>
        /// Method To Update POSDetails Table by Modify POS Details Status Only (Deactivate POSDetails)
        /// </summary>
        /// <param name="posDetailID">posDetailID</param>
        /// <param name="posDetailStatus">posDetailStatus</param>
        /// <param name="pcNameWhoDeleted">pcNameWhoDeleted</param>
        /// <param name="posDetailWhoDeleted">posDetailWhoDeleted</param>
        public void DeactivatePOSDetail(int posDetailID, bool posDetailStatus, string pcNameWhoDeleted, int posDetailWhoDeleted)
        {
            //Create New Instance From SqlParameter [] array
            SqlParameter[] DeleteParam = new SqlParameter[4];

            DeleteParam[0] = new SqlParameter("@POSDetailID", SqlDbType.Int);
            DeleteParam[0].Value = posDetailID;

            DeleteParam[1] = new SqlParameter("@POSDetailStatus", SqlDbType.Bit);
            DeleteParam[1].Value = posDetailStatus;

            DeleteParam[2] = new SqlParameter("@PCNameWhoDeleted", SqlDbType.NVarChar, 50);
            DeleteParam[2].Value = pcNameWhoDeleted;

            DeleteParam[3] = new SqlParameter("@POSDetailWhoDeleted", SqlDbType.Int);
            DeleteParam[3].Value = posDetailWhoDeleted;

            //Execute Command to Update POSDetails table by In Activate POS Details Status
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_POSDetailDeactivate]", DeleteParam);
        }

        /// <summary>
        /// Method To Update POSDetails Table  
        /// </summary>
        /// <param name="posDetailID">posDetailID</param>
        /// <param name="posDetailPillID">posDetailPillID</param>
        /// <param name="posDetailPillName">posDetailPillName</param>
        /// <param name="posDetailPillCode">posDetailPillCode</param>
        /// <param name="posDetailPOSID">posDetailPOSID</param>
        /// <param name="posDetailPayType">posDetailPayType</param>
        /// <param name="posDetailDemanded">posDetailDemanded</param>
        /// <param name="posDetailPaid">posDetailPaid</param>
        /// <param name="posDetailRemained">posDetailRemained</param>
        /// <param name="pcNameWhoModified">pcNameWhoModified</param>
        /// <param name="posDetailWhoModified"></param>
        public void UpdatePOSDetail(int posDetailID, int posDetailPillID, string posDetailPillName, string posDetailPillCode,
                                    int posDetailPOSID, string posDetailPayType, decimal posDetailDemanded, decimal posDetailPaid, decimal posDetailRemained,
                                    string pcNameWhoModified, int posDetailWhoModified)
        {
            //Create New Instance From SqlParameter[]
            SqlParameter[] UpdateParam = new SqlParameter[11];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            UpdateParam[0] = new SqlParameter("@POSDetailID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[0].Value = posDetailID;

            UpdateParam[1] = new SqlParameter("@PillID", SqlDbType.Int);
            UpdateParam[1].Value = posDetailPillID;

            UpdateParam[2] = new SqlParameter("@PillName", SqlDbType.NVarChar, 50);
            UpdateParam[2].Value = posDetailPillName;

            UpdateParam[3] = new SqlParameter("@PillCustomCode", SqlDbType.NVarChar, 50);
            UpdateParam[3].Value = posDetailPillCode;

            UpdateParam[4] = new SqlParameter("@POSID", SqlDbType.Int);
            UpdateParam[4].Value = posDetailPOSID;

            UpdateParam[5] = new SqlParameter("@POSDetailPayType", SqlDbType.NVarChar, 50);
            UpdateParam[5].Value = posDetailPayType;

            UpdateParam[6] = new SqlParameter("@POSDetailDemanded", SqlDbType.Decimal);
            UpdateParam[6].Value = posDetailDemanded;

            UpdateParam[7] = new SqlParameter("@POSDetailPaid", SqlDbType.Decimal);
            UpdateParam[7].Value = posDetailPaid;

            UpdateParam[8] = new SqlParameter("@POSDetailRemained", SqlDbType.Decimal);
            UpdateParam[8].Value = posDetailRemained;

            UpdateParam[9] = new SqlParameter("@PCNameWhoModified", SqlDbType.NVarChar, 50);
            UpdateParam[9].Value = pcNameWhoModified;

            UpdateParam[10] = new SqlParameter("@POSDetailWhoModified", SqlDbType.Int);
            UpdateParam[10].Value = posDetailWhoModified;

            //Execute Command to Update any Record of POSDetails Table by POSDetailID
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_POSDetailUpdate]", UpdateParam);
        }


        /// <summary>
        /// DataTable Function To Advanced Search in POS Table
        /// Recieve Two Parameters Column Name and Search Key
        /// Two Ways To Search Indentical (=) and Not Indentical (LIKE '%'+ @searchKey + '%';)
        /// </summary>
        /// <param name="ColumnName">ColumnName</param>
        /// <param name="SearchKey">SearchKey</param>
        /// <returns>DataTable</returns>
        //public DataTable SearchPOS(string columnName, string searchKey)
        //{
        //    //Create New Instance From SqlParameter[]
        //    SqlParameter[] SearchParam = new SqlParameter[2];
        //    //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
        //    SearchParam[0] = new SqlParameter("@ColumnName", SqlDbType.NVarChar, 25);
        //    //Initialize value of every element in array by Argument which received from form
        //    SearchParam[0].Value = columnName;

        //    SearchParam[1] = new SqlParameter("@SearchKey", SqlDbType.NVarChar, 100);
        //    SearchParam[1].Value = searchKey;

        //    //Return DataTable which like search key
        //    return Connection.SelectData("[PharmacyDB].[dbo].[SP_POSSearch]", SearchParam);
        //}
    }
}
