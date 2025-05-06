using LC_VersionOne.Enums;
using LC_VersionOne.Interfaces;
using LC_VersionOne.JsonClasses;

namespace LC_VersionOne.DataTypeClasses
{
    public class Story : IAsset
    {
        public EAssetState? AssetState { get; set; }
        public string? Custom_CodedIn { get; set; }
        public string? Custom_CodeSweeps { get; set; }
        public string? Description { get; set; }
        public string? Id { get; set; }
        public string? Name { get; set; }
        public List<string?>? New_OwnersName { get; set; }
        public string? Number { get; set; }
        public List<string?>? Orig_OwnersName { get; set; }
        public EAssetState? ScopeAssetState { get; set; }

        private string? url;
        public string? Url
        {
            get { return url; }
            set => url = $"https://www5.v1host.com{value}";
        }
        public string? TeamName { get; internal set; }
        public Scope? Scope { get; set; }
        public Status? Status { get; set; }

        public List<StoryTask>? Tasks { get; set; }
        public List<StoryTest>? Tests { get; set; }

        public Category? Category { get; set; }
    }
}
