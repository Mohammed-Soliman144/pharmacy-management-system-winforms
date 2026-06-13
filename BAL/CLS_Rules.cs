using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data; //To Deal With DataTables and DataSet
using System.Data.SqlClient; //To Deal With SQL Server Databases and SqlParameter

namespace PharmacySystemV20._0._1.BAL
{
    class CLS_Rules
    {
        //Create new Instance From Singleton Class CLS_ConnectionDB() DataAccessLayer
        readonly DAL.CLS_ConnectionDB Connection = DAL.CLS_ConnectionDB.NewInstance();

        /// <summary>
        /// DataTable Function to Select All Records From Rules Table
        /// </summary>
        /// <returns>Rules Table</returns>
        public DataTable ShowRulesTable()
        {
            /*Use DataTable Function from DAL.CLS_ConnectionDB to Select All Columns From Rules Table
             * no any StoredProcedur Parameters in StoredProcedure so Initialize null value
             * Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
             */
            // return Connection.SelectData("[PharmacyDB].[dbo].[SP_RuleShow]", null);
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_RuleShow]", null);
        }

        /// <summary>
        /// Int Function to generate Rule ID
        /// </summary>
        /// <returns>RuleID</returns>
        public int GenerateRuleID()
        {
            //int RuleID without assignment any value
            int RuleID;

            //Initialize return value of DataTable Function From DAL Connection.SelectData("storedProcedureName",SqlParameter[])
            //Assignment the value from DataTable Function After Convert.ToInt32(Connection.SelectData("[DatabaseName].[dbo].[StoredProcedureName]", null).Rows[0][0].ToString())
            RuleID = Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastRuleID]", null).Rows[0][0].ToString());

