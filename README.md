# Mini Notification Gateway

## Overview

Mini Notification Gateway is a simple notification sending system
developed using C# and .NET 9.

The project demonstrates the usage of:

-   Dependency Injection
-   Interface-based programming
-   SOLID principles
-   Design Patterns

The system supports multiple notification providers and automatically
switches to another provider when the current provider fails.

------------------------------------------------------------------------

# Project Flow

    Create Notification

            ↓

    Select Available Provider

            ↓

    Send Notification

            ↓

    If Failed

            ↓

    Try Next Provider

            ↓

    Log Result

------------------------------------------------------------------------

# Main Components

## INotificationProvider

This interface defines the contract for notification providers.

Implemented providers:

    NotificationProviderA
    NotificationProviderB
    NotificationProviderC

Each provider contains its own sending behavior.

Structure:

    INotificationProvider

              |
     ----------------------
     |          |          |
    ProviderA ProviderB ProviderC

------------------------------------------------------------------------

## NotificationSender

`NotificationSender` controls the notification sending process.

Responsibilities:

-   Receiving available providers
-   Trying providers one by one
-   Handling provider failures
-   Logging sending results

It works with:

    IEnumerable<INotificationProvider>

instead of depending on a concrete provider.

------------------------------------------------------------------------

## Logging System

Logging is implemented using:

    IContentLogger

with:

    ContentLogger

The logger receives events from the sending process and forwards them to
logger providers.

Structure:

    IContentLogger

            |

    ContentLogger

            |

    IContentLoggerProvider

------------------------------------------------------------------------

# Design Patterns Used

## Strategy Pattern

The Strategy Pattern is used for notification providers.

All providers implement:

    INotificationProvider

The sender does not know the internal implementation of providers.

Adding a new provider only requires creating another implementation.

Benefits:

-   Avoids large if/else or switch statements
-   Easy extension
-   Better maintainability

------------------------------------------------------------------------

## Dependency Injection

The project uses .NET Dependency Injection.

Providers and services are registered in `Program.cs`.

Concept:

    NotificationSender

            |

    INotificationProvider

Benefits:

-   Loose coupling
-   Easier testing
-   Cleaner architecture

------------------------------------------------------------------------

## Failover Pattern

The system supports provider failover.

Example:

    ProviderA

        |
        X

    ProviderB

        |
        OK

If one provider fails, the next available provider is selected
automatically.

------------------------------------------------------------------------

# SOLID Principles

## Single Responsibility Principle

Each class has a clear responsibility.

Examples:

-   NotificationSender handles sending workflow
-   Providers handle message sending
-   Logger handles logging

------------------------------------------------------------------------

## Open Closed Principle

New providers can be added without modifying existing sender logic.

Example:

    NotificationProviderD : INotificationProvider

can be added without changing `NotificationSender`.

------------------------------------------------------------------------

## Liskov Substitution Principle

All notification providers implement the same interface and can replace
each other.

------------------------------------------------------------------------

## Interface Segregation Principle

The project uses small focused interfaces:

    INotificationProvider

    INotificationSender

    IContentLogger

------------------------------------------------------------------------

## Dependency Inversion Principle

High-level components depend on abstractions instead of concrete
implementations.

Example:

    NotificationSender

            ↓

    INotificationProvider

------------------------------------------------------------------------

# Technologies

-   C#
-   .NET 9
-   Microsoft Dependency Injection

------------------------------------------------------------------------

# Running

    dotnet run
