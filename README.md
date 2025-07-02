# GeideaTests - UI Automation Framework

This project contains UI automation test cases for the OrangeHRM demo website (https://opensource-demo.orangehrmlive.com/), built using Selenium WebDriver, C#, and NUnit.

## Objective

Automate the following test cases with a clean, maintainable, and scalable framework using the Page Object Model (POM) and Data-Driven Testing (DDT).

## Test Cases Implemented

### TC1: Login Verification
- Open the login page.
- Log in with default credentials.
- Assert that login is successful.
- Test is data-driven using CSV input.

### TC2: Admin Filter Verification
- Navigate to the Admin section.
- Filter users by the User Role: Admin.
- Assert that all displayed users have the role Admin.
- Test is data-driven using CSV input.

## Tech Stack

- Language: C#
- Automation: Selenium WebDriver
- Test Framework: NUnit
- Data Source: CSV files (via CsvHelper)
- Design Pattern: Page Object Model (POM)

## Project Structure

GeideaTests/
├── Drivers/ WebDriver setup
├── Pages/ Page objects for UI interaction
├── Tests/ NUnit test classes
├── Utilities/ CSV reader and data models
├── TestData/ Input CSVs for data-driven tests
├── GeideaTests.csproj

## Installation and Setup

1. Install the latest .NET SDK from https://dotnet.microsoft.com/download
2. Clone this repository:
    ```bash
    git clone https://github.com/IslaamSabbah/GeideaTests.git
    cd GeideaTests
3. Restore dependencies:
    dotnet restore
4. Build the project:
    dotnet build

Author
Islam Sabbah
