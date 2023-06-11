using Dapper;
using Microsoft.Extensions.Configuration;
using MovConDatabase;
using MovConDomain.Models;
using MovConRepository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MovConRepository.Datas
{
    public class ConteinerData : Data, IConteinerData
    {
        public ConteinerData(IConfiguration configuration) : base(configuration)
        {

        }

        public long Insert(ConteinerModel model)
        {
            DynamicParameters parameters = new DynamicParameters();

            string cmd = "INSERT INTO Conteineres (Cliente, Numero, Tipo, Status, Categoria) " +
                "OUTPUT INSERTED.PK_Id " + 
                "VALUES (@Cliente, @Numero, @Tipo, @Status, @Categoria) ";

            parameters.Add("@Cliente", model.Cliente, System.Data.DbType.String, 
                System.Data.ParameterDirection.Input, model.Cliente.Length);
            parameters.Add("@Numero", model.Numero, System.Data.DbType.String, 
                System.Data.ParameterDirection.Input, model.Numero.Length);
            parameters.Add("@Tipo", model.Tipo, System.Data.DbType.String, 
                System.Data.ParameterDirection.Input, model.Tipo.ToString().Length);
            parameters.Add("@Status", model.Status, System.Data.DbType.String, 
                System.Data.ParameterDirection.Input, model.Status.ToString().Length);
            parameters.Add("@Categoria", model.Categoria, System.Data.DbType.String, 
                System.Data.ParameterDirection.Input, model.Categoria.ToString().Length);

            _database.Open();

            long newId = _conn.QuerySingle<long>(cmd, parameters);

            _database.Close();

            return newId;
        }

        public int Update(ConteinerModel model)
        {
            DynamicParameters parameters = new DynamicParameters();

            string cmd = "UPDATE Conteineres " +
                "SET Cliente = @Cliente, Numero = @Numero, Tipo = @Tipo, Status = @Status, Categoria = @Categoria " +
                "WHERE PK_Id = @Id ";

            parameters.Add("@Id", model.Id, System.Data.DbType.Int64,
                System.Data.ParameterDirection.Input, 8);
            parameters.Add("@Cliente", model.Cliente, System.Data.DbType.String,
                System.Data.ParameterDirection.Input, model.Cliente.Length);
            parameters.Add("@Numero", model.Numero, System.Data.DbType.String,
                System.Data.ParameterDirection.Input, model.Numero.Length);
            parameters.Add("@Tipo", model.Tipo, System.Data.DbType.String,
                System.Data.ParameterDirection.Input, model.Tipo.ToString().Length);
            parameters.Add("@Status", model.Status, System.Data.DbType.String,
                System.Data.ParameterDirection.Input, model.Status.ToString().Length);
            parameters.Add("@Categoria", model.Categoria, System.Data.DbType.String,
                System.Data.ParameterDirection.Input, model.Categoria.ToString().Length);

            _database.Open();

            int qtd = _conn.Execute(cmd, parameters);

            _database.Close();

            return qtd;
        }

        public int UpdateByNumero(ConteinerModel model)
        {
            DynamicParameters parameters = new DynamicParameters();

            string cmd = "UPDATE Conteineres " +
                "SET Cliente = @Cliente, Tipo = @Tipo, Status = @Status, Categoria = @Categoria " +
                "WHERE Numero = @Numero ";

            parameters.Add("@Cliente", model.Cliente, System.Data.DbType.String,
                System.Data.ParameterDirection.Input, model.Cliente.Length);
            parameters.Add("@Tipo", model.Tipo, System.Data.DbType.String,
                System.Data.ParameterDirection.Input, model.Tipo.ToString().Length);
            parameters.Add("@Status", model.Status, System.Data.DbType.String,
                System.Data.ParameterDirection.Input, model.Status.ToString().Length);
            parameters.Add("@Categoria", model.Categoria, System.Data.DbType.String,
                System.Data.ParameterDirection.Input, model.Categoria.ToString().Length);
            parameters.Add("@Numero", model.Numero, System.Data.DbType.String,
                System.Data.ParameterDirection.Input, model.Numero.Length);

            _database.Open();

            int qtd = _conn.Execute(cmd, parameters);

            _database.Close();

            return qtd;
        }
        
        public int Delete(long id)
        {
            DynamicParameters parameters = new DynamicParameters();

            string cmd = "DELETE FROM Conteineres WHERE PK_Id = @Id ";

            parameters.Add("@Id", id, System.Data.DbType.Int64,
                System.Data.ParameterDirection.Input, 8);

            _database.Open();

            int qtd = _conn.Execute(cmd, parameters);

            _database.Close();

            return qtd;
        }

        public int DeleteByNumero(string numero)
        {
            DynamicParameters parameters = new DynamicParameters();

            string cmd = "DELETE FROM Conteineres WHERE Numero = @Numero ";

            parameters.Add("@Numero", numero, System.Data.DbType.String,
                System.Data.ParameterDirection.Input, numero.Length);

            _database.Open();

            int qtd = _conn.Execute(cmd, parameters);

            _database.Close();

            return qtd;
        }

        public ConteinerModel Get(long id)
        {
            DynamicParameters parameters = new DynamicParameters();

            string cmd = "SELECT PK_Id as Id, Cliente, Numero, Tipo, Status, Categoria " +
                "FROM Conteineres WHERE PK_Id = @Id ";

            parameters.Add("@Id", id, System.Data.DbType.Int64,
                System.Data.ParameterDirection.Input, 8);

            _database.Open();

            ConteinerModel model = _conn.QuerySingleOrDefault<ConteinerModel>(cmd, parameters);

            _database.Close();

            return model;
        }

        public ConteinerModel GetByNumero(string numero)
        {
            DynamicParameters parameters = new DynamicParameters();

            string cmd = "SELECT PK_Id as Id, Cliente, Numero, Tipo, Status, Categoria " +
                "FROM Conteineres WHERE Numero = @Numero ";

            parameters.Add("@Numero", numero, System.Data.DbType.String,
                System.Data.ParameterDirection.Input, numero.Length);

            _database.Open();

            ConteinerModel model = _conn.QuerySingleOrDefault<ConteinerModel>(cmd, parameters);

            _database.Close();

            return model;
        }

        public List<ConteinerModel> List()
        {
            string cmd = "SELECT PK_Id as Id, Cliente, Numero, Tipo, Status, Categoria " +
                "FROM Conteineres ";

            _database.Open();

            List<ConteinerModel> list = _conn.Query<ConteinerModel>(cmd).ToList();

            _database.Close();

            return list;
        }
    }
}
