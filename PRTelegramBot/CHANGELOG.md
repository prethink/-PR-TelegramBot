
-- 2024.01.02 - V0.5.5
- feature: Добавлена возможность подставлять свой enum в common logs
- feature: Добавлен InlineCommandNotFoundException
- feature: Добавлена GroupUtils в котором есть метод IsGroupMember, IsGroupAdmin, IsGroupCreator
- feature: Заместо StepCommand теперь используется абстракция в виде интерфейса IExecuteStep
- refactoring: Рефакторинг Router
- refactoring: Типы для DI теперь создаются с жизненным циклом Transient а не Singleton
- refactoring: Класс Step переименован в StepService
- refactoring: Step.RegisterNextStep переименован в RegisterStepHandler
- fix: IsSlashCommand теперь проверяет первый символ /


-- 2023.12.24 - V0.5.4
- refactoring: ReflectionUtils перенесен в пространство имен PRTelegramBot.Utils
- refactoring: ReflectionHelper переименован в ReflectionUtils
- refactoring: Calendar перенесен в пространство имен PRTelegramBot.Utils
- refactoring: MenuGenerator перенесен в пространство имен PRTelegramBot.Utils
- refactoring: Generator перенесен в пространство имен PRTelegramBot.Utils
- feature: botClient позволяет вызывать методы простых и ошибочных логов.
- feature: Возможность добавлять/удалять reply и slash команды через экземпляр класса PRBot
- feature: botClient.GetBotAdminIds() возвращает администраторов бота
- feature: Добавлена динамическая регистрация команд inline
- fix: Метод SendPhoto не отправлял сообщения если optionmessage был не пустой
- fix: Enum записывает правильные значения из int

-- 2023.12.18 - V0.5.3
- delete: Удален атрибут TelegramBotHandler
- fix: поправлен поиск и создание классов для обработчиков telegram бота
  
-- 2023.12.17 - V0.5.2
- fix: AddBotHandlers возвращает IServiceProvaider

-- 2023.12.17 - V0.5.1
- fix: Изменен url проекта на https://prtelegrambot.gitbook.io/prtelegrambot/obrabotka-komand/obrabotka-inline-komand


-- 2023.12.17 - V0.5.0
- feature: Добавлена динамическая регистрация команд reply и slash
- feature: Добавлена работа с dependency injection и пример на asp.net
