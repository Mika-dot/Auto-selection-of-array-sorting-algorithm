using System;
using System.Threading;
using Filters;
using sorting;

namespace ChoiceSort
{
    class SpeedSort
    {
        public static double Accuracy = 0.2;
        public static int NumberOfMethods = 17;
        static bool[] Methods = new bool[NumberOfMethods + 1];

        //0 Bubble
        //1 Shaker
        //2 Insertion
        //3 Stooge
        //4 Pancake
        //5 Shell
        //6 Merge
        //7 Selection
        //8 Quick
        //9 Gnome
        //10 Tree
        //11 Comb
        //12 BasicCounting
        //13 CombinedBubble
        //14 Heapify
        //15 Cocktail
        //16 OddEven
        //17 BasicCounting скоростной

        static double[,] ParametersSynthetic = new double[,] {
            {8.886498023120352 * Math.Pow(10, -6), -0.0029476503441027146, 1.2863975050435954, 5.2475960197863465, 2.9774247491638794}, // Bubble
            {6.567664733329382 * Math.Pow(10, -6), Math.Pow(4.496149150567952, -5), 0.22974124825694275, 4.195026367540908, 3.0225375626043407}, // Shaker
            {2.1120085818852256 * Math.Pow(10, -6), 0.002476023269293637, -0.13618504359212125, 1.748047549532584, 2.082687338501292}, // Insertion
            {3.098367184258132 * Math.Pow(10, -8), 0.0002717226170613103, -0.07841137222219885, 0.8996995121725454, 1.4621503017004938}, // Pancake
            {6.46682876394178 * Math.Pow(10, -9), 0.00039311100976708105, -0.10418711906259404, 1.13066091193236, 1.4621503017004938}, // Merge
            {1.8899157767692854 * Math.Pow(10, -6), 0.0017633094975510744, 0.022074055629488498, 1.8186121876749357, 2.0534420289855073}, // Selection
            {-2.895618619522558 * Math.Pow(10, -7), 0.0006180561718480632, -0.09395417476077306, 0.5899069728282459, 1.6271186440677967}, // Quick
            {3.232067215708218 * Math.Pow(10, -6), 0.0017352834348457469, 0.01789278113186299, 2.3143122048196783, 2.2391111111111113}, // Gnome
            {-4.123072216339111 * Math.Pow(10, -7), 0.0035366633141615256, -0.5365642588296495, 2.117500149907495, 2.172158154859967}, // Tree
            {1.1653231638060916 * Math.Pow(10, -8), 0.0002634953706511893, -0.07702789595670367, 0.7047390416954649, 1.3197868087941373}, // Comb
            {6.08312757265802 * Math.Pow(10, -6), 0.0003407771074940835, 0.19163863123378633, 4.555735009148523, 2.668562144597888}, // CombinedBubble
            {3.0712658727831214 * Math.Pow(10, -8), 0.0003772072702234487, 0.022650519764958688, 1.0999223926443318, 1.5172580255853247}, // Heapify
            {2.8675376956714194 * Math.Pow(10, -6), 0.004067452096267965, -0.5899349046755731, 3.1353417835486024, 2.7207278481012658}, // Cocktail
            {4.077354791692507 * Math.Pow(10, -6), 0.002096707333241743, -0.0060553599324748575, 2.2349739599846536, 2.248768472906404}, // OddEven
            {2.303206258843002 * Math.Pow(10, -10), 1.6089275120108283 * Math.Pow(10, -5), -0.15459961498924102, 1.5185756014443144, 1.553413000181061}, // BasicCounting
            {3.098367184258132 * Math.Pow(10, -8), 0.0002717226170613103, -0.07841137222219885, 0.8996995121725454, 1.4621503017004938}, // Shell
            {0.002288340002330899, -0.18868362496050395, -26.072741498031974, 214.4169148052167, 21.750273822562978}, // Stooge
            }; // Ситнтетичеси
        static double[,] ParametersReal = new double[,] {
            {8.886498023120352 * Math.Pow(10, -6), -0.0029476503441027146, 1.2863975050435954, 5.2475960197863465, 2.389578163771712}, // Bubble
            {1.3565400494247324 * Math.Pow(10, -6), -0.0026612125461722806, 1.4555181879589725, 9.784629136390794, 3.3298538622129437}, // Shaker
            {-2.740936913166613 * Math.Pow(10, -8), 0.0005480621886874912, -0.19372831689835834, 2.1851801092490746, 2.057336765738357}, // Insertion
            {3.825290367464296 * Math.Pow(10, -9), 0.000155425721552473, -0.05404144800279198, 0.8402107371573253, 1.441137566137566}, // Pancake
            {6.46682876394178 * Math.Pow(10, -9), 0.00039311100976708105, -0.10418711906259404, 1.13066091193236, 1.441137566137566}, // Merge
            {4.643053210065561 * Math.Pow(10, -7), 0.00623827870491428, -0.7992690989670592, 4.698846185891919, 3.675812274368231}, // Selection
            {1.7417193838038685 * Math.Pow(10, -7), 0.0001757461493074458, 0.352796677854343, 2.6407711410303296, 2.5693255220069102}, // Quick
            {-2.441777615688557 * Math.Pow(10, -9), 0.0003956819580919358, -0.3332315707721669, 1.4553921343801612, 1.8026917216861351}, // Gnome
            {-4.581981664973731 * Math.Pow(10, -8), 0.005157109329861798, -0.8629834985105163, 2.9008681668344503, 2.8588498879761017}, // Tree
            {1.1717930603695903 * Math.Pow(10, -8), 0.00017575748482289745, -0.1495386444619271, 0.7824967115780764, 1.4103937007874017}, // Comb
            {1.7660115756390574 * Math.Pow(10, -6), 0.002509828120318941, -0.3289895898704458, 2.2873224734405446, 1.4103937007874017}, // CombinedBubble
            {3.0712658727831214 * Math.Pow(10, -8), 0.0003772072702234487, 0.022650519764958688, 1.0999223926443318, 1.5172580255853247}, // Heapify
            {7.615990599398971 * Math.Pow(10, -9), 0.0003550423283085573, -0.08076239500829985, 1.0017870742884516, 1.5284174424301813}, // Cocktail
            {-9.895670657085821 * Math.Pow(10, -7), 0.0031904628674310626, -0.5174342838570887, 3.3918198932719217, 2.2115384615384617}, // OddEven
            {2.303206258843002 * Math.Pow(10, -10), 1.6089275120108283 * Math.Pow(10, -5), -0.15459961498924102, 1.5185756014443144, 1.553413000181061}, // BasicCounting
            {3.825290367464296 * Math.Pow(10, -9), 0.000155425721552473, -0.05404144800279198, 0.8402107371573253, 1.441137566137566}, // Shell
            {0.002288340002330899, -0.18868362496050395, -26.072741498031974, 214.4169148052167, 21.750273822562978}, // Stooge
            }; // Реальный

