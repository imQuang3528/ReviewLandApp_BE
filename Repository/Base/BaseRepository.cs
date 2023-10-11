using Dapper;
using Entities.AppSetting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Base
{
    public class BaseRepository
    {
        private IOptions<AppSetting> _appSetting;
        private const string mscSQLServeParamSymbol = "@";
        public BaseRepository(IOptions<AppSetting> appSetting)
        {
            try
            {
                this._appSetting = appSetting;
                _connection = new SqlConnection(ConnectionString);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string ConnectionString
        {
            get
            {
                var conn = _appSetting.Value.StrConnectionString;
                return conn;
            }
        }

        private IDbConnection _connection;

        public IDbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    var str = ConnectionString;
                    _connection = new SqlConnection(str);
                }
                if (_connection.State != ConnectionState.Open)
                {
                    try
                    {
                        _connection.Open();
                    }
                    catch (Exception)
                    {
                        _connection.Close();
                    }
                }
                return _connection;
            }
        }

        public async Task<bool> ExecuteUsingStoreProcedure(string sql, object param = null)
        {
            return await DoExecuteUsingStoreProceduce(sql, param);
        }
        private async Task<bool> DoExecuteUsingStoreProceduce(string sql, object param = null)
        {
            var cd = new CommandDefinition();
            try
            {
                bool success;
                cd = BuildCommandDefinition(sql, commandType: CommandType.StoredProcedure, param);
                using (var conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    success = await conn.ExecuteAsync(cd) > 0;
                    return success;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Thực hiên query nhiều bản ghi vs param là dictionary
        /// </summary>
        /// <param name="types"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<List<List<object>>> QueryMultipleUsingStoreProcedure(List<Type> types, string sql, Dictionary<string, object> param)
        {
            return await DoQueryMultiUsingStoreProcedure(types, sql, param);
        }

        /// <summary>
        /// Thực hiện query nhiều bản ghi vs param là object
        /// </summary>
        /// <param name="types"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<List<List<object>>> QueryMultipleUsingStoreProcedure(List<Type> types, string sql, object param = null)
        {
            return await DoQueryMultiUsingStoreProcedure(types, sql, param);
        }


        public async Task<T> QuerySingleUsingStoreProcedure<T>(string sql, object param = null)
        {
            return await DoQuerySingleUsingStoreProcedure<T>(sql, param);
        }
        /// <summary>
        /// Hàm thực thi trả về 1 object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procedure"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        private async Task<T> DoQuerySingleUsingStoreProcedure<T>(string procedure, object param = null)
        {
            var cd = new CommandDefinition();
            try
            {
                object response = new object();
                cd = BuildCommandDefinition(procedure, commandType: CommandType.StoredProcedure, param);
                using (var conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    response = await conn.QuerySingleAsync<T>(cd);
                    return (T)response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Hàm query trả về danh sách object vs param la object
        /// </summary>
        /// <param name="types"></param>
        /// <param name="procedure"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        private async Task<List<List<object>>> DoQueryMultiUsingStoreProcedure(List<Type> types, string procedure, object param = null)
        {
            var cd = new CommandDefinition();
            try
            {
                List<List<object>> res = new List<List<object>>();
                cd = BuildCommandDefinition(procedure, commandType: CommandType.StoredProcedure, param);
                using (var conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    var result = await conn.QueryMultipleAsync(cd);
                    var index = 0;
                    do
                    {
                        res.Add((await result.ReadAsync(types[index])).ToList());
                        index++;
                    } while (!result.IsConsumed);
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Hàm build param la dictionary
        /// </summary>
        /// <param name="types"></param>
        /// <param name="procedure"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        private async Task<List<List<object>>> DoQueryMultiUsingStoreProcedure(List<Type> types, string procedure, Dictionary<string, object> param = null)
        {
            try
            {
                List<List<object>> res = new List<List<object>>();
                using (var conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    var parameter = BuildDynamicParametersFromDictionaty(procedure, conn, null, param);
                    var result = await conn.QueryMultipleAsync(procedure, parameter, commandType: CommandType.StoredProcedure);
                    var index = 0;
                    do
                    {
                        res.Add((await result.ReadAsync(types[index])).ToList());
                        index++;
                    } while (!result.IsConsumed);
                    return res;
                }  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private CommandDefinition BuildCommandDefinition(string sql, CommandType commandType, object param)
        {
            var commandDefinition = new CommandDefinition(sql, commandType: commandType, parameters: param);
            return commandDefinition;
        }


        public async Task<bool> ExecuteStoreUsingDynamicParam(string proc, object param)
        {
            try
            {
                bool success;
                using (var conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    var parameters = BuildDynamicParametersFromEntity(proc, conn, null, param);
                    success = await conn.ExecuteAsync(proc, parameters, commandType: CommandType.StoredProcedure) > 0;
                    return success;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Build Param từ Entity
        /// </summary>
        /// <param name="proc"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        private DynamicParameters BuildDynamicParametersFromEntity(string proc, SqlConnection conn, SqlTransaction trans, object entity)
        {
            var dynamicParam = new DynamicParameters();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.Transaction = trans;
                cmd.CommandText = proc;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cmd);
                if (entity != null)
                {
                    var entityType = entity.GetType();
                    foreach (SqlParameter item in cmd.Parameters)
                    {
                        if (item.ParameterName != "@RETURN_VALUE")
                        {
                            string paramName = item.ParameterName.Replace(mscSQLServeParamSymbol, string.Empty);
                            var pr = entityType.GetProperty(paramName);
                            if (pr != null)
                            {
                                dynamicParam.Add(item.ParameterName, pr.GetValue(entity));
                            }
                            else
                            {
                                dynamicParam.Add(item.ParameterName, null);
                            }
                        }
                    }
                }
            }
            return dynamicParam;
        }


        /// <summary>
        /// Build param từ dictionary
        /// </summary>
        /// <param name="proc"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        private DynamicParameters BuildDynamicParametersFromDictionaty(string proc, SqlConnection conn, SqlTransaction trans, Dictionary<string, object> param)
        {
            var dynamicParameters = new DynamicParameters();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.Transaction = trans;
                cmd.CommandText = proc;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cmd);
                if (param != null && param.Count > 0)
                {
                    foreach (SqlParameter item in cmd.Parameters)
                    {
                        if (item.ParameterName != "@RETURN_VALUE")
                        {
                            string paramName = item.ParameterName.Replace(mscSQLServeParamSymbol, string.Empty);
                            var pr = param.Where(x => x.Key.Equals(paramName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                            if (pr.Key != null)
                            {
                                dynamicParameters.Add(item.ParameterName, pr.Value, item.DbType);
                            }
                            else
                            {
                                dynamicParameters.Add(item.ParameterName, null);
                            }
                        }                       
                    }
                }
            }
            return dynamicParameters;
        }
    }
}
