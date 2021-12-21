using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Aviv.Eleicao.Terminal
{
    public class MsSqlConnection
    {

        #region Construtores
        private string connection;
        private string database = ConfigurationManager.AppSettings["DATABASE"];
        /// <summary>
        /// Nome do banco a ser conectado
        /// </summary>
        public string Database
        {
            get { return database; }
            set { database = value; }
        }
        private string password = ConfigurationManager.AppSettings["PASSWORD"];
        /// <summary>
        /// Senha do usuário do banco a ser conectado
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string server = ConfigurationManager.AppSettings["SERVER"];
        /// <summary>
        /// Host do servidor a ser conectado
        /// </summary>
        public string Server
        {
            get { return server; }
            set { server = value; }
        }
        private string user = ConfigurationManager.AppSettings["USER"];
        /// <summary>
        /// Usuário a ser conectado no banco
        /// </summary>
        public string User
        {
            get { return user; }
            set { user = value; }
        }
        #endregion

        private void FechaConexao(SqlConnection _connection)
        {
            _connection.Close();
            _connection = null;
        }

        protected void MontaStringConexao()
        {
            this.connection = "Password=" + this.password + "; User Id=" + this.user + "; Initial Catalog=" + this.database + "; Data Source=" + this.server + " ; Pooling=false;";
        }

        /// <summary>
        /// Executa a procedure informada
        /// </summary>
        /// <param name="nomeProcedure"></param>
        /// <param name="SqlParametros"></param>
        public void ExecutaProcedure(string nomeProcedure, params SqlParameter[] SqlParametros)
        {
            SqlConnection connection = this.RetornaConexao();
            SqlCommand command = new SqlCommand(nomeProcedure, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter parameter = null;
            foreach (SqlParameter parameter2 in SqlParametros)
            {
                parameter = command.Parameters.Add(parameter2);
                parameter2.Direction = ParameterDirection.Input;
            }
            command.ExecuteReader(CommandBehavior.CloseConnection);
            command.Dispose();
            this.FechaConexao(connection);
        }

        /// <summary>
        /// Executa uma procedure e retorna seus resultados num SqlDataReader
        /// </summary>
        /// <param name="nomeProcedure"></param>
        /// <param name="SqlParametros"></param>
        /// <returns></returns>
        public SqlDataReader RetornaSqlDataReader(string nomeProcedure, params SqlParameter[] SqlParametros)
        {
            SqlConnection connection = this.RetornaConexao();
            SqlCommand command = new SqlCommand(nomeProcedure, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter parameter = null;
            foreach (SqlParameter parameter2 in SqlParametros)
            {
                parameter = command.Parameters.Add(parameter2);
                parameter2.Direction = ParameterDirection.Input;
            }
            command.Dispose();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// Executa uma procedure e retorna seus resultados num DataSet
        /// </summary>
        /// <param name="nomeProcedure"></param>
        /// <param name="dt"></param>
        /// <param name="SqlParametros"></param>
        /// <returns></returns>
        public DataSet RetornaDataSet(string nomeProcedure, string dt, params SqlParameter[] SqlParametros)
        {
            SqlConnection selectConnection = this.RetornaConexao();
            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(nomeProcedure, selectConnection)
            {
                SelectCommand = { CommandType = CommandType.StoredProcedure }
            };
            SqlParameter parameter = null;
            foreach (SqlParameter parameter2 in SqlParametros)
            {
                adapter.SelectCommand.Parameters.Add(parameter);
                parameter2.Direction = ParameterDirection.Input;
            }
            adapter.Fill(dataSet, dt);
            this.FechaConexao(selectConnection);
            adapter.Dispose();
            return dataSet;
        }

        /// <summary>
        /// Executa uma procedure e retorna seus resultados num DataTable
        /// </summary>
        /// <param name="nomeProcedure"></param>
        /// <param name="SqlParametros"></param>
        /// <returns></returns>
        public DataTable RetornaDataTable(string nomeProcedure, params SqlParameter[] SqlParametros)
        {
            SqlConnection connection = this.RetornaConexao();
            SqlCommand selectCommand = new SqlCommand(nomeProcedure, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            SqlParameter parameter = null;
            foreach (SqlParameter parameter2 in SqlParametros)
            {
                parameter = selectCommand.Parameters.Add(parameter2);
                parameter2.Direction = ParameterDirection.Input;
            }
            adapter.Fill(dataTable);
            this.FechaConexao(connection);
            adapter.Dispose();
            return dataTable;
        }

        private SqlConnection RetornaConexao()
        {
            MontaStringConexao();
            SqlConnection connection = new SqlConnection(this.connection);
            connection.Open();
            return connection;
        }
    }
}
