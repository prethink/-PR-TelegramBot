﻿using Telegram.Bot.Types;

namespace PRTelegramBot.Configs
{
    /// <summary>
    /// Параметры telegram бота для работы с WebHook.
    /// </summary>
    public class WebHookTelegramOptions : TelegramOptions
    {
        #region Поля и свойства

        /// <summary>
        /// 
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public InputFileStream? Certificate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? IpAddress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? MaxConnections { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? DropPendingUpdates { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? SecretToken { get; set; }

        #endregion

        #region ICloneable

        public override object Clone()
        {
            var cloneOptions = new WebHookTelegramOptions();
            cloneOptions.Token = Token;
            cloneOptions.ClearUpdatesOnStart = ClearUpdatesOnStart;
            cloneOptions.BotId = BotId;
            cloneOptions.WhiteListUsers = WhiteListUsers.ToList();
            cloneOptions.Admins = Admins.ToList();
            cloneOptions.ReplyDynamicCommands = new Dictionary<string, string>(ReplyDynamicCommands);
            cloneOptions.ConfigPaths = new Dictionary<string, string>(ConfigPaths);
            cloneOptions.Url = Url;
            cloneOptions.Certificate = Certificate;
            cloneOptions.IpAddress = IpAddress;
            cloneOptions.MaxConnections = MaxConnections;
            cloneOptions.DropPendingUpdates = DropPendingUpdates;
            cloneOptions.SecretToken = SecretToken; 
            return cloneOptions;
        }

        #endregion
    }
}
