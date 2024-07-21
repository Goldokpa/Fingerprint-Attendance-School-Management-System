This is a C# .NET-based school attendance and management application. It allows administrators to manage student details and track attendance using CRUD operations. Additionally, the application includes a fingerprint authentication feature for secure login and attendance marking. The application uses XAMPP for the database backend.

## Features

- CRUD Operations: Create, Read, Update, and Delete student details.
- **Fingerprint Authentication**: Secure login and attendance marking using fingerprint recognition.
- **Admin Authentication**: Login system with Admin credentials.
- **User-friendly Interface**: Intuitive and easy-to-use interface for managing student data and attendance records.

## Technologies Used

- C# .NET**: Core programming language for application development.
- XAMPP: Used for managing the MySQL database.
- SecuGen SDK: Used for integrating fingerprint recognition features.
- Windows Forms: Used for the application's graphical user interface.

## Prerequisites

- Visual Studio (or any C# .NET IDE)
- XAMPP
- SecuGen SDK
- MySQL database setup in XAMPP

## Installation and Setup

Step 1: Clone the Repository.
Step 2: Ensure the SecuGen.FDxSDKPro.Windows.dll is referenced in your project and the target architecture is set to x86.

## Usage
-Login: Use the credentials Admin for the username and Adminpass for the password to log in.
-Manage Students: Navigate to the student management section to add, update, or delete student details.
-Fingerprint Registration: Register students' fingerprints for attendance tracking.
-Attendance Tracking: Use the fingerprint scanner to mark attendance.
