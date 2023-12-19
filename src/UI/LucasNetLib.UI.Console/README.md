# Generic Host
在 .NET 中，Generic Host（泛型主机）是用于构建可承载各种类型应用程序的通用主机环境。它是基于 Microsoft.Extensions.Hosting 命名空间下的 IHostBuilder 接口和相关组件构建的。

Generic Host 提供了一种通用的方式来启动和管理应用程序的生命周期、配置应用程序的依赖关系和服务、处理应用程序的配置等。它适用于构建不同类型的应用程序，如控制台应用程序、Web 应用程序、Windows 服务等。

使用 Generic Host，你可以在应用程序的入口点创建一个 HostBuilder 实例，并通过链式调用一系列方法来配置主机环境

A host is an object that encapsulates an app's resources and lifetime functionality, such as:

Dependency injection (DI)
Logging
Configuration
App shutdown
IHostedService implementations

# Micosoft.Extensions.Host

+ Microsoft.ExtensionsConfiguration.8.0.0
+ Microsoft.Extensions.Configuration.Abstractions.8.0.0
+ Microsoft.Extensions.Configuration.Binder.8.0.0
+ Microsoft.Extensions.Configuration.Commandline.8.0.0
+ MicrosofExtensionsConfiaurationEnvironmentVariables8.0.0
+ Microsoft.Extensions.Configuration.FileExtensions.8.0.0
+ Microsoft.Extensions.Configuration.Json.8.0.0
+ Microsoft.Extensions.Configuration.UserSecrets.8.0.0
+ Microsoft.Extensions.Dependencylniection.8.0.0
+ Microsoft.Extensions.Dependencylnjection,Abstractions.8.0.0
+ Microsoft.Extensions.Diaanostics.8.0.0
+ MicrosoftExtensions.DiaanosticsAbstractions8.0.0
+ Microsoft.Extensions.FileProviders.Abstractions.8.0.0
+ icrosoftExtensionsFileprovidersphysical.8.0.0
+ Microsoft.Extensions.FileSystemGlobbing.8.0.0
+ Microsoft.Extensions.Hosting.8.0.0
+ MicrosoftExtensions.Hosting.Abstractions.8.0.0
+ Microsoft.Extensions,Logging.8.0.0
+ Microsoft.ExtensionsLogging.Abstractions.8.0.0
+ Microsoft.Extensions.Logging.Configuration.8.0.0
+ Microsoft.Extensions.Logging.Console.8.0.0
+ Microsoft.Extensions.Logging.Debug.8.0.0
+ Microsoft.Extensions.Logging.EventLog.8.0.0
+ Microsoft.Extensions.Logging.EventSource.8.0.0
+ Microsoft.Extensions.Options.8.0.0
+ Microsoft.Extensions.Options.ConfiqurationExtensions.8.0.0
+ MicrosoftExtensionsPrimitives.8.0.0
+ System,Diagnostics.DiagnosticSource.8.0.0
+ System.Diagnostics.EventLog.8.0.0System.Text.Encodings.Web.8.0.0System.TextJson.8.0.0