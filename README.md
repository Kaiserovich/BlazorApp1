# BlazorOrders

## Web-app “Customer and Order Management”

The application is developed using AspNetCore 6 and Blazor Server. Data storage MS SQL Server 2019, ORM Entity Framework Core 7. Data access is implemented using "Repository" pattern

Client part implements CRUD logic for the entities customers and orders, validation of entered data. Registration and authorization of users, data filtering are implemented.

## Веб-приложение “**Управление клиентами и заказами”**

Приложение разработано с использованием AspNetCore 6 и Blazor Server. Хранение данных MS SQL Server 2019, ORM Entity Framework Core 7. Доступ к данным реализован с помощью паттерна “Репозиторий”

Клиентская часть реализует CRUD логику для сущностей клиенты и заказы, валидацию вводимых данных. Реализована регистрация и авторизация пользователей, фильтрация данных. Логгирование.

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

![image](https://user-images.githubusercontent.com/31707173/231190156-58ec973b-45fd-4251-a6cb-fdf0a28f69d9.png)
![image](https://user-images.githubusercontent.com/31707173/231190206-4d8f5944-1d14-498f-8b5d-c06abaacf99e.png)
![image](https://user-images.githubusercontent.com/31707173/231190377-f6ec711e-49eb-442b-8372-39bfce0a3d4c.png)
![image](https://user-images.githubusercontent.com/31707173/231190239-76d3e9b0-f048-4046-a5dc-4ace7b4ed1aa.png)
![image](https://user-images.githubusercontent.com/31707173/231190438-2360fb8a-3f96-4ee2-8301-d9705b5044c4.png)
![image](https://user-images.githubusercontent.com/31707173/231190498-85868fc2-7e19-4fb4-b1db-959da3f273fd.png)
![image](https://user-images.githubusercontent.com/31707173/231191230-e061cb3d-559a-4ad9-8320-e03276e317ff.png)
![image](https://user-images.githubusercontent.com/31707173/231191265-5c79450d-e2f0-4554-a3f9-02305e4c82f7.png)
![image](https://user-images.githubusercontent.com/31707173/231191305-685be314-d50b-4633-aa49-6477a4ed0173.png)
![image](https://user-images.githubusercontent.com/31707173/231191366-028e2054-77b0-4f18-87f0-6f3dd7d0cc81.png)
![image](https://user-images.githubusercontent.com/31707173/231191397-7bac36ab-eca3-45d7-a3a5-eb77494304ba.png)
![image](https://user-images.githubusercontent.com/31707173/231191441-fcc33320-ca55-4bf6-857f-7acae9f523fb.png)
![image](https://user-images.githubusercontent.com/31707173/231191492-bf641aaa-f239-4410-9b30-c82009b3efe4.png)
![image](https://user-images.githubusercontent.com/31707173/231191796-c093bf5e-bb47-40d8-9e46-b51f99696f76.png)




