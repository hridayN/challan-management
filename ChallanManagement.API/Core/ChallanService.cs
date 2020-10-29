using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ChallanManagement.API
{
    public class ChallanService : IChallanService
    {
        public string CreateChallan(ChallanRequest challanRequest)
        {
            using (SqlConnection sqlConnection = ChallanDbHelper.GetConnection())
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CreateChallan";

                var parameterList = new List<IDbDataParameter>
                {
                    new SqlParameter() { ParameterName = "@MobileNumber", Value = challanRequest.Challan.MobileNumber, SqlDbType = SqlDbType.NChar },
                    new SqlParameter() { ParameterName = "@VehicleNumber", Value = challanRequest.Challan.VehicleNumber, SqlDbType = SqlDbType.NChar },
                    new SqlParameter() { ParameterName = "@Offense", Value = challanRequest.Challan.Offence, SqlDbType = SqlDbType.VarChar },
                    new SqlParameter() { ParameterName = "@Amount", Value = challanRequest.Challan.Amount, SqlDbType = SqlDbType.BigInt },
                    new SqlParameter() { ParameterName = "@Place", Value = challanRequest.Challan.OffencePlace, SqlDbType = SqlDbType.VarChar },
                    new SqlParameter() { ParameterName = "@IssueDate", Value = challanRequest.Challan.IssueDate, SqlDbType = SqlDbType.Date },
                    new SqlParameter() { ParameterName = "@ExpiryDate", Value = challanRequest.Challan.ExpiryDate, SqlDbType = SqlDbType.Date }
                };

                cmd.Parameters.AddRange(parameterList.ToArray());
                cmd.Connection = sqlConnection;

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);

            }
            return "Request processed successfully";
        }

        public ChallanResponse GetChallans(ChallanRequest challanRequest)
        {
            ChallanResponse challanResponse = new ChallanResponse();
            using (SqlConnection sqlConnection = ChallanDbHelper.GetConnection())
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetChallan";

                var parameterList = new List<IDbDataParameter>
                {
                    new SqlParameter() { ParameterName = "@MobileNumber", Value = challanRequest.Challan.MobileNumber, SqlDbType = SqlDbType.NChar },
                    new SqlParameter() { ParameterName = "@VehicleNumber", Value = challanRequest.Challan.VehicleNumber, SqlDbType = SqlDbType.NChar }
                };

                cmd.Parameters.AddRange(parameterList.ToArray());
                cmd.Connection = sqlConnection;

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);

                if (dataSet != null && dataSet.Tables.Count > 0)
                {
                    challanResponse.ChallanList = new List<Challan>();
                    foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                    {
                        Challan challan = new Challan()
                        {
                            ChallanId = Convert.ToInt64(dataRow["ChallanId"].ToString()),
                            MobileNumber = challanRequest.Challan.MobileNumber,
                            VehicleNumber = dataRow["VehicleNumber"].ToString(),
                            Offence = dataRow["Offence"].ToString(),
                            Amount = Convert.ToInt64(dataRow["Amount"].ToString()),
                            OffencePlace = dataRow["OffencePlace"].ToString(),
                            Status = dataRow["Status"].ToString(),
                            IssueDate = Convert.ToDateTime(dataRow["IssueDate"]),
                            ExpiryDate = Convert.ToDateTime(dataRow["ExpiryDate"])
                        };
                        challanResponse.ChallanList.Add(challan);
                    }
                }
            }
            return challanResponse;
        }

        public string SubmitChallan(ChallanRequest challanRequest)
        {
            using (SqlConnection sqlConnection = ChallanDbHelper.GetConnection())
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SubmitChallan";

                var parameterList = new List<IDbDataParameter>
                {
                    new SqlParameter() { ParameterName = "@ChallanId", Value = challanRequest.Challan.ChallanId, SqlDbType = SqlDbType.BigInt }
                };

                cmd.Parameters.AddRange(parameterList.ToArray());
                cmd.Connection = sqlConnection;

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
            }
            return "Request processed successfully";
        }
    }
}
