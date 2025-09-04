using _1PirmaUzduotis_AutomobiliuNuomaValdymasSuDB.Interfaces;
using _1PirmaUzduotis_AutomobiliuNuomaValdymasSuDB.Models;
using _1PirmaUzduotis_AutomobiliuNuomaValdymasSuDB.Repositories;

namespace _1PirmaUzduotis_AutomobiliuNuomaValdymasSuDB.Services
{
    //Sukurkite C# programą, kuri valdytų automobilių nuomos procesą.
    //Sistema turėtų leisti registruoti naujus automobilius, atnaujinti jų informaciją, peržiūrėti esamų automobilių sąrašą bei valdyti klientų nuomos procesą.
    //Automobiliai bus suskirstyti į du tipus: naftos kuro automobilius ir elektromobilius.

    //Paveldėjimas:
    //Sukurkite bazinę klasę Automobilis, kuri turės savybes: Id, Marke, Modelis, Metai, RegistracijosNumeris.

    //Išvestinės klasės:
    //NaftosKuroAutomobilis: papildoma savybė BakoTalpa.
    //Elektromobilis: papildoma savybė BaterijosTalpa.

    //Duomenų saugojimas:

    //Naudokite Microsoft SQL Server ir Dapper ORM biblioteką duomenų saugojimui ir manipuliavimui.
    //Duomenų bazėje turi būti šios lentelės:
    //Automobiliai: bendra lentelė visiems automobiliams.
    //NaftosKuroAutomobiliai: specifinė informacija naftos kuro automobiliams.
    //Elektromobiliai: specifinė informacija elektromobiliams.
    //Klientai: specifinė informacija apie klientus.
    //Klientų lentelėje, turi būti stulpelis reprezentuojantis kliento registracijos sistemoje datą ir laiką. (Padaryti su DEFAULT SQL arba registruojant klientą naudoti DateTime.Now)
    //Nuoma: lentelėje turi būti informaciją apie automobilių nuomą, tai yra turi būti nuorodos į automobilį, į klientą, bei datos NUO/IKI

    //Funkcionalumai:
    //Automobilių registracija ir jų tipų priskyrimas.
    //Automobilių sąrašo gavimas su galimybe filtruoti pagal tipą.
    //Automobilių informacijos atnaujinimas.
    //Automobilių ištrinimas.
    //Automobilio išnuomavimas pasirinkus automobilį ir pasirinkus klientą, bei priskyrus laiką.Jeigu Automobilis jau yra kažkam tuo laikotarpiu išnuomotas, turi būti metama klaida, jog automobilio išnuomuoti negalima.

    //LABAI SVARBU
    //Pasikeitimai - Tai, ką laikėme DatabaseService turi tapti DatabaseRepository ir turi būti laikoma aplanke Repositories
    //Turi būti sukurtas NuomaService (RentService) kuriame būtų įgyvendinamas programos funkcionalumas.

    //Programos valdymui su konsole turi būti sukurta klasę (kaip servisas) NuomaConsoleUI (RentConsoleUI), kuriame turi būti meniu,
    //visi pasirinkimai išbandyti visą programos funkcionalumą. NuomaConsoleUI, turi priimti kaip argumentą objektą pagal NuomaService interface.
    //Pats, NuomaService turi priimti IDatabaseRepository, per kurį jis atlikinės visus veiksmus su duomenų baze.
    //NuomaConsoleUI turi galimybę valdyti NuomaService -> NuomaService turi turėti galimybę valdyti IDatabaseRepository.
    //Laikini sąrašai, meniu ir kita, neturi būti Main dalyje - Main dalyje, galimas tik servisų ir repositories inicializavimas!
    public class NuomaServiceUI
    {
        public static void Main(string[] args)
        {
            string connectionString = "Data Source=DESKTOP-6FFNPQ7;Initial Catalog=automobiliuNuoma;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";
            IDatabaseRepository databaseRepository = new DatabaseRepository(connectionString);
            NuomaService nuoma = new NuomaService(databaseRepository);
            MenuText();
            MenuInputCheck(out bool inputMenuCheck, out int inputMenu);

            while (inputMenuCheck == true)
            {
                Menu(ref inputMenu, ref nuoma, ref databaseRepository);
                Console.WriteLine();
                MenuText();
                MenuInputCheck(out inputMenuCheck, out inputMenu);
            }
        }

        public static (bool, int) MenuInputCheck(out bool inputMenuCheck, out int inputMenu)
        {
            inputMenuCheck = int.TryParse(Console.ReadLine(), out inputMenu);
            return (inputMenuCheck, inputMenu);
        }


