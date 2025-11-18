## Installation de la solution

### Prerequis

- [.NET 8 SDK]
- [Visual Studio 2022]

### Étapes d'installation

1. Clonez ce dépôt :
   ```bash
   git clone https://github.com/Nguetioofa/Doc-INTIA.git
   cd Doc-INTIA
   ```

2. Restaurez les dependances :
   ```bash
   dotnet restore
   ```

3. Configurez la base de donnees :
   - Modifiez la chaine de connexion dans `appsettings.json`


4. Lancez l'application :
   ```bash
   dotnet run --project AntiaApp.Web
   ```