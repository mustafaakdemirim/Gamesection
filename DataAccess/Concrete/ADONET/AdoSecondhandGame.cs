using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entity.DTO;
using Entity.POCO;
using Microsoft.Data.SqlClient;

namespace DataAccess.Concrete.ADONET
{
    public class AdoSecondhandGame:ISecondhandGameDAL
    {
        public bool Add(SecondhandGame entity)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Insert into {nameof(SecondhandGame)} ({nameof(entity.Stock)},{nameof(entity.AddUserID)},{nameof(entity.GameName)},{nameof(entity.Price)},{nameof(entity.Description)},{nameof(entity.Active)},{nameof(entity.Deleted)},{nameof(entity.Created)},{nameof(entity.Updated)}) values (@stock,@addUserId,@gameName,@price,@description,@active,@deleted,@created,@updated)";
                    command.Parameters.AddWithValue("@stock", entity.Stock);
                    command.Parameters.AddWithValue("@addUserId", entity.AddUserID);
                    command.Parameters.AddWithValue("@gameName", entity.GameName);
                    command.Parameters.AddWithValue("@price", entity.Price);
                    command.Parameters.AddWithValue("@description", entity.Description);
                    command.Parameters.AddWithValue("@active", entity.Active);
                    command.Parameters.AddWithValue("@deleted", entity.Deleted);
                    command.Parameters.AddWithValue("@created", entity.Created);
                    command.Parameters.AddWithValue("@updated", entity.Updated);
                    var result = command.ExecuteNonQuery();
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

        public bool Delete(SecondhandGame entity, int secondhandGameid)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Update {nameof(SecondhandGame)} set {nameof(entity.Active)}='false',{nameof(entity.Deleted)}='true',{nameof(entity.Updated)}=@updated where {nameof(SecondhandGame.ID)}=@secondhandGameid";
                    command.Parameters.AddWithValue("@updated", entity.Updated);
                    command.Parameters.AddWithValue("@secondhandGameid", secondhandGameid);
                    var result = command.ExecuteNonQuery();
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

        public bool Delete(int secondhandGameid)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Update {nameof(SecondhandGame)} set {nameof(SecondhandGame.Active)}='false',{nameof(SecondhandGame.Deleted)}='true',{nameof(SecondhandGame.Updated)}='{DateTime.Now}' where {nameof(SecondhandGame.ID)}=@secondhandGameid";
                    command.Parameters.AddWithValue("@secondhandGameid", secondhandGameid);
                    var result = command.ExecuteNonQuery();
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

        public bool Delete(SecondhandGame entity)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Update {nameof(SecondhandGame)} set {nameof(entity.Active)}='false',{nameof(entity.Deleted)}='true',{nameof(entity.Updated)}=@updated";
                    command.Parameters.AddWithValue("@updated", entity.Updated);
                    var result = command.ExecuteNonQuery();
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

