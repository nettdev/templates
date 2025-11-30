#:sdk Cake.Sdk@6.0.0

var target = Argument<string>("target");
var version = Argument<string>("packageVersion");

Information(target);
Information(version);

Task("Clean").Does(() =>
{
    CleanDirectory($"./dist");
});

Task("Pack").IsDependentOn("Clean").Does(() =>
{
    DotNetPack("./src/Templates.csproj", new DotNetPackSettings
    {
        OutputDirectory = "./dist",
        MSBuildSettings = new() { PackageVersion = version }
    });
});

Task("Publish").IsDependentOn("Pack").Does(() =>
{
    DotNetNuGetPush("./dist/*.nupkg", new DotNetNuGetPushSettings
    {
        Source = "https://git.nett.dev/api/packages/nett/nuget/index.json",
        ApiKey = EnvironmentVariable("NUGET_API_KEY")
    });

    DeleteDirectory("./dist", new() { Recursive = true });
});

RunTarget(target); 
