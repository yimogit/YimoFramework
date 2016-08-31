# 日志记录
log4net：是Apache log4j框架在Microsoft .NET平台的实现，是一个帮助程序员将日志信息输出到各种目标（控制台、文件、数据库等）的工具

FileLogger：用于纯文本日志写入

## 一、log4net

log4net的配置(Config/log4net.config)中包含4中实现：根据需要启用（取消root节点中的注释）

已配置项：

1. 文件形式记录日志（含错误日志），错误日志

2. 控制台输出

3. 数据库保存（启用需要创建日志表[见config/log4net.config]）

4. 邮件发送（启用需要配置邮箱）

使用步骤：

1. 为Log4netLogger.cs所做类库添加log4net引用

2. 在使用log4net的主输出项目中的web.config中配置自定义节：

`<configSections><section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler,log4net"/></configSections>`   
指定configSource的文件为节点配置：`<log4net configSource="Config\log4net.config" />`

3. 新增并配置configSource指定的log4net.config（打开失败修改属性为始终复制）

参考链接：
-------------------------------
>http://www.cnblogs.com/wolf-sun/p/3347373.html

>http://blog.csdn.net/yenange/article/details/19559931

## 二、FileLogger
异步写入文本日志

## 三、Nlog

使用方法和log4net一毛一样，只是配置方式有所变化，依葫芦画瓢即可，根据rules>logger的writeTo属性对应找到target的name

已配置项：

1. 文件形式记录日志（含错误日志），错误日志

2. 控制台输出

3. 数据库保存（启用需要创建日志表[见config/log4net.config]）

4. 邮件发送（启用需要配置邮箱）

参考链接：
-------------------------------

>http://www.cnblogs.com/Gyoung/archive/2012/10/18/2729613.html

>https://github.com/nlog/nlog/wiki

## 备注

* 在实例化的时候启动`log4net.Config.XmlConfigurator.Configure();`，则只需要在Logger.Core类库中添加对log4net的引用即可
* 使用`log4net.LogManager.GetLogger("")`获取log4net对象
* appender>layout>header中换行(\r\n)：&#13;&#10;
* 使用filter节点过滤不同等级的日志，做不同的处理，如给ERROR级别的日志发送邮件~
* 若打开log4net.config失败则修改其属性为【始终复制】

# End
最开始的时候看着log4net.config是一脸懵比的，一个参数一个参数修改看修改，折腾折腾着就这样了