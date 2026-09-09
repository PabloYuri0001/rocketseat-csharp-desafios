using Gerenciador.Aplication.Repositories;
using Gerenciador.Aplication.UseCases.Taks.Delete;
using Gerenciador.Aplication.UseCases.Taks.GetAll;
using Gerenciador.Aplication.UseCases.Taks.GetById;
using Gerenciador.Aplication.UseCases.Taks.Register;
using Gerenciador.Aplication.UseCases.Taks.Update;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(option => option.LowercaseUrls = true);

// para poder simular um banco
// vai criar uma instacia continua na mermoria em quanto o projeto estiver rodando é ele que vai inicializar a lista que vais ser emulada como banco
builder.Services.AddSingleton<TaskRepository>();

// esse vai criar instacia a cada requisição,ele que ira lincar a controler com a regra de negocio,e conseguindo acessar a lista que está emuando o banco
builder.Services.AddScoped<RegisterTaskUseCase>();
builder.Services.AddScoped<GetAllTaskUseCase>();
builder.Services.AddScoped<GetByIdUseCase>();
builder.Services.AddScoped<UpdateTaskUseCase>();
builder.Services.AddScoped<DeleteTaskUseCase>();

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
