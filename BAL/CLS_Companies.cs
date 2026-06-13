using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //To Deal With DataTables and DataSet
using System.Data.SqlClient; //To Deal With SQL Server Databases and SqlParameter


namespace PharmacySystemV20._0._1.BAL
{
    class CLS_Companies
    {
        //Create new Instance From Singleton Class CLS_ConnectionDB() DataAccessLayer
        readonly DAL.CLS_ConnectionDB Connection = DAL.CLS_ConnectionDB.NewInstance();

        /// <summary>
        /// DataTable Function to Select All Records From Companies Table
        /// </summary>
        /// <returns>Companies Table</returns>
        public DataTable ShowCompaniesTable()
        {
            /*Use DataTable Function from DAL.CLS_ConnectionDB to Select All Columns From Companies Table
             * no any StoredProcedur Parameters in StoredProcedure so Initialize null value
             * Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
             */
            // return Connection.SelectData("[PharmacyDB].[dbo].[SP_CompanyShow]", null);
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_CompanyShow]", null);
        }

        /// <summary>
        /// String Function to generate Company ID
        /// </summary>
        /// <returns>CompanyID</returns>
        public string GenerateCompanyID()
        {
            //int CompanyID without assignment any value
            int CompanyID;

            //Initialize return value of DataTable Function From DAL Connection.SelectData("storedProcedureName",SqlParameter[])
            //Assignment the value from DataTable Function After Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastCompID]", null).Rows[0][0].ToString())
            CompanyID = Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastCompID]", null).Rows[0][0].ToString());

