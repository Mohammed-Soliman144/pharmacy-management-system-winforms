using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //To Deal With DataTables and DataSet
using System.Data.SqlClient; //To Deal With SQL Server Databases and SqlParameter

namespace PharmacySystemV20._0._1.BAL
{
    class CLS_ItemGroups
    {
        //Create new Instance From Singleton Class CLS_ConnectionDB() DataAccessLayer
        readonly DAL.CLS_ConnectionDB Connection = DAL.CLS_ConnectionDB.NewInstance();

        /// <summary>
        /// DataTable Function to Select All Columns From ItemGroups Table
        /// </summary>
        /// <returns>ItemGroups Table</returns>
        public DataTable ShowItemGroupTable()
        {
            /*Use DataTable Function from DAL.CLS_ConnectionDB to Select All Columns From ItemGroups Table
             * no any StoredProcedur Parameters in StoredProcedure so Initialize null value
             * Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
             */
            // return Connection.SelectData("[PharmacyDB].[dbo].[SP_ItemGroupShow]", null);
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_ItemGroupShow]", null);
        }

        /// <summary>
        /// Method To Add New ItemGroup to ItemGroups Table Database
        /// </summary>
        /// <param name="groupName">groupName</param>
        /// <param name="pcNameWhoAdded">pcNameWhoAdded</param>
        /// <param name="groupWhoAdded">groupWhoAdded</param>
        /// <param name="groupStatus">groupStatus</param>
        /// <param name="groupDate">groupDate</param>
        /// <param name="groupTime">groupTime</param>
        public void SaveGroup(string groupName, string pcNameWhoAdded, int groupWhoAdded,
                                     bool groupStatus, string groupDate, string groupTime)
        {
            //Create New Instance From SqlParameter[] which length of it is equal counter of storedprocedureparameter
            SqlParameter[] SaveParam = new SqlParameter[6];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            SaveParam[0] = new SqlParameter("@GroupName", SqlDbType.NVarChar, 100);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[0].Value = groupName;

            SaveParam[1] = new SqlParameter("@PcNameAdded", SqlDbType.NVarChar, 50);
            SaveParam[1].Value = pcNameWhoAdded;

            SaveParam[2] = new SqlParameter("@GroupWhoAdded", SqlDbType.Int);
            SaveParam[2].Value = groupWhoAdded;

            SaveParam[3] = new SqlParameter("@GroupStatus", SqlDbType.Bit);
            SaveParam[3].Value = groupStatus;

            SaveParam[4] = new SqlParameter("@Date", SqlDbType.NVarChar, 50);
            SaveParam[4].Value = groupDate;

            SaveParam[5] = new SqlParameter("@Time", SqlDbType.NVarChar, 50);
            SaveParam[5].Value = groupTime;


            //Execute Command Insert into Table ItemGroups by DAL.CLS_ConnectionDB
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemGroupEdit]", SaveParam);
        }

        /// <summary>
        /// Method To Delete Record From itemGroups Table Database
        /// </summary>
        /// <param name="itemGroupID">itemGroupID</param>
        public void DeleteGroup(int itemGroupID)
        {
            //Create new instance from SqlParameter[]
            SqlParameter[] DeleteParam = new SqlParameter[1];

            DeleteParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            DeleteParam[0].Value = itemGroupID;

            //Execute Command To Delete Record from itemGroups Table Database
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemGroupDelete]", DeleteParam);

        }

        /// <summary>
        /// Method To Update ItemGroups Table by Modify itemGroupStatus Only (Deactivate ItemGroup)
        /// </summary>
        /// <param name="itemGroupID">itemGroupID</param>
        /// <param name="itemGroupStatus">itemGroupStatus</param>
        public void DeactivateGroup(int itemGroupID, bool itemGroupStatus)
        {
            //Create New Instance From SqlParameter [] array
            SqlParameter[] DeleteParam = new SqlParameter[2];

            DeleteParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            DeleteParam[0].Value = itemGroupID;

            DeleteParam[1] = new SqlParameter("@Status", SqlDbType.Bit);
            DeleteParam[1].Value = itemGroupStatus;

            //Execute Command to Update ItemGroups table by In Activate ItemGroup
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemGroupDeactivate]", DeleteParam);
        }
    }
}
