BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Przepisy" (
	"Id"	INTEGER PRIMARY KEY AUTOINCREMENT,
	"Nazwa"	TEXT NOT NULL DEFAULT 'Dobre danie',
	"typ_potrawy"	INTEGER NOT NULL DEFAULT 1,
	"kcal"	INTEGER NOT NULL DEFAULT 0,
	"ulubione"	INTEGER DEFAULT 0,
	"moj_przepis"	INTEGER NOT NULL DEFAULT 0,
	"przepis"	TEXT NOT NULL,
	"skladniki"	TEXT DEFAULT NULL,
	"skladniki2"	TEXT DEFAULT NULL
);
CREATE TABLE IF NOT EXISTS "Skladniki" (
	"Id"	INTEGER PRIMARY KEY AUTOINCREMENT,
	"Nazwa"	TEXT NOT NULL UNIQUE,
	"Kalorie"	INTEGER NOT NULL
);
CREATE TABLE IF NOT EXISTS "SkladnikiPrzepisy" (
	"Id"	INTEGER PRIMARY KEY AUTOINCREMENT,
	"SkladnikId"	INTEGER NOT NULL,
	"PrzepisId"	INTEGER NOT NULL,
	"Ilosc"	INTEGER NOT NULL DEFAULT 0
);
CREATE TABLE IF NOT EXISTS "Adresy" (
	"adres_start"	TEXT,
	"adres_koniec"	TEXT,
	"ulubione"	INTEGER DEFAULT 0,
	"id_adresu"	INTEGER PRIMARY KEY AUTOINCREMENT
);
CREATE TABLE IF NOT EXISTS "Cele" 
(
	"CeleId" INTEGER PRIMARY KEY AUTOINCREMENT,
	"UzytkownikId" INT NOT NULL,
	"Waga" INT NOT NULL,
	"Plyny" INT NOT NULL,
	"Kalorie" INT NOT NULL,
	"Dystans" INT NOT NULL);

CREATE TABLE IF NOT EXISTS "Pomiary" 
(
	"PomiaryId" INTEGER PRIMARY KEY AUTOINCREMENT,
	"UzytkownikId" INT NOT NULL,
	"Waga" INT NOT NULL,
	"Plyny" INT NOT NULL,
	"Kalorie" INT NOT NULL,
	"Dystans" INT NOT NULL
	"DataCzas" DATETIME NOT NULL);


