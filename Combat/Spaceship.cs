using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat
{
    class SpaceShip
    {
        public int stepDistance;//растояние шага
        public int hp;
        public int attackDistance;//растояние атаки
        public int damage;
        public int reload;//перезарядка, ходов
        public int position;

        public int player1PointX1 = 20;//начальные координаты для создания наших кораблей
        public int player1PointY1 = 15;
        public int player1PointX2 = 40;
        public int player1PointY2 = 25;
        public int player1PointX3 = 20;
        public int player1PointY3 = 35;

        public int player2PointX1 = 30;//начальные координаты для создания кораблей компьютера
        public int player2PointY1 = 15;
        public int player2PointX2 = 10;
        public int player2PointY2 = 25;
        public int player2PointX3 = 30;
        public int player2PointY3 = 35;
        
        public SpaceShip(int typeShip, int typeWeapon)
        {
            switch (typeShip)
            {
                case 0:
                    hp = 50;
                    stepDistance = 3;
                    break;
            }

            switch (typeWeapon)
            {
                case 0:
                    damage = 25;
                    attackDistance = 5;
                    reload = 0;
                    break;
            }
        }
    }
}
