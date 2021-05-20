using System;
using System.Collections.Generic;
using System.Text;

namespace Duck.src
{

    public enum Can { летать, бегать, плавать, крякать, клевать, ползать };
    public enum TypeDuck { Каменушки, Нырки, Шилохвость, ХохлатаяУтка, Крохали, ЛайсанскаКряква };

    public class Duck
    {
        public static int nDuck = 0;

        public bool Cryak = false;
        public bool house; //знает или не знает, где она живет
        public string name = ""; //имя утки
        public int weight; //вес утки 
        public int SizeFoot; //размер лап
        public string[] masFavoriteDish = { "хлеб", "червяки", "улитки", "кузнечики", "лягушки", "ряска", "осока", "крупа", "овощи" }; //любимое блюдо
        public string FavoriteDish = "";
        public int endurance; //выносливость
        public int SizeBeak; //размер клюва
        public string[] masWingShape = { "узкие", "широкие" };
        public string WingShape = "";//форма крыльев
        public string[] Color = { "белый", "оранжеый", "черный", "желтый", "красный" };
        public string ColorBeak = ""; // окрас клюва 
        public int dexterity;//ловкость 
        public string ColorShape = "";// окрас крыльев
        public TypeDuck typeDuck;
        public Can can;
        public int caught = 0; // > 2 

        public int Crack = -2; // -2 не кряк -1 кряк 0 сбежал (1 или 2) нельзя поймать 3 то ловят

        public List<string> listNFerm = new List<string>();

        public static bool IsDuck = false;

        public static int numDuck = 0;
        static Random random = new Random();

        public string know = "";

        static int nCrack = 0;


        public Duck()
        {
            if(nCrack == 0)
            {
                nCrack = random.Next(1, 169);
            }

            ++nDuck;

            if (nDuck == nCrack)
            {
                Crack = -1;
            }

            int i = 13;

            while (i > 0)
            {

                switch (i)
                {
                    case 13:

                        house = random.Next(0, 1) == 0 ? true : false;
                        if (house)
                        {
                            know = "знает где она живет";
                        }
                        else
                        {
                            know = "не знает где она живет";
                        }
                        break;
                    case 12:
                        name = $"Duck_{++numDuck}";

                        break;
                    case 11:
                        weight = random.Next(2, 9);
                        break;
                    case 10:
                        SizeFoot = random.Next(1, 5);
                        break;
                    case 9:
                        FavoriteDish = masFavoriteDish[random.Next(0, 8)];
                        break;
                    case 8:
                        endurance = random.Next(0, 3);
                        break;
                    case 7:
                        SizeBeak = random.Next(1, 5);
                        break;
                    case 6:
                        WingShape = masWingShape[random.Next(0, 1)];
                        break;
                    case 5:
                        ColorBeak = Color[random.Next(0, 4)];
                        break;
                    case 4:
                        dexterity = random.Next(0, 3);
                        break;
                    case 3:
                        ColorShape = Color[random.Next(0, 4)];
                        break;
                    case 2:
                        typeDuck = (TypeDuck)random.Next(0, 5);
                        break;
                    case 1:

                        can = (Can)GetNumCun();//random.Next(0, 5);
                        break;
                }
                --i;

            }
            int lovk;
            int SizeLap;
            string LoveFood;
            string knowhouse;
            if (typeDuck == TypeDuck.Каменушки)
            {
                knowhouse = know;
                can = Can.летать;
                SizeLap = SizeFoot;
                LoveFood = FavoriteDish;

            }
            else if (typeDuck == TypeDuck.Нырки)
            {
                can = Can.бегать;
            }
            else if (typeDuck == TypeDuck.Шилохвость)
            {
                can = Can.плавать;
            }
            else if (typeDuck == TypeDuck.ХохлатаяУтка)
            {
                can = Can.ползать;
            }
            else if(typeDuck == TypeDuck.Крохали)
            {
                can = Can.плавать;
            }
            else if(typeDuck== TypeDuck.ЛайсанскаКряква)
            {
                can = Can.клевать;
            }
        }

        public int GetNumCun()
        {
            int rnCan = random.Next(0, 60000);

           if(rnCan < 9999)
            {
                return 0;
            }
           else if(rnCan < 19999)
            {
                return 1;
            }
           else if(rnCan < 29999)
            {
                return 2;
            }
           else if(rnCan < 39999)
            {
                return 3;
            }
           else if(rnCan < 49999)
            {
                return 4;
            }

            return 5;
        }

        public void moving(List<Duck> from, List<Duck> to, Duck duck)
        {
            if(from.Contains(duck))
            {
                from.Remove(duck);
                to.Add(duck);
            }
        }
    }
}
