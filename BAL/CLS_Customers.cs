using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //To Deal With DataTable and DataSet etc.....
using System.Data.SqlClient; //To Deal With Sql Server Database

namespace PharmacySystemV20._0._1.BAL
{
    class CLS_Customers
    {
        //Create new Instance From Singleton Class CLS_ConnectionDB() DataAccessLayer
        readonly DAL.CLS_ConnectionDB Connection = DAL.CLS_ConnectionDB.NewInstance();

        /// <summary>
        /// DataTable Function to Select All Columns From Customers Table
        /// </summary>
        /// <returns>CustomersTable</returns>
        public DataTable ShowCustomersTable()
        {
            /*Use DataTable Function from DAL.CLS_ConnectionDB to Select All Columns From Customers Table
             * no any StoredProcedur Parameters in StoredProcedure so Initialize null value
             * Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
             */
            // return Connection.SelectData("[PharmacyDB].[dbo].[SP_CustomerShow]", null);
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_CustomerShow]", null); 
        }

        /// <summary>
        /// Int Function to generate Customer ID
        /// </summary>
        /// <returns>CustomerID</returns>
        public string GenerateCustomerID()
        {
            //int CustomerID without assignment any value
            int CustomerID;

            //Initialize return value of DataTable Function From DAL Connection.SelectData("storedProcedureName",SqlParameter[])
            //Assignment the value from DataTable Function After Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastCustID]", null).Rows[0][0].ToString())
            CustomerID = Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastCustID]", null).Rows[0][0].ToString());

