using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews()
	.AddNewtonsoftJson(options =>
	{
		options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
		options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
		options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
		options.SerializerSettings.Formatting = Formatting.Indented;
	});

var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();
