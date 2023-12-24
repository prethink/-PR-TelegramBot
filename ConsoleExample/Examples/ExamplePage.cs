﻿using PRTelegramBot.Attributes;
using PRTelegramBot.Core;
using PRTelegramBot.Helpers;
using PRTelegramBot.Models.Enums;
using PRTelegramBot.Models.InlineButtons;
using PRTelegramBot.Models.TCommands;
using Telegram.Bot.Types;
using Telegram.Bot;
using Helpers = PRTelegramBot.Helpers;
using PRTelegramBot.Commands.Constants;
using PRTelegramBot.Models;
using PRTelegramBot.Extensions;
using ConsoleExample.Models;
using System;
using PRTelegramBot.Utils;

namespace ConsoleExample.Examples
{
    public class ExamplePage
    {
        //Тестовые данные 1
        static List<string> pageData = new List<string>()
            {
                "Данные страница 1",
                "Данные страница 2",
                "Данные страница 3",
                "Данные страница 4",
                "Данные страница 5"
            };

        //Тестовые данные 2
        static List<string> pageDataTwo = new List<string>()
            {
                "TestДанные страница 1",
                "TestДанные страница 2",
                "TestДанные страница 3",
                "TestДанные страница 4",
                "TestДанные страница 5"
            };

        /// <summary>
        /// Напишите в чате "pages"
        /// </summary>
        [ReplyMenuHandler("pages")]
        public static async Task ExamplePages(ITelegramBotClient botClient, Update update)
        {
            //Беру текст для первого сообщения
            string msg = pageData[0];
            //Получаю контент с 1 страницы с размером страницы 1
            var data = await pageData.GetPaged<string>(1, 1);
            //Генерирую меню постраничного вывода с заголовком
            var generateMenu = MenuGenerator.GetPageMenu(data.CurrentPage, data.PageCount, CustomTHeaderTwo.CustomPageHeader);
            var option = new OptionMessage();
            option.MenuInlineKeyboardMarkup = generateMenu;
            var message = await Helpers.Message.Send(botClient, update, msg, option);
        }

        /// <summary>
        /// Напишите в чате "pagestwo"
        /// </summary>
        [ReplyMenuHandler("pagestwo")]
        public static async Task ExamplePagesTwo(ITelegramBotClient botClient, Update update)
        {
            //Беру текст для первого сообщения
            string msg = pageDataTwo[0];
            //Получаю контент с 1 страницы с размером страницы 1
            var data = await pageDataTwo.GetPaged<string>(1, 1);
            //Генерирую меню постраничного вывода с заголовком
            var generateMenu = MenuGenerator.GetPageMenu(data.CurrentPage, data.PageCount, CustomTHeaderTwo.CustomPageHeader2);
            var option = new OptionMessage();
            option.MenuInlineKeyboardMarkup = generateMenu;

            var message = await Helpers.Message.Send(botClient, update, msg, option);
        }

        /// <summary>
        /// callback обработка постраничного вывода
        /// Обрабатывает одну точку входа
        /// </summary>
        [InlineCallbackHandler<THeader>(THeader.NextPage, THeader.PreviousPage, THeader.CurrentPage)]
        public static async Task InlinenPage(ITelegramBotClient botClient, Update update)
        {
            try
            {
                //Попытка преобразовать callback данные к требуемому типу
                if (update.CallbackQuery?.Data != null)
                {
                    var command = InlineCallback<PageTCommand>.GetCommandByCallbackOrNull(update.CallbackQuery.Data);
                    if (command != null)
                    {
                        //Получаю заголовок из данных
                        CustomTHeaderTwo header = (CustomTHeaderTwo)command.Data.Header;
                        //обрабатываю данные по заголовку
                        if(header == CustomTHeaderTwo.CustomPageHeader)
                        {
                            //Получаю номер страницы и указываю размер страницы
                            var data = await pageData.GetPaged<string>(command.Data.Page, 1);
                            //Генерирую постраничное меню
                            var generateMenu = MenuGenerator.GetPageMenu(data.CurrentPage, data.PageCount, CustomTHeaderTwo.CustomPageHeader);
                            //Получаю результат из постраничного вывода
                            var pageResult = data.Results;
                            var option = new OptionMessage();
                            option.MenuInlineKeyboardMarkup = generateMenu;
                            string msg = "";
                            if (pageResult.Count > 0)
                            {
                                msg = pageResult.FirstOrDefault();
                            }
                            else
                            {
                                msg = "Нечего не найдено";
                            }
                            //Редактирую текущую страницу
                            await Helpers.Message.Edit(botClient, update, msg, option);
                        }
                        //обрабатываю данные по заголовку
                        else if (header == CustomTHeaderTwo.CustomPageHeader2)
                        {
                            //Получаю номер страницы и указываю размер страницы
                            var data = await pageDataTwo.GetPaged<string>(command.Data.Page, 1);
                            //Генерирую постраничное меню
                            var generateMenu = MenuGenerator.GetPageMenu(data.CurrentPage, data.PageCount, CustomTHeaderTwo.CustomPageHeader2);
                            //Получаю результат из постраничного вывода
                            var pageResult = data.Results;
                            var option = new OptionMessage();
                            option.MenuInlineKeyboardMarkup = generateMenu;
                            string msg = "";
                            if (pageResult.Count > 0)
                            {
                                msg = pageResult.FirstOrDefault();
                            }
                            else
                            {
                                msg = "Нечего не найдено";
                            }
                            //Редактирую текущую страницу
                            await Helpers.Message.Edit(botClient, update, msg, option);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //Обработка исключения
            }
        }
    }
}
