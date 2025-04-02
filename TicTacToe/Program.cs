using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

public class TicTacToe
{
    static void Main(string[] args)
    {
        string[,] feld = { {" ", " ", " "}, {" ", " ", " "}, {" ", " ", " "} }; //Leeres Array für Feld

        //Startvariablen
        string player = "a";
        bool game = true;


        //Spielablauf
        while (game == true) {
            Console.WriteLine("Spieler " + player + " ist dran. Das ist der aktuelle Stand:");
            printFeld(feld); //Feld ausgeben
            
            if (player == "a") {
                input(feld, player); //Spieler zug machen lassen
                printFeld(feld);} //Feld ausgeben

            else if (player == "b") {machine(feld);} //PC Zug mnachen lassen

            if (checkWin(feld) == true) { //Prüfen, ob es einen Gewinner gibt
                Console.WriteLine("Herzlichen Glückwunsch Spieler " + player + ". Du hast gewonnen!");
                game = false; //Wenn ja, Spiel beenden
                break;
            }
            if (isFull(feld) == true) {
                Console.WriteLine("Unentschieden!");
                game = false;
                break;
            }
            
        }

        //Spielfeld ausgeben
       static void printFeld(string[,] feld) {
        for (int x = 0; x < 3; x++) {
            if (x == 0) {Console.WriteLine("-------------");}
            for (int y = 0; y < 3; y++) {
                if (y == 0) {Console.Write("| ");}
                Console.Write(feld[x,y]);
                Console.Write(" | ");
            }
            Console.WriteLine("");
            Console.WriteLine("-------------");
        }
        }
        
        static void machine(string[,] feld) {
            var rand = new Random();
            int x = rand.Next(1,3);
            int y = rand.Next(1,3);

            if (feld[x -1,y -1] == " ") { //Nur wenn Feld leer
                        feld[x -1,y -1] = "O";}
                    else {
                        machine(feld);
                    }
        }

        //Eingaben des Spielers
        static void input(string[,] feld, string spieler) {
            int wahl = 0;
            int xWahl = 0;
            int yWahl = 0;

            //Nimmt zweistellige Zahlen an
            Console.Write("Wo möchtest du dein Zeichen platzieren? ");
            wahl = Convert.ToInt32(Console.ReadLine());

            //Teilt zwei Stellige zahlen in beide Ziffern
            if (wahl > 10 && wahl <= 13 || wahl > 20 && wahl <= 23 || wahl > 30 && wahl <= 33) {
                xWahl = wahl/10;
                yWahl = wahl%10;

                //Platziere für Spieler A
                if (feld[xWahl -1,yWahl -1] == " ") { //Nur wenn Feld leer
                    feld[xWahl -1,yWahl -1] = "X";}
                else {
                    Console.WriteLine("Hier ist kein Platz. Bitte versuche es erneut!");
                    input(feld, spieler);
                }
            }

            //Catch für falsche Zahlen
            else {
                Console.WriteLine("Deine Eingabe war ungültig. Bitte versuche es erneut!");
                input(feld, spieler);
            }
        }

        //Gibt es eine Komnination, die Gewinnt?
        static bool checkWin(string[,] feld) {
            //Vertikal
            if (feld[0,0] != " " && feld[0,0] == feld[0,1] && feld[0,0] == feld[0,2]) return true;
            if (feld[1,0] != " " && feld[1,0] == feld[1,1] && feld[1,0] == feld[1,2]) return true;
            if (feld[2,0] != " " && feld[2,0] == feld[2,1] && feld[2,0] == feld[2,2]) return true;

            //Horizontal
            if (feld[0,0] != " " && feld[0,0] == feld[1,0] && feld[0,0] == feld[2,0]) return true;
            if (feld[0,1] != " " && feld[0,1] == feld[1,1] && feld[0,1] == feld[2,1]) return true;
            if (feld[0,2] != " " && feld[0,2] == feld[1,2] && feld[0,2] == feld[2,2]) return true;

            //Diagonalen
            if (feld[0, 0] != " " && feld[0, 0] == feld[1, 1] && feld[1, 1] == feld[2, 2]) return true;
            if (feld[0, 2] != " " && feld[0, 2] == feld[1, 1] && feld[1, 1] == feld[2, 0]) return true;
        
            return false;
        }

        //Spielfeld voll ohne Gewinner?
        static bool isFull(string[,] feld)
        {
            foreach (var feldwert in feld)
            {
                if (feldwert == " ") return false;
            }
            return true;
        } 
    }
}