            //return BranchID.ToString("FormatName-000000");
            return CompanyID.ToString("Comp-000000");
        }

        /// <summary>
        /// Method To Add New Companies Or Save new Company
        /// </summary>
        /// <param name="companyCode">companyCode</param>
        /// <param name="companyName">companyName</param>
        /// <param name="companyPhone1">companyPhone1</param>
        /// <param name="companyPhone2">companyPhone2</param>
        /// <param name="companyPhone3">companyPhone3</param>
        /// <param name="companyFax">companyFax</param>
        /// <param name="companyEmail">companyEmail</param>
        /// <param name="companyWeb">companyWeb</param>
        /// <param name="companyAddress">companyAddress</param>
        /// <param name="companyManager">companyManager</param>
        /// <param name="companyLogo">companyLogo</param>
        /// <param name="companyStatusImg">companyStatusImg</param>
        /// <param name="companyType">companyType</param>
        /// <param name="companyCategory">companyCategory</param>
        /// <param name="companyCommerical">companyCommerical</param>
        /// <param name="companyTax">companyTax</param>
        /// <param name="companyCity">companyCity</param>
        /// <param name="companyCountry">companyCountry</param>
        /// <param name="companyStartDate">companyStartDate</param>
        /// <param name="companyEndDate">companyEndDate</param>
        /// <param name="pcNameWhoAdded">pcNameWhoAdded</param>
        /// <param name="companyWhoAdded">companyWhoAdded</param>
        /// <param name="companyDate">companyDate</param>
        /// <param name="companyTime">companyTime</param>
        public void SaveCompanies(string companyCode, string companyName, string companyPhone1, string companyPhone2,
                                  string companyPhone3, string companyFax, string companyEmail, string companyWeb, 
                                  string companyAddress, int companyManager, byte[] companyLogo, string companyStatusImg,
                                  string companyType, string companyCategory, string companyCommerical, string companyTax,
                                  string companyCity, string companyCountry, string companyStartDate, string companyEndDate,
                                  string pcNameWhoAdded, int companyWhoAdded, string companyDate, string companyTime)
        {
            //Create New Instance From SqlParameter[] which length of it is equal counter of storedprocedureparameter
            SqlParameter[] SaveParam = new SqlParameter[24];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            SaveParam[0] = new SqlParameter("@CustomID", SqlDbType.NVarChar, 50);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[0].Value = companyCode;

            SaveParam[1] = new SqlParameter("@CompName", SqlDbType.NVarChar, 100);
            SaveParam[1].Value = companyName;

            SaveParam[2] = new SqlParameter("@CompPhoneN1", SqlDbType.NVarChar, 25);
            SaveParam[2].Value = companyPhone1;

            SaveParam[3] = new SqlParameter("@CompPhoneN2", SqlDbType.NVarChar, 25);
            SaveParam[3].Value = companyPhone2;

            SaveParam[4] = new SqlParameter("@CompPhoneN3", SqlDbType.NVarChar, 25);
            SaveParam[4].Value = companyPhone3;

            SaveParam[5] = new SqlParameter("@CompFax", SqlDbType.NVarChar, 25);
            SaveParam[5].Value = companyFax;

            SaveParam[6] = new SqlParameter("@CompEmail", SqlDbType.VarChar, 80);
            SaveParam[6].Value = companyEmail;

            SaveParam[7] = new SqlParameter("@CompWeb", SqlDbType.VarChar, 100);
            SaveParam[7].Value = companyWeb;

            SaveParam[8] = new SqlParameter("@CompAddress", SqlDbType.NVarChar, 120);
            SaveParam[8].Value = companyAddress;

            SaveParam[9] = new SqlParameter("@CompManager", SqlDbType.Int);
            SaveParam[9].Value = companyManager;

            SaveParam[10] = new SqlParameter("@CompLogo", SqlDbType.Image);
            SaveParam[10].Value = companyLogo;

            SaveParam[11] = new SqlParameter("@CompImgStatus", SqlDbType.VarChar, 25);
            SaveParam[11].Value = companyStatusImg;

            SaveParam[12] = new SqlParameter("@CompType", SqlDbType.NVarChar, 25);
            SaveParam[12].Value = companyType;

            SaveParam[13] = new SqlParameter("@CompCategory", SqlDbType.NVarChar, 25);
            SaveParam[13].Value = companyCategory;

            SaveParam[14] = new SqlParameter("@CompCommerical", SqlDbType.NVarChar, 50);
            SaveParam[14].Value = companyCommerical;

            SaveParam[15] = new SqlParameter("@CompTax", SqlDbType.NVarChar, 50);
            SaveParam[15].Value = companyTax;

            SaveParam[16] = new SqlParameter("@CompCity", SqlDbType.NVarChar, 25);
            SaveParam[16].Value = companyCity;

            SaveParam[17] = new SqlParameter("@CompCountry", SqlDbType.NVarChar, 25);
            SaveParam[17].Value = companyCountry;

            SaveParam[18] = new SqlParameter("@CompFinStartDate", SqlDbType.NVarChar, 50);
            SaveParam[18].Value = companyStartDate;

            SaveParam[19] = new SqlParameter("@CompFinEndDate", SqlDbType.NVarChar, 50);
            SaveParam[19].Value = companyEndDate;

            SaveParam[20] = new SqlParameter("@PCNameWhoAdded", SqlDbType.NVarChar, 50);
            SaveParam[20].Value = pcNameWhoAdded;

            SaveParam[21] = new SqlParameter("@CompWhoAdded", SqlDbType.Int);
            SaveParam[21].Value = companyWhoAdded;

            SaveParam[22] = new SqlParameter("@Date", SqlDbType.NVarChar, 50);
            SaveParam[22].Value = companyDate;

            SaveParam[23] = new SqlParameter("@Time", SqlDbType.NVarChar, 50);
            SaveParam[23].Value = companyTime;

            //Execute Command Insert into Table Branches by DAL.CLS_ConnectionDB
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_CompanyEdit]", SaveParam);
        }

        /// <summary>
        /// Method To Delete Record From Companies Table
        /// </summary>
        /// <param name="CompanyID">CompanyID</param>
        public void DeleteCompanies(int CompanyID)
        {
            //Create new instance from SqlParameter[]
            SqlParameter[] DeleteParam = new SqlParameter[1];

            DeleteParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            DeleteParam[0].Value = CompanyID;

            //Execute Command To Delete Record from Companies Table
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_CompanyDelete]", DeleteParam);

        }

        /// <summary>
        /// Method To Update Companies Table 
        /// </summary>
        /// <param name="companyCode">companyCode</param>
        /// <param name="companyName">companyName</param>
        /// <param name="companyPhone1">companyPhone1</param>
        /// <param name="companyPhone2">companyPhone2</param>
        /// <param name="companyPhone3">companyPhone3</param>
        /// <param name="companyFax">companyFax</param>
        /// <param name="companyEmail">companyEmail</param>
        /// <param name="companyWeb">companyWeb</param>
        /// <param name="companyAddress">companyAddress</param>
        /// <param name="companyManager">companyManager</param>
        /// <param name="companyLogo">companyLogo</param>
        /// <param name="companyStatusImg">companyStatusImg</param>
        /// <param name="companyType">companyType</param>
        /// <param name="companyCategory">companyCategory</param>
        /// <param name="companyCommerical">companyCommerical</param>
        /// <param name="companyTax">companyTax</param>
        /// <param name="companyCity">companyCity</param>
        /// <param name="companyCountry">companyCountry</param>
        /// <param name="companyStartDate">companyStartDate</param>
        /// <param name="companyEndDate">companyEndDate</param>
        /// <param name="pcNameWhoModified">pcNameWhoModified</param>
        /// <param name="companyWhoModified">companyWhoModified</param>
        public void UpdateCompanies ( int companyID, string companyName, string companyPhone1, string companyPhone2,
                                      string companyPhone3, string companyFax, string companyEmail, string companyWeb,
                                      string companyAddress, int companyManager, byte[] companyLogo, string companyStatusImg,
                                      string companyType, string companyCategory, string companyCommerical, string companyTax,
                                      string companyCity, string companyCountry, string companyStartDate, string companyEndDate,
                                      string pcNameWhoModified, int companyWhoModified)
        {
            //Create New Instance From SqlParameter[]
            SqlParameter[] UpdateParam = new SqlParameter[22];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            UpdateParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[0].Value = companyID;

            UpdateParam[1] = new SqlParameter("@CompName", SqlDbType.NVarChar, 100);
            UpdateParam[1].Value = companyName;

            UpdateParam[2] = new SqlParameter("@CompPhoneN1", SqlDbType.NVarChar, 25);
            UpdateParam[2].Value = companyPhone1;

            UpdateParam[3] = new SqlParameter("@CompPhoneN2", SqlDbType.NVarChar, 25);
            UpdateParam[3].Value = companyPhone2;

            UpdateParam[4] = new SqlParameter("@CompPhoneN3", SqlDbType.NVarChar, 25);
            UpdateParam[4].Value = companyPhone3;

            UpdateParam[5] = new SqlParameter("@CompFax", SqlDbType.NVarChar, 25);
            UpdateParam[5].Value = companyFax;

            UpdateParam[6] = new SqlParameter("@CompEmail", SqlDbType.VarChar, 80);
            UpdateParam[6].Value = companyEmail;

            UpdateParam[7] = new SqlParameter("@CompWeb", SqlDbType.VarChar, 100);
            UpdateParam[7].Value = companyWeb;

            UpdateParam[8] = new SqlParameter("@CompAddress", SqlDbType.NVarChar, 120);
            UpdateParam[8].Value = companyAddress;

            UpdateParam[9] = new SqlParameter("@CompManager", SqlDbType.Int);
            UpdateParam[9].Value = companyManager;

            UpdateParam[10] = new SqlParameter("@CompLogo", SqlDbType.Image);
            UpdateParam[10].Value = companyLogo;

            UpdateParam[11] = new SqlParameter("@CompImgStatus", SqlDbType.VarChar, 25);
            UpdateParam[11].Value = companyStatusImg;

            UpdateParam[12] = new SqlParameter("@CompType", SqlDbType.NVarChar, 25);
            UpdateParam[12].Value = companyType;

            UpdateParam[13] = new SqlParameter("@CompCategory", SqlDbType.NVarChar, 25);
            UpdateParam[13].Value = companyCategory;

            UpdateParam[14] = new SqlParameter("@CompCommerical", SqlDbType.NVarChar, 50);
            UpdateParam[14].Value = companyCommerical;

            UpdateParam[15] = new SqlParameter("@CompTax", SqlDbType.NVarChar, 50);
            UpdateParam[15].Value = companyTax;

            UpdateParam[16] = new SqlParameter("@CompCity", SqlDbType.NVarChar, 25);
            UpdateParam[16].Value = companyCity;

            UpdateParam[17] = new SqlParameter("@CompCountry", SqlDbType.NVarChar, 25);
            UpdateParam[17].Value = companyCountry;

            UpdateParam[18] = new SqlParameter("@CompFinStartDate", SqlDbType.NVarChar, 50);
            UpdateParam[18].Value = companyStartDate;

            UpdateParam[19] = new SqlParameter("@CompFinEndDate", SqlDbType.NVarChar, 50);
            UpdateParam[19].Value = companyEndDate;

            UpdateParam[20] = new SqlParameter("@PCNameWhoModified", SqlDbType.NVarChar, 50);
            UpdateParam[20].Value = pcNameWhoModified;

            UpdateParam[21] = new SqlParameter("@CompWhoModified", SqlDbType.Int);
            UpdateParam[21].Value = companyWhoModified;

            //Execute Command to Update any Record of Companies Table by CompanyID
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_CompanyUpdate]", UpdateParam);
        }

        /// <summary>
        /// DataTable Function To Advanced Search in Companies Table
        /// Recieve Two Parameters Column Name and Search Key
        /// Two Ways To Search Indentical (=) and Not Indentical (LIKE '%'+ @searchKey + '%';)
        /// </summary>
        /// <param name="ColumnName">ColumnName</param>
        /// <param name="SearchKey">SearchKey</param>
        /// <returns>DataTable</returns>
        public DataTable SearchCompanies(string columnName, string searchKey)
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
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_CompanySearch]", SearchParam);
        }
    }
}