            //return CustomerID.ToString("FormatName-000000");
            return CustomerID.ToString("CUST-000000");
        }

        /// <summary>
        /// Method To Add New Customer Or Save new Customer
        /// </summary>
        /// <param name="custID">custID</param>
        /// <param name="custCode">custCode</param>
        /// <param name="custName">custName</param>
        /// <param name="custPhone1">custPhone1</param>
        /// <param name="custPhone2">custPhone2</param>
        /// <param name="custFax">custFax</param>
        /// <param name="custAddress">custAddress</param>
        /// <param name="custEmail">custEmail</param>
        /// <param name="custType">custType</param>
        /// <param name="custCompany">custCompany</param>
        /// <param name="custLimit"></param>
        /// <param name="custDiscount">custDiscount</param>
        /// <param name="custDebStatus">custDebStatus</param>
        /// <param name="custBalance">custBalance</param>
        /// <param name="custNotes">custNotes</param>
        /// <param name="pcNameWhoAdded">pcNameWhoAdded</param>
        /// <param name="customerWhoAdded">customerWhoAdded</param>
        /// <param name="custDate">custDate</param>
        /// <param name="custTime">custTime</param>
        public void SaveCustomers(int custID, string custCode, string custName, string custPhone1, string custPhone2,
                                  string custFax, string custAddress, string custEmail, string custType,
                                  string custCompany, decimal custLimit, string custDiscount,  bool custDebStatus, decimal custBalance,
                                  string custNotes,string pcNameWhoAdded, int customerWhoAdded, string custDate,
                                  string custTime)
        {

            //Create New Instance From SqlParameter[] which length of it is equal counter of storedprocedureparameter
            SqlParameter[] SaveParam = new SqlParameter[19];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            SaveParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[0].Value = custID;

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            SaveParam[1] = new SqlParameter("@CustCode", SqlDbType.NVarChar, 50);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[1].Value = custCode;

            SaveParam[2] = new SqlParameter("@CustName", SqlDbType.NVarChar, 100);
            SaveParam[2].Value = custName;

            SaveParam[3] = new SqlParameter("@CustPhone1", SqlDbType.NVarChar, 25);
            SaveParam[3].Value = custPhone1;

            SaveParam[4] = new SqlParameter("@CustPhone2", SqlDbType.NVarChar, 25);
            SaveParam[4].Value = custPhone2;

            SaveParam[5] = new SqlParameter("@CustFax", SqlDbType.NVarChar, 25);
            SaveParam[5].Value = custFax;

            SaveParam[6] = new SqlParameter("@CustAddress", SqlDbType.NVarChar, 100);
            SaveParam[6].Value = custAddress;

            SaveParam[7] = new SqlParameter("@CustEmail", SqlDbType.VarChar, 80);
            SaveParam[7].Value = custEmail;

            SaveParam[8] = new SqlParameter("@CustType", SqlDbType.NVarChar, 25);
            SaveParam[8].Value = custType;

            SaveParam[9] = new SqlParameter("@CustCompany", SqlDbType.NVarChar,75);
            SaveParam[9].Value = custCompany;

            SaveParam[10] = new SqlParameter("@CustLimit", SqlDbType.Decimal);
            SaveParam[10].Value = custLimit;

            SaveParam[11] = new SqlParameter("@CustDiscount", SqlDbType.NVarChar, 15);
            SaveParam[11].Value = custDiscount;

            SaveParam[12] = new SqlParameter("@CustDebStatus", SqlDbType.Bit);
            SaveParam[12].Value = custDebStatus;

            SaveParam[13] = new SqlParameter("@CustBalance", SqlDbType.Decimal);
            SaveParam[13].Value = custBalance;

            SaveParam[14] = new SqlParameter("@CustNotes", SqlDbType.NVarChar, 75);
            SaveParam[14].Value = custNotes;

            SaveParam[15] = new SqlParameter("@PCNameWhoAdded", SqlDbType.NVarChar, 50);
            SaveParam[15].Value = pcNameWhoAdded;

            SaveParam[16] = new SqlParameter("@CustomerWhoAdded", SqlDbType.Int);
            SaveParam[16].Value = customerWhoAdded;

            SaveParam[17] = new SqlParameter("@CustDate", SqlDbType.NVarChar, 50);
            SaveParam[17].Value = custDate;

            SaveParam[18] = new SqlParameter("@CustTime", SqlDbType.NVarChar, 50);
            SaveParam[18].Value = custTime;

            //Execute Command Insert into Table Users by DAL.CLS_ConnectionDB
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_CustomerEdit]", SaveParam);
        }


        /// <summary>
        /// Method To Delete Record From Customer Table
        /// </summary>
        /// <param name="custID">CustomerID</param>
        public void DeleteCustomers(int custID)
        {
            //Create new instance from SqlParameter[]
            SqlParameter[] DeleteParam = new SqlParameter[1];

            DeleteParam[0] = new SqlParameter("@CustID", SqlDbType.Int);
            DeleteParam[0].Value = custID;

            //Execute Command To Delete Record from Customers Table
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_CustomerDelete]", DeleteParam);

        }

        /// <summary>
        /// Method To Update Customers Table by Modify CustomerStatus Only (Deactivate Customer)
        /// </summary>
        /// <param name="custID">custID</param>
        /// <param name="pcNameWhoDeleted">pcNameWhoDeleted</param>
        /// <param name="customerWhoDeleted">customerWhoDeleted</param>
        public void DeactivateCustomers(int custID,bool custStatus, string pcNameWhoDeleted, int customerWhoDeleted)
        {
            //Create New Instance From SqlParameter [] array
            SqlParameter[] DeleteParam = new SqlParameter[4];

            DeleteParam[0] = new SqlParameter("@CustID", SqlDbType.Int);
            DeleteParam[0].Value = custID;

            DeleteParam[1] = new SqlParameter("@CustStatus", SqlDbType.Bit);
            DeleteParam[1].Value = custStatus;

            DeleteParam[2] = new SqlParameter("@PCNameWhoDeleted", SqlDbType.NVarChar, 50);
            DeleteParam[2].Value = pcNameWhoDeleted;

            DeleteParam[3] = new SqlParameter("@CustomerWhoDeleted", SqlDbType.Int);
            DeleteParam[3].Value = customerWhoDeleted;

            //Execute Command to Update Users table by In Activate Customers
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_CustomerDeactivate]", DeleteParam);

        }

        /// <summary>
        /// Method To Update Customers Table
        /// </summary>
        /// <param name="custID">custID</param>
        /// <param name="custCode">custCode</param>
        /// <param name="custName">custName</param>
        /// <param name="custPhone1">custPhone1</param>
        /// <param name="custPhone2">custPhone2</param>
        /// <param name="custFax">custFax</param>
        /// <param name="custAddress">custAddress</param>
        /// <param name="custEmail">custEmail</param>
        /// <param name="custType">custType</param>
        /// <param name="custCompany">custCompany</param>
        /// <param name="custLimit">custLimit</param>
        /// <param name="custDiscount">custDiscount</param>
        /// <param name="custDebStatus">custDebStatus</param>
        /// <param name="custNotes">custNotes</param>
        /// <param name="pcNameWhoModified">pcNameWhoModified</param>
        /// <param name="customerWhoModified">customerWhoModified</param>
        public void UpdateCustomers(int custID, string custName, string custPhone1,
                                    string custPhone2, string custFax, string custAddress, string custEmail,
                                    string custType, string custCompany, decimal custLimit, string custDiscount,
                                    bool custDebStatus,string custNotes, string pcNameWhoModified, int customerWhoModified)
        {

            //Create New Instance From SqlParameter[]
            SqlParameter[] UpdateParam = new SqlParameter[15];
            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            UpdateParam[0] = new SqlParameter("@CustID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[0].Value = custID;

            UpdateParam[1] = new SqlParameter("@CustName", SqlDbType.NVarChar, 100);
            UpdateParam[1].Value = custName;

            UpdateParam[2] = new SqlParameter("@CustPhone1", SqlDbType.NVarChar, 25);
            UpdateParam[2].Value = custPhone1;

            UpdateParam[3] = new SqlParameter("@CustPhone2", SqlDbType.NVarChar, 25);
            UpdateParam[3].Value = custPhone2;

            UpdateParam[4] = new SqlParameter("@CustFax", SqlDbType.NVarChar, 25);
            UpdateParam[4].Value = custFax;

            UpdateParam[5] = new SqlParameter("@CustAddress", SqlDbType.NVarChar, 100);
            UpdateParam[5].Value = custAddress;

            UpdateParam[6] = new SqlParameter("@CustEmail", SqlDbType.VarChar, 80);
            UpdateParam[6].Value = custEmail;

            UpdateParam[7] = new SqlParameter("@CustType", SqlDbType.NVarChar, 25);
            UpdateParam[7].Value = custType;

            UpdateParam[8] = new SqlParameter("@CustCompany", SqlDbType.NVarChar, 75);
            UpdateParam[8].Value = custCompany;

            UpdateParam[9] = new SqlParameter("@CustLimit", SqlDbType.Decimal);
            UpdateParam[9].Value = custLimit;

            UpdateParam[10] = new SqlParameter("@CustDiscount", SqlDbType.NVarChar, 15);
            UpdateParam[10].Value = custDiscount;

            UpdateParam[11] = new SqlParameter("@CustDebStatus", SqlDbType.Bit);
            UpdateParam[11].Value = custDebStatus;

            UpdateParam[12] = new SqlParameter("@CustNotes", SqlDbType.NVarChar, 75);
            UpdateParam[12].Value = custNotes;

            UpdateParam[13] = new SqlParameter("@PCNameWhoModified", SqlDbType.NVarChar, 50);
            UpdateParam[13].Value = pcNameWhoModified;

            UpdateParam[14] = new SqlParameter("@CustomerWhoModified", SqlDbType.Int);
            UpdateParam[14].Value = customerWhoModified;


            //Execute Command to Update any Record of Users Table by CustomerID
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_CustomerUpdate]", UpdateParam);
        }

        /// <summary>
        /// Method To Update Balance Customer Table in case Postpone Sales Bill
        /// </summary>
        /// <param name="custID">custID</param>
        /// <param name="custBalance">custBalance</param>
        /// <param name="pcNameWhoModified">pcNameWhoModified</param>
        /// <param name="custWhoModified">custWhoModified</param>
        public void UpdateCustomers(int custID, decimal custBalance, string pcNameWhoModified, int custWhoModified)
        {
            //Create New Instance From SqlParameter[]
            SqlParameter[] UpdateParam = new SqlParameter[4];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            UpdateParam[0] = new SqlParameter("@CustID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[0].Value = custID;

            UpdateParam[1] = new SqlParameter("@Balance", SqlDbType.Decimal);
            UpdateParam[1].Value = custBalance;

            UpdateParam[2] = new SqlParameter("@PCNameWhoModified", SqlDbType.NVarChar, 50);
            UpdateParam[2].Value = pcNameWhoModified;

            UpdateParam[3] = new SqlParameter("@CustWhoModified", SqlDbType.Int);
            UpdateParam[3].Value = custWhoModified;

            //Execute Command to Update any Record of Users Table by CustomerID
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_CustomerBalanceUpdate]", UpdateParam);
        }


        /// <summary>
        /// DataTable Function To Advanced Search in Customers Table
        /// Recieve Two Parameters Column Name and Search Key
        /// Two Ways To Search Indentical (=) and Not Indentical (LIKE '%'+ @searchKey + '%';)
        /// </summary>
        /// <param name="ColumnName">ColumnName</param>
        /// <param name="SearchKey">SearchKey</param>
        /// <returns>DataTable</returns>
        public DataTable SearchCustomers(string columnName, string searchKey)
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
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_CustomerSearch]", SearchParam);
        }
    }
}
