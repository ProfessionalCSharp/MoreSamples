# .NET Core Code Samples

> Enjoy the following .NET Core samples

* Project Tye
* Logging to Files
* Dependency Injection
* Dependency Injection with Options
* Configuration
* Dependency Injection with Configuration
* HTTP Client Factory
* Markdown
* Self-contained

## Project Tye

Introducing *Project Tye*.

See the blog article [Project Tye - easier development with .NET for Kubernetes](https://csharp.christiannagel.com/2020/05/11/tye/)

## Logging to Files

This sample shows logging to files using the ILogger interface, and tracesource and Serilog log providers.

See the blog article [Writing ILogger Diagnostics to a File](https://csharp.christiannagel.com/2018/11/13/iloggertofile/).

## Dependency Injection with the Host class

Foder: DependencyInjectionWithHost

This sample offers a simple console project using dependency injection with the Microsoft.Extensions.DependencyInjection framework.

See the blog article [It's all in the Host Class - Dependency Injection with .NET](https://csharp.christiannagel.com/2020/05/15/dependencyinjection-2/) for more information.

## Dependency Injection

> See the newer version: *Dependency Injection with the Host class*

Folder: DependencyInjection

This sample offers a simple console project using dependency injection with the Microsoft.Extensions.DependencyInjection framework.

See the blog article [Dependency Injection with .NET Core](https://csharp.christiannagel.com/2016/06/04/dependencyinjection/ "Dependency Inection") for more information.

The Simple MVVM sample makes use of Microsoft.Extensions.DependencyInjection as well.

The book Professional C# 6 and .NET Core 1.0 offers a bigger example with MVVM and both WPF and UWP applications in the chapter 31, "Patterns with XAML Apps", and in the ASP.NET Core chapters 40 "ASP.NET Core" and 41 "ASP.NET MVC". 

## Dependency Injection with Options

> See the newer version: *Dependency Injection with the Host class*

Folder: DependencyInjectionWithOptions

This sample extends on the Dependency Injection sample to add options for configuration of the injected service.

See the blog article [.NET Core Dependency Injection with Options](https://csharp.christiannagel.com/2016/07/27/diwithoptions/ "DI with Options") for more information.

## Configuration

Folder: ConfigurationSample

This sample shows .NET Core configuration with a simple console application. The book contains configuration information in Chapter 40, ASP.NET Core.

See the blog article [Configuration with .NET Core](https://csharp.christiannagel.com/2016/08/02/netcoreconfiguration/ "Configuration") for more information.

## Dependency Injection with Configuration

Folder: DependencyInjectionWithConfig

This sample extends on the Dependency Injection with Options to instantiate the injected service using JSON configuration.

See the blog article [.NET Core Dependency Injection with Configuration](https://csharp.christiannagel.com/2016/08/16/diwithconfiguration/ "DI with Configuration") for more information.

## HTTP Client Factory

Folder: HttpClientFactory

This sample shows how the HttpClient can be injected using the HTTP Client Factory available with .NET Core 2.1.

See the blog article [HTTP Client Factory](https://csharp.christiannagel.com/2018/06/05/httpclient/ "HTTP Client Factory") for more information.

## Markdown

Folder: MarkdownSample

This sample shows generating HTML from Markdown code using the Markdig Library.

See the blog article [Using Markdown](https://csharp.christiannagel.com/2016/07/03/markdown/ "Using Markdown") for more information.

## Self-Contained application

Folder: SelfContained

This sample shows how to create self-contained .NET Core applications in contrary to portable applications.

See the blog article [Self-Contained .NET Core Applications](https://csharp.christiannagel.com/2016/08/11/selfcontained/ ".NET Core Self-contained") for more information.
