﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ClassLibrary1.TestDataAccess
{
    class ExcelDataAccess
    {
        public string TestDataFileConnection()
        {
            var fileName = ConfigurationManager.AppSettings["TestDataSheetPath"];
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", fileName);
            return con;
        }

        public UserData GetTestData(string keyName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [DataSet$] where key='{0}'", keyName);
                var value = connection.Query<UserData>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
    }
}
