# ControleMaquinas
Antes de rodar o projeto entrar no arquivo --> appsettings.json em DefaultConnection --> Data source --> **Inserir o Server name do seu banco de dados SQL**, após isso em Tools --> NuGet Package Manager --> Package Manager Console --> Comando: update-database // Após o Done. criação do banco de dados feita com sucesso

Usando os pacotes Entity Framework Core, Entity Framework Core.Design, Entity Framework Core.SqlServere e Entity Framework Core.Tools
Funcionalidades de banco de máquinas --> **get** retorna todas as máquinas cadastradas, **get por status** de máquina, **post** cria nova máquina, **put** atualiza máquina, **delete** deleta máquina por id

Apenas a api backend .net foi criada.
