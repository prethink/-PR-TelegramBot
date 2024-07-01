﻿using PRTelegramBot.Attributes;
using PRTelegramBot.Models;
using PRTelegramBot.Models.Enums;
using PRTelegramBot.Models.EventsArgs;
using PRTelegramBot.Utils;
using System.Reflection;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace PRTelegramBot.Core.UpdateHandlers.CommandsUpdateHandlers
{
    /// <summary>
    /// Обработчик slash команд.
    /// </summary>
    public sealed class SlashMessageUpdateHandler : MessageCommandUpdateHandler
    {
        #region Базовый класс

        public override CommandType CommandType => CommandType.Slash;

        public override MessageType TypeMessage => MessageType.Text;

        public override async Task<UpdateResult> Handle(Update update)
        {
            try
            {
                string command = update.Message.Text;
                if (command.StartsWith('/'))
                {
                    var resultExecute = StartHasDeepLink(command, update);
                    if (resultExecute == CommandResult.Executed)
                        return UpdateResult.Handled;

                    bot.Events.MessageEvents.OnPreSlashCommandHandleInvoke(new BotEventArgs(bot, update));
                    resultExecute = await ExecuteCommand(command, update, commands);
                    if (resultExecute != CommandResult.Continue)
                    {
                        bot.Events.MessageEvents.OnPostSlashCommandHandleInvoke(new BotEventArgs(bot, update));
                        return UpdateResult.Handled;
                    }
                }
                return UpdateResult.Continue;
            }
            catch (Exception ex)
            {
                bot.Events.OnErrorLogInvoke(ex, update);
                return UpdateResult.Error;
            }
        }

        public override bool AddCommand(string command, Func<ITelegramBotClient, Update, Task> @delegate)
        {
            if (!command.StartsWith('/'))
                command = "/" + command;

            return base.AddCommand(command, @delegate);
        }

        protected override void RegisterCommands()
        {
            MethodInfo[] methods = ReflectionUtils.FindStaticSlashCommandHandlers(bot.Options.BotId);
            registerService.RegisterStaticCommand(bot, typeof(SlashHandlerAttribute), methods, commands);

            Type[] servicesToRegistration = ReflectionUtils.FindServicesToRegistration();
            foreach (var serviceType in servicesToRegistration)
            {
                var methodsInClass = serviceType.GetMethods().Where(x => !x.IsStatic).ToArray();
                registerService.RegisterMethodFromClass(bot, typeof(SlashHandlerAttribute), methodsInClass, commands, bot.Options.ServiceProvider);
            }
        }

        #endregion

        #region Методы

        /// <summary>
        /// Проверка является ли команда start с аргументом.
        /// </summary>
        /// <param name="command">Команда.</param>
        /// <param name="update">Обновление.</param>
        /// <returns>Результат выполнение команд.</returns>
        private CommandResult StartHasDeepLink(string command, Update update)
        {
            try
            {
                if (!command.ToLower().Contains("start") && command.Contains(" "))
                    return CommandResult.Continue;

                var spl = command.Split(' ');
                if (spl.Length < 2 || string.IsNullOrEmpty(spl[1]))
                    return CommandResult.Continue;

                bot.Events.OnUserStartWithArgsInvoke(new StartEventArgs(bot, update, spl[1]));
                return CommandResult.Executed;
            }
            catch (Exception ex)
            {
                bot.Events.OnErrorLogInvoke(ex, update);
                return CommandResult.Error;
            }
        }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="bot">Бот.</param>
        public SlashMessageUpdateHandler(PRBotBase bot)
            : base(bot)
        {
            RegisterCommands();
        }

        #endregion
    }
}
