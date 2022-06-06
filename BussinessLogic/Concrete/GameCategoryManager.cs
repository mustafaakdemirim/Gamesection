using System;
using BussinessLogic.Abstract;
using Core.BLL.Constant;
using Core.BLL.Logger;
using DataAccess.Abstract;
using Entity.POCO;

namespace BussinessLogic.Concrete
{
    public class GameCategoryManager:IGameCategoryService
    {
        private readonly IGameCategoryDAL gameCategoryDAL;

        public GameCategoryManager(IGameCategoryDAL gameCategoryDAL)
        {
            this.gameCategoryDAL = gameCategoryDAL;
        }

        public EntityResult<bool> Update(GameCategory entity, int categoryid, int gameid)
        {
            try
            {
                var result = gameCategoryDAL.Update(entity, categoryid,gameid);
                if (result)
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: GameCategoryManager>EntityResult<bool> Update(GameCategory entity, int categoryid, int gameid) Tarih: " + DateTime.Now + " GameID: " + gameid + " CategoryID: " + categoryid + " Oyunun Kategorisi Güncellendi", LogType.Update);
                    return new EntityResult<bool>(true,"Success");
                }
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: GameCategoryManager>EntityResult<bool> Update(GameCategory entity, int categoryid, int gameid) Tarih: " + DateTime.Now + " GameID: " + gameid + " CategoryID: " + categoryid + " Oyunun Kategorisi Güncellenemedi, Non Validation", LogType.NonValidation);
                    return new EntityResult<bool>(false,"Non Validation", EntityResultType.NonValidation);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: GameCategoryManager>EntityResult<bool> Update(GameCategory entity, int categoryid, int gameid) Tarih: " + DateTime.Now + " GameID: " + gameid + " CategoryID: " + categoryid + " Oyunun Kategorisi Güncellenemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult<bool>(false,"Error: " + ex.ToInnest().Message, EntityResultType.Error);
            }
        }
    }
}
