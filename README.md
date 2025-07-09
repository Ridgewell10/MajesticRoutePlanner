# 🚀 MajesticRoutePlanner

**MajesticRoutePlanner** is a distributed route planning API built with reliability, observability, and scalability in mind. It leverages modern .NET practices, containerized deployment, and full-stack observability via Prometheus and Grafana.


## 📦 Tech Stack

| Layer            | Tools & Frameworks                              |
|------------------|--------------------------------------------------|
| Backend          | ASP.NET Core (.NET 9), Clean Architecture        |
| Messaging        | RabbitMQ (Request & Result Queues)              |
| Containerization | Docker + Docker Compose                         |
| Observability    | Prometheus, Grafana                             |
| Testing          | xUnit, dotnet test                              |
| CI/CD            | GitHub Actions (optional)                       |

---

## 🛠 Prerequisites

Ensure these are installed before starting:

- [.NET SDK 9.0](https://dotnet.microsoft.com/en-us/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- [Git](https://git-scm.com/)
- (Optional) Visual Studio 2022+ or VS Code

---

## ⚙️ Setup Instructions

### 1. Clone the Repository
```bash
git clone https://github.com/Ridgewell10/MajesticRoutePlanner.git
cd MajesticRoutePlanner
