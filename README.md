# Todo List API - Minimal ASP.NET Core

Une API **Todo List** construite avec **ASP.NET Core Minimal API**, pour gérer des tâches avec CRUD complet et mise à jour partielle .  
Cette API inclut la documentation interactive via **Swagger UI** et des tests automatisés avec **xUnit** à venir.
<img width="1366" height="646" alt="Screenshot From 2026-03-01 16-40-01" src="https://github.com/user-attachments/assets/a720cbf9-9d09-4890-91dd-96e50b2f6ce8" />

---

##  Fonctionnalités

- CRUD complet : `GET`, `POST`, `PUT`, `PATCH`, `DELETE`  
- Mise à jour partielle des tâches sans écraser les champs non envoyés  
- Documentation interactive via **Swagger UI**  
- Tests unitaires et d’intégration automatisés (xUnit)  
- Gestion en mémoire des tâches (pour apprentissage)  
- Architecture propre : **Models / DTOs / Services / Repositories / Endpoints**

---

##  Installation

1. Cloner le projet :

```bash
git clone https://github.com/aina-lang/To-Do-List.git
cd To-Do-List

2. Restaurer les packages NuGet :

```bash
dotnet restore

3. Lancer l’API :

```bash
dotnet run
