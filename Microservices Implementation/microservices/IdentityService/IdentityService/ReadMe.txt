Identity service

Packages
	Microsoft.AspNetCore.Authentication.JwtBearer

Entity Generation - from existing DB
	- Install-Package Microsoft.EntityFrameworkCore.Tools
	- Install-Package Microsoft.EntityFrameworkCore.SqlServer
	- Scaffold-DbContext "Server=LPZ-WFH-1\SQLEXPRESS;Database=IdentityDB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities