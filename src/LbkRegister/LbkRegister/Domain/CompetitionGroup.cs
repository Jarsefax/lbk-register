﻿namespace LbkRegister.Domain {
    public static class CompetitionGroup {
        public enum Groups {
            Unknown = 0,
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10
        }

        public static Groups FromBreed(this string breed) {
            switch (breed.ToLower()) {
                case "australian cattledog":
                case "australian kelpie":
                case "australian shepherd":
                case "bearded collie":
                case "beauceron":
                case "belgisk vallhund/groenendael":
                case "belgisk vallhund/laekenois":
                case "belgisk vallhund/malinois":
                case "belgisk vallhund/tervueren":
                case "bergamasco":
                case "berger des pyrénées à face rase":
                case "berger des pyrénées à poil long":
                case "berger picard":
                case "border collie":
                case "bouvier des ardennes":
                case "bouvier des flandres":
                case "briard":
                case "cao da serra de aires":
                case "ceskoslovenský vlciak":
                case "chodský pes":
                case "ciobanesc romanesc carpatin":
                case "collie, korthårig":
                case "collie, långhårig":
                case "gos d'atura catalá":
                case "hollandse herdershond, korthårig":
                case "hollandse herdershond, långhårig":
                case "hollandse herdershond, strävhåri":
                case "hrvatski ovcar":
                case "juzjnorusskaja ovtjarka":
                case "komondor":
                case "kuvasz":
                case "lancashire heeler":
                case "maremmano abruzzese":
                case "miniature american shepherd":
                case "mudi":
                case "old english sheepdog":
                case "polski owczarek nizinny":
                case "polski owczarek podhalanski":
                case "puli":
                case "pumi":
                case "saarloos wolfhond":
                case "schapendoes":
                case "schipperke":
                case "shetland sheepdog":
                case "slovenský cuvac":
                case "tysk schäferhund":
                case "vit herdehund":
                case "vostochno-evropeiskaya ovcharka":
                case "welsh corgi cardigan":
                case "welsh corgi pembroke":
                case "working kelpie":
                    return Groups.One;

                case "affenpinscher":
                case "aidi":
                case "anatolisk herdehund":
                case "appenzeller sennenhund":
                case "berner sennenhund":
                case "boxer":
                case "broholmer":
                case "bullmastiff":
                case "cane corso":
                case "cao da serra da estrela, pelo compr":
                case "cao da serra da estrela, pelo curto":
                case "cimarrón uruguayo":
                case "dansk-svensk gårdshund":
                case "dobermann":
                case "dogo argentino":
                case "dogo canario":
                case "dogue de bordeaux":
                case "dvärgpinscher":
                case "dvärgschnauzer, peppar & salt":
                case "dvärgschnauzer, svart":
                case "dvärgschnauzer, svart & silver":
                case "engelsk bulldogg":
                case "entlebucher sennenhund":
                case "fila brasileiro":
                case "grand danois":
                case "grosser schweizer sennenhund":
                case "hovawart":
                case "kavkazskaja ovtjarka":
                case "kraski ovcar":
                case "landseer":
                case "leonberger":
                case "mastiff":
                case "mastín espanol":
                case "mastino napoletano":
                case "newfoundlandshund":
                case "perro dogo mallorquín/ca de bou":
                case "pinscher":
                case "pyrenéerhund":
                case "pyreneisk mastiff":
                case "rafeiro do alentejo":
                case "riesenschnauzer, peppar & salt":
                case "riesenschnauzer, svart":
                case "rottweiler":
                case "rysk svart terrier":
                case "sankt bernhardshund, korthårig":
                case "sankt bernhardshund, långhårig":
                case "sarplaninac":
                case "schnauzer, peppar & salt":
                case "schnauzer, svart":
                case "shar pei":
                case "sredneasiatskaja ovtjarka":
                case "tibetansk mastiff":
                case "tornjak":
                case "tosa":
                case "österreichischer pinscher":
                    return Groups.Two;

                case "airedaleterrier":
                case "american hairless terrier":
                case "american staffordshire terrier":
                case "american toy fox terrier":
                case "australisk terrier":
                case "bedlingtonterrier":
                case "borderterrier":
                case "bullterrier":
                case "cairnterrier":
                case "ceskyterrier":
                case "dandie dinmont terrier":
                case "english toy terrier":
                case "irish glen of imaal terrier":
                case "irish softcoated wheaten terrier":
                case "irländsk terrier":
                case "jack russell terrier":
                case "kerry blue terrier":
                case "lakelandterrier":
                case "manchesterterrier":
                case "miniatyrbullterrier":
                case "nihon teria":
                case "norfolkterrier":
                case "norwichterrier":
                case "parson russell terrier":
                case "rat terrier":
                case "sealyhamterrier":
                case "silky terrier":
                case "skotsk terrier":
                case "skyeterrier":
                case "släthårig foxterrier":
                case "staffordshire bullterrier":
                case "strävhårig foxterrier":
                case "tenterfield terrier":
                case "terrier brasileiro":
                case "tysk jaktterrier":
                case "welshterrier":
                case "west highland white terrier":
                case "yorkshireterrier":
                    return Groups.Three;

                case "tax":
                    return Groups.Four;

                case "akita":
                case "alaskan malamute":
                case "american akita":
                case "basenji":
                case "canaan dog":
                case "chow chow":
                case "cirneco dell'etna":
                case "dansk spids":
                case "eurasier":
                case "faraohund":
                case "finsk lapphund":
                case "finsk spets":
                case "grönlandshund":
                case "hokkaido":
                case "hälleforshund":
                case "isländsk fårhund":
                case "japansk spets":
                case "jämthund":
                case "kai":
                case "karelsk björnhund":
                case "keeshond":
                case "korea jindo dog":
                case "lapsk vallhund":
                case "norrbottenspets":
                case "norsk buhund":
                case "norsk lundehund":
                case "norsk älghund, grå (gråhund)":
                case "norsk älghund, svart":
                case "perro sin pelo del perú, grande":
                case "perro sin pelo del perú, médio":
                case "perro sin pelo del perú, pequeno":
                case "podenco canario":
                case "podenco ibicenco, korthårig":
                case "podenco ibicenco, strävhårig":
                case "podengo portugues, cerdoso/grande":
                case "podengo portugues, cerdoso/médio":
                case "podengo portugues, cerdoso/pequeno":
                case "podengo portugues, liso/grande":
                case "podengo portugues, liso/médio":
                case "podengo portugues, liso/pequeno":
                case "pomeranian":
                case "rysk-europeisk lajka":
                case "samojedhund":
                case "shiba":
                case "siberian husky":
                case "svensk lapphund":
                case "svensk vit älghund":
                case "thai bangkaew dog":
                case "thai ridgeback dog":
                case "tysk spets/ grosspitz":
                case "tysk spets/ kleinspitz":
                case "tysk spets/ mittelspitz":
                case "volpino italiano":
                case "västgötaspets":
                case "västsibirisk lajka":
                case "xoloitzcuintle, liten":
                case "xoloitzcuintle, mellan":
                case "xoloitzcuintle, stor":
                case "östsibirisk lajka":
                    return Groups.Five;

                case "alpenländische dachsbracke":
                case "american foxhound":
                case "anglo-russkaja gontjaja":
                case "basset artésien normand":
                case "basset bleu de gascogne":
                case "basset fauve de bretagne":
                case "basset hound":
                case "bayersk viltspårhund":
                case "beagle":
                case "black and tan coonhound":
                case "blodhund":
                case "bluetick coonhound":
                case "bosanski ostrodlaki gonic-barak":
                case "dalmatiner":
                case "deutsche bracke":
                case "drever":
                case "dunkerstövare":
                case "estnisk stövare":
                case "finsk stövare":
                case "foxhound":
                case "gonczy polski":
                case "gotlandsstövare":
                case "grand basset griffon vendéen":
                case "grand griffon vendéen":
                case "griffon bleu de gascogne":
                case "griffon fauve de bretagne":
                case "griffon nivernais":
                case "haldenstövare":
                case "hamiltonstövare":
                case "hannoveransk viltspårhund":
                case "hygenstövare":
                case "istarski kratkodlaki gonic":
                case "otterhound":
                case "petit basset griffon vendéen":
                case "petit bleu de gascogne":
                case "plott":
                case "porcelaine":
                case "posavski gonic":
                case "rhodesian ridgeback":
                case "russkaja gontjaja":
                case "sabueso espanol":
                case "schillerstövare":
                case "schweiziska stövare/ berner":
                case "schweiziska stövare/ jura":
                case "schweiziska stövare/ luzerner":
                case "schweiziska stövare/ schwyzer":
                case "serbski gonic":
                case "slovenský kopov":
                case "smålandsstövare":
                case "steirische rauhhaarbracke":
                case "treeing walker coonhound":
                    return Groups.Six;

                case "bracco italiano":
                case "braque du bourbonnais":
                case "braque francais, type pyrénées":
                case "breton":
                case "cesky fousek":
                case "drentsche patrijshond":
                case "engelsk setter":
                case "épagneul bleu de picardie":
                case "épagneul francais":
                case "épagneul picard":
                case "gammel dansk hönsehund":
                case "griffon d'arret à poil dur/korthals":
                case "grosser münsterländer":
                case "irländsk röd och vit setter":
                case "irländsk röd setter":
                case "kleiner münsterländer":
                case "korthårig vorsteh":
                case "långhårig vorsteh":
                case "perdigueiro portugues":
                case "pointer":
                case "pudelpointer":
                case "slovenský hrubosrsty stavac (ohar)":
                case "spinone":
                case "stabijhoun":
                case "strävhårig vorsteh":
                case "ungersk vizsla, korthårig":
                case "ungersk vizsla, strävhårig":
                case "weimaraner, korthårig":
                case "weimaraner, långhårig":
                    return Groups.Seven;

                case "amerikansk cocker spaniel":
                case "barbet":
                case "chesapeake bay retriever":
                case "clumber spaniel":
                case "cocker spaniel":
                case "curly coated retriever":
                case "engelsk springer spaniel":
                case "field spaniel":
                case "flatcoated retriever":
                case "golden retriever":
                case "irländsk vattenspaniel":
                case "labrador retriever":
                case "lagotto romagnolo":
                case "nederlandse kooikerhondje":
                case "nova scotia duck tolling retriever":
                case "perro de agua espanol":
                case "portugisisk vattenhund":
                case "sussex spaniel":
                case "wachtelhund":
                case "welsh springer spaniel":
                case "wetterhoun":
                    return Groups.Eight;

                case "bichon frisé":
                case "bichon havanais":
                case "bolognese":
                case "bostonterrier":
                case "cavalier king charles spaniel":
                case "chihuahua, korthårig":
                case "chihuahua, långhårig":
                case "chinese crested dog":
                case "coton de tuléar":
                case "fransk bulldogg":
                case "griffon belge":
                case "griffon bruxellois":
                case "japanese chin":
                case "king charles spaniel":
                case "kromfohrländer":
                case "lhasa apso":
                case "löwchen":
                case "malteser":
                case "mops":
                case "papillon":
                case "pekingese":
                case "petit brabancon":
                case "phalène":
                case "prazský krysarík":
                case "pudel, dvärg":
                case "pudel, mellan":
                case "pudel, stor":
                case "pudel, toy":
                case "russkaya tsvetnaya bolonka":
                case "russkiy toy":
                case "shih tzu":
                case "tibetansk spaniel":
                case "tibetansk terrier":
                    return Groups.Nine;

                case "afghanhund":
                case "azawakh":
                case "borzoi":
                case "chart polski":
                case "galgo espanol":
                case "greyhound":
                case "irländsk varghund":
                case "italiensk vinthund":
                case "magyar agar":
                case "saluki":
                case "skotsk hjorthund":
                case "sloughi":
                case "whippet":
                    return Groups.Ten;
            }

            return Groups.Unknown;
        }
    }
}