        //Automobilio išnuomavimas pasirinkus automobilį ir pasirinkus klientą, bei priskyrus laiką.
        //Jeigu Automobilis jau yra kažkam tuo laikotarpiu išnuomotas, turi būti metama klaida, jog automobilio išnuomuoti negalima.

        static void MenuText()
        {
            Console.WriteLine("| MENU |");
            Console.WriteLine("1 - Registruoti automobili.");
            Console.WriteLine("2 - Automobiliu saraso gavimas");
            Console.WriteLine("3 - Atnaujinti automobilio informacija.");
            Console.WriteLine("4 - Isnuomuoti automobili.");

            Console.WriteLine("9 - Istrinti automobili.");
            Console.WriteLine("0 - Baigti darba.");
        }

        //int id = autoparkas.AutoparkoSarasas.Count > 0 ? autoparkas.AutoparkoSarasas.Max(X => X.AutomobilioId) + 1 : 0;
        //autoparkas.PridetiIAutoparka(SukurkAutomobili(ref id));
        public static void Menu(ref int inputMeniu, ref NuomaService nuoma, ref IDatabaseRepository databaseRepository)
        {
            switch (inputMeniu)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    RegistruotiAutomobili(ref nuoma);
                    break;
                case 2:
                    AutomobiliuSarasoSpausdinimas();
                    break;
                case 3:
                    AtnaujintiAuto(ref databaseRepository);
                    break;
                case 4:

                    break;
                case 9:
                    IstrintiAutomobili(ref databaseRepository);
                    break;
                default:
                    break;
            }
        }
        public static void AutomobiliuSarasoSpausdinimas()
        {
            Console.WriteLine("Saraso tipas:");
            Console.WriteLine("1 - visu automobiliu sarasas.");
            Console.WriteLine("2 - naftos automobiliu sarasas.");
            Console.WriteLine("3 - elektriniu automobiliu sarasas.");

        sarasoTipoCheck:
            int sarasoTipas;
            try
            {
                int.TryParse(Console.ReadLine(), out sarasoTipas);

                switch (sarasoTipas)
                {
                    case 1:
                        List<NaftosKuroAutomobilis> NaftosAutomobiliai = GetNaftosAutomobiliuSarasas().ToList();
                        foreach (NaftosKuroAutomobilis a in NaftosAutomobiliai)
                        {
                            Console.WriteLine(a.ToString());
                        }

                        List<ElektrinisAutomobilis> ElektriniaiAutomobiliai = GetElektrinisAutomobiliuSarasas().ToList();
                        foreach (ElektrinisAutomobilis a in ElektriniaiAutomobiliai)
                        {
                            Console.WriteLine(a.ToString());
                        }
                        break;
                    case 2:
                        NaftosAutomobiliai = databaseRepository.GetNaftosAutomobiliuSarasas().ToList();
                        foreach (Automobilis a in NaftosAutomobiliai)
                        {
                            Console.WriteLine(a.ToString());
                        }
                        break;
                    case 3:
                        ElektriniaiAutomobiliai = databaseRepository.GetElektrinisAutomobiliuSarasas().ToList();
                        foreach (Automobilis a in ElektriniaiAutomobiliai)
                        {
                            Console.WriteLine(a.ToString());
                        }
                        break;
                    default:
                        goto sarasoTipoCheck;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto sarasoTipoCheck;
            }
        }
        public static void RegistruotiAutomobili(ref NuomaService nuoma)
        {
            Console.WriteLine("Kokio tipo automobili norite registruoti?");
            Console.WriteLine("1 - Naftos kuro automobilis");
            Console.WriteLine("2 - Elektrinis automobilis");

            int automobilioTipas;

        automobilioTipoCheck:
            try
            {
                automobilioTipas = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("iveskite 1 arba 2 ");
                goto automobilioTipoCheck;
            }

            Console.Write("Iveskite automobilio marke: ");
            string Marke = Console.ReadLine();

            Console.Write("Iveskite automobilio modeli: ");
            string Modelis = Console.ReadLine();

            Console.Write("Iveskite automobilio gamybos metus: ");
            int Gamybosmetai;
        gamybosmetaiCheck:
            try
            {
                Gamybosmetai = int.Parse(Console.ReadLine());
            }
            catch (Exception blogaIvestis)
            {
                Console.WriteLine($"Error: {blogaIvestis.Message}\n Ivesties formatas: sveikieji skaiciai");
                goto gamybosmetaiCheck;
            }

            Console.Write("Iveskite automobilio registracijos numeri: ");
            string RegNr = Console.ReadLine();

            switch (automobilioTipas)
            {
                case 1:
                    Console.Write("Iveskite automobilio bako talpa:");

                    int BakoTalpa;
                BakoTalpaCheck:
                    try
                    {
                        BakoTalpa = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error: {e.Message} Iveskite sveikuosius skaicius");
                        goto BakoTalpaCheck;
                    }
                    Automobilis automobilis = new NaftosKuroAutomobilis(Marke, Modelis, Gamybosmetai, RegNr, BakoTalpa);
                    nuoma.PridetiRegistruotaAuto(automobilis);
                    break;
                case 2:
                    Console.WriteLine("Iveskite baterijos talpa (kWh) : ");
                    int BaterijosTalpa;
                BaterijosTalpaCheck:
                    try
                    {
                        BaterijosTalpa = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error: {e.Message} Iveskite sveikuju skaiciu formatu");
                        goto BaterijosTalpaCheck;
                    }
                    automobilis = new ElektrinisAutomobilis(Marke, Modelis, Gamybosmetai, RegNr, BaterijosTalpa);
                    nuoma.PridetiRegistruotaAuto(automobilis);
                    break;
            }

        }
        public static void AtnaujintiAuto(ref IDatabaseRepository databaseRepository)
        {

            Console.WriteLine("Kokio tipo automobili norite atnaujinti?");
            Console.WriteLine("1 - Naftos kuro automobilis");
            Console.WriteLine("2 - Elektrinis automobilis");
            int automobilioTipas;

        automobilioTipoCheck:
            try
            {
                automobilioTipas = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("iveskite 1 arba 2 ");
                goto automobilioTipoCheck;
            }

            Console.WriteLine("Iveskite automobilio ID:");
            int autoID;
        autoID:
            try
            {
                autoID = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("iveskite sveikuosius skaicius");
                goto autoID;
            }

            Console.Write("Iveskite automobilio marke: ");
            string Marke = Console.ReadLine();

            Console.Write("Iveskite automobilio modeli: ");
            string Modelis = Console.ReadLine();

            Console.Write("Iveskite automobilio gamybos metus: ");
            int Gamybosmetai;
        gamybosmetaiCheck:
            try
            {
                Gamybosmetai = int.Parse(Console.ReadLine());
            }
            catch (Exception blogaIvestis)
            {
                Console.WriteLine($"Error: {blogaIvestis.Message}\n Ivesties formatas: sveikieji skaiciai");
                goto gamybosmetaiCheck;
            }

            Console.Write("Iveskite automobilio registracijos numeri: ");
            string RegNr = Console.ReadLine();

            switch (automobilioTipas)
            {
                case 1:
                    Console.Write("Iveskite automobilio bako talpa:");

                    int BakoTalpa;
                BakoTalpaCheck:
                    try
                    {
                        BakoTalpa = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error: {e.Message} Iveskite sveikuosius skaicius");
                        goto BakoTalpaCheck;
                    }
                    NaftosKuroAutomobilis nAutomobilis = new NaftosKuroAutomobilis(autoID, Marke, Modelis, Gamybosmetai, RegNr, BakoTalpa);
                    databaseRepository.UpdateNaftosKuroAutomobilis(nAutomobilis);
                    break;
                case 2:
                    Console.WriteLine("Iveskite baterijos talpa (kWh) : ");
                    int BaterijosTalpa;
                BaterijosTalpaCheck:
                    try
                    {
                        BaterijosTalpa = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error: {e.Message} Iveskite sveikuju skaiciu formatu");
                        goto BaterijosTalpaCheck;
                    }
                    ElektrinisAutomobilis eAutomobilis = new ElektrinisAutomobilis(autoID, Marke, Modelis, Gamybosmetai, RegNr, BaterijosTalpa);
                    databaseRepository.UpdateElektrinisAutomobilis(eAutomobilis);
                    break;
            }
        }
        public static void IstrintiAutomobili(ref IDatabaseRepository databaseRepository)
        {
            Console.WriteLine("Kokio tipo automobili norite atnaujinti?");
            Console.WriteLine("1 - Naftos kuro automobilis");
            Console.WriteLine("2 - Elektrinis automobilis");
            int automobilioTipas;
        automobilioTipoCheck:
            try
            {
                automobilioTipas = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("iveskite 1 arba 2 ");
                goto automobilioTipoCheck;
            }

            Console.WriteLine("Iveskite trinamo automobilio ID");
            int autoID;
        autoID:
            try
            {
                autoID = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("iveskite sveikuosius skaicius");
                goto autoID;
            }

            switch (automobilioTipas)
            {
                case 1:
                    databaseRepository.DeleteNaftosKuroAutomobilis(autoID);
                    break;
                case 2:
                    databaseRepository.DeleteElektrinisAutomobilis(autoID);
                    break;

            }
        }
    }
}