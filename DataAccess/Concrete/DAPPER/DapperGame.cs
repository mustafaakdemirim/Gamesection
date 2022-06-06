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
    public class DapperGame : IGameDAL
    {
        public bool Add(Game entity)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Insert into {nameof(Game)} ({nameof(entity.Stock)},{nameof(entity.Name)},{nameof(entity.Price)},{nameof(entity.Description)},{nameof(entity.Active)},{nameof(entity.Deleted)},{nameof(entity.Created)},{nameof(entity.Updated)}) values (@stock,@name,@price,@description,@active,@deleted,@created,@updated)";
                cmd.Parameters.Add(new SqlParameter("@stock", entity.Stock));
                cmd.Parameters.Add(new SqlParameter("@name", entity.Name));
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

        public bool Delete(Game entity,int gameid)
        {
            using (IDbConnection connection = new SqlConnection())
            {
               using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Update {nameof(Game)} set {nameof(entity.Active)}='false',{nameof(entity.Deleted)}='true',{nameof(entity.Updated)}=@updated where {nameof(Game.ID)}=@gameid";
                cmd.Parameters.Add(new SqlParameter("@updated", entity.Updated));
                cmd.Parameters.Add(new SqlParameter("@gameid", gameid));
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

        public bool Delete(int gameid)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Update {nameof(Game)} set {nameof(Game.Active)}='false',{nameof(Game.Deleted)}='true',{nameof(Game.Updated)}='{DateTime.Now}' where {nameof(Game.ID)}=@gameid";
                cmd.Parameters.Add(new SqlParameter("@gameid", gameid));
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

        public bool Delete(Game entity)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Update {nameof(Game)} set {nameof(entity.Active)}='false',{nameof(entity.Deleted)}='true',{nameof(entity.Updated)}=@updated";
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

        public IEnumerable<Game> Get()
        {
            using (IDbConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                using (IDataReader result = connection.ExecuteReader($"Select {nameof(Game.ID)},{nameof(Game.Name)},{nameof(Game.Stock)},{nameof(Game.Price)},{nameof(Game.Description)} from {nameof(Game)}"))
                {
                    while (result.Read())
                        yield return new Game() { ID = result.GetInt32(0), Name = result.GetString(1), Stock = result.GetInt32(2), Price = result.GetDecimal(3), Description = result.GetString(4) };
                    connection.Close();
                }
            }
        }

        public IEnumerable<Game> GetAllActive()
        {
            using (IDbConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                using (IDataReader result = connection.ExecuteReader($"Select {nameof(Game.ID)},{nameof(Game.Name)},{nameof(Game.Stock)},{nameof(Game.Price)},{nameof(Game.Description)} from {nameof(Game)} where {nameof(Game.Active)}=1 and {nameof(Game.Deleted)}=0"))
                {
                    while (result.Read())
                        yield return new Game() { ID = result.GetInt32(0), Name = result.GetString(1), Stock = result.GetInt32(2), Price = result.GetDecimal(3), Description = result.GetString(4) };
                    connection.Close();
                }
            }
        }

        public Game Get(int id)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Select {nameof(Game.ID)},{nameof(Game.Name)},{nameof(Game.Stock)},{nameof(Game.Price)},{nameof(Game.Description)} from {nameof(Game)} where {nameof(Game.ID)} = @id";
                cmd.Parameters.Add(new SqlParameter("@id", id));
                using (IDataReader result = cmd.ExecuteReader())
                {
                    if (result.Read())
                        return new Game() { ID = result.GetInt32(0), Name = result.GetString(1), Stock = result.GetInt32(2), Price = result.GetDecimal(3), Description = result.GetString(4) };
                    else
                        return null;
                    connection.Close();
                }
            }
        }

        public Game GetActive(int id)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Select {nameof(Game.ID)},{nameof(Game.Name)},{nameof(Game.Stock)},{nameof(Game.Price)},{nameof(Game.Description)} from {nameof(Game)} where {nameof(Game.ID)} = @id and {nameof(Game.Active)}=1 and {nameof(Game.Deleted)}=0";
                cmd.Parameters.Add(new SqlParameter("@id", id));
                using (IDataReader result = cmd.ExecuteReader())
                {
                    if (result.Read())
                        return new Game() { ID = result.GetInt32(0), Name = result.GetString(1), Stock = result.GetInt32(2), Price = result.GetDecimal(3), Description = result.GetString(4) };
                    else
                        return null;
                    connection.Close();
                }
            }
        }

        public IEnumerable<GameDTO> GetGameByCategoryId(int categoryid)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Select gm.{nameof(Game.ID)},{nameof(Game.Name)},{nameof(Game.Stock)},{nameof(Game.Price)},{nameof(Game.Description)} from {nameof(Game)} as gm join {nameof(GameCategory)} as gc on gm.{nameof(Game.ID)}=gc.{nameof(GameCategory.GameID)} join {nameof(Category)} as c on c.{nameof(Category.ID)}=gc.{nameof(GameCategory.CategoryID)} where c.{nameof(Category.ID)} = @categoryid";
                cmd.Parameters.Add(new SqlParameter("@categoryid", categoryid));
                using (IDataReader result = cmd.ExecuteReader())
                {
                    while (result.Read())
                        yield return new GameDTO() { ID = result.GetInt32(0), GameName = result.GetString(1), Stock = result.GetInt32(2), Price = result.GetDecimal(3), Description = result.GetString(4) };
                    connection.Close();
                }
            }
        }

        public bool Update(Game entity, int gameid)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Update {nameof(Game)} set {nameof(Game.Stock)}=@stock,{nameof(Game.Name)}=@name,{nameof(entity.Price)}=@price,{nameof(Game.Description)}=@description,{nameof(Game.Active)}=@active,{nameof(Game.Deleted)}=@deleted,{nameof(Game.Updated)}=@updated where {nameof(Game.ID)}=@gameid";
                cmd.Parameters.Add(new SqlParameter("@stock", entity.Stock));
                cmd.Parameters.Add(new SqlParameter("@name", entity.Name));
                cmd.Parameters.Add(new SqlParameter("@price", entity.Price));
                cmd.Parameters.Add(new SqlParameter("@description", entity.Description));
                cmd.Parameters.Add(new SqlParameter("@active", Convert.ToInt32(entity.Active)));
                cmd.Parameters.Add(new SqlParameter("@deleted", Convert.ToInt32(entity.Deleted)));
                cmd.Parameters.Add(new SqlParameter("@updated", entity.Updated));
                cmd.Parameters.Add(new SqlParameter("@gameid", gameid));
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

        public bool Update(Game entity)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Update {nameof(Game)} set {nameof(Game.Stock)}=@stock,{nameof(Game.Name)}=@name,{nameof(entity.Price)}=@price,{nameof(Game.Description)}=@description,{nameof(Game.Active)}=@active,{nameof(Game.Deleted)}=@deleted,{nameof(Game.Updated)}=@updated";
                cmd.Parameters.Add(new SqlParameter("@stock", entity.Stock));
                cmd.Parameters.Add(new SqlParameter("@name", entity.Name));
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

        public IEnumerable<GameDTO> GetGameAndImage()
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Select gm.{nameof(Game.ID)},{nameof(Game.Name)},{nameof(Game.Stock)},{nameof(Game.Price)},{nameof(Game.Description)},c.{nameof(Category.CategoryName)},gı.{nameof(GameImage.ImageURL)} from {nameof(Game)} as gm join {nameof(GameCategory)} as gc on gm.{nameof(Game.ID)}=gc.{nameof(GameCategory.GameID)} join {nameof(Category)} as c on c.{nameof(Category.ID)}=gc.{nameof(GameCategory.CategoryID)} join {nameof(GameImage)} as gı on gm.{nameof(Game.ID)}=gı.{nameof(GameImage.GameID)} where gm.Active = 1 and gm.Deleted = 0";

                using (IDataReader result = cmd.ExecuteReader())
                {
                    while (result.Read())
                        yield return new GameDTO() { ID = result.GetInt32(0), GameName = result.GetString(1), Stock = result.GetInt32(2), Price = result.GetDecimal(3), Description = result.GetString(4), GameCategoryName = result.GetString(5), GameImageURL = result.GetString(6) };
                    connection.Close();
                }
            }
        }

        public IEnumerable<GameDTO> GetGameAndImage(int id)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Select gm.{nameof(Game.ID)},{nameof(Game.Name)},{nameof(Game.Stock)},{nameof(Game.Price)},{nameof(Game.Description)},c.{nameof(Category.CategoryName)},gı.{nameof(GameImage.ImageURL)} from {nameof(Game)} as gm join {nameof(GameCategory)} as gc on gm.{nameof(Game.ID)}=gc.{nameof(GameCategory.GameID)} join {nameof(Category)} as c on c.{nameof(Category.ID)}=gc.{nameof(GameCategory.CategoryID)} join {nameof(GameImage)} as gı on gm.{nameof(Game.ID)}=gı.{nameof(GameImage.GameID)} where gm.ID = @id";
                cmd.Parameters.Add(new SqlParameter("@id", id));
                using (IDataReader result = cmd.ExecuteReader())
                {
                    while (result.Read())
                        yield return new GameDTO() { ID = result.GetInt32(0), GameName = result.GetString(1), Stock = result.GetInt32(2), Price = result.GetDecimal(3), Description = result.GetString(4), GameCategoryName = result.GetString(5), GameImageURL = result.GetString(6) };
                    connection.Close();
                }
            }
        }

        public IEnumerable<GameDTO> GetCartByGameId(int userId)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Select gm.{nameof(Game.ID)},{nameof(Game.Name)},{nameof(Game.Stock)},{nameof(Game.Price)},{nameof(Game.Description)},gı.{nameof(GameImage.ImageURL)} from {nameof(Game)} as gm join {nameof(Cart)} as crt on gm.{nameof(Game.ID)} = crt.{nameof(Cart.GameID)} join AspNetUsers as usr on usr.Id = crt.{nameof(Cart.AppUserId)} join {nameof(GameImage)} as gı on gm.{nameof(Game.ID)}=gı.{nameof(GameImage.GameID)} where usr.Id = @userId and crt.Active = 1 and crt.Deleted = 0";
                cmd.Parameters.Add(new SqlParameter("@userId", userId));
                using (IDataReader result = cmd.ExecuteReader())
                {
                    while (result.Read())
                        yield return new GameDTO() { ID = result.GetInt32(0), GameName = result.GetString(1), Stock = result.GetInt32(2), Price = result.GetDecimal(3), Description = result.GetString(4), GameImageURL = result.GetString(5) };
                    connection.Close();
                }
            }
        }

        public GameDTO GetGameAndImageByGameId(int gameId)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Select gm.{nameof(Game.ID)},{nameof(Game.Name)},{nameof(Game.Stock)},{nameof(Game.Price)},{nameof(Game.Description)},c.{nameof(Category.CategoryName)},gı.{nameof(GameImage.ImageURL)},c.{nameof(Category.ID)} from {nameof(Game)} as gm join {nameof(GameCategory)} as gc on gm.{nameof(Game.ID)}=gc.{nameof(GameCategory.GameID)} join {nameof(Category)} as c on c.{nameof(Category.ID)}=gc.{nameof(GameCategory.CategoryID)} join {nameof(GameImage)} as gı on gm.{nameof(Game.ID)}=gı.{nameof(GameImage.GameID)} where gm.ID = @id";
                cmd.Parameters.Add(new SqlParameter("@id", gameId));
                using (IDataReader result = cmd.ExecuteReader())
                {
                    GameDTO game = new GameDTO();
                    if (result.Read())
                    {
                        game.ID = result.GetInt32(0); game.GameName = result.GetString(1); game.Stock = result.GetInt32(2); game.Price = result.GetDecimal(3); game.Description = result.GetString(4); game.GameCategoryName = result.GetString(5); game.GameImageURL = result.GetString(6); game.CategoryID = result.GetInt32(7);
                        connection.Close();
                    }
                    using (IDbConnection connection2 = new SqlConnection())
                    {
                        using var cmd2 = connection2.CreateCommand();
                        connection2.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                        connection2.Open();
                        cmd2.CommandText = $"Select ID,CategoryName,CategoryImageURL from Category where not ID = (select CategoryID from GameCategory where GameID = @id)";
                        cmd2.Parameters.Add(new SqlParameter("@id", gameId));
                        using (IDataReader result2 = cmd2.ExecuteReader())
                        {
                            List<Category> category = new List<Category>();
                            while (result2.Read())
                            {
                                Category c = new Category() { ID = result2.GetInt32(0),CategoryName = result2.GetString(1), CategoryImageURL = result2.GetString(2) };

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
