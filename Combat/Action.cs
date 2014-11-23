using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat
{
    class Action
    {
        public int damage;

        public Action(int selectPreviousBox, int selectNewBox, int activePlayer, ref List<BoxMap> boxs, ref List<SpaceShip> spaceShipPlayer1, ref List<SpaceShip> spaceShipPlayer2)
        {
            boxs[selectPreviousBox].block = 0;//разблокируем предыдущую ячейку
            if (activePlayer == 0)
            {
                boxs[selectNewBox].block = 3;//блокируем текущую
                for (int id = 0; id < spaceShipPlayer1.Count; id++)
                {
                    if (spaceShipPlayer1[id].position == selectPreviousBox)//находим корабль
                    {
                        spaceShipPlayer1[id].position = selectNewBox;//передвигаем корабль
                        spaceShipPlayer1[id].player1PointX1 = boxs[selectNewBox].pointX2;
                        spaceShipPlayer1[id].player1PointY1 = boxs[selectNewBox].pointY2 + 10;
                        spaceShipPlayer1[id].player1PointX2 = boxs[selectNewBox].pointX4 - 5;
                        spaceShipPlayer1[id].player1PointY2 = boxs[selectNewBox].pointY4;
                        spaceShipPlayer1[id].player1PointX3 = boxs[selectNewBox].pointX6;
                        spaceShipPlayer1[id].player1PointY3 = boxs[selectNewBox].pointY6 - 10;
                    }
                }
            }
            else
            {
                boxs[selectNewBox].block = 4;//блокируем текущую
                for (int id = 0; id < spaceShipPlayer2.Count; id++)
                {
                    if (spaceShipPlayer2[id].position == selectPreviousBox)//находим корабль
                    {
                        spaceShipPlayer2[id].position = selectNewBox;//передвигаем корабль
                        spaceShipPlayer2[id].player2PointX1 = boxs[selectNewBox].pointX3;
                        spaceShipPlayer2[id].player2PointY1 = boxs[selectNewBox].pointY3 + 10;
                        spaceShipPlayer2[id].player2PointX2 = boxs[selectNewBox].pointX1 + 5;
                        spaceShipPlayer2[id].player2PointY2 = boxs[selectNewBox].pointY1;
                        spaceShipPlayer2[id].player2PointX3 = boxs[selectNewBox].pointX5;
                        spaceShipPlayer2[id].player2PointY3 = boxs[selectNewBox].pointY5 - 10;
                    }
                }
            }
            boxs[selectNewBox].forstep = 0;
        }

        public Action(int selectPreviousBox, int selectNewBox, int activePlayer, ref List<BoxMap> boxs, ref List<SpaceShip> spaceShipPlayer1, ref List<SpaceShip> spaceShipPlayer2, ref List<Barrier> barriersType1, ref List<Barrier> barriersType2)
        {
            if (activePlayer == 0)
            {
                for (int id = 0; id < spaceShipPlayer1.Count; id++)
                {
                    if (spaceShipPlayer1[id].position == selectPreviousBox)//находим атакующий корабль
                    {
                        damage = spaceShipPlayer1[id].damage;//находим его дамаг
                    }
                }
                switch (boxs[selectNewBox].block)//выбираем тип препятствия
                {
                    case 1:
                        for (int id = 0; id < barriersType1.Count; id++)
                        {
                            if (barriersType1[id].position == selectNewBox)//находим препятствие
                            {
                                barriersType1[id].hp -= damage;//атакуем
                                if (barriersType1[id].hp <= 0)//если hp доходит до 0
                                {
                                    boxs[selectNewBox].block = 0;//разблокируем ячейку
                                    barriersType1.Remove(barriersType1[id]);//удаляем препятствие
                                }
                            }
                        }
                        break;
                    case 2:
                        for (int id = 0; id < barriersType2.Count; id++)
                        {
                            if (barriersType2[id].position == selectNewBox)//находим препятствие
                            {
                                barriersType2[id].hp -= damage;//атакуем
                                if (barriersType2[id].hp <= 0)//если hp доходит до 0
                                {
                                    boxs[selectNewBox].block = 0;//разблокируем ячейку
                                    barriersType2.Remove(barriersType2[id]);//удаляем препятствие
                                }
                            }
                        }
                        break;
                    case 4:
                        for (int id = 0; id < spaceShipPlayer2.Count; id++)
                        {
                            if (spaceShipPlayer2[id].position == selectNewBox)//находим корабль
                            {
                                spaceShipPlayer2[id].hp -= damage;//атакуем
                                if (spaceShipPlayer2[id].hp <= 0)//если hp доходит до 0
                                {
                                    boxs[selectNewBox].block = 0;//разблокируем ячейку
                                    spaceShipPlayer2.Remove(spaceShipPlayer2[id]);//удаляем корабль
                                }
                            }
                        }
                        break;
                }
            }
            else
            {
                for (int id = 0; id < spaceShipPlayer2.Count; id++)
                {
                    if (spaceShipPlayer2[id].position == selectPreviousBox)//находим атакующий корабль
                    {
                        damage = spaceShipPlayer2[id].damage;//находим его дамаг
                    }
                }
                switch (boxs[selectNewBox].block)//выбираем тип препятствия
                {
                    case 1:
                        for (int id = 0; id < barriersType1.Count; id++)
                        {
                            if (barriersType1[id].position == selectNewBox)//находим препятствие
                            {
                                barriersType1[id].hp -= damage;//атакуем
                                if (barriersType1[id].hp <= 0)//если hp доходит до 0
                                {
                                    boxs[selectNewBox].block = 0;//разблокируем ячейку
                                    barriersType1.Remove(barriersType1[id]);//удаляем препятствие
                                }
                            }
                        }
                        break;
                    case 2:
                        for (int id = 0; id < barriersType2.Count; id++)
                        {
                            if (barriersType2[id].position == selectNewBox)//находим препятствие
                            {
                                barriersType2[id].hp -= damage;//атакуем
                                if (barriersType2[id].hp <= 0)//если hp доходит до 0
                                {
                                    boxs[selectNewBox].block = 0;//разблокируем ячейку
                                    barriersType2.Remove(barriersType2[id]);//удаляем препятствие
                                }
                            }
                        }
                        break;
                    case 3:
                        for (int id = 0; id < spaceShipPlayer1.Count; id++)
                        {
                            if (spaceShipPlayer1[id].position == selectNewBox)//находим корабль
                            {
                                spaceShipPlayer1[id].hp -= damage;//атакуем
                                if (spaceShipPlayer1[id].hp <= 0)//если hp доходит до 0
                                {
                                    boxs[selectNewBox].block = 0;//разблокируем ячейку
                                    spaceShipPlayer1.Remove(spaceShipPlayer1[id]);//удаляем корабль
                                }
                            }
                        }
                        break;
                }
            }
            boxs[selectNewBox].forattack = 0;
        }
    }
}
