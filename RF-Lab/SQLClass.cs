using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace RFLab
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
                    MessageBox.Show("Error during the opening of the database!");
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
                            MessageBox.Show("New record has created!" + Environment.NewLine + 
                                            "Rows Affected: " + rowsAffected);
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
                            MessageBox.Show("Password has changed!" + Environment.NewLine + 
                                            "Rows Affected: " + rowsAffected);
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
                SqlConnection connect = new SqlConnection("Data Source=" + Properties.Settings.Default.Server + 
                                                          ";Initial Catalog=" + Properties.Settings.Default.Database +
                                                          "; Security=True");
                return connect;
            }
            catch (Exception ex)
            {
                throw new DefaultException("Error during connecting to the database!\nThe message:\n", ex);
            }
        }

        private int GetRfgunSzeriaSzamCount(SqlConnection sqlConnection)
        {
            int returnValue = -1;
            try
            {
                SqlCommand userExists = new SqlCommand("SELECT COUNT(RfgunSzériaSzám) FROM " + Properties.Settings.Default.Server + 
                                                       " WHERE Felhasználónév LIKE @user", sqlConnection);
                userExists.Parameters.Add("@user", SqlDbType.NVarChar);
                userExists.Parameters["@user"].Value = lista[i - 2];
                returnValue = (int)userExists.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new DefaultException("Error during the SELECT query!\nThe message:\n", ex);
            }
            return returnValue;

        }
        private int AddNewLine(SqlConnection sqlConnection)
        {
            int returnValue = -1;
            try
            {
                SqlCommand newLine = new SqlCommand("INSERT INTO" + Properties.Settings.Default.Table + 
                                                    "(Felhasználónév, Jelszó) VALUES(@user, @password)", sqlConnection);
                newLine.Parameters.Add("@user", SqlDbType.NVarChar);
                newLine.Parameters["@user"].Value = lista[i - 2];
                newLine.Parameters.Add("@password", SqlDbType.Int);
                newLine.Parameters["@password"].Value = lista[i - 1];
                returnValue = newLine.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DefaultException("Error during the INSERT query!\nThe message:\n", ex);
            }
            return returnValue;

        }
        private int UpdateExistLine(SqlConnection sqlConnection)
        {
            int returnValue = -1;
            try
            {
                SqlCommand pwRefresh = new SqlCommand("UPDATE" + Properties.Settings.Default.Table + 
                                                      "SET Jelszó = @password WHERE Felhasználónév = @user;", sqlConnection);
                pwRefresh.Parameters.Add("@user", SqlDbType.NVarChar);
                pwRefresh.Parameters["@user"].Value = lista[i - 2];
                pwRefresh.Parameters.Add("@password", SqlDbType.Int);
                pwRefresh.Parameters["@password"].Value = lista[i - 1];
                returnValue = pwRefresh.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DefaultException("Error during the UPDATE query!\nThe message:\n", ex);
            }
            return returnValue;

        }
    }
}
