﻿using Ppt.Shared;

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

List<VybaveniVm> seznam = VybaveniVm.VratRandSeznam();

app.MapGet("/vybaveni", () =>
{
    return seznam;
});
app.MapGet("/vybaveni/specific", ()=>{
    
    return seznam[2]; 

});

app.MapPost("/vybaveni", (VybaveniVm prichoziModel) =>
{
    Guid id = Guid.NewGuid();
    prichoziModel.Id = id;
    seznam.Insert(0, prichoziModel);
    return id;

});

app.UseHttpsRedirection();


app.MapDelete("/vybaveni/{Id}", (Guid Id) =>
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
