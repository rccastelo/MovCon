using Dapper;
using Microsoft.Extensions.Configuration;
using MovConDatabase;
using MovConDomain.Models;
using MovConRepository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public List<ConteinerEntity> Filter(ConteinerEntity entity)
        {
            DynamicParameters parameters = new DynamicParameters();
            List<ConteinerEntity> list = null;
            bool hasParam = false;

            string queryCmd = "SELECT PK_Id as Id, Cliente, Numero, Tipo, Status, Categoria " +
                    "FROM Conteineres ";
            StringBuilder queryFilter = new StringBuilder();

            if (entity.Id > 0)
            {
                parameters.Add("@Id", entity.Id, System.Data.DbType.Int64,
                    System.Data.ParameterDirection.Input, 8);
                hasParam = true;
                if (!string.IsNullOrWhiteSpace(queryFilter.ToString())) queryFilter.Append(" AND ");
                queryFilter.Append(" PK_Id = @Id ");
            }
            if (!string.IsNullOrWhiteSpace(entity.Cliente))
            {
                parameters.Add("@Cliente", entity.Cliente, System.Data.DbType.String,
                    System.Data.ParameterDirection.Input, entity.Cliente.Length);
                hasParam = true;
                if (!string.IsNullOrWhiteSpace(queryFilter.ToString())) queryFilter.Append(" AND ");
                queryFilter.Append(" Cliente = @Cliente ");
            }
            if (!string.IsNullOrWhiteSpace(entity.Numero))
            {
                parameters.Add("@Numero", entity.Numero, System.Data.DbType.String,
                    System.Data.ParameterDirection.Input, entity.Numero.Length);
                hasParam = true;
                if (!string.IsNullOrWhiteSpace(queryFilter.ToString())) queryFilter.Append(" AND ");
                queryFilter.Append(" Numero = @Numero ");
            }
            if (!string.IsNullOrWhiteSpace(entity.Tipo))
            {
                parameters.Add("@Tipo", entity.Tipo, System.Data.DbType.String,
                    System.Data.ParameterDirection.Input, entity.Tipo.Length);
                hasParam = true;
                if (!string.IsNullOrWhiteSpace(queryFilter.ToString())) queryFilter.Append(" AND ");
                queryFilter.Append(" Tipo = @Tipo ");
            }
            if (!string.IsNullOrWhiteSpace(entity.Status))
            {
                parameters.Add("@Status", entity.Status, System.Data.DbType.String,
                    System.Data.ParameterDirection.Input, entity.Status.Length);
                hasParam = true;
                if (!string.IsNullOrWhiteSpace(queryFilter.ToString())) queryFilter.Append(" AND ");
                queryFilter.Append(" Status = @Status ");
            }
            if (!string.IsNullOrWhiteSpace(entity.Categoria))
            {
                parameters.Add("@Categoria", entity.Categoria, System.Data.DbType.String,
                    System.Data.ParameterDirection.Input, entity.Categoria.Length);
                hasParam = true;
                if (!string.IsNullOrWhiteSpace(queryFilter.ToString())) queryFilter.Append(" AND ");
                queryFilter.Append(" Categoria = @Categoria ");
            }

            _database.Open();

            if (hasParam)
            {
                list = _conn.Query<ConteinerEntity>(queryCmd + " WHERE " + queryFilter.ToString(), parameters).ToList();
            } else {
                list = _conn.Query<ConteinerEntity>(queryCmd).ToList();
            }

            _database.Close();

            return list;
        }
    }
}
