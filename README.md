***Bankomaten***

<details><summary>Uppgiften</summary> 
  
<details>
  <summary>🔒 Start av programmet och inloggning</summary>

  När programmet startar ska användaren välkomnas till banken.
  Användaren ska mata in sitt användarnummer/användarnamn (valfritt hur detta ser ut) och en pin-kod som ska avgöra vilken användare det är som vill använda bankomaten.
  Bankomaten ska ha 5 olika användare som ska kunna använda den. Det behöver inte gå att lägga till fler användare.
  Om användaren skriver in fel pinkod tre gånger ska det inte gå att försöka logga in igen utan att starta om programmet.
  
</details>

<details>
  <summary>🧭 Navigera som användare</summary>

  När användaren lyckats logga in ska bankomaten fråga vad användaren vill göra. Det ska finnas fyra val:

  1. Se dina konton och saldo
  2. Överföring mellan konton
  3. Ta ut pengar
  4. Logga ut
  
  Användaren ska kunna välja en av funktionerna ovan genom att skriva in en siffra.
  När en funktion har kört klart ska användaren få upp texten "Klicka enter för att komma till huvudmenyn". När användaren klickat enter kommer menyn upp igen.
  Om användaren väljer "Logga ut" ska programmet inte stängas av. Användaren ska komma tillbaka till inloggningen igen.
  Om användaren skriver ett nummer som inte finns i menyn, eller något annat än ett nummer, ska systemet meddela att det är ett "ogiltigt val".
  
</details>

<details>
  <summary>🔢 Se konton och saldo</summary>

  Denna funktion ska köras när användaren navigerat in till alternativet "Se dina konton och saldo".
  Användaren ska få en utskrift av de olika konton som användaren har och hur mycket pengar det finns på dessa.
  Konton ska kunna ha både kronor och ören.
  Alla användare ska ha olika antal konton och alla ska ha minst ett konto.
  Varje konto ska ha ett namn, ex. "lönekonto" eller "sparkonto".
  Saldon för alla konton sätts vid starten av programmet (du ställer in en summa som finns på varje konto i koden) så om programmet startas om återställs alla saldon.
  
</details>

<details>
  <summary>🔁 Överföring mellan konton</summary>

  Denna funktion ska köras när användaren navigerat in till alternativet "Överföring mellan konton".
  Användaren ska kunna välja ett konto att ta pengar från, ett konto att flytta pengarna till och sen en summa som ska flyttas mellan dessa.
  Denna summa ska sedan flyttas mellan dessa konton och efteråt ska användaren få se vilken summa som finns på de två konton som påverkades.
  
</details>

<details>
  <summary>⏏️ Ta ut pengar</summary>

  Denna funktion ska köras när användaren navigerat in till alternativet "Ta ut pengar".
  Användaren ska kunna välja ett av sina konton samt en summa att ta ut.
  Efter detta måste användaren skriva in sin pinkod för att bekräfta att de vill ta ut pengar.
  Lägg till ett felmeddelande om användaren försöker ta ut mer pengar än vad som finns på kontot.
  Pengarna ska sedan tas bort från det konto som valdes.
  Sist av allt ska systemet skriva ut det nya saldot på det kontot.
  </details>
</details>
