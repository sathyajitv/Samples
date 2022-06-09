https://stackoverflow.com/questions/48185894/when-to-use-tryaddsingleton-or-addsingleton

When multiple registrations exist for the same service type, but a single instance is requested, .NET Core will always return the last one registered. 
For collection resolution however, AddSingleton behaves as a collection ‘append’ of already existing registrations for that service type. 

Links:
.NET Generic Host in ASP.NET Core
1. Add a PackageReference to Microsoft.Extensions.Hosting 
	PM> install-package Microsoft.Extensions.Hosting
https://dfederm.com/building-a-console-app-with-.net-generic-host/
https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-6.0

