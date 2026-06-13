using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //To Deal With DataTables and DataSet
using System.Data.SqlClient; //To Deal With SQL Server Databases and SqlParameter

namespace PharmacySystemV20._0._1.BAL
{
    class CLS_ItemClassOfActions
    {
        //Create new Instance From Singleton Class CLS_ConnectionDB() DataAccessLayer
        readonly DAL.CLS_ConnectionDB Connection = DAL.CLS_ConnectionDB.NewInstance();

        /// <summary>
        /// DataTable Function to Select All Columns From ItemClassOfActions Table
        /// </summary>
        /// <returns>ItemClassOfActions Table</returns>
        public DataTable ShowItemClassTable()
        {
            /*Use DataTable Function from DAL.CLS_ConnectionDB to Select All Columns From ItemClassOfActions Table
             * no any StoredProcedur Parameters in StoredProcedure so Initialize null value
             * Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
             */
            // return Connection.SelectData("[PharmacyDB].[dbo].[SP_ItemClassShow]", null);
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_ItemClassShow]", null);
        }

        /// <summary>
        /// Method To Add New ClassOfAction to ItemClassOfActions Table Database
        /// </summary>
        /// <param name="className">className</param>
        /// <param name="pcNameWhoAdded">pcNameWhoAdded</param>
        /// <param name="classWhoAdded">classWhoAdded</param>
        /// <param name="classStatus">classStatus</param>
        /// <param name="classDate">classDate</param>
        /// <param name="classTime">classTime</param>
        public void SaveClassOfAction(string className, string pcNameWhoAdded, int classWhoAdded,
                                     bool classStatus, string classDate, string classTime)
        {
            //Create New Instance From SqlParameter[] which length of it is equal counter of storedprocedureparameter
            SqlParameter[] SaveParam = new SqlParameter[6];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            SaveParam[0] = new SqlParameter("@ClassName", SqlDbType.NVarChar, 100);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[0].Value = className;

            SaveParam[1] = new SqlParameter("@PcNameAdded", SqlDbType.NVarChar, 50);
            SaveParam[1].Value = pcNameWhoAdded;

            SaveParam[2] = new SqlParameter("@ClassWhoAdded", SqlDbType.Int);
            SaveParam[2].Value = classWhoAdded;

            SaveParam[3] = new SqlParameter("@ClassStatus", SqlDbType.Bit);
            SaveParam[3].Value = classStatus;

            SaveParam[4] = new SqlParameter("@Date", SqlDbType.NVarChar, 50);
            SaveParam[4].Value = classDate;

            SaveParam[5] = new SqlParameter("@Time", SqlDbType.NVarChar, 50);
            SaveParam[5].Value = classTime;


            //Execute Command Insert into Table ItemClassOfActions by DAL.CLS_ConnectionDB
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemClassEdit]", SaveParam);
        }

        /// <summary>
        /// Method To Delete Record From ItemClassOfActions Table Database
        /// </summary>
        /// <param name="classID">classID</param>
        public void DeleteClassOfAction(int classID)
        {
            //Create new instance from SqlParameter[]
            SqlParameter[] DeleteParam = new SqlParameter[1];

            DeleteParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            DeleteParam[0].Value = classID;

            //Execute Command To Delete Record from ItemClassOfActions Table Database
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemClassDelete]", DeleteParam);

        }

        /// <summary>
        /// Method To Update ItemClassOfActions Table by Modify ItemClassOfActionStatus Only (Deactivate ItemClassOfAction)
        /// </summary>
        /// <param name="classID">classID</param>
        /// <param name="classStatus">classStatus</param>
        public void DeactivateClassOfAction(int classID, bool classStatus)
        {
            //Create New Instance From SqlParameter [] array
            SqlParameter[] DeleteParam = new SqlParameter[2];

            DeleteParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            DeleteParam[0].Value = classID;

            DeleteParam[1] = new SqlParameter("@Status", SqlDbType.Bit);
            DeleteParam[1].Value = classStatus;

            //Execute Command to Update ItemClassOfActions table by In Activate ItemClassDeactivate
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemClassDeactivate]", DeleteParam);
        }
    }
}
