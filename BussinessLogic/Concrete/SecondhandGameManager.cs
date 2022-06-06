using System;
using System.Collections.Generic;
using System.Linq;
using BussinessLogic.Abstract;
using Core.BLL.Constant;
using Core.BLL.Logger;
using DataAccess.Abstract;
using Entity.DTO;
using Entity.POCO;

namespace BussinessLogic.Concrete
{
    public class SecondhandGameManager:ISecondhandGameService
    {
        private readonly ISecondhandGameDAL secondhandGameDAL;

        public SecondhandGameManager(ISecondhandGameDAL secondhandGameDAL)
        {
            this.secondhandGameDAL = secondhandGameDAL;
        }

        public EntityResult Add(SecondhandGame entity)
        {
            try
            {
                var result = secondhandGameDAL.Add(entity);
                if (result)
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: SecondhandGameManager>EntityResult Add(SecondhandGame entity) Tarih: " + DateTime.Now + " ID: " + entity.ID + "  Oyun Adı: " + entity.GameName + " Oyunu Eklendi", LogType.Insert);
                    return new EntityResult("Success");
                }
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: SecondhandGameManager>EntityResult Add(SecondhandGame entity) Tarih: " + DateTime.Now + " ID: " + entity.ID + "  Oyun Adı: " + entity.GameName + " Oyunu Eklenemedi, Non Validation", LogType.NonValidation);
                    return new EntityResult("Non Validation", EntityResultType.NonValidation);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: SecondhandGameManager>EntityResult Add(SecondhandGame entity) Tarih: " + DateTime.Now + " ID: " + entity.ID + "  Oyun Adı: " + entity.GameName + " Oyunu Eklenemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult("Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult Delete(SecondhandGame entity, int secondhandGameid)
        {
            try
            {
                var result = secondhandGameDAL.Delete(entity, secondhandGameid);
                if (result)
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: SecondhandGameManager>EntityResult Delete(SecondhandGame entity, int secondhandGameid) Tarih: " + DateTime.Now + " ID: " + secondhandGameid + "  Oyun Adı: " + entity.GameName + " Oyunu Silindi", LogType.Delete);
                    return new EntityResult("Success");
                }
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: SecondhandGameManager>EntityResult Delete(SecondhandGame entity, int secondhandGameid) Tarih: " + DateTime.Now + " ID: " + secondhandGameid + "  Oyun Adı: " + entity.GameName + " Oyunu Silinemedi, Warning", LogType.Warning);
                    return new EntityResult("Warning", EntityResultType.Warning);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: SecondhandGameManager>EntityResult Delete(SecondhandGame entity, int secondhandGameid) Tarih: " + DateTime.Now + " ID: " + secondhandGameid + "  Oyun Adı: " + entity.GameName + " Oyunu Silinemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult("Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult Delete(int secondhandGameid)
        {
            try
            {
                var result = secondhandGameDAL.Delete(secondhandGameid);
                if (result)
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: SecondhandGameManager>EntityResult Delete(int secondhandGameid) Tarih: " + DateTime.Now + " ID: " + secondhandGameid + " Olan Oyun Silindi", LogType.Delete);
                    return new EntityResult("Success");
                }
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: SecondhandGameManager>EntityResult Delete(int secondhandGameid) Tarih: " + DateTime.Now + " Oyun ID: " + secondhandGameid + " Olan Oyun Silinemedi, Warning", LogType.Warning);
                    return new EntityResult("Warning", EntityResultType.Warning);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: SecondhandGameManager>EntityResult Delete(int secondhandGameid) Tarih: " + DateTime.Now + " ID: " + secondhandGameid + " Olan Oyun Silinemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult("Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult Delete(SecondhandGame entity)
        {
            try
            {
                var result = secondhandGameDAL.Delete(entity);
                if (result)
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: SecondhandGameManager>EntityResult Delete(SecondhandGame entity) Tarih: " + DateTime.Now + " ID: " + entity.ID + "  Oyun Adı: " + entity.GameName + " Tüm Oyunlar Bu Şekilde Silindi", LogType.Delete);
                    return new EntityResult("Success");
                }
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: SecondhandGameManager>EntityResult Delete(SecondhandGame entity) Tarih: " + DateTime.Now + " ID: " + entity.ID + "  Oyun Adı: " + entity.GameName + " Tüm Oyunlar Bu Şekilde Silinemedi, Warning", LogType.Warning);
                    return new EntityResult("Warning", EntityResultType.Warning);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: SecondhandGameManager>EntityResult Delete(SecondhandGame entity) Tarih: " + DateTime.Now + " ID: " + entity.ID + "  Oyun Adı: " + entity.GameName + " Tüm Oyunlar Bu Şekilde Silinemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult("Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult<IEnumerable<SecondhandGame>> Get()
        {
            try
            {
                var result = secondhandGameDAL.Get();
                if (result != null && result.Count() > 0)
                    return new EntityResult<IEnumerable<SecondhandGame>>(result, "Success");
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: SecondhandGameManager>EntityResult<IEnumerable<SecondhandGame>> Get() Tarih: " + DateTime.Now + " Oyun Çekilemedi, NotFound ", LogType.Notfound);
                    return new EntityResult<IEnumerable<SecondhandGame>>(null, "Not Found", EntityResultType.Notfound);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: SecondhandGameManager>EntityResult<IEnumerable<SecondhandGame>> Get() Tarih: " + DateTime.Now + " Oyun Çekilemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult<IEnumerable<SecondhandGame>>(null, "Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult<SecondhandGame> Get(int id)
        {
            try
            {
                var result = secondhandGameDAL.Get(id);
                if (result != null)
                    return new EntityResult<SecondhandGame>(result, "Success");
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: SecondhandGameManager>EntityResult<SecondhandGame> Get(int id) Tarih: " + DateTime.Now + " ID: " + id + " Olan Oyun Çekilemedi, NotFound ", LogType.Notfound);
                    return new EntityResult<SecondhandGame>(null, "Not Found", EntityResultType.Notfound);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: SecondhandGameManager>EntityResult<SecondhandGame> Get(int id) Tarih: " + DateTime.Now + " ID: " + id + " Olan Oyun Çekilemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult<SecondhandGame>(null, "Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult<SecondhandGame> GetActive(int id)
        {
            try
            {
                var result = secondhandGameDAL.GetActive(id);
                if (result != null)
                    return new EntityResult<SecondhandGame>(result, "Success");
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: SecondhandGameManager>EntityResult<SecondhandGame> GetActive(int id) Tarih: " + DateTime.Now + " ID: " + id + " Olan Oyun Çekilemedi, NotFound ", LogType.Notfound);
                    return new EntityResult<SecondhandGame>(null, "Not Found", EntityResultType.Notfound);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: SecondhandGameManager>EntityResult<SecondhandGame> GetActive(int id) Tarih: " + DateTime.Now + " ID: " + id + " Olan Oyun Çekilemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult<SecondhandGame>(null, "Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult<IEnumerable<SecondhandGame>> GetAllActive()
        {
            try
            {
                var result = secondhandGameDAL.GetAllActive();
                if (result != null && result.Count() > 0)
                    return new EntityResult<IEnumerable<SecondhandGame>>(result, "Success");
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: SecondhandGameManager>EntityResult<IEnumerable<SecondhandGame>> GetAllActive() Tarih: " + DateTime.Now + " Oyun Çekilemedi, NotFound ", LogType.Notfound);
                    return new EntityResult<IEnumerable<SecondhandGame>>(null, "Not Found", EntityResultType.Notfound);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: SecondhandGameManager>EntityResult<IEnumerable<SecondhandGame>> GetAllActive() Tarih: " + DateTime.Now + " Oyun Çekilemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult<IEnumerable<SecondhandGame>>(null, "Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult<IEnumerable<SecondhandGameDTO>> GetGameByCategoryId(int categoryid)
        {
            try
            {
                var result = secondhandGameDAL.GetGameByCategoryId(categoryid);
                if (result != null && result.Count() > 0)
                    return new EntityResult<IEnumerable<SecondhandGameDTO>>(result, "Success");
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: SecondhandGameManager>EntityResult<IEnumerable<SecondhandGameDTO>> GetGameByCategoryId(int categoryid) Tarih: " + DateTime.Now + " Oyun Çekilemedi, NotFound ", LogType.Notfound);
                    return new EntityResult<IEnumerable<SecondhandGameDTO>>(null, "Not Found", EntityResultType.Notfound);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: SecondhandGameManager>EntityResult<IEnumerable<SecondhandGameDTO>> GetGameByCategoryId(int categoryid) Tarih: " + DateTime.Now + " Oyun Çekilemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult<IEnumerable<SecondhandGameDTO>>(null, "Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult Update(SecondhandGame entity, int secondhandGameid)
        {
            try
            {
                var result = secondhandGameDAL.Update(entity, secondhandGameid);
                if (result)
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: SecondhandGameManager>EntityResult Update(SecondhandGame entity, int secondhandGameid) Tarih: " + DateTime.Now + " ID: " + secondhandGameid + "  Oyun Adı: " + entity.GameName + " Oyunu Güncellendi", LogType.Update);
                    return new EntityResult("Success");
                }
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: SecondhandGameManager>EntityResult Update(SecondhandGame entity, int secondhandGameid) Tarih: " + DateTime.Now + " ID: " + secondhandGameid + "  Oyun Adı: " + entity.GameName + " Oyunu Güncellenemedi, Non Validation", LogType.NonValidation);
                    return new EntityResult("Non Validation", EntityResultType.NonValidation);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: SecondhandGameManager>EntityResult Update(SecondhandGame entity, int secondhandGameid) Tarih: " + DateTime.Now + " ID: " + secondhandGameid + "  Oyun Adı: " + entity.GameName + " Oyunu Güncellenemedi, Error", LogType.Error);
                return new EntityResult("Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult Update(SecondhandGame entity)
        {
            try
            {
                var result = secondhandGameDAL.Update(entity);
                if (result)
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: SecondhandGameManager>EntityResult Update(SecondhandGame entity) Tarih: " + DateTime.Now + " ID: " + entity.ID + "  Oyun Adı: " + entity.GameName + " Tüm Oyunlar Bu Şekilde Güncellendi", LogType.Update);
                    return new EntityResult("Success");
                }
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: SecondhandGameManager>EntityResult Update(SecondhandGame entity) Tarih: " + DateTime.Now + " ID: " + entity.ID + "  Oyun Adı: " + entity.GameName + " Tüm Oyunlar Bu Şekilde Güncellenemedi, Non Validation", LogType.NonValidation);
                    return new EntityResult("Non Validation", EntityResultType.NonValidation);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: SecondhandGameManager>EntityResult Update(SecondhandGame entity) Tarih: " + DateTime.Now + " ID: " + entity.ID + "  Oyun Adı: " + entity.GameName + " Tüm Oyunlar Bu Şekilde Güncellenemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult("Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }
    }
}
