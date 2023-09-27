using FluentValidation;
using ImageFileValidation;
using ImageFileValidation.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//register validators
builder.Services.AddTransient<IFileValidator>(sp => new FileSizeValidation(1024 * 1024));
builder.Services.AddTransient<IFileValidator>(sp => new FileTypeValidation(new string[] { ".jpg", ".jpeg", ".png" }));

builder.Services.AddValidatorsFromAssemblyContaining<FileValidationChain>();

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
