using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //To Deal With DataTable and DataSet etc.....
using System.Data.SqlClient;//To Deal With Sql Server Database and SqlParameter[] etc.......

namespace PharmacySystemV20._0._1.BAL
{
    class CLS_Suppliers
    {
        //Create new Instance From Singleton Class CLS_ConnectionDB() DataAccessLayer
        readonly DAL.CLS_ConnectionDB Connection = DAL.CLS_ConnectionDB.NewInstance();

        /// <summary>
        /// DataTable Function to Select All Columns From Suppliers Table
        /// </summary>
        /// <returns>SuppliersTable</returns>
        public DataTable ShowSuppliersTable()
        {
            /*Use DataTable Function from DAL.CLS_ConnectionDB to Select All Columns From Suppliers Table
             * no any StoredProcedur Parameters in StoredProcedure so Initialize null value
             * Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
             */
            // return Connection.SelectData("[PharmacyDB].[dbo].[SP_SupplierShow]", null);
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_SupplierShow]", null);
        }


        /// <summary>
        /// Int Function to generate Supplier ID
        /// </summary>
        /// <returns>SupplierID</returns>
        public string GenerateSupplierID()
        {
            //int SupplierID without assignment any value
            int SupplierID;

            //Initialize return value of DataTable Function From DAL Connection.SelectData("storedProcedureName",SqlParameter[])
            //Assignment the value from DataTable Function After Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastSupID]", null).Rows[0][0].ToString())
            SupplierID = Convert.ToInt32(Connection.SelectData("[PharmacyDB].[dbo].[SP_GetLastSupID]", null).Rows[0][0].ToString());

            //return CustomerID.ToString("FormatName-000000");
            return SupplierID.ToString("SUPP-000000");
        }


