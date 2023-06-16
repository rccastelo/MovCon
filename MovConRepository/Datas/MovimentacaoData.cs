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

        public long Iniciar(MovimentacaoModel model)
        {
            DynamicParameters parameters = new DynamicParameters();

            string cmd = "INSERT INTO Movimentacoes (Numero, Tipo, TipoConteiner, Status, Categoria, DataHoraInicio, DataHoraFim) " +
                "OUTPUT INSERTED.PK_Id " +
                "VALUES (@Numero, @Tipo, @TipoConteiner, @Status, @Categoria, GETDATE(), NULL) ";

            parameters.Add("@Numero", model.Numero, System.Data.DbType.String,
                System.Data.ParameterDirection.Input, model.Numero.Length);
            parameters.Add("@Tipo", model.Tipo, System.Data.DbType.String,
                System.Data.ParameterDirection.Input, model.Tipo.ToString().Length);
            parameters.Add("@TipoConteiner", model.TipoConteiner, System.Data.DbType.String,
                System.Data.ParameterDirection.Input, model.TipoConteiner.ToString().Length);
            parameters.Add("@Status", model.Status, System.Data.DbType.String,
                System.Data.ParameterDirection.Input, model.Status.ToString().Length);
            parameters.Add("@Categoria", model.Categoria, System.Data.DbType.String,
                System.Data.ParameterDirection.Input, model.Categoria.ToString().Length);

            _database.Open();

            long newId = _conn.QuerySingle<long>(cmd, parameters);

            _database.Close();

            return newId;
        }

        public int Finalizar(MovimentacaoModel model)
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

        public int FinalizarPorNumero(string numero)
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

        public MovimentacaoModel Obter(long id)
        {
            DynamicParameters parameters = new DynamicParameters();

            string cmd = "SELECT PK_Id as Id, Numero, Tipo, TipoConteiner, Status, Categoria, DataHoraInicio, DataHoraFim " +
                "FROM Movimentacoes WHERE PK_Id = @Id ";

            parameters.Add("@Id", id, System.Data.DbType.Int64,
                System.Data.ParameterDirection.Input, 8);

            _database.Open();

            MovimentacaoModel model = _conn.QuerySingleOrDefault<MovimentacaoModel>(cmd, parameters);

            _database.Close();

            return model;
        }

        public MovimentacaoModel ObterEmMovimentoPorNumero(string numero)
        {
            DynamicParameters parameters = new DynamicParameters();

            string cmd = "SELECT PK_Id as Id, Numero, Tipo, TipoConteiner, Status, Categoria, DataHoraInicio, DataHoraFim " +
                "FROM Movimentacoes WHERE Numero = @Numero AND DataHoraFim IS NULL ";

            parameters.Add("@Numero", numero, System.Data.DbType.String,
                System.Data.ParameterDirection.Input, numero.Length);

            _database.Open();

            MovimentacaoModel model = _conn.QueryFirstOrDefault<MovimentacaoModel>(cmd, parameters);

            _database.Close();

            return model;
        }

        public List<MovimentacaoModel> Listar()
        {
            string cmd = "SELECT PK_Id as Id, Numero, Tipo, TipoConteiner, Status, Categoria, DataHoraInicio, DataHoraFim " +
                    "FROM Movimentacoes ";

            _database.Open();

            List<MovimentacaoModel> list = _conn.Query<MovimentacaoModel>(cmd).ToList();

            _database.Close();

            return list;
        }

        public List<MovimentacaoModel> ListarEmMovimento()
        {
            string cmd = "SELECT PK_Id as Id, Numero, Tipo, TipoConteiner, Status, Categoria, DataHoraInicio, DataHoraFim " +
                    "FROM Movimentacoes WHERE DataHoraFim IS NULL ";

            _database.Open();

            List<MovimentacaoModel> list = _conn.Query<MovimentacaoModel>(cmd).ToList();

            _database.Close();

            return list;
        }

        public List<MovimentacaoModel> ListarPorNumero(string numero)
        {
            DynamicParameters parameters = new DynamicParameters();
            
            string cmd = "SELECT PK_Id as Id, Numero, Tipo, TipoConteiner, Status, Categoria, DataHoraInicio, DataHoraFim " +
                    "FROM Movimentacoes WHERE Numero = @numero ";

            parameters.Add("@Numero", numero, System.Data.DbType.String,
                System.Data.ParameterDirection.Input, numero.Length);

            _database.Open();

            List<MovimentacaoModel> list = _conn.Query<MovimentacaoModel>(cmd, parameters).ToList();

            _database.Close();

            return list;
        }

        public List<MovimentacaoEntity> Filtrar(MovimentacaoEntity entity)
        {
            DynamicParameters parameters = new DynamicParameters();
            List<MovimentacaoEntity> list = null;
            bool hasParam = false;

            string queryCmd = "SELECT PK_Id as Id, Numero, Tipo, TipoConteiner, Status, Categoria, DataHoraInicio, DataHoraFim " +
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
            if (entity.Pendente) {
                hasParam = true;
                if (!string.IsNullOrWhiteSpace(queryFilter.ToString())) queryFilter.Append(" AND ");
                queryFilter.Append(" DataHoraFim IS NULL ");
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
