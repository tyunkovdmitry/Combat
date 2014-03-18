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
         * 0: ячейка не блокированна
         * 1: препятствие 1го типа (маленькое)
         * 2: препятствие 2го типа (большое)
         * 3: наш корабль
         * 4: корабль компьютера
         */
        public int id;//номер ячейки
        public int forstep;//1: ячейка для шага, 0: обычная
        public int forattack;//1: ячейка для атаки, 0: обычная

        public int pointX1 = 5;//начальные координаты шестиугольников
        public int pointY1 = 25;
        public int pointX2 = 15;
        public int pointY2 = 5;
        public int pointX3 = 35;
        public int pointY3 = 5;
        public int pointX4 = 45;
        public int pointY4 = 25;
        public int pointX5 = 35;
        public int pointY5 = 45;
        public int pointX6 = 15;
        public int pointY6 = 45;

        public int pointXCenter;
        public int pointYCenter;
    }
}
