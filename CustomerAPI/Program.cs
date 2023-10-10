using System.Reflection;
using Commands;
using MediatR;
using MessageBroker;
using Publisher.Publisher;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<ISocketClient, SocketClient>();
builder.Services.AddSingleton<IPublisher<RegisterCustomerCommand>, Publisher<RegisterCustomerCommand>>();
builder.Services.AddSingleton<IPublisher<UpdateCustomerCommand>, Publisher<UpdateCustomerCommand>>();
builder.Services.AddSingleton<IPublisher<DeleteCustomerCommand>, Publisher<DeleteCustomerCommand>>();
    
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();