using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; // To Deal With DataTable or DataSet
using System.Data.SqlClient; // To Deal With Sql Databases
using System.Drawing;

namespace PharmacySystemV20._0._1.BAL
{
    class CLS_Users
    {
        //Create new Instance From Singleton Class CLS_ConnectionDB() DataAccessLayer
        readonly DAL.CLS_ConnectionDB Connection = DAL.CLS_ConnectionDB.NewInstance();

        /// <summary>
        /// DataTable Function to Select All Columns From Users Table
        /// </summary>
        /// <returns>UsersTable</returns>
        public DataTable ShowUsersTable()
        {
            /*Use DataTable Function from DAL.CLS_ConnectionDB to Select All Columns From Users Table
             * no any StoredProcedur Parameters in StoredProcedure so Initialize null value
             * Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
             */

            // return Connection.SelectData("[PharmacyDB].[dbo].[SP_UserShow]", null); other way
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_UserShow]", null);
        }

        /// <summary>
        /// Int Function to generate User ID
        /// </summary>
        /// <returns>userID</returns>
        public int GenerateUserID()
        {
            //int UserID and Initialize Zero Value to it
            int UserID;

            //Initialize return value of DataTable Function From DAL Connection.SelectData("storedProcedureName",SqlParameter[])
            //Assignment the value from DataTable Function After Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastUserID]", null).Rows[0][0].ToString())
            UserID = Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastUserID]", null).Rows[0][0].ToString());

