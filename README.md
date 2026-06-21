# Mini Notification Gateway

## Overview

Mini Notification Gateway is a simple notification sending system
implemented with C# and .NET 9.

The purpose of this project is to demonstrate software design
principles, SOLID principles, Dependency Injection and Design Patterns
by creating a notification system that supports multiple providers and
automatic failover.

------------------------------------------------------------------------

# Features

-   Create notification messages
-   Send notifications through multiple providers
-   Automatic provider failover
-   Provider abstraction using interfaces
-   Event logging system
-   Message status management
-   Extensible architecture

------------------------------------------------------------------------

# Notification Flow

    Create Message

            ↓

    Select Provider

            ↓

    Send Message

            ↓

    Update Status

            ↓

    Log Result

------------------------------------------------------------------------

# Architecture

The system is based on interface-driven design.

Main components:

## Notification Providers

Interface:

    INotificationProvider

Implementations:

    NotificationProviderA
    NotificationProviderB
    NotificationProviderC

Each provider contains its own sending logic.

------------------------------------------------------------------------

## Notification Sender

Interface:

    INotificationSender

Responsible for:

-   Selecting providers
-   Sending messages
-   Handling provider failures
-   Managing failover process

------------------------------------------------------------------------

## Logging System

Interface:

    IContentLogger

Implementation:

    ContentLogger

The logger records system events such as:

-   MessageCreated
-   ProviderSelected
-   MessageSent
-   MessageFailed
-   ProviderChanged

------------------------------------------------------------------------

# Design Patterns Used

## Strategy Pattern

The Strategy Pattern is used for notification providers.

All providers implement:

    INotificationProvider

Structure:

    INotificationProvider

            |
     -----------------------
     |          |           |
    ProviderA ProviderB ProviderC

The sender works with the interface and does not depend on a specific
provider.

Benefits:

-   Adding new providers without modifying existing code
-   Removing large if/else or switch statements
-   Following Open/Closed Principle

------------------------------------------------------------------------

## Dependency Injection Pattern

Dependency Injection is used to provide required services.

Example:

    NotificationSender
            |
            |
    IEnumerable<INotificationProvider>

Providers and loggers are registered in the .NET DI container.

Benefits:

-   Loose coupling
-   Better testability
-   Easier maintenance

------------------------------------------------------------------------

## Composite Pattern

The logging system uses a composite approach.

Structure:

    IContentLogger

           |
    ContentLogger

           |
    ---------------------
    |                   |
    ConsoleLoggerProvider
    Other Logger Provider

New logging destinations can be added without changing existing code.

------------------------------------------------------------------------

## Failover Pattern

The system automatically switches to another provider when sending
fails.

Example:

    ProviderA

       X Failed

          ↓

    ProviderB

       ✓ Sent

This increases reliability of message delivery.

------------------------------------------------------------------------

# SOLID Principles

## Single Responsibility Principle

Each class has one responsibility.

Example:

-   NotificationSender manages sending workflow
-   ContentLogger manages logging

------------------------------------------------------------------------

## Open Closed Principle

The system is open for extension and closed for modification.

A new provider can be added by implementing:

    INotificationProvider

without changing existing classes.

------------------------------------------------------------------------

## Liskov Substitution Principle

All notification providers implement the same contract and can replace
each other.

------------------------------------------------------------------------

## Interface Segregation Principle

Small focused interfaces are used:

    INotificationProvider

    INotificationSender

    IContentLogger

------------------------------------------------------------------------

## Dependency Inversion Principle

High-level components depend on abstractions instead of concrete
classes.

Example:

Correct:

    NotificationSender
            |
    INotificationProvider

------------------------------------------------------------------------

# Technologies

-   C#
-   .NET 9
-   Dependency Injection
-   SOLID Principles

------------------------------------------------------------------------

# Running The Project

Clone the repository:

    git clone <repository-url>

Run:

    dotnet run

------------------------------------------------------------------------

# UML Diagram

The UML diagram is available in the project documentation.

------------------------------------------------------------------------

# Author

Mini Notification Gateway Project
