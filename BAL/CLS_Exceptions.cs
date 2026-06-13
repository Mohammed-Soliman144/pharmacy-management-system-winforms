using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; // to deal with dataset and datatable
using System.Data.SqlClient; //Using System.Data.SqlClient; to deal with SqlServer Database

namespace PharmacySystemV20._0._1.BAL
{
    class CLS_Exceptions
    {
        //Create New Instance from DAL.CLS_ConnectionDB
        readonly DAL.CLS_ConnectionDB Connection = DAL.CLS_ConnectionDB.NewInstance();

        /// <summary>
        /// Method To Save any Exceptions happened when run software
        /// To Handling exceptions in next updates of software
        /// </summary>
        /// <param name="exMsg">exMsg</param>
        /// <param name="exType">exType</param>
        /// <param name="exTrace">exTrace</param>
        public void SaveExceptions(string exMsg, string exType, string exTrace)
        {
            //Create New Instance From SqlParameter[]
            SqlParameter[] ExceptionParam = new SqlParameter[3];

            ExceptionParam[0] = new SqlParameter("@ExMsg", SqlDbType.NVarChar, 150);
            ExceptionParam[0].Value = exMsg;

            ExceptionParam[1] = new SqlParameter("@ExType", SqlDbType.NVarChar, 100);
            ExceptionParam[1].Value = exType;

            ExceptionParam[2] = new SqlParameter("@ExStackTrace", SqlDbType.NVarChar);
            ExceptionParam[2].Value = exTrace;

            //Execute Command from Data Access Layer to Save Exceptions
            Connection.ExecuteCommands("[PharmacyDB].[dbo].[SP_EditException]",ExceptionParam);
        }

        /// <summary>
        /// DataTable To Show Exceptions inner software to handling exceptions in next updates
        /// </summary>
        /// <returns>DataTable of Exceptions</returns>
        public DataTable ShowExceptions()
        {
            //Return DataTable by all columns of Exceptions table in database
            return Connection.SelectData("[PharmacyDB].[dbo].[SP_ShowException]", null);
        }
    }
}
