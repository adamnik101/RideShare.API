
# WEB programiranje ASP - Projekat

Aplikacija sluzi za deljenje voznje. Autorizovan korisnik moze da dodaje voznje i svoje automobile. Dok drugi autorizovani korisnici mogu da se prijave da budu putnici. Neautorizovani korisnici mogu da pretrazuju voznje.
Administratori mogu da dohvataju, dodaju i brisu podatke. 
// izmena jos nije odradjena.
Takodje mogu da pretrazuju i dohvataju slucajeve koriscenja. 

Autorizacija pomocu JWT tokena.

Slanje mejla prilikom registracije.

Unos fajla tj. slike pomocu base64 prilikom unosa automobila autorizovanog korisnika.

Use cases:
> Autorizacija
1. Logovanje [HttpPost] /auth
2. Registracija [HttpPost] /users

> Brendovi automobila
1. Dohvatanje brendova [HttpGet] /brands
2. Dohvatanje jednog brenda [HttpGet] /brands/{id}
3. Dohvatanje modele brendova [HttpGet] /brands/{id}/models
4. Dodavanje brenda [HttpPost] /brands
5. Brisanje brenda [HttpDelete] /brands/{id}

> Automobili
1. Dohvatanje automobila [HttpGet] /cars
2. Dohvatanje jednog automobila [HttpGet] /cars/{id}
3. Dodavanje automobila [HttpPost] /cars
4. Brisanje automobila [HttpDelete] /cars/{id}

.....
