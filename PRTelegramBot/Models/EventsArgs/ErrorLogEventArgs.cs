﻿using PRTelegramBot.Core;

namespace PRTelegramBot.Models.EventsArgs
{
    public class ErrorLogEventArgs : BotEventArgs
    {
        public Exception Exception { get; private set; }
        public ErrorLogEventArgs(PRBotBase bot, ErrorLogEventArgsCreator errorEvent)
            : base(bot, errorEvent.Update)
        {
            this.Exception = errorEvent.Exception;
        }
    }
}
