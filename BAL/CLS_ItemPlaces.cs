using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //To Deal With DataTables and DataSet
using System.Data.SqlClient; //To Deal With SQL Server Databases and SqlParameter

namespace PharmacySystemV20._0._1.BAL
{
    class CLS_ItemPlaces
    {
        //Create new Instance From Singleton Class CLS_ConnectionDB() DataAccessLayer
        readonly DAL.CLS_ConnectionDB Connection = DAL.CLS_ConnectionDB.NewInstance();

        /// <summary>
        /// DataTable Function to Select All Columns From ItemPlaces Table
        /// </summary>
        /// <returns>ItemPlaces Table</returns>
        public DataTable ShowItemPlaceTable()
        {
            /*Use DataTable Function from DAL.CLS_ConnectionDB to Select All Columns From ItemPlaces Table
             * no any StoredProcedur Parameters in StoredProcedure so Initialize null value
             * Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
             */
            // return Connection.SelectData("[PharmacyDB].[dbo].[SP_ItemPlaceShow]", null);
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_ItemPlaceShow]", null);
        }

        /// <summary>
        /// Method To Add New itemPlace to ItemPlaces Table Database
        /// </summary>
        /// <param name="placeName">placeName</param>
        /// <param name="pcNameWhoAdded">pcNameWhoAdded</param>
        /// <param name="placeWhoAdded">placeWhoAdded</param>
        /// <param name="placeStatus">placeStatus</param>
        /// <param name="placeDate">placeDate</param>
        /// <param name="placeTime">placeTime</param>
        public void SavePlace(string placeName, string pcNameWhoAdded, int placeWhoAdded,
                                     bool placeStatus, string placeDate, string placeTime)
        {
            //Create New Instance From SqlParameter[] which length of it is equal counter of storedprocedureparameter
            SqlParameter[] SaveParam = new SqlParameter[6];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            SaveParam[0] = new SqlParameter("@PlaceName", SqlDbType.NVarChar, 100);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[0].Value = placeName;

            SaveParam[1] = new SqlParameter("@PcNameAdded", SqlDbType.NVarChar, 50);
            SaveParam[1].Value = pcNameWhoAdded;

            SaveParam[2] = new SqlParameter("@PlaceWhoAdded", SqlDbType.Int);
            SaveParam[2].Value = placeWhoAdded;

            SaveParam[3] = new SqlParameter("@PlaceStatus", SqlDbType.Bit);
            SaveParam[3].Value = placeStatus;

            SaveParam[4] = new SqlParameter("@Date", SqlDbType.NVarChar, 50);
            SaveParam[4].Value = placeDate;

            SaveParam[5] = new SqlParameter("@Time", SqlDbType.NVarChar, 50);
            SaveParam[5].Value = placeTime;


            //Execute Command Insert into Table ItemPlaces by DAL.CLS_ConnectionDB
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemPlaceEdit]", SaveParam);
        }

        /// <summary>
        /// Method To Delete Record From ItemPlaces Table Database
        /// </summary>
        /// <param name="itemPlaceID">itemPlaceID</param>
        public void DeletePlace(int itemPlaceID)
        {
            //Create new instance from SqlParameter[]
            SqlParameter[] DeleteParam = new SqlParameter[1];

            DeleteParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            DeleteParam[0].Value = itemPlaceID;

            //Execute Command To Delete Record from ItemPlaces Table Database
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemPlaceDelete]", DeleteParam);

        }

        /// <summary>
        /// Method To Update ItemPlaces Table by Modify itemPlaceStatus Only (Deactivate itemPlace)
        /// </summary>
        /// <param name="itemPlaceID">itemPlaceID</param>
        /// <param name="itemPlaceStatus">itemPlaceStatus</param>
        public void DeactivatePlace(int itemPlaceID, bool itemPlaceStatus)
        {
            //Create New Instance From SqlParameter [] array
            SqlParameter[] DeleteParam = new SqlParameter[2];

            DeleteParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            DeleteParam[0].Value = itemPlaceID;

            DeleteParam[1] = new SqlParameter("@Status", SqlDbType.Bit);
            DeleteParam[1].Value = itemPlaceStatus;

            //Execute Command to Update ItemPlaces table by In Activate itemPlace
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemPlaceDeactivate]", DeleteParam);
        }
    }
}
