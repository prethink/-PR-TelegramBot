﻿using PRTelegramBot.Configs;

namespace PRTelegramBot.Commands.Constants
{
    /// <summary>
    /// Позволяет редактировать текст сообщений не перекомпилируя программу,а используя json файл
    /// </summary>
    public class MessageKeys
    {
        public const string MSG_MAIN_MENU           = "1m";
        public const string MSG_EXAMPLE_TEXT        = "2m";

        /// <summary>
        /// Преобразует константу сообщения в текст из JSOON
        /// </summary>
        /// <param name="messagePattern"></param>
        /// <returns></returns>
        public static string GetMessage(string messagePattern)
        {
            return ConfigApp.GetSettings<CustomSettings>().GetMessage(messagePattern);
        }

        /// <summary>
        /// Преобразует константу команды в текст из JSON
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static string GetValueButton(string command)
        {
            var result = ConfigApp.GetSettings<CustomSettings>().GetButton(command);
            return result.Contains("NOT_FOUND") ? command : result;
        }
    }
}
