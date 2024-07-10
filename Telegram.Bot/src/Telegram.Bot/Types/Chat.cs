﻿namespace Telegram.Bot.Types;

/// <summary>This object represents a chat.</summary>
public partial class Chat
{
    /// <summary>Unique identifier for this chat.</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public long Id { get; set; }

    /// <summary>Type of the chat, can be either <see cref="ChatType.Private">Private</see>, <see cref="ChatType.Group">Group</see>, <see cref="ChatType.Supergroup">Supergroup</see> or <see cref="ChatType.Channel">Channel</see></summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public ChatType Type { get; set; }

    /// <summary><em>Optional</em>. Title, for supergroups, channels and group chats</summary>
    public string? Title { get; set; }

    /// <summary><em>Optional</em>. Username, for private chats, supergroups and channels if available</summary>
    public string? Username { get; set; }

    /// <summary><em>Optional</em>. First name of the other party in a private chat</summary>
    public string? FirstName { get; set; }

    /// <summary><em>Optional</em>. Last name of the other party in a private chat</summary>
    public string? LastName { get; set; }

    /// <summary><em>Optional</em>. <see langword="true"/>, if the supergroup chat is a forum (has <a href="https://telegram.org/blog/topics-in-groups-collectible-usernames#topics-in-groups">topics</a> enabled)</summary>
    public bool IsForum { get; set; }
}

/// <summary>This object contains full information about a chat.</summary>
public partial class ChatFullInfo : Chat
{
    /// <summary>Identifier of the accent color for the chat name and backgrounds of the chat photo, reply header, and link preview. See <a href="https://core.telegram.org/bots/api#accent-colors">accent colors</a> for more details.</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public int AccentColorId { get; set; }

    /// <summary>The maximum number of reactions that can be set on a message in the chat</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public int MaxReactionCount { get; set; }

    /// <summary><em>Optional</em>. Chat photo</summary>
    public ChatPhoto? Photo { get; set; }

    /// <summary><em>Optional</em>. If non-empty, the list of all <a href="https://telegram.org/blog/topics-in-groups-collectible-usernames#collectible-usernames">active chat usernames</a>; for private chats, supergroups and channels</summary>
    public string[]? ActiveUsernames { get; set; }

    /// <summary><em>Optional</em>. For private chats, the date of birth of the user</summary>
    public Birthdate? Birthdate { get; set; }

    /// <summary><em>Optional</em>. For private chats with business accounts, the intro of the business</summary>
    public BusinessIntro? BusinessIntro { get; set; }

    /// <summary><em>Optional</em>. For private chats with business accounts, the location of the business</summary>
    public BusinessLocation? BusinessLocation { get; set; }

    /// <summary><em>Optional</em>. For private chats with business accounts, the opening hours of the business</summary>
    public BusinessOpeningHours? BusinessOpeningHours { get; set; }

    /// <summary><em>Optional</em>. For private chats, the personal channel of the user</summary>
    public Chat? PersonalChat { get; set; }

    /// <summary><em>Optional</em>. List of available reactions allowed in the chat. If omitted, then all <see cref="ReactionTypeEmoji">emoji reactions</see> are allowed.</summary>
    public ReactionType[]? AvailableReactions { get; set; }

    /// <summary><em>Optional</em>. Custom emoji identifier of the emoji chosen by the chat for the reply header and link preview background</summary>
    public string? BackgroundCustomEmojiId { get; set; }

    /// <summary><em>Optional</em>. Identifier of the accent color for the chat's profile background. See <a href="https://core.telegram.org/bots/api#profile-accent-colors">profile accent colors</a> for more details.</summary>
    public int? ProfileAccentColorId { get; set; }

    /// <summary><em>Optional</em>. Custom emoji identifier of the emoji chosen by the chat for its profile background</summary>
    public string? ProfileBackgroundCustomEmojiId { get; set; }

    /// <summary><em>Optional</em>. Custom emoji identifier of the emoji status of the chat or the other party in a private chat</summary>
    public string? EmojiStatusCustomEmojiId { get; set; }

