# MVP DEMO

This is a very simple demo designed to illustrate the MVP (model-view-presenter) pattern implementation in 
ASP.NET WebForms. Additionally, it illustrates potential portability of the presenter by implementing a WPF 
client using the same presenter.

This demo also demonstrates the power of IoC/DI, unit testing, and strives to abide by SOLID design principles.

This solution was initially developed with Ninject dependency container, which can be seen on the "ninjectDI" branch, 
but due to certain requirements, it has been refactored to implemented Unity container instead, which can be 
seen on the "master" branch. The "ninjectDI" branch has not been updated thoroughly and lacks the techniques
found in the "master" branch.

This demo is based on a solution created by Dino Esposito, heavily modified and expanded to highlight various 
concepts in a "brown-bag session" type of presentation. Certain implementation decisions are explained
throughout the presentation, and may not be clear from source code alone. Remember, this is a demo designed
to explain various concepts, and not exactly serve as basis of ideal system architecture.

## Overview

The demo implements a simple stock quote application. It piggybacks on Yahoo Finance and Google Finance to pull stock
data. The solution can quickly alternate between either one of the two quote providers with a simple change to 
dependency type registration. The "master" branch implements both a service class and Web API service that 
can be similarly alternated with IoC. MvpDemo.Infrastructure.CoreDependencyExtension and 
MvpDemo.Infrastructure.DataDependencyExtension encapsulate type registrations shared between the desktop and 
web clients.

To demo portability of the presenters, the WPF client implements the exact same presenters used by the WebForms app.
Navigator class is injected with either SiteNavigationRouteStrategy or DesktopNavigationRouteStrategy depending
on the platform to provide a platform agnostic navigation mechanism between views.

To keep the demo simple and focused, no cross-cutting concerns like validation, security, or logging are considered.

## master Branch Key Tech Stack

* C#
* ASP.NET WebForms
* WPF
* ASP.NET Web API
* Unity
* Unity.WebForms (and WebActivatorEx)
* MSTest
* NSubstitute
* Newtownsoft.Json
* RichardShalay.MockHttp

## ninjectDI Branch Key Tech Stack

* C#
* ASP.NET WebForms
* WPF
* Ninject
* MSTest
* NSubstitute
* Newtownsoft.Json