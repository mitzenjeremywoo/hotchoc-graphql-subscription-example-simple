using MySubscriptionApp;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    //.ConfigureSchema(sb => sb.ModifyOptions(opts => opts.StrictValidation = false))
    .AddSubscriptionType<Subscription>()
    .AddMutationType<Mutation>()
    .AddQueryType<Query>()
    .AddInMemorySubscriptions();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGraphQL();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseWebSockets();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
