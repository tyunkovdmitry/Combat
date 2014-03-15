using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Combat
{
    public partial class Form_CombatScreen : Form
    {
        public Bitmap combatBitmap;
        Random r = new Random();
        List<BoxMap> boxs = new List<BoxMap>();
        List<Spaceship> spsm = new List<Spaceship>();
        List<Spaceship> spsc = new List<Spaceship>();
        List<Barrier> bars1 = new List<Barrier>();
        List<Barrier> bars2 = new List<Barrier>();
        int damage;
        int id = 0;

        public Form_CombatScreen()
        {
            InitializeComponent();
            Spaceship_Generate();
            Box_Generate();
            Draw();
        }

        public void Box_Generate()
        {
            for (int j = 0; j < 23; j++)
            {

                for (int i = 0; i < 20; i++)
                {
                    BoxMap box = new BoxMap();
                    box.p1x = box.p1x + j * 60;
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
                    if (i == 19) { box.block = -1; }
                    else { box.block = 0; }
                    boxs.Add(box);
                    id += 1;
                }
                for (int k = 0; k < 19; k++)
                {
                    BoxMap box = new BoxMap();
                    box.p1x = box.p1x + 30 + j * 60;
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
                    box.block = 0;
                    boxs.Add(box);
                    id += 1;
                }
            }
            int a = r.Next(15, 25);
            for (int i = 0; i < a; i++)
            {

                id = r.Next(50, 800);
                if (boxs[id].block == 0)
                {
                    boxs[id].block = 1;
                    Barrier bar = new Barrier();
                    bar.type = boxs[id].block;
                    bar.hp = r.Next(15, 40);
                    bar.position = boxs[id].id;
                    bars1.Add(bar);
                }
            }
            a = r.Next(5, 10);
            for (int i = 0; i < a; i++)
            {

                id = r.Next(50, 800);
                if (boxs[id].block == 0)
                {
                    boxs[id].block = 2;
                    Barrier bar = new Barrier();
                    bar.type = boxs[id].block;
                    bar.hp = r.Next(1000, 2000);
                    bar.position = boxs[id].id;
                    bars2.Add(bar);
                }
            }
            for (int id = 0; id < spsm.Count; id++)
            {
                //id = 0;
                if (spsm[id].own == 1)
                {
                    int i = r.Next(1, 38);
                    if (boxs[i].block == 0)
                    {
                        boxs[i].block = 3;
                        spsm[id].position = i;
                    }
                    else
                    {
                        id--;
                    }
                    //id++;
                }
            }
            for (int id = 0; id < spsc.Count; id++)
            {
                // id = 0;
                if (spsc[id].own == 0)
                {
                    int i = r.Next(839, 877);
                    if (boxs[i].block == 0)
                    {
                        boxs[i].block = 4;
                        spsc[id].position = i;
                    }
                    else
                    {
                        id--;
                    }
                    //id++;
                }
            }
      }
        

        public void Spaceship_Generate()
        {
            for (int i = 0; i < 10; i++)
            {
                Spaceship sp = new Spaceship(0, 0);
                sp.own = 1;
                spsm.Add(sp);
            }
            for (int i = 0; i < 10; i++)
            {
                Spaceship sp = new Spaceship(0, 0);
                sp.own = 0;
                spsc.Add(sp);
            }
        }

        public void Step()
        {
            boxs[select].block = 0;
            boxs[select2].block = 3;
            for (int id = 0; id < spsm.Count; id++)
            {
                if (spsm[id].position == select)
                {
                    spsm[id].position = select2;
                }
            }
                Draw();
        }
        public void Attack()
        {
            for (int id = 0; id < spsm.Count; id++)
            {
                if (spsm[id].position == select)
                {
                    damage = spsm[id].damage;
                }
            }
            switch(boxs[select2].block)
            {
                case 1:
                    for (int id = 0; id < bars1.Count; id++)
                    {
                        if (bars1[id].position == select2)
                        {
                            bars1[id].hp -= damage;
                            if (bars1[id].hp <= 0)
                            {
                                boxs[select2].block = 0;
                                bars1.Remove(bars1[id]);
                            }
                        }
                    }
                    break;
                case 2:
                    for (int id = 0; id < bars2.Count; id++)
                    {
                        if (bars2[id].position == select2)
                        {
                            bars2[id].hp -= damage;
                            if (bars2[id].hp <= 0)
                            {
                                boxs[select2].block = 0;
                                bars2.Remove(bars2[id]);
                            }
                        }
                    }
                    break;
                
                case 4:
                    for (int id = 0; id < spsc.Count; id++)
                    {
                        if (spsc[id].position == select2)
                        {
                            spsc[id].hp -= damage;
                            if (spsc[id].hp <= 0)
                            {
                                boxs[select2].block = 0;
                                spsc.Remove(spsc[id]);
                            }
                        }
                    }
                    break;
            }
            if (spsc.Count == 0)
            {
                Form_Win fw = new Form_Win();
                fw.ShowDialog();
                Close();
            }
            else
            {
                Draw();
            }
           
        }

        public void Draw()
        {
            labelDamage.Text = "";
            combatBitmap = new Bitmap(combatImage.Width, combatImage.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(combatBitmap);
            g.FillRectangle(Brushes.Blue, 0, 0, combatBitmap.Width, combatBitmap.Height);

            Pen redPen = new Pen(Color.Red, 1);
            //Pen myPenbl = new Pen(Color.Black, 1);
            SolidBrush redBrush = new SolidBrush(Color.Red);
            SolidBrush blackBrush = new SolidBrush(Color.Black);

            id = 0;
            for (int j = 0; j < 23; j++)
            {
                for (int i = 0; i < 20; i++)
                {
                    Point[] myPointArrayHex = {  
                    new Point(boxs[id].p1x,boxs[id].p1y),
                    new Point(boxs[id].p2x,boxs[id].p2y),
                    new Point(boxs[id].p3x,boxs[id].p3y),
                    new Point(boxs[id].p4x,boxs[id].p4y),
                    new Point(boxs[id].p5x,boxs[id].p5y),
                    new Point(boxs[id].p6x,boxs[id].p6y)};
                    g.DrawPolygon(redPen, myPointArrayHex);
                    switch (boxs[id].block)
                    {
                        case -1:
                            //g.DrawString(boxs[id].id.ToString(), new Font("Arial", 8.0F), Brushes.Black, new PointF(10 + j * 60, 10 + i * 40));
                            break;
                        case 0:
                            //g.DrawString(boxs[id].id.ToString(), new Font("Arial", 8.0F), Brushes.White, new PointF(10 + j * 60, 10 + i * 40));
                            break;
                        case 1:
                            for (int id1 = 0; id1 < bars1.Count; id1++)
                            {
                                if (bars1[id1].position == boxs[id].id)
                                {
                                    g.FillEllipse(blackBrush, boxs[id].p2x, boxs[id].p2y + 10, 20, 20);
                                    g.DrawString(bars1[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Red, new PointF(10 + j * 60, 10 + i * 40));
                                }
                            }
                            break;
                        case 2:
                            for (int id1 = 0; id1 < bars2.Count; id1++)
                            {
                                if (bars2[id1].position == boxs[id].id)
                                {
                                    g.FillEllipse(redBrush, boxs[id].p2x - 5, boxs[id].p2y + 5, 30, 30);
                                    g.DrawString(bars2[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Black, new PointF(10 + j * 60, 10 + i * 40));
                                }
                            }
                            break;
                        case 3:
                            for (int id1 = 0; id1 < spsm.Count; id1++)
                            {
                                if (spsm[id1].position == boxs[id].id)
                                {
                                    Point[] myPointArrayShip = {  
                                    new Point(spsm[0].mp1x+j*60, spsm[0].mp1y+i*40),
                                    new Point(spsm[0].mp2x+j*60, spsm[0].mp2y+i*40),
                                    new Point(spsm[0].mp3x+j*60, spsm[0].mp3y+i*40)};
                                    g.FillPolygon(redBrush, myPointArrayShip);
                                    g.DrawString(spsm[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Black, new PointF(10 + j * 60, 10 + i * 40));
                                }
                            }
                                break;
                        case 4:
                                for (int id1 = 0; id1 < spsc.Count; id1++)
                                {
                                    if (spsc[id1].position == boxs[id].id)
                                    {
                                        Point[] compPointArrayShip = {  
                                        new Point(spsc[0].cp1x+j*60, spsc[0].cp1y+i*40),
                                        new Point(spsc[0].cp2x+j*60, spsc[0].cp2y+i*40),
                                        new Point(spsc[0].cp3x+j*60, spsc[0].cp3y+i*40)};
                                        g.FillPolygon(blackBrush, compPointArrayShip);
                                        g.DrawString(spsc[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Red, new PointF(10 + j * 60, 10 + i * 40));
                                    }
                                }
                            break;
                    }
                    id++;
                }
                for (int k = 0; k < 19; k++)
                {
                    Point[] myPointArrayHex = {  
                    new Point(boxs[id].p1x,boxs[id].p1y),
                    new Point(boxs[id].p2x,boxs[id].p2y),
                    new Point(boxs[id].p3x,boxs[id].p3y),
                    new Point(boxs[id].p4x,boxs[id].p4y),
                    new Point(boxs[id].p5x,boxs[id].p5y),
                    new Point(boxs[id].p6x,boxs[id].p6y)};
                    g.DrawPolygon(redPen, myPointArrayHex);
                    switch (boxs[id].block)
                    {
                        case 0:
                            //g.DrawString(boxs[id].id.ToString(), new Font("Arial", 8.0F), Brushes.White, new PointF(40 + j * 60, 30 + k * 40));
                            break;
                        case 1:
                            for (int id1 = 0; id1 < bars1.Count; id1++)
                            {
                                if (bars1[id1].position == boxs[id].id)
                                {
                                    g.FillEllipse(blackBrush, boxs[id].p2x, boxs[id].p2y + 10, 20, 20);
                                    g.DrawString(bars1[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Red, new PointF(40 + j * 60, 30 + k * 40));
                                }
                            }
                            break;
                        case 2:
                            for (int id1 = 0; id1 < bars2.Count; id1++)
                            {
                                if (bars2[id1].position == boxs[id].id)
                                {
                                    g.FillEllipse(redBrush, boxs[id].p2x - 5, boxs[id].p2y + 5, 30, 30);
                                    g.DrawString(bars2[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Black, new PointF(40 + j * 60, 30 + k * 40));
                                }
                            }
                            break;
                        case 3:
                            for (int id1 = 0; id1 < spsm.Count; id1++)
                            {
                                if (spsm[id1].position == boxs[id].id)
                                {
                                    Point[] myPointArrayShip = { 
                                    new Point(spsm[0].mp1x+30+j*60, spsm[0].mp1y+20+k*40),
                                    new Point(spsm[0].mp2x+30+j*60, spsm[0].mp2y+20+k*40),
                                    new Point(spsm[0].mp3x+30+j*60, spsm[0].mp3y+20+k*40)};
                                    g.FillPolygon(redBrush, myPointArrayShip);
                                    g.DrawString(spsm[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Black, new PointF(40 + j * 60, 30 + k * 40));
                                }
                            }
                            break;
                        case 4:
                            for (int id1 = 0; id1 < spsc.Count; id1++)
                            {
                                if (spsc[id1].position == boxs[id].id)
                                {
                                    Point[] compPointArrayShip = {  
                                    new Point(spsc[0].cp1x+30+j*60, spsc[0].cp1y+20+k*40),
                                    new Point(spsc[0].cp2x+30+j*60, spsc[0].cp2y+20+k*40),
                                    new Point(spsc[0].cp3x+30+j*60, spsc[0].cp3y+20+k*40)};
                                    g.FillPolygon(blackBrush, compPointArrayShip);
                                    g.DrawString(spsc[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Red, new PointF(40 + j * 60, 30 + k * 40));
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
        int cl = 0;
        int select;
        int select2;
        private void combatImage_MouseClick(object sender, MouseEventArgs e)
        {
            if (cl == 0)
            {
                for (int j = 0; j < boxs.Count; j++)
                {
                    BoxMap box = boxs[j];
                    if ((e.X > box.p2x) &&
                        (e.X < box.p3x) &&
                        (e.Y > box.p2y + 10) &&
                        (e.Y < box.p6y - 10) &&
                        (box.block == 3))
                    {
                        select = box.id;
                        Redraw();
                        cl = 1;

                        break;
                    }
                }
            }
            else
            {
                for (int j = 0; j < boxs.Count; j++)
                {
                    BoxMap box = boxs[j];
                    if ((e.X > box.p2x) &&
                        (e.X < box.p3x) &&
                        (e.Y > box.p2y + 10) &&
                        (e.Y < box.p6y - 10) &&
                        (box.forstep == 1))
                    {
                        select2 = box.id;
                        Step();
                        cl = 0;
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
                        (box.forattack == 1))
                    {
                        select2 = box.id;
                        Attack();
                        cl = 0;
                        break;
                    }
                }
            }
        }

        public void Redraw()
        {
            for (int id1 = 0; id1 < spsm.Count; id1++)
            {
                if (spsm[id1].position == select)
                {
                    labelDamage.Text = spsm[id1].damage.ToString();
                }
            }
            combatBitmap = new Bitmap(combatImage.Width, combatImage.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(combatBitmap);
            g.FillRectangle(Brushes.Blue, 0, 0, combatBitmap.Width, combatBitmap.Height);
            combatImage.Image = combatBitmap;
            Pen redPen = new Pen(Color.Red, 1);
            //Pen myPenbl = new Pen(Color.Black, 1);

            SolidBrush greenBrush = new SolidBrush(Color.Green);
            SolidBrush redBrush = new SolidBrush(Color.Red);
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush coralBrush = new SolidBrush(Color.Coral);

            id = 0;
            for (int j = 0; j < 23; j++)
            {
                for (int i = 0; i < 20; i++)
                {
                    Point[] myPointArrayHex = {  
                    new Point(boxs[id].p1x,boxs[id].p1y),
                    new Point(boxs[id].p2x,boxs[id].p2y),
                    new Point(boxs[id].p3x,boxs[id].p3y),
                    new Point(boxs[id].p4x,boxs[id].p4y),
                    new Point(boxs[id].p5x,boxs[id].p5y),
                    new Point(boxs[id].p6x,boxs[id].p6y)};
                    if (((boxs[id].id == select + 1) ||
                        (boxs[id].id == select - 1) ||
                        (boxs[id].id == select + 19) ||
                        (boxs[id].id == select - 19) ||
                        (boxs[id].id == select + 20) ||
                        (boxs[id].id == select - 20)) &&
                        (boxs[id].block == 0))
                    {
                        boxs[id].forstep = 1;
                        g.FillPolygon(greenBrush, myPointArrayHex);
                        g.DrawPolygon(redPen, myPointArrayHex);
                    }
                    else
                    {
                        if ((
                            (boxs[id].id == select + 19) ||
                            (boxs[id].id == select + 20)) &&
                            (boxs[id].block != 0) &&
                            (boxs[id].block != -1) &&
                            (boxs[id].block != 3))
                        {
                            boxs[id].forattack = 1;
                            g.FillPolygon(coralBrush, myPointArrayHex);
                            g.DrawPolygon(redPen, myPointArrayHex);
                        }
                        else
                        {
                            boxs[id].forattack = 0;
                            boxs[id].forstep = 0;
                            g.DrawPolygon(redPen, myPointArrayHex);
                        }
                    }
                    switch (boxs[id].block)
                    {
                        case -1:
                            //g.DrawString(boxs[id].id.ToString(), new Font("Arial", 8.0F), Brushes.Black, new PointF(10 + j * 60, 10 + i * 40));
                            break;
                        case 0:
                           // g.DrawString(boxs[id].id.ToString(), new Font("Arial", 8.0F), Brushes.White, new PointF(10 + j * 60, 10 + i * 40));
                            break;
                        case 1:
                            for (int id1 = 0; id1 < bars1.Count; id1++)
                            {
                                if (bars1[id1].position == boxs[id].id)
                                {
                                    g.FillEllipse(blackBrush, boxs[id].p2x, boxs[id].p2y + 10, 20, 20);
                                    g.DrawString(bars1[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Red, new PointF(10 + j * 60, 10 + i * 40));
                                }
                            }
                            break;
                        case 2:
                            for (int id1 = 0; id1 < bars2.Count; id1++)
                            {
                                if (bars2[id1].position == boxs[id].id)
                                {
                                    g.FillEllipse(redBrush, boxs[id].p2x - 5, boxs[id].p2y + 5, 30, 30);
                                    g.DrawString(bars2[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Black, new PointF(10 + j * 60, 10 + i * 40));
                                }
                            }
                            break;
                        case 3:
                            for (int id1 = 0; id1 < spsm.Count; id1++)
                            {
                                if (spsm[id1].position == boxs[id].id)
                                {
                                    Point[] myPointArrayShip = {  
                                    new Point(spsm[0].mp1x+j*60, spsm[0].mp1y+i*40),
                                    new Point(spsm[0].mp2x+j*60, spsm[0].mp2y+i*40),
                                    new Point(spsm[0].mp3x+j*60, spsm[0].mp3y+i*40)};
                                    g.FillPolygon(redBrush, myPointArrayShip);
                                    g.DrawString(spsm[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Black, new PointF(10 + j * 60, 10 + i * 40));
                                }
                            }
                            break;
                        case 4:
                            for (int id1 = 0; id1 < spsc.Count; id1++)
                            {
                                if (spsc[id1].position == boxs[id].id)
                                {
                                    Point[] compPointArrayShip = {  
                                        new Point(spsc[0].cp1x+j*60, spsc[0].cp1y+i*40),
                                        new Point(spsc[0].cp2x+j*60, spsc[0].cp2y+i*40),
                                        new Point(spsc[0].cp3x+j*60, spsc[0].cp3y+i*40)};
                                    g.FillPolygon(blackBrush, compPointArrayShip);
                                    g.DrawString(spsc[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Red, new PointF(10 + j * 60, 10 + i * 40));
                                }
                            }
                            break;
                    }
                    id++;
                }
                for (int k = 0; k < 19; k++)
                {
                    Point[] myPointArrayHex = {  
                    new Point(boxs[id].p1x,boxs[id].p1y),
                    new Point(boxs[id].p2x,boxs[id].p2y),
                    new Point(boxs[id].p3x,boxs[id].p3y),
                    new Point(boxs[id].p4x,boxs[id].p4y),
                    new Point(boxs[id].p5x,boxs[id].p5y),
                    new Point(boxs[id].p6x,boxs[id].p6y)};
                    if (((boxs[id].id == select + 1) ||
                        (boxs[id].id == select - 1) ||
                        (boxs[id].id == select + 19) ||
                        (boxs[id].id == select - 19) ||
                        (boxs[id].id == select + 20) ||
                        (boxs[id].id == select - 20)) &&
                        (boxs[id].block == 0))
                    {
                        boxs[id].forstep = 1;

                        g.FillPolygon(greenBrush, myPointArrayHex);
                        g.DrawPolygon(redPen, myPointArrayHex);
                    }
                    else
                    {
                        if ((
                            (boxs[id].id == select + 19) ||
                            (boxs[id].id == select + 20)) &&
                            (boxs[id].block != 0) &&
                            (boxs[id].block != -1) &&
                            (boxs[id].block != 3))
                        {
                            boxs[id].forattack = 1;
                            g.FillPolygon(coralBrush, myPointArrayHex);
                            g.DrawPolygon(redPen, myPointArrayHex);
                        }
                        else
                        {
                            boxs[id].forattack = 0;
                            boxs[id].forstep = 0;
                            g.DrawPolygon(redPen, myPointArrayHex);
                        }
                    }
                    switch (boxs[id].block)
                    {
                        case 0:
                           // g.DrawString(boxs[id].id.ToString(), new Font("Arial", 8.0F), Brushes.White, new PointF(40 + j * 60, 30 + k * 40));
                            break;
                        case 1:
                            for (int id1 = 0; id1 < bars1.Count; id1++)
                            {
                                if (bars1[id1].position == boxs[id].id)
                                {
                                    g.FillEllipse(blackBrush, boxs[id].p2x, boxs[id].p2y + 10, 20, 20);
                                    g.DrawString(bars1[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Red, new PointF(40 + j * 60, 30 + k * 40));
                                }
                            }
                            break;
                        case 2:
                            for (int id1 = 0; id1 < bars2.Count; id1++)
                            {
                                if (bars2[id1].position == boxs[id].id)
                                {
                                    g.FillEllipse(redBrush, boxs[id].p2x - 5, boxs[id].p2y + 5, 30, 30);
                                    g.DrawString(bars2[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Black, new PointF(40 + j * 60, 30 + k * 40));
                                }
                            }
                            break;
                        case 3:
                            for (int id1 = 0; id1 < spsm.Count; id1++)
                            {
                                if (spsm[id1].position == boxs[id].id)
                                {
                                    Point[] myPointArrayShip = { 
                                    new Point(spsm[0].mp1x+30+j*60, spsm[0].mp1y+20+k*40),
                                    new Point(spsm[0].mp2x+30+j*60, spsm[0].mp2y+20+k*40),
                                    new Point(spsm[0].mp3x+30+j*60, spsm[0].mp3y+20+k*40)};
                                    g.FillPolygon(redBrush, myPointArrayShip);
                                    g.DrawString(spsm[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Black, new PointF(40 + j * 60, 30 + k * 40));
                                }
                            }
                            break;
                        case 4:
                            for (int id1 = 0; id1 < spsc.Count; id1++)
                            {
                                if (spsc[id1].position == boxs[id].id)
                                {
                                    Point[] compPointArrayShip = {  
                                    new Point(spsc[0].cp1x+30+j*60, spsc[0].cp1y+20+k*40),
                                    new Point(spsc[0].cp2x+30+j*60, spsc[0].cp2y+20+k*40),
                                    new Point(spsc[0].cp3x+30+j*60, spsc[0].cp3y+20+k*40)};
                                    g.FillPolygon(blackBrush, compPointArrayShip);
                                    g.DrawString(spsc[id1].hp.ToString(), new Font("Arial", 8.0F), Brushes.Red, new PointF(40 + j * 60, 30 + k * 40));
                                }
                            }
                            break;
                    }
                    id++;
                }
            }
            combatImage.Refresh();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            cl = 0;
            Draw();
        }

        private void combatImage_Click(object sender, EventArgs e)
        {

        }
    }
}
