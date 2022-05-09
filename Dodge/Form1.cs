using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dodge
//Maddox Ollivier, 2022-05-09, This Dodge game is to be reviewed for feedback
{
    public partial class Form1 : Form
    {
        //Size of hero
        Rectangle hero = new Rectangle(5, 170, 10, 30);
        //Obstacles lists
        List<Rectangle> leftRec = new List<Rectangle>();
        List<Rectangle> rightRec = new List<Rectangle>();
        List<Rectangle> middleRec = new List<Rectangle>();
        List<int> recSpeed = new List<int>();
        List<string> recColour = new List<string>();
        //Speeds & when new obstacle is added
        int playerSpeed = 4;
        int counter = 0;
        //Bool variables
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;
        //Brushes
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        public Form1()
        {
            InitializeComponent();

            leftRec.Add(new Rectangle(100, 0, 10, 50));
            rightRec.Add(new Rectangle(400, 0, 10, 50));
            middleRec.Add(new Rectangle(200, 0, 20, 50));
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)//Keys used in game
            {
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode) //Keys used in game
            {
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(blueBrush, hero);

            for (int i = 0; i < leftRec.Count(); i++)
            {
                e.Graphics.FillRectangle(whiteBrush, leftRec[i]);
            }
            for (int i = 0; i < rightRec.Count(); i++)
            {
                e.Graphics.FillRectangle(whiteBrush, rightRec[i]);
            }
            for (int i = 0; i < middleRec.Count(); i++)
            {
                e.Graphics.FillRectangle(whiteBrush, middleRec[i]);
            }


        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (upArrowDown == true && hero.Y > 0)
            {
                hero.Y -= playerSpeed;
            }
            else if (downArrowDown == true && hero.Y < this.Height - hero.Height)
            {
                hero.Y += playerSpeed;
            }
            else if (leftArrowDown == true)
            {
                hero.X -= playerSpeed;
            }
            else if (rightArrowDown == true)
            {
                hero.X += playerSpeed;
            }

            for (int i = 0; i < leftRec.Count(); i++)
            {
                //find the new postion of y based on speed 
                int y = leftRec[i].Y + 8;

                //replace the rectangle in the list with updated one using new y 
                leftRec[i] = new Rectangle(leftRec[i].X, y, leftRec[i].Width, leftRec[i].Height);
            }
            for (int i = 0; i < rightRec.Count(); i++)
            {
                //find the new postion of y based on speed 
                int y = rightRec[i].Y + 10;

                //replace the rectangle in the list with updated one using new y 
                rightRec[i] = new Rectangle(rightRec[i].X, y, rightRec[i].Width, rightRec[i].Height);
            }
            for (int i = 0; i < middleRec.Count(); i++)
            {
                //find the new postion of y based on speed 
                int y = middleRec[i].Y + 17;

                //replace the rectangle in the list with updated one using new y 
                middleRec[i] = new Rectangle(middleRec[i].X, y, middleRec[i].Width, middleRec[i].Height);
            }
                counter++;

            if (counter == 16)
            {
                leftRec.Add(new Rectangle(100, 0, 10, 50));
                rightRec.Add(new Rectangle(400, 0, 10, 50));
                middleRec.Add(new Rectangle(200, 0, 20, 50));
                counter = 0;
            }
          
            for (int i = 0; i < leftRec.Count(); i++)
            {
                if (hero.IntersectsWith(leftRec[i]))
                {
                    Close();
                }
            }
             for (int j = 0; j < rightRec.Count(); j++)
                {
                    if (hero.IntersectsWith(rightRec[j]))
                    {
                        Close();
                    }
                }
             for (int k = 0; k < middleRec.Count(); k++)
            {
                if (hero.IntersectsWith(middleRec[k]))
                {
                    Close();
                }
            }



                Refresh();


            }
        }
    }
    
    
    



