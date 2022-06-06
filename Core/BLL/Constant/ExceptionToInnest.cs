using System;
namespace Core.BLL.Constant
{
    public static class ExceptionToInnest
    {
        public static Exception ToInnest(this Exception ex)
        {
            if (ex.InnerException != null)
            {
                return ex.InnerException.ToInnest();
            }
            return ex;
        }
    }
}
