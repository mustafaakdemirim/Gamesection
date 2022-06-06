using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entity.DTO;
using Entity.POCO;
using Microsoft.Data.SqlClient;

namespace DataAccess.Concrete.ADONET
{
    public class AdoGame : IGameDAL
    {
        public bool Add(Game entity)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Insert into {nameof(Game)} ({nameof(entity.Stock)},{nameof(entity.Name)},{nameof(entity.Price)},{nameof(entity.Description)},{nameof(entity.Active)},{nameof(entity.Deleted)},{nameof(entity.Created)},{nameof(entity.Updated)}) values (@stock,@name,@price,@description,@active,@deleted,@created,@updated)";
                    command.Parameters.AddWithValue("@stock",entity.Stock);
                    command.Parameters.AddWithValue("@name", entity.Name);
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

        public bool Delete(Game entity,int gameid)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Update {nameof(Game)} set {nameof(entity.Active)}='false',{nameof(entity.Deleted)}='true',{nameof(entity.Updated)}=@updated where {nameof(Game.ID)}=@gameid";
                    command.Parameters.AddWithValue("@updated", entity.Updated);
                    command.Parameters.AddWithValue("@gameid", gameid);
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

        public bool Delete(int gameid)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Update {nameof(Game)} set {nameof(Game.Active)}='false',{nameof(Game.Deleted)}='true',{nameof(Game.Updated)}='{DateTime.Now}' where {nameof(Game.ID)}=@gameid";
                    command.Parameters.AddWithValue("@gameid", gameid);
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

        public bool Delete(Game entity)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Update {nameof(Game)} set {nameof(entity.Active)}='false',{nameof(entity.Deleted)}='true',{nameof(entity.Updated)}=@updated";
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

