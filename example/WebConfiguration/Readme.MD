# 自定义配置节

1. 在configuration>configSections>section定义自定义节 name="节点名称" ,type="节点对应类, 程序集名称" 

2. 添加YFKConfig节点定义节点，可使用configSource属性将配置节点提取到其他文件

    `
    <YFKConfig configSource="Config\YFK.config" />
    `

3. 利用分部类来暴露配置的属性
