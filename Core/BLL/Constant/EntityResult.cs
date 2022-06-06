using System;
namespace Core.BLL.Constant
{
    public class EntityResult
    {
        public object Message { get; set; }
        public EntityResultType ResultType { get; set; }
        public EntityResult(object Message,EntityResultType resultType=EntityResultType.Success)
        {
            this.Message = Message;
            ResultType = resultType;
        }
    }

    public class EntityResult<T> : EntityResult
    {
        public T Data { get; }

        public EntityResult(T data, object Message,
            EntityResultType resultType = EntityResultType.Success) : base(Message, resultType)
        {
            Data = data;
        }
    }
}