        public IEnumerable<Game> Get()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Select {nameof(Game.ID)},{nameof(Game.Name)},{nameof(Game.Stock)},{nameof(Game.Price)},{nameof(Game.Description)} from {nameof(Game)}";
                    using (SqlDataReader result = command.ExecuteReader())
                    {
                        while (result.Read())
                            yield return new Game() { ID = result.GetInt32(0), Name = result.GetString(1), Stock = result.GetInt32(2), Price = result.GetDecimal(3), Description = result.GetString(4) };
                        connection.Close();

                    }
                }
            }
        }

        public IEnumerable<Game> GetAllActive()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Select {nameof(Game.ID)},{nameof(Game.Name)},{nameof(Game.Stock)},{nameof(Game.Price)},{nameof(Game.Description)} from {nameof(Game)} where {nameof(Game.Active)}=1 and {nameof(Game.Deleted)}=0";
                    using (SqlDataReader result = command.ExecuteReader())
                    {
                        while (result.Read())
                            yield return new Game() { ID = result.GetInt32(0), Name = result.GetString(1), Stock = result.GetInt32(2), Price = result.GetDecimal(3), Description = result.GetString(4) };
                        connection.Close();

                    }
                }
            }
        }

        public Game Get(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Select {nameof(Game.ID)},{nameof(Game.Name)},{nameof(Game.Stock)},{nameof(Game.Price)},{nameof(Game.Description)} from {nameof(Game)} where {nameof(Game.ID)} = @id";
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader result = command.ExecuteReader())
                    {
                        if (result.Read())
                            return new Game() { ID = result.GetInt32(0), Name = result.GetString(1), Stock = result.GetInt32(2), Price = result.GetDecimal(3), Description = result.GetString(4) };
                        else
                            return null;
                        connection.Close();
                    }
                }
            }
        }

        public Game GetActive(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Select {nameof(Game.ID)},{nameof(Game.Name)},{nameof(Game.Stock)},{nameof(Game.Price)},{nameof(Game.Description)} from {nameof(Game)} where {nameof(Game.ID)} = @id and {nameof(Game.Active)}=1 and {nameof(Game.Deleted)}=0";
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader result = command.ExecuteReader())
                    {
                        if (result.Read())
                            return new Game() { ID = result.GetInt32(0), Name = result.GetString(1), Stock = result.GetInt32(2), Price = result.GetDecimal(3), Description = result.GetString(4) };
                        else
                            return null;
                        connection.Close();
                    }
                }
            }
        }

        public IEnumerable<GameDTO> GetGameByCategoryId(int categoryid)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Select gm.{nameof(Game.ID)},{nameof(Game.Name)},{nameof(Game.Stock)},{nameof(Game.Price)},{nameof(Game.Description)} from {nameof(Game)} as gm join {nameof(GameCategory)} as gc on gm.{nameof(Game.ID)}=gc.{nameof(GameCategory.GameID)} join {nameof(Category)} as c on c.{nameof(Category.ID)}=gc.{nameof(GameCategory.CategoryID)} where c.{nameof(Category.ID)} = @categoryid";
                    command.Parameters.AddWithValue("@categoryid", categoryid);
                    using (SqlDataReader result = command.ExecuteReader())
                    {
                            while (result.Read())
                                yield return new GameDTO() { ID = result.GetInt32(0), GameName = result.GetString(1), Stock = result.GetInt32(2), Price = result.GetDecimal(3), Description = result.GetString(4) };
                            connection.Close();
                    }
                }
            }
        }

        public bool Update(Game entity,int gameid)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Update {nameof(Game)} set {nameof(Game.Stock)}=@stock,{nameof(Game.Name)}=@name,{nameof(entity.Price)}=@price,{nameof(Game.Description)}=@description,{nameof(Game.Active)}=@active,{nameof(Game.Deleted)}=@deleted,{nameof(Game.Updated)}=@updated where {nameof(Game.ID)}=@gameid";
                    command.Parameters.AddWithValue("@stock", entity.Stock);
                    command.Parameters.AddWithValue("@name", entity.Name);
                    command.Parameters.AddWithValue("@price", entity.Price);
                    command.Parameters.AddWithValue("@description", entity.Description);
                    command.Parameters.AddWithValue("@active", Convert.ToInt32(entity.Active));
                    command.Parameters.AddWithValue("@deleted", Convert.ToInt32(entity.Deleted));
                    command.Parameters.AddWithValue("@updated", entity.Updated);
                    command.Parameters.AddWithValue("@gameid", gameid);
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

        public bool Update(Game entity)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Update {nameof(Game)} set {nameof(Game.Stock)}=@stock,{nameof(Game.Name)}=@name,{nameof(Game.Price)}=@price,{nameof(Game.Description)}=@description,{nameof(Game.Active)}=@active,{nameof(Game.Deleted)}=@deleted,{nameof(Game.Updated)}=@updated";
                    command.Parameters.AddWithValue("@stock", entity.Stock);
                    command.Parameters.AddWithValue("@name",entity.Name);
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

        public IEnumerable<GameDTO> GetGameAndImage()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Select gm.{nameof(Game.ID)},{nameof(Game.Name)},{nameof(Game.Stock)},{nameof(Game.Price)},{nameof(Game.Description)},c.{nameof(Category.CategoryName)},gı.{nameof(GameImage.ImageURL)} from {nameof(Game)} as gm join {nameof(GameCategory)} as gc on gm.{nameof(Game.ID)}=gc.{nameof(GameCategory.GameID)} join {nameof(Category)} as c on c.{nameof(Category.ID)}=gc.{nameof(GameCategory.CategoryID)} join {nameof(GameImage)} as gı on gm.{nameof(Game.ID)}=gı.{nameof(GameImage.GameID)} where gm.Active = 1 and gm.Deleted = 0";
                   
                    using (SqlDataReader result = command.ExecuteReader())
                    {
                        while (result.Read())
                            yield return new GameDTO() { ID = result.GetInt32(0), GameName = result.GetString(1), Stock = result.GetInt32(2), Price = result.GetDecimal(3), Description = result.GetString(4),GameCategoryName = result.GetString(5),GameImageURL = result.GetString(6) };
                        connection.Close();
                    }
                }
            }
        }

        public IEnumerable<GameDTO> GetGameAndImage(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Select gm.{nameof(Game.ID)},{nameof(Game.Name)},{nameof(Game.Stock)},{nameof(Game.Price)},{nameof(Game.Description)},c.{nameof(Category.CategoryName)},gı.{nameof(GameImage.ImageURL)} from {nameof(Game)} as gm join {nameof(GameCategory)} as gc on gm.{nameof(Game.ID)}=gc.{nameof(GameCategory.GameID)} join {nameof(Category)} as c on c.{nameof(Category.ID)}=gc.{nameof(GameCategory.CategoryID)} join {nameof(GameImage)} as gı on gm.{nameof(Game.ID)}=gı.{nameof(GameImage.GameID)} where gm.ID = @id";
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader result = command.ExecuteReader())
                    {
                        while (result.Read())
                            yield return new GameDTO() { ID = result.GetInt32(0), GameName = result.GetString(1), Stock = result.GetInt32(2), Price = result.GetDecimal(3), Description = result.GetString(4), GameCategoryName = result.GetString(5), GameImageURL = result.GetString(6) };
                        connection.Close();
                    }
                }
            }
        }

        public IEnumerable<GameDTO> GetCartByGameId(int userId)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Select gm.{nameof(Game.ID)},{nameof(Game.Name)},{nameof(Game.Stock)},{nameof(Game.Price)},{nameof(Game.Description)},gı.{nameof(GameImage.ImageURL)} from {nameof(Game)} as gm join {nameof(Cart)} as crt on gm.{nameof(Game.ID)} = crt.{nameof(Cart.GameID)} join AspNetUsers as usr on usr.Id = crt.{nameof(Cart.AppUserId)} join {nameof(GameImage)} as gı on gm.{nameof(Game.ID)}=gı.{nameof(GameImage.GameID)} where usr.Id = @userId and crt.Active = 1 and crt.Deleted = 0";
                    command.Parameters.AddWithValue("@userId", userId);

                    using (SqlDataReader result = command.ExecuteReader())
                    {
                        while (result.Read())
                            yield return new GameDTO() { ID = result.GetInt32(0), GameName = result.GetString(1), Stock = result.GetInt32(2), Price = result.GetDecimal(3), Description = result.GetString(4), GameImageURL = result.GetString(5) };
                        connection.Close();
                    }
                }
            }
        }

        public GameDTO GetGameAndImageByGameId(int gameId)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Select gm.{nameof(Game.ID)},{nameof(Game.Name)},{nameof(Game.Stock)},{nameof(Game.Price)},{nameof(Game.Description)},c.{nameof(Category.CategoryName)},gı.{nameof(GameImage.ImageURL)},c.{nameof(Category.ID)} from {nameof(Game)} as gm join {nameof(GameCategory)} as gc on gm.{nameof(Game.ID)}=gc.{nameof(GameCategory.GameID)} join {nameof(Category)} as c on c.{nameof(Category.ID)}=gc.{nameof(GameCategory.CategoryID)} join {nameof(GameImage)} as gı on gm.{nameof(Game.ID)}=gı.{nameof(GameImage.GameID)} where gm.ID = @id";
                    command.Parameters.AddWithValue("@id", gameId);

                    using (SqlDataReader result = command.ExecuteReader())
                    {
                        GameDTO game = new GameDTO();
                        if (result.Read())
                        {
                            game.ID = result.GetInt32(0); game.GameName = result.GetString(1); game.Stock = result.GetInt32(2); game.Price = result.GetDecimal(3); game.Description = result.GetString(4); game.GameCategoryName = result.GetString(5); game.GameImageURL = result.GetString(6); game.CategoryID = result.GetInt32(7);
                            connection.Close();
                        }
                        using (SqlConnection connection2 = new SqlConnection())
                        {
                            connection2.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                            using (SqlCommand command2 = new SqlCommand())
                            {
                                connection2.Open();
                                command2.Connection = connection2;
                                command2.CommandText = $"Select ID,CategoryName,CategoryImageURL from Category where not ID = (select CategoryID from GameCategory where GameID = @id)";
                                command2.Parameters.AddWithValue("@id", gameId);

                                using (SqlDataReader result2 = command2.ExecuteReader())
                                {

                                    List<Category> category = new List<Category>();
                                    while (result2.Read())
                                    {
                                        Category c = new Category() {ID = result2.GetInt32(0),CategoryName = result2.GetString(1),CategoryImageURL=result2.GetString(2) };

                                        category.Add(c);
                                        
                                    }
                                    connection2.Close();
                                    game.Categories = category;
                                    return game;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
