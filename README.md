# Simplified- Microsoft UI Automation

This project uses a Builder Pattern combined with a Fluent Interface to simplify and streamline interaction with UI elements through Microsoft UI Automation (UIA).

✅ Why Fluent & Builder Design?
Working with raw UIA APIs can become verbose and difficult to maintain. To address this, I implemented a pattern that brings:

    👉 Simplified Syntax – Reduces boilerplate by abstracting repetitive search and action logic.

    👉 Fluent Interface – Enables readable, chainable operations for better test clarity.

    👉 Reusability & Modularity – Common actions like Click() and EnterText() are encapsulated as reusable components.

🔨 How It Works
The design includes a UiaSearchEngine class that acts as a builder and search handler. Each method returns the context itself, allowing chained operations that are easy to write and read.

💡 Example:

      👉 UiaSearchEngine.WithAutomationId("submitBtn").WithControlType(ControlType.Button).FindFirst().Click();

🔍 Finder Methods

    👉 FindFirst() – Returns the first matching AutomationElement.

    👉 FindAll() – Returns a collection of matched elements.

✨ Common Actions
The builder supports modular action methods such as:

    👉 Click()

    👉 EnterText(string text)

    👉 IsVisible()

    👉 IsEnabled()

These actions internally use the appropriate control patterns (e.g., InvokePattern, ValuePattern) based on the UI element type.

📌 Benefits

    👉 Clean, expressive test logic

    👉 Centralized automation behavior

    👉 Easy to scale and extend

    👉 Compatible with most UI frameworks supported by UIA (Win32, WPF, WinForms, etc.)
