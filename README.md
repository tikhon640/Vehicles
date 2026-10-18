# Vehicles

## Eesmärk

Vehicles on WPF rakendus, mis demonstreerib objektorienteeritud programmeerimist, pärimist, liideseid ja sündmuste kasutamist.

## Klassid

### Vehicle

Abstraktne baasklass kõikidele sõidukitele.

### Car

Sõiduk, mis saab sõita.

### Boat

Sõiduk, mis saab ujuda.

### AmphibiousCar

Sõiduk, mis saab nii sõita kui ujuda.

### Garage

Garaaž, mis haldab sõidukeid ja sündmusi.

## Liidesed

### IDriveable

Võimaldab sõidukil sõita.

### ISwimmable

Võimaldab sõidukil ujuda.

## Funktsionaalsus

- Sõiduki lisamine
- Sõiduki eemaldamine
- Sõiduki valimine
- Sõitmine
- Ujumine
- Läbisõidu jälgimine
- Tegevuste logi

## Garaažid

Rakenduses kasutatakse kahte garaaži:

- Garage A
- Garage B

Mõlemas garaažis saab:

- lisada sõidukeid
- valida sõidukeid
- eemaldada sõidukeid

## Sündmused

### Lisamine

Kui sõiduk lisatakse garaaži:

- lisamine salvestatakse logisse
- teised garaaži sõidukid annavad signaali

### Eemaldamine

Kui sõiduk eemaldatakse garaažist:

- eemaldamine salvestatakse logisse
- ülejäänud sõidukid vilgutavad tulesid

## Kasutatud OOP põhimõtted

- Pärimine
- Polümorfism
- Abstraktne klass
- Liidesed
- Kapseldamine

## Käivitamine

1. Ava lahendus Visual Studios.
2. Määra käivitatavaks projektiks Vehicles.WpfApp.
3. Build Solution.
4. Käivita rakendus.

## AI kasutamine

Kasutasin tehisintellekti õppematerjalide selgitamiseks, lahenduse kontrollimiseks ja dokumentatsiooni koostamiseks. Lõpliku lahenduse koostasin ja testisin iseseisvalt.
