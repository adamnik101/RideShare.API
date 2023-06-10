
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
1. Brendova automobila
2. Modela automobila
3. Gradova
4. Boja
5. Restrikcija automobila
6. Voznji
7. Tipova automobila
8. Putnika za voznju
> Brisanje
1. Brendova automobila
2. Automobila
3. Gradova
4. Boja
5. Modela automobila
6. Restrikcija automobila
7. Voznji
8. Tipova automobila
> Dohvatanje i pretraga
1. Svih brendova automobila i jednog brenda
2. Svih modela automobila i jednog modela
3. Svih modela brendova automobila 
4. Svih slucajeva koriscenja 
5. Svih automobila korisnika i jednog automobila
6. Svih restrikcija i jedne restrikcije
7. Svih voznji i jedne voznje
8. Svih tipova automobila i jednog tipa automobila
9. Svih gradova i jednog grada
10. Svih boja i jedne boje
