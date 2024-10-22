![Static Badge](https://img.shields.io/badge/version-v0.7.2-brightgreen) ![Static Badge](https://img.shields.io/badge/telegram.bot-2.8.0-blue)  ![NuGet Downloads](https://img.shields.io/nuget/dt/prtelegrambot) ![NuGet Version](https://img.shields.io/nuget/v/prtelegrambot)


> **Если данный проект был для вас полезен и хотите его поддержать, можете поставить ⭐ в репозитории проекта.

[https://prethink.gitbook.io/prtelegrambot/](https://prethink.gitbook.io/prtelegrambot/)  - актуальная документация.        
[https://www.nuget.org/packages/PRTelegramBot/](https://www.nuget.org/packages/PRTelegramBot/) - nuget.     
[https://t.me/predevchat](https://t.me/predevchat) - чат для вопросов.    

# ⚛️ Ядро фреймворка
TelegramBot v21.8.0 https://github.com/TelegramBots/Telegram.Bot

# 📰 Описание
Фреймворк с открытым исходным кодом с гибким и простым функционалом для создания ботов Telegram.     
Примеры https://github.com/prethink/PRTelegramBot/tree/master/Examples     
Примеры с видео: https://github.com/prethink/PRTelegramYoutube   

# 💎 Функционал

 - **Работа с reply командами.** Поддержка простых текстовых команд.   
 - **Работа с динамическими командами ответа.** Текстовые команды, загружаемые из конфигурационного файла без необходимости компиляции.        
 - **Обработка команд с параметрами.** Возможность работы с командами, содержащими параметры в скобках, например, "Тест (1)".        
 - **Работа с slash командами.** Обработка команд типа /get_1, /users и других текстовых команд.    
 - **Гибкая работа с inline-командами.** Генератор и парсер inline-команд.    
 - **Создание меню.** Простое и гибкое создание reply и inline меню.    
 - **Работа с конфигурационными файлами.** Поддержка конфигурационных файлов для каждого бота с возможностью реализации собственного провайдера конфигураций. По умолчанию используется JSON.    
 - **Админ-менеджер.** Управление администраторами бота с возможностью реализации собственного админ-менеджера.    
 - **Менеджер белого списка пользователей.** Гибкое управление белым списком с возможностью добавления методов, игнорируемых белым списком, и реализации собственного менеджера белого списка.    
 - **Обработка update.** Возможность реализации собственного обработчика update.    
 - **Система событий.** Гибкая система обработки событий.    
 - **Многоботная система.** Возможность создания нескольких ботов в одном проекте.    
 - **Система middleware.** Добавление собственных обработчиков до и после update, аналогично middleware в ASP.NET.    
 - **Проверки перед выполнением команд.** Внутренние проверки для команд reply, dynamicreply, nextstep, slash и inline.
 - **Создание собственных обработчиков для update типа message и callbackQuery.** Реализация своих обработчиков как reply, slash, inlineCallback.
 - **Динамическое управление командами.** Возможность добавления и удаления команд в реальном времени с реализацией собственного регистратора команд.    
 - **Сброс старых update.** Возможность сброса всех старых update перед запуском бота.    
 - **Пошаговое выполнение команд.** Возможность выполнения пошаговых наборов reply-команд.    
 - **Подключение к собственным серверам.** Работа ботов через собственные сервера.    
 - **Создание polling и webhook ботов.** Поддержка различных методов работы с ботами.    
 - **Встроенный функционал календаря.** Работа с датами и календарями.    
 - **Постраничная работа с сообщениями.** Управление сообщениями с постраничной навигацией.    
 - **Хранение кэша пользователей.** Работа с пользовательским кэшем.    
 - **Ограничение доступа к методам.** Возможность ограничения доступа к определенным методам.    
 - **Работа с dependency injection.** Поддержка внедрения зависимостей.    
 - **Парсинг из конфигурационных файлов.** Парсинг сообщений, команд и кнопок из конфигурационных файлов.    
 - **Функционал предоставляемый telegram.bot.**    

# 🧱 Интегрированные пакеты
 - CalendarPicker | karb0f0s   https://github.com/karb0f0s/CalendarPicker     
