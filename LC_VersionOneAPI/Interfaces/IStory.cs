using LC_VersionOne.Enums;
using LC_VersionOne.JsonClasses;

namespace LC_VersionOne.Interfaces
{
    public interface IAsset
    {
        EAssetState? AssetState { get; set; }
        string? Custom_CodedIn { get; set; }
        string? Custom_CodeSweeps { get; set; }
        string? Description { get; set; }
        string? Id { get; set; }
        string? Name { get; set; }
        List<string?>? New_OwnersName { get; set; }
        string? Number { get; set; }
        List<string?>? Orig_OwnersName { get; set; }
        Scope? Scope { get; set; }
        EAssetState? ScopeAssetState { get; set; }
        Status? Status { get; set; }
        string? Url { get; set; }
    }
}