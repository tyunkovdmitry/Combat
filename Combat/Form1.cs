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
        List<Spaceship> sps = new List<Spaceship>();

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
                    if (i == 19) { box.block = 2; }
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

            for (int i = 0; i < 50; i++)
            {

                id = r.Next(50, 800);
                if (boxs[id].block == 0)
                {
                    boxs[id].block = 1;
                }
            }

            for (int i = 0; i < 10; i++)
            {

                id = r.Next(50, 800);
                if (boxs[id].block == 0)
                {
                    boxs[id].block = 2;
                }
            }
            for (int id = 0; id < sps.Count; id++)
            {
                //id = 0;
                if (sps[id].own == 1)
                {
                    int i = r.Next(1, 38);
                    if (boxs[i].block == 0)
                    {
                        boxs[i].block = 3;
                    }
                    else
                    {
                        id--;
                    }
                    //id++;
                }
                // id = 0;
                if (sps[id].own == 0)
                {
                    int i = r.Next(839, 877);
                    if (boxs[i].block == 0)
                    {
                        boxs[i].block = 4;
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
                sps.Add(sp);
            }
            for (int i = 0; i < 10; i++)
            {
                Spaceship sp = new Spaceship(0, 0);
                sp.own = 0;
                sps.Add(sp);
            }
        }

        public void Step()
        {
            boxs[select].block = 0;
            boxs[select2].block = 3;
            Draw();
        }

        public void Draw()
        {
            
            combatBitmap = new Bitmap(combatImage.Width, combatImage.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(combatBitmap);
            g.FillRectangle(Brushes.Blue, 0, 0, combatBitmap.Width, combatBitmap.Height);

            Pen redPen = new Pen(Color.Red, 1);
            //Pen myPenbl = new Pen(Color.Black, 1);
            SolidBrush redBrush = new SolidBrush(Color.Red);
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            int nom = 0;
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
                        case 0:
                            g.DrawString(boxs[id].id.ToString(), new Font("Arial", 8.0F), Brushes.White, new PointF(10 + j * 60, 10 + i * 40));
                            break;
                        case 1:
                            g.DrawString(boxs[id].id.ToString(), new Font("Arial", 8.0F), Brushes.Red, new PointF(10 + j * 60, 10 + i * 40));
                            break;
                        case 2:
                            g.DrawString(boxs[id].id.ToString(), new Font("Arial", 8.0F), Brushes.Black, new PointF(10 + j * 60, 10 + i * 40));
                            break;
                        case 3:
                            Point[] myPointArrayShip = {  
                            new Point(sps[0].mp1x+j*60, sps[0].mp1y+i*40),
                            new Point(sps[0].mp2x+j*60, sps[0].mp2y+i*40),
                            new Point(sps[0].mp3x+j*60, sps[0].mp3y+i*40)};
                            g.FillPolygon(redBrush, myPointArrayShip);
                            break;
                        case 4:
                            Point[] compPointArrayShip = {  
                            new Point(sps[0].cp1x+j*60, sps[0].cp1y+i*40),
                            new Point(sps[0].cp2x+j*60, sps[0].cp2y+i*40),
                            new Point(sps[0].cp3x+j*60, sps[0].cp3y+i*40)};
                            g.FillPolygon(blackBrush, compPointArrayShip);
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
                            g.DrawString(boxs[id].id.ToString(), new Font("Arial", 8.0F), Brushes.White, new PointF(40 + j * 60, 30 + k * 40));
                            break;
                        case 1:
                            g.DrawString(boxs[id].id.ToString(), new Font("Arial", 8.0F), Brushes.Red, new PointF(40 + j * 60, 30 + k * 40));
                            break;
                        case 2:
                            g.DrawString(boxs[id].id.ToString(), new Font("Arial", 8.0F), Brushes.Black, new PointF(40 + j * 60, 30 + k * 40));
                            break;
                        case 3:
                            Point[] myPointArrayShip = { 
                            new Point(sps[0].mp1x+30+j*60, sps[0].mp1y+20+k*40),
                            new Point(sps[0].mp2x+30+j*60, sps[0].mp2y+20+k*40),
                            new Point(sps[0].mp3x+30+j*60, sps[0].mp3y+20+k*40)};
                            g.FillPolygon(redBrush, myPointArrayShip);
                            break;
                        case 4:
                            Point[] compPointArrayShip = {  
                            new Point(sps[0].cp1x+30+j*60, sps[0].cp1y+20+k*40),
                            new Point(sps[0].cp2x+30+j*60, sps[0].cp2y+20+k*40),
                            new Point(sps[0].cp3x+30+j*60, sps[0].cp3y+20+k*40)};
                            g.FillPolygon(blackBrush, compPointArrayShip);
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
            }
        }

        public void Redraw()
        {
            combatBitmap = new Bitmap(combatImage.Width, combatImage.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(combatBitmap);
            g.FillRectangle(Brushes.Blue, 0, 0, combatBitmap.Width, combatBitmap.Height);
            combatImage.Image = combatBitmap;
            Pen redPen = new Pen(Color.Red, 1);
            //Pen myPenbl = new Pen(Color.Black, 1);

            SolidBrush greenBrush = new SolidBrush(Color.Green);
            SolidBrush redBrush = new SolidBrush(Color.Red);
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            int nom = 0;
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
                    }
                    else
                    {
                        boxs[id].forstep = 0;
                        g.DrawPolygon(redPen, myPointArrayHex);
                    }
                    switch (boxs[id].block)
                    {
                        case 0:
                            g.DrawString(boxs[id].id.ToString(), new Font("Arial", 8.0F), Brushes.White, new PointF(10 + j * 60, 10 + i * 40));
                            break;
                        case 1:
                            g.DrawString(boxs[id].id.ToString(), new Font("Arial", 8.0F), Brushes.Red, new PointF(10 + j * 60, 10 + i * 40));
                            break;
                        case 2:
                            g.DrawString(boxs[id].id.ToString(), new Font("Arial", 8.0F), Brushes.Black, new PointF(10 + j * 60, 10 + i * 40));
                            break;
                        case 3:
                            Point[] myPointArrayShip = {  
                            new Point(sps[0].mp1x+j*60, sps[0].mp1y+i*40),
                            new Point(sps[0].mp2x+j*60, sps[0].mp2y+i*40),
                            new Point(sps[0].mp3x+j*60, sps[0].mp3y+i*40)};
                            g.FillPolygon(redBrush, myPointArrayShip);
                            break;
                        case 4:
                            Point[] compPointArrayShip = {  
                            new Point(sps[0].cp1x+j*60, sps[0].cp1y+i*40),
                            new Point(sps[0].cp2x+j*60, sps[0].cp2y+i*40),
                            new Point(sps[0].cp3x+j*60, sps[0].cp3y+i*40)};
                            g.FillPolygon(blackBrush, compPointArrayShip);
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
                    }
                    else
                    {
                        boxs[id].forstep = 0;
                        g.DrawPolygon(redPen, myPointArrayHex);
                    }
                    switch (boxs[id].block)
                    {
                        case 0:
                            g.DrawString(boxs[id].id.ToString(), new Font("Arial", 8.0F), Brushes.White, new PointF(40 + j * 60, 30 + k * 40));
                            break;
                        case 1:
                            g.DrawString(boxs[id].id.ToString(), new Font("Arial", 8.0F), Brushes.Red, new PointF(40 + j * 60, 30 + k * 40));
                            break;
                        case 2:
                            g.DrawString(boxs[id].id.ToString(), new Font("Arial", 8.0F), Brushes.Black, new PointF(40 + j * 60, 30 + k * 40));
                            break;
                        case 3:
                            Point[] myPointArrayShip = { 
                            new Point(sps[0].mp1x+30+j*60, sps[0].mp1y+20+k*40),
                            new Point(sps[0].mp2x+30+j*60, sps[0].mp2y+20+k*40),
                            new Point(sps[0].mp3x+30+j*60, sps[0].mp3y+20+k*40)};
                            g.FillPolygon(redBrush, myPointArrayShip);
                            break;
                        case 4:
                            Point[] compPointArrayShip = {  
                            new Point(sps[0].cp1x+30+j*60, sps[0].cp1y+20+k*40),
                            new Point(sps[0].cp2x+30+j*60, sps[0].cp2y+20+k*40),
                            new Point(sps[0].cp3x+30+j*60, sps[0].cp3y+20+k*40)};
                            g.FillPolygon(blackBrush, compPointArrayShip);
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
