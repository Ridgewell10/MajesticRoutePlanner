# 🚀 MajesticRoutePlanner

MajesticRoutePlanner is a distributed route planning API built with Clean Architecture, RabbitMQ messaging, Dockerized deployment, and full observability powered by Prometheus and Grafana.

---

## 🧭 Motivation
- ✨ Showcase Clean Architecture using modern C# (.NET 9)
- ⚙️ Handle asynchronous processing with RabbitMQ
- 📈 Provide observability through Prometheus and Grafana
- 🐳 Streamline dev automation using PowerShell and Docker
- 🚀 Support CI/CD workflows via GitHub Actions

---

## 📦 Tech Stack

| Layer            | Tools & Frameworks                              |
|------------------|--------------------------------------------------|
| Backend          | ASP.NET Core (.NET 9), Clean Architecture        |
| Messaging        | RabbitMQ                                         |
| Containerization | Docker & Docker Compose                         |
| Observability    | Prometheus, Grafana                             |
| Testing          | xUnit, dotnet test                              |
| CI/CD            | GitHub Actions                                  |

---

## 🛠 Prerequisites

Install the following before getting started:

- [.NET SDK 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- [Git](https://git-scm.com/)
- (Optional) Visual Studio 2022 or VS Code

---

## ⚙️ Project Setup

### 1️⃣ Clone the Repository

```bash
git clone https://github.com/Ridgewell10/MajesticRoutePlanner.git
cd MajesticRoutePlanner
```

---

### 2️⃣ Prepare Your Environment

Make sure your setup is ready:

- 🐳 **Start Docker Desktop**

- 🧰 **Verify .NET SDK Installation**

  ```bash
  dotnet --version
  ```

  Confirm you're running .NET 9. If not, install it from [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

- 🧹 **(Optional) Clean Docker Cache**

  ```bash
  docker compose down
  docker system prune -f
  ```

---

### 3️⃣ Launch Using PowerShell

Use the automation script to run, verify, and launch services:

```powershell
Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass
.\launch-and-verify.ps1
```

#### 🧠 What the Script Does:

- ✅ Runs unit tests  
- 🧼 Cleans up Docker environment  
- 🛠 Builds containers with `docker compose up -d --build`  
- 🔁 Verifies Swagger, Prometheus, and Grafana endpoints  
- 🌍 Opens dashboards automatically in your browser  

> 🧯 If any service fails, inspect container logs:

```powershell
docker-compose logs majestic-api
docker-compose logs prometheus
docker-compose logs grafana
```

---

## 📊 Dashboards

After launching, access the following services:

- 🔧 [Swagger UI](http://localhost:5050/swagger)
- 📡 [Prometheus](http://localhost:9090)
- 📈 [Grafana](http://localhost:3000)  
  **Login:** `admin / admin`

> ⚠️ Configure Prometheus as a Grafana data source if no panels appear.

---

## 🧪 Testing

Run test suite manually:

```bash
dotnet test MajesticRoutePlanner.Tests/MajesticRoutePlanner.Tests.csproj
```

---

## 📁 Project Structure

```plaintext
MajesticRoutePlanner/
├── MajesticRoutePlanner.sln
├── MajesticRoutePlanner.Api/             # API layer
├── MajesticRoutePlanner.Application/     # Business logic and services
├── MajesticRoutePlanner.Domain/          # Domain models and entities
├── MajesticRoutePlanner.Infrastructure/  # Messaging and data access
├── MajesticRoutePlanner.Tests/           # Unit and integration tests
├── docker-compose.yml
├── prometheus.yml
├── README.md
```

## 🤝 Contributing

We welcome contributions!

1. Fork the repository  
2. Create your feature branch  
   ```bash
   git checkout -b feature/amazing-feature
   ```
3. Commit your changes  
4. Push your branch  
   ```bash
   git push origin feature/amazing-feature
   ```
5. Open a pull request

Please include relevant tests and document your changes.

---

## 📃 License

MIT — free to use, build on, and scale.

---
```

