# Scheduling Desktop Application

## Introduction
Welcome to my Scheduling Desktop Application project! This is a C# application I've built to handle a variety of business needs, much like those encountered in real-world software development. This application showcases my ability to create robust, functional software solutions and serves as a valuable piece in my portfolio.

This README provides an overview of the project, including its features, requirements, and instructions for setup and usage.

## Table of Contents
- [Introduction](#introduction)
- [Scenario](#scenario)
- [Requirements](#requirements)
- [Features](#features)
- [Setup Instructions](#setup-instructions)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Scenario
I developed this application for a global consulting organization with offices in Phoenix, Arizona; New York, New York; and London, England. The application interacts with a provided MySQL database, pulling data without modifying the database structure. The goal was to create a user-friendly, multilingual application that meets specific business requirements.

## Requirements
The application is built in C# using the .NET Framework and Visual Studio IDE. It includes:
- A login form with location detection and multilingual support.
- Functionality to add, update, and delete customer records.
- Functionality to add, update, and delete appointments.
- A calendar view feature.
- Time zone and daylight saving time adjustments for appointments.
- Alerts for upcoming appointments.
- Report generation capabilities.
- Logging of user login activities.

## Features
### Login Form
- **Location Detection**: Determines the user's location.
- **Multilingual Support**: Translates login and error messages into English and one additional language.
- **Authentication**: Verifies username and password ("test" for both).
![image](https://github.com/LorenzoDOrtiz/Scheduler/assets/7910477/24d4b137-5f44-4a1c-a705-769983d3b978)
### Customer Management
- **Add, Update, Delete**: Manage customer records with name, address, and phone number fields.
- **Validation**: Ensures fields are trimmed, non-empty, and phone numbers allow only digits and dashes.
- **Exception Handling**: Handles errors during add, update, and delete operations.
![image](https://github.com/LorenzoDOrtiz/Scheduler/assets/7910477/79d6fcb7-6803-4a2f-b65e-e5686ed4e4ef)


### Appointment Management
- **Add, Update, Delete**: Manage appointments linked to customer records.
- **Validation**: Ensures appointments are scheduled during business hours (9:00 AM - 5:00 PM, Monday–Friday, EST) and prevents overlapping appointments.
- **Exception Handling**: Handles errors during add, update, and delete operations.
![image](https://github.com/LorenzoDOrtiz/Scheduler/assets/7910477/adb4a2c7-aed5-4ef2-a525-005a50c4ba08)
<br>
![image](https://github.com/LorenzoDOrtiz/Scheduler/assets/7910477/157e36c5-c6cd-46d8-92b4-1afec09b882a)
<br>
![image](https://github.com/LorenzoDOrtiz/Scheduler/assets/7910477/541fc858-2918-4806-8f10-d56ea0dcfb35)
<br>
![image](https://github.com/LorenzoDOrtiz/Scheduler/assets/7910477/7c5c6c4b-aa96-4cd3-bfee-6fc733ee9c3c)



### Calendar View
- **Monthly View**: Displays appointments for selected days in a calendar format.

### Time Adjustments
- **Automatic Adjustments**: Adjusts appointment times based on user time zones and daylight saving time.

### Alerts
- **Appointment Alerts**: Generates alerts for users with appointments within the next 15 minutes upon login.

### Reporting
- **Report Generation**: Generates reports using collection classes and lambda expressions, including:
  - Number of appointment types by month.
  - Schedule for each user.
  - An additional custom report.
![image](https://github.com/LorenzoDOrtiz/Scheduler/assets/7910477/26d7178c-27e7-4b2d-9516-1850ad30ed2a)
### Logging
- **Login History**: Records timestamps and usernames of logins in "Login_History.txt".

## Setup Instructions
1. **Clone the Repository**: 
    ```bash
    git clone https://github.com/yourusername/scheduling-desktop-app.git
    ```
2. **Open in Visual Studio**: 
    - Open the solution file (.sln) in Visual Studio.
3. **Configure Database Connection**: 
    - Update the database connection string in the configuration file.
4. **Run the Application**: 
    - Build and run the application from Visual Studio.

## Usage
1. **Login**: 
    - Use "test" as both username and password.
2. **Customer Management**: 
    - Navigate to the customer management section to add, update, or delete customer records.
3. **Appointment Management**: 
    - Schedule, update, or cancel appointments linked to customer records.
4. **Calendar View**: 
    - View appointments by selecting dates from the calendar.
5. **Generate Reports**: 
    - Access the reports section to generate predefined and custom reports.

## Contributing
I welcome contributions! If you'd like to help improve this project, please follow these steps:
1. Fork the repository.
2. Create a new feature branch.
3. Commit your changes.
4. Push to the branch.
5. Submit a pull request.

## License
This project is licensed under the MIT License. See the LICENSE file for details.

---

Thank you for checking out my Scheduling Desktop Application. If you have any questions or need further assistance, feel free to contact me. Happy coding!
