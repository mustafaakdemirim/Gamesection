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
    public class DapperCategory : ICategoryDAL
    {
        public bool Add(Category entity)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Insert into {nameof(Category)} ({nameof(entity.CategoryName)},{nameof(entity.CategoryImageURL)},{nameof(entity.Active)},{nameof(entity.Deleted)},{nameof(entity.Created)},{nameof(entity.Updated)}) values (@categoryName,@categoryImageURL,@active,@deleted,@created,@updated)";
                cmd.Parameters.Add(new SqlParameter("@categoryName", entity.CategoryName));
                cmd.Parameters.Add(new SqlParameter("@categoryImageURL", entity.CategoryImageURL));
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

        public bool Delete(Category entity,int categoryid)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Update {nameof(Category)} set {nameof(Category.Active)}='false',{nameof(Category.Deleted)}='true',{nameof(Category.Updated)}=@updated where {nameof(Category.ID)} = @categoryid";
                cmd.Parameters.Add(new SqlParameter("@updated", entity.Updated));
                cmd.Parameters.Add(new SqlParameter("@categoryid", categoryid));
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

        public bool Delete(int categoryid)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Update {nameof(Category)} set {nameof(Category.Active)}='false',{nameof(Category.Deleted)}='true',{nameof(Category.Updated)}='{DateTime.Now}' where {nameof(Category.ID)} = @categoryid";
                cmd.Parameters.Add(new SqlParameter("@categoryid", categoryid));
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

        public bool Delete(Category entity)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Update {nameof(Category)} set {nameof(Category.Active)}='false',{nameof(Category.Deleted)}='true',{nameof(Category.Updated)}=@updated";
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

        public IEnumerable<Category> Get()
        {
            using (IDbConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                using (IDataReader result = connection.ExecuteReader($"Select {nameof(Category.ID)},{nameof(Category.CategoryName)},{nameof(Category.CategoryImageURL)} from {nameof(Category)}"))
                {

                    while (result.Read())
                        yield return new Category { ID = result.GetInt32(0), CategoryName = result.GetString(1), CategoryImageURL = result.GetString(2) };
                    connection.Close();
                }

            }
        }

        public IEnumerable<Category> GetAllActive()
        {
            using (IDbConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                using (IDataReader result = connection.ExecuteReader($"Select {nameof(Category.ID)},{nameof(Category.CategoryName)},{nameof(Category.CategoryImageURL)} from {nameof(Category)} where {nameof(Category.Active)}=1 and {nameof(Category.Deleted)}=0"))
                {

                    while (result.Read())
                        yield return new Category { ID = result.GetInt32(0), CategoryName = result.GetString(1), CategoryImageURL = result.GetString(2) };
                    connection.Close();
                }

            }
        }

        public Category Get(int id)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Select {nameof(Category.ID)},{nameof(Category.CategoryName)},{nameof(Category.CategoryImageURL)} from {nameof(Category)} Where {nameof(Category.ID)} = @id";
                cmd.Parameters.Add(new SqlParameter("@id", id));
                using (IDataReader result = cmd.ExecuteReader())
                {

                    if (result.Read())
                        return new Category() { ID = result.GetInt32(0), CategoryName = result.GetString(1), CategoryImageURL = result.GetString(2) };
                    else
                        return null;
                    connection.Close();
                }
                
            }
        }

        public Category GetActive(int id)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Select {nameof(Category.ID)},{nameof(Category.CategoryName)},{nameof(Category.CategoryImageURL)} from {nameof(Category)} Where {nameof(Category.ID)} = @id and {nameof(Category.Active)}=1 and {nameof(Category.Deleted)}=0";
                cmd.Parameters.Add(new SqlParameter("@id", id));
                using (IDataReader result = cmd.ExecuteReader())
                {

                    if (result.Read())
                        return new Category { ID = result.GetInt32(0), CategoryName = result.GetString(1), CategoryImageURL = result.GetString(2) };
                    else
                        return new Category { };
                    connection.Close();
                }

            }
        }

        public bool Update(Category entity,int categoryid)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Update {nameof(Category)} set {nameof(Category.CategoryName)}=@categoryName,{nameof(Category.CategoryImageURL)}=@categoryImageURL,{nameof(Category.Active)}=@active,{nameof(Category.Deleted)}=@deleted,{nameof(Category.Updated)}=@updated where {nameof(Category.ID)} = @categoryid";
                cmd.Parameters.Add(new SqlParameter("@categoryName", entity.CategoryName));
                cmd.Parameters.Add(new SqlParameter("@categoryImageURL", entity.CategoryImageURL));
                cmd.Parameters.Add(new SqlParameter("@active", Convert.ToInt32(entity.Active)));
                cmd.Parameters.Add(new SqlParameter("@deleted", Convert.ToInt32(entity.Deleted)));
                cmd.Parameters.Add(new SqlParameter("@updated", entity.Updated));
                cmd.Parameters.Add(new SqlParameter("@categoryid", categoryid));
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

        public bool Update(Category entity)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Update {nameof(Category)} set {nameof(Category.CategoryName)}=@categoryName,{nameof(Category.CategoryImageURL)}=@categoryImageURL,{nameof(Category.Active)}=@active,{nameof(Category.Deleted)}=@deleted,{nameof(Category.Updated)}=@updated";
                cmd.Parameters.Add(new SqlParameter("@categoryName", entity.CategoryName));
                cmd.Parameters.Add(new SqlParameter("@categoryImageURL", entity.CategoryImageURL));
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

        public IEnumerable<CategoryDTO> GetAllActiveAndCartUserId(int userId)
        {
            using (IDbConnection connection = new SqlConnection())
            {
                using var cmd = connection.CreateCommand();
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                connection.Open();
                cmd.CommandText = $"Select c.{nameof(Category.ID)},{nameof(Category.CategoryName)},{nameof(Category.CategoryImageURL)},Count(AppUserId) as 'Toplam' from {nameof(Category)} as c join {nameof(GameCategory)} as gc on c.{nameof(Category.ID)}=gc.{nameof(GameCategory.CategoryID)} join {nameof(Game)} as gm on gc.{nameof(GameCategory.GameID)}=gm.{nameof(Game.ID)} join {nameof(Cart)} as crt on gm.{nameof(Game.ID)}=crt.{nameof(Cart.GameID)} join AspNetUsers as usr on crt.{nameof(Cart.AppUserId)}=usr.Id Where crt.{nameof(Cart.AppUserId)} = @userId group by c.{nameof(Category.ID)},c.{nameof(Category.CategoryName)},{nameof(Category.CategoryImageURL)}";
                cmd.Parameters.Add(new SqlParameter("@userId", userId));
                using (IDataReader result = cmd.ExecuteReader())
                {

                    while (result.Read())
                       yield return new CategoryDTO() { ID = result.GetInt32(0), CategoryName = result.GetString(1), CategoryImageURL = result.GetString(2), CartCount = result.GetInt32(3) };
                    connection.Close();
                }

            }
        }
    }
}
