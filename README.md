# Тема
Автоматизация процессов продажи одежды

Описание предметной области
---
Данный проект предназначен для автоматизации покупок у клиентов магазина одежды. 
В проекте присутствует база данных состоящая из следующих таблиц:
 - TClient - таблица, хрянящаяя в себе данные о клиентах;
 - TThing - таблица, хрянящаяя в себе данные о вещах, которые есть в наличии;
 - TCart - таблица, хрянящаяя в себе данные о корзинах пользователей;
 - TOrder - таблица, хрянящаяя в себе данные о заказах пользователей;
 - TAccommodation - таблица, хрянящаяя в себе данные о размещениях вещей на складе;
 - TStorage - таблица, хрянящаяя в себе данные о складах;

Бизнес домен
---
Ретейл одежды

Автор
---
Монашов Николай Егорович студент группы ИП 20-3


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
    Client ||--o{ Cart: is
    Client ||--o{ Order: is

  BaseAuditEntity {
        Guid ID
        DateTimeOffset CreatedAt
        string CreatedBy
        DateTimeOffset UpdatedAt
        string UpdatedBy
        DateTimeOffset DeleteddAt
  }
