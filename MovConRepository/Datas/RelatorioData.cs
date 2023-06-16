using Dapper;
using Microsoft.Extensions.Configuration;
using MovConDatabase;
using MovConDomain.Models;
using MovConRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovConRepository.Datas
{
    public class RelatorioData : Data, IRelatorioData
    {
        public RelatorioData(IConfiguration configuration) : base(configuration)
        {

        }

        public List<RelatorioEntity> Pesquisar(RelatorioEntity entity)
        {
            DynamicParameters parameters = new DynamicParameters();
            List<RelatorioEntity> list = null;
            bool hasParam = false;

            string queryCmd = "SELECT M.Numero, M.Tipo as TipoMovimentacao, C.Cliente, M.TipoConteiner, " +
                "M.Status, M.Categoria, M.DataHoraInicio, M.DataHoraFim " +
                "FROM Movimentacoes M " +
                "INNER JOIN Conteineres C ON C.Numero = M.Numero ";
            string querySort = "ORDER BY C.Cliente, M.Tipo, M.Numero, M.DataHoraInicio ";

            StringBuilder queryFilter = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(entity.Cliente)) {
                parameters.Add("@Cliente", entity.Cliente, System.Data.DbType.String,
                    System.Data.ParameterDirection.Input, entity.Cliente.Length);
                hasParam = true;
                if (!string.IsNullOrWhiteSpace(queryFilter.ToString())) queryFilter.Append(" AND ");
                queryFilter.Append(" C.Cliente = @Cliente ");
            }
            if (!string.IsNullOrWhiteSpace(entity.Numero)) {
                parameters.Add("@Numero", entity.Numero, System.Data.DbType.String,
                    System.Data.ParameterDirection.Input, entity.Numero.Length);
                hasParam = true;
                if (!string.IsNullOrWhiteSpace(queryFilter.ToString())) queryFilter.Append(" AND ");
                queryFilter.Append(" M.Numero = @Numero ");
            }
            if (!string.IsNullOrWhiteSpace(entity.TipoConteiner)) {
                parameters.Add("@TipoConteiner", entity.TipoConteiner, System.Data.DbType.String,
                    System.Data.ParameterDirection.Input, entity.TipoConteiner.Length);
                hasParam = true;
                if (!string.IsNullOrWhiteSpace(queryFilter.ToString())) queryFilter.Append(" AND ");
                queryFilter.Append(" M.TipoConteiner = @TipoConteiner ");
            }
            if (!string.IsNullOrWhiteSpace(entity.Status)) {
                parameters.Add("@Status", entity.Status, System.Data.DbType.String,
                    System.Data.ParameterDirection.Input, entity.Status.Length);
                hasParam = true;
                if (!string.IsNullOrWhiteSpace(queryFilter.ToString())) queryFilter.Append(" AND ");
                queryFilter.Append(" M.Status = @Status ");
            }
            if (!string.IsNullOrWhiteSpace(entity.Categoria)) {
                parameters.Add("@Categoria", entity.Categoria, System.Data.DbType.String,
                    System.Data.ParameterDirection.Input, entity.Categoria.Length);
                hasParam = true;
                if (!string.IsNullOrWhiteSpace(queryFilter.ToString())) queryFilter.Append(" AND ");
                queryFilter.Append(" M.Categoria = @Categoria ");
            }
            if (!string.IsNullOrWhiteSpace(entity.TipoMovimentacao)) {
                parameters.Add("@TipoMovimentacao", entity.TipoMovimentacao, System.Data.DbType.String,
                    System.Data.ParameterDirection.Input, entity.TipoMovimentacao.Length);
                hasParam = true;
                if (!string.IsNullOrWhiteSpace(queryFilter.ToString())) queryFilter.Append(" AND ");
                queryFilter.Append(" M.Tipo = @TipoMovimentacao ");
            }
            if (!entity.DataHoraInicio.Equals(DateTime.MinValue)) {
                parameters.Add("@DataHoraInicioDe", entity.DataHoraInicio, System.Data.DbType.DateTime2,
                    System.Data.ParameterDirection.Input, 8);
                hasParam = true;
                if (!string.IsNullOrWhiteSpace(queryFilter.ToString())) queryFilter.Append(" AND ");
                queryFilter.Append(" M.DataHoraInicio >= @DataHoraInicioDe ");
            }
            if (!entity.DataHoraInicioAte.Equals(DateTime.MinValue)) {
                parameters.Add("@DataHoraInicioAte", entity.DataHoraInicioAte, System.Data.DbType.DateTime2,
                    System.Data.ParameterDirection.Input, 8);
                hasParam = true;
                if (!string.IsNullOrWhiteSpace(queryFilter.ToString())) queryFilter.Append(" AND ");
                queryFilter.Append(" M.DataHoraInicio <= @DataHoraInicioAte ");
            }
            if (entity.Pendente) {
                hasParam = true;
                if (!string.IsNullOrWhiteSpace(queryFilter.ToString())) queryFilter.Append(" AND ");
                queryFilter.Append(" M.DataHoraFim IS NULL ");
            } else {
                if (!entity.DataHoraFim.Equals(DateTime.MinValue)) {
                    parameters.Add("@DataHoraFimDe", entity.DataHoraFim, System.Data.DbType.DateTime2,
                        System.Data.ParameterDirection.Input, 8);
                    hasParam = true;
                    if (!string.IsNullOrWhiteSpace(queryFilter.ToString())) queryFilter.Append(" AND ");
                    queryFilter.Append(" M.DataHoraFim >= @DataHoraFimDe ");
                }
                if (!entity.DataHoraFimAte.Equals(DateTime.MinValue)) {
                    parameters.Add("@DataHoraFimAte", entity.DataHoraFimAte, System.Data.DbType.DateTime2,
                        System.Data.ParameterDirection.Input, 8);
                    hasParam = true;
                    if (!string.IsNullOrWhiteSpace(queryFilter.ToString())) queryFilter.Append(" AND ");
                    queryFilter.Append(" M.DataHoraFim <= @DataHoraFimAte ");
                }
            }

            _database.Open();

            if (hasParam) {
                list = _conn.Query<RelatorioEntity>(queryCmd + " WHERE " + queryFilter.ToString() + querySort, parameters).ToList();
            } else {
                list = _conn.Query<RelatorioEntity>(queryCmd + querySort).ToList();
            }

            _database.Close();

            return list;
        }
    }
}
