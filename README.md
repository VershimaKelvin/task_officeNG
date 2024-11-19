
# **Sauce Labs Playwright Tests**

Automated end-to-end tests for the [Sauce Labs Sample Application](https://www.saucedemo.com/) using [Playwright](https://playwright.dev/) and NUnit.

---

## **Table of Contents**
- [Overview](#overview)
- [Features](#features)
- [Setup](#setup)
- [Running Tests](#running-tests)
- [Test Scenarios](#test-scenarios)
- [Technologies Used](#technologies-used)

---

## **Overview**

This repository contains Playwright tests for automating common user actions on the Sauce Labs Sample Application. The tests cover scenarios such as user login, adding products to the cart, and completing a checkout process.

---

## **Features**
- **Cross-browser Testing**: Supports Chromium, Firefox, and WebKit.
- **Incognito Mode**: Tests run in isolated browser sessions.
- **Assertions**: Verifies critical application behaviors (e.g., URL navigation, element visibility, and cart updates).
- **NUnit Integration**: Organized test cases with NUnit framework.

---

## **Setup**

### **Prerequisites**
1. [.NET SDK](https://dotnet.microsoft.com/) (6.0 or later).
2. [Node.js](https://nodejs.org/) (optional for managing dependencies).
3. Internet connection for downloading Playwright binaries.

### **Installation**
1. Clone the repository:
   ```bash
   git clone https://github.com/vershimakelvin/*****.git
   cd sauce-labs-playwright-tests
2. Restore dependencies
   ```bash
   dotnet restore
3. Install Playwright
   ```bash
   dotnet tool install --global Microsoft.Playwright.CLI
   playwright install

  
## **Running Tests with Visual Studio Test Explorer**

Visual Studio provides a convenient interface for running and managing tests through the Test Explorer. Follow these steps to execute your tests:

---

### **Steps to Run Tests**

1. **Open the Solution in Visual Studio**  
   - Launch Visual Studio and open the `.sln` file for your project.

2. **Restore Dependencies**  
   - Ensure all project dependencies are restored:
     ```bash
     dotnet restore
     ```
   - Alternatively, use the "Restore NuGet Packages" option in Visual Studio (right-click the solution in the Solution Explorer and select the option).

3. **Build the Solution**  
   - Build the project to ensure there are no compilation errors:
     - Use the shortcut `Ctrl+Shift+B` or select "Build Solution" from the Build menu.

4. **Open Test Explorer**  
   - Navigate to the **Test Explorer**:
     - Go to `Test` > `Windows` > `Test Explorer` from the top menu.
     - Alternatively, press `Ctrl+E, T`.

5. **Run All Tests**  
   - In the Test Explorer, click **Run All** to execute all the tests in the repository.

6. **View Test Results**  
   - After the tests run, Visual Studio will display the results in the Test Explorer:
     - Green checkmarks indicate passing tests.
     - Red icons signify failing tests.

# **Test Scenarios**

## **Current Test Cases**

### **Login Functionality**
- Navigate to the application.
- Verify successful login with valid credentials.

### **Add to Cart**
- Select a product.
- Verify it appears in the cart.

### **Checkout Process**
- Complete checkout and verify order confirmation.


## **Technologies Used**
- **Playwright**: For browser automation.
- **NUnit**: Test framework for structuring and running tests.
- **C#**: Programming language used for tests.
- **Sauce Labs Sample Application**: Test application for automation.
