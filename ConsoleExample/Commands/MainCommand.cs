﻿using PRTelegramBot.Attributes;
using Telegram.Bot;
using Telegram.Bot.Types;
using PRTelegramBot.Extensions;
using PRTelegramBot.Core;
using PRTelegramBot.Commands.Constants;
using PRTelegramBot.Models;
using ConsoleExample.Commands.Constants;
using PRTelegramBot.Utils;

namespace PRTelegramBot.Commands
{
    internal class MainCommand
    {
        [ReplyMenuDictionaryHandler(nameof(ReplyKeys.RP_MENU), nameof(ReplyKeys.RP_MAIN_MENU))]
        [RequiredTypeChat(Telegram.Bot.Types.Enums.ChatType.Private)]
        public static async Task MainMenu(ITelegramBotClient botClient, Update update)
        {
            try
            {
                await MainMenu(botClient,  update.GetChatId(), new DictionaryJSON().GetMessage(nameof(MessageKeys.MSG_MAIN_MENU)));
            }
            catch(Exception ex)
            {
                //Обработка исключения
            }
        }

        public static async Task MainMenu(ITelegramBotClient botClient, long telegramId)
        {
            try
            {
                await MainMenu(botClient, telegramId, new DictionaryJSON().GetMessage(nameof(MessageKeys.MSG_MAIN_MENU)));
            }
            catch (Exception ex)
            {
                //Обработка исключения
            }
        }

        [RequiredTypeChat(Telegram.Bot.Types.Enums.ChatType.Private)]
        public static async Task MainMenu(ITelegramBotClient botClient, long telegramId, string message)
        {
            try
            {
                if (string.IsNullOrEmpty(message))
                {
                    message = "Главное меню";
                }

                var option = new OptionMessage();
                option.MenuReplyKeyboardMarkup = MenuGenerator.ReplyKeyboard(1, new List<string>(), true, new DictionaryJSON().GetButton(nameof(ReplyKeys.RP_MAIN_MENU)));
                await Helpers.Message.Send(botClient, telegramId, message, option);
            }
            catch (Exception ex)
            {
                //Обработка исключения
            }
        }

    }
}
