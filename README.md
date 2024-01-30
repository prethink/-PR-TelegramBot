Актуальная документация - [https://prtelegrambot.gitbook.io/prtelegrambot/](https://prtelegrambot.gitbook.io/prtelegrambot/)     
Чат для вопросов - [https://t.me/predevchat](https://t.me/predevchat)


# 📰 Описание
Библиотека для быстрого создания telegram ботов.   
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

 - TelegramBot v19.0.0 https://github.com/TelegramBots/Telegram.Bot
 - Microsoft.Extensions.Configuration.Binder v7.0.0 https://github.com/dotnet/runtime
 - Microsoft.Extensions.Configuration.Json v7.0.0 https://github.com/dotnet/runtime
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





### [📎 Основные элементы в структуре проекта](https://github.com/prethink/-PR-TelegramBot/wiki/%D0%9E%D1%81%D0%BD%D0%BE%D0%B2%D0%BD%D1%8B%D0%B5-%D1%8D%D0%BB%D0%B5%D0%BC%D0%B5%D0%BD%D1%82%D1%8B-%D0%B2-%D1%81%D1%82%D1%80%D1%83%D0%BA%D1%82%D1%83%D1%80%D0%B5-%D0%BF%D1%80%D0%BE%D0%B5%D0%BA%D1%82%D0%B0)

