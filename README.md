
# WEB programiranje ASP - Projekat

Aplikacija sluzi za deljenje voznje. Autorizovan korisnik moze da dodaje voznje i svoje automobile. Dok drugi autorizovani korisnici mogu da se prijave da budu putnici. Neautorizovani i autorizovani korisnici mogu da pretrazuju voznje.
Administratori mogu da dohvataju, dodaju i brisu podatke(brendovi, modeli, restrikcije za automobile, gradove, automobile, boje, tipove automobila). [izmena treba da se doda]
Takodje mogu da pretrazuju i dohvataju slucajeve koriscenja. 
Paginacija je dodata za entitete gde je moguc broj rezultata biti veci.
Autorizacija pomocu JWT tokena.
Slanje mejla prilikom registracije. 
Unos fajla tj. slike pomocu base64 prilikom unosa automobila autorizovanog korisnika.

Use cases:
> Autorizacija
1. Logovanje [HttpPost] /auth
2. Registracija [HttpPost] /users

> Kreiranje
1. Brendova automobila  `Admin`
2. Modela automobila  `Admin`  
3. Gradova  `Admin`
4. Boja `Admin`
5. Restrikcija automobila `Admin`
6. Tipova automobila  `Admin`
7. Voznji `Autorizovani korisnik`
8. Putnika za voznju  `Autorizovani korisnik`
> Brisanje
1. Brendova automobila  `Admin`
2. Automobila `Admin` `Autorizovani korisnik`
3. Gradova  `Admin`
4. Boja `Admin`
5. Modela automobila  `Admin`
6. Restrikcija automobila `Admin`
7. Voznji `Admin` `Autorizovani korisnik`
8. Tipova automobila  `Admin`
> Dohvatanje i pretraga
1. Svih brendova automobila i jednog brenda `Admin`
2. Svih modela automobila i jednog modela `Admin`
3. Svih modela brendova automobila  `Admin`
4. Svih slucajeva koriscenja  `Admin`
5. Svih automobila korisnika i jednog automobila  `Autorizovani korisnik`
6. Svih restrikcija i jedne restrikcije `Admin`
7. Svih voznji i jedne voznje `Admin`
8. Svih tipova automobila i jednog tipa automobila  `Admin`
9. Svih gradova i jednog grada  `Admin`
10. Svih boja i jedne boje  `Admin`
