***Bankomaten***

> 🔒 **Start av programmet och inloggning**
>
> - [X] När programmet startar ska användaren välkomnas till banken.
> - [X] Användaren ska mata in sitt användarnummer/användarnamn (valfritt hur detta ser ut) och en pin-kod som ska avgöra vilken användare det är som vill använda bankomaten.
> - [x] Bankomaten ska ha 5 olika användare som ska kunna använda den. Det behöver inte gå att lägga till fler användare.
> - [x] Om användaren skriver in fel pinkod tre gånger ska det inte gå att försöka logga in igen utan att starta om programmet.

> 🧭 **Navigera som användare**
>
> - [x] När användaren lyckats logga in ska bankomaten fråga vad användaren vill göra. Det ska finnas fyra val:
> 
>     ```csharp
>     1. Se dina konton och saldo
>     2. Överföring mellan konton
>     3. Ta ut pengar
>     4. Logga ut
>     ```
>
> - [x] Användaren ska kunna välja en av funktionerna ovan genom att skriva in en siffra.
> - [x] När en funktion har kört klart ska användaren få upp texten "Klicka enter för att komma till huvudmenyn". När användaren klickat enter kommer menyn upp igen.
> - [x] Om användaren väljer "Logga ut" ska programmet inte stängas av. Användaren ska komma tillbaka till inloggningen igen.
> - [x] Om användaren skriver ett nummer som inte finns i menyn, eller något annat än ett nummer, ska systemet meddela att det är ett "ogiltigt val".

> 🔢 **Se konton och saldo**
>
> - [x] Denna funktion ska köras när användaren navigerat in till alternativet "Se dina konton och saldo".
> - [x] Användaren ska få en utskrift av de olika konton som användaren har och hur mycket pengar det finns på dessa.
> - [x] Konton ska kunna ha både kronor och ören.
> - [x] Alla användare ska ha olika antal konton och alla ska ha minst ett konto.
> - [x] Varje konto ska ha ett namn, ex. "lönekonto" eller "sparkonto".
> - [x] Saldon för alla konton sätts vid starten av programmet (du ställer in en summa som finns på varje konto i koden) så om programmet startas om återställs alla saldon.

> 🔁 **Överföring mellan konton**
>
> - [x] Denna funktion ska köras när användaren navigerat in till alternativet "Överföring mellan konton".
> - [x] Användaren ska kunna välja ett konto att ta pengar från, ett konto att flytta pengarna till och sen en summa som ska flyttas mellan dessa.
> - [x] Denna summa ska sedan flyttas mellan dessa konton och efteråt ska användaren få se vilken summa som finns på de två konton som påverkades.

> ⏏️ **Ta ut pengar**
>
> - [x] Denna funktion ska köras när användaren navigerat in till alternativet "Ta ut pengar".
> - [x] Användaren ska kunna välja ett av sina konton samt en summa att ta ut.
> - [x] Efter detta måste användaren skriva in sin pinkod för att bekräfta att de vill ta ut pengar.
> - [x] Lägg till ett felmeddelande om användaren försöker ta ut mer pengar än vad som finns på kontot.
> - [x] Pengarna ska sedan tas bort från det konto som valdes.
> - [x] Sist av allt ska systemet skriva ut det nya saldot på det kontot.
