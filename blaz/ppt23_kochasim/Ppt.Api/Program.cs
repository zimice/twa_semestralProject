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
using var context = new HospitalContext();

var equipments = context.HospitalEquipment.ToList();

foreach (var equipment in equipments)
{
    Console.WriteLine($"Name: {equipment.Name}");
}

List<VybaveniVm> seznam; 
//seznam = VybaveniVm.VratRandSeznam();
seznam = equipments;

app.MapGet("/vybaveni", () =>
{
    return seznam;
});
app.MapGet("/vybaveni/specific", ()=>{
    
    return seznam[2]; 

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
