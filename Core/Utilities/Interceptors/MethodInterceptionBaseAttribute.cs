using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    //.Class ve :Method diyerek bu Attribute yi sınıf ve metotlara uygulayabilirsin dedik.
    //True diyerek de birden çok kullanılabilir dedik.
    //Inherited edildiğinde de kullanılsın dedik.

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }

}
