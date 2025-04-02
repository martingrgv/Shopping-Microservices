# 🛍️ Shopping-Microservices  

A microservices-based e-commerce application with **Product, Basket, Discount, and Ordering** services. It leverages **RabbitMQ, Redis, PostgreSQL, SQLite, SQL Server**, and **YARP API Gateway** for efficient communication and scalability.  

### ⚡ Architecture Overview  

🚀 **Microservices Architecture** – Independent, scalable, and loosely coupled services.  
🔄 **Event-Driven Design** – Services communicate via **RabbitMQ** for reliability.  
🌍 **API Gateway** – **YARP** centralizes requests, improving security and performance.  

### 🏗️ Key Design Patterns  

- 📦 **Repository Pattern** – Clean data access.  
- 🏗️ **Dependency Injection** – Enhances maintainability.  
- 🚨 **Circuit Breaker** – Prevents cascading failures.  
- 📊 **CQRS** – Separates read/write for better performance.  
- ⏳ **Event Sourcing** – Tracks state changes efficiently.  

### 🛠️ Technologies  

🔹 **.NET Core & C#** | 🗄 **PostgreSQL, SQL Server, Redis** | 📨 **RabbitMQ** | 🔀 **YARP**  

### 🚀 Quick Start  

1️⃣ **Clone Repo:** `git clone https://github.com/martingrgv/Shopping-Microservices.git`  
2️⃣ **Navigate:** `cd Shopping-Microservices`  
3️⃣ **Run with Docker:** `docker-compose up`  
4️⃣ **Run Manually:** `dotnet run` in each service  

### 🤝 Contribute  

Fork, improve, and submit a PR! 🚀  

### 📜 License  

🔓 MIT License – Free to use and modify.
