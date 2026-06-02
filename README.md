# Smart Event Management and Ticketing System

![ASP.NET MVC](https://img.shields.io/badge/ASP.NET-MVC-blue)
![MongoDB](https://img.shields.io/badge/Database-MongoDB-green)
![C%23](https://img.shields.io/badge/Language-C%23-purple)
![Status](https://img.shields.io/badge/Status-Completed-success)

## Overview

The Smart Event Management and Ticketing System is a web-based platform designed to streamline the management of cultural and community events. The system enables users to discover events, register as members, reserve tickets, submit reviews, and communicate with event organizers through an integrated inquiry system.

The platform provides different levels of access for guests and registered members, ensuring secure and personalized user experiences while promoting community engagement.

---

## Features

### Guest Features

* Browse upcoming events
* View event details (restricted information only)
* Read event reviews submitted by members
* Send inquiries to event administrators
* Register for membership

### Member Features

* Secure registration and login
* Personalized dashboard
* Browse and search events
* Filter events by category
* Book tickets with seat type and quantity selection
* View booking history
* Submit event reviews and ratings
* Send inquiries and support requests

### Administrative Benefits

* Centralized event management
* Digital ticket reservation tracking
* Community feedback collection
* Improved audience engagement
* Scalable architecture for future enhancements

---

## Technology Stack

### Frontend

* ASP.NET MVC
* Razor Views
* Bootstrap
* HTML5
* CSS3
* JavaScript

### Backend

* C#
* ASP.NET MVC Framework

### Database

* MongoDB Atlas
* MongoDB Compass

### Design & Modeling Tools

* Oracle SQL Developer Data Modeler
* Entity Relationship Diagrams (ERD)

---

## System Architecture

The system is designed around the following core entities:

* Member
* Event
* Venue
* Booking
* Review
* Inquiry

### Relationships

* One Venue can host multiple Events.
* One Member can create multiple Bookings.
* One Event can have multiple Bookings.
* One Event can receive multiple Reviews.
* Guests can submit Inquiries without booking privileges.

---

## Database Collections

### Members

Stores user profiles and preferences.

### Events

Stores event information including:

* Event name
* Category
* Date
* Price
* Status

### Venues

Stores venue details including:

* Name
* Address
* Capacity

### Bookings

Stores ticket reservations including:

* Member ID
* Event ID
* Seat type
* Quantity
* Booking date

### Reviews

Stores user feedback and ratings.

### Inquiries

Stores messages submitted by users.

---

## Key Functionalities

### User Authentication

Secure registration and login system for members.

### Event Discovery

Users can search and browse events by:

* Category
* Date
* Availability

### Ticket Reservation

Members can:

* Select seat types
* Choose ticket quantities
* Confirm bookings

### Booking History

Members can view previously reserved tickets and booking details.

### Review System

Members can submit ratings and feedback after attending events.

### Inquiry Management

Users can send questions and support requests directly through the platform.

---

## Testing

The system was tested across all major functional modules, including:

* User Registration
* Member Login
* Dynamic Navigation
* Event Booking
* Booking History
* Inquiry Submission

All tested features successfully passed validation and database verification checks.

---

## Future Improvements

Potential enhancements include:

* Online payment gateway integration
* Email notifications
* SMS alerts
* Event recommendation engine
* QR code ticket generation
* Admin management dashboard
* Advanced analytics and reporting

---

## Installation

### Prerequisites

* Visual Studio 2022 or later
* .NET Framework / ASP.NET MVC
* MongoDB Atlas Account
* MongoDB Compass

### Setup

1. Clone the repository

```bash
git clone https://github.com/your-username/smart-event-management-system.git
```

2. Open the solution in Visual Studio.

3. Configure the MongoDB connection string.

4. Restore NuGet packages.

5. Build and run the application.

---

## Project Screenshots

Add screenshots of:

* Home Page
* Login Page
* Registration Page
* Member Dashboard
* Event Booking Page
* Booking History
* Inquiry Module
* Review System

---

## Author

Developed as a full-stack web application demonstrating event management, ticket reservation, user authentication, and MongoDB integration using ASP.NET MVC.
