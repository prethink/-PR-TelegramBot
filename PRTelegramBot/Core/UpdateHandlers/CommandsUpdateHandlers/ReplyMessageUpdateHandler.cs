﻿using PRTelegramBot.Attributes;
using PRTelegramBot.Models;
using PRTelegramBot.Models.Enums;
using PRTelegramBot.Models.EventsArgs;
using PRTelegramBot.Utils;
using System.Reflection;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace PRTelegramBot.Core.UpdateHandlers.CommandsUpdateHandlers
{
    /// <summary>
    /// Обработчик reply команд.
    /// </summary>
    public class ReplyMessageUpdateHandler : MessageCommandUpdateHandler
    {
        #region Поля и свойства

        public override MessageType TypeMessage => MessageType.Text;

        #endregion

        #region Методы

        public override async Task<UpdateResult> Handle(Update update)
        {
            try
            {
                string command = update.Message.Text;
                RemoveBracketsIfExists(ref command);
                var resultExecute = await ExecuteCommand(command, update, commands);
                if (resultExecute != CommandResult.Continue)
                    return UpdateResult.Handled;

                return UpdateResult.Continue;
            }
            catch (Exception ex)
            {
                bot.Events.OnErrorLogInvoke(ex, update);
                return UpdateResult.Error;
            }
        }

        /// <summary>
        /// Удалить скобки из сообщения
        /// </summary>
        /// <param name="command"></param>
        protected void RemoveBracketsIfExists(ref string command)
        {
            if (command.Contains("(") && command.Contains(")"))
                command = command.Remove(command.LastIndexOf("(") - 1);
        }

        protected override void RegisterCommands()
        {
            MethodInfo[] methods = ReflectionUtils.FindStaticMessageMenuHandlers(bot.Options.BotId);
            registerService.RegisterStaticCommand(bot, typeof(ReplyMenuHandlerAttribute), methods, commands);

            Type[] servicesToRegistration = ReflectionUtils.FindServicesToRegistration();
            foreach (var serviceType in servicesToRegistration)
            {
                var methodsInClass = serviceType.GetMethods().Where(x => !x.IsStatic).ToArray();
                registerService.RegisterMethodFromClass(bot, typeof(ReplyMenuHandlerAttribute), methodsInClass, commands, bot.Options.ServiceProvider);
            }
        }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="bot">Бот.</param>
        public ReplyMessageUpdateHandler(PRBotBase bot)
            : base(bot)
        {
            RegisterCommands();
        }

        #endregion
    }
}
