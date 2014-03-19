using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat
{
    class FullMap
    {
        Random r = new Random();
        public List<BoxMap> boxs = new List<BoxMap>();
        public List<SpaceShip> spaceShipPlayer1 = new List<SpaceShip>();
        public List<SpaceShip> spaceShipPlayer2 = new List<SpaceShip>();
        public List<Barrier> barrierType1 = new List<Barrier>();
        public List<Barrier> barrierType2 = new List<Barrier>();
        int id = 0;

        public FullMap(int width, int height, int countSpaceShip)
        {
            Player1 player1 = new Player1(countSpaceShip);
            Player2 player2 = new Player2(countSpaceShip);
            AllBarriers barriers = new AllBarriers((((width - 20) / 60) * ((height / 40) - 1)) / 40, (((width - 20) / 60) * ((height / 40) - 1)) / 60);

            for (int j = 0; j < ((width - 20) / 60); j++)//заполнение столбцами в ширину
            {
                for (int i = 0; i < (height / 40) - 1; i++)//нечетный столбец
                {
                    BoxMap box = new BoxMap();
                    box.pointX1 = box.pointX1 + j * 60;//координаты для создания шестиугольников
                    box.pointY1 = box.pointY1 + i * 40;
                    box.pointX2 = box.pointX2 + j * 60;
                    box.pointY2 = box.pointY2 + i * 40;
                    box.pointX3 = box.pointX3 + j * 60;
                    box.pointY3 = box.pointY3 + i * 40;
                    box.pointX4 = box.pointX4 + j * 60;
                    box.pointY4 = box.pointY4 + i * 40;
                    box.pointX5 = box.pointX5 + j * 60;
                    box.pointY5 = box.pointY5 + i * 40;
                    box.pointX6 = box.pointX6 + j * 60;
                    box.pointY6 = box.pointY6 + i * 40;
                    box.pointXCenter = (int)(box.pointX4 / 2) + box.pointX1;
                    box.pointYCenter = (int)(box.pointY5 / 2) + box.pointY2;
                    box.id = id;
                    box.block = 0;//все элементы устанавливаем неблокированными
                    boxs.Add(box);//заполняем коллекцию элементами
                    id += 1;
                }
                for (int i = 0; i < (height / 40) - 1; i++)//четный столбец
                {
                    BoxMap box = new BoxMap();
                    box.pointX1 = box.pointX1 + 30 + j * 60;//координаты для создания шестиугольников
                    box.pointY1 = box.pointY1 + 20 + i * 40;
                    box.pointX2 = box.pointX2 + 30 + j * 60;
                    box.pointY2 = box.pointY2 + 20 + i * 40;
                    box.pointX3 = box.pointX3 + 30 + j * 60;
                    box.pointY3 = box.pointY3 + 20 + i * 40;
                    box.pointX4 = box.pointX4 + 30 + j * 60;
                    box.pointY4 = box.pointY4 + 20 + i * 40;
                    box.pointX5 = box.pointX5 + 30 + j * 60;
                    box.pointY5 = box.pointY5 + 20 + i * 40;
                    box.pointX6 = box.pointX6 + 30 + j * 60;
                    box.pointY6 = box.pointY6 + 20 + i * 40;
                    box.pointXCenter = (int)(box.pointX4 / 2) + box.pointX1;
                    box.pointYCenter = (int)(box.pointY5 / 2) + box.pointY2;
                    box.id = id;
                    box.block = 0;//элементы устанавливаем неблокированными
                    boxs.Add(box);//заполняем коллекцию элементами
                    id += 1;
                }
            }

            for (int id = 0; id < player1.spaceShipPlayer1.Count; id++)//работаем с нашими кораблями
            {
                int i = r.Next(0, 40);//рандомное место корабля
                if (boxs[i].block == 0)//если ячейка не блокированна
                {
                    boxs[i].block = 3;//устанавливаем блокировку
                    player1.spaceShipPlayer1[id].position = i;//позиция корабля (номер ячейки)
                    player1.spaceShipPlayer1[id].player1PointX1 = boxs[i].pointX2;
                    player1.spaceShipPlayer1[id].player1PointY1 = boxs[i].pointY2 + 10;
                    player1.spaceShipPlayer1[id].player1PointX2 = boxs[i].pointX4 - 5;
                    player1.spaceShipPlayer1[id].player1PointY2 = boxs[i].pointY4;
                    player1.spaceShipPlayer1[id].player1PointX3 = boxs[i].pointX6;
                    player1.spaceShipPlayer1[id].player1PointY3 = boxs[i].pointY6 - 10;
                }
                else
                {
                    id--;//возвращаем id назад, т.к. корабаль небыл размещен
                }
            }
            spaceShipPlayer1.AddRange(player1.spaceShipPlayer1);
            player1.spaceShipPlayer1.Clear();

            for (int id = 0; id < player2.spaceShipPlayer2.Count; id++)//работаем с кораблями компьютера
            {
                int i = r.Next(boxs.Count - 40, boxs.Count);//рандомное место корабля
                if (boxs[i].block == 0)//если ячейка не блокированна
                {
                    boxs[i].block = 4;//устанавливаем блокировку
                    player2.spaceShipPlayer2[id].position = i;//позиция корабля (номер ячейки) 
                    player2.spaceShipPlayer2[id].player2PointX1 = boxs[i].pointX3;
                    player2.spaceShipPlayer2[id].player2PointY1 = boxs[i].pointY3 + 10;
                    player2.spaceShipPlayer2[id].player2PointX2 = boxs[i].pointX1 + 5;
                    player2.spaceShipPlayer2[id].player2PointY2 = boxs[i].pointY1;
                    player2.spaceShipPlayer2[id].player2PointX3 = boxs[i].pointX5;
                    player2.spaceShipPlayer2[id].player2PointY3 = boxs[i].pointY5 - 10;
                }
                else
                {
                    id--;//возвращаем id назад, т.к. корабаль небыл размещен
                }
            }
            spaceShipPlayer2.AddRange(player2.spaceShipPlayer2);
            player2.spaceShipPlayer2.Clear();

            for (int i = 0; i < barriers.barrierType1.Count; i++)
            {
                id = r.Next(50, boxs.Count - 50);//рандомное место препятствия
                if (boxs[id].block == 0)//если ячейка не блокированна
                {
                    boxs[id].block = 1;//устанавливаем блокировку
                    barriers.barrierType1[i].position = boxs[id].id;//позиция препятствия (номер ячейки)
                }
                else
                {
                    i--;
                }
            }
            barrierType1.AddRange(barriers.barrierType1);
            barriers.barrierType1.Clear();

            for (int i = 0; i < barriers.barrierType2.Count; i++)
            {
                id = r.Next(50, boxs.Count - 50);//рандомное место препятствия
                if (boxs[id].block == 0)//если ячейка не блокированна
                {
                    boxs[id].block = 2;//устанавливаем блокировку
                    barriers.barrierType2[i].position = boxs[id].id;//позиция препятствия (номер ячейки)
                }
                else
                {
                    i--;
                }
            }
            barrierType2.AddRange(barriers.barrierType2);
            barriers.barrierType2.Clear();
        }
    }
}