        /// <summary>
        /// Method To Add New Supplier Or Save new Supplier
        /// </summary>
        /// <param name="supID">supID</param>
        /// <param name="supCode">supCode</param>
        /// <param name="supName">supName</param>
        /// <param name="supCompany">supCompany</param>
        /// <param name="supResposible">supResposible</param>
        /// <param name="supPhone1">supPhone1</param>
        /// <param name="supPhone2">supPhone2</param>
        /// <param name="supPhone3">supPhone3</param>
        /// <param name="supFax">supFax</param>
        /// <param name="supAddress">supAddress</param>
        /// <param name="supArea">supArea</param>
        /// <param name="supEmail">supEmail</param>
        /// <param name="supType">supType</param>
        /// <param name="supGroup">supGroup</param>
        /// <param name="supSize">supSize</param>
        /// <param name="supLimit">supLimit</param>
        /// <param name="supDiscount">supDiscount</param>
        /// <param name="supBalance">supBalance</param>
        /// <param name="supNotes">supNotes</param>
        /// <param name="pcNameWhoAdded">pcNameWhoAdded</param>
        /// <param name="supWhoAdded">supWhoAdded</param>
        /// <param name="supDate">supDate</param>
        /// <param name="supTime">supTime</param>
        public void SaveSuppliers(int supID, string supCode, string supName, string supCompany, string supResposible,
                                  string supPhone1, string supPhone2, string supPhone3, string supFax, 
                                  string supAddress, string supArea, string supEmail, string supType,
                                  string supGroup, string supSize, decimal supLimit, string supDiscount, decimal supBalance,
                                  string supNotes, string pcNameWhoAdded, int supWhoAdded, string supDate,
                                  string supTime)
        {
            //Create New Instance From SqlParameter[] which length of it is equal counter of storedprocedureparameter
            SqlParameter[] SaveParam = new SqlParameter[23];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            SaveParam[0] = new SqlParameter("@ID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[0].Value = supID;

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            SaveParam[1] = new SqlParameter("@SupCustCode", SqlDbType.NVarChar, 50);
            //Initialize value of every element in array by Argument which received from form
            SaveParam[1].Value = supCode;

            SaveParam[2] = new SqlParameter("@SupFullName", SqlDbType.NVarChar, 100);
            SaveParam[2].Value = supName;

            SaveParam[3] = new SqlParameter("@SupCompName", SqlDbType.NVarChar, 75);
            SaveParam[3].Value = supCompany;

            SaveParam[4] = new SqlParameter("@SupRespName", SqlDbType.NVarChar, 50);
            SaveParam[4].Value = supResposible;

            SaveParam[5] = new SqlParameter("@SupPhone1", SqlDbType.NVarChar, 25);
            SaveParam[5].Value = supPhone1;

            SaveParam[6] = new SqlParameter("@SupPhone2", SqlDbType.NVarChar, 25);
            SaveParam[6].Value = supPhone2;

            SaveParam[7] = new SqlParameter("@SupPhone3", SqlDbType.NVarChar, 25);
            SaveParam[7].Value = supPhone3;

            SaveParam[8] = new SqlParameter("@SupFax", SqlDbType.NVarChar, 25);
            SaveParam[8].Value = supFax;

            SaveParam[9] = new SqlParameter("@SupAddress", SqlDbType.NVarChar, 100);
            SaveParam[9].Value = supAddress;

            SaveParam[10] = new SqlParameter("@SupArea", SqlDbType.NVarChar, 50);
            SaveParam[10].Value = supArea;

            SaveParam[11] = new SqlParameter("@SupEmail", SqlDbType.VarChar, 80);
            SaveParam[11].Value = supEmail;

            SaveParam[12] = new SqlParameter("@SupType", SqlDbType.NVarChar, 25);
            SaveParam[12].Value = supType;

            SaveParam[13] = new SqlParameter("@SupClassGRP", SqlDbType.NVarChar, 50);
            SaveParam[13].Value = supGroup;

            SaveParam[14] = new SqlParameter("@SupClassSize", SqlDbType.NVarChar, 25);
            SaveParam[14].Value = supSize;

            SaveParam[15] = new SqlParameter("@SupCreditLimit", SqlDbType.Decimal);
            SaveParam[15].Value = supLimit;

            SaveParam[16] = new SqlParameter("@SupDiscount", SqlDbType.NVarChar, 15);
            SaveParam[16].Value = supDiscount;

            SaveParam[17] = new SqlParameter("@SupBalance", SqlDbType.Decimal);
            SaveParam[17].Value = supBalance;

            SaveParam[18] = new SqlParameter("@SupNotes", SqlDbType.NVarChar, 75);
            SaveParam[18].Value = supNotes;

            SaveParam[19] = new SqlParameter("@PCNameWhoAdded", SqlDbType.NVarChar, 50);
            SaveParam[19].Value = pcNameWhoAdded;

            SaveParam[20] = new SqlParameter("@SupWhoAdded", SqlDbType.Int);
            SaveParam[20].Value = supWhoAdded;

            SaveParam[21] = new SqlParameter("@SupDate", SqlDbType.NVarChar, 50);
            SaveParam[21].Value = supDate;

            SaveParam[22] = new SqlParameter("@SupTime", SqlDbType.NVarChar, 50);
            SaveParam[22].Value = supTime;

            //Execute Command Insert into Table Users by DAL.CLS_ConnectionDB
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_SupplierEdit]", SaveParam);
        }


