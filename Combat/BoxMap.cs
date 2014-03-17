using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Combat
{
    class BoxMap
    {
        public int block;//блокировка
        /*
         * -1: крайняя ячейка которая выходит за границу
         * 0: ячейка не блокированна
         * 1: препятствие 1го типа (маленькое)
         * 2: препятствие 2го типа (большое)
         * 3: наш корабль
         * 4: корабль компьютера
         */
        public int id;//номер ячейки
        public int forstep;//1: ячейка для шага, 0: обычная
        public int forattack;//1: ячейка для атаки, 0: обычная

        public int p1x = 5;//начальные координаты шестиугольников
        public int p1y = 25;
        public int p2x = 15;
        public int p2y = 5;
        public int p3x = 35;
        public int p3y = 5;
        public int p4x = 45;
        public int p4y = 25;
        public int p5x = 35;
        public int p5y = 45;
        public int p6x = 15;
        public int p6y = 45;
    }
}
