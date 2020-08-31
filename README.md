# TrueBeauty

Aplikacja WPF "TrueBeauty" jest projektem końcowym zaliczającym przedmiot MAS - Modelowanie i Analiza Systemów informacyjnych. Celem aplikacji było umożliwienie przeprowadzenia, krótkiego procesu biznesowego polegającego na zapisie klienta na zabieg.
# Opis przebiegu
•	Wstęp:
Klient przychodzi do kliniki i zgłasza chęć odbycia zabiegu.
•	Po stronie pracownika zwykłego:
Pracownik sprawdza czy klient nie jest lekarzem. Jeśli nim jest, w formularzu dodającym klienta zaznacza się checkbox wyłączający wszystkie input'y(np. imie, nazwisko itd.), ale jednocześnie udostępniający ComboBox z listą wszystkich lekarzy(pobranych z bazy). Po wyborze lekarza zatwierdza się dodanie przyciskiem "Dodaj" i klient jest zapisywany w bazie. Jeśli jednak klient nie jest lekarzem, pracownik wypełnia wszystkie wymagane inputy i również zatwierdza dodanie wciskając przycisk "Dodaj". Pracownik zwykły ma również możliwość dodawania i usuwania lekarzy w zakładce "Lekarze".
•	Po stronie lekarza:
W widoku lekarza, dostępne są dwie tabele, na które ma on wpływ. Tabela z listą klientów nieobsłużonych i obsłużonych. Po dodaniu przez pracownika zwykłego nowego klienta pojawia się on również po stronie lekarza w tabeli klientów nieobsłużonych. Tutaj lekarz po wyborze konkretnego klienta z tabeli i wciśnięcia przycisku "Przeprowadź wizytę" ma możliwość wprowadzenia informacji na temat przeprowadzonej wizyty konsultacyjnej dla tego klienta. Wprowadzanymi danymi są informacje na temat daty wizyty, opisu przebiegu, sali w której odbyła się wizyta oraz użytego sprzętu. W każdej sali znajduje się wiele sprzętów, lecz każdy sprzęt jest przypisany do konkretnej sali, dlatego przy zmianie w ComboBox numeru sali automatycznie w ComoboBox'ach do wyboru użytych sprzętów zmienia się dostępny sprzęt na taki jaki jest przypisany w bazie do wybranej sali. Lekarz dodatkowo zaznacza czy czy jego decyzja jest pozytywna czy negatywna na temat omawianego zabiegu. Po wciśnięciu przycisku "Dodaj" kończącego wprowadzanie danych na temat wizyty konsultacyjnej, automatycznie klient jest usuwany z tabeli klientów nieobsłużonych i pojawia się w tabeli klientów obsłużonych. W tabeli klientów obsłużonych lekarz po wyborze klienta i wciśnięciu przycisku "Wyświetl szczegóły wizyty" zobaczy w oddzielnym oknie informacje na temat wcześniej wprowadzonych danych wizyty konsultacyjnej tego klienta.
# Decyje implementacyjne
•	Klasyfikacja „overlapping” dla klienta i lekarza - w związku z tym, iż dziedziczenie tego rodzaju nie występuje w językach m.in. Java/C#, skorzystałem z zamiany na kompozycję.
•	Kompozycja – została ona przeze mnie zaimplementowana za pomocą utworzenia specjalnych konstruktorów prywatnych i dodania specjalnych metod przypisujących nowy element do kompozycji.
•	Do stworzenia bazy danych zostało przeze mnie wykorzystane Entity Framework (podejście code-first).
•	Asocjacje - Asocjację implementuję za pomocą natywnych referencji języka C# oraz odpowiednich metod.
•	Trwałość ekstensji – została ona zapewniona poprzez zapis do bazy danych Microsoft SQL Server.

