using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat
{
    class AllBarriers
    {
        Random r = new Random();
        public List<Barrier> barrierType1 = new List<Barrier>();
        public List<Barrier> barrierType2 = new List<Barrier>();

        public AllBarriers(int countBarriers1, int countBarriers2)
        {
            for (int i = 0; i < countBarriers1; i++)
            {
                Barrier bar = new Barrier();
                bar.type = 1;
                bar.hp = r.Next(20, 100);//hp препятствия
                barrierType1.Add(bar);//заполняем коллекцию препятствий 1го типа
            }

            for (int i = 0; i < countBarriers2; i++)
            {
                Barrier bar = new Barrier();
                bar.type = 2;
                bar.hp = r.Next(1000, 2000);//hp препятствия
                barrierType2.Add(bar);//заполняем коллекцию препятствий 1го типа
            }
        }
    }
}
