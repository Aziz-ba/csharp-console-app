using System;
using System.Text.RegularExpressions;
using System.Threading.Channels;


namespace TP3
{


    class Program
    {

        /*définir la méthode SaisieNombre();
        chaque exercice sera dÈfinie sous forme d'une mÈthode static*/


        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;

            do
            {
                Console.Clear();
                Console.WriteLine("Menu :\n"
                                 + "exercice 1: Dessiner une ligne de croix\n"
                                 + "exercice 2: Dessiner une matrice de signes, Dessiner une diagonale\n"
                                 + "exercice 3: Afficher les tables de multiplication\n"
                                 + "exercice 4: Inverser une chaîne de caractères\n"
                                 + "\n"
                                 + "Sélectionnez le numéro de l'exercice désiré");
                int exo = SaisieNombre();
                bool result;
                switch (exo)
                {
                    case 1:
                        Console.WriteLine("Choisissez un entier");
                        int b = Convert.ToInt32(Console.ReadLine());
                        int[] a = new int[b];
                        for (int i = 0; i < a.Length; i++)
                        {
                            Console.WriteLine("Choisissez un entier");
                            a[i] = Convert.ToInt32(Console.ReadLine());
                        }
                        result = Palindrome(a);
                        if (result)
                        {
                            Console.WriteLine("C'est un palindrome");
                        }
                        else
                        {
                            Console.WriteLine("Ce n'est un palindrome");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Choisissez un entier");
                        int d = Convert.ToInt32(Console.ReadLine());
                        result = Verif_premier(d);
                        if (result)
                        {
                            Console.WriteLine("C'est un nombre premier");
                        }
                        else
                        {
                            Console.WriteLine("Ce n'est un nombre premier");
                        }
                        break;
                    case 3:
                        int[,] mat1 = new int[2, 3] { { 1, 2, 3 }, { 4, 6, 8 } };
                        int[,] mat2 = new int[2, 3] { { 6, 4, 3 }, { 8, 2, 8 } };
                        Produit2Matrices(mat1, mat2);
                        break;
                    case 4:
                        int[,] mat3 = new int[2, 3] { { 6, 4, 3 }, { 8, 2, 8 } };
                        result = CarreMagique(mat3);
                        if (result)
                        {
                            Console.WriteLine("C'est un carré magique");
                        }
                        else
                        {
                            Console.WriteLine("Ce n'est un carré magique");
                        }
                        break;
                    default:
                        Console.WriteLine("Erreur saisissez à nouveau");
                        break;
                }
                Console.WriteLine("Tapez Escape pour sortir ou un numero d exo");
                cki = Console.ReadKey();
            } while (cki.Key != ConsoleKey.Escape);

            Console.Read();
        }

        public static int SaisieNombre()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            { }
            return result;
        }
        public static bool Palindrome(int[] arr)
        {
            bool a = false;
            int[] arr2 = inverser(arr);
            if (arr == arr2)
            {
                return a = true;
            }
            else
            {
                return a;
            }
        }
        public static void afficher(int[] tab)
        {
            for (int i = 0; i <= tab.Length - 1; i++)
            {
                Console.Write(tab[i]);
                Console.Write(" ");
            }
        }
        public static int[] inverser(int[] tab)
        {
            int[] p = new int[tab.Length];
            for (int i = 0; i <= tab.Length - 1; i++)
            {
                p[i] = tab[(tab.Length - 1) - i];
            }
            return p;
        }
        public static bool Verif_premier(int nbr)
        {
            bool a = true;
            for (int i = 2; i < nbr; i++)
            {
                int b = nbr % i;
                if (b == 0)
                {
                    a = false;
                    return a;
                }
                else
                {
                    a = true;
                }
            }
            return a;
        }
        public static int[,] Produit2Matrices(int[,] mat1, int[,] mat2)
        {
            int[,] mat = new int[mat1.GetLength(0), mat1.GetLength(0)];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    mat[i, j] = mat1[i, j] + mat2[i, j];
                }
            }
            return mat;
        }
        public static bool CarreMagique(int[,] mat)
        {
            bool a = false;
            // sumd1 and sumd2 are the sum of the two diagonals
            int sumd1 = 0, sumd2 = 0;

            for (int i = 0; i < N; i++)
            {
                // (i, i) is the diagonal from top-left -> bottom-right
                // (i, N - i - 1) is the diagonal from top-right -> bottom-left
                sumd1 = sumd1 + mat[i, i];
                sumd2 = sumd2 + mat[i, N - 1 - i];
            }
            // if the two diagonal sums are unequal then it is not a magic square
            if (sumd1 != sumd2)
                return false;

            // For sums of Rows
            for (int i = 0; i < N; i++)
            {

                int rowSum = 0, colSum = 0;
                for (int j = 0; j < N; j++)
                {
                    rowSum += mat[i, j];
                    colSum += mat[j, i];
                }
                if (rowSum != colSum || colSum != sumd1)
                    return false;
            }

            return a;
        }
    }
}