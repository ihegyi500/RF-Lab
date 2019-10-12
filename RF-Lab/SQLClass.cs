using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using RFLab;
using System.Data;

namespace Nyomtatas
{
    class SQLClass
    {
        private int i;
        private readonly int textboxcounter;
        private readonly List<string> lista;

        public SQLClass(List<string> listap, int textboxcounterp)
        {
            lista = listap;
            textboxcounter = textboxcounterp;
        }

        public void Sqlcon()
        {
            using (SqlConnection sqlConnection = CreateConnection())
            {
                try
                {
                    sqlConnection.Open();
                }
                catch
                {
                    MessageBox.Show("Hiba az adatbázis kapcsolat létrehozásakor!");
                    sqlConnection.Close();
                    return;
                }

                for (i = 2; i <= textboxcounter; i = i + 2)
                {
                    int exists = GetRfgunSzeriaSzamCount(sqlConnection);
                    if (exists == 0)
                    {
                        try
                        {
                            int rowsAffected = AddNewLine(sqlConnection);
                            MessageBox.Show("New record has created!" + Environment.NewLine + "Rows Affected: " + rowsAffected);
                        }
                        catch (DefaultException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            int rowsAffected = UpdateExistLine(sqlConnection);
                            MessageBox.Show("Password has changed!" + Environment.NewLine + "Rows Affected: " + rowsAffected);
                        }
                        catch (DefaultException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                sqlConnection.Close();
            }
        }


        private SqlConnection CreateConnection()
        {
            try
            {
                SqlConnection connect = new SqlConnection("Data Source=KUNSHUMS001;Initial Catalog=Kunsziget_IS;" +
                    "Integrated Security=True");
                return connect;
            }
            catch (Exception ex)
            {
                throw new DefaultException("Hiba lépett fel az adatbázis kapcsolat kiépítése során!\nA hibaüzenet:\n", ex);
            }
        }

        private int GetRfgunSzeriaSzamCount(SqlConnection sqlConnection)
        {
            int returnValue = -1;
            try
            {
                SqlCommand userExists = new SqlCommand("SELECT COUNT(RfgunSzériaSzám) FROM RFGUN WHERE Felhasználónév LIKE @user", sqlConnection);
                userExists.Parameters.Add("@user", SqlDbType.NVarChar);
                userExists.Parameters["@user"].Value = lista[i - 2];
                returnValue = (int)userExists.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new DefaultException("Hiba lépett fel az adatok lekérdezése során!\nA hibaüzenet:\n", ex);
            }
            return returnValue;

        }

        private int AddNewLine(SqlConnection sqlConnection)
        {
            int returnValue = -1;
            try
            {
                SqlCommand newLine = new SqlCommand("INSERT INTO RFGUN (Felhasználónév, Jelszó) VALUES(@user, @password)", sqlConnection);
                newLine.Parameters.Add("@user", SqlDbType.NVarChar);
                newLine.Parameters["@user"].Value = lista[i - 2];
                newLine.Parameters.Add("@password", SqlDbType.Int);
                newLine.Parameters["@password"].Value = lista[i - 1];
                returnValue = newLine.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DefaultException("Hiba lépett fel az adatok rögzítése során!\nA hibaüzenet:\n", ex);
            }
            return returnValue;

        }

        #region Létezőr sor módosítása
        /// <summary>
        /// Egy már létező sort módosít az adatbázisban
        /// </summary>
        /// <param name="sqlConnection">Egy sql kapcsolat ahhoz az adatbázishoz, amiben a módosítást el szeretné végezni</param>
        /// <returns>A módosított sorok száma</returns>
        private int UpdateExistLine(SqlConnection sqlConnection)
        {
            int returnValue = -1;
            try
            {
                SqlCommand pwRefresh = new SqlCommand("UPDATE RFGUN SET Jelszó = @password WHERE Felhasználónév = @user;", sqlConnection);
                pwRefresh.Parameters.Add("@user", SqlDbType.NVarChar);
                pwRefresh.Parameters["@user"].Value = lista[i - 2];
                pwRefresh.Parameters.Add("@password", SqlDbType.Int);
                pwRefresh.Parameters["@password"].Value = lista[i - 1];
                returnValue = pwRefresh.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DefaultException("Hiba lépett fel az adatok módosítása során!\nA hibaüzenet:\n", ex);
            }
            return returnValue;

        }
        #endregion


        ~SQLClass()
        {

        }
    }
}
