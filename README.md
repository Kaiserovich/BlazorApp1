# BlazorOrders

## Web-app “Customer and Order Management”

The application is developed using AspNetCore 6 and Blazor Server. Data storage MS SQL Server 2019, ORM Entity Framework Core 7. Data access is implemented using "Repository" pattern

Client part implements CRUD logic for the entities customers and orders, validation of entered data. Registration and authorization of users, data filtering are implemented.

## Веб-приложение “**Управление клиентами и заказами”**

Приложение разработано с использованием AspNetCore 6 и Blazor Server. Хранение данных MS SQL Server 2019, ORM Entity Framework Core 7. Доступ к данным реализован с помощью паттерна “Репозиторий”

Клиентская часть реализует CRUD логику для сущностей клиенты и заказы, валидацию вводимых данных. Реализована регистрация и авторизация пользователей, фильтрация данных.

Модель данных

- Clients (содержит поля ID, Name, DateCreate, Status) – клиенты, таблица содержит данные о клиентах, дате создания клиента, статусе клиента (потенциальный, активный, не активный)
- Orders (содержит поля ID, Client_ID – внешний ключ для таблицы клиентов, Decsription, Date, Price, Status, Currency) – заказы, таблица содержит данные о заказах клиента, обязательные поля ссылка на клиента, описание заказа, дата заказа, стоимость, статус заказа (новый, выполнен), валюта.

### Бизнес-логика:

Заказы могут создаваться только для клиентов в статусе активный.

При создании заказа ему автоматически присваивается статус Новый.

Перевод в статус Выполнен в ручном режиме.

Удаление заказа доступно только в статусе Новый.

Изменение статуса клиента: при добавлении – Потенциальный, перевод в статус Активный в ручном режиме, перевод в статус Не Активный только для клиентов без заказов в статусе Новый.

Удаление клиента доступно только при отсутствии заказов.

![image](https://user-images.githubusercontent.com/31707173/228570510-488d690c-05ed-407e-be30-d51d19ebd621.png)
![image](https://user-images.githubusercontent.com/31707173/228570674-f582b38d-be79-4563-9b08-98a927964da9.png)
![image](https://user-images.githubusercontent.com/31707173/228570712-f176ee30-d9f1-43f4-a0bb-1ee4694304d7.png)
![image](https://user-images.githubusercontent.com/31707173/228570789-b5228005-4d86-4834-9ffb-ba5bad314063.png)
![image](https://user-images.githubusercontent.com/31707173/228571652-d34e53b9-0920-47b4-b645-45c120b5f42f.png)
![image](https://user-images.githubusercontent.com/31707173/228571742-16c2b944-3142-4f0a-bc2e-e0db0f9c4aaf.png)
![image](https://user-images.githubusercontent.com/31707173/228571949-7fbcd16a-1196-4a6f-be75-0e079efa2bca.png)

