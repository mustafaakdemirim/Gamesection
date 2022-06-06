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
    public class CategoryManager:ICategoryService
    {
        private readonly ICategoryDAL categoryDAL;
        

        public CategoryManager(ICategoryDAL categoryDAL)
        {
            this.categoryDAL = categoryDAL;
            
        }

        public EntityResult Add(Category entity)
        {
            try
            {
                var result = categoryDAL.Add(entity);
                if (result)
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: CategoryManager>EntityResult Add(Category entity) Tarih: " + DateTime.Now + " ID: " + entity.ID + "  Kategori Adı: " + entity.CategoryName + " Kategorisi Eklendi", LogType.Insert);
                    return new EntityResult("Success");
                }
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: CategoryManager>EntityResult Add(Category entity) Tarih: " + DateTime.Now + " ID: " + entity.ID + "  Kategori Adı: " + entity.CategoryName + " Kategorisi Eklenemedi, Non Validation", LogType.NonValidation);
                    return new EntityResult("Non Validation", EntityResultType.NonValidation);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: CategoryManager>EntityResult Add(Category entity) Tarih: " + DateTime.Now + " ID: " + entity.ID + "  Kategori Adı: " + entity.CategoryName + " Kategorisi Eklenemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult("Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult Delete(Category entity)
        {
            try
            {
                var result = categoryDAL.Delete(entity);
                if (result)
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: CategoryManager>EntityResult Delete(Category entity) Tarih: " + DateTime.Now + " ID: " + entity.ID + "  Kategori Adı: " + entity.CategoryName + " Tüm Kategoriler Bu Şekilde Silindi", LogType.Delete);
                    return new EntityResult("Success");
                }
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: CategoryManager>EntityResult Delete(Category entity) Tarih: " + DateTime.Now + " ID: " + entity.ID + "  Kategori Adı: " + entity.CategoryName + " Tüm Kategoriler Bu Şekilde Silinemedi, Warning", LogType.Warning);
                    return new EntityResult("Warning", EntityResultType.Warning);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: CategoryManager>EntityResult Delete(Category entity) Tarih: " + DateTime.Now + " ID: " + entity.ID + "  Kategori Adı: " + entity.CategoryName + " Tüm Kategoriler Bu Şekilde Silinemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult("Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult Delete(Category entity, int categoryid)
        {
            try
            {
                var result = categoryDAL.Delete(entity,categoryid);
                if (result)
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: CategoryManager>EntityResult Delete(Category entity, int categoryid) Tarih: " + DateTime.Now + " ID: " + categoryid + "  Kategori Adı: " + entity.CategoryName + " Kategorisi Silindi", LogType.Delete);
                    return new EntityResult("Success");
                }
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: CategoryManager>EntityResult Delete(Category entity, int categoryid) Tarih: " + DateTime.Now + " ID: " + categoryid + "  Kategori Adı: " + entity.CategoryName + " Kategorisi Silinemedi, Warning", LogType.Warning);
                    return new EntityResult("Warning", EntityResultType.Warning);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: CategoryManager>EntityResult Delete(Category entity, int categoryid) Tarih: " + DateTime.Now + " ID: " + categoryid + "  Kategori Adı: " + entity.CategoryName + " Kategorisi Silinemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult("Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult Delete(int categoryid)
        {
            try
            {
                var result = categoryDAL.Delete(categoryid);
                if (result)
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: CategoryManager>EntityResult Delete(int categoryid) Tarih: " + DateTime.Now + " Oyun ID: " + categoryid + " Olan Kategori Silindi", LogType.Delete);
                    return new EntityResult("Success");
                }
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: CategoryManager>EntityResult Delete(int categoryid)  Tarih: " + DateTime.Now + " Oyun ID: " + categoryid + " Olan Kategori Silinemedi, Warning", LogType.Warning);
                    return new EntityResult("Warning", EntityResultType.Warning);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: CategoryManager>EntityResult Delete(int categoryid)  Tarih: " + DateTime.Now + " ID: " + categoryid + " Olan Kategori Silinemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult("Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult<IEnumerable<Category>> Get()
        {
            try
            {
                var result = categoryDAL.Get();
                if (result != null && result.Count() > 0)
                    return new EntityResult<IEnumerable<Category>>(result, "Success");
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: CategoryManager>EntityResult<IEnumerable<Category>> Get() Tarih: " + DateTime.Now + " Kategori Çekilemedi, NotFound ", LogType.Notfound);
                    return new EntityResult<IEnumerable<Category>>(null, "Not Found", EntityResultType.Notfound);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: CategoryManager>EntityResult<IEnumerable<Category>> Get() Tarih: " + DateTime.Now + " Kategori Çekilemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult<IEnumerable<Category>>(null,"Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult<Category> Get(int id)
        {
            try
            {
                var result = categoryDAL.Get(id);
                if (result != null)
                    return new EntityResult<Category>(result, "Success");
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: CategoryManager>EntityResult<Category> Get(int id) Tarih: " + DateTime.Now + " ID: " + id + " Olan Kategori Çekilemedi, NotFound ", LogType.Notfound);
                    return new EntityResult<Category>(null, "Not Found", EntityResultType.Notfound);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: CategoryManager>EntityResult<Category> Get(int id) Tarih: " + DateTime.Now + " ID: " + id + " Olan Kategori Çekilemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult<Category>(null, "Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult<Category> GetActive(int id)
        {
            try
            {
                var result = categoryDAL.GetActive(id);
                if (result != null)
                    return new EntityResult<Category>(result, "Success");
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: CategoryManager>EntityResult<Category> GetActive(int id) Tarih: " + DateTime.Now + " ID: " + id + " Olan Kategori Çekilemedi, NotFound ", LogType.Notfound);
                    return new EntityResult<Category>(null, "Not Found", EntityResultType.Notfound);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: CategoryManager>EntityResult<Category> GetActive(int id) Tarih: " + DateTime.Now + " ID: " + id + " Olan Kategori Çekilemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult<Category>(null, "Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult<IEnumerable<Category>> GetAllActive()
        {
            try
            {
                var result = categoryDAL.GetAllActive();
                if (result != null && result.Count() > 0)
                    return new EntityResult<IEnumerable<Category>>(result, "Success");
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: CategoryManager>EntityResult<IEnumerable<Category>> GetAllActive() Tarih: " + DateTime.Now + " Kategori Çekilemedi, NotFound ", LogType.Notfound);
                    return new EntityResult<IEnumerable<Category>>(null, "Not Found", EntityResultType.Notfound);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: CategoryManager>EntityResult<IEnumerable<Category>> GetAllActive() Tarih: " + DateTime.Now + " Kategori Çekilemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult<IEnumerable<Category>>(null, "Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult<IEnumerable<CategoryDTO>> GetAllActiveAndCartUserId(int userId)
        {
            try
            {
                var result = categoryDAL.GetAllActiveAndCartUserId(userId).ToList();
                if (result != null && result.Count() > 0)
                    return new EntityResult<IEnumerable<CategoryDTO>>(result, "Success");
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: CategoryManager>EntityResult<IEnumerable<CategoryDTO>> GetAllActiveAndCartUserId(int userId) Tarih: " + DateTime.Now + " Kategori Çekilemedi, NotFound ", LogType.Notfound);
                    return new EntityResult<IEnumerable<CategoryDTO>>(null, "Not Found", EntityResultType.Notfound);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: CategoryManager>EntityResult<IEnumerable<CategoryDTO>> GetAllActiveAndCartUserId(int userId) Tarih: " + DateTime.Now + " Kategori Çekilemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult<IEnumerable<CategoryDTO>>(null, "Error: " + ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult Update(Category entity)
        {
            try
            {
                var result = categoryDAL.Update(entity);
                if (result)
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: CategoryManager>EntityResult Update(Category entity) Tarih: " + DateTime.Now + " ID: " + entity.ID + "  Kategori Adı: " + entity.CategoryName + " Tüm Kategoriler Bu Şekilde Güncellendi", LogType.Update);
                    return new EntityResult("Success");
                }
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: CategoryManager>EntityResult Update(Category entity) Tarih: " + DateTime.Now + " ID: " + entity.ID + "  Kategori Adı: " + entity.CategoryName + " Tüm Kategoriler Bu Şekilde Güncellenemedi, Non Validation", LogType.NonValidation);
                    return new EntityResult("Non Validation", EntityResultType.NonValidation);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: CategoryManager>EntityResult Update(Category entity) Tarih: " + DateTime.Now + " ID: " + entity.ID + "  Kategori Adı: " + entity.CategoryName + " Tüm Kategoriler Bu Şekilde Güncellenemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult("Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult Update(Category entity, int categoryid)
        {
            try
            {
                var result = categoryDAL.Update(entity,categoryid);
                if (result)
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: CategoryManager>EntityResult Update(Category entity, int categoryid) Tarih: " + DateTime.Now + " ID: " + categoryid + "  Kategori Adı: " + entity.CategoryName + " Kategorisi Güncellendi", LogType.Update);
                    return new EntityResult("Success");
                }
                else
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: CategoryManager>EntityResult Update(Category entity, int categoryid) Tarih: " + DateTime.Now + " ID: " + categoryid + "  Kategori Adı: " + entity.CategoryName + " Kategorisi Güncellenemedi, Non Validation", LogType.NonValidation);
                    return new EntityResult("Non Validation", EntityResultType.NonValidation);
                }
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: CategoryManager>EntityResult Update(Category entity, int categoryid) Tarih: " + DateTime.Now + " ID: " + categoryid + "  Kategori Adı: " + entity.CategoryName + " Kategorisi Güncellenemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult("Error: "+ex.ToInnest().Message, EntityResultType.Error);
            }
        }
    }
}
