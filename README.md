# MVP DEMO

This is a very simple demo designed to illustrate the MVP (model-view-presenter) pattern implementation in 
ASP.NET WebForms. Additionally, it illustrates potential portability of the presenter by implementing a WPF 
client using the same presenter.

This demo also demonstrates the power of IoC/DI, unit testing, and strives to abide by SOLID design principles.

This solution was initially developed with Ninject dependency container, which is on the "master" branch, but due to
certain requirements, it has been refactored to implemented Unity instead, which can be seen on the "unityDI" branch. 
This branch has evolved to include various improvements, and generally serves as a better reference.

This demo is based on a solution created by Dino Esposito, heavily modified and expanded to highlight various 
concepts in a "brown-bag session" type of presentation.

## Overview

The demo implements a simple stock quote application. It piggybacks on Yahoo Finance and Google Finance to pull stock
data. The solution can quickly alternate between either one of the two quote providers with a simple change to 
dependency type registration. The "unityDI" branch also implements both a service class and Web API service that 
can be similarly alternated with IoC.

To keep the demo simple and focused, no cross-cutting concerns like validation, security, or logging are considered.

## master Branch Tech Stack

* C#
* ASP.NET WebForms
* WPF
* Ninject
* MSTest
* NSubstitute
* Newtownsoft.Json

## unityDI Branch Tech Stack

* C#
* ASP.NET WebForms
* WPF
* ASP.NET Web API
* Unity
* MSTest
* NSubstitute
* Newtownsoft.Json
