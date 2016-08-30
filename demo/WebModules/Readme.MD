# 以区域的方式分离模块

## 使用步骤

1. 新增两个mvc项目main,blogs并移除不使用的引用

2. 添加main对core的引用，并在Global.asax添加自定义视图引擎 `ViewEngines.Engines.Add(new ThemableRazorViewEngine());`

3. 在RouteConfig.cs配置模块路由，子模块的路由通过 AreaRegistration来注册。
