using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entity.DTO;
using Entity.POCO;
using Microsoft.Data.SqlClient;

namespace DataAccess.Concrete.ADONET
{
    public class AdoCategory:ICategoryDAL
    {

        public bool Add(Category entity)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Insert into {nameof(Category)} ({nameof(entity.CategoryName)},{nameof(entity.CategoryImageURL)},{nameof(entity.Active)},{nameof(entity.Deleted)},{nameof(entity.Created)},{nameof(entity.Updated)}) values (@categoryName,@categoryImageURL,@active,@deleted,@created,@updated)";
                    command.Parameters.AddWithValue("@categoryName", entity.CategoryName);
                    command.Parameters.AddWithValue("@categoryImageURL", entity.CategoryImageURL);
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

        public bool Delete(Category entity,int categoryid)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Update {nameof(Category)} set {nameof(Category.Active)}='false',{nameof(Category.Deleted)}='true',{nameof(Category.Updated)}=@updated where {nameof(Category.ID)} = @categoryid";
                    command.Parameters.AddWithValue("@updated", entity.Updated);
                    command.Parameters.AddWithValue("@categoryid", categoryid);
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

        public bool Delete(int categoryid)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Update {nameof(Category)} set {nameof(Category.Active)}='false',{nameof(Category.Deleted)}='true',{nameof(Category.Updated)}='{DateTime.Now}' where {nameof(Category.ID)} = @categoryid";
                    command.Parameters.AddWithValue("@categoryid", categoryid);
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


        public bool Delete(Category entity)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Update {nameof(Category)} set {nameof(Category.Active)}='false',{nameof(Category.Deleted)}='true',{nameof(Category.Updated)}=@updated";
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

        public IEnumerable<Category> Get()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Select {nameof(Category.ID)},{nameof(Category.CategoryName)},{nameof(Category.CategoryImageURL)} from {nameof(Category)}";
                    using (SqlDataReader result = command.ExecuteReader())
                    {
                        while (result.Read())
                            yield return new Category { ID = result.GetInt32(0), CategoryName = result.GetString(1), CategoryImageURL = result.GetString(2) };
                        connection.Close();
                    }
                }
            }
        }

        public IEnumerable<Category> GetAllActive()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Select {nameof(Category.ID)},{nameof(Category.CategoryName)},{nameof(Category.CategoryImageURL)} from {nameof(Category)} where {nameof(Category.Active)}=1 and {nameof(Category.Deleted)}=0";
                    using (SqlDataReader result = command.ExecuteReader())
                    {
                        while (result.Read())
                            yield return new Category { ID = result.GetInt32(0), CategoryName = result.GetString(1), CategoryImageURL = result.GetString(2) };
                        connection.Close();
                    }
                }
            }
        }

        public Category Get(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Select {nameof(Category.ID)},{nameof(Category.CategoryName)},{nameof(Category.CategoryImageURL)} from {nameof(Category)} Where {nameof(Category.ID)} = @id";
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader result = command.ExecuteReader())
                    {
                        if (result.Read())
                            return new Category() { ID = result.GetInt32(0), CategoryName = result.GetString(1), CategoryImageURL = result.GetString(2) };
                        else
                            return null;
                        connection.Close();
                    }
                }
            }
        }

        public Category GetActive(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Select {nameof(Category.ID)},{nameof(Category.CategoryName)},{nameof(Category.CategoryImageURL)} from {nameof(Category)} Where {nameof(Category.ID)} = @id and {nameof(Category.Active)}=1 and {nameof(Category.Deleted)}=0";
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader result = command.ExecuteReader())
                    {

                        if (result.Read())
                            return new Category() { ID = result.GetInt32(0), CategoryName = result.GetString(1), CategoryImageURL = result.GetString(2) };
                        else
                            return new Category() { };
                        connection.Close();
                    }
                }
            }
        }

        public bool Update(Category entity,int categoryid)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Update {nameof(Category)} set {nameof(Category.CategoryName)}=@categoryName,{nameof(Category.CategoryImageURL)}=@categoryImageURL,{nameof(Category.Active)}=@active,{nameof(Category.Deleted)}=@deleted,{nameof(Category.Updated)}=@updated where {nameof(Category.ID)} = @categoryid";
                    command.Parameters.AddWithValue("@categoryName", entity.CategoryName);
                    command.Parameters.AddWithValue("@categoryImageURL", entity.CategoryImageURL);
                    command.Parameters.AddWithValue("@active", Convert.ToInt32(entity.Active));
                    command.Parameters.AddWithValue("@deleted", Convert.ToInt32(entity.Deleted));
                    command.Parameters.AddWithValue("@updated", entity.Updated);
                    command.Parameters.AddWithValue("@categoryid", categoryid);
                    var result = command.ExecuteNonQuery() ;
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


        public bool Update(Category entity)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Update {nameof(Category)} set {nameof(Category.CategoryName)}=@categoryName,{nameof(Category.CategoryImageURL)}=@categoryImageURL,{nameof(Category.Active)}=@active,{nameof(Category.Deleted)}=@deleted,{nameof(Category.Updated)}=@updated";
                    command.Parameters.AddWithValue("@categoryName", entity.CategoryName);
                    command.Parameters.AddWithValue("@categoryImageURL", entity.CategoryImageURL);
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

        public IEnumerable<CategoryDTO> GetAllActiveAndCartUserId(int userId)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Select c.{nameof(Category.ID)},{nameof(Category.CategoryName)},{nameof(Category.CategoryImageURL)},Count(AppUserId) as 'Toplam' from {nameof(Category)} as c join {nameof(GameCategory)} as gc on c.{nameof(Category.ID)}=gc.{nameof(GameCategory.CategoryID)} join {nameof(Game)} as gm on gc.{nameof(GameCategory.GameID)}=gm.{nameof(Game.ID)} join {nameof(Cart)} as crt on gm.{nameof(Game.ID)}=crt.{nameof(Cart.GameID)} join AspNetUsers as usr on crt.{nameof(Cart.AppUserId)}=usr.Id Where crt.{nameof(Cart.AppUserId)} = @userId group by c.{nameof(Category.ID)},c.{nameof(Category.CategoryName)},{nameof(Category.CategoryImageURL)}";
                    command.Parameters.AddWithValue("@userId", userId);
                    using (SqlDataReader result = command.ExecuteReader())
                    {
                        while (result.Read())
                            yield return new CategoryDTO() { ID = result.GetInt32(0), CategoryName = result.GetString(1), CategoryImageURL = result.GetString(2), CartCount= result.GetInt32(3) };
                        connection.Close();
                    }
                }
            }
        }
    }
}
