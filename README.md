
# WEB programiranje ASP - Projekat

The application is used for ride sharing. Authorized users can add rides and their own cars, while other authorized users can sign up to be passengers. Unauthorized and authorized users can search for rides. Administrators can retrieve, add, and delete data (users, brands, models, car restrictions, cities, cars, colors, car types). [The update needs to be added] They can also search for and retrieve usage cases. Pagination is added for entities with a larger number of results. Authorization is done using JWT tokens. An email is sent during registration. File or image input using base64 is used when adding a car for an authorized user. *Adding ratings after a ride has not been implemented yet.

>Kredencijali za admina:
`email: luke@gmail.com
 password: sifra1`
 
>Dizajn baze podataka

![image](https://github.com/adamnik101/RideShare.API/assets/58403484/32aaae29-e24f-4dae-9a4f-953622dae101)

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
11. Svih korisnika sistema `Admin`
12. Informacija o korisniku i njegovim automobilima i voznjama `Admin` `Autorizovani korisnik`
