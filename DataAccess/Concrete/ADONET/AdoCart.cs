using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entity.DTO;
using Entity.POCO;
using Microsoft.Data.SqlClient;

namespace DataAccess.Concrete.ADONET
{
    public class AdoCart : ICartDAL
    {
        public bool Add(Cart entity)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Insert into {nameof(Cart)} ({nameof(entity.GameID)},{nameof(entity.AppUserId)},{nameof(entity.Quantity)},{nameof(entity.Active)},{nameof(entity.Deleted)},{nameof(entity.Created)},{nameof(entity.Updated)}) values (@gameId,@appUserId,@quantity,@active,@deleted,@created,@updated)";
                    command.Parameters.AddWithValue("@gameId", entity.GameID);
                    command.Parameters.AddWithValue("@appUserId", entity.AppUserId);
                    command.Parameters.AddWithValue("@quantity", entity.Quantity);
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

        public IEnumerable<CartDTO> AddToCart(CartDTO cartDTO)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Select * from {nameof(Cart)} where {nameof(Cart.AppUserId)} = @userId and {nameof(Cart.GameID)} = @gameId";
                    command.Parameters.AddWithValue("@userId", cartDTO.UserId);
                    command.Parameters.AddWithValue("@gameId", cartDTO.GameID);
                    using (SqlDataReader result = command.ExecuteReader())
                    {
                        if (!result.Read())
                        {
                            connection.Close();
                            using (SqlConnection connection2 = new SqlConnection())
                            {
                                connection2.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                                using (SqlCommand command2 = new SqlCommand())
                                {
                                    connection2.Open();
                                    command2.Connection = connection2;
                                    command2.CommandText = $"Insert into {nameof(Cart)} ({nameof(Cart.GameID)},{nameof(Cart.AppUserId)},{nameof(Cart.Quantity)},{nameof(Cart.Active)},{nameof(Cart.Deleted)},{nameof(Cart.Created)},{nameof(Cart.Updated)}) values (@gameId,@userId,@quantity,@active,@deleted,@created,@updated)";
                                    command2.Parameters.AddWithValue("@gameId", cartDTO.GameID);
                                    command2.Parameters.AddWithValue("@userId", cartDTO.UserId);
                                    command2.Parameters.AddWithValue("@quantity", cartDTO.Quantity);
                                    command2.Parameters.AddWithValue("@active", 1);
                                    command2.Parameters.AddWithValue("@deleted", 0);
                                    command2.Parameters.AddWithValue("@created", DateTime.Now);
                                    command2.Parameters.AddWithValue("@updated", DateTime.Now);
                                    var result2 = command2.ExecuteNonQuery();
                                    if (result2 > 0)
                                    {
                                        connection2.Close();

                                        using (SqlConnection connection3 = new SqlConnection())
                                        {
                                            connection3.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                                            using (SqlCommand command3 = new SqlCommand())
                                            {
                                                connection3.Open();
                                                command3.Connection = connection3;
                                                command3.CommandText = $"Select crt.{nameof(Cart.Quantity)},usr.Id,gm.{nameof(Game.ID)},{nameof(Game.Name)},gı.{nameof(GameImage.ImageURL)},gm.{nameof(Game.Price)} from {nameof(Cart)} as crt join {nameof(Game)} as gm on crt.{nameof(Cart.GameID)} = gm.{nameof(Game.ID)} join {nameof(GameImage)} as gı on gm.{nameof(Game.ID)} = gı.{nameof(GameImage.GameID)} join AspNetUsers as usr on crt.{nameof(Cart.AppUserId)} = usr.Id where crt.{nameof(Cart.AppUserId)} = @userId";
                                                command3.Parameters.AddWithValue("@userId", cartDTO.UserId);
                                                using (SqlDataReader result3 = command3.ExecuteReader())
                                                {
                                                    while (result3.Read())
                                                        yield return new CartDTO() { Quantity = result3.GetInt32(0), UserId = result3.GetInt32(1), GameID = result3.GetInt32(2), GameName = result3.GetString(3), GameImageURL = result3.GetString(4), Price = result3.GetDecimal(5)};
                                                    connection3.Close();
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        connection2.Close();
                                        yield return null;
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
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Delete From {nameof(Cart)} where AppUserId = @userId and GameID = @gameId";
                    command.Parameters.AddWithValue("@gameId", gameid);
                    command.Parameters.AddWithValue("@userId", userId);
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

        public bool Delete(Cart entity)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Update {nameof(Cart)} set {nameof(entity.Active)}='false',{nameof(entity.Deleted)}='true',{nameof(entity.Updated)}=@updated";
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

        public IEnumerable<Cart> Get()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Select {nameof(Cart.GameID)},{nameof(Cart.AppUserId)},{nameof(Cart.Quantity)} from {nameof(Cart)}";
                    using (SqlDataReader result = command.ExecuteReader())
                    {
                        while (result.Read())
                        {
                            yield return new Cart() { GameID = result.GetInt32(0), AppUserId = result.GetInt32(1), Quantity = result.GetInt32(2) };
                        }
                        connection.Close();

                    }
                }
            }
        }

        public Cart Get(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Select {nameof(Cart.GameID)},{nameof(Cart.AppUserId)},{nameof(Cart.Quantity)} from {nameof(Cart)} where {nameof(Cart.ID)} = @id";
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader result = command.ExecuteReader())
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
        }

        public IEnumerable<CartDTO> GetCart(int userId)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Select crt.{nameof(Cart.Quantity)},usr.Id,gm.{nameof(Game.ID)},{nameof(Game.Name)},gı.{nameof(GameImage.ImageURL)} from {nameof(Cart)} as crt join {nameof(Game)} as gm on crt.{nameof(Cart.GameID)} = gm.{nameof(Game.ID)} join {nameof(GameImage)} as gı on gm.{nameof(Game.ID)} = gı.{nameof(GameImage.GameID)} join AspNetUsers as usr on crt.{nameof(Cart.AppUserId)} = usr.Id where crt.{nameof(Cart.AppUserId)} = @userId";
                    command.Parameters.AddWithValue("@userId", userId);
                    using (SqlDataReader result = command.ExecuteReader())
                    {
                        while (result.Read())
                            yield return new CartDTO() { Quantity = result.GetInt32(0), UserId = result.GetInt32(1), GameID = result.GetInt32(2), GameName = result.GetString(3), GameImageURL = result.GetString(4) };
                        connection.Close();
                    }
                }
            }
        }

        public IEnumerable<UserDTO> GetUser(int userId)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Select UserName,Email from AspNetUsers where Id = @userId";
                    command.Parameters.AddWithValue("@userId", userId);
                    using (SqlDataReader result = command.ExecuteReader())
                    {
                        while (result.Read())
                            yield return new UserDTO() { AppUserName = result.GetString(0), Email = result.GetString(1) };
                        connection.Close();
                    }
                }
            }
        }

        public bool Update(Cart entity)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Update {nameof(Cart)} set {nameof(Cart.GameID)}=@gameId,{nameof(Cart.AppUserId)}=@appUserId,{nameof(Cart.Quantity)}=@quantity,{nameof(Cart.Active)}=@active,{nameof(Cart.Deleted)}=@deleted,{nameof(Cart.Updated)}=@updated";
                    command.Parameters.AddWithValue("@gameId", entity.GameID);
                    command.Parameters.AddWithValue("@appUserId", entity.AppUserId);
                    command.Parameters.AddWithValue("@quantity", entity.Quantity);
                    command.Parameters.AddWithValue("@active", Convert.ToInt32(entity.Active));
                    command.Parameters.AddWithValue("@deleted", Convert.ToInt32(entity.Deleted));
                    command.Parameters.AddWithValue("@updated", DateTime.Now);
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

        public IEnumerable<UserDTO> UpdateUser(int userId, string userName, string email)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Update AspNetUsers set UserName = @userName,Email = @email, NormalizedUserName=@normalizedUserName,NormalizedEmail=@normalizedEmail where Id = @userId";
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@userName", userName);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@normalizedUserName", userName.ToUpper());
                    command.Parameters.AddWithValue("@normalizedEmail", email.ToUpper());
                    var result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        connection.Close();
                        using (SqlConnection connection2 = new SqlConnection())
                        {
                            connection2.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                            using (SqlCommand command2 = new SqlCommand())
                            {
                                connection2.Open();
                                command2.Connection = connection2;
                                command2.CommandText = $"Select UserName,Email from AspNetUsers where Id = @userId";
                                command2.Parameters.AddWithValue("@userId", userId);
                                using (SqlDataReader result2 = command2.ExecuteReader())
                                {
                                    while (result2.Read())
                                        yield return new UserDTO() { AppUserName = result2.GetString(0), Email = result2.GetString(1) };
                                    connection2.Close();
                                }
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

        public Cart GetEntity(int userId, int gameId)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Select {nameof(Cart.GameID)},{nameof(Cart.AppUserId)},{nameof(Cart.Quantity)} from {nameof(Cart)} where {nameof(Cart.AppUserId)} = @userId and {nameof(Cart.GameID)} = @gameId";
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@gameId", gameId);
                    using (SqlDataReader result = command.ExecuteReader())
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
        }
    }
}
