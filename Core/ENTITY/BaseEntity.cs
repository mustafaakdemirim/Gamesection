using System;
namespace Core.ENTITY
{
    public interface IBASEENTITY
    {

    }
    public class BaseEntity:IBASEENTITY
    {
        public BaseEntity()
        {
            Active = true;
            Deleted = false;
            Created = DateTime.Now;
            Updated = DateTime.Now;
        }
        public int ID { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

    }
}
