﻿using PRTelegramBot.Configs;
using PRTelegramBot.Core.CommandHandlers;
using PRTelegramBot.Core.Events;
using PRTelegramBot.Interfaces;
using PRTelegramBot.Models.Enums;
using PRTelegramBot.Registrars;
using Telegram.Bot;

namespace PRTelegramBot.Core
{
    public abstract class PRBotBase
    {
        #region Поля и свойства

        /// <summary>
        /// Имя бота.
        /// </summary>
        public string BotName { get; protected set; }

        /// <summary>
        /// Клиент для telegram бота.
        /// </summary>
        public ITelegramBotClient botClient { get; protected set; }

        /// <summary>
        /// Идентификатор бота в telegram.
        /// </summary>
        public long? TelegramId { get { return botClient.BotId; } }

        /// <summary>
        /// Обработчик для telegram бота
        /// </summary>
        public IPRUpdateHandler Handler { get; protected set; }

        /// <summary>
        /// Работает бот или нет
        /// </summary>
        public bool IsWork { get; protected set; }

        /// <summary>
        /// Параметры бота.
        /// </summary>
        public TelegramOptions Options { get; protected set; }

        /// <summary>
        /// Идентификатор бота.
        /// </summary>
        public long BotId => Options.BotId;

        /// <summary>
        /// События.
        /// </summary>
        public TEvents Events { get; protected set; }

        /// <summary>
        /// Регистрация команд.
        /// </summary>
        public IRegisterCommand Register { get; protected set; }

        /// <summary>
        /// Созданные экземпляры классов для Inline команд.
        /// </summary>
        public Dictionary<Enum, ICallbackQueryCommandHandler> InlineClassHandlerInstances { get; protected set; } = new();

        /// <summary>
        /// Тип получения обновления.
        /// </summary>
        public abstract DataRetrievalMethod DataRetrieval { get; }

        #endregion

        #region Методы

        /// <summary>
        /// Перезагрузить обработчики.
        /// </summary>
        /// <returns>True - удачно, False - не удачно.</returns>
        public bool ReloadHandlers()
        {
            try
            {
                InitHandlers();
                Handler.HotReload();
                return true;
            }
            catch(Exception ex)
            {
                this.Events.OnErrorLogInvoke(ex);
                return false;
            }
        }

        /// <summary>
        /// Инициализация обработчиков.
        /// </summary>
        /// <returns>True - инициализация прошла, False - не прошла.</returns>
        private bool InitHandlers()
        {
            try
            {
                if(Handler is null)
                {
                    Handler = Options.UpdateHandler ?? new Handler(this);
                    if(Handler is Handler baseHandler)
                    {
                        Options.MessageHandlers.Add(new SlashCommandHandler());
                        Options.MessageHandlers.Add(new ReplyCommandHandler());
                        Options.MessageHandlers.Add(new ReplyDynamicCommandHandler());

                        Options.CallbackQueryHandlers.Add(new InlineClassInstanceHandler());
                        Options.CallbackQueryHandlers.Add(new InlineCommandHandler());
                    }
                }
                if(Register is null)
                {
                    Register = Options.CommandOptions.RegisterCommand ?? new RegisterCommand();
                    Register.Init(this);
                }

                return true;
            }
            catch (Exception ex)
            {
                this.Events.OnErrorLogInvoke(ex);
                return false;
            }
        }

        /// <summary>
        /// Очистка очереди команд перед запуском.
        /// </summary>
        protected async Task ClearUpdates()
        {
            try
            {
                var update = await botClient.GetUpdates();
                foreach (var item in update)
                {
                    var offset = item.Id + 1;
                    await botClient.GetUpdates(offset);
                }
            }
            catch (Exception ex)
            {
                this.Events.OnErrorLogInvoke(ex);
            }
        }

        /// <summary>
        /// Запустить бота.
        /// </summary>
        public virtual async Task Start()
        {
            InitHandlers();
        }


        /// <summary>
        /// Остановка бота.
        /// </summary>
        public abstract Task Stop();

        #endregion

        #region Конструкторы

        protected PRBotBase(Action<TelegramOptions> optionsBuilder, TelegramOptions options)
            : base()
        {
            Options = new TelegramOptions();
            if (optionsBuilder != null)
                optionsBuilder.Invoke(Options);
            else
                Options = options;

            if (string.IsNullOrEmpty(Options.Token))
                throw new Exception("Bot token is empty");

            if (Options.BotId < 0)
                throw new Exception("Bot ID cannot be less than zero");

            BotCollection.Instance.AddBot(this);

            botClient = Options.Client ?? new TelegramBotClient(Options.Token);
            Events = new TEvents(this);
            InlineClassRegistrar.Register(this);
            InitHandlers();
        }

        #endregion
    }
}
