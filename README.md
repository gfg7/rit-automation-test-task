# RITAutomantion

## Задание 1 

На языке C# необходимо разработать приложение Windows Forms (ОБЯЗАТЕЛЬНО .NET Framework), которое на главной форме содержит карту из библиотеки GMap.NET, загружает из базы данных Microsoft SQL Server географические координаты условных единиц техники и отображает их на карте в виде маркеров. Так же необходимо реализовать перемещение маркеров с помощью мыши (Drag&Drop, то есть нажать на маркер и перенести в другую точку карты) и сохранение новых координат в базу данных, чтобы после перезапуска приложения маркеры были расположены так же, как и до закрытия приложения.

Выполненным заданием будет считаться архив с проектом Visual Studio, а также SQL-скриптом для создания базы данных (полное создание БД с нуля + наполнение данными). В базе данных уже должны содержаться маркеры. При работе с базой данных нельзя пользоваться никакими фреймворками (EntityFramework и т.д.), необходимо использовать T-SQL.

## Запуск задания 1

RITAutomantion.exe.config

Добавить строку соединения в configuration/connectionStrings в формате:

`<add name="RITAutomantion.Properties.Settings.masterConnectionString"
            connectionString="Data Source=<Data Source>;Initial Catalog=<Initial Catalog>;User ID=<User ID>;Password=<Password>;MultipleActiveResultSets=True"
            providerName="System.Data.SqlClient" />`
