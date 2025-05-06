// See https://aka.ms/new-console-template for more information
using LC_VersionOne.DataTypeClasses;
using LC_VersionOne;

Console.WriteLine("Hello, World!");

var result = await VersionOne.GetAsync("https://www5.v1host.com/TheLakeCompaniesInc26/rest-1.v1/Data/Story?sel=Name" +
            ",Number" +
            ",Description" +
            ",Scope" +
            ",Scope.AssetState" +
            ",AssetState" +
            ",Status" +
            ",Status.AssetState" +
            ",Custom_CodeSweeps" +
            ",Custom_CodedIn" +
            ",Team.Name" +
            ",Owners.Name" +
            ",Category.Name" +
            "&where=Number=%27b-03458%27");
Story story = result.Assets[0].ToStory();

Console.WriteLine($"Scope.Id= {story.Scope.Value.Id}");
Console.WriteLine($"Scope.AssetState= {story.ScopeAssetState.ToString()}");


Console.ReadLine();