namespace Yunhu.Test.Util;

using System.Text.Json.Serialization;

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(Config))]
internal partial class SourceGenerationContext : JsonSerializerContext;