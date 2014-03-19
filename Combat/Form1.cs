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
        public Random r = new Random();

        List<BoxMap> boxs = new List<BoxMap>();
        List<SpaceShip> spaceShipPlayer1 = new List<SpaceShip>();
        List<SpaceShip> spaceShipPlayer2 = new List<SpaceShip>();
        List<Barrier> barriersType1 = new List<Barrier>();
        List<Barrier> barriersType2 = new List<Barrier>();

        int damage;
        int id = 0;
        int clickCount = 0;
        int action = 0;
        int maxAction = 5;
        int activePlayer = 0;
        int selectPreviousBox = 0;
        int selectNewBox = 0;
        int stepDistance;
        int attackDistance;
        int spaceShipCount;

        public Form_CombatScreen()
        {
            InitializeComponent();
            
            Form_Start fs = new Form_Start();
            fs.ShowDialog();
            if (fs.DialogResult == DialogResult.OK)
            {
                spaceShipCount = (int)fs.numericSpaceShip.Value;
                if (fs.radioButton640x480.Checked) { combatImage.Width = 640; combatImage.Height = 480; }
                if (fs.radioButton1440x900.Checked) { combatImage.Width = 1440; combatImage.Height = 900; }
                if (fs.radioButton1900x1080.Checked) { combatImage.Width = 1900; combatImage.Height = 1080; }
            }
            else
            {
                Environment.Exit(0);
            }

            Generate_Map();
            Draw();
        }

        public void Generate_Map()
        {
            

            FullMap map = new FullMap((int)(combatImage.Width), (int)(combatImage.Height), spaceShipCount);

            boxs.AddRange(map.boxs);
            map.boxs.Clear();

            spaceShipPlayer1.AddRange(map.spaceShipPlayer1);
            map.spaceShipPlayer1.Clear();

            spaceShipPlayer2.AddRange(map.spaceShipPlayer2);
            map.spaceShipPlayer2.Clear();

            barriersType1.AddRange(map.barrierType1);
            map.barrierType1.Clear();

            barriersType2.AddRange(map.barrierType2);
            map.barrierType2.Clear();
        }

        public void Draw()//рисование
        {

            if (clickCount == 1)
            {
                if (activePlayer == 0)
                {
                    for (int id1 = 0; id1 < spaceShipPlayer1.Count; id1++)
                    {
                        if (spaceShipPlayer1[id1].position == selectPreviousBox)//находим выбранный корабль
                        {
                            labelDamage.Text = "Damage: " + spaceShipPlayer1[id1].damage.ToString();//пишем его дамаг
                        }
                    }
                }
                else
                {
                    for (int id1 = 0; id1 < spaceShipPlayer2.Count; id1++)
                    {
                        if (spaceShipPlayer2[id1].position == selectPreviousBox)//находим выбранный корабль
                        {
                            labelDamage.Text = "Damage: " + spaceShipPlayer2[id1].damage.ToString();//пишем его дамаг
                        }
                    }
                }

            }
            else
            {
                labelDamage.Text = "Damage: ";
            }
            labelAction.Text = "Action: " + (maxAction - action).ToString();

            combatBitmap = new Bitmap(combatImage.Width, combatImage.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(combatBitmap);
            g.FillRectangle(Brushes.DarkBlue, 0, 0, combatBitmap.Width, combatBitmap.Height);//рисуем фон окна

            Pen redPen = new Pen(Color.Red, 1);
            Pen blackPen = new Pen(Color.Black, 1);

            SolidBrush greenBrush = new SolidBrush(Color.Green);
            SolidBrush redBrush = new SolidBrush(Color.Red);
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush darkRedBrush = new SolidBrush(Color.DarkRed);

            id = 0;
            if (clickCount == 1)
            {
                stepDistance = 0;
                attackDistance = 0;
                if (boxs[selectPreviousBox].block == 3)
                {
                    for (int id1 = 0; id1 < spaceShipPlayer1.Count; id1++)
                    {
                        if (spaceShipPlayer1[id1].position == boxs[selectPreviousBox].id)
                        {
                            stepDistance = spaceShipPlayer1[id1].stepDistance;
                            attackDistance = spaceShipPlayer1[id1].attackDistance;
                        }
                    }
                }
                if (boxs[selectPreviousBox].block == 4)
                {
                    for (int id1 = 0; id1 < spaceShipPlayer2.Count; id1++)
                    {
                        if (spaceShipPlayer2[id1].position == boxs[selectPreviousBox].id)
                        {
                            stepDistance = spaceShipPlayer2[id1].stepDistance;
                            attackDistance = spaceShipPlayer2[id1].attackDistance;
                        }
                    }
                }
            }
            for (int j = 0; j < (int)((combatImage.Width - 20) / 60); j++)
            {
                for (int i = 0; i < (int)(combatImage.Height / 40) - 1; i++)
                {
                    Point[] myPointArrayHex = {  //точки для рисования шестиугольника
                    new Point(boxs[id].pointX1,boxs[id].pointY1),
                    new Point(boxs[id].pointX2,boxs[id].pointY2),
                    new Point(boxs[id].pointX3,boxs[id].pointY3),
                    new Point(boxs[id].pointX4,boxs[id].pointY4),
                    new Point(boxs[id].pointX5,boxs[id].pointY5),
                    new Point(boxs[id].pointX6,boxs[id].pointY6)};

                    if (clickCount == 1)
                    {
                        if ((((Math.Pow((boxs[selectPreviousBox].pointXCenter - boxs[id].pointXCenter), 2) / Math.Pow((53 * stepDistance), 2)) + (Math.Pow((boxs[selectPreviousBox].pointYCenter - boxs[id].pointYCenter), 2) / (Math.Pow((60 * stepDistance), 2)))) <= 1) &&
                            (boxs[id].block == 0))
                        //пока на 1 ячейку, надо придумать математику на несклько ячеек
                        {
                            boxs[id].forstep = 1;//помечаем ячейку, как ячейку для шага
                            g.FillPolygon(greenBrush, myPointArrayHex);//закрашиваем шестиугольник

                        }
                        else
                        {
                            if (activePlayer == 0)
                            {
                                if ((boxs[id].pointXCenter > boxs[selectPreviousBox].pointXCenter) &&
                                    (boxs[id].pointXCenter < boxs[selectPreviousBox].pointXCenter + 50 * attackDistance) &&
                                    (boxs[id].pointYCenter <= boxs[selectPreviousBox].pointYCenter + 40 * (attackDistance)) &&
                                    (boxs[id].pointYCenter >= boxs[selectPreviousBox].pointYCenter - 40 * (attackDistance)) &&
                                    (boxs[id].block != 0) &&//некоторое условие рисования ячейки для атаки
                                    (boxs[id].block != 3))
                                {
                                    boxs[id].forattack = 1;//помечаем ячейку, как ячейку для атаки
                                    g.FillPolygon(darkRedBrush, myPointArrayHex);//закрашиваем шестиугольник

                                }
                                else
                                {
                                    boxs[id].forattack = 0;//ячейка не для атаки
                                    boxs[id].forstep = 0;//ячейка не для шага

                                }
                            }
                            else
                            {

                                if ((boxs[id].pointXCenter < boxs[selectPreviousBox].pointXCenter) &&
                                        (boxs[id].pointXCenter > boxs[selectPreviousBox].pointXCenter - 50 * attackDistance) &&
                                        (boxs[id].pointYCenter <= boxs[selectPreviousBox].pointYCenter + 40 * (attackDistance)) &&
                                        (boxs[id].pointYCenter >= boxs[selectPreviousBox].pointYCenter - 40 * (attackDistance)) &&
                                        (boxs[id].block != 0) &&//некоторое условие рисования ячейки для атаки
                                        (boxs[id].block != 4))
                                {
                                    boxs[id].forattack = 1;//помечаем ячейку, как ячейку для атаки
                                    g.FillPolygon(darkRedBrush, myPointArrayHex);//закрашиваем шестиугольник

                                }
                                else
                                {
                                    boxs[id].forattack = 0;//ячейка не для атаки
                                    boxs[id].forstep = 0;//ячейка не для шага
                                }
                            }
                        }
                    }
                    g.DrawPolygon(redPen, myPointArrayHex);//рисуем шестиугольник
                    switch (boxs[id].block)
                    {
                        case 0:
                            //g.DrawString(boxs[id].id.ToString(), new Font("Arial", 8.0F), Brushes.White, new PointF(10 + j * 60, 10 + i * 40));
                            break;
                        case 1://рисование препятствия 1го типа
                            for (int id1 = 0; id1 < barriersType1.Count; id1++)
                            {
                                if (barriersType1[id1].position == boxs[id].id)
                                {
                                    g.FillEllipse(blackBrush, boxs[id].pointX2, boxs[id].pointY2 + 10, 20, 20);//рисуем препятствие
                                    g.DrawString(barriersType1[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Red, new PointF(10 + j * 60, 10 + i * 40));//подписываем hp
                                }
                            }
                            break;
                        case 2://рисование препятствия 2го типа
                            for (int id1 = 0; id1 < barriersType2.Count; id1++)
                            {
                                if (barriersType2[id1].position == boxs[id].id)
                                {
                                    g.FillEllipse(redBrush, boxs[id].pointX2 - 5, boxs[id].pointY2 + 5, 30, 30);//рисуем препятствие
                                    g.DrawString(barriersType2[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Black, new PointF(10 + j * 60, 10 + i * 40));//подписываем hp
                                }
                            }
                            break;
                        case 3://рисование нашего корабля
                            for (int id1 = 0; id1 < spaceShipPlayer1.Count; id1++)
                            {
                                if (spaceShipPlayer1[id1].position == boxs[id].id)
                                {
                                    Point[] myPointArrayShip = {  //точки для рисование корабля
                                    new Point(spaceShipPlayer1[id1].player1PointX1, spaceShipPlayer1[id1].player1PointY1),
                                    new Point(spaceShipPlayer1[id1].player1PointX2, spaceShipPlayer1[id1].player1PointY2),
                                    new Point(spaceShipPlayer1[id1].player1PointX3, spaceShipPlayer1[id1].player1PointY3)};
                                    g.FillPolygon(redBrush, myPointArrayShip);//рисуем корабль
                                    g.DrawString(spaceShipPlayer1[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Black, new PointF(10 + j * 60, 10 + i * 40));//подписываем hp
                                }
                            }
                            break;
                        case 4://рисование корабля компьютера
                            for (int id1 = 0; id1 < spaceShipPlayer2.Count; id1++)
                            {
                                if (spaceShipPlayer2[id1].position == boxs[id].id)
                                {
                                    Point[] compPointArrayShip = {  //точки для рисование корабля
                                        new Point(spaceShipPlayer2[id1].player2PointX1, spaceShipPlayer2[id1].player2PointY1),
                                        new Point(spaceShipPlayer2[id1].player2PointX2, spaceShipPlayer2[id1].player2PointY2),
                                        new Point(spaceShipPlayer2[id1].player2PointX3, spaceShipPlayer2[id1].player2PointY3)};
                                    g.FillPolygon(blackBrush, compPointArrayShip);//рисуем корабль
                                    g.DrawString(spaceShipPlayer2[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Red, new PointF(10 + j * 60, 10 + i * 40));//подписываем hp
                                }
                            }
                            break;
                    }
                    id++;
                }
                for (int k = 0; k < (int)(combatImage.Height / 40) - 1; k++)
                {
                    Point[] myPointArrayHex = {  //точки для рисования шестиугольника
                    new Point(boxs[id].pointX1,boxs[id].pointY1),
                    new Point(boxs[id].pointX2,boxs[id].pointY2),
                    new Point(boxs[id].pointX3,boxs[id].pointY3),
                    new Point(boxs[id].pointX4,boxs[id].pointY4),
                    new Point(boxs[id].pointX5,boxs[id].pointY5),
                    new Point(boxs[id].pointX6,boxs[id].pointY6)};
                    if (clickCount == 1)
                    {

                        if ((((Math.Pow((boxs[selectPreviousBox].pointXCenter - boxs[id].pointXCenter), 2) / Math.Pow((53 * stepDistance), 2)) + (Math.Pow((boxs[selectPreviousBox].pointYCenter - boxs[id].pointYCenter), 2) / (Math.Pow((60 * stepDistance), 2)))) <= 1) &&
                            (boxs[id].block == 0))
                        {
                            boxs[id].forstep = 1;//помечаем ячейку, как ячейку для шага
                            g.FillPolygon(greenBrush, myPointArrayHex);//закрашиваем шестиугольник 
                        }
                        else
                        {
                            if (activePlayer == 0)
                            {
                                if ((boxs[id].pointXCenter > boxs[selectPreviousBox].pointXCenter) &&
                                    (boxs[id].pointXCenter < boxs[selectPreviousBox].pointXCenter + 50 * attackDistance) &&
                                    (boxs[id].pointYCenter <= boxs[selectPreviousBox].pointYCenter + 40 * (attackDistance)) &&
                                    (boxs[id].pointYCenter >= boxs[selectPreviousBox].pointYCenter - 40 * (attackDistance)) &&
                                    (boxs[id].block != 0) &&//некоторое условие рисования ячейки для атаки
                                    (boxs[id].block != 3))
                                {
                                    boxs[id].forattack = 1;//помечаем ячейку, как ячейку для атаки
                                    g.FillPolygon(darkRedBrush, myPointArrayHex);//закрашиваем шестиугольник

                                }
                                else
                                {
                                    boxs[id].forattack = 0;//ячейка не для атаки
                                    boxs[id].forstep = 0;//ячейка не для шага

                                }
                            }
                            else
                            {
                                if ((boxs[id].pointXCenter < boxs[selectPreviousBox].pointXCenter) &&
                                        (boxs[id].pointXCenter > boxs[selectPreviousBox].pointXCenter - 50 * attackDistance) &&
                                        (boxs[id].pointYCenter <= boxs[selectPreviousBox].pointYCenter + 40 * (attackDistance)) &&
                                        (boxs[id].pointYCenter >= boxs[selectPreviousBox].pointYCenter - 40 * (attackDistance)) &&
                                        (boxs[id].block != 0) &&//некоторое условие рисования ячейки для атаки
                                        (boxs[id].block != 4))
                                {
                                    boxs[id].forattack = 1;//помечаем ячейку, как ячейку для атаки
                                    g.FillPolygon(darkRedBrush, myPointArrayHex);//закрашиваем шестиугольник

                                }
                                else
                                {
                                    boxs[id].forattack = 0;//ячейка не для атаки
                                    boxs[id].forstep = 0;//ячейка не для шага

                                }
                            }
                        }
                    }
                    g.DrawPolygon(redPen, myPointArrayHex);//рисуем шестиугольник
                    switch (boxs[id].block)
                    {
                        case 0:
                            //g.DrawString(boxs[id].id.ToString(), new Font("Arial", 8.0F), Brushes.White, new PointF(40 + j * 60, 30 + k * 40));
                            break;
                        case 1://рисование препятствия 1го типа
                            for (int id1 = 0; id1 < barriersType1.Count; id1++)
                            {
                                if (barriersType1[id1].position == boxs[id].id)
                                {
                                    g.FillEllipse(blackBrush, boxs[id].pointX2, boxs[id].pointY2 + 10, 20, 20);//рисуем препятствие
                                    g.DrawString(barriersType1[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Red, new PointF(40 + j * 60, 30 + k * 40));//подписываем hp
                                }
                            }
                            break;
                        case 2://рисование препятствия 2го типа
                            for (int id1 = 0; id1 < barriersType2.Count; id1++)
                            {
                                if (barriersType2[id1].position == boxs[id].id)
                                {
                                    g.FillEllipse(redBrush, boxs[id].pointX2 - 5, boxs[id].pointY2 + 5, 30, 30);//рисуем препятствие
                                    g.DrawString(barriersType2[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Black, new PointF(40 + j * 60, 30 + k * 40));//подписываем hp
                                }
                            }
                            break;
                        case 3://рисование нашего корабля
                            for (int id1 = 0; id1 < spaceShipPlayer1.Count; id1++)
                            {
                                if (spaceShipPlayer1[id1].position == boxs[id].id)
                                {
                                    Point[] myPointArrayShip = { //точки для рисование корабля
                                    new Point(spaceShipPlayer1[id1].player1PointX1, spaceShipPlayer1[id1].player1PointY1),
                                    new Point(spaceShipPlayer1[id1].player1PointX2, spaceShipPlayer1[id1].player1PointY2),
                                    new Point(spaceShipPlayer1[id1].player1PointX3, spaceShipPlayer1[id1].player1PointY3)};
                                    g.FillPolygon(redBrush, myPointArrayShip);//рисуем корабль
                                    g.DrawString(spaceShipPlayer1[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Black, new PointF(40 + j * 60, 30 + k * 40));//подписываем hp
                                }
                            }
                            break;
                        case 4://рисование корабля компьютера
                            for (int id1 = 0; id1 < spaceShipPlayer2.Count; id1++)
                            {
                                if (spaceShipPlayer2[id1].position == boxs[id].id)
                                {
                                    Point[] compPointArrayShip = {  //точки для рисование корабля
                                    new Point(spaceShipPlayer2[id1].player2PointX1, spaceShipPlayer2[id1].player2PointY1),
                                    new Point(spaceShipPlayer2[id1].player2PointX2, spaceShipPlayer2[id1].player2PointY2),
                                    new Point(spaceShipPlayer2[id1].player2PointX3, spaceShipPlayer2[id1].player2PointY3)};
                                    g.FillPolygon(blackBrush, compPointArrayShip);//рисуем корабль
                                    g.DrawString(spaceShipPlayer2[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Red, new PointF(40 + j * 60, 30 + k * 40));//подписываем hp
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
            if (clickCount == 0)//если нажатие первое
            {
                for (int j = 0; j < boxs.Count; j++)
                {
                    if (activePlayer == 0)
                    {
                        BoxMap box = boxs[j];
                        if ((e.X > box.pointX2) &&
                            (e.X < box.pointX3) &&
                            (e.Y > box.pointY2) &&
                            (e.Y < box.pointY6) &&
                            (box.block == 3))//находим нажатие на наш корабль
                        {
                            selectPreviousBox = box.id;//запоминаем выбраную точку
                            clickCount = 1;
                            Draw();
                            break;
                        }
                    }
                    else
                    {
                        BoxMap box = boxs[j];
                        if ((e.X > box.pointX2) &&
                            (e.X < box.pointX3) &&
                            (e.Y > box.pointY2) &&
                            (e.Y < box.pointY6) &&
                            (box.block == 4))//находим нажатие на наш корабль
                        {
                            selectPreviousBox = box.id;//запоминаем выбраную точку
                            clickCount = 1;
                            Draw();
                            break;
                        }
                    }
                }
            }
            else//если нажатие второе
            {
                for (int j = 0; j < boxs.Count; j++)
                {
                    BoxMap box = boxs[j];
                    if ((e.X > box.pointX2) &&
                        (e.X < box.pointX3) &&
                        (e.Y > box.pointY2) &&
                        (e.Y < box.pointY6) &&
                        (box.forstep == 1))//находим нажатие в ячейку для перемещения
                    {
                        selectNewBox = box.id;//запоминаем номер ячейки для перемещения
                        clickCount = 0;//сбрасываем счетчик кликов

                        Action actionStep = new Action(selectPreviousBox, selectNewBox, activePlayer, ref boxs, ref spaceShipPlayer1, ref  spaceShipPlayer2);

                        selectPreviousBox = 0;
                        selectPreviousBox = 0;
                        action++;
                        Draw();
                        break;
                    }
                }
                for (int j = 0; j < boxs.Count; j++)
                {
                    BoxMap box = boxs[j];
                    if ((e.X > box.pointX2) &&
                        (e.X < box.pointX3) &&
                        (e.Y > box.pointY2 + 10) &&
                        (e.Y < box.pointY6 - 10) &&
                        (box.forattack == 1))//находим нажатие в ячейку для атаки
                    {
                        selectNewBox = box.id;//запоминаем номер ячейки для атаки
                        clickCount = 0;//сбрасываем счетчик кликов

                        Action actionAttack = new Action(selectPreviousBox, selectNewBox, activePlayer, ref boxs, ref spaceShipPlayer1, ref  spaceShipPlayer2, ref barriersType1, ref barriersType2);
                        damage = actionAttack.damage;

                        selectPreviousBox = 0;
                        selectNewBox = 0;
                        action++;
                        if (spaceShipPlayer2.Count == 0)//уничтожены все корабли противника
                        {
                            Form_Win fw = new Form_Win(0);
                            fw.ShowDialog();//выводим сообщение о победе
                            Close();//закрываем окно
                        }
                        if (spaceShipPlayer1.Count == 0)//уничтожены все корабли противника
                        {
                            Form_Win fw = new Form_Win(1);
                            fw.ShowDialog();//выводим сообщение о победе
                            Close();//закрываем окно
                        }
                        else
                        {
                            Draw();
                        }
                        break;
                    }
                }

                if (maxAction - action == 0)
                {
                    action = 0;
                    if (activePlayer == 0) { labelTurnPlayer.Text = "Turn Player 2"; activePlayer = 1; }
                    else { labelTurnPlayer.Text = "Turn Player 1"; activePlayer = 0; }
                    labelAction.Text = "Action: " + (maxAction - action).ToString();
                }

            }
        }

        private void cancelSelect_MouseClick(object sender, MouseEventArgs e)//отмена выбора корабля
        {
            clickCount = 0;//сбрасываем счетчик нажатий
            selectPreviousBox = -(2 * boxs.Count);
            selectNewBox = -(2 * boxs.Count);
            Draw();
        }

        private void buttonEndTurn_Click(object sender, EventArgs e)//завершить ход
        {
            clickCount = 0;
            selectPreviousBox = -(2 * boxs.Count);
            selectNewBox = -(2 * boxs.Count);
            action = 0;

            if (activePlayer == 0)
            {
                labelTurnPlayer.Text = "Turn Player 2";
                activePlayer = 1;
            }
            else
            {
                labelTurnPlayer.Text = "Turn Player 1";
                activePlayer = 0;
            }

            Draw();
        }
    }
}