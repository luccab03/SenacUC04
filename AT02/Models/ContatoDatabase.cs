using MySqlConnector;

namespace AT02.Models
{
    public class ContatoDatabase
    {
        private const string DataString = "Database=DestinoCerto;Server=localhost;Port=8889;User Id=root;Password=root";

        public void Inserir(Contato contato)
        {
            MySqlConnection connection = new MySqlConnection(DataString);
            connection.Open();
            string sqlCommand =
                "INSERT INTO Contato(NomeCompleto,Email,Assunto,Mensagem) VALUES (@Nome,@Email,@Assunto,@Mensagem);";
            MySqlCommand command = new MySqlCommand(sqlCommand, connection);
            command.Parameters.AddWithValue("@Nome", contato.NomeCompleto);
            command.Parameters.AddWithValue("@Email", contato.Email);
            command.Parameters.AddWithValue("@Mensagem", contato.Mensagem);
            command.Parameters.AddWithValue("@Assunto", contato.Assunto);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}