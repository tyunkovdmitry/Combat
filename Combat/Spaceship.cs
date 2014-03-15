using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat
{
    class Spaceship
    {
        /*public int type_ship;
        public int type_weapon;*/
        public int step_distance;
        public int hp;
        public int attack_distance;
        public int damage;
        public int reload;
        public int own;
        public int mp1x = 15;
        public int mp1y = 10;
        public int mp2x = 35;
        public int mp2y = 20;
        public int mp3x = 15;
        public int mp3y = 30;
        public int cp1x = 25;
        public int cp1y = 10;
        public int cp2x = 5;
        public int cp2y = 20;
        public int cp3x = 25;
        public int cp3y = 30;

        public Spaceship(int type_ship, int type_weapon)
        {
            switch (type_ship)
            {
                case 0:
                    hp = 50;
                    step_distance = 3;
                    break;
            }
            switch (type_weapon)
            {
                case 0:
                    damage = 25;
                    attack_distance = 5;
                    reload = 0;
                    break;
            }
        }
    }
}
