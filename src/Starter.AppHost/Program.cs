using Projects;

var builder = DistributedApplication.CreateBuilder(args);

const string prefix = "my-app";

var db = builder
    .AddSqlServer($"{prefix}-db", port: 44000)
    .WithDataVolume();

builder
    .AddProject<Command_Api>($"{prefix}-command-api")
    .WithReference(db)
    .WaitFor(db);

builder
    .AddProject<Query_Api>($"{prefix}-query-api")
    .WithReference(db)
    .WaitFor(db);

builder.Build().Run();
