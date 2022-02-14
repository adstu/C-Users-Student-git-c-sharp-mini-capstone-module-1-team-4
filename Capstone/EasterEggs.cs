using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class EasterEggs
    {
        public static bool EasterEgg1 { get; set; } = false;
        public static bool EasterEgg2 { get; set; } = false;
        public static bool EasterEgg3 { get; set; } = false;
        public static bool Boomstick { get; set; } = false;
        public static int HittingMachine { get; set; } = 0;
        public static bool OnceThroughOnly { get; set; } = false;

        public static void BadEndingText()
        {
            Console.WriteLine("You feel a cold hand on your shoulder...");
            Console.ReadLine();
            Console.WriteLine("@@@ @@@   @@@@@@   @@@  @@@      @@@@@@   @@@@@@@   @@@@@@@@     @@@@@@@   @@@@@@@@   @@@@@@   @@@@@@@  ");
            Console.WriteLine("@@@ @@@  @@@@@@@@  @@@  @@@     @@@@@@@@  @@@@@@@@  @@@@@@@@     @@@@@@@@  @@@@@@@@  @@@@@@@@  @@@@@@@@ ");
            Console.WriteLine("@@! !@@  @@!  @@@  @@!  @@@     @@!  @@@  @@!  @@@  @@!          @@!  @@@  @@!       @@!  @@@  @@!  @@@ ");
            Console.WriteLine("!@! @!!  !@!  @!@  !@!  @!@     !@!  @!@  !@!  @!@  !@!          !@!  @!@  !@!       !@!  @!@  !@!  @!@ ");
            Console.WriteLine(" !@!@!   @!@  !@!  @!@  !@!     @!@!@!@!  @!@!!@!   @!!!:!       @!@  !@!  @!!!:!    @!@!@!@!  @!@  !@!  ");
            Console.WriteLine("  @!!!   !@!  !!!  !@!  !!!     !!!@!!!!  !!@!@!    !!!!!:       !@!  !!!  !!!!!:    !!!@!!!!  !@!  !!! ");
            Console.WriteLine("  !!:    !!:  !!!  !!:  !!!     !!:  !!!  !!: :!!   !!:          !!:  !!!  !!:       !!:  !!!  !!:  !!! ");
            Console.WriteLine("  :!:    :!:  !:!  :!:  !:!     :!:  !:!  :!:  !:!  :!:          :!:  !:!  :!:       :!:  !:!  :!:  !:! ");
            Console.WriteLine("   ::    ::::: ::  ::::: ::     ::   :::  ::   :::   :: ::::      :::: ::   :: ::::  ::   :::   :::: ::  ");
            Console.WriteLine("   :      : :  :    : :  :       :   : :   :   : :  : :: ::      :: :  :   : :: ::    :   : :  :: :  :   ");
            Console.ReadLine();
            Console.ReadLine();
        }

        public static void GoodEndingText()
        {
            Console.WriteLine("You feel a cold hand on your shoulder...");
            Console.ReadLine();
            Console.WriteLine("You use your shotgun to blow the zombie's head off!");
            Console.ReadLine();
            Console.WriteLine(@"___                                                                                                                          ");
            Console.WriteLine(@"-   ---___- ,,                ,,                                    /\                         ,,                             ");
            Console.WriteLine(@"   (' ||    ||      _         ||                                   ||                          ||   _           '         _   ");
            Console.WriteLine(@"  ((  ||    ||/\\  < \, \\/\\ ||/\       '\\/\\  /'\\ \\ \\       =||=  /'\\ ,._-_       -_-_  ||  < \, '\\/\\ \\ \\/\\  / \\ ");
            Console.WriteLine(@" ((   ||    || ||  /-|| || || ||_<        || ;' || || || ||        ||  || ||  ||         || \\ ||  /-||  || ;' || || || || || ");
            Console.WriteLine(@"  (( //     || || (( || || || || |        ||/   || || || ||        ||  || ||  ||         || || || (( ||  ||/   || || || || || ");
            Console.WriteLine(@"    -____-  \\ |/  \/\\ \\ \\ \\,\        |/    \\,/  \\/\\        \\, \\,/   \\,        ||-'  \\  \/\\  |/    \\ \\ \\ \\_-| ");
            Console.WriteLine(@"              _/                         (                                               |/             (                /  \ ");
            Console.WriteLine(@"                                          -_-                                            '               -_-            '----`");
            Console.ReadLine();
            Console.ReadLine();

        }

        public static void Logo()
        {
            Console.WriteLine(@"           _______________________________");
            Console.WriteLine(@"         /  XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX \ ");
            Console.WriteLine(@"        /    XXXXXXXXXXXXXXXXXXXXXXXXXXXX   \ ");
            Console.WriteLine(@"       /      XXXXXXXXXXXXXXXXXXXXXXXXXX     \");
            Console.WriteLine(@"      /        XXXXXXXXXXXXXXXXXXXXXXXX       \");
            Console.WriteLine(@"     /          XXXXXXXXXXXXXXXXXXXXXX         \");
            Console.WriteLine(@"    /            XXXXXXXXXXXXXXXXXXXX           \");
            Console.WriteLine(@"   /              XXXXXXXXXXXXXXXXXX             \");
            Console.WriteLine(@"  /                XXXXXXXXXXXXXXXX               \");
            Console.WriteLine(@" /                  XXXXXXXXXXXXXX                 \");
            Console.WriteLine(@"/                    XXXXXXXXXXXX                   \");
            Console.WriteLine(@"|XXX                  XXXXXXXXXX                  XXX| ");
            Console.WriteLine(@"|XXXXXXXXX             XXXXXXXX              XXXXXXXX| ");
            Console.WriteLine(@"|XXXXXXXXXXXXXXX        XXXXXX         XXXXXXXXXXXXXX|");
            Console.WriteLine(@"|XXXXXXXXXXXXXXXXXXXX     XX    XXXXXXXXXXXXXXXXXXXXX|");
            Console.WriteLine(@"|XXXXXXXXXXXXXXXXXXXXXXXX XX XXXXXXXXXXXXXXXXXXXXXXXX|");
            Console.WriteLine(@"|XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX|");
            Console.WriteLine(@"|XXXXXXXXXXXXXXXXXXXXXXXX XX XXXXXXXXXXXXXXXXXXXXXXXX|  ");
            Console.WriteLine(@"|XXXXXXXXXXXXXXXXXXXX     XX    XXXXXXXXXXXXXXXXXXXXX|");
            Console.WriteLine(@"|XXXXXXXXXXXXXXX         XXXX          XXXXXXXXXXXXXX| ");
            Console.WriteLine(@"|XXXXXXXXX              XXXXXX               XXXXXXXX|");
            Console.WriteLine(@"|XXX                   XXXXXXXX                   XXX|");
            Console.WriteLine(@"\                     XXXXXXXXXX                     /");
            Console.WriteLine(@" \                   XXXXXXXXXXXX                   /");
            Console.WriteLine(@"  \                 XXXXXXXXXXXXXX                 /");
            Console.WriteLine(@"   \               XXXXXXXXXXXXXXXX               /");
            Console.WriteLine(@"    \             XXXXXXXXXXXXXXXXXX             /");
            Console.WriteLine(@"     \           XXXXXXXXXXXXXXXXXXXX           /");
            Console.WriteLine(@"      \         XXXXXXXXXXXXXXXXXXXXXX         /");
            Console.WriteLine(@"       \       XXXXXXXXXXXXXXXXXXXXXXXX       /");
            Console.WriteLine(@"        \     XXXXXXXXXXXXXXXXXXXXXXXXXX     /");
            Console.WriteLine(@"         \   XXXXXXXXXXXXXXXXXXXXXXXXXXXX   /");
            Console.WriteLine(@"          \ XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX /");
            Console.WriteLine(@"            ‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾                      ");





        }







    }
}
