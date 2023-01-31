var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<PhoneBookAbsa.Repositories.IPhoneBookRepository, PhoneBookAbsa.Repositories.PhoneBookRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
