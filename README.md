# Tekst-Redaction

Офлайн редактор текста.

Вскором времени будет совместное редактирование.

````
//1.	Разработать простейший текстовый редактор,
//который позволяет выполнять основные операции редактирования текста,
//открывать и сохранять текстовый файл.
````
Описание проета и кода в нём.

Начало

Форма входа т.е регистрации, пока что сделано так но обновления будут выходить по мере времени.

Создание SQL

![image](https://user-images.githubusercontent.com/103760832/211211555-4c941ad1-ac05-463f-bf07-36f506f05303.png)

Подключение к БД

````
cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=C:\Users\tvc\source\repos\text_redaction\Database1.mdf;
Integrated Security=True");
cn.Open();
````
Форма входа

![image](https://user-images.githubusercontent.com/103760832/211211669-fe1f5c11-b4d2-443c-8772-8d2541695653.png)

-------------------------------------------------------------------------------------------------------------------

Сам редактор и его работа

Сдесь происходит смена цветового режима приложения

![image](https://user-images.githubusercontent.com/103760832/211211774-281c370a-7d87-4e71-930d-802419ac5cd4.png)

Выбор Шрифта из базы Microsoft

![image](https://user-images.githubusercontent.com/103760832/211211796-add53be6-9db8-4052-9788-d9f579e75a74.png)

Текущияя дата и время

![image](https://user-images.githubusercontent.com/103760832/211211824-8935d9ec-3b30-4b1a-9d63-3fba1b728ce9.png)

Открытие файла текстового

![image](https://user-images.githubusercontent.com/103760832/211211859-d9a10910-fba0-438b-a596-814f6262cbdb.png)

Сохранение Файла

![image](https://user-images.githubusercontent.com/103760832/211211885-74ae930d-065f-4e7f-b718-ee021b15ec07.png)

Сохранить изменения

![image](https://user-images.githubusercontent.com/103760832/211211908-ec3fea8f-82c7-4ed5-abd2-607825acdbb7.png)


Открытие вашего текста в Word

![image](https://user-images.githubusercontent.com/103760832/211211934-bf285c1a-a50b-4a6d-897b-4231af6d4185.png)


Вот так выглядит Редактор

![image](https://user-images.githubusercontent.com/103760832/211211971-ace75032-dc98-4038-bb14-6a8cd37878a6.png)


![image](https://user-images.githubusercontent.com/103760832/211211983-4508ca02-2dd5-466d-ab11-f1b1b64c92cc.png)

