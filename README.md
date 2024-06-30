# 🤖 Текущая версия: 0.6.1
# Если данный проект был для вас полезен и хотите его поддержать, поставьте ⭐    

Актуальная документация для версии в nuget - [https://prtelegrambot.gitbook.io/prtelegrambot/](https://prtelegrambot.gitbook.io/prtelegrambot/)     
nuget - [https://www.nuget.org/packages/PRTelegramBot/](https://www.nuget.org/packages/PRTelegramBot/)    
Чат для вопросов - [https://t.me/predevchat](https://t.me/predevchat)
# ⚛️ Ядро библиотеки
TelegramBot v21.2.0 https://github.com/TelegramBots/Telegram.Bot

# 📰 Описание
Библиотека с простой маршрутизацией команд для создания telegram ботов.      
Пример использования в консольном приложении. https://github.com/prethink/PRTelegramBot/tree/master/ConsoleExample

# 💎 Возможности

 - Регистрация и автоматическая обработка команд (reply) и ответов;
 - Обработка команд, содержащих скобки, например, "Лайки (5)";
 - Создание меню ответов;
 - Регистрация и обработка встроенных (Inline) команд;
 - Генерация встроенных кнопок и меню;
 - Работа с inline календарем;
 - Постраничный вывод сообщений;
 - Регистрация и обработка команд с использованием слеша [/];
 - Работа со словарем;
 - Выполнение команд пошагово;
 - Хранение кэша данных пользователей;
 - Возможность ограничить доступ к определенным функциям только выбранным пользователям;
 - Возможность добавления администраторов для управления телеграм-ботом;
 - Возможность использования белого списка пользователей, которые могут пользоваться ботом.
 - Динамическое добавление и удаление команд


# 🔑 Зависимости

 - TelegramBot v21.2.0 https://github.com/TelegramBots/Telegram.Bot
 - Microsoft.Extensions.Configuration.Binder v8.0.0 https://github.com/dotnet/runtime
 - Microsoft.Extensions.Configuration.Json v8.0.0 https://github.com/dotnet/runtime
 - Microsoft.Extensions.DependencyInjection.Abstractions v8.0.0 https://github.com/dotnet/runtime

# 🧱 Интегрированные пакеты
 - CalendarPicker | karb0f0s   https://github.com/karb0f0s/CalendarPicker



## Примеры использования    
Для того чтобы посмотреть, как работает бот можно воспользоваться примером из репозитория ConsoleExample.
Примеры готовых функций есть в консольном приложение по пути ***/Examples***
- ***ExampleCalendar.cs*** - Пример работы с календарем.
- ***ExampleCommand.cs*** - Пример как создавать reply, inline и слеш команды.
- ***ExampleHandlers.cs*** - Пример как можно обрабатывать callback данные.
- ***ExampleStepCommand.cs*** - Пример c пошаговым выполнением команд.
- ***ExampleUserCache.cs*** - Пример c кэш данными пользователя.    
- ***ExampleEvent.cs*** - Пример обработки разных типов сообщений.    
- ***WebApp.html*** - Скромный пример что требуется для WebApp страницы.   