INSERT INTO "Przepisy" ("Id","Nazwa","typ_potrawy","kcal","ulubione","moj_przepis","przepis","skladniki","skladniki2") VALUES (1,'Kanapki  z  serkiem,  łososiem  i  warzywami',1,306,0,0,'Kromkę posmarować jogurtem, następnie położyć łososia i paprykę','50g łososia, 2 kromki chleba żytniego, 1/3 papryki czerwonej, 2 łyżeczki serka naturalnego','łosoś, filet z łososia, chleb żytni, papryka czerwona, papryka, serek naturalny'),
 (2,'Owsianka  z  grapefruitem',1,310,0,0,'Wlać jogurt do miski, następnie wymieszać z pozostałymi składnikami','1/2 grejfruta, 2/3 szklanki jogurtu naturalnego, 2 łyżki otrębów owsianych, 4 łyżki płatków owsianych','grejfrut, jogurt naturalny, otręby owsiane, płatki owsiane'),
 (3,'Kanapki  z  twarożkiem  paprykowym  i  olejem  lnianym',1,307,0,0,'Kromkę posmarowac jogurtem, następnie położc ser twarogowy, paprykę i odrobinę skropić olejem lnianym','2 kromki chleba żytniego, 1 łyżka jogurtu naturalnego, 1 łyżeczka oleju lnianego, 1/4 czerwonej papryki, 2 plastry sera twarogowego pół tłustego','chleb żytni, jogurt naturalny, olej lniany,papryka czerwona, papryka,ser twarogowy, twaróg'),
 (4,'Jaglanka  z  gruszką',1,301,0,0,'Zagrzać mleko, a następnie wsypać do mleka kaszę. Gotować, aż kasza zrobi się miękka, pokroić gruszę i wymieszać z kaszą, doprawić cynamonem','1 szczypta cynamonu, 1 sztuka gruszki, 3 łyżki kaszy jaglanej, 1 szklanka mleka 0,5%','gruszka, kasza jaglana, mleko, cynamon'),
 (5,'Owsianka  z  mandarynką  i  nasionami  chia',1,304,0,0,'Ugotować płatki owsiane z mlekiem i miodem i odstawić na 10 minut, następnie pomieszaj z nasionami chia, obrać mandarynki i udekorować owsiankę','2 mandarynki, 1 łyżeczka miodu, 3/4 szklanki mleka 0,5%,200 ml, 3 łyżki płatków owsianych, 1 łyżeczka nasion chia','mandarynki, miód, melko, płatki owsiane, nasiona chia'),
 (6,'Kanapki  ze  schabem,  pomidorkami  i  kiełkami',1,316,0,0,'Posmaruj kanapkę masłem, następnie połóż schab, pomidor i udekoruj kiełkami','2 kromki chleba żytniego, 3 łyżki kiełków rzodkiewki, 1 łyżeczka masła, 1 pomidor, 2 plastry pieczonego schabu','chleb żytni, kiełki rzodkiewki, masło, pomidor, schab pieczony'),
 (7,'Kakaowy  omlet  z  ciecierzycy  z  owocami',1,307,0,0,'Jajko wbić do miski i wymieszać z suchymi składnikami i mlekiem, następnie usmażyć. Podawać z owocami i jogurtem','1jajko kurze, 1 garść borówek amerykańskich, 1/2 garści czereśni, 1 łyżka jogurtu naturalnego, 1 łyżeczka kakao, 1 łyżka mąki pszennej, 2 łyżki mleka 0,5%, 1 łyżeczka proszku do pieczenia','jaja kurze, borówki amerykańskie, czereśnie, jogurt naturalny, kakao, mąka pszenna, mleko, proszek do pieczenia'),
 (8,'Kanapka  z  kozim  serem  i  wędzonym  łososiem  +  pomidor  z  oliwą  i  ziołami',3,223,0,0,'Na kromkę chleba położyć ser, ogórek, plaster łososia, skropić sokiem z cytryny dla smaku. Pomidor pokroić w kostkę i wymieszać z oliwą, ziołami','1 kromka chleba żytnio razowego, 1/2 łyżeczki świerzego koperku, 1 plaster łososia wędzonego, 5 plastrów ogórka, 1/2 łyżeczki natki pietruszki, 1 plaster koziego sera, 1/2 łyżeczki soku z cytryny, 1 łyżeczka oliwy z oliwek, 1 pomidor, 1 szczypta ziół prowensalskich','chleb żytno razowy, koperek, łosoś wędzony, ogórek, natka pietruszki, ser kozi, cytryna, oliwa z oliwek, pomidor, zioła prowensalskie'),
 (9,'Sałatka  z  tofu  i  awokado',3,220,0,0,'Awokado i pomidor pokroić w drobną kostkę i wymieszać z podostałymi składnikami','1/4 awokado, 1  łyżeczka oleju lnianego, 1 pomidor,1  łyżeczka nasion słonecznika, 1 łyżka tofu sałatkowego, 1 garść liści sałaty','awokado, olej lniany, pomidor, słonecznik, sałata'),
 (10,'Zupa  krem  z  kopru  włoskiego',3,237,0,0,'Na początku należy przygotować warzywa, gotować koper około 15 minut, wrzucić ziemniaka do wo wody i gotować aż będzie miękki, dorzucić cebulę pokrojoną w kostkę cebulę gotować chwilę, dodać pozostałe skłądniki i zblędować całość','1/2 dużej cebuli, 1/2 kopru włoskiego, 2 łyżeczki oliwy z oliwek, 1/2 poru, 1/2 łyżeczki kurkumy mielonej,1 szczypta pieprzu czarnego, 1 łyżeczka tymianku suszonego, 1 szczypta soli, 2 szklanki wody, 1 ziemniak','cebula, koper włoski, oliwa z oliwek, por, kurkuma, pieprz czarny, tymianek suszony, sól, ziemniaki'),
 (11,'Omlet  z  groszkiem  i  serem  feta',3,223,0,0,'Jajko wymieszać z groszkiem, maką i pieprzem. Smażyć na oleju rzepakowym, pokroić pomidorki w połówki i podać obok z omletem','1 jajko kurze, 3 łyżki groszku zielonego (mrożony/z  zalewy/puszki), 1 łyżeczka oleju rzepakowego, 1  łyżka mąki gryczanej, 3 pomidorki koktajlowe, 1  szczypta pieprzu czarnego, 2 plastry sera feta','jaja kurze, zielony groszek, olej rzepakowy, mąka gryczana, pomidory koktajlowe, pieprz czarny, ser feta'),
 (12,'Kanapka  z  pastą  soczewicowo-pietruszkową  i  ogórkiem  kiszonym',3,224,0,0,'Nasiona soczewicy zetrzeć na masę z ugotowaną pietruszką i natką, dodać sól i paprykę chili. Na kanapkę z pastą położyć pokrojonego ogórka w plastry','1 kromka chleba razowego, 1 ogórek kiszony, 1/2 cebuli, 1 łyżeczka oliwy z oliwek, 1 pietruszka, 5 łyżeczek natki pieruszki, 1/4 szklanki nasion soczewicy, 1 szczypta soli, 1 szczypta papryki chili','chleb razowy, ogórek kiszony, cebula, oliwa z oliwek, pietruszka, natka pietruszki, soczewica, sól, papryka chili'),
 (13,'Sałatka  z  pęczakiem  i  awokado',3,226,0,0,'Kaszę  pęczak  ugotować  zgodnie  z  instrukcją  na  opakowaniu.  Warzywa  pokroić  i  wymieszać  z  ugotowaną  kaszą,  porwaną sałatą i  posiekanymi  orzechami.  Sos  przygotować  poprzez  wymieszanie  soku  z  limonki  i  oliwy  ze  szczyptą  soli  i  pieprzu.  Sałatkę  polać sosem','2 łyżki kaszy pęczka, 1/4 awokado, łyżeczka świeżej bazylii, 2 łyżeczki oliwy z oliwek, 5 pistacji, 3 pomidory koktajlowe, 1 szczypta pieprzu, 2 liście sałąty lodowej, 1 łyżeczki soku z limonki','kasza pęczak, awokado, bazylia, oliwa z oliwek, pistacje, pomidory koktajlowe, pieprz, sałata lodowa, limonka'),
 (14,'Krem  z  cukinii +  grzanka  żytnia',3,239,0,0,'Cukinię zagotować razem z czosnkiem i olejem. Po ugotowaniu zetrzeć na krem, dodać pieprz, sól i natkę pieptruszki i jeszcze raz zblendować, podawać z grzanką z chleba żytniego','1 kromka chleba żytniego, 1,5 cukini, 1 ząbek czosnku, 2 łyżki jogurtu naturalnego, 2 łyżki oleju rzepakowego, 2 łyżeczki natki pietruszki, 2 szczypty pieprzu czarnego, 1 szczypta soli, 2 szklanki wody','chleb żytni, cukinia, czosnek, jogurt naturalny, olej rzepakowy, natka pietruszki, pieprz czarny, sól'),
 (15,'Grillowany  łosoś  z  ryżem  brązowym  i  surówką  z  kiszonej  kapusty  i marchewki',2,343,0,0,'Łososia  dokładnie  umyć,  natrzeć  przyprawami.  Nagrzać  patelnię  grillową  z  nieprzywierającą  powłoką  i  umieścić  na  niej  łososia. Grillować  na  początku  na  stronie  bez  skóry,  do  momentu,  aż  łosoś  zetnie  się  do  połowy  grubości.  Następnie  odwrócić  go  na drugą  stronę  i  dogrillować.  Podawać  z  plasterkiem  cytryny.  Kapustę  odcisnąć  z  soku,    a  następnie  posiekać  na  mniejsze  kawałki. Cebulę  pokroić  w  drobną  kostkę,  marchewkę  obrać  i  zetrzeć  na  tarce  o  drobnych  oczkach.  Do  kapusty  dodać  cebulę, marchewkę,  doprawić  pieprzem.  Całość  polać  oliwą  z  oliwek i wymieszać','1 filet z Łososia, papryka suszona, pieprz czarny, 1 plaster cytryny, 1/4 cebuli, 1 i 1/4 szklanki kapusty kiszonej, 1/2 marchwi, 1 łyżka oliwy z oliwek','filet z łososia, łosoś, papryka suszona, pieprz czarny, cytryna, cebyla, kapusta kiszona, marchew, oliwa z oliwek'),
 (16,'Indyk  z  kaszą  i  warzywami',2,352,0,0,'Pierś usmażyć na oleju rzepokowym, następnie podsmażyć warzywa ze startym czosnkiem, całośc podawać z kaszą ugotowaną według zaleceń na opakowaniu','1 ząbek czosnku100 gram piersi z indyka, 2 łyżki jogurtu naturalnego, 1 łyżeczka koperku, 1 i 1/2 marchwi, 1 łyżeczka oleju rzepakowego, 1/2 papryki czerwonej, 4 łyżki kaszy gryczanej','czosnek, indyk, pierś z indyka, jogurt naturalny, koperek, marchew, olej rzepakowy,papryka, papryka czerwona, kasza gryczana'),
 (17,'Leczo  z  cukinią  i  piersią  z  kurczaka',2,364,0,0,'Warzywa  umyć, cukinię  pokroić  w  dużą  kostkę,  ½  porcji  cebuli  obrać  i  pokroić  w  piórka,  paprykę  tak samo,  czosnek  w  plasterki.  W  garnku  rozgrzać  olej,  podsmażyć  cebulę  z  zielem  angielskim  i  liściem laurowym  oraz  czosnek,  dodać  zioła  prowansalskie,  jak  cebula  zmięknie  dodać  cukinię  i  paprykę, całość  wymieszać  i  chwilę  dusić  aż  wytworzy  się  sok,  dodać  pomidory  z  puszki  i  koncentrat pomidorowy.  Dodać  sos  sojowy.  Podlać  wszystko  wrzątkiem,  zakryć  pokrywką  i  gotować  10  min. Pierś  z  kurczaka  podsmażyć  na  odrobinie  oleju  a  następnie  dorzucić  do  leczo,  gotować  kolejne  10 minut.  Na  koniec  posypać  natką  pietruszki','1 cebula, 3/4 cukini, 1 ząbek czosnku, 1 łyżeczka koncentratu pomidorowego, 1/3 szklanki zmielonego mięsa z kurczaka, 1 łyżka oleju rzepakowego, 1/2 zielonej papryki','Cebula, cukinia, czosnek, koncentra pomidorowy, przecier pomidorowy, kurczak, olej rzepakowy, papryka'),
 (18,'Zupa  z  soczewicy',2,354,0,0,'Warzywa  obrać,  opłukać  i  pokroić  w  małą  kostkę  lub  zetrzeć  na  grubych  oczkach.  Rozgrzać  olej  rzepakowy  w  większym  garnku z  grubym  dnem,  dodać  warzywa  i  dusić  pod  przykryciem,  na  małym ogniu,  przez  około  4  minuty,  od  czasu  do  czasu  mieszając (nie  zrumieniać,  tylko  zeszklić).Wlać  wodę,  dodać  wszystkie  przyprawy  oraz  pokrojone  pomidory  z  puszki,  doprowadzić  do wrzenia.  Gotować  przez  10  minut,  aż  warzywa  trochę  zmiękną,  następnie  dodać  sok  pomidorowy  i  znów  zagotować.  Dzień  4 Po  kolejnych  10  minutach  gotowania,  jak  warzywa  będą  już  całkowicie  miękkie,  zmiksować  całość  w  blenderze.  Wlać  z powrotem  do  garnka,  zagotować,  dodać  opłukaną  i  odsączoną  soczewicę.  Gotować  przez  około  10  -  15  minut,  aż  soczewica będzie  całkowicie  miękka.  Doprawić  ewentualnie  do  smaku  solą  i  świeżo  zmielonym  pieprzem.  Posypać  świeżym szczypiorkiem','12 łyżek czerwonej soczewicy, 1/4 cebuli, 1 łyżka szczypiorku, 1 ząbek czosnku, 1 marchew, 2 łyżki oleju rzepakowego, 1/2 pietruszki, 2/3 szklanki pomidorów z puszki, 1/4 poru, 1/3 łyżeczki kminku, 1 szczypta kolendry suszonej, 1 liść laurowy, 1 szczypta pieprzu czarnego, 1 ziele angielskie, 2/3 szklanki soku pomidorowego, 2 szklanki wody','Czerwona soczewica, cebula, szczypiorek, czosnek, marchew, olej rzepakowy, pietruszka, pomidory w puszce, por, kminek, kolendra, liść laurowy, pieprz czarny, ziele angielskie, sok pomidorowy'),
 (19,'Pieczony  halibut  z  ziemniakami  i  ogórkiem  kiszonym',2,363,0,0,'Posiekaj cebulkę, zetrzyj czosnek i zawiń w folię aluminiową razem z filetem i olejem, piec rozgrzać do 180 stopniach, piec przez 10 minut, podawać z ugotowanymi ziemniakami posypanymi koperkiem','1/4 cebuli, 1 ząbek czosnku, 1 filet z halibuta, 1 łyżeczka koperku, 2 ogórki kiszone, 1 łyżka oleju rzepakowego, 2 ziemniaki','Cebula, czosnek, filet z halibuta, halibut, koperek, ogórek kiszony, olej rzepakowy, ziemniak'),
 (20,'Pieczona  pierś  z  kurczaka  z  kaszą  gryczaną  i  surówką  z  czerwonej  kapusty',2,363,0,0,'Nagrzać  piekarnik  do  180  stopni.  Przyprawy  połączyć  z  olejem.  Pierś  z  kurczaka  dokładnie  umyć  i  dokładnie  natrzeć  marynatą. Zawinąć  w  folię  aluminiową  i  piec  25  minut.  Paprykę  umyć  i  posiekać  w  kawałeczki  lub  z  cieniutkie  plasterki.  Wymieszać z  jogurtem  naturalnym,  sokiem  z  cytryny  i  przyprawami','3 łyżki kaszy gryczanej, 1/2 piersi z kurczaka, 1 łyżeczka oleju rzepakowego, 3/4 łyżeczki kurkumy, 1 łyżeczka suszonej papryki, 3 szczypta pieprzu czarnego, 2/3 łyżeczki suszonego tymianku, 2 szczypta soli, 1 łyżka jogurtu naturalnego, 1 papryka czerwona, 1 gałązka świerzego tymianku, 1 łyżka soku z cytryny','Kasza gryczana, pierś z kurczaka, kurczak, olej rzepakowy, kurkuma, suszaona papryka, pieprz czarny, suszony tymianek, sól, jogurt naturalny, papryka czerwona, tymianek świerzy, cytryna'),
 (30,'Kotlet  z  batatów  z  surówką  z  rukoli  i  pomidora',2,396,0,0,'Piekarnik  rozgrzać  do  220  stopni.  Batata  owinąć  w  folię  aluminiową  i  włożyć  do rozgrzanego  piekarnika,  piec  przez  30  minut  lub  do  czasu,  aż  będzie  miękki.  Upieczonego  batata  rozwinąć  i  przestudzić, piekarnik  ustawić  na  200  stopni.  W  międzyczasie  wszystkie  składniki  odmierzyć  i  włożyć  do  dużej  miski.  Batata  obrać  ze  skórki i przy  pomocy  blendera  zmiksować  na  gładkie  purée.  Purée  dodać  do  pozostałych  składników  w  misce  i  rękami  bardzo dokładnie  wyrobić  gładką masę doprawiając do smaku solą i pieprzem. Blachę wyłożyć  papierem do pieczenia.    Z gotowej masy lepić  nieduże  burgery,  następnie  ułożyć  je  na  blasze,  wsunąć  do  rozgrzanego  piekarnika  i  piec  przez  20  minut.  Po  tym  czasie blachę  wysunąć,  każdego  burgera  obrócić  i  piec  kolejne  8  –  10  minut.  Warzywa  umyć.  Pomidora  pokroić  na  małe  kawałki. Rukolę  wyłożyć  do  miski,  na  wierzch  ułożyć  pomidora.  doprawić  i  skropić  łyżeczką  oleju  z  pestek  dyni','1/4 cebuli czerwonej, 2 łyżki kaszy jaglanej, 1/2 łyżki masła sezamowego, 1 łyżeczka mąki jaglanej, 2/3 łyżeczki mięty pieprzowej, 1 łyżka nasion sezamu, 1/2 batata','Cebula, kasza jaglana, masło sezamowe, mąka jaglana, sezam, batat');
