using Autofac;
using Autofac.Features.Indexed;
using Autofac.Integration.Mvc;
using MvcAutofac.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcAutofac.Framework
{
    public class EngineContext
    {
        private static IContainer _container;
        public static void Install(Action<ContainerBuilder> cbAction)
        {
            var builder = new ContainerBuilder();
            cbAction(builder);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            _container = container;
        }
        /// <summary>
        /// 获取使用枚举注册的唯一实例 建议
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static TService ResolveEnum<TService, TEnum>(TEnum t)
            where TService : class
            where TEnum : ValueType
        {
            IIndex<TEnum, TService> iIndex = _container.Resolve<IIndex<TEnum, TService>>();

            return iIndex[t];
        }
        /// <summary>
        /// 获取使用key注册的唯一实例
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TService Resolve<TService>(string key="") where TService : class
        {
            if (string.IsNullOrEmpty(key))
            {
                return _container.Resolve<TService>();
            }
            return _container.ResolveNamed<TService>(key);
        }
        /// <summary>
        /// 获取注册的所有实例
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public TService[] ResolveAll<TService>(string key = "")
        {
            if (string.IsNullOrEmpty(key))
            {
                return _container.Resolve<IEnumerable<TService>>().ToArray();
            }
            return _container.ResolveKeyed<IEnumerable<TService>>(key).ToArray();
        }


    }
}