        public IEnumerable<SecondhandGame> Get()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Select {nameof(SecondhandGame.ID)},{nameof(SecondhandGame.GameName)},{nameof(SecondhandGame.Stock)},{nameof(SecondhandGame.Price)},{nameof(SecondhandGame.Description)} from {nameof(SecondhandGame)}";
                    using (SqlDataReader result = command.ExecuteReader())
                    {
                        while (result.Read())
                            yield return new SecondhandGame() { ID = result.GetInt32(0), GameName = result.GetString(1), Stock = result.GetInt32(2), Price = result.GetDecimal(3), Description = result.GetString(4) };
                        connection.Close();

                    }
                }
            }
        }

        public SecondhandGame Get(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Select {nameof(SecondhandGame.ID)},{nameof(SecondhandGame.GameName)},{nameof(SecondhandGame.Stock)},{nameof(SecondhandGame.Price)},{nameof(SecondhandGame.Description)} from {nameof(SecondhandGame)} where {nameof(SecondhandGame.ID)} = @id";
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader result = command.ExecuteReader())
                    {
                        if (result.Read())
                            return new SecondhandGame() { ID = result.GetInt32(0), GameName = result.GetString(1), Stock = result.GetInt32(2), Price = result.GetDecimal(3), Description = result.GetString(4) };
                        else
                            return null;
                        connection.Close();
                    }
                }
            }
        }

        public SecondhandGame GetActive(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Select {nameof(SecondhandGame.ID)},{nameof(SecondhandGame.GameName)},{nameof(SecondhandGame.Stock)},{nameof(SecondhandGame.Price)},{nameof(SecondhandGame.Description)} from {nameof(SecondhandGame)} where {nameof(SecondhandGame.ID)} = @id and {nameof(SecondhandGame.Active)}=1 and {nameof(SecondhandGame.Deleted)}=0";
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader result = command.ExecuteReader())
                    {
                        if (result.Read())
                            return new SecondhandGame() { ID = result.GetInt32(0), GameName = result.GetString(1), Stock = result.GetInt32(2), Price = result.GetDecimal(3), Description = result.GetString(4) };
                        else
                            return null;
                        connection.Close();
                    }
                }
            }
        }

        public IEnumerable<SecondhandGame> GetAllActive()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Select {nameof(SecondhandGame.ID)},{nameof(SecondhandGame.GameName)},{nameof(SecondhandGame.Stock)},{nameof(SecondhandGame.Price)},{nameof(SecondhandGame.Description)} from {nameof(SecondhandGame)} where {nameof(SecondhandGame.Active)}=1 and {nameof(SecondhandGame.Deleted)}=0";
                    using (SqlDataReader result = command.ExecuteReader())
                    {
                        while (result.Read())
                            yield return new SecondhandGame() { ID = result.GetInt32(0), GameName = result.GetString(1), Stock = result.GetInt32(2), Price = result.GetDecimal(3), Description = result.GetString(4) };
                        connection.Close();

                    }
                }
            }
        }

        public IEnumerable<SecondhandGameDTO> GetGameByCategoryId(int categoryid)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Select gm.{nameof(SecondhandGame.ID)},{nameof(SecondhandGame.GameName)},{nameof(SecondhandGame.Stock)},{nameof(SecondhandGame.Price)},{nameof(SecondhandGame.Description)} from {nameof(SecondhandGame)} as gm join {nameof(SecondhandGameCategory)} as gc on gm.{nameof(SecondhandGame.ID)}=gc.{nameof(SecondhandGameCategory.SecondhandGameID)} join {nameof(Category)} as c on c.{nameof(Category.ID)}=gc.{nameof(SecondhandGameCategory.CategoryID)} where c.{nameof(Category.ID)} = @categoryid";
                    command.Parameters.AddWithValue("@categoryid", categoryid);
                    using (SqlDataReader result = command.ExecuteReader())
                    {
                        while (result.Read())
                            yield return new SecondhandGameDTO() { ID = result.GetInt32(0), GameName = result.GetString(1), Stock = result.GetInt32(2), Price = result.GetDecimal(3), Description = result.GetString(4) };
                        connection.Close();
                    }
                }
            }
        }

        public bool Update(SecondhandGame entity, int secondhandGameid)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Update {nameof(SecondhandGame)} set {nameof(SecondhandGame.Stock)}=@stock,{nameof(SecondhandGame.GameName)}=@gameName,{nameof(entity.Price)}=@price,{nameof(SecondhandGame.Description)}=@description,{nameof(SecondhandGame.Active)}=@active,{nameof(SecondhandGame.Deleted)}=@deleted,{nameof(SecondhandGame.Updated)}=@updated where {nameof(SecondhandGame.ID)}=@secondhandGameid";
                    command.Parameters.AddWithValue("@stock", entity.Stock);
                    command.Parameters.AddWithValue("@gameName", entity.GameName);
                    command.Parameters.AddWithValue("@price", entity.Price);
                    command.Parameters.AddWithValue("@description", entity.Description);
                    command.Parameters.AddWithValue("@active", Convert.ToInt32(entity.Active));
                    command.Parameters.AddWithValue("@deleted", Convert.ToInt32(entity.Deleted));
                    command.Parameters.AddWithValue("@updated", entity.Updated);
                    command.Parameters.AddWithValue("@secondhandGameid", secondhandGameid);
                    var result = command.ExecuteNonQuery();
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

        public bool Update(SecondhandGame entity)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Update {nameof(SecondhandGame)} set {nameof(SecondhandGame.Stock)}=@stock,{nameof(SecondhandGame.GameName)}=@gameName,{nameof(entity.Price)}=@price,{nameof(SecondhandGame.Description)}=@description,{nameof(SecondhandGame.Active)}=@active,{nameof(SecondhandGame.Deleted)}=@deleted,{nameof(SecondhandGame.Updated)}=@updated";
                    command.Parameters.AddWithValue("@stock", entity.Stock);
                    command.Parameters.AddWithValue("@gameName", entity.GameName);
                    command.Parameters.AddWithValue("@price", entity.Price);
                    command.Parameters.AddWithValue("@description", entity.Description);
                    command.Parameters.AddWithValue("@active", Convert.ToInt32(entity.Active));
                    command.Parameters.AddWithValue("@deleted", Convert.ToInt32(entity.Deleted));
                    command.Parameters.AddWithValue("@updated", entity.Updated);
                    var result = command.ExecuteNonQuery();
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
}
