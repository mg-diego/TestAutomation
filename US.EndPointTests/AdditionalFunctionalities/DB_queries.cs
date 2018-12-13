using US.EndPointTests.Steps;
using Npgsql;
using System;

namespace US.EndPointTests.AdditionalFunctionalities
{
	using Roche.Rmdd.HivMonitor.Utils;
    using SimpleIdentityServer.Core.Common.DTOs.Requests;
	using System.Collections.Generic;

	public class DB_queries
    {
        public DB_queries()
        {

        }

		StepsBase baseSteps = new StepsBase();		

		//General Methods
		public NpgsqlConnection ConnectToDabatase(string database_id)
        {
            NpgsqlConnection conn = new NpgsqlConnection();
			//13.94.168.16 //dev
			//40.113.145.68 // staging

			string ip = "";

			if (baseSteps.site == "staging") { ip = "40.113.145.68"; }
			if (baseSteps.site == "bcn") { ip = "13.94.168.16"; }
			if (baseSteps.site == "demo") { ip = "40.68.203.169"; }


			conn.ConnectionString = $"Host={ip};Username=rmddteam;Password=rmddteam;Database={database_id}";

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Database couldn't be opened", ex);
            }

            return conn;
        }

        private void executeQuery(NpgsqlConnection connection, string query)
        {
            try
            {
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataReader dr = command.ExecuteReader();

            }
            catch (Exception ex)
            {
                connection.Close();
                throw new Exception("Analytic from database couldn't be saved", ex);
            }

            connection.Close();
        }
        private T executeQueryWithResults<T>(NpgsqlConnection connection, string query)
        {
            try
            {
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                T dr = (T)command.ExecuteScalar();
                return dr;
            }
            catch (Exception ex)
            {
                throw new Exception("Analytic from database couldn't be saved", ex);
            }
            finally
            {
                connection.Close();
            }
        }


		#region .: Barcodes :.
		public void DeleteBarcodeInDB(string barcode)
        {
            NpgsqlConnection conn = ConnectToDabatase("barcodes");
            string query = $"delete from barcodes where barcode_id = \'{barcode}\';";
			NpgsqlCommand countResults = new NpgsqlCommand(query, conn);
			Int64 existingResults = (Int64)countResults.ExecuteNonQuery();
			Console.WriteLine("- Barcodes Deleted: " + existingResults + " (" + barcode + ")");
		}
		#endregion

		#region .: Results :.

		public void UnreleaseResultFromBarcodeInDB(string barcode)
        {
            NpgsqlConnection conn = ConnectToDabatase("results");
            string query = $"update viral_load_info set released = false where barcode = \'{barcode}\';";
			NpgsqlCommand countResults = new NpgsqlCommand(query, conn);
			Int64 existingResults = (Int64)countResults.ExecuteNonQuery();
			Console.WriteLine("- Results unreleased: " + existingResults + " ("+barcode+")");
		}

        public void DeleteResultFromBarcodeInDB(string barcode)
        {
            NpgsqlConnection conn = ConnectToDabatase("results");
            string query = $"delete from viral_load_info where barcode = \'{barcode}\';";
			NpgsqlCommand countResults = new NpgsqlCommand(query, conn);
			Int64 existingResults = (Int64)countResults.ExecuteNonQuery();
			Console.WriteLine("- Results Deleted: " + existingResults + " (" + barcode + ")");
		}

		public void ReleaseResultFromBarcodeInDB(string barcode)
		{
			NpgsqlConnection conn = ConnectToDabatase("results");
			string query = $"update viral_load_info set released = true where barcode = \'{barcode}\';";
			NpgsqlCommand countResults = new NpgsqlCommand(query, conn);
			Int64 existingResults = (Int64)countResults.ExecuteNonQuery();
			Console.WriteLine("- Results released: " + existingResults + " (" + barcode + ")");
		}

		public void AddResult(string barcode, string value_result)
		{
			NpgsqlConnection conn = ConnectToDabatase("results");
			string query = $"INSERT INTO VIRAL_LOAD_INFO VALUES('1X0X2MNK-P93V-LJTB-5WN1-EQBCHWY3RPJ7', '{barcode}', 'ALCZC613877L', '{{TM40-2,TM42-2}}', '0', 'Detected DBS', 'Unknown', '2019-11-1 3:23:42.225093', '2019-9-16 10:53:45.430488', '2018-11-17 12:52:23.629412', '2016-7-8 19:11:28.148749', '2016-12-21 6:56:17.518427', '2015-3-28 3:21:39.255843', 'TID.HI2QLD96', '0', '{value_result}', 'CAPCTM', 'FALSE');".Replace("\"","'");
			//string query = $"INSERT INTO VIRAL_LOAD_INFO VALUES('1X0X2MNK-P93V-LJTB-5WN1-EQBCHWY3RPJ7', 'en_666666', 'ALCZC613877L', '{{TM40-2,TM42-2}}', '0', 'Detected DBS', 'Unknown', '2019-11-1 3:23:42.225093', '2019-9-16 10:53:45.430488', '2018-11-17 12:52:23.629412', '2016-7-8 19:11:28.148749', '2016-12-21 6:56:17.518427', '2015-3-28 3:21:39.255843', 'TID.HI2QLD96', '0', '{value_result}', 'CAPCTM', 'FALSE');";
			NpgsqlCommand countResults = new NpgsqlCommand(query, conn);
			Int64 existingResults = (Int64)countResults.ExecuteNonQuery();
			Console.WriteLine("- Results added: " + existingResults + " (" + barcode + ")");
		}

