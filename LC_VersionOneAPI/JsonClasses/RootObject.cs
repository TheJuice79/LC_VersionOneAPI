using LC_VersionOne.DataTypeClasses;
using LC_VersionOne.Enums;
using LC_VersionOne;
using Newtonsoft.Json;

namespace LC_VersionOne.JsonClasses
{
    public class RootObject
    {
        public List<Asset>? Assets { get; set; }
    }
    public class Asset
    {
        public string? href { get; set; }
        public string? id { get; set; }
        public Attributes? Attributes { get; set; }

        public Story ToStory()
        {
            Story story = new()
            {
                Id = id,
                //Category = VersionOne.StoryCategories.Where(c => c.Name),
                Url = href,
                Name = Attributes?.Name?.Value,
                Number = Attributes?.Number?.Value,
                Description = Attributes?.Description?.Value,
                AssetState = (EAssetState)Enum.Parse(typeof(EAssetState), Attributes?.AssetState?.Value!),
                Orig_OwnersName = Attributes?.OwnersName?.Value,
                New_OwnersName = Attributes?.OwnersName?.Value,
                TeamName = Attributes?.TeamName?.Value,
                Custom_CodeSweeps = Attributes?.Custom_CodeSweeps?.Value,
                Custom_CodedIn = Attributes?.Custom_CodedIn?.Value,
                Scope = Attributes?.Scope,
                Status = Attributes?.Status,
                ScopeAssetState = Attributes?.ScopeAssetState?.Value == null ? null : (EAssetState)Enum.Parse(typeof(EAssetState), Attributes?.ScopeAssetState?.Value!),
            };

            story.Tasks
        }

        public Member ToMember() => new()
        {
            Id = id,
            Email = Attributes?.Email?.Value,
            Name = Attributes?.Name?.Value,
            Nickname = Attributes?.Nickname?.Value,
            Username = Attributes?.Username?.Value,
            Url = href
        };

        public Category ToCategory() => new()
        {
            Id = id,
            Name = Attributes?.Name?.Value,
            Url = href
        };

        public Category ToStatus() => new()
        {
            Id = id,
            Name = Attributes?.Name?.Value,
            Url = href
        };

    }
    public class Attributes
    {
        public Attribute? Email { get; set; }
        public Attribute? Name { get; set; }
        public Attribute? Number { get; set; }
        public Attribute? Description { get; set; }

        [JsonProperty("Category.Name")]
        public Attribute? CategoryName { get; set; }
        public Attribute? AssetState { get; set; }

        [JsonProperty("Scope.AssetState")]
        public Attribute? ScopeAssetState { get; set; }

        [JsonProperty("Custom_CodeSweeps")]
        public Attribute? Custom_CodeSweeps { get; set; }


        [JsonProperty("Custom_CodedIn")]
        public Attribute? Custom_CodedIn { get; set; }

        [JsonProperty("Team.Name")]
        public Attribute? TeamName { get; set; }
        public Scope? Scope { get; set; }
        public Status? Status { get; set; }

        [JsonProperty("Owners.Name")]
        public OwnersNames? OwnersName { get; set; }
        public Attribute? Nickname { get; set; }
        public Attribute? Username { get; set; }
    }
    public class Attribute
    {
        [JsonProperty("value")]
        public string? Value { get; set; }
    }
    public class OwnersNames
    {
        [JsonProperty("value")]
        public List<string?>? Value { get; set; }
    }

    public class Status
    {
        [JsonProperty("value")]
        public Value? Value { get; set; }
    }

    public class Scope
    {
        [JsonProperty("value")]
        public Value? Value { get; set; }
    }


    public class Value
    {
        [JsonProperty("idref")]
        public string? Idref { get; set; }
        public string? Id => Idref?[(Idref.IndexOf(':') + 1)..];

        [JsonProperty("href")]

        private string? url;
        public string? Url
        {
            get { return url; }
            set => url = $"https://www5.v1host.com{value}";
        }
    }
}
