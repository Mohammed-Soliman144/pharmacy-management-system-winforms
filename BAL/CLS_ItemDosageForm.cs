using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //To Deal With DataTables and DataSet
using System.Data.SqlClient; //To Deal With SQL Server Databases and SqlParameter

namespace PharmacySystemV20._0._1.BAL
{
    class CLS_ItemDosageForm
    {
        //Create new Instance From Singleton Class CLS_ConnectionDB() DataAccessLayer
        readonly DAL.CLS_ConnectionDB Connection = DAL.CLS_ConnectionDB.NewInstance();

        /// <summary>
        /// DataTable Function to Select All Columns From ItemDosageForm Table
        /// </summary>
        /// <returns>ItemDosageForm Table</returns>
        public DataTable ShowItemDosageFormTable()
        {
            /*Use DataTable Function from DAL.CLS_ConnectionDB to Select All Columns From ItemDosageForm Table
             * no any StoredProcedur Parameters in StoredProcedure so Initialize null value
             * Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
             */
            // return Connection.SelectData("[PharmacyDB].[dbo].[SP_ItemDosageFormShow]", null);
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_ItemDosageFormShow]", null);
        }

        /// <summary>
        /// Method To Add New DosageForm to ItemDosageForm Table Database
        /// </summary>
        /// <param name="dosageFormName">dosageFormName</param>
        /// <param name="pcNameWhoAdded">pcNameWhoAdded</param>
        /// <param name="dosageWhoAdded">dosageWhoAdded</param>
        /// <param name="dosageStatus">dosageStatus</param>
        /// <param name="dosageDate">dosageDate</param>
        /// <param name="dosageTime">dosageTime</param>
        public void SaveDosageForm (string dosageFormName,string pcNameWhoAdded, int dosageWhoAdded, 
                                     bool dosageStatus, string dosageDate, string dosageTime)
        {
            //Create New Instance From SqlParameter[] which length of it is equal counter of storedprocedureparameter
            SqlParameter[] SaveParam = new SqlParameter[6];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            SaveParam[0] = new SqlParameter("@DosageFormName", SqlDbType.NVarChar, 100);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[0].Value = dosageFormName;

            SaveParam[1] = new SqlParameter("@PcNameAdded", SqlDbType.NVarChar, 50);
            SaveParam[1].Value = pcNameWhoAdded;

            SaveParam[2] = new SqlParameter("@DosageWhoAdded", SqlDbType.Int);
            SaveParam[2].Value = dosageWhoAdded;

            SaveParam[3] = new SqlParameter("@DosageStatus", SqlDbType.Bit);
            SaveParam[3].Value = dosageStatus;

            SaveParam[4] = new SqlParameter("@Date", SqlDbType.NVarChar, 50);
            SaveParam[4].Value = dosageDate;

            SaveParam[5] = new SqlParameter("@Time", SqlDbType.NVarChar, 50);
            SaveParam[5].Value = dosageTime;


            //Execute Command Insert into Table Branches by DAL.CLS_ConnectionDB
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemDosageFormEdit]", SaveParam);
        }

        /// <summary>
        /// Method To Delete Record From ItemDosageForm Table Database
        /// </summary>
        /// <param name="itemDosageID">itemDosageID</param>
        public void DeleteDosageForm(int itemDosageID)
        {
            //Create new instance from SqlParameter[]
            SqlParameter[] DeleteParam = new SqlParameter[1];

            DeleteParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            DeleteParam[0].Value = itemDosageID;

            //Execute Command To Delete Record from ItemDosageForm Table Database
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemDosageFormDelete]", DeleteParam);

        }

        /// <summary>
        /// Method To Update ItemDosageForm Table by Modify itemDosageStatus Only (Deactivate ItemDosageForm)
        /// </summary>
        /// <param name="itemDosageID">itemDosageID</param>
        /// <param name="itemDosageStatus">itemDosageStatus</param>
        public void DeactivateDosageForm(int itemDosageID, bool itemDosageStatus)
        {
            //Create New Instance From SqlParameter [] array
            SqlParameter[] DeleteParam = new SqlParameter[2];

            DeleteParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            DeleteParam[0].Value = itemDosageID;

            DeleteParam[1] = new SqlParameter("@Status", SqlDbType.Bit);
            DeleteParam[1].Value = itemDosageStatus;

            //Execute Command to Update ItemDosageForm table by In Activate ItemDosageForm
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemDosageFormDeactivate]", DeleteParam);
        }
    }
}
