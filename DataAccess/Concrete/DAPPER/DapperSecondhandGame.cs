using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using Dapper;
using DataAccess.Abstract;
using Entity.DTO;
using Entity.POCO;
using Microsoft.Data.SqlClient;

namespace DataAccess.Concrete.DAPPER
{
    public class DapperSecondhandGame : ISecondhandGameDAL
    {
        public bool Add(SecondhandGame entity)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand() ;
                
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Insert into {nameof(SecondhandGame)} ({nameof(entity.Stock)},{nameof(entity.AddUserID)},{nameof(entity.GameName)},{nameof(entity.Price)},{nameof(entity.Description)},{nameof(entity.Active)},{nameof(entity.Deleted)},{nameof(entity.Created)},{nameof(entity.Updated)}) values (@stock,@addUserID,@gameName,@price,@description,@active,@deleted,@created,@updated)";
                cmd.Parameters.Add(new SqlParameter("@stock", entity.Stock));
                cmd.Parameters.Add(new SqlParameter("@addUserID", entity.AddUserID));
                cmd.Parameters.Add(new SqlParameter("@gameName", entity.GameName));
                cmd.Parameters.Add(new SqlParameter("@price", entity.Price));
                cmd.Parameters.Add(new SqlParameter("@description", entity.Description));
                cmd.Parameters.Add(new SqlParameter("@active", entity.Active));
                cmd.Parameters.Add(new SqlParameter("@deleted", entity.Deleted));
                cmd.Parameters.Add(new SqlParameter("@created", entity.Created));
                cmd.Parameters.Add(new SqlParameter("@updated", entity.Updated));
                var result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    connection.Close();
                    return true;
                }
                else
                {
                    connection.Close();
                    return false;
                }
            }
        }

        public bool Delete(SecondhandGame entity, int secondhandGameid)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Update {nameof(SecondhandGame)} set {nameof(entity.Active)}='false',{nameof(entity.Deleted)}='true',{nameof(entity.Updated)}=@updated where {nameof(SecondhandGame.ID)}=@secondhandGameid";
                cmd.Parameters.Add(new SqlParameter("@updated", entity.Updated));
                cmd.Parameters.Add(new SqlParameter("@secondhandGameid", secondhandGameid));
                var result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    connection.Close();
                    return true;
                }
                else
                {
                    connection.Close();
                    return false;
                }
            }
        }

        public bool Delete(int secondhandGameid)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Update {nameof(SecondhandGame)} set {nameof(SecondhandGame.Active)}='false',{nameof(SecondhandGame.Deleted)}='true',{nameof(SecondhandGame.Updated)}='{DateTime.Now}' where {nameof(SecondhandGame.ID)}=@secondhandGameid";
                cmd.Parameters.Add(new SqlParameter("@secondhandGameid", secondhandGameid));
                var result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    connection.Close();
                    return true;
                }
                else
                {
                    connection.Close();
                    return false;
                }
            }
        }

        public bool Delete(SecondhandGame entity)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Update {nameof(SecondhandGame)} set {nameof(entity.Active)}='false',{nameof(entity.Deleted)}='true',{nameof(entity.Updated)}=@updated";
                cmd.Parameters.Add(new SqlParameter("@updated", entity.Updated));
                var result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    connection.Close();
                    return true;
                }
                else
                {
                    connection.Close();
                    return false;
                }
            }
        }

        public IEnumerable<SecondhandGame> Get()
        {
            using (IDbConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                using (IDataReader result = connection.ExecuteReader($"Select {nameof(SecondhandGame.ID)},{nameof(SecondhandGame.GameName)},{nameof(SecondhandGame.Stock)},{nameof(SecondhandGame.Price)},{nameof(SecondhandGame.Description)} from {nameof(SecondhandGame)}"))
                {
                    while (result.Read())
                        yield return new SecondhandGame() { ID = result.GetInt32(0), GameName = result.GetString(1), Stock = result.GetInt32(2), Price = result.GetDecimal(3), Description = result.GetString(4) };
                    connection.Close();
                }
            }
        }

        public SecondhandGame Get(int id)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Select {nameof(SecondhandGame.ID)},{nameof(SecondhandGame.GameName)},{nameof(SecondhandGame.Stock)},{nameof(SecondhandGame.Price)},{nameof(SecondhandGame.Description)} from {nameof(SecondhandGame)} where {nameof(SecondhandGame.ID)} = @id";
                cmd.Parameters.Add(new SqlParameter("@id", id));
                using (IDataReader result = cmd.ExecuteReader())
                {
                    if (result.Read())
                        return new SecondhandGame() { ID = result.GetInt32(0), GameName = result.GetString(1), Stock = result.GetInt32(2), Price = result.GetDecimal(3), Description = result.GetString(4) };
                    else
                        return null;
                    connection.Close();
                }
            }
        }

        public SecondhandGame GetActive(int id)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Select {nameof(SecondhandGame.ID)},{nameof(SecondhandGame.GameName)},{nameof(SecondhandGame.Stock)},{nameof(SecondhandGame.Price)},{nameof(SecondhandGame.Description)} from {nameof(SecondhandGame)} where {nameof(SecondhandGame.ID)} = {id} and {nameof(SecondhandGame.Active)}=1 and {nameof(SecondhandGame.Deleted)}=0";
                    using (IDataReader result = cmd.ExecuteReader())
                    if (result.Read())
                        return new SecondhandGame() { ID = result.GetInt32(0), GameName = result.GetString(1), Stock = result.GetInt32(2), Price = result.GetDecimal(3), Description = result.GetString(4) };
                    else
                        return null;
                    connection.Close();
            }
        }

        public IEnumerable<SecondhandGame> GetAllActive()
        {
            using (IDbConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                using (IDataReader result = connection.ExecuteReader($"Select {nameof(SecondhandGame.ID)},{nameof(SecondhandGame.GameName)},{nameof(SecondhandGame.Stock)},{nameof(SecondhandGame.Price)},{nameof(SecondhandGame.Description)} from {nameof(SecondhandGame)} where {nameof(SecondhandGame.Active)}=1 and {nameof(SecondhandGame.Deleted)}=0"))
                {
                    while (result.Read())
                        yield return new SecondhandGame() { ID = result.GetInt32(0), GameName = result.GetString(1), Stock = result.GetInt32(2), Price = result.GetDecimal(3), Description = result.GetString(4) };
                    connection.Close();
                }
            }
        }

        public IEnumerable<SecondhandGameDTO> GetGameByCategoryId(int categoryid)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Select gm.{nameof(SecondhandGame.ID)},{nameof(SecondhandGame.GameName)},{nameof(SecondhandGame.Stock)},{nameof(SecondhandGame.Price)},{nameof(SecondhandGame.Description)} from {nameof(SecondhandGame)} as gm join {nameof(SecondhandGameCategory)} as gc on gm.{nameof(SecondhandGame.ID)}=gc.{nameof(SecondhandGameCategory.SecondhandGameID)} join {nameof(Category)} as c on c.{nameof(Category.ID)}=gc.{nameof(SecondhandGameCategory.CategoryID)} where c.{nameof(Category.ID)} = @categoryid";
                cmd.Parameters.Add(new SqlParameter("@categoryid", categoryid));
                using (IDataReader result = cmd.ExecuteReader())
                {
                    while (result.Read())
                        yield return new SecondhandGameDTO() { ID = result.GetInt32(0), GameName = result.GetString(1), Stock = result.GetInt32(2), Price = result.GetDecimal(3), Description = result.GetString(4) };
                    connection.Close();
                }
            }
        }

        public bool Update(SecondhandGame entity, int secondhandGameid)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Update {nameof(SecondhandGame)} set {nameof(SecondhandGame.Stock)}=@stock,{nameof(SecondhandGame.GameName)}=@gameName,{nameof(entity.Price)}=@price,{nameof(SecondhandGame.Description)}=@description,{nameof(SecondhandGame.Active)}=@active,{nameof(SecondhandGame.Deleted)}=@deleted,{nameof(SecondhandGame.Updated)}=@updated where {nameof(SecondhandGame.ID)}=@secondhandGameid";
                cmd.Parameters.Add(new SqlParameter("@stock", entity.Stock));
                cmd.Parameters.Add(new SqlParameter("@gameName", entity.GameName));
                cmd.Parameters.Add(new SqlParameter("@price", entity.Price));
                cmd.Parameters.Add(new SqlParameter("@description", entity.Description));
                cmd.Parameters.Add(new SqlParameter("@active", Convert.ToInt32(entity.Active)));
                cmd.Parameters.Add(new SqlParameter("@deleted", Convert.ToInt32(entity.Deleted)));
                cmd.Parameters.Add(new SqlParameter("@updated", entity.Updated));
                cmd.Parameters.Add(new SqlParameter("@secondhandGameid", secondhandGameid));
                var result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    connection.Close();
                    return true;
                }
                else
                {
                    connection.Close();
                    return false;
                }
            }
        }

        public bool Update(SecondhandGame entity)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Update {nameof(SecondhandGame)} set {nameof(SecondhandGame.Stock)}=@stock,{nameof(SecondhandGame.GameName)}=@gameName,{nameof(entity.Price)}=@price,{nameof(SecondhandGame.Description)}=@description,{nameof(SecondhandGame.Active)}=@active,{nameof(SecondhandGame.Deleted)}=@deleted,{nameof(SecondhandGame.Updated)}=@updated";
                cmd.Parameters.Add(new SqlParameter("@stock", entity.Stock));
                cmd.Parameters.Add(new SqlParameter("@gameName", entity.GameName));
                cmd.Parameters.Add(new SqlParameter("@price", entity.Price));
                cmd.Parameters.Add(new SqlParameter("@description", entity.Description));
                cmd.Parameters.Add(new SqlParameter("@active", Convert.ToInt32(entity.Active)));
                cmd.Parameters.Add(new SqlParameter("@deleted", Convert.ToInt32(entity.Deleted)));
                cmd.Parameters.Add(new SqlParameter("@updated", entity.Updated));
                var result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    connection.Close();
                    return true;
                }
                else
                {
                    connection.Close();
                    return false;
                }
            }
        }
    }
}
