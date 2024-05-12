﻿using PRTelegramBot.Core;
using PRTelegramBot.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace PRTelegramBot.Extensions
{
    public static class BotExtension
    {
        #region Методы

        /// <summary>
        /// Проверяет пользователя, является ли он администратором бота.
        /// </summary>
        /// <param name="botClient">Бот клиент.</param>
        /// <param name="update">Обновление из telegram.</param>
        /// <returns>True - администратор, False - не администратор.</returns>
        public static bool IsAdmin(this ITelegramBotClient botClient, Update update)
        {
            return IsAdmin(botClient, update.GetChatId());
        }

        /// <summary>
        /// Проверяет пользователя, является ли он администратором бота.
        /// </summary>
        /// <param name="botClient">Бот клиент.</param>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>True - администратор, False - не администратор.</returns>
        public static bool IsAdmin(this ITelegramBotClient botClient, long userId)
        {
            var botData = GetBotDataOrNull(botClient);
            return botData != null && botData.Options.Admins.Contains(userId);
        }

        /// <summary>
        /// Проверяет пользователя, является ли он администратором бота.
        /// </summary>
        /// <param name="botClient">Бот.</param>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>True - администратор, False - не администратор.</returns>
        public static bool IsAdmin(this PRBot botClient, long userId)
        {
            return botClient.Options.Admins.Contains(userId);
        }

        /// <summary>
        /// Проверяет пользователя, присутствует ли в белом списке бота.
        /// </summary>
        /// <param name="botClient">Бот клиент.</param>
        /// <param name="update">Обновление из telegram.</param>
        /// <returns>True - есть в списке, False - нет в списке.</returns>
        public static bool InWhiteList(this ITelegramBotClient botClient, Update update)
        {
            return InWhiteList(botClient, update.GetChatId());
        }

        /// <summary>
        /// Проверяет пользователя, присутствует ли в белом списке бота.
        /// </summary>
        /// <param name="botClient">Бот клиент.</param>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>True - есть в списке, False - нет в списке.</returns>
        public static bool InWhiteList(this ITelegramBotClient botClient, long userId)
        {
            var botData = GetBotDataOrNull(botClient);
            return botData != null && botData.Options.WhiteListUsers.Contains(userId);
        }

        /// <summary>
        /// Проверяет пользователя, присутствует ли в белом списке бота.
        /// </summary>
        /// <param name="botClient">Бот.</param>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>True - есть в списке, False - нет в списке.</returns>
        public static bool InWhiteList(this PRBot botClient, long userId)
        {
            return botClient.Options.WhiteListUsers.Contains(userId);
        }

        /// <summary>
        /// Возращает список администраторов бота.
        /// </summary>
        /// <param name="botClient">Бот клиент.</param>
        /// <returns>Список идентификаторов.</returns>
        public static List<long> GetAdminsIds(this ITelegramBotClient botClient)
        {
            var botData = GetBotDataOrNull(botClient);
            return botData != null ? botData.Options.Admins.ToList() : new List<long>();
        }

        /// <summary>
        /// Возращает список администраторов бота.
        /// </summary>
        /// <param name="botClient">Бот клиент.</param>
        /// <returns>Список идентификаторов.</returns>
        public static List<long> GetAdminsIds(this PRBot botClient)
        {
            return botClient.Options.Admins.ToList();
        }

        /// <summary>
        /// Возращает белый список пользователей.
        /// </summary>
        /// <param name="botClient">Бот клиент.</param>
        /// <returns>Список идентификаторов.</returns>
        public static List<long> GetWhiteListIds(this ITelegramBotClient botClient)
        {
            var botData = GetBotDataOrNull(botClient);
            return botData != null ? botData.Options.WhiteListUsers.ToList() : new List<long>();
        }

        /// <summary>
        /// Возращает белый список пользователей.
        /// </summary>
        /// <param name="botClient">Бот клиент.</param>
        /// <returns>Список идентификаторов.</returns>
        public static List<long> GetWhiteListIds(this PRBot botClient)
        {
            return botClient.Options.WhiteListUsers.ToList();
        }

        /// <summary>
        /// Получить экземпляр класса бота.
        /// </summary>
        /// <param name="botClient">Бот клиент.</param>
        /// <returns>Экземпляр класса или null.</returns>
        public static PRBot GetBotDataOrNull(this ITelegramBotClient botClient)
        {
            return BotCollection.Instance.GetBotByTelegramIdOrNull(botClient.BotId);
        }

        /// <summary>
        /// Вызов события простого лога.
        /// </summary>
        /// <param name="botClient">Бот.</param>
        /// <param name="msg">Сообщение.</param>
        /// <param name="typeEvent">Тип события.</param>
        /// <param name="color">Цвет.</param>
        public static void InvokeCommonLog(this ITelegramBotClient botClient, string msg, string typeEvent = "", ConsoleColor color = ConsoleColor.Blue)
        {
            var bot = GetBotDataOrNull(botClient);
            bot?.InvokeCommonLog(msg, typeEvent, color);
        }

        /// <summary>
        /// Вызов события логирование ошибок.
        /// </summary>
        /// <param name="botClient">Бот.</param>
        /// <param name="ex">Исключение.</param>
        /// <param name="id">Идентификатор пользователя.</param>
        public static void InvokeErrorLog(this ITelegramBotClient botClient, Exception ex, long? id = null)
        {
            var bot = GetBotDataOrNull(botClient);
            bot?.InvokeErrorLog(ex, id);
        }

        /// <summary>
        /// Генерация реферальной ссылки.
        /// </summary>
        /// <param name="botClient">Бот.</param>
        /// <param name="refLink">Текст реферальной ссылки.</param>
        /// <returns>Сгенерированная реферальная ссылка.</returns>
        /// <exception cref="ArgumentNullException">Вызывается в случае пустого текста.</exception>
        public async static Task<string> GetGeneratedRefLink(this ITelegramBotClient botClient, string refLink)
        {
            if (string.IsNullOrEmpty(refLink))
                throw new ArgumentNullException(nameof(refLink));

            var bot = await botClient.GetMeAsync();
            return $"https://t.me/{bot.Username}?start={refLink}";
        }

        public static TReturn GetConfigValue<TBotProvider, TReturn>(this ITelegramBotClient botClient, string configKey, string key)
            where TBotProvider : IBotConfigProvider
        {
            string configPath = botClient.GetBotDataOrNull().Options.ConfigPaths[configKey];
            var botConfiguration = Activator.CreateInstance(typeof(TBotProvider)) as IBotConfigProvider;
            botConfiguration.SetConfigPath(configPath);
            return botConfiguration.GetValue<TReturn>(key);
        }

        public static bool TryGetConfigValue<TBotProvider, TReturn>(this ITelegramBotClient botClient, string configKey, string key, out TReturn result)
            where TBotProvider : IBotConfigProvider, new()
        {
            result = default(TReturn);
            try
            {
                var botConfiguration = new TBotProvider(); // Создание экземпляра поставщика конфигурации
                string configPath = botClient.GetBotDataOrNull()?.Options?.ConfigPaths?.GetValueOrDefault(configKey);

                if (configPath == null)
                {
                    // Если путь конфигурации не найден, возвращаем false
                    return false;
                }

                botConfiguration.SetConfigPath(configPath); // Установка пути конфигурации
                result = botConfiguration.GetValue<TReturn>(key); // Получение значения конфигурации
                return true; // Успешно получили значение конфигурации
            }
            catch (Exception ex)
            {
                // Обработка ошибки и возврат false
                return false;
            }
        }

        #endregion
    }
}
