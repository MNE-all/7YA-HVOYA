
## Схема базы данных
```mermaid
erDiagram

    Client {
        Guid Id
        string Surname
        string Name
        string Patronymic
        string Email
        string Phone
        Enum Gender
        DateTime Birthday
        string Password
    }
    
    Thing {
        Guid Id
        Enum Category
        Enum Gender
        Enum Season
        Enum Size
        decimal Price
    }
    
    Storage {
        Guid Id
        string Name
        string Address
    }
    
    Accommodation {
        Guid Id
        Guid StorageId
        Guid ThingId
        string Amount
    }

    Cart {
        Guid Id
        Guid ClientId
        Guid ThingId
        string Amount
    }

     Order {
        Guid Id
        int Number
        Guid ClientId
        Guid ThingId
        string Amount
    }
    Storage ||--o{ Accommodation: is
    Thing ||--o{ Accommodation: is
    Thing ||--o{ Order: is
    Thing ||--o{ Cart: is
    CLient ||--o{ Cart: is
    CLient ||--o{ Order: is

  BaseAuditEntity {
        Guid ID
        DateTimeOffset CreatedAt
        string CreatedBy
        DateTimeOffset UpdatedAt
        string UpdatedBy
        DateTimeOffset DeleteddAt
  }
