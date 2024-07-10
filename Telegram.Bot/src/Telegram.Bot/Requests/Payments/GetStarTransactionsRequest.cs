﻿namespace Telegram.Bot.Requests;

/// <summary>Returns the bot's Telegram Star transactions in chronological order.<para>Returns: A <see cref="StarTransactions"/> object.</para></summary>
public partial class GetStarTransactionsRequest : RequestBase<StarTransactions>
{
    /// <summary>Number of transactions to skip in the response</summary>
    public int? Offset { get; set; }

    /// <summary>The maximum number of transactions to be retrieved. Values between 1-100 are accepted. Defaults to 100.</summary>
    public int? Limit { get; set; }

    /// <summary>Instantiates a new <see cref="GetStarTransactionsRequest"/></summary>
    public GetStarTransactionsRequest() : base("getStarTransactions") { }
}
