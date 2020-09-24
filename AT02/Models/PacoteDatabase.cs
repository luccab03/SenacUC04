using System.Collections.Generic;
using MySqlConnector;

namespace AT02.Models
{
    public class PacoteDatabase
    {
        private const string DataString = "Database=DestinoCerto;Server=localhost;Port=8889;User Id=root;Password=root";

        public void Inserir(Pacote pacote)
        {
            MySqlConnection connection = new MySqlConnection(DataString);
            connection.Open();
            string comando =
                "INSERT INTO Pacotes(nomePacote, origemPacote, destinoPacote, atrativosPacote, saidaPacote, retornoPacote, idCriador) VALUES (@Nome,@Origem,@Destino,@Atrativos,@Saida,@Retorno,@IdCriador)";
            MySqlCommand command = new MySqlCommand(comando, connection);
            command.Parameters.AddWithValue("@Nome", pacote.Nome);
            command.Parameters.AddWithValue("@Origem", pacote.Origem);
            command.Parameters.AddWithValue("@Destino", pacote.Destino);
            command.Parameters.AddWithValue("@Atrativos", pacote.Atrativos);
            command.Parameters.AddWithValue("@Saida", pacote.Saida);
            command.Parameters.AddWithValue("@Retorno", pacote.Retorno);
            command.Parameters.AddWithValue("@IdCriador", pacote.IdCriador);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Alterar(Pacote pacote)
        {
            MySqlConnection connection = new MySqlConnection(DataString);
            connection.Open();
            string sqlCommand =
                "UPDATE Pacotes SET nomePacote = @Nome, origemPacote = @Origem, destinoPacote = @Destino, atrativosPacote = @Atrativos, saidaPacote = @Saida, retornoPacote = @Retorno, idCriador = @IdC WHERE idPacote = @IdP";
            MySqlCommand command = new MySqlCommand(sqlCommand, connection);
            command.Parameters.AddWithValue("@Nome", pacote.Nome);
            command.Parameters.AddWithValue("@Origem", pacote.Origem);
            command.Parameters.AddWithValue("@Destino", pacote.Destino);
            command.Parameters.AddWithValue("@Atrativos", pacote.Atrativos);
            command.Parameters.AddWithValue("@Saida", pacote.Saida);
            command.Parameters.AddWithValue("@Retorno", pacote.Retorno);
            command.Parameters.AddWithValue("@IdC", pacote.IdCriador);
            command.Parameters.AddWithValue("@IdP", pacote.IdPacote);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Excluir(int id)
        {
            MySqlConnection connection = new MySqlConnection(DataString);
            connection.Open();
            string sqlCommand = "DELETE From Pacotes WHERE idPacote = @Id";
            MySqlCommand command = new MySqlCommand(sqlCommand, connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Pacote Query(int id)
        {
            MySqlConnection connection = new MySqlConnection(DataString);
            connection.Open();
            string sqlString = "SELECT * FROM Pacotes WHERE idPacote = @Id";
            MySqlCommand command = new MySqlCommand(sqlString, connection);
            command.Parameters.AddWithValue("@Id", id);
            MySqlDataReader reader = command.ExecuteReader();
            Pacote pacote = new Pacote();
            while (reader.Read())
            {
                if (reader.GetInt32("idPacote") == id)
                {
                    pacote.IdPacote = reader.GetInt32("idPacote");

                    if (!reader.IsDBNull(reader.GetOrdinal("nomePacote")))
                        pacote.Nome = reader.GetString("nomePacote");
                    if (!reader.IsDBNull(reader.GetOrdinal("origemPacote")))
                        pacote.Origem = reader.GetString("origemPacote");
                    if (!reader.IsDBNull(reader.GetOrdinal("destinoPacote")))
                        pacote.Destino = reader.GetString("destinoPacote");
                    if (!reader.IsDBNull(reader.GetOrdinal("atrativosPacote")))
                        pacote.Atrativos = reader.GetString("atrativosPacote");
                    if (!reader.IsDBNull(reader.GetOrdinal("saidaPacote")))
                        pacote.Saida = reader.GetDateTime("saidaPacote");
                    if (!reader.IsDBNull(reader.GetOrdinal("retornoPacote")))
                        pacote.Retorno = reader.GetDateTime("retornoPacote");
                    if (!reader.IsDBNull(reader.GetOrdinal("idCriador")))
                        pacote.IdCriador = reader.GetInt32("idCriador");
                }
            }
            connection.Close();
            return pacote;
        }

        public List<Pacote> Query()
        {
            MySqlConnection connection = new MySqlConnection(DataString);
            connection.Open();
            string sqlCommand = "SELECT * FROM Pacotes ORDER BY nomePacote";
            MySqlCommand command = new MySqlCommand(sqlCommand, connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<Pacote> lista = new List<Pacote>();
            while (reader.Read())
            {
                Pacote pacote = new Pacote();
                pacote.IdPacote = reader.GetInt32("idPacote");

                if (!reader.IsDBNull(reader.GetOrdinal("nomePacote")))
                    pacote.Nome = reader.GetString("nomePacote");
                if (!reader.IsDBNull(reader.GetOrdinal("origemPacote")))
                    pacote.Origem = reader.GetString("origemPacote");
                if (!reader.IsDBNull(reader.GetOrdinal("destinoPacote")))
                    pacote.Destino = reader.GetString("destinoPacote");
                if (!reader.IsDBNull(reader.GetOrdinal("atrativosPacote")))
                    pacote.Atrativos = reader.GetString("atrativosPacote");
                if (!reader.IsDBNull(reader.GetOrdinal("saidaPacote")))
                    pacote.Saida = reader.GetDateTime("saidaPacote");
                if (!reader.IsDBNull(reader.GetOrdinal("retornoPacote")))
                    pacote.Retorno = reader.GetDateTime("retornoPacote");
                if (!reader.IsDBNull(reader.GetOrdinal("idCriador")))
                    pacote.IdCriador = reader.GetInt32("idCriador");
                lista.Add(pacote);
            }
            connection.Close();
            return lista;
        }
    }
}