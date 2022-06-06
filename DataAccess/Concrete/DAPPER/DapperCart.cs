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
    public class DapperCart : ICartDAL
    {
        public bool Add(Cart entity)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Insert into {nameof(Cart)} ({nameof(entity.GameID)},{nameof(entity.AppUserId)},{nameof(entity.Quantity)},{nameof(entity.Active)},{nameof(entity.Deleted)},{nameof(entity.Created)},{nameof(entity.Updated)}) values (@gameId,@appUserId,@quantity,@active,@deleted,@created,@updated)";
                cmd.Parameters.Add(new SqlParameter("@gameId", entity.GameID));
                cmd.Parameters.Add(new SqlParameter("@appUserId", entity.AppUserId));
                cmd.Parameters.Add(new SqlParameter("@quantity", entity.Quantity));
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

        public IEnumerable<CartDTO> AddToCart(CartDTO cartDTO)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Select * from {nameof(Cart)} where {nameof(Cart.AppUserId)} = @userId and {nameof(Cart.GameID)} = @gameId";
                cmd.Parameters.Add(new SqlParameter("@userId", cartDTO.UserId));
                cmd.Parameters.Add(new SqlParameter("@gameId", cartDTO.GameID));
                using (IDataReader result = cmd.ExecuteReader())
                {
                    if (!result.Read())
                    {
                        connection.Close();
                        using (IDbConnection connection2 = new SqlConnection())
                        {
                            using var cmd2 = connection2.CreateCommand();
                            connection2.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                            connection2.Open();
                            cmd2.CommandText = $"Insert into {nameof(Cart)} ({nameof(Cart.GameID)},{nameof(Cart.AppUserId)},{nameof(Cart.Quantity)},{nameof(Cart.Active)},{nameof(Cart.Deleted)},{nameof(Cart.Created)},{nameof(Cart.Updated)}) values (@gameId,@userId,@quantity,@active,@deleted,@created,@updated)";
                            cmd2.Parameters.Add(new SqlParameter("@gameId", cartDTO.GameID));
                            cmd2.Parameters.Add(new SqlParameter("@userId", cartDTO.UserId));
                            cmd2.Parameters.Add(new SqlParameter("@quantity", cartDTO.Quantity));
                            cmd2.Parameters.Add(new SqlParameter("@active", Convert.ToInt32(true)));
                            cmd2.Parameters.Add(new SqlParameter("@deleted", Convert.ToInt32(false)));
                            cmd2.Parameters.Add(new SqlParameter("@created", DateTime.Now));
                            cmd2.Parameters.Add(new SqlParameter("@updated", DateTime.Now));
                            var result2 = cmd2.ExecuteNonQuery();
                            if (result2 > 0)
                            {
                                connection2.Close();
                                using (IDbConnection connection3 = new SqlConnection())
                                {
                                    using var cmd3 = connection3.CreateCommand();
                                    connection3.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                                    connection3.Open();
                                    cmd3.CommandText = $"Select crt.{nameof(Cart.Quantity)},usr.Id,gm.{nameof(Game.ID)},{nameof(Game.Name)},gı.{nameof(GameImage.ImageURL)} from {nameof(Cart)} as crt join {nameof(Game)} as gm on crt.{nameof(Cart.GameID)} = gm.{nameof(Game.ID)} join {nameof(GameImage)} as gı on gm.{nameof(Game.ID)} = gı.{nameof(GameImage.GameID)} join AspNetUsers as usr on crt.{nameof(Cart.AppUserId)} = usr.Id where crt.{nameof(Cart.AppUserId)} = @userId";
                                    cmd3.Parameters.Add(new SqlParameter("@userId", cartDTO.UserId));
                                    using (IDataReader result3 = cmd3.ExecuteReader())
                                    {
                                        while (result3.Read())
                                            yield return new CartDTO() { Quantity = result3.GetInt32(0), UserId = result3.GetInt32(1), GameID = result3.GetInt32(2), GameName = result3.GetString(3), GameImageURL = result3.GetString(4) };
                                        connection3.Close();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public bool Delete(int gameid, int userId)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Delete From {nameof(Cart)} where AppUserId = @userId and GameID = @gameId";
                cmd.Parameters.Add(new SqlParameter("@userId", userId));
                cmd.Parameters.Add(new SqlParameter("@gameId", gameid));
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

        public bool Delete(Cart entity)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Update {nameof(Cart)} set {nameof(entity.Active)}='false',{nameof(entity.Deleted)}='true',{nameof(entity.Updated)}=@updated";
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

        public IEnumerable<Cart> Get()
        {
            using (IDbConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                using (IDataReader result = connection.ExecuteReader($"Select {nameof(Cart.GameID)},{nameof(Cart.AppUserId)},{nameof(Cart.Quantity)} from {nameof(Cart)}"))
                {
                    while (result.Read())
                        yield return new Cart() { GameID = result.GetInt32(0), AppUserId = result.GetInt32(1), Quantity = result.GetInt32(2) };
                    connection.Close();
                }
            }
        }

        public Cart Get(int id)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Select {nameof(Cart.GameID)},{nameof(Cart.AppUserId)},{nameof(Cart.Quantity)} from {nameof(Cart)} where {nameof(Cart.ID)} = @id";
                cmd.Parameters.Add(new SqlParameter("@id", id));
                using (IDataReader result = cmd.ExecuteReader())
                {
                    if (result.Read())
                    {
                        return new Cart() { GameID = result.GetInt32(0), AppUserId = result.GetInt32(1), Quantity = result.GetInt32(2) };
                        connection.Close();
                    }
                    else
                    {
                        return null;
                        connection.Close();
                    }
                        
                }
            }
        }

        public IEnumerable<CartDTO> GetCart(int userId)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Select crt.{nameof(Cart.Quantity)},usr.Id,gm.{nameof(Game.ID)},{nameof(Game.Name)},gı.{nameof(GameImage.ImageURL)} from {nameof(Cart)} as crt join {nameof(Game)} as gm on crt.{nameof(Cart.GameID)} = gm.{nameof(Game.ID)} join {nameof(GameImage)} as gı on gm.{nameof(Game.ID)} = gı.{nameof(GameImage.GameID)} join AspNetUsers as usr on crt.{nameof(Cart.AppUserId)} = usr.Id where crt.{nameof(Cart.AppUserId)} = @userId";
                cmd.Parameters.Add(new SqlParameter("@userId", userId));
                using (IDataReader result = cmd.ExecuteReader())
                {
                    while (result.Read())
                        yield return new CartDTO() { Quantity = result.GetInt32(0), UserId = result.GetInt32(1), GameID = result.GetInt32(2), GameName = result.GetString(3), GameImageURL = result.GetString(4) };
                    connection.Close();
                }
            }
        }

        public Cart GetEntity(int userId, int gameId)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Select {nameof(Cart.GameID)},{nameof(Cart.AppUserId)},{nameof(Cart.Quantity)} from {nameof(Cart)} where {nameof(Cart.AppUserId)} = @userId and {nameof(Cart.GameID)} = @gameId";
                cmd.Parameters.Add(new SqlParameter("@userId", userId));
                cmd.Parameters.Add(new SqlParameter("@gameId", gameId));
                using (IDataReader result = cmd.ExecuteReader())
                {
                    if (result.Read())
                    {
                        return new Cart() { GameID = result.GetInt32(0), AppUserId = result.GetInt32(1), Quantity = result.GetInt32(2) };
                        connection.Close();
                    }
                    else
                    {
                        return null;
                        connection.Close();
                    }

                }
            }
        }

        public IEnumerable<UserDTO> GetUser(int userId)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Select UserName,Email from AspNetUsers where Id = @userId";
                cmd.Parameters.Add(new SqlParameter("@userId", userId));
                using (IDataReader result = cmd.ExecuteReader())
                {
                    while (result.Read())
                        yield return new UserDTO() { AppUserName = result.GetString(0), Email = result.GetString(1) };
                    connection.Close();
                }
            }
        }

        public bool Update(Cart entity)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Update {nameof(Cart)} set {nameof(Cart.GameID)}=@gameId,{nameof(Cart.AppUserId)}=@appUserId,{nameof(Cart.Quantity)}=@quantity,{nameof(Cart.Active)}=@active,{nameof(Cart.Deleted)}=@deleted,{nameof(Cart.Updated)}=@updated";
                cmd.Parameters.Add(new SqlParameter("@gameId", entity.GameID));
                cmd.Parameters.Add(new SqlParameter("@appUserId", entity.AppUserId));
                cmd.Parameters.Add(new SqlParameter("@quantity", entity.Quantity));
                cmd.Parameters.Add(new SqlParameter("@active", Convert.ToInt32(entity.Active)));
                cmd.Parameters.Add(new SqlParameter("@deleted", Convert.ToInt32(entity.Deleted)));
                cmd.Parameters.Add(new SqlParameter("@updated", DateTime.Now));
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

        public IEnumerable<UserDTO> UpdateUser(int userId, string userName, string email)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Update AspNetUsers set UserName = @userName,Email = @email, NormalizedUserName=@normalizedUserName,NormalizedEmail=@normalizedEmail where Id = @userId";
                cmd.Parameters.Add(new SqlParameter("@userId", userId));
                cmd.Parameters.Add(new SqlParameter("@userName", userName));
                cmd.Parameters.Add(new SqlParameter("@email", email));
                cmd.Parameters.Add(new SqlParameter("@normalizedUserName", userName.ToUpper()));
                cmd.Parameters.Add(new SqlParameter("@normalizedEmail", email.ToUpper()));
                var result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    connection.Close();
                    using (IDbConnection connection2 = new SqlConnection())
                    {
                        using var cmd2 = connection2.CreateCommand();
                        connection2.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                        connection2.Open();
                        cmd2.CommandText = $"Select UserName,Email from AspNetUsers where Id = @userId";
                        cmd2.Parameters.Add(new SqlParameter("@userId", userId));
                        using (IDataReader result2 = cmd2.ExecuteReader())
                        {
                            while (result2.Read())
                                yield return new UserDTO() { AppUserName = result2.GetString(0), Email = result2.GetString(1) };
                            connection.Close();
                        }
                    }
                }
                else
                {
                    connection.Close();
                   yield return null;
                }
            }
        }
    }
}
