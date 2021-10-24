# API .Net Core 5 + EF Core
O projeto desta API de uso genérico implementa as seguintes tecnologias :
- .Net Core 5
- AutoMapper
- Microsoft.EntityFrameworkCore (Database first)
- System.IdentityModel.Tokens.Jwt
- EnterpriseLibrary.Validation.NetCore
- Swashbuckle.AspNetCore

## Banco de dados SQL Server

```SQL
CREATE TABLE [dbo].[Login](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[CreatedAt] [datetime] NULL,
	[ModifiedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
```
## Log de execução EF Core
A exibição das consultas geradas pelo EF Core estão habilitadas no modo Debug (incluindo dados sensíveís) e podem ser conferidas na **janela de saída** em tempo de execução.

Esta configuração é feita na classe Startup.cs do projeto da API, dentro do método **ConfigureServices** da seguinte forma

```c#
#if DEBUG
            services.AddDbContext<MyDbContext>(opt => {
                opt.UseSqlServer(Configuration.GetConnectionString("default"));
                opt.EnableSensitiveDataLogging(true);
                opt.LogTo(Console.WriteLine, LogLevel.Debug, DbContextLoggerOptions.DefaultWithUtcTime);
            });
#else
            services.AddDbContext<EasyCreditDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("default")));
#endif
```
