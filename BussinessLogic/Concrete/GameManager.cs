using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BussinessLogic.Abstract;
using Core.BLL.Constant;
using Core.BLL.Logger;
using DataAccess.Abstract;
using Entity.DTO;
using Entity.POCO;

namespace BussinessLogic.Concrete
{
    public class GameManager:IGameService
    {
        private readonly IGameDAL gameDAL;
        

        public GameManager(IGameDAL gameDAL)
        {
            this.gameDAL = gameDAL;
            
        }

        
        public EntityResult Add(Game entity)
        {
            try
            {
                var result = gameDAL.Add(entity);
                if (result)
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult Add(Game entity) Tarih: " + DateTime.Now+" ID: "+entity.ID+"  Oyun Adı: "+entity.Name+" Oyunu Eklendi", LogType.Insert);
                    return new EntityResult("Success");
                }
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult Add(Game entity) Tarih: " + DateTime.Now + " ID: " + entity.ID + "  Oyun Adı: " + entity.Name + " Oyunu Eklenemedi, Non Validation", LogType.NonValidation);
                    return new EntityResult("Non Validation", EntityResultType.NonValidation);
                }
            }
            catch (Exception ex)
            {

                GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult Add(Game entity) Tarih: " + DateTime.Now + " ID: " + entity.ID + "  Oyun Adı: " + entity.Name + " Oyunu Eklenemedi, Error: "+ex.ToInnest().Message, LogType.Error);
                return new EntityResult("Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult Delete(Game entity)
        {
            try
            {
                var result = gameDAL.Delete(entity);
                if (result)
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult Delete(Game entity) Tarih: " + DateTime.Now + " ID: " + entity.ID + "  Oyun Adı: " + entity.Name + " Tüm Oyunlar Bu Şekilde Silindi", LogType.Delete);
                    return new EntityResult("Success");
                }
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult Delete(Game entity) Tarih: " + DateTime.Now + " ID: " + entity.ID + "  Oyun Adı: " + entity.Name + " Tüm Oyunlar Bu Şekilde Silinemedi, Warning", LogType.Warning);
                    return new EntityResult("Warning", EntityResultType.Warning);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult Delete(Game entity) Tarih: " + DateTime.Now + " ID: " + entity.ID + "  Oyun Adı: " + entity.Name + " Tüm Oyunlar Bu Şekilde Silinemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult("Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult Delete(Game entity, int gameid)
        {
            try
            {
                var result = gameDAL.Delete(entity,gameid);
                if (result)
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult Delete(Game entity, int gameid) Tarih: " + DateTime.Now + " ID: " + gameid + "  Oyun Adı: " + entity.Name + " Oyunu Silindi", LogType.Delete);
                    return new EntityResult("Success");
                }
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult Delete(Game entity, int gameid) Tarih: " + DateTime.Now + " ID: " + gameid + "  Oyun Adı: " + entity.Name + " Oyunu Silinemedi, Warning", LogType.Warning);
                    return new EntityResult("Warning", EntityResultType.Warning);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult Delete(Game entity, int gameid) Tarih: " + DateTime.Now + " ID: " + gameid + "  Oyun Adı: " + entity.Name + " Oyunu Silinemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult("Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult Delete(int gameid)
        {
            try
            {
                var result = gameDAL.Delete(gameid);
                if (result)
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult Delete(int gameid) Tarih: " + DateTime.Now + " Oyun ID: " + gameid + " Olan Oyun Silindi", LogType.Delete);
                    return new EntityResult("Success");
                }
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult Delete(int gameid) Tarih: " + DateTime.Now + " Oyun ID: " + gameid + " Olan Oyun Silinemedi, Warning", LogType.Warning);
                    return new EntityResult("Warning", EntityResultType.Warning);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult Delete(int gameid) Tarih: " + DateTime.Now + " ID: " + gameid + " Olan Oyun Silinemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult("Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        

        public EntityResult<IEnumerable<Game>> Get()
        {
            try
            {
                var result = gameDAL.Get();
                if (result != null && result.Count() > 0)
                    return new EntityResult<IEnumerable<Game>>(result, "Success");
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult<IEnumerable<Game>> Get() Tarih: " + DateTime.Now + " Oyun Çekilemedi, NotFound ", LogType.Notfound);
                    return new EntityResult<IEnumerable<Game>>(null, "Not Found", EntityResultType.Notfound);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult<IEnumerable<Game>> Get() Tarih: " + DateTime.Now + " Oyun Çekilemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult<IEnumerable<Game>>(null, "Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult<Game> Get(int id)
        {
            try
            {
                var result = gameDAL.Get(id);
                if (result != null)
                    return new EntityResult<Game>(result, "Success");
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult<Game> Get(int id) Tarih: " + DateTime.Now + " ID: " + id + " Olan Oyun Çekilemedi, NotFound ", LogType.Notfound);
                    return new EntityResult<Game>(null, "Not Found", EntityResultType.Notfound);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult<Game> Get(int id) Tarih: " + DateTime.Now + " ID: " + id + " Olan Oyun Çekilemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult<Game>(null, "Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult<Game> GetActive(int id)
        {
            try
            {
                var result = gameDAL.GetActive(id);
                if (result != null)
                    return new EntityResult<Game>(result, "Success");
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult<Game> GetActive(int id) Tarih: " + DateTime.Now + " ID: " + id + " Olan Oyun Çekilemedi, NotFound ", LogType.Notfound);
                    return new EntityResult<Game>(null, "Not Found", EntityResultType.Notfound);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult<Game> GetActive(int id) Tarih: " + DateTime.Now + " ID: " + id + " Olan Oyun Çekilemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult<Game>(null, "Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult<IEnumerable<Game>> GetAllActive()
        {
            try
            {
                var result = gameDAL.GetAllActive();
                if (result != null && result.Count() > 0)
                    return new EntityResult<IEnumerable<Game>>(result, "Success");
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult<IEnumerable<Game>> GetAllActive() Tarih: " + DateTime.Now + " Oyun Çekilemedi, NotFound ", LogType.Notfound);
                    return new EntityResult<IEnumerable<Game>>(null, "Not Found", EntityResultType.Notfound);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult<IEnumerable<Game>> GetAllActive() Tarih: " + DateTime.Now + " Oyun Çekilemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult<IEnumerable<Game>>(null, "Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult<IEnumerable<GameDTO>> GetCartByGameId(int userId)
        {
            try
            {
                var result = gameDAL.GetCartByGameId(userId).ToList();
                if (result != null && result.Count() > 0)
                {
                    return new EntityResult<IEnumerable<GameDTO>>(result, "Success");
                }
                GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult<IEnumerable<GameDTO>> GetCartByGameId(int userId) Tarih: " + DateTime.Now + " Oyun Çekilemedi, NotFound ", LogType.Notfound);
                return new EntityResult<IEnumerable<GameDTO>>(null, "NotFound", EntityResultType.Notfound);
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult<IEnumerable<GameDTO>> GetCartByGameId(int userId) Tarih: " + DateTime.Now + " Oyun Çekilemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult<IEnumerable<GameDTO>>(null, "Error: " + ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult<IEnumerable<GameDTO>> GetGameAndImage()
        {
            try
            {
                var result = gameDAL.GetGameAndImage();
                if (result != null && result.Count() > 0)
                    return new EntityResult<IEnumerable<GameDTO>>(result, "Success");
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult<IEnumerable<GameDTO>> GetGameAndImage() Tarih: " + DateTime.Now + " Oyun Çekilemedi, NotFound ", LogType.Notfound);
                    return new EntityResult<IEnumerable<GameDTO>>(null, "Not Found", EntityResultType.Notfound);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult<IEnumerable<GameDTO>> GetGameAndImage() Tarih: " + DateTime.Now + " Oyun Çekilemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult<IEnumerable<GameDTO>>(null, "Error: " + ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult<IEnumerable<GameDTO>> GetGameAndImage(int id)
        {
            try
            {
                var result = gameDAL.GetGameAndImage(id);
                if (result != null && result.Count() > 0)
                    return new EntityResult<IEnumerable<GameDTO>>(result, "Success");
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult<IEnumerable<GameDTO>> GetGameAndImage(int id) Tarih: " + DateTime.Now + " Oyun Çekilemedi, NotFound ", LogType.Notfound);
                    return new EntityResult<IEnumerable<GameDTO>>(null, "Not Found", EntityResultType.Notfound);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult<IEnumerable<GameDTO>> GetGameAndImage(int id) Tarih: " + DateTime.Now + " Oyun Çekilemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult<IEnumerable<GameDTO>>(null, "Error: " + ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult<GameDTO> GetGameAndImageByGameId(int gameId)
        {
            try
            {
                var result = gameDAL.GetGameAndImageByGameId(gameId);
                if (result != null)
                    return new EntityResult<GameDTO>(result, "Success");
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult<GameDTO> GetGameAndImageByGameId(int gameId) Tarih: " + DateTime.Now + " Oyun Çekilemedi, NotFound ", LogType.Notfound);
                    return new EntityResult<GameDTO>(null, "Not Found", EntityResultType.Notfound);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult<GameDTO> GetGameAndImageByGameId(int gameId) Tarih: " + DateTime.Now + " Oyun Çekilemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult<GameDTO>(null, "Error: " + ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult<IEnumerable<GameDTO>> GetGameByCategoryId(int categoryid)
        {
            try
            {
                var result = gameDAL.GetGameByCategoryId(categoryid);
                if (result != null && result.Count() > 0)
                    return new EntityResult<IEnumerable<GameDTO>>(result, "Success");
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult<IEnumerable<GameDTO>> GetGameByCategoryId(int categoryid) Tarih: " + DateTime.Now + "Kategori ID: "+ categoryid+"Olan Oyun Çekilemedi, NotFound ", LogType.Notfound);
                    return new EntityResult<IEnumerable<GameDTO>>(null, "Not Found", EntityResultType.Notfound);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult<IEnumerable<GameDTO>> GetGameByCategoryId(int categoryid) Tarih: " + DateTime.Now + "Kategori ID: " + categoryid + "Olan Oyun Çekilemedi, Error: "+ex.ToInnest().Message, LogType.Error);
                return new EntityResult<IEnumerable<GameDTO>>(null, "Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult Update(Game entity)
        {
            try
            {
                var result = gameDAL.Update(entity);
                if (result)
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult Update(Game entity) Tarih: " + DateTime.Now + " ID: " + entity.ID + "  Oyun Adı: " + entity.Name + " Tüm Oyunlar Bu Şekilde Güncellendi", LogType.Update);
                    return new EntityResult("Success");
                }
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult Update(Game entity) Tarih: " + DateTime.Now + " ID: " + entity.ID + "  Oyun Adı: " + entity.Name + " Tüm Oyunlar Bu Şekilde Güncellenemedi, Non Validation", LogType.NonValidation);
                    return new EntityResult("Non Validation", EntityResultType.NonValidation);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult Update(Game entity) Tarih: " + DateTime.Now + " ID: " + entity.ID + "  Oyun Adı: " + entity.Name + " Tüm Oyunlar Bu Şekilde Güncellenemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult("Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult Update(Game entity, int gameid)
        {
            try
            {
                var result = gameDAL.Update(entity,gameid);
                if (result)
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult Update(Game entity, int gameid) Tarih: " + DateTime.Now + " ID: " + gameid + "  Oyun Adı: " + entity.Name + " Oyunu Güncellendi", LogType.Update);
                    return new EntityResult("Success");
                }
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult Update(Game entity, int gameid) Tarih: " + DateTime.Now + " ID: " + gameid + "  Oyun Adı: " + entity.Name + " Oyunu Güncellenemedi, Non Validation", LogType.NonValidation);
                    return new EntityResult("Non Validation", EntityResultType.NonValidation);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: GameManager>EntityResult Update(Game entity, int gameid) Tarih: " + DateTime.Now + " ID: " + gameid + "  Oyun Adı: " + entity.Name + " Oyunu Güncellenemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult("Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }
    }
}
