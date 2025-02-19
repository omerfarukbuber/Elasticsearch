# Elasticsearch Integration with .NET Core  

This repository demonstrates how to integrate **.NET Core** with **Elasticsearch** using the `Elastic.Clients.Elasticsearch` library. It covers both **CRUD operations** and **search functionality** with a repository pattern. The project is **feature-based**, without a layered architecture, and runs **Elasticsearch & Kibana** via Docker.

## 🚀 Features  

- **Elasticsearch Connection:** Uses `Elastic.Clients.Elasticsearch` to interact with Elasticsearch.  
- **Dockerized Setup:** Elasticsearch and Kibana run inside Docker containers.  
- **CRUD Operations:** Full **Create, Read, Update, Delete** support on the `products` index.  
- **Search Functionality:** Searches the `kibana_sample_data_ecommerce` index using a copied entity model.  
- **Feature-Based Architecture:** No strict layering, focusing on modular design.  
- **Repository & Service Pattern:** Clean separation of data access and business logic.  

## 🛠️ Technologies Used  

- **.NET Core**  
- **Elasticsearch**  
- **Kibana**  
- **Docker**  
- **Elastic.Clients.Elasticsearch**  
- **Repository & Service Pattern**  

## 📦 Setup & Installation  

### Prerequisites  

- **Docker** installed on your machine.  
- **.NET Core SDK** (latest version recommended).  

### 1️⃣ Clone the Repository  

```sh  
git clone https://github.com/omerfarukbuber/Elasticsearch.git  
cd Elasticsearch  
```  

### 2️⃣ Start Elasticsearch & Kibana with Docker  

Run the following command to start **Elasticsearch** and **Kibana** containers:  

```sh  
docker-compose up -d  
```  

> **Note:** Ensure that `docker-compose.yml` is correctly configured with the necessary Elasticsearch and Kibana settings.  

### 3️⃣ Run the .NET Core API  

Restore dependencies and start the API:  

```sh  
dotnet restore
cd src/Elasticsearch.API  
dotnet run  
```  

## 🔍 Elasticsearch Indexes  

### `products` Index (CRUD Operations)  

This index is used for **Create, Read, Update, and Delete** operations.  

### `kibana_sample_data_ecommerce` Index (Search Operations)  

- The **entity model** from Kibana's sample index is copied and used for search operations.  
- Search is implemented via a **dedicated repository** in .NET.  

## 📡 API Endpoints

### 🛍️ ECommerce

| Method | Endpoint | Description |
|--------|-------------------------------|---------------------------------|
| `GET`  | `/api/ECommerce/term/customer_first_name/{customerFirstName}` | Get customers by first name (term query). |
| `POST` | `/api/ECommerce/terms/customer_first_name` | Get multiple customers by first name (terms query). |

### 📦 Products

| Method | Endpoint | Description |
|--------|----------------------|-------------------------------|
| `GET`  | `/Products`          | Get all products. |
| `POST` | `/Products`          | Create a new product. |
| `PUT`  | `/Products`          | Update an existing product. |
| `GET`  | `/Products/{id}`     | Get product by ID. |
| `DELETE` | `/Products/{id}`   | Delete product by ID. |

## 📜 License

This project is licensed under the MIT License. Feel free to contribute!

---

🔗 **GitHub Repository**: [Elasticsearch .NET API](https://github.com/omerfarukbuber/Elasticsearch)

