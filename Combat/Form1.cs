using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Combat
{
    public partial class Form_CombatScreen : Form
    {
        Bitmap combatBitmap;
        Random r = new Random();
        List<BoxMap> boxs = new List<BoxMap>();
        List<Spaceship> spsm = new List<Spaceship>();
        List<Spaceship> spsc = new List<Spaceship>();
        List<Barrier> bars1 = new List<Barrier>();
        List<Barrier> bars2 = new List<Barrier>();
        int damage;
        int id = 0;
        int cl = 0;
        int select = -10000;//подумать
        int select2 = -10000;
        

        public Form_CombatScreen()
        {
            InitializeComponent();
            Spaceship_Generate();
            Box_Generate();
            Draw();
        }

        public void Box_Generate() //генерируем карту
        {
            FullMap map = new FullMap((int)(combatImage.Width), (int)(combatImage.Height));
            boxs.AddRange(map.boxs);

            int a = r.Next(25, 50);//рандомное число препятствий 1го типа (маленьких)
            for (int i = 0; i < a; i++)
            {
                id = r.Next(50, boxs.Count - 50);//рандомное место препятствия
                if (boxs[id].block == 0)//если ячейка не блокированна
                {
                    boxs[id].block = 1;//устанавливаем блокировку
                    Barrier bar = new Barrier();
                    bar.type = boxs[id].block;
                    bar.hp = r.Next(20, 100);//hp препятствия
                    bar.position = boxs[id].id;//позиция препятствия (номер ячейки)
                    bars1.Add(bar);//заполняем коллекцию препятствий 1го типа
                }
            }
            a = r.Next(10, 20);//рандомное число препятствий 2го типа (большие)
            for (int i = 0; i < a; i++)
            {

                id = r.Next(50, boxs.Count - 50);//рандомное место препятствия
                if (boxs[id].block == 0)//если ячейка не блокированна
                {
                    boxs[id].block = 2;//устанавливаем блокировку
                    Barrier bar = new Barrier();
                    bar.type = boxs[id].block;
                    bar.hp = r.Next(1000, 2000);//hp препятствия
                    bar.position = boxs[id].id;//позиция препятствия (номер ячейки)
                    bars2.Add(bar);//заполняем коллекцию препятствий 2го типа
                }
            }
            for (int id = 0; id < spsm.Count; id++)//работаем с нашими кораблями
            {
                int i = r.Next(0, 40);//рандомное место корабля
                if (boxs[i].block == 0)//если ячейка не блокированна
                    {
                        boxs[i].block = 3;//устанавливаем блокировку
                        spsm[id].position = i;//позиция препятствия (номер ячейки)
                    }
                    else
                    {
                        id--;//возвращаем id назад, т.к. корабаль небыл размещен
                    }
            }
            for (int id = 0; id < spsc.Count; id++)//работаем с кораблями компьютера
            {
                int i = r.Next(boxs.Count - 40, boxs.Count);//рандомное место корабля
                    if (boxs[i].block == 0)//если ячейка не блокированна
                    {
                        boxs[i].block = 4;//устанавливаем блокировку
                        spsc[id].position = i;//позиция препятствия (номер ячейки)
                    }
                    else
                    {
                        id--;//возвращаем id назад, т.к. корабаль небыл размещен
                    }
            }
      }
        
        public void Spaceship_Generate()//генерируем корабли
        {
            for (int i = 0; i < 10; i++)//10 кораблей
            {
                Spaceship sp = new Spaceship(0, 0);//тип корабля и оружия пока 1
                sp.own = 1;//корабль наш
                spsm.Add(sp);//заполняем колекцию наших кораблей
            }
            for (int i = 0; i < 10; i++)//10 кораблей
            {
                Spaceship sp = new Spaceship(0, 0);//тип корабля и оружия пока 1
                sp.own = 0;//корабль компьютера
                spsc.Add(sp);//заполняем колекцию кораблей компьютера
            }
        }

        public void Step()//передвижение
        {
            boxs[select].block = 0;//разблокируем предыдущую ячейку
            boxs[select2].block = 3;//блокируем текущую
            for (int id = 0; id < spsm.Count; id++)
            {
                if (spsm[id].position == select)//находим корабль
                {
                    spsm[id].position = select2;//передвигаем корабль
                }
            }
            boxs[select2].forstep = 0;
            select = -(2 * boxs.Count);
            select2 = -(2 * boxs.Count);
            Draw();
        }

        public void Attack()
        {
            for (int id = 0; id < spsm.Count; id++)
            {
                if (spsm[id].position == select)//находим атакующий корабль
                {
                    damage = spsm[id].damage;//находим его дамаг
                }
            }
            switch(boxs[select2].block)//выбираем тип препятствия
            {
                case 1:
                    for (int id = 0; id < bars1.Count; id++)
                    {
                        if (bars1[id].position == select2)//находим препятствие
                        {
                            bars1[id].hp -= damage;//атакуем
                            if (bars1[id].hp <= 0)//если hp доходит до 0
                            {
                                boxs[select2].block = 0;//разблокируем ячейку
                                bars1.Remove(bars1[id]);//удаляем препятствие
                            }
                        }
                    }
                    break;
                case 2:
                    for (int id = 0; id < bars2.Count; id++)
                    {
                        if (bars2[id].position == select2)//находим препятствие
                        {
                            bars2[id].hp -= damage;//атакуем
                            if (bars2[id].hp <= 0)//если hp доходит до 0
                            {
                                boxs[select2].block = 0;//разблокируем ячейку
                                bars2.Remove(bars2[id]);//удаляем препятствие
                            }
                        }
                    }
                    break;
                case 4:
                    for (int id = 0; id < spsc.Count; id++)
                    {
                        if (spsc[id].position == select2)//находим корабль
                        {
                            spsc[id].hp -= damage;//атакуем
                            if (spsc[id].hp <= 0)//если hp доходит до 0
                            {
                                boxs[select2].block = 0;//разблокируем ячейку
                                spsc.Remove(spsc[id]);//удаляем корабль
                            }
                        }
                    }
                    break;
            }
            boxs[select2].forattack = 0;
            select = -(2 * boxs.Count);
            select2 = -(2 * boxs.Count);
            if (spsc.Count == 0)//уничтожены все корабли противника
            {
                Form_Win fw = new Form_Win();
                fw.ShowDialog();//выводим сообщение о победе
                Close();//закрываем окно
            }
            else
            {
                Draw();
            }
           
        }//атака

        public void Draw()//рисование карты без выделений
        {
            if (cl == 1)
            {
                for (int id1 = 0; id1 < spsm.Count; id1++)
                {
                    if (spsm[id1].position == select)//находим выбранный корабль
                    {
                        labelDamage.Text = "Damage: " + spsm[id1].damage.ToString();//пишем его дамаг
                    }
                }
            }
            else
            {
                labelDamage.Text = "";
            }
            combatBitmap = new Bitmap(combatImage.Width, combatImage.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(combatBitmap);
            g.FillRectangle(Brushes.Blue, 0, 0, combatBitmap.Width, combatBitmap.Height);//рисуем фон окна

            Pen redPen = new Pen(Color.Red, 1);

            SolidBrush greenBrush = new SolidBrush(Color.Green);
            SolidBrush redBrush = new SolidBrush(Color.Red);
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush coralBrush = new SolidBrush(Color.Coral);

            id = 0;
            for (int j = 0; j < (int)(combatImage.Width / 60); j++)
            {
                for (int i = 0; i < (int)(combatImage.Height / 40) - 1; i++)
                {
                    Point[] myPointArrayHex = {  //точки для рисования шестиугольника
                    new Point(boxs[id].p1x,boxs[id].p1y),
                    new Point(boxs[id].p2x,boxs[id].p2y),
                    new Point(boxs[id].p3x,boxs[id].p3y),
                    new Point(boxs[id].p4x,boxs[id].p4y),
                    new Point(boxs[id].p5x,boxs[id].p5y),
                    new Point(boxs[id].p6x,boxs[id].p6y)};
                    if (((boxs[id].id == select + 1) ||
                        (boxs[id].id == select - 1) ||
                        (boxs[id].id == select + 18) ||
                        (boxs[id].id == select - 18) ||
                        (boxs[id].id == select + 19) ||
                        (boxs[id].id == select - 17)) &&//некоторое условие для рисования ячейки для шага,
                        (boxs[id].block == 0))//пока на 1 ячейку, надо придумать математику на несклько ячеек
                    {
                        boxs[id].forstep = 1;//помечаем ячейку, как ячейку для шага
                        g.FillPolygon(greenBrush, myPointArrayHex);//закрашиваем шестиугольник
                        g.DrawPolygon(redPen, myPointArrayHex);//рисуем контур шестиугольника
                    }
                    else
                    {
                        if ((
                            (boxs[id].id == select + 18) ||
                            (boxs[id].id == select + 19)) &&
                            (boxs[id].block != 0) &&
                            (boxs[id].block != -1) &&//некоторое условие для рисования ячейки для атаки,
                            (boxs[id].block != 3))//пока на 1 ячейку, надо придумать математику на несклько ячеек
                        {
                            boxs[id].forattack = 1;//помечаем ячейку, как ячейку для атаки
                            g.FillPolygon(coralBrush, myPointArrayHex);//закрашиваем шестиугольник
                            g.DrawPolygon(redPen, myPointArrayHex);//рисуем контур шестиугольника
                        }
                        else
                        {
                            boxs[id].forattack = 0;//ячейка не для атаки
                            boxs[id].forstep = 0;//ячейка не для шага
                            g.DrawPolygon(redPen, myPointArrayHex);//рисуем шестиугольник
                        }
                    }
                    switch (boxs[id].block)
                    {
                        case 0:
                            //g.DrawString(boxs[id].id.ToString(), new Font("Arial", 8.0F), Brushes.White, new PointF(10 + j * 60, 10 + i * 40));
                            break;
                        case 1://рисование препятствия 1го типа
                            for (int id1 = 0; id1 < bars1.Count; id1++)
                            {
                                if (bars1[id1].position == boxs[id].id)
                                {
                                    g.FillEllipse(blackBrush, boxs[id].p2x, boxs[id].p2y + 10, 20, 20);//рисуем препятствие
                                    g.DrawString(bars1[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Red, new PointF(10 + j * 60, 10 + i * 40));//подписываем hp
                                }
                            }
                            break;
                        case 2://рисование препятствия 2го типа
                            for (int id1 = 0; id1 < bars2.Count; id1++)
                            {
                                if (bars2[id1].position == boxs[id].id)
                                {
                                    g.FillEllipse(redBrush, boxs[id].p2x - 5, boxs[id].p2y + 5, 30, 30);//рисуем препятствие
                                    g.DrawString(bars2[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Black, new PointF(10 + j * 60, 10 + i * 40));//подписываем hp
                                }
                            }
                            break;
                        case 3://рисование нашего корабля
                            for (int id1 = 0; id1 < spsm.Count; id1++)
                            {
                                if (spsm[id1].position == boxs[id].id)
                                {
                                    Point[] myPointArrayShip = {  //точки для рисование корабля
                                    new Point(spsm[0].mp1x+j*60, spsm[0].mp1y+i*40),
                                    new Point(spsm[0].mp2x+j*60, spsm[0].mp2y+i*40),
                                    new Point(spsm[0].mp3x+j*60, spsm[0].mp3y+i*40)};
                                    g.FillPolygon(redBrush, myPointArrayShip);//рисуем корабль
                                    g.DrawString(spsm[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Black, new PointF(10 + j * 60, 10 + i * 40));//подписываем hp
                                }
                            }
                                break;
                        case 4://рисование корабля компьютера
                                for (int id1 = 0; id1 < spsc.Count; id1++)
                                {
                                    if (spsc[id1].position == boxs[id].id)
                                    {
                                        Point[] compPointArrayShip = {  //точки для рисование корабля
                                        new Point(spsc[0].cp1x+j*60, spsc[0].cp1y+i*40),
                                        new Point(spsc[0].cp2x+j*60, spsc[0].cp2y+i*40),
                                        new Point(spsc[0].cp3x+j*60, spsc[0].cp3y+i*40)};
                                        g.FillPolygon(blackBrush, compPointArrayShip);//рисуем корабль
                                        g.DrawString(spsc[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Red, new PointF(10 + j * 60, 10 + i * 40));//подписываем hp
                                    }
                                }
                            break;
                    }
                    id++;
                }
                for (int k = 0; k < (int)(combatImage.Height / 40) - 1; k++)
                {
                    Point[] myPointArrayHex = {  //точки для рисования шестиугольника
                    new Point(boxs[id].p1x,boxs[id].p1y),
                    new Point(boxs[id].p2x,boxs[id].p2y),
                    new Point(boxs[id].p3x,boxs[id].p3y),
                    new Point(boxs[id].p4x,boxs[id].p4y),
                    new Point(boxs[id].p5x,boxs[id].p5y),
                    new Point(boxs[id].p6x,boxs[id].p6y)};
                    if (((boxs[id].id == select + 1) ||
                       (boxs[id].id == select - 1) ||
                       (boxs[id].id == select + 17) ||
                       (boxs[id].id == select - 18) ||
                       (boxs[id].id == select + 18) ||
                       (boxs[id].id == select - 19)) &&//некоторое условие для рисования ячейки для шага,
                       (boxs[id].block == 0))//пока на 1 ячейку, надо придумать математику на несклько ячеек
                    {
                        boxs[id].forstep = 1;//помечаем ячейку, как ячейку для шага
                        g.FillPolygon(greenBrush, myPointArrayHex);//закрашиваем шестиугольник
                        g.DrawPolygon(redPen, myPointArrayHex);//рисуем контур шестиугольника
                    }
                    else
                    {
                        if ((
                            (boxs[id].id == select + 17) ||
                            (boxs[id].id == select + 18)) &&
                            (boxs[id].block != 0) &&
                            (boxs[id].block != -1) &&//некоторое условие для рисования ячейки для атаки,
                            (boxs[id].block != 3))//пока на 1 ячейку, надо придумать математику на несклько ячеек
                        {
                            boxs[id].forattack = 1;//помечаем ячейку, как ячейку для атаки
                            g.FillPolygon(coralBrush, myPointArrayHex);//закрашиваем шестиугольник
                            g.DrawPolygon(redPen, myPointArrayHex);//рисуем контур шестиугольника
                        }
                        else
                        {
                            boxs[id].forattack = 0;//ячейка не для атаки
                            boxs[id].forstep = 0;//ячейка не для шага
                            g.DrawPolygon(redPen, myPointArrayHex);//рисуем шестиугольник
                        }
                    }
                    switch (boxs[id].block)
                    {
                        case 0:
                            //g.DrawString(boxs[id].id.ToString(), new Font("Arial", 8.0F), Brushes.White, new PointF(40 + j * 60, 30 + k * 40));
                            break;
                        case 1://рисование препятствия 1го типа
                            for (int id1 = 0; id1 < bars1.Count; id1++)
                            {
                                if (bars1[id1].position == boxs[id].id)
                                {
                                    g.FillEllipse(blackBrush, boxs[id].p2x, boxs[id].p2y + 10, 20, 20);//рисуем препятствие
                                    g.DrawString(bars1[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Red, new PointF(40 + j * 60, 30 + k * 40));//подписываем hp
                                }
                            }
                            break;
                        case 2://рисование препятствия 2го типа
                            for (int id1 = 0; id1 < bars2.Count; id1++)
                            {
                                if (bars2[id1].position == boxs[id].id)
                                {
                                    g.FillEllipse(redBrush, boxs[id].p2x - 5, boxs[id].p2y + 5, 30, 30);//рисуем препятствие
                                    g.DrawString(bars2[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Black, new PointF(40 + j * 60, 30 + k * 40));//подписываем hp
                                }
                            }
                            break;
                        case 3://рисование нашего корабля
                            for (int id1 = 0; id1 < spsm.Count; id1++)
                            {
                                if (spsm[id1].position == boxs[id].id)
                                {
                                    Point[] myPointArrayShip = { //точки для рисование корабля
                                    new Point(spsm[0].mp1x+30+j*60, spsm[0].mp1y+20+k*40),
                                    new Point(spsm[0].mp2x+30+j*60, spsm[0].mp2y+20+k*40),
                                    new Point(spsm[0].mp3x+30+j*60, spsm[0].mp3y+20+k*40)};
                                    g.FillPolygon(redBrush, myPointArrayShip);//рисуем корабль
                                    g.DrawString(spsm[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Black, new PointF(40 + j * 60, 30 + k * 40));//подписываем hp
                                }
                            }
                            break;
                        case 4://рисование корабля компьютера
                            for (int id1 = 0; id1 < spsc.Count; id1++)
                            {
                                if (spsc[id1].position == boxs[id].id)
                                {
                                    Point[] compPointArrayShip = {  //точки для рисование корабля
                                    new Point(spsc[0].cp1x+30+j*60, spsc[0].cp1y+20+k*40),
                                    new Point(spsc[0].cp2x+30+j*60, spsc[0].cp2y+20+k*40),
                                    new Point(spsc[0].cp3x+30+j*60, spsc[0].cp3y+20+k*40)};
                                    g.FillPolygon(blackBrush, compPointArrayShip);//рисуем корабль
                                    g.DrawString(spsc[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Red, new PointF(40 + j * 60, 30 + k * 40));//подписываем hp
                                }
                            }
                            break;
                    }
                    id++;
                }
            }
            combatImage.Image = combatBitmap;
            combatImage.Refresh();
        }

        private void combatImage_MouseClick(object sender, MouseEventArgs e)//обработка нажатия
        {
            
            if (cl == 0)//если нажатие первое
            {
                for (int j = 0; j < boxs.Count; j++)
                {
                    BoxMap box = boxs[j];
                    if ((e.X > box.p2x) &&
                        (e.X < box.p3x) &&
                        (e.Y > box.p2y) &&
                        (e.Y < box.p6y) &&
                        (box.block == 3))//находим нажатие на наш корабль
                    {
                        select = box.id;//запоминаем выбраную точку
                        cl = 1;
                        Draw();
                        break;
                    }
                }
            }
            else//если нажатие второе
            {
                for (int j = 0; j < boxs.Count; j++)
                {
                    BoxMap box = boxs[j];
                    if ((e.X > box.p2x) &&
                        (e.X < box.p3x) &&
                        (e.Y > box.p2y) &&
                        (e.Y < box.p6y) &&
                        (box.forstep == 1))//находим нажатие в ячейку для перемещения
                    {
                        select2 = box.id;//запоминаем номер ячейки для перемещения
                        cl = 0;//сбрасываем счетчик кликов
                        Step();
                        break;
                    }
                }
                for (int j = 0; j < boxs.Count; j++)
                {
                    BoxMap box = boxs[j];
                    if ((e.X > box.p2x) &&
                        (e.X < box.p3x) &&
                        (e.Y > box.p2y + 10) &&
                        (e.Y < box.p6y - 10) &&
                        (box.forattack == 1))//находим нажатие в ячейку для атаки
                    {
                        select2 = box.id;//запоминаем номер ячейки для атаки
                        cl = 0;//сбрасываем счетчик кликов
                        Attack();
                        break;
                    }
                }
            }
        }

        private void cancelSelect_MouseClick(object sender, MouseEventArgs e)//отмена выбора корабля
        {
            cl = 0;//сбрасываем счетчик нажатий
            select = -(2 * boxs.Count);
            select2 = -(2 * boxs.Count);
            Draw();
        }
    }
}
