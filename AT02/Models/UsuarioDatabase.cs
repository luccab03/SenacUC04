using System.Collections.Generic;
using MySqlConnector;

namespace AT02.Models
{
    public class UsuarioDatabase
    {
        private const string DataString = "Database=DestinoCerto;Server=localhost;Port=8889;User Id=root;Password=root";

        public void Insert(Usuario usuario)
        {
            MySqlConnection connection = new MySqlConnection(DataString);
            connection.Open();
            string commando =
                "INSERT INTO Usuarios(nomeUsuario,dataNascimento, loginUsuario, senhaUsuario, tipoUsuario) VALUES (@Nome,@Data,@Login,@Senha,@Tipo)";
            MySqlCommand command = new MySqlCommand(commando, connection);
            command.Parameters.AddWithValue("@Nome", usuario.Nome);
            command.Parameters.AddWithValue("@Data", usuario.Nascimento);
            command.Parameters.AddWithValue("@Login", usuario.Login);
            command.Parameters.AddWithValue("@Senha", usuario.Senha);
            command.Parameters.AddWithValue("@Tipo", usuario.Tipo);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Usuario Query(string login)
        {
            MySqlConnection connection = new MySqlConnection(DataString);
            connection.Open();
            string comando = "SELECT * FROM Usuarios WHERE loginUsuario = @Id";
            MySqlCommand command = new MySqlCommand(comando, connection);
            command.Parameters.AddWithValue("@Id", login);
            MySqlDataReader reader = command.ExecuteReader();
            Usuario user = null;
            while (reader.Read())
            {
                if (reader.GetString("loginUsuario") == login)
                {
                    user = new Usuario();
                    user.Id = reader.GetInt32("idUsuario");

                    if (!reader.IsDBNull(reader.GetOrdinal("nomeUsuario")))
                        user.Nome = reader.GetString("nomeUsuario");
                    if (!reader.IsDBNull(reader.GetOrdinal("dataNascimento")))
                        user.Nascimento = reader.GetDateTime("dataNascimento");
                    if (!reader.IsDBNull(reader.GetOrdinal("loginUsuario")))
                        user.Login = reader.GetString("loginUsuario");
                    if (!reader.IsDBNull(reader.GetOrdinal("senhaUsuario")))
                        user.Senha = reader.GetString("senhaUsuario");
                    if (!reader.IsDBNull(reader.GetOrdinal("tipoUsuario")))
                        user.Tipo = reader.GetInt32("tipoUsuario");
                }
            }

            connection.Close();
            return user;
        }

        public Usuario Query(int id)
        {
            MySqlConnection connection = new MySqlConnection(DataString);
            connection.Open();
            string comando = "SELECT * FROM Usuarios WHERE idUsuario = @Id";
            MySqlCommand command = new MySqlCommand(comando, connection);
            command.Parameters.AddWithValue("@Id", id);
            MySqlDataReader reader = command.ExecuteReader();
            Usuario user = null;
            while (reader.Read())
            {
                if (reader.GetInt32("idUsuario") == id)
                {
                    user = new Usuario();
                    user.Id = reader.GetInt32("idUsuario");

                    if (!reader.IsDBNull(reader.GetOrdinal("nomeUsuario")))
                        user.Nome = reader.GetString("nomeUsuario");
                    if (!reader.IsDBNull(reader.GetOrdinal("dataNascimento")))
                        user.Nascimento = reader.GetDateTime("dataNascimento");
                    if (!reader.IsDBNull(reader.GetOrdinal("loginUsuario")))
                        user.Login = reader.GetString("loginUsuario");
                    if (!reader.IsDBNull(reader.GetOrdinal("senhaUsuario")))
                        user.Senha = reader.GetString("senhaUsuario");
                    if (!reader.IsDBNull(reader.GetOrdinal("tipoUsuario")))
                        user.Tipo = reader.GetInt32("tipoUsuario");
                }
            }

            connection.Close();
            return user;
        }

        public List<Usuario> Query()
        {
            MySqlConnection connection = new MySqlConnection(DataString);
            connection.Open();
            string comando = "SELECT * FROM Usuarios ORDER BY nomeUsuario";
            MySqlCommand command = new MySqlCommand(comando, connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<Usuario> lista = new List<Usuario>();
            while (reader.Read())
            {
                Usuario user = new Usuario();
                user.Id = reader.GetInt32("idUsuario");

                if (!reader.IsDBNull(reader.GetOrdinal("nomeUsuario")))
                    user.Nome = reader.GetString("nomeUsuario");
                if (!reader.IsDBNull(reader.GetOrdinal("dataNascimento")))
                    user.Nascimento = reader.GetDateTime("dataNascimento");
                if (!reader.IsDBNull(reader.GetOrdinal("loginUsuario")))
                    user.Login = reader.GetString("loginUsuario");
                if (!reader.IsDBNull(reader.GetOrdinal("senhaUsuario")))
                    user.Senha = reader.GetString("senhaUsuario");
                if (!reader.IsDBNull(reader.GetOrdinal("tipoUsuario")))
                    user.Tipo = reader.GetInt32("tipoUsuario");

                lista.Add(user);
            }

            connection.Close();
            return lista;
        }

        public void Remover(int id)
        {
            MySqlConnection connection = new MySqlConnection(DataString);
            connection.Open();
            string comando = "DELETE FROM Usuarios WHERE idUsuario = @Id";
            MySqlCommand command = new MySqlCommand(comando, connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Alterar(Usuario usuario)
        {
            MySqlConnection connection = new MySqlConnection(DataString);
            connection.Open();
            string commandString =
                "UPDATE Usuarios SET nomeUsuario = @Nome, dataNascimento = @Data, loginUsuario = @Login, senhaUsuario = @Senha, tipoUsuario = @Tipo WHERE idUsuario = @Id";
            MySqlCommand command = new MySqlCommand(commandString, connection);
            command.Parameters.AddWithValue("@Nome", usuario.Nome);
            command.Parameters.AddWithValue("@Id", usuario.Id);
            command.Parameters.AddWithValue("@Data", usuario.Nascimento);
            command.Parameters.AddWithValue("@Login", usuario.Login);
            command.Parameters.AddWithValue("@Senha", usuario.Senha);
            command.Parameters.AddWithValue("@Tipo", usuario.Tipo);
            command.ExecuteNonQuery();
            connection.Close();
        }

        
    }
}