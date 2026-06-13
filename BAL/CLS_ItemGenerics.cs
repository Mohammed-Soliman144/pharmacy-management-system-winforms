using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //To Deal With DataTables and DataSet
using System.Data.SqlClient; //To Deal With SQL Server Databases and SqlParameter

namespace PharmacySystemV20._0._1.BAL
{
    class CLS_ItemGenerics
    {
        //Create new Instance From Singleton Class CLS_ConnectionDB() DataAccessLayer
        readonly DAL.CLS_ConnectionDB Connection = DAL.CLS_ConnectionDB.NewInstance();

        /// <summary>
        /// DataTable Function to Select All Columns From ItemGenerics Table
        /// </summary>
        /// <returns>ItemGenerics Table</returns>
        public DataTable ShowItemGenericTable()
        {
            /*Use DataTable Function from DAL.CLS_ConnectionDB to Select All Columns From ItemGenerics Table
             * no any StoredProcedur Parameters in StoredProcedure so Initialize null value
             * Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
             */
            // return Connection.SelectData("[PharmacyDB].[dbo].[SP_ItemGenericShow]", null);
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_ItemGenericShow]", null);
        }

        /// <summary>
        /// Method To Add New Generic to ItemGenerics Table Database
        /// </summary>
        /// <param name="genericName">genericName</param>
        /// <param name="pcNameWhoAdded">pcNameWhoAdded</param>
        /// <param name="genericWhoAdded">genericWhoAdded</param>
        /// <param name="genericStatus">genericStatus</param>
        /// <param name="genericDate">genericDate</param>
        /// <param name="genericTime">genericTime</param>
        public void SaveGeneric(string genericName, string pcNameWhoAdded, int genericWhoAdded,
                                     bool genericStatus, string genericDate, string genericTime)
        {
            //Create New Instance From SqlParameter[] which length of it is equal counter of storedprocedureparameter
            SqlParameter[] SaveParam = new SqlParameter[6];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            SaveParam[0] = new SqlParameter("@GenericName", SqlDbType.NVarChar, 100);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[0].Value = genericName;

            SaveParam[1] = new SqlParameter("@PcNameAdded", SqlDbType.NVarChar, 50);
            SaveParam[1].Value = pcNameWhoAdded;

            SaveParam[2] = new SqlParameter("@GenericWhoAdded", SqlDbType.Int);
            SaveParam[2].Value = genericWhoAdded;

            SaveParam[3] = new SqlParameter("@GenericStatus", SqlDbType.Bit);
            SaveParam[3].Value = genericStatus;

            SaveParam[4] = new SqlParameter("@Date", SqlDbType.NVarChar, 50);
            SaveParam[4].Value = genericDate;

            SaveParam[5] = new SqlParameter("@Time", SqlDbType.NVarChar, 50);
            SaveParam[5].Value = genericTime;


            //Execute Command Insert into Table Branches by DAL.CLS_ConnectionDB
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemGenericEdit]", SaveParam);
        }

        /// <summary>
        /// Method To Delete Record From ItemitemGenerics Table Database
        /// </summary>
        /// <param name="itemGenericID">itemGenericID</param>
        public void DeleteGeneric(int itemGenericID)
        {
            //Create new instance from SqlParameter[]
            SqlParameter[] DeleteParam = new SqlParameter[1];

            DeleteParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            DeleteParam[0].Value = itemGenericID;

            //Execute Command To Delete Record from ItemGenerics Table Database
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemGenericDelete]", DeleteParam);

        }

        /// <summary>
        /// Method To Update ItemGenerics Table by Modify itemGenericStatus Only (Deactivate itemGeneric)
        /// </summary>
        /// <param name="itemGenericID">itemGenericID</param>
        /// <param name="itemGenericStatus">itemGenericStatus</param>
        public void DeactivateGeneric(int itemGenericID, bool itemGenericStatus)
        {
            //Create New Instance From SqlParameter [] array
            SqlParameter[] DeleteParam = new SqlParameter[2];

            DeleteParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            DeleteParam[0].Value = itemGenericID;

            DeleteParam[1] = new SqlParameter("@Status", SqlDbType.Bit);
            DeleteParam[1].Value = itemGenericStatus;

            //Execute Command to Update ItemGenerics table by In Activate ItemGeneric
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemGenericDeactivate]", DeleteParam);
        }
    }
}
