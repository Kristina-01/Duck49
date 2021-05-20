using System;
using System.Collections.Generic;
using System.Text;

namespace Duck.src
{

    public class CountDuck
    {
        public int from = 0;
        public int to = 0;
    }

    public class Territory
    {
        public List<Duck> lsit = new List<Duck>();
        public List<CountDuck> hunters = new List<CountDuck>();


        public Territory(int count = 0, List<CountDuck> ListCd = null)
        {
            //если передаем List, то каждому охотнику говорим, сколько уток он может переместить за один ход 
            if(ListCd != null)
            {
                foreach(var el in ListCd)
                {
                    hunters.Add(new CountDuck() { from = el.from, to = el.to });
                }
            }

            //если передаем count, то заполняем озера 
            while(count > 0)
            {
                lsit.Add(new Duck());
                --count;
            }
        }
    }
}
