# TSBAutomationExam

This is the Automation Test Suite based from the Test Automation task as part of the application for the Automation Analyst role.

## Test Scenarios:

Using the TradeMe Sandbox web site, write automation code which does the following:

1. Check there is at least one listing in the TradeMe UsedCars category.
2. Check that the make ‘Kia’ exists.
3. Query any existing Used Car listing and confirm that the following details are shown for that car:
- Number plate
- Kilometres
- Body
- Seats
- Fuel type
- Engine
- Transmission
- History
- Registration expires
- WoF expires
- Model detail

# Getting Started

These instructions will get you a copy of the project up and running on your local machine for testing purposes.


## Prerequisites

What things you need to install first:

- [Visual Studio 2017 (can be Community Version)](https://visualstudio.microsoft.com/vs/older-downloads/)
- [.NET Core 2.1 for VS 2017](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-2.1.520-windows-x64-installer) - *[Refer here for the specfics versions](https://dotnet.microsoft.com/download/visual-studio-sdks)*
- [Google Chrome v88 and up](https://www.google.com/chrome/) NOTE: This Automation Suite is configured to run only on Chrome Browser in the meantime.
- [Git](https://git-scm.com/downloads)


## Running the tests

Upon setting up of the necessary requirements, we can now proceed on running the Automation Suite.

### Step-by-step guide

#### Run via Visual Studio IDE
1. Clone the repo from Github to you local machine
2. Launch Visual Studio 2017
3. Open the Project/Solution from the cloned repository
4. Build the Project
5. Navigate thru the Test Explorer Window
6. Click "Run All" button
7. Wait until the automation run is completed.
8. Verify results through the output, or thru the /TestResults folder with FileName ExtentReport.html

#### Run via Visual Studio IDE
1. Clone the repo from Github to you local machine
2. Open a CLI (Command Prompt)
3. Navigate to the cloned project directory
4. Run the Command "dotnet test"
5. Wait until the automation run is completed.
6. Verify results through the output, or thru the /TestResults folder with FileName ExtentReport.html

## Authors

* **Robert Cecil Vibora** - [TSBAutomationExam](https://github.com/sephiroh/TSBAutomationExam)
