

using Telegram.Bot.Types.Enums;
using Xunit;
using JsonSerializerOptionsProvider = Telegram.Bot.Serialization.JsonSerializerOptionsProvider;

namespace Telegram.Bot.Tests.Unit.EnumConverter;

public class ParseModeConverterTests
{
    [Theory]
    [InlineData(ParseMode.Markdown, "Markdown")]
    [InlineData(ParseMode.Html, "Html")]
    [InlineData(ParseMode.MarkdownV2, "MarkdownV2")]
    [InlineData(ParseMode.None, "None")]
    public void Should_Convert_ParseMode_To_String(ParseMode parseMode, string value)
    {
        SendMessageRequest sendMessageRequest = new() { ParseMode = parseMode };
        string expectedResult = parseMode == 0 ? "{}" : @$"{{""parse_mode"":""{value}""}}";

        string result = JsonSerializer.Serialize(sendMessageRequest, JsonSerializerOptionsProvider.Options);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(ParseMode.Markdown, "Markdown")]
    [InlineData(ParseMode.Html, "Html")]
    [InlineData(ParseMode.MarkdownV2, "MarkdownV2")]
    [InlineData(ParseMode.None, "None")]
    public void Should_Convert_String_To_ParseMode(ParseMode parseMode, string value)
    {
        SendMessageRequest expectedResult = new() { ParseMode = parseMode };
        string jsonData = @$"{{""parse_mode"":""{value}""}}";

        SendMessageRequest? result = JsonSerializer.Deserialize<SendMessageRequest>(jsonData, JsonSerializerOptionsProvider.Options);

        Assert.NotNull(result);
        Assert.Equal(expectedResult.ParseMode, result.ParseMode);
    }

    [Fact]
    public void Should_Return_Zero_For_Incorrect_ParseMode()
    {
        string jsonData = @$"{{""parse_mode"":""{int.MaxValue}""}}";

        SendMessageRequest? result = JsonSerializer.Deserialize<SendMessageRequest>(jsonData, JsonSerializerOptionsProvider.Options);

        Assert.NotNull(result);
        Assert.Equal((ParseMode)0, result.ParseMode);
    }


    class SendMessageRequest
    {
        [JsonRequired]
        public ParseMode ParseMode { get; init; }
    }
}
