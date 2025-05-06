using LC_VersionOne.Enums;
using LC_VersionOne.Interfaces;
using LC_VersionOne.JsonClasses;

namespace LC_VersionOne.DataTypeClasses
{
    public class StoryTest : IAsset
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
        public Scope? Scope { get; set; }
        public EAssetState? ScopeAssetState { get; set; }
        public Status? Status { get; set; }

        private string? url;
        public string? Url
        {
            get { return url; }
            set => url = $"https://www5.v1host.com{value}";
        }
    }
}