        static void SpeedSortConstructor()
        {
            for (int i = 0; i < ParametersSynthetic.GetLength(0); i++)
            {
                if (ParametersSynthetic[i, 0] < 0)
                {
                    ParametersSynthetic[i, 0] = 0;

                    if (ParametersSynthetic[i, 1] < 0)
                    {
                        ParametersSynthetic[i, 1] = Math.Abs(ParametersSynthetic[i, 1]);
                    }
                }
                if (ParametersSynthetic[i, 2] < 0)
                {
                    ParametersSynthetic[i, 2] = 0;
                }
            }
            for (int i = 0; i < ParametersReal.GetLength(0); i++)
            {
                if (ParametersReal[i, 0] < 0)
                {
                    ParametersReal[i, 0] = 0;

                    if (ParametersReal[i, 1] < 0)
                    {
                        ParametersReal[i, 1] = Math.Abs(ParametersReal[i, 1]);
                    }
                }
                if (ParametersReal[i, 2] < 0)
                {
                    ParametersReal[i, 2] = 0;
                }
            }
        } // Нормализация данных

        static bool ArrayType(int[] Array)
        {
            double[] Parameters = filtration.LeastSquareMethod2(Array);

            if (Parameters[0] < Accuracy)
            {
                return true;
            }
            else
            {
                return false;
            }
        } // тип массива true синтетика, false реал

