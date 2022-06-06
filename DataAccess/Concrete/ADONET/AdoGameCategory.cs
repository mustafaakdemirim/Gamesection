using System;
using DataAccess.Abstract;
using Entity.POCO;
using Microsoft.Data.SqlClient;

namespace DataAccess.Concrete.ADONET
{
    public class AdoGameCategory : IGameCategoryDAL
    {
        public bool Update(GameCategory entity, int categoryid, int gameid)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Server=localhost; Database = GamesectionDb; User Id=sa;Password=Msty200105465834310;MultipleActiveResultSets=true;";
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"Update {nameof(GameCategory)} set {nameof(GameCategory.CategoryID)}=@categoryID,{nameof(GameCategory.GameID)}=@gameId where {nameof(GameCategory.GameID)}=@gameId";
                    command.Parameters.AddWithValue("@categoryID", categoryid);
                    command.Parameters.AddWithValue("@gameId", gameid);
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
