using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; // To Deal With DataTable or DataSet
using System.Data.SqlClient; // To Deal With Sql Databases

namespace PharmacySystemV20._0._1.BAL
{
    class CLS_Register
    {
        //Create new Instance From Singleton Class CLS_ConnectionDB() DataAccessLayer
        readonly DAL.CLS_ConnectionDB Connection = DAL.CLS_ConnectionDB.NewInstance();

        /// <summary>
        /// Int Function to Generate Register ID
        /// </summary>
        /// <returns>RegID</returns>
        public int GenerateRegisterID()
        {
            //int RegID without assignment any value
            int RegID;

            //Initialize return value of DataTable Function From DAL Connection.SelectData("storedProcedureName",SqlParameter[])
            //Assignment the value from DataTable Function After Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastRegID]", null).Rows[0][0].ToString())
            RegID = Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastRegID]", null).Rows[0][0].ToString());

            //return RegID;
            return RegID;
        }

        /// <summary>
        /// Method To Save User Register
        /// </summary>
        /// <param name="regID">regID</param>
        /// <param name="uid">userid</param>
        /// <param name="pcAdded">pcAdded</param>
        /// <param name="date">date</param>
        /// <param name="time">time</param>
        public void SaveUserRegister(int regID, int userID, string pcAdded, string date, string time)
        {
            //Create New Instance From SqlParameter[] which length of it is equal counter of storedprocedureparameter
            SqlParameter[] RegisterParam = new SqlParameter[5];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.Int, Size
            RegisterParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            RegisterParam[0].Value = regID;

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.Int, Size
            RegisterParam[1] = new SqlParameter("@UserID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            RegisterParam[1].Value = userID;

            RegisterParam[2] = new SqlParameter("@PcNameWhoAdded", SqlDbType.NVarChar, 50);
            RegisterParam[2].Value = pcAdded;

            RegisterParam[3] = new SqlParameter("@Date", SqlDbType.NVarChar, 50);
            RegisterParam[3].Value = date;

            RegisterParam[4] = new SqlParameter("@Time", SqlDbType.NVarChar, 50);
            RegisterParam[4].Value = time;

            //Execute Command Insert into Table Register by DAL.CLS_ConnectionDB
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_RegisterEdit]", RegisterParam);
        }

        /// <summary>
        /// DataTable Function To Search by IP Address Criteria
        /// To Get UserName and Password Automatic or Remember Login
        /// </summary>
        /// <param name="IPAddress">IPAddress</param>
        /// <returns>DataTable</returns>
        public DataTable SearchUserRegister(string IPAddress)
        {
            //Create New Instance From SqlParameter[]
            SqlParameter[] SearchParam = new SqlParameter[1];

            SearchParam[0] = new SqlParameter("@PcNameWhoAdded", SqlDbType.NVarChar, 50);
            SearchParam[0].Value = IPAddress;

            //Return DataTable which like search key
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_RegisterSearch]", SearchParam);
        }
    }
}