    /// <summary><em>Optional</em>. Expiration date of the emoji status of the chat or the other party in a private chat,, if any</summary>
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime? EmojiStatusExpirationDate { get; set; }

    /// <summary><em>Optional</em>. Bio of the other party in a private chat</summary>
    public string? Bio { get; set; }

    /// <summary><em>Optional</em>. <see langword="true"/>, if privacy settings of the other party in the private chat allows to use <c>tg://user?id=&lt;UserId&gt;</c> links only in chats with the user</summary>
    public bool HasPrivateForwards { get; set; }

    /// <summary><em>Optional</em>. <see langword="true"/>, if the privacy settings of the other party restrict sending voice and video note messages in the private chat</summary>
    public bool HasRestrictedVoiceAndVideoMessages { get; set; }

    /// <summary><em>Optional</em>. <see langword="true"/>, if users need to join the supergroup before they can send messages</summary>
    public bool JoinToSendMessages { get; set; }

    /// <summary><em>Optional</em>. <see langword="true"/>, if all users directly joining the supergroup without using an invite link need to be approved by supergroup administrators</summary>
    public bool JoinByRequest { get; set; }

    /// <summary><em>Optional</em>. Description, for groups, supergroups and channel chats</summary>
    public string? Description { get; set; }

    /// <summary><em>Optional</em>. Primary invite link, for groups, supergroups and channel chats</summary>
    public string? InviteLink { get; set; }

    /// <summary><em>Optional</em>. The most recent pinned message (by sending date)</summary>
    public Message? PinnedMessage { get; set; }

    /// <summary><em>Optional</em>. Default chat member permissions, for groups and supergroups</summary>
    public ChatPermissions? Permissions { get; set; }

    /// <summary><em>Optional</em>. <see langword="true"/>, if paid media messages can be sent or forwarded to the channel chat. The field is available only for channel chats.</summary>
    public bool CanSendPaidMedia { get; set; }

    /// <summary><em>Optional</em>. For supergroups, the minimum allowed delay between consecutive messages sent by each unprivileged user; in seconds</summary>
    public int? SlowModeDelay { get; set; }

    /// <summary><em>Optional</em>. For supergroups, the minimum number of boosts that a non-administrator user needs to add in order to ignore slow mode and chat permissions</summary>
    public int? UnrestrictBoostCount { get; set; }

    /// <summary><em>Optional</em>. The time after which all messages sent to the chat will be automatically deleted; in seconds</summary>
    public int? MessageAutoDeleteTime { get; set; }

    /// <summary><em>Optional</em>. <see langword="true"/>, if aggressive anti-spam checks are enabled in the supergroup. The field is only available to chat administrators.</summary>
    public bool HasAggressiveAntiSpamEnabled { get; set; }

    /// <summary><em>Optional</em>. <see langword="true"/>, if non-administrators can only get the list of bots and administrators in the chat</summary>
    public bool HasHiddenMembers { get; set; }

    /// <summary><em>Optional</em>. <see langword="true"/>, if messages from the chat can't be forwarded to other chats</summary>
    public bool HasProtectedContent { get; set; }

    /// <summary><em>Optional</em>. <see langword="true"/>, if new chat members will have access to old messages; available only to chat administrators</summary>
    public bool HasVisibleHistory { get; set; }

    /// <summary><em>Optional</em>. For supergroups, name of the group sticker set</summary>
    public string? StickerSetName { get; set; }

    /// <summary><em>Optional</em>. <see langword="true"/>, if the bot can change the group sticker set</summary>
    public bool CanSetStickerSet { get; set; }

    /// <summary><em>Optional</em>. For supergroups, the name of the group's custom emoji sticker set. Custom emoji from this set can be used by all users and bots in the group.</summary>
    public string? CustomEmojiStickerSetName { get; set; }

    /// <summary><em>Optional</em>. Unique identifier for the linked chat, i.e. the discussion group identifier for a channel and vice versa; for supergroups and channel chats.</summary>
    public long? LinkedChatId { get; set; }

    /// <summary><em>Optional</em>. For supergroups, the location to which the supergroup is connected</summary>
    public ChatLocation? Location { get; set; }
}
