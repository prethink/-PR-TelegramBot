﻿namespace Telegram.Bot.Types.Enums;

/// <summary>Source of the boost</summary>
[JsonConverter(typeof(ChatBoostSourceTypeConverter))]
public enum ChatBoostSourceType
{
    /// <summary>The boost was obtained by subscribing to Telegram Premium or by gifting a Telegram Premium subscription to another user.<br/><br/><i>(<see cref="ChatBoostSource"/> can be cast into <see cref="ChatBoostSourcePremium"/>)</i></summary>
    Premium = 1,
    /// <summary>The boost was obtained by the creation of Telegram Premium gift codes to boost a chat. Each such code boosts the chat 4 times for the duration of the corresponding Telegram Premium subscription.<br/><br/><i>(<see cref="ChatBoostSource"/> can be cast into <see cref="ChatBoostSourceGiftCode"/>)</i></summary>
    GiftCode,
    /// <summary>The boost was obtained by the creation of a Telegram Premium giveaway. This boosts the chat 4 times for the duration of the corresponding Telegram Premium subscription.<br/><br/><i>(<see cref="ChatBoostSource"/> can be cast into <see cref="ChatBoostSourceGiveaway"/>)</i></summary>
    Giveaway,
}
