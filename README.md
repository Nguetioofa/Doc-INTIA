## Installation de la solution

### Prerequis

- [.NET 8 SDK]
- [Visual Studio 2022]
- [Sql Server 2022]

### Étapes d'installation

1. Clonez ce dépôt :
   ```bash
   git clone https://github.com/Nguetioofa/Doc-INTIA.git
   cd Doc-INTIA
   ```

2. Restaurez les dependances :
   ```bash
   cd AntiaApp.Web
   dotnet restore
   ```

3. Configurez la base de donnees :
   - Executez le script script.sql(AntiaApp.Web\Script\script.sql) dans `Sql Server 2022`
   - Modifiez la chaine de connexion dans `appsettings.json`


4. Lancez l'application :
   ```bash
   dotnet run --project AntiaApp.Web
   ```