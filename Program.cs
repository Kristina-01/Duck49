using Duck.src;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Duck
{
    class Program
    {
        static Random rn = new Random();
        static int numDay = 0; // подсчет дней для crack
       static  public int Day = 1;
        static void Main(string[] args)
        {
            //фермы
            List<CountDuck> l1 = new List<CountDuck>()
            {
                new CountDuck() { from =1,to = 5},
                new CountDuck() { from =2,to = 7}
            };
            Territory tr1 = new Territory(ListCd: l1);

            List<CountDuck> l2 = new List<CountDuck>()
            {
                new CountDuck() { from =2,to = 9},
                new CountDuck() { from =4,to = 7}
            };
            Territory tr2 = new Territory(ListCd: l2);

            List<Territory> ferms = new List<Territory>() { tr1, tr2 }; //List из ферм 

            //озера
            int i1 = rn.Next(1, 56);
            Territory tr3 = new Territory(i1);
            int i2 = rn.Next(57, 112);
            Territory tr4 = new Territory(i2);
            int i3 = 169 - (i1 + i2);
            Territory tr5 = new Territory(i3);

            List<Territory> lakes = new List<Territory>() { tr3, tr4, tr5 }; //List из озер

            string h = "";

            while (Day<=8)
            {
                ++numDay;
                охота(lakes, ferms[0]);
                охота(lakes, ferms[1]);

                //-------------------------

                побег(lakes, ferms);

                
                Console.WriteLine("Нажмите Enter для следующего дня ");
                string str = Console.ReadLine();
                OutPutData(str, lakes, ferms);
            }


        }

        private static void OutPutData(string str, List<Territory> lakes, List<Territory> ferms)
        {

            switch (str)
            {
                
                case "":
                    if (Day <=8)
                    {
                        Console.WriteLine("------");
                        Console.WriteLine("День " + Day);
                        Console.WriteLine("------");
                        Day++;
                    }
                    else 
                    {
                        Console.WriteLine("Охота закончена!");
                        break;
                    }

                    Console.WriteLine($"на 1 озере {lakes[0].lsit.Count}");
                    Console.WriteLine($"на 2 озере {lakes[1].lsit.Count}");
                    Console.WriteLine($"на 3 озере {lakes[2].lsit.Count}");


                    Console.WriteLine($"на 1 ферме {ferms[0].lsit.Count}");
                    Console.WriteLine($"на 2 ферме {ferms[1].lsit.Count}");

                    Console.WriteLine("Введите номер озеро: ");
                    string prosto = Console.ReadLine();
                    if (prosto == "1")
                    {
                        int i = 1;
                        int k = 1;
                        foreach (Territory el in lakes)
                        {
                            if (k == i)
                            {
                                Console.WriteLine(el.lsit.Count);
                                var e = el.lsit.GroupBy(x => x.can); // создаются списки из списка по определенному параметру 



                                foreach (var tm in e)
                                    Console.WriteLine($"{tm.Key} = {tm.ToList().Count}");
                                Console.WriteLine("-----------------------------");
                            }
                            ++k;
                        }
                    }
                    else if (prosto == "2")
                    {
                        Console.WriteLine("Озеро 2:");

                        int i = 2;
                        int k = 1;
                        foreach (var el in lakes)
                        {
                            if (k == i)
                            {
                                Console.WriteLine(el.lsit.Count);
                                var e = el.lsit.GroupBy(x => x.can);
                                foreach (var tm in e)
                                    Console.WriteLine($"{tm.Key} = {tm.ToList().Count}");
                                Console.WriteLine("-----------------------------");
                            }
                            ++k;
                        }
                    }
                    else if (prosto == "3")
                    {
                        int i = 3;
                        int k = 1;
                        foreach (var el in lakes)
                        {
                            if (k == i)
                            {
                                
                                Console.WriteLine(el.lsit.Count);
                                var e = el.lsit.GroupBy(x => x.can);
                                foreach (var tm in e)
                                    Console.WriteLine($"{tm.Key} = {tm.ToList().Count}");
                                Console.WriteLine("-----------------------------");
                            }
                            ++k;
                        }
                    }
                    else if (Day > 8)
                        Console.WriteLine("Охото окончена!");
                    break;

            }
        }

        private static void побег(List<Territory> lakes, List<Territory> ferms)
        {
            for (int i = 0; i < ferms.Count; ++i)
            {
                var el = ferms[i];
                if (i == 0)
                {
                    if (el.lsit.Count == 0) break;
                    var d = el.lsit[rn.Next(0, el.lsit.Count - 1)];

                    if (d.Crack == -2)
                    {
                        if (d.can == Can.плавать)
                        {
                            if (!d.house)
                            {

                                if (d.caught > 2)
                                {
                                    d.caught++;
                                    d.moving(el.lsit, lakes[GetInt3()].lsit, d);
                                }
                            }
                        }
                    }
                    else
                    {
                        
                        d.moving(el.lsit, lakes[GetInt3()].lsit, d);
                        numDay = 0;
                    }
                }
                else if (i == 1)
                {
                    if (el.lsit.Count == 0) break;
                    var d = el.lsit[rn.Next(0, el.lsit.Count - 1)];
                    if (d.Crack == -2)
                    {
                        if (d.can == Can.плавать)
                        {
                            if (!d.house)
                            {

                                if (d.caught > 2)
                                {
                                    d.caught++;
                                    d.moving(el.lsit, lakes[GetInt3()].lsit, d);
                                }
                            }
                        }
                    }
                    else
                    {
                        
                        d.moving(el.lsit, lakes[GetInt3()].lsit, d);
                        numDay = 0;
                    }
                }
            }
        }

        private static void охота(List<Territory> lakes, Territory ferm)
        {
            foreach (var el in ferm.hunters)
            {

                int i = rn.Next(el.from, el.to);

                while (i > 0)
                {
                    var lake = lakes[GetInt3()];
                    if (lake.lsit.Count == 0) break; //если на озере нет уток 
                    var d = lake.lsit[rn.Next(0, lake.lsit.Count - 1)]; // рандомно выберем утку из озера 
                    
                    if (d.Crack == -2) //обычная утка 
                    {
                        d.moving(lake.lsit, ferm.lsit, d);
                        
                    }
                    if(d.Crack == -1 && numDay > 1) // утка Crack
                    {
                        d.moving(lake.lsit, ferm.lsit, d);
                    }
                    --i;
                }

            }
        }

      

        //рандомное заполнение озер уточками
        static int GetInt3()
        {
            int lake = rn.Next(0, 1000);
            if (lake >= 0 && lake <= 333)
            {
                lake = 0;
            }
            else if (lake > 333 && lake <= 333 * 2)
            {
                lake = 1;

            }
            else if (lake > 333 * 2 && lake <= 333 * 3)
            {
                lake = 2;
            }

            return lake;
        }
    }
}
