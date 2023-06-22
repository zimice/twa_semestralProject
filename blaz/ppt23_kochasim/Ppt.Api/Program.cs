using Ppt.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(corsOptions => corsOptions.AddDefaultPolicy(policy =>
    policy.WithOrigins("https://localhost:1111")
    .WithMethods("GET", "POST", "PUT", "DELETE")
    .AllowAnyHeader()
));


var app = builder.Build();

//někde za definicí proměnné app
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using var hospitalContext = new HospitalContext();
var equipments = hospitalContext.HospitalEquipment.ToList();

using var loginContext = new LoginContext();
var users = loginContext.Users.ToList();

List<VybaveniVm> seznam; 
//seznam = VybaveniVm.VratRandSeznam();
seznam = equipments;

List<User> userList = users;

app.MapPost("/login", (User incomingUser) =>
{
    bool isCorrect = userList.Contains(incomingUser);
    if (isCorrect == false)
        return Results.NotFound("Tato položka nebyla nalezena!!");
    return Results.Ok();

});

app.MapGet("/vybaveni", () =>
{
    return seznam;
});


app.MapPost("/vybaveni", (VybaveniVm prichoziModel) =>
{
    int id = new Random().Next(1,300000);
    prichoziModel.Id = id;
    seznam.Insert(0, prichoziModel);
    return id;

});

app.UseHttpsRedirection();


app.MapDelete("/vybaveni/{Id}", (int Id) =>
{
    var item = seznam.SingleOrDefault(x => x.Id == Id);
    if (item == null)
        return Results.NotFound("Tato položka nebyla nalezena!!");
    seznam.Remove(item);
    return Results.Ok();
}
);

app.MapPut("/vybaveni/{Id}", (VybaveniVm prichoziModel) => {
    var item = seznam.SingleOrDefault(x => x.Id == prichoziModel.Id);
    if (item == null)
        return Results.NotFound("Tato položka nebyla nalezena!!");
    seznam.Remove(item);
    seznam.Insert(0,prichoziModel);
    return Results.Ok();

});


app.Run();