            //return UserID;
            return UserID;
        }

        /// <summary>
        /// Method To Add New User
        /// </summary>
        /// <param name="uid">userid</param>
        /// <param name="rule">rule</param>
        /// <param name="custCode">custCode</param>
        /// <param name="name">fullname</param>
        /// <param name="phone">phone</param>
        /// <param name="job">job</param>
        /// <param name="gender">gender</param>
        /// <param name="address">address</param>
        /// <param name="natid">natid</param>
        /// <param name="uprogram">uprogram</param>
        /// <param name="uname">username</param>
        /// <param name="pass">password</param>
        /// <param name="date">date</param>
        /// <param name="time">time</param>
        /// <param name="checkImg"></param>
        /// <param name="img"></param>
        /// <param name="pcAdded">pcAdded</param>
        /// <param name="userAdded">userAdded</param>
        public void SaveUsers(int uID, int rule, string custCode, string name, string phone, string job, string gender,
                              string address, string natID, bool uProgram, string uName, 
                              string pass, string date, string time, string checkImg, byte[] img,
                              string pcAdded , int userAdded)
        {
            //Create New Instance From SqlParameter[] which length of it is equal counter of storedprocedureparameter
            SqlParameter[] SaveParam = new SqlParameter[18];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.Int, Size
            SaveParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[0].Value = uID;

            SaveParam[1] = new SqlParameter("@Rule", SqlDbType.Int);
            SaveParam[1].Value = rule;

            SaveParam[2] = new SqlParameter("@CustomeCode", SqlDbType.NVarChar, 50);
            SaveParam[2].Value = custCode;

            SaveParam[3] = new SqlParameter("@FullName", SqlDbType.NVarChar, 100);
            SaveParam[3].Value = name;

            SaveParam[4] = new SqlParameter("@Phone", SqlDbType.NVarChar, 25);
            SaveParam[4].Value = phone;

            SaveParam[5] = new SqlParameter("@Job", SqlDbType.NVarChar, 25);
            SaveParam[5].Value = job;

            SaveParam[6] = new SqlParameter("@Gender", SqlDbType.NVarChar, 5);
            SaveParam[6].Value = gender;

            SaveParam[7] = new SqlParameter("@Address", SqlDbType.NVarChar, 120);
            SaveParam[7].Value = address;

            SaveParam[8] = new SqlParameter("@Identification", SqlDbType.NVarChar, 20);
            SaveParam[8].Value = natID;

            SaveParam[9] = new SqlParameter("@UserForPro", SqlDbType.Bit);
            SaveParam[9].Value = uProgram;

            SaveParam[10] = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
            SaveParam[10].Value = uName;

            SaveParam[11] = new SqlParameter("@Pass", SqlDbType.NVarChar, 50);
            SaveParam[11].Value = pass;

            SaveParam[12] = new SqlParameter("@Date", SqlDbType.NVarChar, 50);
            SaveParam[12].Value = date;

            SaveParam[13] = new SqlParameter("@Time", SqlDbType.NVarChar, 50);
            SaveParam[13].Value = time;

            SaveParam[14] = new SqlParameter("@CheckImg", SqlDbType.NVarChar, 15);
            SaveParam[14].Value = checkImg;

            SaveParam[15] = new SqlParameter("@Img", SqlDbType.Image);
            SaveParam[15].Value = img;

            SaveParam[16] = new SqlParameter("@PCAdded", SqlDbType.NVarChar, 50);
            SaveParam[16].Value = pcAdded;

            SaveParam[17] = new SqlParameter("@UserAdded", SqlDbType.Int);
            SaveParam[17].Value = userAdded;

            //Execute Command Insert into Table Users by DAL.CLS_ConnectionDB
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_UserEdit]", SaveParam);
        }

        /// <summary>
        /// Method To Delete Record From users Table
        /// </summary>
        /// <param name="uid">userID</param>
        public void DeleteUsers(int uID)
        {
            //Create new instance from SqlParameter[]
            SqlParameter[] DeleteParam = new SqlParameter[1];

            DeleteParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            DeleteParam[0].Value = uID;

            //Execute Command To Delete Record from Users Table
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_UserDelete]",DeleteParam);

        }

        /// <summary>
        /// Method To Update Users Table by Inactivate Users Only
        /// </summary>
        /// <param name="uID">uID</param>
        /// <param name="status">status</param>
        /// <param name="pcDeleted">pcDeleted</param>
        /// <param name="userDeleted">userDeleted</param>
        public void InActivateUsers(int uID, bool status, string pcDeleted, int userDeleted)
        {
            //Create New Instance From SqlParameter [] array
            SqlParameter[] DeleteParam = new SqlParameter[4];

            DeleteParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            DeleteParam[0].Value = uID;

            DeleteParam[1] = new SqlParameter("@Status", SqlDbType.Bit);
            DeleteParam[1].Value = status;

            DeleteParam[2] = new SqlParameter("@PCDeleted", SqlDbType.NVarChar, 50);
            DeleteParam[2].Value = pcDeleted;

            DeleteParam[3] = new SqlParameter("@UserDeleted", SqlDbType.Int);
            DeleteParam[3].Value = userDeleted;

            //Execute Command to Update Users table by In Activate Users
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_UserInActivate]", DeleteParam);

        }

        /// <summary>
        /// Method To Update Users Table
        /// </summary>
        /// <param name="uid">userid</param>
        /// <param name="fullName">fullname</param>
        /// <param name="phone">phone</param>
        /// <param name="job">job</param>
        /// <param name="gender">gender</param>
        /// <param name="address">address</param>
        /// <param name="natid">natid</param>
        /// <param name="uprogram">uprogram</param>
        /// <param name="uname">username</param>
        /// <param name="pass">password</param>
        /// <param name="checkImg">checkImg</param>
        /// <param name="img">img</param>
        /// <param name="pcModified">pcModified</param>
        /// <param name="userModified">userModified</param>
        public void UpdateUsers(int uID, int rule, string fullName, string phone, string job, string gender,
                                string address, string natID, bool uProgram, string uName, string pass,
                                string checkImg, byte[] img, string pcModified, int userModified)
        {
            //Create New Instance From SqlParameter[]
            SqlParameter[] UpdateParam = new SqlParameter[15];

            UpdateParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            UpdateParam[0].Value = uID;

            UpdateParam[1] = new SqlParameter("@Rule", SqlDbType.Int);
            UpdateParam[1].Value = rule;

            UpdateParam[2] = new SqlParameter("@FullName", SqlDbType.NVarChar,100);
            UpdateParam[2].Value = fullName;

            UpdateParam[3] = new SqlParameter("@Phone", SqlDbType.NVarChar, 25);
            UpdateParam[3].Value = phone;

            UpdateParam[4] = new SqlParameter("@Job", SqlDbType.NVarChar, 25);
            UpdateParam[4].Value = job;

            UpdateParam[5] = new SqlParameter("@Gender", SqlDbType.NVarChar, 5);
            UpdateParam[5].Value = gender;

            UpdateParam[6] = new SqlParameter("@Address", SqlDbType.NVarChar, 120);
            UpdateParam[6].Value = address;

            UpdateParam[7] = new SqlParameter("@Identification", SqlDbType.NVarChar, 20);
            UpdateParam[7].Value = natID;

            UpdateParam[8] = new SqlParameter("@UserForPro", SqlDbType.Bit);
            UpdateParam[8].Value = uProgram;

            UpdateParam[9] = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
            UpdateParam[9].Value = uName;

            UpdateParam[10] = new SqlParameter("@Pass", SqlDbType.NVarChar, 50);
            UpdateParam[10].Value = pass;

            UpdateParam[11] = new SqlParameter("@CheckImg", SqlDbType.NVarChar, 15);
            UpdateParam[11].Value = checkImg;

            UpdateParam[12] = new SqlParameter("@Img", SqlDbType.Image);
            UpdateParam[12].Value = img;

            UpdateParam[13] = new SqlParameter("@PCModified", SqlDbType.NVarChar, 50);
            UpdateParam[13].Value = pcModified;

            UpdateParam[14] = new SqlParameter("@UserModified", SqlDbType.Int);
            UpdateParam[14].Value = userModified;

            //Execute Command to Update any Record of Users Table by UserID
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_UserUpdate]", UpdateParam);
        }

        /// <summary>
        /// DataTable Function To Search by more one Criteria
        /// </summary>
        /// <param name="SearchKey">SearchKey</param>
        /// <returns>DataTable</returns>
        public DataTable SearchUsers(string SearchKey)
        {
            //Create New Instance From SqlParameter[]
            SqlParameter[] SearchParam = new SqlParameter[1];

            SearchParam[0] = new SqlParameter("@SearchKey", SqlDbType.NVarChar, 100);
            SearchParam[0].Value = SearchKey;

            //Return DataTable which like search key
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_UserSearch]", SearchParam);
        }

        /// <summary>
        /// DataTable Function To check users login
        /// </summary>
        /// <param name="user">UserName</param>
        /// <param name="pass">Password</param>
        /// <returns>DataTable by Data of user</returns>
        public DataTable CheckLogin(string user, string pass)
        {
            //Create New Instance From SqlParameter[]
            SqlParameter[] LoginParam = new SqlParameter[2];

            //UserName
            LoginParam[0] = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
            LoginParam[0].Value = user;
            //Password
            LoginParam[1] = new SqlParameter("@Password", SqlDbType.NVarChar, 25);
            LoginParam[1].Value = pass;

            //Return DataTable which like search key
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_UserCheckLogin]", LoginParam);
        }

        /// <summary>
        /// DataTable Function To Search by Phone number to Recovery User Name and password
        /// </summary>
        /// <param name="PhoneNo">PhoneNo</param>
        /// <returns>DataTable</returns>
        public DataTable RecoveryUser(string PhoneNo)
        {
            //Create New Instance From SqlParameter[]
            SqlParameter[] SearchParam = new SqlParameter[1];

            SearchParam[0] = new SqlParameter("@Phone", SqlDbType.NVarChar, 25);
            SearchParam[0].Value = PhoneNo;

            //Return DataTable which like search key
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_UserRecovery]", SearchParam);
        }
    }
}
