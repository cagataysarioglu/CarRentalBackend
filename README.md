# Car Rental
A car rental application with API connection consisting of special layers for transactions.

Introduction

        This is an automation project where you can manage your car rental operations. Still working on 
    this project. It is a fast software development infrastructure suitable for modular PnP (Plug and Play)
    architecture, focusing on SOLID principles and Clean Code methods.

Latest Updates

    18 February 2021;
        Autofac, Autofac.Extensions.DependencyInjection, Autofac.Extras.DynamicProxy are added to project.
        AOP and IoC container structures are now used in the project.
        FluentValidation is added. Validation processes will now be performed with the help of FluentValidation.
        Business layer has been updated. Added attributes instead of conditions.
        Codes have been refactored according to Autofac and FluentValidation.
        Some bugs are fixed.
        Tested via Postman after refactoring.

    16 February 2021;
        WebAPI layer is added. Set WebAPI as startup project for testing.
        CRUD Operations is added to WebAPI/Controllers layer.
        Detail operations have been updated.
        Singletons are added to Startup.cs
        RentalDetailDto entity and its operations has been updated.
        Some bugs fixed.
        Tested via Postman.

Installation

    Autofac v6.1.0 package must be added to the following layers via NuGet.
        - Business
        - Core

    Autofac.Extensions.DependencyInjection v7.1.0 package must be added to the following layers.
        - Core
        - WebAPI

    Autofac.Extras.DynamicProxy v6.0.0" package must be added to the following layers.
        - Business
        - Core

    Microsoft.EntityFrameworkCore v3.1.11 package must be added to the following layers.
        - DataAccess

    Microsoft.EntityFrameworkCore.SqlServer v3.1.11 package must be added to the following layers.
        - Core
        - DataAccess

Layers

    Business
    Core
    DataAccess
    Entities
    ConsoleUI
    WebAPI
