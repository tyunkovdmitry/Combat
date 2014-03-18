using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat
{
    class Player1
    {
        public List<SpaceShip> spaceShipPlayer1 = new List<SpaceShip>();
        public Player1(int count)
        {
            for (int i = 0; i < count; i++)//10 кораблей
            {
                SpaceShip spaceShip = new SpaceShip(0, 0);//тип корабля и оружия пока 1
                spaceShipPlayer1.Add(spaceShip);//заполняем колекцию наших кораблей
            }
        }
    }
}
