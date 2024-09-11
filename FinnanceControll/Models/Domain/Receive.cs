using System;

namespace FinnanceControll.Models.Domain;

public sealed class Receive:Transaction
{
    public string Identifier { get; set; } = string.Empty;
}
