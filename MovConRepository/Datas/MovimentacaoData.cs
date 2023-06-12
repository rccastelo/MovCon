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
    public class MovimentacaoData : Data, IMovimentacaoData
    {
        public MovimentacaoData(IConfiguration configuration) : base(configuration)
        {

        }

        public long Insert(MovimentacaoModel model)
        {
            DynamicParameters parameters = new DynamicParameters();

            string cmd = "INSERT INTO Movimentacoes (Numero, Tipo, DataHoraInicio, DataHoraFim) " +
                "OUTPUT INSERTED.PK_Id " +
                "VALUES (@Numero, @Tipo, GETDATE(), NULL) ";

            parameters.Add("@Numero", model.Numero, System.Data.DbType.String,
                System.Data.ParameterDirection.Input, model.Numero.Length);
            parameters.Add("@Tipo", model.Tipo, System.Data.DbType.String,
                System.Data.ParameterDirection.Input, model.Tipo.ToString().Length);

            _database.Open();

            long newId = _conn.QuerySingle<long>(cmd, parameters);

            _database.Close();

            return newId;
        }

        public int Update(MovimentacaoModel model)
        {
            DynamicParameters parameters = new DynamicParameters();

            string cmd = "UPDATE Movimentacoes " +
                "SET DataHoraFim = GETDATE() " +
                "WHERE PK_Id = @Id AND Numero = @Numero ";

            parameters.Add("@Id", model.Id, System.Data.DbType.Int64,
                System.Data.ParameterDirection.Input, 8);
            parameters.Add("@Numero", model.Numero, System.Data.DbType.String,
                System.Data.ParameterDirection.Input, model.Numero.Length);

            _database.Open();

            int qtd = _conn.Execute(cmd, parameters);

            _database.Close();

            return qtd;
        }

        public int UpdateFimMovimentoByNumero(string numero)
        {
            DynamicParameters parameters = new DynamicParameters();

            string cmd = "UPDATE Movimentacoes " +
                "SET DataHoraFim = GETDATE() " +
                "WHERE Numero = @Numero AND DataHoraFim IS NULL ";

            parameters.Add("@Numero", numero, System.Data.DbType.String,
                System.Data.ParameterDirection.Input, numero.Length);

            _database.Open();

            int qtd = _conn.Execute(cmd, parameters);

            _database.Close();

            return qtd;
        }

        public MovimentacaoModel Get(long id)
        {
            DynamicParameters parameters = new DynamicParameters();

            string cmd = "SELECT PK_Id as Id, Numero, Tipo, DataHoraInicio, DataHoraFim " +
                "FROM Movimentacoes WHERE PK_Id = @Id ";

            parameters.Add("@Id", id, System.Data.DbType.Int64,
                System.Data.ParameterDirection.Input, 8);

            _database.Open();

            MovimentacaoModel model = _conn.QuerySingleOrDefault<MovimentacaoModel>(cmd, parameters);

            _database.Close();

            return model;
        }

        public MovimentacaoModel GetEmMovimentoByNumero(string numero)
        {
            DynamicParameters parameters = new DynamicParameters();

            string cmd = "SELECT PK_Id as Id, Numero, Tipo, DataHoraInicio, DataHoraFim " +
                "FROM Movimentacoes WHERE Numero = @Numero AND DataHoraFim IS NULL ";

            parameters.Add("@Numero", numero, System.Data.DbType.String,
                System.Data.ParameterDirection.Input, numero.Length);

            _database.Open();

            MovimentacaoModel model = _conn.QueryFirstOrDefault<MovimentacaoModel>(cmd, parameters);

            _database.Close();

            return model;
        }

        public List<MovimentacaoModel> List()
        {
            string cmd = "SELECT PK_Id as Id, Numero, Tipo, DataHoraInicio, DataHoraFim " +
                    "FROM Movimentacoes ";

            _database.Open();

            List<MovimentacaoModel> list = _conn.Query<MovimentacaoModel>(cmd).ToList();

            _database.Close();

            return list;
        }

        public List<MovimentacaoModel> ListEmMovimento()
        {
            string cmd = "SELECT PK_Id as Id, Numero, Tipo, DataHoraInicio, DataHoraFim " +
                    "FROM Movimentacoes WHERE DataHoraFim IS NULL ";

            _database.Open();

            List<MovimentacaoModel> list = _conn.Query<MovimentacaoModel>(cmd).ToList();

            _database.Close();

            return list;
        }

        public List<MovimentacaoModel> ListByNumero(string numero)
        {
            DynamicParameters parameters = new DynamicParameters();
            
            string cmd = "SELECT PK_Id as Id, Numero, Tipo, DataHoraInicio, DataHoraFim " +
                    "FROM Movimentacoes WHERE Numero = @numero ";

            parameters.Add("@Numero", numero, System.Data.DbType.String,
                System.Data.ParameterDirection.Input, numero.Length);

            _database.Open();

            List<MovimentacaoModel> list = _conn.Query<MovimentacaoModel>(cmd, parameters).ToList();

            _database.Close();

            return list;
        }

        public List<MovimentacaoEntity> Filter(MovimentacaoEntity entity)
        {
            DynamicParameters parameters = new DynamicParameters();
            List<MovimentacaoEntity> list = null;
            bool hasParam = false;

            string queryCmd = "SELECT PK_Id as Id, Numero, Tipo, DataHoraInicio, DataHoraFim " +
                    "FROM Movimentacoes ";
            StringBuilder queryFilter = new StringBuilder();

            if (entity.Id > 0) {
                parameters.Add("@Id", entity.Id, System.Data.DbType.Int64,
                    System.Data.ParameterDirection.Input, 8);
                hasParam = true;
                if (!string.IsNullOrWhiteSpace(queryFilter.ToString())) queryFilter.Append(" AND ");
                queryFilter.Append(" PK_Id = @Id ");
            }
            if (!string.IsNullOrWhiteSpace(entity.Numero)) {
                parameters.Add("@Numero", entity.Numero, System.Data.DbType.String,
                    System.Data.ParameterDirection.Input, entity.Numero.Length);
                hasParam = true;
                if (!string.IsNullOrWhiteSpace(queryFilter.ToString())) queryFilter.Append(" AND ");
                queryFilter.Append(" Numero = @Numero ");
            }
            if (!string.IsNullOrWhiteSpace(entity.Tipo)) {
                parameters.Add("@Tipo", entity.Tipo, System.Data.DbType.String,
                    System.Data.ParameterDirection.Input, entity.Tipo.Length);
                hasParam = true;
                if (!string.IsNullOrWhiteSpace(queryFilter.ToString())) queryFilter.Append(" AND ");
                queryFilter.Append(" Tipo = @Tipo ");
            }

            _database.Open();

            if (hasParam) {
                list = _conn.Query<MovimentacaoEntity>(queryCmd + " WHERE " + queryFilter.ToString(), parameters).ToList();
            } else {
                list = _conn.Query<MovimentacaoEntity>(queryCmd).ToList();
            }

            _database.Close();

            return list;
        }
    }
}
