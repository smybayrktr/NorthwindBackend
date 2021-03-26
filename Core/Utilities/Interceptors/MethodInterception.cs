using Castle.DynamicProxy;
using System;

namespace Core.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation) //Çalıştırmak istediğim metot.
        {
            var isSuccess = true;
            OnBefore(invocation); //Methodun başında çalışır
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)  
            {
                isSuccess = false;
                OnException(invocation, e); //Hata alınca çalışır
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);  //Başarılı olunca çalışır
                }
            }
            OnAfter(invocation); //Metottan sonra çalıır
        }
    }
}
