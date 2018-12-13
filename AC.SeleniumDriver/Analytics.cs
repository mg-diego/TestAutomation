using AC.Contracts;
using AC.SeleniumDriver.Pages;
using AC.SeleniumDriver.Pages.Login;
using DF.Entities;
using Npgsql;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;

namespace AC.SeleniumDriver
{
    public class Analytics : IAnalytics 
    {        

        #region .: General Methods :.

        /// <summary>
        /// Connects to the postgresql database
        /// </summary>
        private NpgsqlConnection ConnectToDabatase()
        {
            NpgsqlConnection conn = new NpgsqlConnection();
            conn.ConnectionString = "Host=40.113.145.68;Username=rmddteam;Password=rmddteam;Database=hivmonitor";

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


        /// <summary>
        /// Check if the analytic timestamp is correct (lower than 30s from current time)
        /// </summary> 
        private bool IsAnalyticTimestampCorrect(string AnalyticTimestamp)
        {
            string CurrentTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH\\:mm\\:ss.ffffffzzz");

            //Change CurrentTime from ISO8601 to EPOCH
            var dateTime_CurrentTime = new DateTime(
                Int32.Parse(CurrentTime.Substring(0, "yyyy".Length)),
                Int32.Parse(CurrentTime.Substring("yyyy-".Length, "MM".Length)),
                Int32.Parse(CurrentTime.Substring("yyyy-MM-".Length, "dd".Length)),
                Int32.Parse(CurrentTime.Substring("yyyy-MM-ddT".Length, "HH".Length)),
                Int32.Parse(CurrentTime.Substring("yyyy-MM-ddTHH:".Length, "mm".Length)),
                Int32.Parse(CurrentTime.Substring("yyyy-MM-ddTHH:mm:".Length, "ss".Length)),
                DateTimeKind.Local);
            var dateTimeOffset_CurrentTime = new DateTimeOffset(dateTime_CurrentTime);
            var unixDateTime_currentTime = dateTimeOffset_CurrentTime.ToUnixTimeSeconds();


            //Change CurrentTime from ISO8601 to EPOCH
            var dateTime_AnalyticTimestamp = new DateTime(
                Int32.Parse(AnalyticTimestamp.Substring(0, "yyyy".Length)),
                Int32.Parse(AnalyticTimestamp.Substring("yyyy-".Length, "MM".Length)),
                Int32.Parse(AnalyticTimestamp.Substring("yyyy-MM-".Length, "dd".Length)),
                Int32.Parse(AnalyticTimestamp.Substring("yyyy-MM-ddT".Length, "HH".Length)),
                Int32.Parse(AnalyticTimestamp.Substring("yyyy-MM-ddTHH:".Length, "mm".Length)),
                Int32.Parse(AnalyticTimestamp.Substring("yyyy-MM-ddTHH:mm:".Length, "ss".Length)),
                DateTimeKind.Local);
            var dateTimeOffset_AnalyticTimestamp = new DateTimeOffset(dateTime_AnalyticTimestamp);
            var unixDateTime_AnalyticTimestamp = dateTimeOffset_AnalyticTimestamp.ToUnixTimeSeconds();

            if (Math.Abs(unixDateTime_currentTime - unixDateTime_AnalyticTimestamp) <= 30)
            {
                return true;
            }

            else
            {
                Console.WriteLine("   " + AnalyticTimestamp + "  -  AnalyticTimestamp");
                Console.WriteLine("   " + CurrentTime + "  -  CurrentTimestamp");
            }

            return false;
        }

        #endregion

        #region .: Experience Rated :.

        /// <summary>
        /// GetAnalyticExperienceRatedFromDatabase
        /// </summary>
        public Dictionary<string, string> GetAnalyticExperienceRatedFromDatabase()
        {
            Dictionary<string, string> results = new Dictionary<string, string>();

            NpgsqlConnection conn = ConnectToDabatase();

            Thread.Sleep(7);

            NpgsqlCommand command = new NpgsqlCommand(
                "SELECT  id, data->> 'EventType' as EVENT_TYPE, data->'Payload'->'Experience' AS EXPERIENCE, data->'Payload'->'Rating' as RATING, data->'Payload'->'Source' as SOURCE, data->'Payload'->'TimeStamp' as TIMESTAMP FROM mt_doc_hivmonitorevent WHERE data->> 'EventType' = 'ExperienceRated' order by TIMESTAMP desc", conn);

            try
            {
                NpgsqlDataReader dr = command.ExecuteReader();
                dr.Read();

                results.Add("id", String.Join("", dr[0].ToString().Split('"')));
                results.Add("event_type", String.Join("", dr[1].ToString().Split('"')));
                results.Add("experience", String.Join("", dr[2].ToString().Split('"')));
                results.Add("rating", String.Join("", dr[3].ToString().Split('"')));
                results.Add("source", String.Join("", dr[4].ToString().Split('"')));
                results.Add("timestamp", String.Join("", dr[5].ToString().Split('"')));

                Console.WriteLine("\n- Analytic:");
                foreach (KeyValuePair<string, string> entry in results)
                {
                    Console.WriteLine("   {0} = {1}", entry.Key, entry.Value);
                }
                Console.WriteLine("\n");

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception("Analytic from database couldn't be saved", ex);
            }

            conn.Close();

            return results;
        }

        /// <summary>
        /// Check if Login Survey Analytic has been saved at DB
        /// </summary>
        public void IsAnalyticLoginSurveySaved(Dictionary<string, string> results, UserLogin userLogin)
        {
            Assert.Multiple(() =>
            {
                Assert.That(results["event_type"], Is.EqualTo("ExperienceRated"), "Event_Type is not ExperienceRated");
                Assert.That(results["source"], Is.EqualTo(userLogin.Uuid.ToString().Substring("ID: HI-M-".Length)), "source is not correct");
                Assert.That(results["experience"], Is.EqualTo("Login"), "Experience is not Login");
                Assert.That(IsAnalyticTimestampCorrect(results["timestamp"]), Is.EqualTo(true), "Timestamp difference is higher than 6 sec");
            });
        }

        #endregion

        #region .: BarcodeScanFailed :.

        /// <summary>
        /// GetAnalyticBarcodeScanFailedFromDatabase
        /// </summary>
        public Dictionary<string, string> GetAnalyticBarcodeScanFailedFromDatabase()
        {
            Dictionary<string, string> results = new Dictionary<string, string>();

            NpgsqlConnection conn = ConnectToDabatase();

            NpgsqlCommand command = new NpgsqlCommand(
                "SELECT id, data->> 'EventType' as EVENT_TYPE, data->'Payload'->'Source' as SOURCE, data->'Payload'->'ErrorMessage' as ERROR_MESSAGE, data->'Payload'->'TimeStamp' as TIMESTAMP FROM mt_doc_hivmonitorevent WHERE data->> 'EventType' = 'BarcodeScanFailed' order by TIMESTAMP desc", conn);

            try
            {
                NpgsqlDataReader dr = command.ExecuteReader();
                dr.Read();

                results.Add("id", String.Join("", dr[0].ToString().Split('"')));
                results.Add("event_type", String.Join("", dr[1].ToString().Split('"')));
                results.Add("source", String.Join("", dr[2].ToString().Split('"')));
                results.Add("error_message", String.Join("", dr[3].ToString().Split('"')));
                results.Add("timestamp", String.Join("", dr[4].ToString().Split('"')));

                Console.WriteLine("\n- Analytic:");
                foreach (KeyValuePair<string, string> entry in results)
                {
                    Console.WriteLine("   {0} = {1}", entry.Key, entry.Value);
                }
                Console.WriteLine("\n");

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception("Analytic from database couldn't be saved", ex);
            }

            conn.Close();

            return results;
        }

        /// <summary>
        /// Check if Barcode Scan Failed Analytic has been saved at DB
        /// </summary>
        public void IsAnalyticBarcodeScanFailedSaved(Dictionary<string, string> results)
        {
            Assert.Multiple(() =>
            {
                Assert.That(results["event_type"], Is.EqualTo("BarcodeScanFailed"), "Event_Type is not BarcodeScanFailed");
                Assert.That(results["error_message"], Is.EqualTo("Scan timer elapsed"), "error_message is not Login");
                Assert.That(IsAnalyticTimestampCorrect(results["timestamp"]), Is.EqualTo(true), "Timestamp difference is higher than 6 sec");
            });
        }
        #endregion

        #region .: FailedLoginAttempts :.

        /// <summary>
        /// GetAnalyticFailedLoginAttemptsFromDatabase
        /// </summary>
        public Dictionary<string, string> GetAnalyticFailedLoginAttemptsFromDatabase()
        {
            Dictionary<string, string> results = new Dictionary<string, string>();

            NpgsqlConnection conn = ConnectToDabatase();

            NpgsqlCommand command = new NpgsqlCommand(
                "SELECT id, data->> 'EventType' as EVENT_TYPE, data->'Payload'->'Attempts' as ATTEMPTS, data->'Payload'->'Source' as SOURCE, data->'Payload'->'TimeStamp' as TIMESTAMP FROM mt_doc_hivmonitorevent WHERE data->> 'EventType' = 'FailedLoginAttempts' order by TIMESTAMP desc", conn);

            try
            {
                NpgsqlDataReader dr = command.ExecuteReader();
                dr.Read();

                results.Add("id", String.Join("", dr[0].ToString().Split('"')));
                results.Add("event_type", String.Join("", dr[1].ToString().Split('"')));
                results.Add("attempts", String.Join("", dr[2].ToString().Split('"')));
                results.Add("source", String.Join("", dr[3].ToString().Split('"')));
                results.Add("timestamp", String.Join("", dr[4].ToString().Split('"')));

                Console.WriteLine("\n- Analytic:");
                foreach (KeyValuePair<string, string> entry in results)
                {
                    Console.WriteLine("   {0} = {1}", entry.Key, entry.Value);
                }
                Console.WriteLine("\n");

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception("Analytic from database couldn't be saved", ex);
            }

            conn.Close();

            return results;
        }

        /// <summary>
        /// Check if Failed Login Attempts Analytic has been saved at DB
        /// </summary>
        public void IsAnalyticFailedLoginAttemptsSaved(Dictionary<string, string> results)
        {
            Assert.Multiple(() =>
            {
                Assert.That(results["event_type"], Is.EqualTo("FailedLoginAttempts"), "Event_Type is not FailedLoginAttempts");
                Assert.That(results["attempts"], Is.EqualTo(LoginPage.randomTimes.ToString()), "attempts is not "+ LoginPage.randomTimes);
                Assert.That(IsAnalyticTimestampCorrect(results["timestamp"]), Is.EqualTo(true), "Timestamp difference is higher than 30 sec");
            });
        }

        #endregion

        #region .: WhatsappJoined :.

        /// <summary>
        /// GetAnalyticWhatsappJoinedFromDatabase
        /// </summary>
        public Dictionary<string, string> GetAnalyticWhatsappJoinedFromDatabase()
        {
            Dictionary<string, string> results = new Dictionary<string, string>();

            NpgsqlConnection conn = ConnectToDabatase();

            NpgsqlCommand command = new NpgsqlCommand(
                "SELECT id, data->> 'EventType' as EVENT_TYPE, data->'Payload'->'Source' as SOURCE, data->'Payload'->'GroupId' as GROUP_ID, data->'Payload'->'TimeStamp' as TIMESTAMP FROM mt_doc_hivmonitorevent WHERE data->> 'EventType' = 'WhatsappJoined' order by TIMESTAMP desc", conn);

            try
            {
                NpgsqlDataReader dr = command.ExecuteReader();
                dr.Read();

                results.Add("id", String.Join("", dr[0].ToString().Split('"')));
                results.Add("event_type", String.Join("", dr[1].ToString().Split('"')));
                results.Add("source", String.Join("", dr[2].ToString().Split('"')));
                results.Add("group_id", String.Join("", dr[3].ToString().Split('"')));
                results.Add("timestamp", String.Join("", dr[4].ToString().Split('"')));

                Console.WriteLine("\n- Analytic:");
                foreach (KeyValuePair<string, string> entry in results)
                {
                    Console.WriteLine("   {0} = {1}", entry.Key, entry.Value);
                }
                Console.WriteLine("\n");

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception("Analytic from database couldn't be saved", ex);
            }

            conn.Close();

            return results;
        }

        /// <summary>
        /// Check if Whatsapp Joined Analytic has been saved at DB
        /// </summary>
        public void IsAnalyticWhatsappJoinedSaved(Dictionary<string, string> results)
        {
            Assert.Multiple(() =>
            {
                Assert.That(results["event_type"], Is.EqualTo("WhatsappJoined"), "Event_Type is not WhatsappJoined");
                Assert.That(results["group_id"], Is.EqualTo(ConvertAnalyticGroupIdToGroupName(CommunitiesPage.selectedGroup)), "group_id is not correct");
                Assert.That(IsAnalyticTimestampCorrect(results["timestamp"]), Is.EqualTo(true), "Timestamp difference is higher than 30 sec");
            });
        }


        private string ConvertAnalyticGroupIdToGroupName(int group)
        {
            string groupName = "";

            switch(group)
            {
                case 0:
                    return groupName = "H2iUHt0FSvB1O2IVNoMCLn";
                case 1:
                    return groupName = "KPe3JNXPL7DCKcGNHiGtLw";
                case 2:
                    return groupName = "IEZhcOGeILcEFfQpPxbX9c";
                case 3:
                    return groupName = "CcRKsmN9NcoDm1cB6AsUfM";
                case 4:
                    return groupName = "JPCjFvLNaCL4qlLnSNVfXi";
                case 5:
                    return groupName = "BADs9gv6HnfE9s7B9zkpXt";
            }
            return groupName;
        }

        #endregion

        #region .: UserLoggedIn :.

        /// <summary>
        /// GetAnalyticUserLoggedInFromDatabase
        /// </summary>
        public Dictionary<string, string> GetAnalyticUserLoggedInFromDatabase()
        {
            Dictionary<string, string> results = new Dictionary<string, string>();
            results.Clear();

            NpgsqlConnection conn = ConnectToDabatase();

            Thread.Sleep(TimeSpan.FromSeconds(7));

            NpgsqlCommand command = new NpgsqlCommand(
                "SELECT id, data->>'EventType' as EVENT_TYPE, data->'Payload'->'UserId' as USER_ID, data->'Payload'->'TimeStamp' as TIMESTAMP FROM mt_doc_hivmonitorevent WHERE data->> 'EventType' = 'UserLoggedIn' order by TIMESTAMP desc;", conn);
                     
            try
            {
                NpgsqlDataReader dr = command.ExecuteReader();
                dr.Read();

                results.Add("id", String.Join("", dr[0].ToString().Split('"')));
                results.Add("event_type", String.Join("", dr[1].ToString().Split('"')));
                results.Add("user_id", String.Join("", dr[2].ToString().Split('"')));
                results.Add("timestamp", String.Join("", dr[3].ToString().Split('"')));

                Console.WriteLine("\n- Analytic:");
                foreach (KeyValuePair<string, string> entry in results)
                {
                    Console.WriteLine("   {0} = {1}", entry.Key, entry.Value);
                }
                Console.WriteLine("\n");

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception("Analytic from database couldn't be saved", ex);
            }

            conn.Close();

            return results;
        }

        /// <summary>
        /// Check if UserLoggedIn Analytic has been saved at DB
        /// </summary>
        public void IsAnalyticUserLoggedInSaved(Dictionary<string, string> results, UserLogin user)
        {
            Assert.Multiple(() =>
            {
                Assert.That(results["event_type"], Is.EqualTo("UserLoggedIn"), "Event_Type is not UserLoggedIn");
                Assert.That(results["user_id"], Is.EqualTo(user.Uuid.ToString().Substring("ID: HI-M-".Length)), "user_id is not correct");
                Assert.That(IsAnalyticTimestampCorrect(results["timestamp"]), Is.EqualTo(true), "Timestamp difference is higher than 30 sec");
            });
        }

        #endregion

        #region .: BarcodeDataRequested :.

        /// <summary>
        /// GetAnalyticBarcodeDataRequestedFromDatabase
        /// </summary>
        public Dictionary<string, string> GetAnalyticBarcodeDataRequestedFromDatabase()
        {
            Dictionary<string, string> results = new Dictionary<string, string>();
            results.Clear();

            NpgsqlConnection conn = ConnectToDabatase();

            Thread.Sleep(TimeSpan.FromSeconds(7));

            NpgsqlCommand command = new NpgsqlCommand(
                "SELECT id, data->> 'EventType' as EVENT_TYPE, data->'Payload'->'Source' as SOURCE, data->'Payload'->'Barcodes'->'$values' as BARCODES, data->'Payload'->'TimeStamp' as TIMESTAMP FROM mt_doc_hivmonitorevent WHERE data->> 'EventType' = 'BarcodeDataRequested' order by TIMESTAMP desc", conn);

            try
            {
                NpgsqlDataReader dr = command.ExecuteReader();
                dr.Read();

                results.Add("id", String.Join("", dr[0].ToString().Split('"')));
                results.Add("event_type", String.Join("", dr[1].ToString().Split('"')));
                results.Add("user_id", String.Join("", dr[2].ToString().Split('"')));
                results.Add("barcodes", String.Join("", dr[3].ToString().Split('"','[',']')));
                results.Add("timestamp", String.Join("", dr[4].ToString().Split('"')));

                Console.WriteLine("\n- Analytic:");
                foreach (KeyValuePair<string, string> entry in results)
                {
                    Console.WriteLine("   {0} = {1}", entry.Key, entry.Value);
                }
                Console.WriteLine("\n");

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception("Analytic from database couldn't be saved", ex);
            }

            conn.Close();

            return results;
        }

        /// <summary>
        /// Check if BarcodeDataRequested Analytic has been saved at DB
        /// </summary>
        public void IsAnalyticBarcodeDataRequestedSaved(Dictionary<string, string> results, UserLogin user)
        {
            Assert.Multiple(() =>
            {
                Assert.That(results["event_type"], Is.EqualTo("BarcodeDataRequested"), "Event_Type is not BarcodeDataRequested");
                Assert.That(results["user_id"], Is.EqualTo(user.Uuid.ToString().Substring("ID: HI-M-".Length)), "user_id is not correct");
                Assert.That(results["barcodes"], Is.EqualTo(string.Join(", ", user.BarcodeIdList)), "barcodesList is not correct");
                Assert.That(IsAnalyticTimestampCorrect(results["timestamp"]), Is.EqualTo(true), "Timestamp difference is higher than 30 sec");
            });
        }

        #endregion


    }
}