		public long GetAllResultsCountInDB()
		{
			NpgsqlConnection conn = ConnectToDabatase("results");
			string query = $"select count(*) from viral_load_info;";
			NpgsqlCommand countResults = new NpgsqlCommand(query, conn);
			Int64 existingResults = (Int64)countResults.ExecuteScalar();

			return existingResults;
		}

		public long GetUnreleasedResultsCountInDB()
		{
			NpgsqlConnection conn = ConnectToDabatase("results");
			string query = $"select count(*) from viral_load_info where released = false;";
			NpgsqlCommand countResults = new NpgsqlCommand(query, conn);
			Int64 existingResults = (Int64)countResults.ExecuteScalar();

			return existingResults;
		}

		public void ChangeResultBarcodeInDB(string old_barcode, string new_barcode)
		{
			NpgsqlConnection conn = ConnectToDabatase("results");
			string query = $"update viral_load_info set barcode = \'{old_barcode}\' where barcode = \'{new_barcode}\';";
			NpgsqlCommand countResults = new NpgsqlCommand(query, conn);
			Int64 existingResults = (Int64)countResults.ExecuteNonQuery();
			Console.WriteLine("- Results unreleased: " + existingResults + " (" + old_barcode + " -> "+ new_barcode +")");
		}

		#endregion

		#region .: Resgistration codes :.
		public void DeleteBarcodeFromPushNotificationDB(string barcode)
        {
            var barcode_hash = barcode.Hash();
			Console.WriteLine(" -Barcode (hash): " + barcode_hash);
            NpgsqlConnection conn = ConnectToDabatase("registration_codes");
            string query = $"delete from registration_codes where barcode = \'{barcode_hash}\';";
			NpgsqlCommand countResults = new NpgsqlCommand(query, conn);
			Int64 existingResults = (Int64)countResults.ExecuteNonQuery();
			Console.WriteLine("- Registration codes deleted: " + existingResults);
		}

		public bool CheckBarcodeEntry(string barcode)
		{
			NpgsqlConnection conn = ConnectToDabatase("registration_codes");

			string query = $"select count(*) from registration_codes where barcode = \'{barcode.Hash()}\';";
			return executeQueryWithResults<long>(conn, query) > 0;
		}

		#endregion

		#region .: Referencedata :.

		public void EmptyWhatsappGroupsInDB()
		{
			NpgsqlConnection conn = ConnectToDabatase("referencedata");
			string query = $"update whatsapp_groups set total_members = 1 where id > 0;";
			executeQuery(conn, query);
		}

		public void CompleteWhatsappGroupsInDB()
		{
			NpgsqlConnection conn = ConnectToDabatase("referencedata");
			string query = $"update whatsapp_groups set total_members = 30 where id > 0;";
			executeQuery(conn, query);
		}

		public void CompleteFirstWhatsappGroupsInDB()
		{
			EmptyWhatsappGroupsInDB();

			NpgsqlConnection conn = ConnectToDabatase("referencedata");
			string query = $"update whatsapp_groups set total_members = 30 where title like '%(1)';";
			executeQuery(conn, query);
		}

		#endregion

		#region .: Notification Worflow :.

		public void CleanupNotificationWorkflowDB(string barcode)
        {
            NpgsqlConnection conn = ConnectToDabatase("notificationworkflow");

            string query = $"delete from mt_doc_trackednotification where id = \'{barcode.Hash()}\';";
			NpgsqlCommand countResults = new NpgsqlCommand(query, conn);
			Int64 existingResults = (Int64)countResults.ExecuteNonQuery();
			Console.WriteLine("- Notification trackednotification deleted: " + existingResults);

            query = $"delete from commits where streamidoriginal = \'{barcode}\';";
			countResults = new NpgsqlCommand(query, conn);
			existingResults = (Int64)countResults.ExecuteNonQuery();
			Console.WriteLine("- Notification commits deleted: " + existingResults);
		}

		#endregion

		public Dictionary<string, string> CheckUserScimId(string userId)
		{
			Dictionary<string, string> results = new Dictionary<string, string>();
			results.Clear();

			NpgsqlConnection conn = ConnectToDabatase("idserver");		

			string query = $"select \"resourceOwnerClaims\".\"Value\" from \"resourceOwnerClaims\" where \"ResourceOwnerId\" = '"+ userId + "' and \"ClaimCode\" = 'scim_id' ORDER by \"ClaimCode\" ASC;";
			NpgsqlCommand command = new NpgsqlCommand(query, conn);

			try
			{
				NpgsqlDataReader dr = command.ExecuteReader();
				dr.Read();

				results.Add("userId", String.Join("", dr[0].ToString().Split('"')));
				conn.Close();
			}
			catch(Exception ex)
			{
				conn.Close();
				throw new Exception("User profile couldn't be retrieved", ex);
			}

			conn.Close();

			return results;
		}

		#region .: idserver :.



		#endregion




	}
}





