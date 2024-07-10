using Telegram.Bot.Types.Passport;
using Xunit;
using JsonSerializerOptionsProvider = Telegram.Bot.Serialization.JsonSerializerOptionsProvider;

namespace Telegram.Bot.Tests.Unit.EnumConverter;

public class EncryptedPassportElementTypeConverterTests
{
    [Theory]
    [InlineData(EncryptedPassportElementType.PersonalDetails, "personal_details")]
    [InlineData(EncryptedPassportElementType.Passport, "passport")]
    [InlineData(EncryptedPassportElementType.DriverLicense, "driver_license")]
    [InlineData(EncryptedPassportElementType.IdentityCard, "identity_card")]
    [InlineData(EncryptedPassportElementType.InternalPassport, "internal_passport")]
    [InlineData(EncryptedPassportElementType.Address, "address")]
    [InlineData(EncryptedPassportElementType.UtilityBill, "utility_bill")]
    [InlineData(EncryptedPassportElementType.BankStatement, "bank_statement")]
    [InlineData(EncryptedPassportElementType.RentalAgreement, "rental_agreement")]
    [InlineData(EncryptedPassportElementType.PassportRegistration, "passport_registration")]
    [InlineData(EncryptedPassportElementType.TemporaryRegistration, "temporary_registration")]
    [InlineData(EncryptedPassportElementType.PhoneNumber, "phone_number")]
    [InlineData(EncryptedPassportElementType.Email, "email")]
    public void Should_Convert_EncryptedPassportElementType_To_String(EncryptedPassportElementType encryptedPassportElementType, string value)
    {
        EncryptedPassportElement encryptedPassportElement = new() { Type = encryptedPassportElementType };
        string expectedResult = @$"{{""type"":""{value}""}}";

        string result = JsonSerializer.Serialize(encryptedPassportElement, JsonSerializerOptionsProvider.Options);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(EncryptedPassportElementType.PersonalDetails, "personal_details")]
    [InlineData(EncryptedPassportElementType.Passport, "passport")]
    [InlineData(EncryptedPassportElementType.DriverLicense, "driver_license")]
    [InlineData(EncryptedPassportElementType.IdentityCard, "identity_card")]
    [InlineData(EncryptedPassportElementType.InternalPassport, "internal_passport")]
    [InlineData(EncryptedPassportElementType.Address, "address")]
    [InlineData(EncryptedPassportElementType.UtilityBill, "utility_bill")]
    [InlineData(EncryptedPassportElementType.BankStatement, "bank_statement")]
    [InlineData(EncryptedPassportElementType.RentalAgreement, "rental_agreement")]
    [InlineData(EncryptedPassportElementType.PassportRegistration, "passport_registration")]
    [InlineData(EncryptedPassportElementType.TemporaryRegistration, "temporary_registration")]
    [InlineData(EncryptedPassportElementType.PhoneNumber, "phone_number")]
    [InlineData(EncryptedPassportElementType.Email, "email")]
    public void Should_Convert_String_To_EncryptedPassportElementType(EncryptedPassportElementType encryptedPassportElementType, string value)
    {
        EncryptedPassportElement expectedResult = new() { Type = encryptedPassportElementType };
        string jsonData = @$"{{""type"":""{value}""}}";

        EncryptedPassportElement? result = JsonSerializer.Deserialize<EncryptedPassportElement>(jsonData, JsonSerializerOptionsProvider.Options);

        Assert.NotNull(result);
        Assert.Equal(expectedResult.Type, result.Type);
    }

    [Fact]
    public void Should_Return_Zero_For_Incorrect_EncryptedPassportElementType()
    {
        string jsonData = @$"{{""type"":""{int.MaxValue}""}}";

        EncryptedPassportElement? result = JsonSerializer.Deserialize<EncryptedPassportElement>(jsonData, JsonSerializerOptionsProvider.Options);

        Assert.NotNull(result);
        Assert.Equal((EncryptedPassportElementType)0, result.Type);
    }

    [Fact]
    public void Should_Throw_JsonException_For_Incorrect_EncryptedPassportElementType()
    {
        EncryptedPassportElement encryptedPassportElement = new() { Type = (EncryptedPassportElementType)int.MaxValue };

        // ToDo: add EncryptedPassportElementType.Unknown ?
        //    protected override string GetStringValue(EncryptedPassportElementType value) =>
        //        EnumToString.TryGetValue(value, out var stringValue)
        //            ? stringValue
        //            : "unknown";
        Assert.Throws<JsonException>(() => JsonSerializer.Serialize(encryptedPassportElement, JsonSerializerOptionsProvider.Options));
    }


    class EncryptedPassportElement
    {
        [JsonRequired]
        public EncryptedPassportElementType Type { get; init; }
    }
}
