﻿using PRTelegramBot.Core.Middlewares;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace PRTelegramBot.Tests.Common.TestMiddleware
{
    public class TestOneMiddleware : MiddlewareBase
    {
        public const string NextMessage = "OneNext";
        public const string PrevMessage = "OnePrev";
        private List<string> log;

        public override async Task InvokeOnPreUpdateAsync(ITelegramBotClient botClient, Update update, Func<Task> next)
        {
            log.Add(NextMessage);
            await base.InvokeOnPreUpdateAsync(botClient, update, next);
        }

        public override Task InvokeOnPostUpdatesAsync(ITelegramBotClient botClient, Update update)
        {
            log.Add(PrevMessage);
            return base.InvokeOnPostUpdatesAsync(botClient, update);
        }

        public TestOneMiddleware(List<string> log)
        {
            this.log = log;
        }
    }
}
