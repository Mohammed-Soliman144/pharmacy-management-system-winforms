using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //To Deal With DataTables and DataSet
using System.Data.SqlClient; //To Deal With SQL Server Databases and SqlParameter

namespace PharmacySystemV20._0._1.BAL
{
    class CLS_ItemCompanies
    {
        //Create new Instance From Singleton Class CLS_ConnectionDB() DataAccessLayer
        readonly DAL.CLS_ConnectionDB Connection = DAL.CLS_ConnectionDB.NewInstance();

        /// <summary>
        /// DataTable Function to Select All Columns From ItemCompanies Table
        /// </summary>
        /// <returns>ItemCompanies Table</returns>
        public DataTable ShowItemCompanyTable()
        {
            /*Use DataTable Function from DAL.CLS_ConnectionDB to Select All Columns From ItemCompanies Table
             * no any StoredProcedur Parameters in StoredProcedure so Initialize null value
             * Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
             */
            // return Connection.SelectData("[PharmacyDB].[dbo].[SP_ItemCompanyShow]", null);
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_ItemCompanyShow]", null);
        }

        /// <summary>
        /// Method To Add New ItemCompany to ItemCompanies Table Database
        /// </summary>
        /// <param name="companyName">companyName</param>
        /// <param name="pcNameWhoAdded">pcNameWhoAdded</param>
        /// <param name="companyWhoAdded">companyWhoAdded</param>
        /// <param name="companyStatus">companyStatus</param>
        /// <param name="companyDate">companyDate</param>
        /// <param name="companyTime">companyTime</param>
        public void SaveCompany(string companyName, string pcNameWhoAdded, int companyWhoAdded,
                                     bool companyStatus, string companyDate, string companyTime)
        {
            //Create New Instance From SqlParameter[] which length of it is equal counter of storedprocedureparameter
            SqlParameter[] SaveParam = new SqlParameter[6];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 50
            SaveParam[0] = new SqlParameter("@CompanyName", SqlDbType.NVarChar, 100);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[0].Value = companyName;

            SaveParam[1] = new SqlParameter("@PcNameAdded", SqlDbType.NVarChar, 50);
            SaveParam[1].Value = pcNameWhoAdded;

            SaveParam[2] = new SqlParameter("@CompanyWhoAdded", SqlDbType.Int);
            SaveParam[2].Value = companyWhoAdded;

            SaveParam[3] = new SqlParameter("@CompanyStatus", SqlDbType.Bit);
            SaveParam[3].Value = companyStatus;

            SaveParam[4] = new SqlParameter("@Date", SqlDbType.NVarChar, 50);
            SaveParam[4].Value = companyDate;

            SaveParam[5] = new SqlParameter("@Time", SqlDbType.NVarChar, 50);
            SaveParam[5].Value = companyTime;


            //Execute Command Insert into Table ItemCompanies by DAL.CLS_ConnectionDB
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemCompanyEdit]", SaveParam);
        }

        /// <summary>
        /// Method To Delete Record From ItemCompanies Table Database
        /// </summary>
        /// <param name="itemCompanyID">itemCompanyID</param>
        public void DeleteCompany(int itemCompanyID)
        {
            //Create new instance from SqlParameter[]
            SqlParameter[] DeleteParam = new SqlParameter[1];

            DeleteParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            DeleteParam[0].Value = itemCompanyID;

            //Execute Command To Delete Record from ItemCompanies Table Database
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemCompanyDelete]", DeleteParam);

        }

        /// <summary>
        /// Method To Update ItemCompanies Table by Modify itemCompanyStatus Only (Deactivate itemCompany)
        /// </summary>
        /// <param name="itemCompanyID">itemCompanyID</param>
        /// <param name="itemCompanyStatus">itemCompanyStatus</param>
        public void DeactivateCompany(int itemCompanyID, bool itemCompanyStatus)
        {
            //Create New Instance From SqlParameter [] array
            SqlParameter[] DeleteParam = new SqlParameter[2];

            DeleteParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            DeleteParam[0].Value = itemCompanyID;

            DeleteParam[1] = new SqlParameter("@Status", SqlDbType.Bit);
            DeleteParam[1].Value = itemCompanyStatus;

            //Execute Command to Update ItemCompanies table by In Activate itemCompany
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_ItemCompanyDeactivate]", DeleteParam);
        }
    }
}
