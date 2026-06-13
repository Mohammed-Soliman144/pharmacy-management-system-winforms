using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //To Deal With DataTables and DataSet
using System.Data.SqlClient; //To Deal With SQL Server Databases and SqlParameter

namespace PharmacySystemV20._0._1.BAL
{
    class CLS_ItemUnits
    {
        //Create new Instance From Singleton Class CLS_ConnectionDB() DataAccessLayer
        readonly DAL.CLS_ConnectionDB Connection = DAL.CLS_ConnectionDB.NewInstance();

        /// <summary>
        /// DataTable Function to Select All Columns From ItemUnits Table
        /// </summary>
        /// <returns>ItemUnits Table</returns>
        public DataTable ShowItemUnitTable()
        {
            /*Use DataTable Function from DAL.CLS_ConnectionDB to Select All Columns From ItemUnits Table
             * no any StoredProcedur Parameters in StoredProcedure so Initialize null value
             * Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
             */
            // return Connection.SelectData("[PharmacyDB].[dbo].[SP_ItemUnitShow]", null);
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_ItemUnitShow]", null);
        }

        /// <summary>
        /// Method To Add New Unit to ItemUnits Table Database
        /// </summary>
        /// <param name="unitName"></param>
        /// <param name="pcNameWhoAdded"></param>
        /// <param name="unitWhoAdded"></param>
        /// <param name="unitStatus"></param>
        /// <param name="unitDate"></param>
        /// <param name="unitTime"></param>

        public void SaveUnit(string unitName, string pcNameWhoAdded, int unitWhoAdded,
                                     bool unitStatus, string unitDate, string unitTime)
        {
            //Create New Instance From SqlParameter[] which length of it is equal counter of storedprocedureparameter
            SqlParameter[] SaveParam = new SqlParameter[6];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            SaveParam[0] = new SqlParameter("@UnitName", SqlDbType.NVarChar, 100);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[0].Value = unitName;

            SaveParam[1] = new SqlParameter("@PcNameAdded", SqlDbType.NVarChar, 50);
            SaveParam[1].Value = pcNameWhoAdded;

            SaveParam[2] = new SqlParameter("@UnitWhoAdded", SqlDbType.Int);
            SaveParam[2].Value = unitWhoAdded;

            SaveParam[3] = new SqlParameter("@UnitStatus", SqlDbType.Bit);
            SaveParam[3].Value = unitStatus;

            SaveParam[4] = new SqlParameter("@Date", SqlDbType.NVarChar, 50);
            SaveParam[4].Value = unitDate;

            SaveParam[5] = new SqlParameter("@Time", SqlDbType.NVarChar, 50);
            SaveParam[5].Value = unitTime;


            //Execute Command Insert into Table ItemUnits by DAL.CLS_ConnectionDB
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemUnitEdit]", SaveParam);
        }

        /// <summary>
        /// Method To Delete Record From ItemUnits Table Database
        /// </summary>
        /// <param name="itemUnitID">itemUnitID</param>
        public void DeleteUnit(int itemUnitID)
        {
            //Create new instance from SqlParameter[]
            SqlParameter[] DeleteParam = new SqlParameter[1];

            DeleteParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            DeleteParam[0].Value = itemUnitID;

            //Execute Command To Delete Record from ItemUnits Table Database
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemUnitDelete]", DeleteParam);

        }

        /// <summary>
        /// Method To Update ItemUnits Table by Modify itemUnitStatus Only (Deactivate ItemUnit)
        /// </summary>
        /// <param name="itemUnitID">itemUnitID</param>
        /// <param name="itemUnitStatus">itemUnitStatus</param>
        public void DeactivateUnit(int itemUnitID, bool itemUnitStatus)
        {
            //Create New Instance From SqlParameter [] array
            SqlParameter[] DeleteParam = new SqlParameter[2];

            DeleteParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            DeleteParam[0].Value = itemUnitID;

            DeleteParam[1] = new SqlParameter("@Status", SqlDbType.Bit);
            DeleteParam[1].Value = itemUnitStatus;

            //Execute Command to Update ItemUnits table by In Activate ItemUnit
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemUnitDeactivate]", DeleteParam);
        }
    }
}