        /// <summary>
        /// Method To Delete Record From Suppliers Table
        /// </summary>
        /// <param name="custID">SupplierID</param>
        public void DeleteSuppliers(int supID)
        {
            //Create new instance from SqlParameter[]
            SqlParameter[] DeleteParam = new SqlParameter[1];

            DeleteParam[0] = new SqlParameter("@SupID", SqlDbType.Int);
            DeleteParam[0].Value = supID;

            //Execute Command To Delete Record from Suppliers Table
            //Note Name of Stored Procedure [DatabaseName].[dbo].[storedProcedureName / TableName]
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_SupplierDelete]", DeleteParam);

        }

        /// <summary>
        /// Method To Update Suppliers Table by Modify SupplierStatus Only (Deactivate Supplier)
        /// </summary>
        /// <param name="custID">supID</param>
        /// <param name="pcNameWhoDeleted">pcNameWhoDeleted</param>
        /// <param name="customerWhoDeleted">supWhoDeleted</param>
        public void DeactivateSuppliers(int suptID, bool supStatus, string pcNameWhoDeleted, int supWhoDeleted)
        {
            //Create New Instance From SqlParameter [] array
            SqlParameter[] DeleteParam = new SqlParameter[4];

            DeleteParam[0] = new SqlParameter("@SupID", SqlDbType.Int);
            DeleteParam[0].Value = suptID;

            DeleteParam[1] = new SqlParameter("@SupStatus", SqlDbType.Bit);
            DeleteParam[1].Value = supStatus;

            DeleteParam[2] = new SqlParameter("@PCNameWhoDeleted", SqlDbType.NVarChar, 50);
            DeleteParam[2].Value = pcNameWhoDeleted;

            DeleteParam[3] = new SqlParameter("@SupplierWhoDeleted", SqlDbType.Int);
            DeleteParam[3].Value = supWhoDeleted;

            //Execute Command to Update Users table by In Activate Suppliers
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_SupplierDeactivate]", DeleteParam);

        }

        /// <summary>
        /// Method To Update Suppliers Table
        /// </summary>
        /// <param name="supID">supID</param>
        /// <param name="supName">supName</param>
        /// <param name="supCompany">supCompany</param>
        /// <param name="supResponsible">supResponsible</param>
        /// <param name="supPhone1">supPhone1</param>
        /// <param name="supPhone2">supPhone2</param>
        /// <param name="supPhone3">supPhone3</param>
        /// <param name="suptFax">suptFax</param>
        /// <param name="supAddress">supAddress</param>
        /// <param name="supArea">supArea</param>
        /// <param name="supEmail">supEmail</param>
        /// <param name="supType">supType</param>
        /// <param name="supGroup">supGroup</param>
        /// <param name="supSize">supSize</param>
        /// <param name="supLimit">supLimit</param>
        /// <param name="supDiscount">supDiscount</param>
        /// <param name="supNotes">supNotes</param>
        /// <param name="pcNameWhoModified">pcNameWhoModified</param>
        /// <param name="supWhoModified">supWhoModified</param>
        public void UpdateSuppliers( int supID, string supName, string supCompany, 
                                    string supResponsible, string supPhone1, string supPhone2, string supPhone3,
                                    string suptFax, string supAddress, string supArea, string supEmail,
                                    string supType, string supGroup, string supSize, decimal supLimit, 
                                    string supDiscount, string supNotes, string pcNameWhoModified, int supWhoModified)
        { 



            //Create New Instance From SqlParameter[]
            SqlParameter[] UpdateParam = new SqlParameter[19];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            UpdateParam[0] = new SqlParameter("@SupID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[0].Value = supID;

            UpdateParam[1] = new SqlParameter("@SupFullName", SqlDbType.NVarChar, 100);
            UpdateParam[1].Value = supName;

            UpdateParam[2] = new SqlParameter("@SupCompName", SqlDbType.NVarChar, 75);
            UpdateParam[2].Value = supCompany;

            UpdateParam[3] = new SqlParameter("@SupRespName", SqlDbType.NVarChar, 50);
            UpdateParam[3].Value = supResponsible;

            UpdateParam[4] = new SqlParameter("@SupPhone1", SqlDbType.NVarChar, 25);
            UpdateParam[4].Value = supPhone1;

            UpdateParam[5] = new SqlParameter("@SupPhone2", SqlDbType.NVarChar, 25);
            UpdateParam[5].Value = supPhone2;

            UpdateParam[6] = new SqlParameter("@SupPhone3", SqlDbType.NVarChar, 25);
            UpdateParam[6].Value = supPhone3;

            UpdateParam[7] = new SqlParameter("@SupFax", SqlDbType.NVarChar, 25);
            UpdateParam[7].Value = suptFax;

            UpdateParam[8] = new SqlParameter("@SupAddress", SqlDbType.NVarChar, 100);
            UpdateParam[8].Value = supAddress;

            UpdateParam[9] = new SqlParameter("@SupArea", SqlDbType.NVarChar, 50);
            UpdateParam[9].Value = supArea;

            UpdateParam[10] = new SqlParameter("@SupEmail", SqlDbType.VarChar, 80);
            UpdateParam[10].Value = supEmail;

            UpdateParam[11] = new SqlParameter("@SupType", SqlDbType.NVarChar, 25);
            UpdateParam[11].Value = supType;

            UpdateParam[12] = new SqlParameter("@SupClassGRP", SqlDbType.NVarChar, 50);
            UpdateParam[12].Value = supGroup;

            UpdateParam[13] = new SqlParameter("@SupClassSize", SqlDbType.NVarChar, 25);
            UpdateParam[13].Value = supSize;

            UpdateParam[14] = new SqlParameter("@SupCreditLimit", SqlDbType.Decimal);
            UpdateParam[14].Value = supLimit;

            UpdateParam[15] = new SqlParameter("@SupDiscount", SqlDbType.NVarChar, 15);
            UpdateParam[15].Value = supDiscount;

            UpdateParam[16] = new SqlParameter("@SupNotes", SqlDbType.NVarChar, 75);
            UpdateParam[16].Value = supNotes;

            UpdateParam[17] = new SqlParameter("@PCNameWhoModified", SqlDbType.NVarChar, 50);
            UpdateParam[17].Value = pcNameWhoModified;

            UpdateParam[18] = new SqlParameter("@SupWhoModified", SqlDbType.Int);
            UpdateParam[18].Value = supWhoModified;


            //Execute Command to Update any Record of Users Table by SupplierID
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_SupplierUpdate]", UpdateParam);
        }


        /// <summary>
        /// Method To Update Balance Supplier Table in case Postpone purchases Bill
        /// </summary>
        /// <param name="supID">supID</param>
        /// <param name="supBalance">supBalance</param>
        /// <param name="pcNameWhoModified">pcNameWhoModified</param>
        /// <param name="supWhoModified">supWhoModified</param>
        public void UpdateSuppliers(int supID, decimal supBalance, string pcNameWhoModified, int supWhoModified)
        {
            //Create New Instance From SqlParameter[]
            SqlParameter[] UpdateParam = new SqlParameter[4];

            //Define every element of array by initialize "@nameofStoredProcedure", datatype SqlDbType.NVarChar, Size 25
            UpdateParam[0] = new SqlParameter("@SupID", SqlDbType.Int);
            //Initialize value of every element in array by Argument which received from form
            UpdateParam[0].Value = supID;

            UpdateParam[1] = new SqlParameter("@Balance", SqlDbType.Decimal);
            UpdateParam[1].Value = supBalance;

            UpdateParam[2] = new SqlParameter("@PCNameWhoModified", SqlDbType.NVarChar, 50);
            UpdateParam[2].Value = pcNameWhoModified;

            UpdateParam[3] = new SqlParameter("@SupWhoModified", SqlDbType.Int);
            UpdateParam[3].Value = supWhoModified;

            //Execute Command to Update any Record of Users Table by SupplierID
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_SupplierBalanceUpdate]", UpdateParam);
        }


        /// <summary>
        /// DataTable Function To Advanced Search in Suppliers Table
        /// Recieve Two Parameters Column Name and Search Key
        /// Two Ways To Search Indentical (=) and Not Indentical (LIKE '%'+ @searchKey + '%';)
        /// </summary>
        /// <param name="ColumnName">ColumnName</param>
        /// <param name="SearchKey">SearchKey</param>
        /// <returns>DataTable</returns>
        public DataTable SearchSuppliers(string columnName, string searchKey)
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
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_SupplierSearch]", SearchParam);
        }
    }
}
