Beskrivning av projekt:

-Detta är en konsolapp skapad i C# med .NET 9.0.

-Projektet innehåller 3 appar. En enkel kalkylator, en app för att beräkna area och
omkrets på några enkla figurer och ett simpelt sten sax påse spel.

-Alla appar använder sig av Entity Framework för att skapa en databas som sparar alla resultat
och beräkningar. Detta görs med Code First-principen och alla tabellobjekt manipuleras
direkt i koden liknande såsom man skapar och manipulerar vanliga klassobjekt i C#. Dvs, jag
skapar en databaseContext fil utifrån en appsettings.json fil där alla inställningar och
anslutningsinformation till databasen existerar i json-objektet.

-Programmet utnyttjar följande package-dependencies för att hantera databasen:
	1. Microsoft.EntityFrameworkCore.SqlServer (9.0.3)
	2. Microsoft.EntityFrameworkCore.Tools (9.0.3)
	3. Microsoft.Extensions.Configuration.Json (9.0.3)

-Utöver det utnyttjas FluentValidation till all felhantering i apparna. Det fungerar som så att
jag har skapat separata model och valideringsklasser som kontrollerar så att inmatningen är korrekt.
Jag har dock tagit det ett steg längre och har valt att även validera typkonverteringar samt
databasvalidering i mina FluentValidation-klasser i en och samma vända. Detta är i vanliga fall
inte möjligt men istället för att använda de korrekta Property-typerna i modellerna så har jag valt
att göra alla model-properties till strängar som sedan konverteras.

-Fluent validation behöver importera följande paket:
	1. FluentValidation (11.11.0)

-I projektet så har jag arbetat med tre branches för att separera apparnas olika funktionaliteter.
Den första branchen "main" innehåller konsolappen och all dess funktionalitet. Nästa branch som bygger på main
"inputHandling" fungerar likadant men har utökats med felhantering som hindrar programmet från att krascha.
Den tredje branchen "databaseHandling" har tillägget att man även kan utnyttja CRUD-funktionlitet
mot en databas.

-Programmet använder sig av enkla while-loopar för att navigera genom de olika apparna och menyerna och
utnyttjar lokala namespace för var och en av apparna.

-Mappstrukturen speglar programmets struktur och är uppdelad i:
	1. Shapes
	2. Calculator
	3. RockPaperScissors

och innehåller specifika klasser för var och en av apparna. Det finns också generella mappar för andra delade
funktioner i:
	4. Data (Innehåller klasser till alla databastabeller)
	5. DatabaseServices (Innehåller appsettings.json options och lite metoder som pratar med databasen)
	6. Migrations (Innehåller migreringar av databasstrukturen)
	7. ValidatorModels (Innehåller alla modeller som FLuentValidation använder)
	8. Validators (Innehåller alla regler och metoder som sköter felhanteringen)

Utöver det finns övergripande klasser för programmet "Program.cs" och "ThreeInOneApp.cs"-menyn som leder till apparna.
Sen finns också en "AppValidation.cs"-klass som fungerar lite som ett interface för att kommunicera med FluentValidation-
klasserna. 

-Och till sist sparar jag strängdata i programmet i en klassfil "MenuData.cs" som sköts av "Menu.cs". Varje
gång användaren ska mata in något skapas ett menuobjekt för att skapa en strukturerad och säker metod för att
hantera programmet med ett simpelt Model-View-Controller-tänk.

-Alla appar delar samma databas vid namn "ThreeInOneApp" och följer i stort sett samma designtänk och skiljer 
sig inte så mycket från varandra. Detta ökar generaliseringen av programmet och gör det enklare att 
underhålla apparna när nya versioner ska skapas eller när de ska dela ett interface.

-Shapes (kort beskrivning)
	Appen ger användare möjlighet att beräkna area och omkrets på:
		1. en rektangel
		2. ett parallellogram
		3. en triangel
		4. en romb
	Man har också möjlighet att gå in och radera rader med information eller uppdatera en beräkning av den
	förvalda figuren.

-Calculator
	Appen ger en möjlighet att beräkna två tal (tal1 =a, tal2 = b) med:
		1. summering a+b = c
		2. subtraktion a-b = c
		3. multiplikation a*b = c
		4. division a/b = c
		5. roten ur med valfri exponent enligt a^(1/b) = c
		6. moduloberäkning enligt a mod b = c
	Även här finns funktionalitet för att radera och uppdatera beräkningar.
	
-RockPaperScissors
	Spelaren spelar ett parti sten sax påse med en datormotståndare som med uniform slumpmässighet väljer
	sten,sax eller påse som motdrag. Man spelar en bäst av tre match som kan sluta med vinst, förlust eller
	oavgjort. Spelresultaten sparas i en tabell för varje runda och en tabell för varje match. Tabellerna
	är länkade med en foreign key "RoundId" för att hitta korresponderande resultat eller om man vill joina
	resultaten. I övrigt finns det endast read och create-funktionalitet i appens databas.
