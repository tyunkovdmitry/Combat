using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat
{
    class Player2
    {
        public List<SpaceShip> spaceShipPlayer2 = new List<SpaceShip>();
        public Player2(int count)
        {
            for (int i = 0; i < count; i++)
            {
                SpaceShip spaceShip = new SpaceShip(0, 0);//тип корабля и оружия пока 1
                spaceShipPlayer2.Add(spaceShip);//заполняем колекцию наших кораблей
            }
        }
    }
}
