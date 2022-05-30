# .NET OpenTelemetry demo

Project is generated using `dotnet new webapp`

## Install additional packages

```
dotnet add package OpenTelemetry --prerelease
dotnet add package OpenTelemetry.Exporter.OpenTelemetryProtocol --prerelease
dotnet add package OpenTelemetry.Extensions.Hosting --prerelease
dotnet add package OpenTelemetry.Instrumentation.AspNetCore --prerelease
dotnet add package OpenTelemetry.Instrumentation.Http --prerelease
dotnet add package OpenTelemetry.Instrumentation.SqlClient --prerelease
```
# Add configuration in `Program.cs` file

Changes to Program.cs are wrapped with `#region` pragmas.
