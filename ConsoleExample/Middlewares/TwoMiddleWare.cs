﻿using PRTelegramBot.Core.Middlewares;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ConsoleExample.Middlewares
{
    public class TwoMiddleware : MiddlewareBase
    {
        public override async Task InvokeOnPreUpdateAsync(ITelegramBotClient botClient, Update update, Func<Task> next)
        {
            Console.WriteLine("Выполнение второго обработчика перед update");
            await base.InvokeOnPreUpdateAsync(botClient,update, next);
        }

        public override Task InvokeOnPostUpdatesAsync(ITelegramBotClient botClient, Update update)
        {
            Console.WriteLine("Выполнение второго обработчика после update");
            return base.InvokeOnPostUpdatesAsync(botClient, update);
        }
    }
}
