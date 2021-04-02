﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace _8_Puzzle
{
    class UserMoveBtn
    {
        static public void MoveBTN(Button btn1, Button btn2,Button btn3,Color clr)
        {
            if (btn2.Text == "")
            {
                btn2.Text = btn1.Text;
                btn2.BackColor = btn1.BackColor;
                btn2.ForeColor = btn1.ForeColor;
                btn2.BackgroundImage = Bitmap.FromFile(@"E:\taive\8-Puzzle\8-Puzzle\Resources\" + btn1.Text.ToString() + ".JPG");
                btn2.FlatAppearance.BorderSize = 3;
                btn1.Text = "";
                btn1.BackColor = clr;
                btn1.ForeColor = clr;
                btn1.BackgroundImage = Bitmap.FromFile(@"E:\taive\8-Puzzle\8-Puzzle\Resources\" + btn2.Text.ToString() + ".JPG");
                btn1.FlatAppearance.BorderSize = 0;
                btn1.FlatAppearance.MouseDownBackColor = clr;
                btn1.FlatAppearance.MouseOverBackColor = clr;
            }
            else if (btn3.Text == "")
            {
                btn3.Text = btn1.Text;
                btn3.BackColor = btn1.BackColor;
                btn3.ForeColor = btn1.ForeColor;
                btn3.BackgroundImage = Bitmap.FromFile(@"E:\taive\8-Puzzle\8-Puzzle\Resources\" + btn1.Text.ToString() + ".JPG");
                btn3.FlatAppearance.BorderSize = 3;
                
                btn1.Text = "";
                btn1.BackColor = clr;
                btn1.ForeColor = clr;
                btn1.BackgroundImage = Bitmap.FromFile(@"E:\taive\8-Puzzle\8-Puzzle\Resources\" + btn3.Text.ToString() + ".JPG");
                btn1.FlatAppearance.BorderSize = 0;
                btn1.FlatAppearance.MouseDownBackColor = clr;
                btn1.FlatAppearance.MouseOverBackColor = clr;
            }

        }
        static public void MoveBTN(Button btn1, Button btn2, Button btn3,Button btn4, Color clr)
        {
            if (btn2.Text == "")
            {
                
                btn2.Text = btn1.Text;
                btn2.BackColor = btn1.BackColor;
                btn2.ForeColor = btn1.ForeColor;
               
                btn2.BackgroundImage = Bitmap.FromFile(@"E:\taive\8-Puzzle\8-Puzzle\Resources\" + btn1.Text.ToString() + ".JPG");
                btn2.FlatAppearance.BorderSize = 3;

                btn1.Text = "";
                btn1.BackColor = clr;
                btn1.ForeColor = clr;
                btn1.FlatAppearance.BorderSize = 0;
                btn1.BackgroundImage = Bitmap.FromFile(@"E:\taive\8-Puzzle\8-Puzzle\Resources\" + btn2.Text.ToString() + ".JPG");
                btn1.FlatAppearance.MouseDownBackColor = clr;
                btn1.FlatAppearance.MouseOverBackColor = clr;
            }
            else if (btn3.Text == "")
            {
                
                btn3.Text = btn1.Text;
                btn3.BackColor = btn1.BackColor;
                btn3.ForeColor = btn1.ForeColor;
                btn3.BackgroundImage = Bitmap.FromFile(@"E:\taive\8-Puzzle\8-Puzzle\Resources\" + btn1.Text.ToString() + ".JPG");
                btn3.FlatAppearance.BorderSize = 3;

                btn1.Text = "";
                btn1.BackColor = clr;
                btn1.ForeColor = clr;
                btn1.FlatAppearance.BorderSize = 0;
                btn1.BackgroundImage = Bitmap.FromFile(@"E:\taive\8-Puzzle\8-Puzzle\Resources\" + btn3.Text.ToString() + ".JPG");
                btn1.FlatAppearance.MouseDownBackColor = clr;
                btn1.FlatAppearance.MouseOverBackColor = clr;
            }
            else if (btn4.Text == "")
            {
                
                btn4.Text = btn1.Text;
                btn4.BackColor = btn1.BackColor;
                btn4.ForeColor = btn1.ForeColor;
                btn4.BackgroundImage = Bitmap.FromFile(@"E:\taive\8-Puzzle\8-Puzzle\Resources\" + btn1.Text.ToString() + ".JPG");
                btn4.FlatAppearance.BorderSize = 3;

                btn1.Text = "";
                btn1.BackColor = clr;
                btn1.ForeColor = clr;
                btn1.FlatAppearance.BorderSize = 0;
                btn1.BackgroundImage = Bitmap.FromFile(@"E:\taive\8-Puzzle\8-Puzzle\Resources\" + btn4.Text.ToString() + ".JPG");
                btn1.FlatAppearance.MouseDownBackColor = clr;
                btn1.FlatAppearance.MouseOverBackColor = clr;
            }
            
        }
        static public void MoveBTN(Button btn1, Button btn2, Button btn3, Button btn4,Button btn5, Color clr)
        {
            if (btn2.Text == "")
            {
                
                btn2.Text = btn1.Text;
                btn2.BackColor = btn1.BackColor;
                btn2.ForeColor = btn1.ForeColor;
                btn2.BackgroundImage = Bitmap.FromFile(@"E:\taive\8-Puzzle\8-Puzzle\Resources\" + btn1.Text.ToString() + ".JPG");
                btn2.BackgroundImageLayout = ImageLayout.Stretch;
                btn2.FlatAppearance.BorderSize = 3;

                btn1.Text = "";
                btn1.BackColor = clr;
                btn1.ForeColor = clr;
                btn1.FlatAppearance.BorderSize = 0;
                btn1.BackgroundImage = Bitmap.FromFile(@"E:\taive\8-Puzzle\8-Puzzle\Resources\kk.JPG");// + btn2.Text.ToString() + ".JPG");
                btn1.BackgroundImageLayout = ImageLayout.Stretch;
                btn1.FlatAppearance.MouseDownBackColor = clr;
                btn1.FlatAppearance.MouseOverBackColor = clr;
            }
            else if (btn3.Text == "")
            {
                
                btn3.Text = btn1.Text;
                btn3.BackColor = btn1.BackColor;
                btn3.ForeColor = btn1.ForeColor;
                btn3.BackgroundImage = Bitmap.FromFile(@"E:\taive\8-Puzzle\8-Puzzle\Resources\" + btn1.Text.ToString() + ".JPG");
                btn3.BackgroundImageLayout = ImageLayout.Stretch;
                btn3.FlatAppearance.BorderSize = 3;

                btn1.Text = "";
                btn1.BackColor = clr;
                btn1.ForeColor = clr;
                btn1.FlatAppearance.BorderSize = 0;
                btn1.BackgroundImage = Bitmap.FromFile(@"E:\taive\8-Puzzle\8-Puzzle\Resources\" + btn3.Text.ToString() + ".JPG");
                btn1.BackgroundImageLayout = ImageLayout.Stretch;
                btn1.FlatAppearance.MouseDownBackColor = clr;
                btn1.FlatAppearance.MouseOverBackColor = clr;
            }
            else if (btn4.Text == "")
            {
                
                btn4.Text = btn1.Text;
                btn4.BackColor = btn1.BackColor;
                btn4.ForeColor = btn1.ForeColor;
                btn4.BackgroundImage = Bitmap.FromFile(@"E:\taive\8-Puzzle\8-Puzzle\Resources\" + btn1.Text.ToString() + ".JPG");
                btn4.BackgroundImageLayout = ImageLayout.Stretch;
                btn4.FlatAppearance.BorderSize = 3;

                btn1.Text = "";
                btn1.BackColor = clr;
                btn1.ForeColor = clr;
                btn1.FlatAppearance.BorderSize = 0;
                btn1.BackgroundImage = Bitmap.FromFile(@"E:\taive\8-Puzzle\8-Puzzle\Resources\" + btn4.Text.ToString() + ".JPG");
                btn1.BackgroundImageLayout = ImageLayout.Stretch;
                btn1.FlatAppearance.MouseDownBackColor = clr;
                btn1.FlatAppearance.MouseOverBackColor = clr;
            }
            else if (btn5.Text == "")
            {
                
                btn5.Text = btn1.Text;
                btn5.BackColor = btn1.BackColor;
                btn5.ForeColor = btn1.ForeColor;
                btn5.BackgroundImage = Bitmap.FromFile(@"E:\taive\8-Puzzle\8-Puzzle\Resources\" + btn1.Text.ToString() + ".JPG");
                btn5.BackgroundImageLayout = ImageLayout.Stretch;
                btn5.FlatAppearance.BorderSize = 3;

                btn1.Text = "";
                btn1.BackColor = clr;
                btn1.ForeColor = clr;
                btn1.FlatAppearance.BorderSize = 0;
                btn1.BackgroundImage = Bitmap.FromFile(@"E:\taive\8-Puzzle\8-Puzzle\Resources\" + btn5.Text.ToString() + ".JPG");
                btn1.BackgroundImageLayout = ImageLayout.Stretch;
                btn1.FlatAppearance.MouseDownBackColor = clr;
                btn1.FlatAppearance.MouseOverBackColor = clr;
            }

        }

    }
}
