using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat
{
    class FullMap
    {
        public List<BoxMap> boxs = new List<BoxMap>();
        int id = 0;
        public FullMap(int width, int height)
        {
            for (int j = 0; j < (width / 60); j++)//заполнение столбцами в ширину
            {

                for (int i = 0; i < (height / 40) - 1; i++)//нечетный столбец
                {
                    BoxMap box = new BoxMap();
                    box.p1x = box.p1x + j * 60;//координаты для создания шестиугольников
                    box.p1y = box.p1y + i * 40;
                    box.p2x = box.p2x + j * 60;
                    box.p2y = box.p2y + i * 40;
                    box.p3x = box.p3x + j * 60;
                    box.p3y = box.p3y + i * 40;
                    box.p4x = box.p4x + j * 60;
                    box.p4y = box.p4y + i * 40;
                    box.p5x = box.p5x + j * 60;
                    box.p5y = box.p5y + i * 40;
                    box.p6x = box.p6x + j * 60;
                    box.p6y = box.p6y + i * 40;
                    box.id = id;
                    box.block = 0;//все элементы устанавливаем неблокированными
                    boxs.Add(box);//заполняем коллекцию элементами
                    id += 1;
                }
                for (int k = 0; k < (height / 40) - 1; k++)//четный столбец
                {
                    BoxMap box = new BoxMap();
                    box.p1x = box.p1x + 30 + j * 60;//координаты для создания шестиугольников
                    box.p1y = box.p1y + 20 + k * 40;
                    box.p2x = box.p2x + 30 + j * 60;
                    box.p2y = box.p2y + 20 + k * 40;
                    box.p3x = box.p3x + 30 + j * 60;
                    box.p3y = box.p3y + 20 + k * 40;
                    box.p4x = box.p4x + 30 + j * 60;
                    box.p4y = box.p4y + 20 + k * 40;
                    box.p5x = box.p5x + 30 + j * 60;
                    box.p5y = box.p5y + 20 + k * 40;
                    box.p6x = box.p6x + 30 + j * 60;
                    box.p6y = box.p6y + 20 + k * 40;
                    box.id = id;
                    box.block = 0;//элементы устанавливаем неблокированными
                    boxs.Add(box);//заполняем коллекцию элементами
                    id += 1;
                }
            }
        }
    }
}