        static double FunctionTime(double a, double b, double c, int Number)
        {
            return a * Math.Pow(Number, 2) + b * Number + c;
        } // расчет времени с параметрами сортировки

        static double TheFastest(double[,] Parameters, int Number)
        {
            double minValue = int.MaxValue;
            int minNamber = 0;

            for (int i = 0; i < Parameters.GetLength(0); i++)
            {
                double temp = Math.Abs(FunctionTime(Parameters[i, 0], Parameters[i, 1], Parameters[i, 2], Number));
                if (temp < minValue)
                {
                    minValue = temp;
                    minNamber = i;
                }
            }
            return FunctionTime(Parameters[minNamber, 0], Parameters[minNamber, 1], Parameters[minNamber, 2], Number) + Parameters[minNamber, 4];
        } // минимальное время сортировки

        public static int[] AutomaticSorting(int[] Arrays)
        {
            int[] Finite = new int[Arrays.Length];

            var thread0 = new Thread(() =>
            {
                Finite = SortingSmart.Cocktail(Arrays);
                Methods[NumberOfMethods] = true;
            });
            thread0.Start(); // самый быстрый старт вдруг сработает

            if (Methods[NumberOfMethods])
            {
                return Finite;
            } // выполнился 1 скорость

            SpeedSortConstructor();

            bool type = ArrayType(Arrays);
            int Leng = Arrays.Length;

            if (Methods[NumberOfMethods])
            {
                return Finite;
            } // выполнился 1 скорость

            double TimeMax; // максимальное из минемальных времен
            if (type)
            {
                TimeMax = TheFastest(ParametersSynthetic, Leng);
                Thread[] thread1 = new Thread[NumberOfMethods];
                for (int i = 0; i < NumberOfMethods; i++)
                {
                    if (TimeMax > FunctionTime(ParametersSynthetic[i, 0], ParametersSynthetic[i, 1], ParametersSynthetic[i, 2], Leng) - ParametersSynthetic[i, 4])
                    {
                        continue;
                    }
                    thread1[i] = new Thread(() =>
                    {
                        Finite = SortingSmart.Choice(Arrays, i);
                        Methods[i] = true;
                    });
                    thread1[i].Start();

                    if (Methods[NumberOfMethods])
                    {
                        return Finite;
                    } // выполнился 1 скорость
                }
                bool ready = true;
                while (ready)
                {
                    for (int i = 0; i < NumberOfMethods + 1; i++)
                    {
                        if (Methods[i] == true)
                        {
                            return Finite;
                        }
                    }
                }
            }
            else
            {
                TimeMax = TheFastest(ParametersReal, Leng);
                Thread[] thread1 = new Thread[NumberOfMethods];
                for (int i = 0; i < NumberOfMethods; i++)
                {
                    if (TimeMax > FunctionTime(ParametersReal[i, 0], ParametersReal[i, 1], ParametersReal[i, 2], Leng) - ParametersReal[i, 4])
                    {
                        thread1[i] = new Thread(() =>
                        {
                            Finite = SortingSmart.Choice(Arrays, i);
                            Methods[i] = true;
                        });
                        thread1[i].Start();
                    }
                    if (Methods[NumberOfMethods])
                    {
                        return Finite;
                    } // выполнился 1 скорость
                }
                bool ready = true;
                while (ready)
                {
                    for (int i = 0; i < NumberOfMethods + 1; i++)
                    {
                        if (Methods[i] == true)
                        {
                            return Finite;
                        }
                    }
                }
            }

            return Finite; // Никогда не выполнится
        }

    }
}
