# Examination System in C#  

## Overview  
This project is a comprehensive examination system built with C# to simulate real-world exam scenarios. It supports multiple exam types, dynamic notifications, and a user-friendly interface for both students and administrators.  

## Features  

### 1. Exam Types  
- Final Exam:  
  - After completion, the system displays:  
    - Pass/Fail status.  
    - Individual grades for each question.  
    - Total grade.  

- Practical Exam:  
  - Provides model answers for questions answered incorrectly, formatted as:  
    - "Question 1: Not Correct. Correct Answer is "True"."  

### 2. Question Types  
- True/False  
- Choose One (Single correct answer)  
- Choose All That Apply (Multiple correct answers)  

### 3. User Roles  
- Admin:  
  - Can start an exam for a specific subject.  
  - Automatically notifies all students registered for that subject using delegates and event handlers.  

- Student:  
  - Can register for multiple subjects.  
  - Receives notifications for exams of their registered subjects.  
  - Can view and select from available exams when notified.  

### 4. Dynamic Notifications  
- When an admin starts an exam, students registered for the subject receive notifications in real-time using Event Handlers.  

### 5. Timed Exams  
- Each exam includes a timer. If the timer runs out:  
  - The exam is terminated.  
  - Stored answers are evaluated.  

### 6. Object-Oriented Design  
- A `User` class serves as the base for:  
  - `Student`  
  - `Admin`  
- The design ensures scalability and reusability.  

### 7. Exam Management  
- Admin logs in, selects a subject and starts an exam type.  
- Students can view:  
  - All ongoing exams they are eligible for (based on subject registration).  
  - Exam details and types.  

## Project Workflow  

1. Admin Login:  
   - Choose a subject.  
   - Select an exam type to start.  

2. Student Interaction:  
   - Automatically notified of ongoing exams for their registered subjects.  
   - Log in and choose the type of exam to attempt.  

3. Exam Attempt:  
   - Questions are presented based on the selected type.  
   - The timer starts at the beginning of the exam.  
   - Answers are stored and evaluated.  

4. Results:  
   - Final Exam: Displays Pass/Fail and grades.  
   - Practical Exam: Displays model answers for incorrect responses.  

## Technologies Used  

- C#  
- OOP Principles  
- Delegates and Events for real-time notifications  

## How to Run  

1. Clone the repository.  
2. Open the solution in Visual Studio.  
3. Build and run the project.  
4. Log in as Admin or Student to test functionality.  
