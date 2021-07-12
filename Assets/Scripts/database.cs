protected void Button1_Click(object sender, EventArgs e)
{
    MySql.Data.MySqlClient.MySqlConnection connection;
    string server = "db.cce-solutions.dk";
    string database = "gnn3";
    string uid = "gnn3";
    string password = "essos991";
    string connectionString;
    connectionString = "SERVER=" + server + ";" + "DATABASE=" +
    database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
    connection = new MySqlConnection(connectionString);
    try
    {
        connection.ConnectionString = connectionString;
        connection.Open();
        MySqlCommand cmd = new MySqlCommand("insert into  web626445bocce-users (player1) values(@GABIN NANKEU)", connection);
        cmd.Parameters.AddWithValue("@player1", 'player1');
        
        cmd.ExecuteNonQuery();
    }
    catch (Exception ex)
    {
        DisplayMessage.Text = "Error occured. Please try again later.";
    }
    connection.Close();
    }}