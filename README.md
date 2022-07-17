# TestProgrammForVersta 

Использованная БД - PostgreSQL. Для корректной работы в Visual Studio необходимо утановить пакеты: 
* Microsoft.AspNetCore.SpaProxy
* Microsoft.EntityFrameworkCore
* Microsoft.EntityFrameworkCore.Tools
* Npgsql.EntityFrameworkCore.PostgreSQL

Для запуска:
1. Склонируйте репозиторий
2. В папке ClientApp выполните команду `npm install`
3. В диспетчере пакетов NUGet создайте БД командой `Update-Database` (информация о подключении к БД находится в файле `OrdersContext.cs`)
4. Скомпилируйте и запустите проект
