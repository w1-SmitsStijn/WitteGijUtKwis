using System.Data.SqlClient;

namespace WitteGijUtKwis
{
    class LoginManager
    {
        private readonly SqlConnection _conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog = WitteGijUtKwis; Integrated Security = True");

        /// <summary>
        /// kijkt of de username en password met elkaar overheen komen
        /// </summary>
        public bool CheckLogin(string spelersnaam, string wachtwoord)
        {
            _conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT wachtwoord FROM Speler WHERE spelersnaam='" + spelersnaam + "'", _conn);

            using (SqlDataReader read = cmd.ExecuteReader())
            {
                if (read.Read())
                {
                    if (read[0].ToString() == wachtwoord)
                    {
                        _conn.Close();
                        return true;
                    }
                }
            }


            _conn.Close();

            return false;
        }

        /// <summary>
        /// kijkt of de username al bestaat en anders zet die de username en password in de database
        /// </summary>
        public bool CheckRegister(string spelersnaam, string wachtwoord, string plaatsnaam, int leeftijd)
        {
            _conn.Open();

            using (SqlDataReader reader = new SqlCommand("SELECT spelersnaam FROM Speler WHERE spelersnaam='" + spelersnaam + "';", _conn).ExecuteReader())
            {
                if (reader.Read())
                {
                    _conn.Close();
                    return false;

                }
            }

            bool value = false;
            string carnavalsnaam = null;

            using (SqlDataReader reader = new SqlCommand("SELECT carnavalsnaam FROM Plaats WHERE plaatsnaam='" + plaatsnaam + "';", _conn).ExecuteReader())
            {
                if (reader.Read())
                {
                    if (reader[0].ToString() != "NULL")
                    {
                        carnavalsnaam = reader[0].ToString();
                        value = true;
                        
                    }
                }
            }

            if (value)
            {
                new SqlCommand("INSERT INTO Speler (spelersnaam, wachtwoord, plaatsnaam, leeftijd, carnavalsnaam) VALUES ('" + spelersnaam + "', '" + wachtwoord + "', '" + plaatsnaam + "', " + leeftijd + ", '" + carnavalsnaam + "');", _conn).ExecuteNonQuery();
            }

            else
            {
                new SqlCommand("INSERT INTO Speler (spelersnaam, wachtwoord, plaatsnaam, leeftijd) VALUES ('" + spelersnaam + "', '" + wachtwoord + "', '" + plaatsnaam + "', " + leeftijd + ");", _conn).ExecuteNonQuery();
            }

            _conn.Close();

            return true;
        }
    }
}