            //return RuleID;
            return RuleID;
        }

        /// <summary>
        /// Method To Add New Rule to Rules Table Database
        /// </summary>
        /// <param name="ruleID">ruleID</param>
        /// <param name="ruleName"></param>
        /// <param name="ruleCustAdd"></param>
        /// <param name="ruleCustEdit"></param>
        /// <param name="ruleCustDelete"></param>
        /// <param name="ruleCustSearch"></param>
        /// <param name="ruleCustPrint"></param>
        /// <param name="ruleCustActivate"></param>
        /// <param name="ruleCustBalRpt"></param>
        /// <param name="ruleSuppAdd"></param>
        /// <param name="ruleSuppEdit"></param>
        /// <param name="ruleSuppDelete"></param>
        /// <param name="ruleSuppSearch"></param>
        /// <param name="ruleSuppPrint"></param>
        /// <param name="ruleSuppActivate"></param>
        /// <param name="ruleSuppBalRpt"></param>
        /// <param name="ruleItemAdd"></param>
        /// <param name="ruleItemEdit"></param>
        /// <param name="ruleItemDelete"></param>
        /// <param name="ruleItemSearch"></param>
        /// <param name="ruleItemPrint"></param>
        /// <param name="ruleItemActivate"></param>
        /// <param name="ruleStoreAdd"></param>
        /// <param name="ruleStoreEdit"></param>
        /// <param name="ruleStoreDelete"></param>
        /// <param name="ruleStoreSearch"></param>
        /// <param name="ruleStorePrint"></param>
        /// <param name="ruleStoreActivate"></param>
        /// <param name="ruleBranchAdd"></param>
        /// <param name="ruleBranchEdit"></param>
        /// <param name="ruleBranchDelete"></param>
        /// <param name="ruleBranchSearch"></param>
        /// <param name="ruleBranchPrint"></param>
        /// <param name="ruleBranchActivate"></param>
        /// <param name="ruleUserAdd"></param>
        /// <param name="ruleUserEdit"></param>
        /// <param name="ruleUserDelete"></param>
        /// <param name="ruleUserSearch"></param>
        /// <param name="ruleUserPrint"></param>
        /// <param name="ruleUserActivate"></param>
        /// <param name="rulePOSAdd"></param>
        /// <param name="rulePOSDelete"></param>
        /// <param name="rulePOSActivate"></param>
        /// <param name="ruleBuyAdd"></param>
        /// <param name="ruleBuySearch"></param>
        /// <param name="ruleBuyPrint"></param>
        /// <param name="ruleReBuyAdd"></param>
        /// <param name="ruleReBuySearch"></param>
        /// <param name="ruleReBuyPrint"></param>
        /// <param name="ruleSaleAdd"></param>
        /// <param name="ruleSaleSearch"></param>
        /// <param name="ruleSalePrint"></param>
        /// <param name="ruleReSaleAdd"></param>
        /// <param name="ruleReSaleSearch"></param>
        /// <param name="ruleReSalePrint"></param>
        /// <param name="ruleServer"></param>
        /// <param name="ruleBackupDB"></param>
        /// <param name="ruleRestoreDB"></param>
        /// <param name="ruleAdd"></param>
        /// <param name="ruleEdit"></param>
        /// <param name="ruleDelete"></param>
        /// <param name="pcNameWhoAdded"></param>
        /// <param name="ruleWhoAdded"></param>
        /// <param name="ruleDate"></param>
        /// <param name="ruleTime"></param>
        public void SaveRule(int ruleID, string ruleName, bool ruleCustAdd, bool ruleCustEdit, bool ruleCustDelete,
                                bool ruleCustSearch, bool ruleCustPrint, bool ruleCustActivate, bool ruleCustBalRpt,
                                bool ruleSuppAdd, bool ruleSuppEdit, bool ruleSuppDelete,
                                bool ruleSuppSearch, bool ruleSuppPrint, bool ruleSuppActivate, bool ruleSuppBalRpt,
                                bool ruleItemAdd, bool ruleItemEdit, bool ruleItemDelete,
                                bool ruleItemSearch, bool ruleItemPrint, bool ruleItemActivate,
                                bool ruleStoreAdd, bool ruleStoreEdit, bool ruleStoreDelete,
                                bool ruleStoreSearch, bool ruleStorePrint, bool ruleStoreActivate,
                                bool ruleBranchAdd, bool ruleBranchEdit, bool ruleBranchDelete,
                                bool ruleBranchSearch, bool ruleBranchPrint, bool ruleBranchActivate,
                                bool ruleUserAdd, bool ruleUserEdit, bool ruleUserDelete,
                                bool ruleUserSearch, bool ruleUserPrint, bool ruleUserActivate,
                                bool rulePOSAdd, bool rulePOSDelete, bool rulePOSActivate,
                                bool ruleBuyAdd, bool ruleBuySearch, bool ruleBuyPrint,
                                bool ruleReBuyAdd, bool ruleReBuySearch, bool ruleReBuyPrint,
                                bool ruleSaleAdd, bool ruleSaleSearch, bool ruleSalePrint,
                                bool ruleReSaleAdd, bool ruleReSaleSearch, bool ruleReSalePrint,
                                bool ruleServer, bool ruleBackupDB, bool ruleRestoreDB,
                                bool ruleAdd, bool ruleEdit, bool ruleDelete,
                                string pcNameWhoAdded, int ruleWhoAdded,
                                string ruleDate, string ruleTime)
        {
            //Create New Instance From SqlParameter[] which length of it is equal counter of storedprocedureparameter
            SqlParameter[] SaveParam = new SqlParameter[65];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            SaveParam[0] = new SqlParameter("@RuleID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[0].Value = ruleID;

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            SaveParam[1] = new SqlParameter("@RuleName", SqlDbType.NVarChar, 100);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[1].Value = ruleName;


            SaveParam[2] = new SqlParameter("@RuleCustAdd", SqlDbType.Bit);
            SaveParam[2].Value = ruleCustAdd;

            SaveParam[3] = new SqlParameter("@RuleCustEdit", SqlDbType.Bit);
            SaveParam[3].Value = ruleCustEdit;

            SaveParam[4] = new SqlParameter("@RuleCustDelete", SqlDbType.Bit);
            SaveParam[4].Value = ruleCustDelete;

            SaveParam[5] = new SqlParameter("@RuleCustSearch", SqlDbType.Bit);
            SaveParam[5].Value = ruleCustSearch;

            SaveParam[6] = new SqlParameter("@RuleCustPrint", SqlDbType.Bit);
            SaveParam[6].Value = ruleCustPrint;

            SaveParam[7] = new SqlParameter("@RuleCustActivate", SqlDbType.Bit);
            SaveParam[7].Value = ruleCustActivate;

            SaveParam[8] = new SqlParameter("@RuleCustBalRpt", SqlDbType.Bit);
            SaveParam[8].Value = ruleCustBalRpt;

            SaveParam[9] = new SqlParameter("@RuleSuppAdd", SqlDbType.Bit);
            SaveParam[9].Value = ruleSuppAdd;

            SaveParam[10] = new SqlParameter("@RuleSuppEdit", SqlDbType.Bit);
            SaveParam[10].Value = ruleSuppEdit;

            SaveParam[11] = new SqlParameter("@RuleSuppDelete", SqlDbType.Bit);
            SaveParam[11].Value = ruleSuppDelete;

            SaveParam[12] = new SqlParameter("@RuleSuppSearch", SqlDbType.Bit);
            SaveParam[12].Value = ruleSuppSearch;

            SaveParam[13] = new SqlParameter("@RuleSuppPrint", SqlDbType.Bit);
            SaveParam[13].Value = ruleSuppPrint;

            SaveParam[14] = new SqlParameter("@RuleSuppActivate", SqlDbType.Bit);
            SaveParam[14].Value = ruleSuppActivate;

            SaveParam[15] = new SqlParameter("@RuleSuppBalRpt", SqlDbType.Bit);
            SaveParam[15].Value = ruleSuppBalRpt;

            SaveParam[16] = new SqlParameter("@RuleItemAdd", SqlDbType.Bit);
            SaveParam[16].Value = ruleItemAdd;

            SaveParam[17] = new SqlParameter("@RuleItemEdit", SqlDbType.Bit);
            SaveParam[17].Value = ruleItemEdit;

            SaveParam[18] = new SqlParameter("@RuleItemDelete", SqlDbType.Bit);
            SaveParam[18].Value = ruleItemDelete;

            SaveParam[19] = new SqlParameter("@RuleItemSearch", SqlDbType.Bit);
            SaveParam[19].Value = ruleItemSearch;

            SaveParam[20] = new SqlParameter("@RuleItemPrint", SqlDbType.Bit);
            SaveParam[20].Value = ruleItemPrint;

            SaveParam[21] = new SqlParameter("@RuleItemActivate", SqlDbType.Bit);
            SaveParam[21].Value = ruleItemActivate;

            SaveParam[22] = new SqlParameter("@RuleStoreAdd", SqlDbType.Bit);
            SaveParam[22].Value = ruleStoreAdd;

            SaveParam[23] = new SqlParameter("@RuleStoreEdit", SqlDbType.Bit);
            SaveParam[23].Value = ruleStoreEdit;

            SaveParam[24] = new SqlParameter("@RuleStoreDelete", SqlDbType.Bit);
            SaveParam[24].Value = ruleStoreDelete;

            SaveParam[25] = new SqlParameter("@RuleStoreSearch", SqlDbType.Bit);
            SaveParam[25].Value = ruleStoreSearch;

            SaveParam[26] = new SqlParameter("@RuleStorePrint", SqlDbType.Bit);
            SaveParam[26].Value = ruleStorePrint;

            SaveParam[27] = new SqlParameter("@RuleStoreActivate", SqlDbType.Bit);
            SaveParam[27].Value = ruleStoreActivate;

            SaveParam[28] = new SqlParameter("@RuleBranchAdd", SqlDbType.Bit);
            SaveParam[28].Value = ruleBranchAdd;

            SaveParam[29] = new SqlParameter("@RuleBranchEdit", SqlDbType.Bit);
            SaveParam[29].Value = ruleBranchEdit;

            SaveParam[30] = new SqlParameter("@RuleBranchDelete", SqlDbType.Bit);
            SaveParam[30].Value = ruleBranchDelete;

            SaveParam[31] = new SqlParameter("@RuleBranchSearch", SqlDbType.Bit);
            SaveParam[31].Value = ruleBranchSearch;

            SaveParam[32] = new SqlParameter("@RuleBranchPrint", SqlDbType.Bit);
            SaveParam[32].Value = ruleBranchPrint;

            SaveParam[33] = new SqlParameter("@RuleBranchActivate", SqlDbType.Bit);
            SaveParam[33].Value = ruleBranchActivate;

            SaveParam[34] = new SqlParameter("@RuleUserAdd", SqlDbType.Bit);
            SaveParam[34].Value = ruleUserAdd;

            SaveParam[35] = new SqlParameter("@RuleUserEdit", SqlDbType.Bit);
            SaveParam[35].Value = ruleUserEdit;

            SaveParam[36] = new SqlParameter("@RuleUserDelete", SqlDbType.Bit);
            SaveParam[36].Value = ruleUserDelete;

            SaveParam[37] = new SqlParameter("@RuleUserSearch", SqlDbType.Bit);
            SaveParam[37].Value = ruleUserSearch;

            SaveParam[38] = new SqlParameter("@RuleUserPrint", SqlDbType.Bit);
            SaveParam[38].Value = ruleUserPrint;

            SaveParam[39] = new SqlParameter("@RuleUserActivate", SqlDbType.Bit);
            SaveParam[39].Value = ruleUserActivate;

            SaveParam[40] = new SqlParameter("@RulePOSAdd", SqlDbType.Bit);
            SaveParam[40].Value = rulePOSAdd;

            SaveParam[41] = new SqlParameter("@RulePOSDelete", SqlDbType.Bit);
            SaveParam[41].Value = rulePOSDelete;

            SaveParam[42] = new SqlParameter("@RulePOSActivate", SqlDbType.Bit);
            SaveParam[42].Value = rulePOSActivate;

            SaveParam[43] = new SqlParameter("@RuleBuyAdd", SqlDbType.Bit);
            SaveParam[43].Value = ruleBuyAdd;

            SaveParam[44] = new SqlParameter("@RuleBuySearch", SqlDbType.Bit);
            SaveParam[44].Value = ruleBuySearch;

            SaveParam[45] = new SqlParameter("@RuleBuyPrint", SqlDbType.Bit);
            SaveParam[45].Value = ruleBuyPrint;

            SaveParam[46] = new SqlParameter("@RuleReBuyAdd", SqlDbType.Bit);
            SaveParam[46].Value = ruleReBuyAdd;

            SaveParam[47] = new SqlParameter("@RuleReBuySearch", SqlDbType.Bit);
            SaveParam[47].Value = ruleReBuySearch;

            SaveParam[48] = new SqlParameter("@RuleReBuyPrint", SqlDbType.Bit);
            SaveParam[48].Value = ruleReBuyPrint;

            SaveParam[49] = new SqlParameter("@RuleSaleAdd", SqlDbType.Bit);
            SaveParam[49].Value = ruleSaleAdd;

            SaveParam[50] = new SqlParameter("@RuleSaleSearch", SqlDbType.Bit);
            SaveParam[50].Value = ruleSaleSearch;

            SaveParam[51] = new SqlParameter("@RuleSalePrint", SqlDbType.Bit);
            SaveParam[51].Value = ruleSalePrint;

            SaveParam[52] = new SqlParameter("@RuleReSaleAdd", SqlDbType.Bit);
            SaveParam[52].Value = ruleReSaleAdd;

            SaveParam[53] = new SqlParameter("@RuleReSaleSearch", SqlDbType.Bit);
            SaveParam[53].Value = ruleReSaleSearch;

            SaveParam[54] = new SqlParameter("@RuleReSalePrint", SqlDbType.Bit);
            SaveParam[54].Value = ruleReSalePrint;

            SaveParam[55] = new SqlParameter("@RuleServer", SqlDbType.Bit);
            SaveParam[55].Value = ruleServer;

            SaveParam[56] = new SqlParameter("@RuleBackupDB", SqlDbType.Bit);
            SaveParam[56].Value = ruleBackupDB;

            SaveParam[57] = new SqlParameter("@RuleRestoreDB", SqlDbType.Bit);
            SaveParam[57].Value = ruleRestoreDB;

            SaveParam[58] = new SqlParameter("@RuleAdd", SqlDbType.Bit);
            SaveParam[58].Value = ruleAdd;

            SaveParam[59] = new SqlParameter("@RuleEdit", SqlDbType.Bit);
            SaveParam[59].Value = ruleEdit;

            SaveParam[60] = new SqlParameter("@RuleDelete", SqlDbType.Bit);
            SaveParam[60].Value = ruleDelete;

            SaveParam[61] = new SqlParameter("@PcNameWhoAdded", SqlDbType.NVarChar, 50);
            SaveParam[61].Value = pcNameWhoAdded;

            SaveParam[62] = new SqlParameter("@RuleWhoAdded", SqlDbType.Int);
            SaveParam[62].Value = ruleWhoAdded;

            SaveParam[63] = new SqlParameter("@RuleDate", SqlDbType.NVarChar, 50);
            SaveParam[63].Value = ruleDate;

            SaveParam[64] = new SqlParameter("@RuleTime", SqlDbType.NVarChar, 50);
            SaveParam[64].Value = ruleTime;


            //Execute Command Insert into Table Branches by DAL.CLS_ConnectionDB
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_RuleEdit]", SaveParam);
        }

        /// <summary>
        /// Method To Delete Record From Rules Table
        /// </summary>
        /// <param name="ruleID">ruleID</param>
        public void DeleteRule(int ruleID)
        {
            //Create new instance from SqlParameter[]
            SqlParameter[] DeleteParam = new SqlParameter[1];

            DeleteParam[0] = new SqlParameter("@@RuleID", SqlDbType.Int);
            DeleteParam[0].Value = ruleID;

            //Execute Command To Delete Record from Rules Table
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_RuleDelete]", DeleteParam);

        }


        /// <summary>
        /// Method To Update Rules Table 
        /// </summary>
        /// <param name="ruleID"></param>
        /// <param name="ruleName"></param>
        /// <param name="ruleCustAdd"></param>
        /// <param name="ruleCustEdit"></param>
        /// <param name="ruleCustDelete"></param>
        /// <param name="ruleCustSearch"></param>
        /// <param name="ruleCustPrint"></param>
        /// <param name="ruleCustActivate"></param>
        /// <param name="ruleCustBalRpt"></param>
        /// <param name="ruleSuppAdd"></param>
        /// <param name="ruleSuppEdit"></param>
        /// <param name="ruleSuppDelete"></param>
        /// <param name="ruleSuppSearch"></param>
        /// <param name="ruleSuppPrint"></param>
        /// <param name="ruleSuppActivate"></param>
        /// <param name="ruleSuppBalRpt"></param>
        /// <param name="ruleItemAdd"></param>
        /// <param name="ruleItemEdit"></param>
        /// <param name="ruleItemDelete"></param>
        /// <param name="ruleItemSearch"></param>
        /// <param name="ruleItemPrint"></param>
        /// <param name="ruleItemActivate"></param>
        /// <param name="ruleStoreAdd"></param>
        /// <param name="ruleStoreEdit"></param>
        /// <param name="ruleStoreDelete"></param>
        /// <param name="ruleStoreSearch"></param>
        /// <param name="ruleStorePrint"></param>
        /// <param name="ruleStoreActivate"></param>
        /// <param name="ruleBranchAdd"></param>
        /// <param name="ruleBranchEdit"></param>
        /// <param name="ruleBranchDelete"></param>
        /// <param name="ruleBranchSearch"></param>
        /// <param name="ruleBranchPrint"></param>
        /// <param name="ruleBranchActivate"></param>
        /// <param name="ruleUserAdd"></param>
        /// <param name="ruleUserEdit"></param>
        /// <param name="ruleUserDelete"></param>
        /// <param name="ruleUserSearch"></param>
        /// <param name="ruleUserPrint"></param>
        /// <param name="ruleUserActivate"></param>
        /// <param name="rulePOSAdd"></param>
        /// <param name="rulePOSDelete"></param>
        /// <param name="rulePOSActivate"></param>
        /// <param name="ruleBuyAdd"></param>
        /// <param name="ruleBuySearch"></param>
        /// <param name="ruleBuyPrint"></param>
        /// <param name="ruleReBuyAdd"></param>
        /// <param name="ruleReBuySearch"></param>
        /// <param name="ruleReBuyPrint"></param>
        /// <param name="ruleSaleAdd"></param>
        /// <param name="ruleSaleSearch"></param>
        /// <param name="ruleSalePrint"></param>
        /// <param name="ruleReSaleAdd"></param>
        /// <param name="ruleReSaleSearch"></param>
        /// <param name="ruleReSalePrint"></param>
        /// <param name="ruleServer"></param>
        /// <param name="ruleBackupDB"></param>
        /// <param name="ruleRestoreDB"></param>
        /// <param name="ruleAdd"></param>
        /// <param name="ruleEdit"></param>
        /// <param name="ruleDelete"></param>
        /// <param name="pcNameWhoModified"></param>
        /// <param name="ruleWhoModified"></param>
        public void UpdateRule(int ruleID, string ruleName, bool ruleCustAdd, bool ruleCustEdit, bool ruleCustDelete,
                                bool ruleCustSearch, bool ruleCustPrint, bool ruleCustActivate, bool ruleCustBalRpt,
                                bool ruleSuppAdd, bool ruleSuppEdit, bool ruleSuppDelete,
                                bool ruleSuppSearch, bool ruleSuppPrint, bool ruleSuppActivate, bool ruleSuppBalRpt,
                                bool ruleItemAdd, bool ruleItemEdit, bool ruleItemDelete,
                                bool ruleItemSearch, bool ruleItemPrint, bool ruleItemActivate,
                                bool ruleStoreAdd, bool ruleStoreEdit, bool ruleStoreDelete,
                                bool ruleStoreSearch, bool ruleStorePrint, bool ruleStoreActivate,
                                bool ruleBranchAdd, bool ruleBranchEdit, bool ruleBranchDelete,
                                bool ruleBranchSearch, bool ruleBranchPrint, bool ruleBranchActivate,
                                bool ruleUserAdd, bool ruleUserEdit, bool ruleUserDelete,
                                bool ruleUserSearch, bool ruleUserPrint, bool ruleUserActivate,
                                bool rulePOSAdd, bool rulePOSDelete, bool rulePOSActivate,
                                bool ruleBuyAdd, bool ruleBuySearch, bool ruleBuyPrint,
                                bool ruleReBuyAdd, bool ruleReBuySearch, bool ruleReBuyPrint,
                                bool ruleSaleAdd, bool ruleSaleSearch, bool ruleSalePrint,
                                bool ruleReSaleAdd, bool ruleReSaleSearch, bool ruleReSalePrint,
                                bool ruleServer, bool ruleBackupDB, bool ruleRestoreDB,
                                bool ruleAdd, bool ruleEdit, bool ruleDelete,
                                string pcNameWhoModified, int ruleWhoModified)
        {

            //Create New Instance From SqlParameter[]
            SqlParameter[] UpdateParam = new SqlParameter[63];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            UpdateParam[0] = new SqlParameter("@RuleID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[0].Value = ruleID;

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            UpdateParam[1] = new SqlParameter("@RuleName", SqlDbType.NVarChar, 100);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[1].Value = ruleName;


            UpdateParam[2] = new SqlParameter("@RuleCustAdd", SqlDbType.Bit);
            UpdateParam[2].Value = ruleCustAdd;

            UpdateParam[3] = new SqlParameter("@RuleCustEdit", SqlDbType.Bit);
            UpdateParam[3].Value = ruleCustEdit;

            UpdateParam[4] = new SqlParameter("@RuleCustDelete", SqlDbType.Bit);
            UpdateParam[4].Value = ruleCustDelete;

            UpdateParam[5] = new SqlParameter("@RuleCustSearch", SqlDbType.Bit);
            UpdateParam[5].Value = ruleCustSearch;

            UpdateParam[6] = new SqlParameter("@RuleCustPrint", SqlDbType.Bit);
            UpdateParam[6].Value = ruleCustPrint;

            UpdateParam[7] = new SqlParameter("@RuleCustActivate", SqlDbType.Bit);
            UpdateParam[7].Value = ruleCustActivate;

            UpdateParam[8] = new SqlParameter("@RuleCustBalRpt", SqlDbType.Bit);
            UpdateParam[8].Value = ruleCustBalRpt;

            UpdateParam[9] = new SqlParameter("@RuleSuppAdd", SqlDbType.Bit);
            UpdateParam[9].Value = ruleSuppAdd;

            UpdateParam[10] = new SqlParameter("@RuleSuppEdit", SqlDbType.Bit);
            UpdateParam[10].Value = ruleSuppEdit;

            UpdateParam[11] = new SqlParameter("@RuleSuppDelete", SqlDbType.Bit);
            UpdateParam[11].Value = ruleSuppDelete;

            UpdateParam[12] = new SqlParameter("@RuleSuppSearch", SqlDbType.Bit);
            UpdateParam[12].Value = ruleSuppSearch;

            UpdateParam[13] = new SqlParameter("@RuleSuppPrint", SqlDbType.Bit);
            UpdateParam[13].Value = ruleSuppPrint;

            UpdateParam[14] = new SqlParameter("@RuleSuppActivate", SqlDbType.Bit);
            UpdateParam[14].Value = ruleSuppActivate;

            UpdateParam[15] = new SqlParameter("@RuleSuppBalRpt", SqlDbType.Bit);
            UpdateParam[15].Value = ruleSuppBalRpt;

            UpdateParam[16] = new SqlParameter("@RuleItemAdd", SqlDbType.Bit);
            UpdateParam[16].Value = ruleItemAdd;

            UpdateParam[17] = new SqlParameter("@RuleItemEdit", SqlDbType.Bit);
            UpdateParam[17].Value = ruleItemEdit;

            UpdateParam[18] = new SqlParameter("@RuleItemDelete", SqlDbType.Bit);
            UpdateParam[18].Value = ruleItemDelete;

            UpdateParam[19] = new SqlParameter("@RuleItemSearch", SqlDbType.Bit);
            UpdateParam[19].Value = ruleItemSearch;

            UpdateParam[20] = new SqlParameter("@RuleItemPrint", SqlDbType.Bit);
            UpdateParam[20].Value = ruleItemPrint;

            UpdateParam[21] = new SqlParameter("@RuleItemActivate", SqlDbType.Bit);
            UpdateParam[21].Value = ruleItemActivate;

            UpdateParam[22] = new SqlParameter("@RuleStoreAdd", SqlDbType.Bit);
            UpdateParam[22].Value = ruleStoreAdd;

            UpdateParam[23] = new SqlParameter("@RuleStoreEdit", SqlDbType.Bit);
            UpdateParam[23].Value = ruleStoreEdit;

            UpdateParam[24] = new SqlParameter("@RuleStoreDelete", SqlDbType.Bit);
            UpdateParam[24].Value = ruleStoreDelete;

            UpdateParam[25] = new SqlParameter("@RuleStoreSearch", SqlDbType.Bit);
            UpdateParam[25].Value = ruleStoreSearch;

            UpdateParam[26] = new SqlParameter("@RuleStorePrint", SqlDbType.Bit);
            UpdateParam[26].Value = ruleStorePrint;

            UpdateParam[27] = new SqlParameter("@RuleStoreActivate", SqlDbType.Bit);
            UpdateParam[27].Value = ruleStoreActivate;

            UpdateParam[28] = new SqlParameter("@RuleBranchAdd", SqlDbType.Bit);
            UpdateParam[28].Value = ruleBranchAdd;

            UpdateParam[29] = new SqlParameter("@RuleBranchEdit", SqlDbType.Bit);
            UpdateParam[29].Value = ruleBranchEdit;

            UpdateParam[30] = new SqlParameter("@RuleBranchDelete", SqlDbType.Bit);
            UpdateParam[30].Value = ruleBranchDelete;

            UpdateParam[31] = new SqlParameter("@RuleBranchSearch", SqlDbType.Bit);
            UpdateParam[31].Value = ruleBranchSearch;

            UpdateParam[32] = new SqlParameter("@RuleBranchPrint", SqlDbType.Bit);
            UpdateParam[32].Value = ruleBranchPrint;

            UpdateParam[33] = new SqlParameter("@RuleBranchActivate", SqlDbType.Bit);
            UpdateParam[33].Value = ruleBranchActivate;

            UpdateParam[34] = new SqlParameter("@RuleUserAdd", SqlDbType.Bit);
            UpdateParam[34].Value = ruleUserAdd;

            UpdateParam[35] = new SqlParameter("@RuleUserEdit", SqlDbType.Bit);
            UpdateParam[35].Value = ruleUserEdit;

            UpdateParam[36] = new SqlParameter("@RuleUserDelete", SqlDbType.Bit);
            UpdateParam[36].Value = ruleUserDelete;

            UpdateParam[37] = new SqlParameter("@RuleUserSearch", SqlDbType.Bit);
            UpdateParam[37].Value = ruleUserSearch;

            UpdateParam[38] = new SqlParameter("@RuleUserPrint", SqlDbType.Bit);
            UpdateParam[38].Value = ruleUserPrint;

            UpdateParam[39] = new SqlParameter("@RuleUserActivate", SqlDbType.Bit);
            UpdateParam[39].Value = ruleUserActivate;

            UpdateParam[40] = new SqlParameter("@RulePOSAdd", SqlDbType.Bit);
            UpdateParam[40].Value = rulePOSAdd;

            UpdateParam[41] = new SqlParameter("@RulePOSDelete", SqlDbType.Bit);
            UpdateParam[41].Value = rulePOSDelete;

            UpdateParam[42] = new SqlParameter("@RulePOSActivate", SqlDbType.Bit);
            UpdateParam[42].Value = rulePOSActivate;

            UpdateParam[43] = new SqlParameter("@RuleBuyAdd", SqlDbType.Bit);
            UpdateParam[43].Value = ruleBuyAdd;

            UpdateParam[44] = new SqlParameter("@RuleBuySearch", SqlDbType.Bit);
            UpdateParam[44].Value = ruleBuySearch;

            UpdateParam[45] = new SqlParameter("@RuleBuyPrint", SqlDbType.Bit);
            UpdateParam[45].Value = ruleBuyPrint;

            UpdateParam[46] = new SqlParameter("@RuleReBuyAdd", SqlDbType.Bit);
            UpdateParam[46].Value = ruleReBuyAdd;

            UpdateParam[47] = new SqlParameter("@RuleReBuySearch", SqlDbType.Bit);
            UpdateParam[47].Value = ruleReBuySearch;

            UpdateParam[48] = new SqlParameter("@RuleReBuyPrint", SqlDbType.Bit);
            UpdateParam[48].Value = ruleReBuyPrint;

            UpdateParam[49] = new SqlParameter("@RuleSaleAdd", SqlDbType.Bit);
            UpdateParam[49].Value = ruleSaleAdd;

            UpdateParam[50] = new SqlParameter("@RuleSaleSearch", SqlDbType.Bit);
            UpdateParam[50].Value = ruleSaleSearch;

            UpdateParam[51] = new SqlParameter("@RuleSalePrint", SqlDbType.Bit);
            UpdateParam[51].Value = ruleSalePrint;

            UpdateParam[52] = new SqlParameter("@RuleReSaleAdd", SqlDbType.Bit);
            UpdateParam[52].Value = ruleReSaleAdd;

            UpdateParam[53] = new SqlParameter("@RuleReSaleSearch", SqlDbType.Bit);
            UpdateParam[53].Value = ruleReSaleSearch;

            UpdateParam[54] = new SqlParameter("@RuleReSalePrint", SqlDbType.Bit);
            UpdateParam[54].Value = ruleReSalePrint;

            UpdateParam[55] = new SqlParameter("@RuleServer", SqlDbType.Bit);
            UpdateParam[55].Value = ruleServer;

            UpdateParam[56] = new SqlParameter("@RuleBackupDB", SqlDbType.Bit);
            UpdateParam[56].Value = ruleBackupDB;

            UpdateParam[57] = new SqlParameter("@RuleRestoreDB", SqlDbType.Bit);
            UpdateParam[57].Value = ruleRestoreDB;

            UpdateParam[58] = new SqlParameter("@RuleAdd", SqlDbType.Bit);
            UpdateParam[58].Value = ruleAdd;

            UpdateParam[59] = new SqlParameter("@RuleEdit", SqlDbType.Bit);
            UpdateParam[59].Value = ruleEdit;

            UpdateParam[60] = new SqlParameter("@RuleDelete", SqlDbType.Bit);
            UpdateParam[60].Value = ruleDelete;

            UpdateParam[61] = new SqlParameter("@PcNameWhoModified", SqlDbType.NVarChar, 50);
            UpdateParam[61].Value = pcNameWhoModified;

            UpdateParam[62] = new SqlParameter("@RuleWhoModified", SqlDbType.Int);
            UpdateParam[62].Value = ruleWhoModified;


            //Execute Command to Update any Record of Rules Table by RuleID
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_RuleUpdate]", UpdateParam);
        }


        /// <summary>
        /// DataTable Function To Advanced Search in Rules Table
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
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_RuleSearch]", SearchParam);
        }

        /// <summary>
        /// bool Function to check if rule of user is true or false
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="colName">colName</param>
        /// <returns></returns>
        public bool CheckRuleOfUser(int userID, string colName)
        {
            bool checkStatus = false;

            for (int i = 0; i < ShowRulesTable().Rows.Count; i++)
            {
                if (userID == Convert.ToInt32(ShowRulesTable().Rows[i]["UserID"]))
                {
                    if (Convert.ToBoolean(ShowRulesTable().Rows[i][colName]) == true) checkStatus = true;
                    else checkStatus = false;
                }
            }
            return checkStatus;
        }

    }
}