INSERT INTO "Skladniki" ("Id","Nazwa","Kalorie") VALUES (1,'Płatki owsiane',391),
 (2,'Makaron',368),
 (3,'Kasza Jaglana',354),
 (4,'Bułka pszenna',250),
 (5,'Kasza manna',353),
 (6,'Ryż',349),
 (7,'Jabłko',46),
 (8,'Maliny',29),
 (9,'Marchew',23),
 (10,'Pomarańcze',35),
 (11,'Rodzynki',247),
 (12,'Grejfrut',22),
 (13,'Gruszka',41),
 (14,'Dżem truskawkowy',204),
 (15,'Brzeoskwinie',37),
 (16,'Ananas',46),
 (17,'Banan',77),
 (18,'Truskawki',26),
 (19,'Winogrona',62),
 (20,'Cielęcina',129),
 (21,'Ser twarogowy tłusty',168),
 (22,'Makrela',112),
 (23,'Śledź',87),
 (24,'Łosoś',129),
 (25,'Jajka',140),
 (26,'Wołowina',204),
 (27,'Łopatka wieprzowa',228),
 (28,'Szynka gotowana',389),
 (29,'Białko jajka',36),
 (30,'Sandacz',47),
 (31,'Szczupak',47),
 (32,'Flądra',29),
 (33,'Krewetki',34),
 (34,'Okoń',50),
 (35,'Ser twarogowy chudy',104),
 (36,'Wątroba wołowa',128),
 (37,'Karp',49),
 (38,'Wątroba wieprzowa',124),
 (39,'Schab',139),
 (40,'Ziemniaki',71);
CREATE UNIQUE INDEX IF NOT EXISTS "UQ_skladnikiprzepisy_skladnikid_przepisid" ON "SkladnikiPrzepisy" (
	"SkladnikId",
	"PrzepisId"
);
COMMIT;
