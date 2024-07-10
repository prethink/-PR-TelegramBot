using System.IO;
using Telegram.Bot.Tests.Integ.Framework;
using Telegram.Bot.Tests.Integ.Framework.Fixtures;
using Telegram.Bot.Types;

namespace Telegram.Bot.Tests.Integ.Admin_Bot;

public class ChannelAdminBotTestFixture : AsyncLifetimeFixture
{
    ChannelChatFixture _channelChatFixture;
    byte[] _oldChatPhoto;

    public ChatFullInfo Chat => _channelChatFixture.ChannelChat;
    public Message PinnedMessage { get; set; }


    public ChannelAdminBotTestFixture(TestsFixture fixture)
    {
        AddLifetime(
            initializer: async () =>
            {
                _channelChatFixture = new(fixture, Constants.TestCollections.ChannelAdminBots);
                await _channelChatFixture.InitializeAsync();
                // Save existing chat photo as byte[] to restore it later because Bot API 4.4+ invalidates old
                // file_ids after changing chat photo
                if (!string.IsNullOrEmpty(Chat.Photo?.BigFileId))
                {
                    await using MemoryStream stream = new();
                    await fixture.BotClient.GetInfoAndDownloadFileAsync(Chat.Photo.BigFileId, stream);
                    _oldChatPhoto = stream.ToArray();
                }
            },
            finalizer: async () =>
            {
                // If chat had a photo before, reset the photo back.
                if (_oldChatPhoto is not null)
                {
                    await using MemoryStream photoStream = new(_oldChatPhoto);
                    await fixture.BotClient.WithStreams(photoStream).SetChatPhotoAsync(
                        chatId: Chat.Id,
                        photo: InputFile.FromStream(photoStream)
                    );
                }

                await _channelChatFixture.DisposeAsync();
            }
        );
    }
}
