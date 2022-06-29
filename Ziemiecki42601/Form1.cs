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

namespace Ziemiecki42601
{

    public partial class Ziemiecki42601 : Form
    {
        static Ziemiecki42601 iz_Form;
        static Graphics iz_Graphics;
        List<iz_Point> iz_PointList = new List<iz_Point>();
        static int iz_RandomDistracter;   // taka magia do unikania uzyskiwania identycznej wartosci, jesli komputer za szybko oblicza ;)

        const int iz_margin = 10;
        int iz_FigureNumber = 13;

        /*
         _________________________________________________________________________________________________________________
         Słowem wstępu:
         Wiem, że jest tu bardzo dużo do poprawy. Podczas pisania kodu na etapie kółek i elips olśniło mnie w dużym stopniu.
         Można by oczywiście:
         - wyrzucić niepotrzebne dane z punktu (brushe, grubość)
         - utworzyć podklasy w formie punkt ->elipsa[..] -> koło -> koło wypełnione, koło ze wzorem
 
         - uporządkować niepotrzebne konstruktory
         
         Jednakże wóczas z 12 klas zrobiło by się 32, a jest godzina 04:57 i jakbym zaczął to robić, to bym się nie wyrobił z dostarczeniem programu na czas.
         musi zostać w formie punkt->elipsa->okrąg
                                   ->prostokąt->kwadrat
         Proszę pokornie o wybaczenie. :P         
         
         */


        public Ziemiecki42601()
        {
            InitializeComponent();

            // nie ma skalowania, ponieważ uważam, że skalowanie i rozmieszczanie o ile ma sens w jedną stronę (powiększanie),
            // to w drugą stronę (pomniejszanie) może powodować problemy z niewidocznością elementów (implementacja stałego
            // marginesu) (ten problem wystąpił na wykładach, gdyż projektor wymusza niższą rozdzielczość i część
            // elementów była niewidoczna), lub z nakładaniem się elementów (brak marginesu)
            // jeżeli już implementować skalowanie, to na zasadzie procentowego pomniejszania całego okna,
            // czyli tak jakbyśmy pomniejszali obrazek wklejony do painta
            iz_dType.SelectedIndex = 0; // początkowa wartość dla stylu, aby uniknąć null index call
            iz_Form = this;
            iz_Graphics = iz_pbBoard.CreateGraphics();
            iz_Graphics.SmoothingMode = SmoothingMode.AntiAlias; // znalezione w internetach, zapewnia antialiasing
            iz_chList.SetItemChecked(0, true); // punkt domyślnie zaznaczony
            iz_RandomDistracter = (new Random()).Next();
        }

        public class iz_Point
        {
            public int iz_Type;
            public int iz_X, iz_Y, iz_Thickness;
            public Color iz_Color;
            public DashStyle iz_DashStyle;
            public HatchBrush iz_HatchBrush;
            public SolidBrush iz_sBrush;
            public bool iz_Visible;
            const int iz_PointSize = 10;

            public iz_Point()
            {
                iz_Type = 0;
                iz_X = 0;
                iz_Y = 0;
                iz_Thickness = 1;
                iz_Color = Color.Black;
                iz_Visible = false;
            }
            public iz_Point(int iz_x, int iz_y)
            {
                iz_Type = 0;
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_Thickness = 1;
                iz_Color = Color.Black;
                iz_Visible = false;
            }
            public iz_Point(int iz_x, int iz_y, Color iz_LineColor)
            {
                iz_Type = 0;
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_Thickness = 1;
                iz_Color = iz_LineColor;
                iz_Visible = false;
            }

            public void iz_SetPosition(int iz_x, int iz_y)
            {
                iz_X = iz_x;
                iz_Y = iz_y;
            }
            public virtual void iz_Move(int iz_x, int iz_y)
            {
                //    iz_Remove();
                iz_SetPosition(iz_x, iz_y);
                iz_Draw();
            }
            public virtual void iz_MoveFilled(int iz_x, int iz_y) { }
            public virtual void iz_MoveHatched(int iz_x, int iz_y) { }
            public void iz_EditVisuals()
            {
                Random iz_Random = new Random((int)DateTime.Now.Ticks * iz_RandomDistracter);
                iz_RandomDistracter = iz_Random.Next();
                iz_Color = Color.FromArgb(iz_Random.Next(255), iz_Random.Next(255), iz_Random.Next(255));
                iz_sBrush = new SolidBrush(iz_Color);
                HatchStyle iz_hStyle = (HatchStyle)iz_Random.Next(0, 52);    // HatchStyle to eNum o przedziale 0-52, tak więc skróciłem sobie męki pisania randomowego wyboru do tego prostego przypisania random liczby.


                iz_HatchBrush = new HatchBrush(iz_hStyle, Color.FromArgb(iz_Random.Next(255),
                                           iz_Random.Next(255), iz_Random.Next(255)), Color.FromArgb(iz_Random.Next(255), iz_Random.Next(255), iz_Random.Next(255)));

                switch (iz_Random.Next(5))
                {
                    case 0:
                        iz_DashStyle = DashStyle.Solid; break;
                    case 1:
                        iz_DashStyle = DashStyle.Dash; break;
                    case 2:
                        iz_DashStyle = DashStyle.DashDot; break;
                    case 3:
                        iz_DashStyle = DashStyle.DashDotDot; break;
                    case 4:
                        iz_DashStyle = DashStyle.Dot; break;
                    default: iz_DashStyle = DashStyle.Solid; break;
                }
                iz_Thickness = iz_Random.Next(1, 20);

            }
            public void iz_Draw()
            {
                SolidBrush iz_Brush = new SolidBrush(iz_Color);
                iz_Graphics.FillEllipse(iz_Brush, iz_X, iz_Y, iz_PointSize / 2, iz_PointSize / 2);
                iz_Visible = true;
            }
            public void iz_Remove()
            {
                if (iz_Visible)
                {
                    SolidBrush iz_Brush = new SolidBrush(iz_Form.iz_pbBoard.BackColor);
                    iz_Graphics.FillEllipse(iz_Brush, iz_X, iz_Y, iz_PointSize / 2, iz_PointSize / 2);
                    iz_Visible = false;
                }
            }

        }

        public class iz_Ellipse : iz_Point
        {
            private int iz_Width, iz_Heigth;
            public iz_Ellipse()
            {
                iz_Type = 4;
                iz_X = iz_Y = 0;
                iz_Thickness = 1;
                iz_Width = 6;
                iz_Heigth = 5;
            }
            public iz_Ellipse(int iz_x, int iz_y)
            {
                iz_Type = 4;
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_Thickness = 1;
                iz_Width = iz_Heigth = 5;
            }

            public iz_Ellipse(int iz_x, int iz_y, int iz_heigth, int iz_width)
            {
                iz_Type = 4;
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_Thickness = 1;
                iz_Width = iz_width;
                iz_Heigth = iz_heigth;
            }
            public iz_Ellipse(int iz_x, int iz_y, int iz_heigth, int iz_width, Color iz_LineColor, int iz_thickness, DashStyle iz_dashStyle)
            {
                iz_Type = 4;
                iz_Color = iz_LineColor;
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_Thickness = iz_thickness;
                iz_DashStyle = iz_dashStyle;
                iz_Width = iz_width;
                iz_Heigth = iz_heigth;
            }
            public iz_Ellipse(int iz_x, int iz_y, int iz_heigth, int iz_width, SolidBrush iz_solidBrush)
            {
                iz_Type = 5;
                iz_sBrush = iz_solidBrush;
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_Thickness = 1;
                iz_Width = iz_width;
                iz_Heigth = iz_heigth;
            }
            public iz_Ellipse(int iz_x, int iz_y, int iz_heigth, int iz_width, HatchBrush iz_hBrush)
            {
                iz_Type = 6;
                iz_HatchBrush = iz_hBrush;
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_Thickness = 1;
                iz_Width = iz_width;
                iz_Heigth = iz_heigth;
            }

            public void iz_Move(int iz_x, int iz_y)
            {
                //      iz_Remove();
                iz_SetPosition(iz_x, iz_y);
                iz_Draw();
            }
            public void iz_MoveFilled(int iz_x, int iz_y)
            {
                //      iz_RemoveFilled();
                iz_SetPosition(iz_x, iz_y);
                iz_DrawFilled();
            }
            public void iz_MoveHatched(int iz_x, int iz_y)
            {
                //       iz_RemoveFilled();
                iz_SetPosition(iz_x, iz_y);
                iz_DrawHatched();
            }

            public void iz_Draw()
            {
                Pen iz_Pen = new Pen(iz_Color, iz_Thickness);
                iz_Pen.DashStyle = iz_DashStyle;
                iz_Graphics.DrawEllipse(iz_Pen, iz_X, iz_Y, iz_Width, iz_Heigth);
            }
            public void iz_DrawFilled()
            {
                iz_Graphics.FillEllipse(iz_sBrush, iz_X, iz_Y, iz_Width, iz_Heigth);
            }
            public void iz_DrawHatched()
            {
                iz_Graphics.FillEllipse(iz_HatchBrush, iz_X, iz_Y, iz_Width, iz_Heigth);
            }
            public void iz_Remove()
            {
                Pen iz_Pen = new Pen(iz_Form.iz_pbBoard.BackColor);
                iz_Pen.DashStyle = iz_DashStyle;
                iz_Graphics.DrawEllipse(iz_Pen, iz_X, iz_Y, iz_Width, iz_Width);
            }
            public void iz_RemoveFilled() // stosowane również dla Hatched, ponieważ w efekcie usuwamy wypełnione koło
            {
                SolidBrush iz_sBrush = new SolidBrush(iz_Form.iz_pbBoard.BackColor);
                iz_Graphics.FillEllipse(iz_sBrush, iz_X, iz_Y, iz_Width, iz_Heigth);
            }

        }

        public class iz_Circle : iz_Ellipse
        {
            int iz_Radius;

            public iz_Circle(int iz_x, int iz_y, int iz_radius)
            {
                iz_Type = 1;
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_Thickness = 1;
                iz_Radius = iz_radius;
            }
            public iz_Circle(int iz_x, int iz_y, int iz_radius, Color iz_LineColor)
            {
                iz_Type = 1;
                iz_Color = iz_LineColor;
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_Thickness = 1;
                iz_Radius = iz_radius;
            }
            public iz_Circle(int iz_x, int iz_y, int iz_radius, SolidBrush iz_solidBrush)
            {
                iz_Type = 2;
                iz_sBrush = iz_solidBrush;
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_Thickness = 1;
                iz_Radius = iz_radius;
            }
            public iz_Circle(int iz_x, int iz_y, int iz_radius, HatchBrush iz_hBrush)
            {
                iz_Type = 3;
                iz_HatchBrush = iz_hBrush;
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_Thickness = 1;
                iz_Radius = iz_radius;
            }
            public iz_Circle(int iz_x, int iz_y, int iz_radius, SolidBrush iz_solidBrush, Color iz_LineColor, DashStyle iz_dashStyle, int iz_thickness)
            {
                iz_Thickness = iz_thickness;
                iz_DashStyle = iz_dashStyle;
                iz_Color = iz_LineColor;
                iz_sBrush = iz_solidBrush;
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_Radius = iz_radius;
            }
            public void iz_Move(int iz_x, int iz_y)
            {
                //     iz_Remove();
                iz_SetPosition(iz_x, iz_y);
                iz_Draw();
            }
            public void iz_MoveFilled(int iz_x, int iz_y)
            {
                //     iz_RemoveFilled();
                iz_SetPosition(iz_x, iz_y);
                iz_DrawFilled();
            }
            public void iz_MoveHatched(int iz_x, int iz_y)
            {
                //      iz_RemoveFilled();
                iz_SetPosition(iz_x, iz_y);
                iz_DrawHatched();
            }
            public void iz_Draw()
            {
                Pen iz_Pen = new Pen(iz_Color, iz_Thickness);
                iz_Pen.DashStyle = iz_DashStyle;
                iz_Graphics.DrawEllipse(iz_Pen, iz_X, iz_Y, iz_Radius, iz_Radius);
            }
            public void iz_DrawFilled()
            {
                iz_Graphics.FillEllipse(iz_sBrush, iz_X, iz_Y, iz_Radius, iz_Radius);
            }
            public void iz_DrawHatched()
            {
                iz_Graphics.FillEllipse(iz_HatchBrush, iz_X, iz_Y, iz_Radius, iz_Radius);
            }
            public void iz_Remove()
            {
                Pen iz_Pen = new Pen(iz_Form.iz_pbBoard.BackColor);
                iz_Pen.DashStyle = iz_DashStyle;
                iz_Graphics.DrawEllipse(iz_Pen, iz_X, iz_Y, iz_Radius, iz_Radius);
            }
            public void iz_RemoveFilled()  // używane również dla hatchbrush
            {
                SolidBrush iz_sBrush = new SolidBrush(iz_Form.iz_pbBoard.BackColor);
                iz_Graphics.FillEllipse(iz_sBrush, iz_X, iz_Y, iz_Radius, iz_Radius);
            }

        }
        public class iz_Rectangle : iz_Point
        {
            private int iz_Height, iz_Width;

            public iz_Rectangle()
            {
                iz_Type = 10;
                iz_Height = 5;
                iz_Width = 3;
                iz_Thickness = 1;
                iz_Color = Color.Black;
                iz_X = iz_Y = 0;
            }
            public iz_Rectangle(int iz_x, int iz_y)
            {
                iz_Type = 10;
                iz_Height = 5;
                iz_Width = 3;
                iz_Thickness = 1;
                iz_Color = Color.Black;
                iz_X = iz_x;
                iz_Y = iz_y;
            }
            public iz_Rectangle(int iz_x, int iz_y, int iz_height, int iz_width)
            {
                iz_Type = 10;
                iz_Height = iz_height;
                iz_Width = iz_width;
                iz_Thickness = 1;
                iz_Color = Color.Black;
                iz_X = iz_x;
                iz_Y = iz_y;
            }
            public iz_Rectangle(int iz_x, int iz_y, int iz_height, int iz_width, int iz_thickness, Color iz_color, DashStyle iz_dashStyle)
            {
                iz_Type = 10;
                iz_Height = iz_height;
                iz_Width = iz_width;
                iz_Thickness = iz_thickness;
                iz_Color = iz_color;
                iz_DashStyle = iz_dashStyle;
                iz_X = iz_x;
                iz_Y = iz_y;
            }
            public iz_Rectangle(int iz_x, int iz_y, int iz_height, int iz_width, SolidBrush iz_solidBrush)
            {
                iz_Type = 11;
                iz_Height = iz_height;
                iz_Width = iz_width;
                iz_sBrush = iz_solidBrush;
                iz_X = iz_x;
                iz_Y = iz_y;
            }
            public iz_Rectangle(int iz_x, int iz_y, int iz_height, int iz_width, HatchBrush iz_hBrush)
            {
                iz_Type = 12;
                iz_Height = iz_height;
                iz_Width = iz_width;
                iz_HatchBrush = iz_hBrush;
                iz_X = iz_x;
                iz_Y = iz_y;
            }
            public void iz_Move(int iz_x, int iz_y)
            {
                //      iz_Remove();
                iz_SetPosition(iz_x, iz_y);
                iz_Draw();
            }
            public void iz_MoveFilled(int iz_x, int iz_y)
            {
                //     iz_RemoveFilled();
                iz_SetPosition(iz_x, iz_y);
                iz_DrawFilled();
            }
            public void iz_MoveHatched(int iz_x, int iz_y)
            {
                //     iz_RemoveFilled();
                iz_SetPosition(iz_x, iz_y);
                iz_DrawHatched();
            }
            public void iz_Draw()
            {
                Pen iz_Pen = new Pen(iz_Color, iz_Thickness);
                iz_Pen.DashStyle = iz_DashStyle;
                iz_Graphics.DrawRectangle(iz_Pen, iz_X, iz_Y, iz_Width, iz_Height);
            }
            public void iz_DrawFilled()
            {
                iz_Graphics.FillRectangle(iz_sBrush, iz_X, iz_Y, iz_Width, iz_Height);
            }
            public void iz_DrawHatched()
            {
                iz_Graphics.FillRectangle(iz_HatchBrush, iz_X, iz_Y, iz_Width, iz_Height);
            }

            public void iz_Remove()
            {
                Pen iz_Pen = new Pen(iz_Form.iz_pbBoard.BackColor, iz_Thickness);
                iz_Pen.DashStyle = iz_DashStyle;
                iz_Graphics.DrawRectangle(iz_Pen, iz_X, iz_Y, iz_Width, iz_Height);
            }
            public void iz_RemoveFilled()     //używane też do wymazywania hatched
            {
                SolidBrush iz_sBrush = new SolidBrush(iz_Form.iz_pbBoard.BackColor);
                iz_Graphics.FillRectangle(iz_sBrush, iz_X, iz_Y, iz_Width, iz_Height);
            }
        }
        public class iz_Square : iz_Rectangle
        {
            private int iz_Size;
            public iz_Square()
            {
                iz_Type = 7;
                iz_Size = 5;
                iz_Thickness = 1;
                iz_Color = Color.Black;
                iz_X = iz_Y = 0;
            }
            public iz_Square(int iz_x, int iz_y)
            {
                iz_Type = 7;
                iz_Size = 5;
                iz_Thickness = 1;
                iz_Color = Color.Black;
                iz_X = iz_x;
                iz_Y = iz_y;
            }
            public iz_Square(int iz_x, int iz_y, int iz_size)
            {
                iz_Type = 7;
                iz_Size = iz_size;
                iz_Thickness = 1;
                iz_Color = Color.Black;
                iz_X = iz_x;
                iz_Y = iz_y;
            }
            public iz_Square(int iz_x, int iz_y, int iz_size, int iz_thickness, Color iz_color, DashStyle iz_dashStyle)
            {
                iz_Type = 7;
                iz_Size = iz_size;
                iz_Thickness = iz_thickness;
                iz_Color = iz_color;
                iz_DashStyle = iz_dashStyle;
                iz_X = iz_x;
                iz_Y = iz_y;
            }
            public iz_Square(int iz_x, int iz_y, int iz_size, SolidBrush iz_solidBrush)
            {
                iz_Type = 8;
                iz_Size = iz_size;
                iz_sBrush = iz_solidBrush;
                iz_X = iz_x;
                iz_Y = iz_y;
            }
            public iz_Square(int iz_x, int iz_y, int iz_size, HatchBrush iz_hBrush)
            {
                iz_Type = 9;
                iz_Size = iz_size;
                iz_HatchBrush = iz_hBrush;
                iz_X = iz_x;
                iz_Y = iz_y;
            }
            public void iz_Move(int iz_x, int iz_y)
            {
                //   iz_Remove();
                iz_SetPosition(iz_x, iz_y);
                iz_Draw();
            }
            public void iz_MoveFilled(int iz_x, int iz_y)
            {
                //  iz_RemoveFilled();
                iz_SetPosition(iz_x, iz_y);
                iz_DrawFilled();
            }
            public void iz_MoveHatched(int iz_x, int iz_y)
            {
                //  iz_RemoveFilled();
                iz_SetPosition(iz_x, iz_y);
                iz_DrawHatched();
            }
            public void iz_Draw()
            {
                Pen iz_Pen = new Pen(iz_Color, iz_Thickness);
                iz_Pen.DashStyle = iz_DashStyle;
                iz_Graphics.DrawRectangle(iz_Pen, iz_X, iz_Y, iz_Size, iz_Size);
            }
            public void iz_DrawFilled()
            {
                iz_Graphics.FillRectangle(iz_sBrush, iz_X, iz_Y, iz_Size, iz_Size);
            }
            public void iz_DrawHatched()
            {
                iz_Graphics.FillRectangle(iz_HatchBrush, iz_X, iz_Y, iz_Size, iz_Size);
            }

            public void iz_Remove()
            {
                Pen iz_Pen = new Pen(iz_Form.iz_pbBoard.BackColor, iz_Thickness);
                iz_Pen.DashStyle = iz_DashStyle;
                iz_Graphics.DrawRectangle(iz_Pen, iz_X, iz_Y, iz_Size, iz_Size);
            }
            public void iz_RemoveFilled()     //używane też do wymazywania hatched
            {
                SolidBrush iz_sBrush = new SolidBrush(iz_Form.iz_pbBoard.BackColor);
                iz_Graphics.FillRectangle(iz_sBrush, iz_X, iz_Y, iz_Size, iz_Size);
            }

        }

        private void iz_btnStart_Click(object sender, EventArgs e)
        {
            int iz_N = int.Parse(iz_nNumber.Value.ToString());     // używam numeric up down z readonly, mam pewność co do poprawności
            int iz_MaxX = iz_Form.iz_pbBoard.Width - iz_margin;
            int iz_MaxY = iz_Form.iz_pbBoard.Height - iz_margin;
            Random iz_Random = new Random((int)DateTime.Now.Ticks * iz_RandomDistracter);
            iz_RandomDistracter = iz_Random.Next();

            int iz_Xh, iz_Yh;
            Color iz_Color;
            SolidBrush iz_sBrush;
            HatchBrush iz_hBrush;
            int iz_Thickness;
            DashStyle iz_DashStyle;
            int iz_HowManySelected = iz_chList.CheckedItems.Count;

            int[] iz_RandomFigureSelector = new int[iz_HowManySelected];
            for (int i = 0, j = 0; i < 13; i++)
            {
                if (iz_chList.GetItemChecked(i))
                {
                    iz_RandomFigureSelector[j] = i;
                    j++;
                }
            }
            // przelatuje po calej liscie 'do zaznaczania' i jesli item jest zaznaczony - zapisuje jego index do tablicy
            // potem bedzie losowanie indexu z iz_RandomFigureSelector i na podstawie wartosci przypisanej do wartosci - rysowanie


            for (int i = 0; i < iz_N; i++)
            {
                iz_Xh = iz_Random.Next(iz_margin, iz_MaxX);
                iz_Yh = iz_Random.Next(iz_margin, iz_MaxY);
                iz_Color = Color.FromArgb(iz_Random.Next(255), iz_Random.Next(255), iz_Random.Next(255));
                iz_sBrush = new SolidBrush(iz_Color);
                HatchStyle iz_hStyle = (HatchStyle)iz_Random.Next(0, 52);    // HatchStyle to eNum o przedziale 0-52, tak więc skróciłem sobie męki pisania randomowego wyboru do tego prostego przypisania random liczby.


                iz_hBrush = new HatchBrush(iz_hStyle, Color.FromArgb(iz_Random.Next(255),
                                           iz_Random.Next(255), iz_Random.Next(255)), Color.FromArgb(iz_Random.Next(255), iz_Random.Next(255), iz_Random.Next(255)));

                switch (iz_Random.Next(5))
                {
                    case 0:
                        iz_DashStyle = DashStyle.Solid; break;
                    case 1:
                        iz_DashStyle = DashStyle.Dash; break;
                    case 2:
                        iz_DashStyle = DashStyle.DashDot; break;
                    case 3:
                        iz_DashStyle = DashStyle.DashDotDot; break;
                    case 4:
                        iz_DashStyle = DashStyle.Dot; break;
                    default: iz_DashStyle = DashStyle.Solid; break;
                }
                iz_Thickness = iz_Random.Next(1, 20);

                int iz_i = 0;
                if (iz_HowManySelected > 1)  // jeśli mamy 1 zaznaczoną figurę, to nie ma czego tu losować
                    iz_i = iz_Random.Next(iz_HowManySelected);

                switch (iz_RandomFigureSelector[iz_i])
                {
                    case 0:
                        iz_PointList.Add(new iz_Point(iz_Xh, iz_Yh, iz_Color));
                        iz_PointList[iz_PointList.Count - 1].iz_Draw();
                        break;
                    case 1:
                        iz_PointList.Add(new iz_Circle(iz_Xh, iz_Yh, iz_Random.Next(1, 500), iz_sBrush, iz_Color, iz_DashStyle, iz_Thickness));
                        ((iz_Circle)iz_PointList[iz_PointList.Count - 1]).iz_Draw();
                        break;
                    case 2:
                        iz_PointList.Add(new iz_Circle(iz_Xh, iz_Yh, iz_Random.Next(1, 500), iz_sBrush));
                        ((iz_Circle)iz_PointList[iz_PointList.Count - 1]).iz_DrawFilled();
                        break;
                    case 3:
                        iz_PointList.Add(new iz_Circle(iz_Xh, iz_Yh, iz_Random.Next(1, 500), iz_hBrush));
                        ((iz_Circle)iz_PointList[iz_PointList.Count - 1]).iz_DrawHatched();
                        break;
                    case 4:
                        iz_PointList.Add(new iz_Ellipse(iz_Xh, iz_Yh, iz_Random.Next(1, 500), iz_Random.Next(1, 500), iz_Color, iz_Thickness, iz_DashStyle));
                        ((iz_Ellipse)iz_PointList[iz_PointList.Count - 1]).iz_Draw();
                        break;
                    case 5:
                        iz_PointList.Add(new iz_Ellipse(iz_Xh, iz_Yh, iz_Random.Next(1, 500), iz_Random.Next(1, 500), iz_sBrush));
                        ((iz_Ellipse)iz_PointList[iz_PointList.Count - 1]).iz_DrawFilled();
                        break;
                    case 6:
                        iz_PointList.Add(new iz_Ellipse(iz_Xh, iz_Yh, iz_Random.Next(1, 500), iz_Random.Next(1, 500), iz_hBrush));
                        ((iz_Ellipse)iz_PointList[iz_PointList.Count - 1]).iz_DrawHatched();
                        break;
                    case 7:
                        iz_PointList.Add(new iz_Square(iz_Xh, iz_Yh, iz_Random.Next(1, 500), iz_Thickness, iz_Color, iz_DashStyle));
                        ((iz_Square)iz_PointList[iz_PointList.Count - 1]).iz_Draw();
                        break;
                    case 8:
                        iz_PointList.Add(new iz_Square(iz_Xh, iz_Yh, iz_Random.Next(1, 500), iz_sBrush));
                        ((iz_Square)iz_PointList[iz_PointList.Count - 1]).iz_DrawFilled();
                        break;
                    case 9:
                        iz_PointList.Add(new iz_Square(iz_Xh, iz_Yh, iz_Random.Next(1, 500), iz_hBrush));
                        ((iz_Square)iz_PointList[iz_PointList.Count - 1]).iz_DrawHatched();
                        break;
                    case 10:
                        iz_PointList.Add(new iz_Rectangle(iz_Xh, iz_Yh, iz_Random.Next(1, 500), iz_Random.Next(1, 500), iz_Thickness, iz_Color, iz_DashStyle));
                        ((iz_Rectangle)iz_PointList[iz_PointList.Count - 1]).iz_Draw();
                        break;
                    case 11:
                        iz_PointList.Add(new iz_Rectangle(iz_Xh, iz_Yh, iz_Random.Next(1, 500), iz_Random.Next(1, 500), iz_sBrush));
                        ((iz_Rectangle)iz_PointList[iz_PointList.Count - 1]).iz_DrawFilled();
                        break;
                    case 12:
                        iz_PointList.Add(new iz_Rectangle(iz_Xh, iz_Yh, iz_Random.Next(1, 500), iz_Random.Next(1, 500), iz_hBrush));
                        ((iz_Rectangle)iz_PointList[iz_PointList.Count - 1]).iz_DrawHatched();
                        break;
                }

            }


        }

        private void iz_btnAdd_Click(object sender, EventArgs e)
        {
            int iz_HowManySelected = iz_chList.CheckedItems.Count;
            int[] iz_RandomFigureSelector = new int[iz_HowManySelected];
            for (int i = 0, j = 0; i < 13; i++)
            {
                if (iz_chList.GetItemChecked(i))
                {
                    iz_RandomFigureSelector[j] = i;
                    j++;
                }

            }
            int iz_MaxX = iz_Form.iz_pbBoard.Width - iz_margin;
            int iz_MaxY = iz_Form.iz_pbBoard.Height - iz_margin;
            int iz_Xh;
            int iz_Yh;
            Random iz_Random = new Random((int)DateTime.Now.Ticks * iz_RandomDistracter);
            iz_RandomDistracter = iz_Random.Next();
            DashStyle iz_DashStyle;
            HatchStyle iz_hStyle = (HatchStyle)iz_Random.Next(0, 52);    // HatchStyle to eNum o przedziale 0-52, tak więc skróciłem sobie męki pisania randomowego wyboru do tego prostego przypisania random liczby.


            HatchBrush iz_hBrush = new HatchBrush(iz_hStyle, iz_lblBrush.BackColor, iz_lblColor.BackColor);

            switch (iz_dType.SelectedIndex)
            {
                case 0:
                    iz_DashStyle = DashStyle.Solid; break;
                case 1:
                    iz_DashStyle = DashStyle.Dash; break;
                case 2:
                    iz_DashStyle = DashStyle.DashDot; break;
                case 3:
                    iz_DashStyle = DashStyle.DashDotDot; break;
                case 4:
                    iz_DashStyle = DashStyle.Dot; break;
                default:
                    iz_DashStyle = DashStyle.Solid; break;
            }


            for (int i = 0; i < iz_HowManySelected; i++)
            {
                iz_Xh = iz_Random.Next(iz_margin, iz_MaxX);
                iz_Yh = iz_Random.Next(iz_margin, iz_MaxY);

                switch (iz_RandomFigureSelector[i])
                {
                    case 0:
                        iz_PointList.Add(new iz_Point(iz_Xh, iz_Yh, iz_lblColor.BackColor));
                        iz_PointList[iz_PointList.Count - 1].iz_Draw();
                        break;
                    case 1:
                        iz_PointList.Add(new iz_Circle(iz_Xh, iz_Yh, iz_Random.Next(1, 500), new SolidBrush(iz_lblColor.BackColor), iz_lblColor.BackColor, iz_DashStyle, (int)iz_numThickness.Value));
                        ((iz_Circle)iz_PointList[iz_PointList.Count - 1]).iz_Draw();
                        break;
                    case 2:
                        iz_PointList.Add(new iz_Circle(iz_Xh, iz_Yh, iz_Random.Next(1, 500), new SolidBrush(iz_lblColor.BackColor)));
                        ((iz_Circle)iz_PointList[iz_PointList.Count - 1]).iz_DrawFilled();
                        break;
                    case 3:
                        iz_PointList.Add(new iz_Circle(iz_Xh, iz_Yh, iz_Random.Next(1, 500), iz_hBrush));
                        ((iz_Circle)iz_PointList[iz_PointList.Count - 1]).iz_DrawHatched();
                        break;
                    case 4:
                        iz_PointList.Add(new iz_Ellipse(iz_Xh, iz_Yh, iz_Random.Next(1, 500), iz_Random.Next(1, 500), iz_lblColor.BackColor, (int)iz_numThickness.Value, iz_DashStyle));
                        ((iz_Ellipse)iz_PointList[iz_PointList.Count - 1]).iz_Draw();
                        break;
                    case 5:
                        iz_PointList.Add(new iz_Ellipse(iz_Xh, iz_Yh, iz_Random.Next(1, 500), iz_Random.Next(1, 500), new SolidBrush(iz_lblColor.BackColor)));
                        ((iz_Ellipse)iz_PointList[iz_PointList.Count - 1]).iz_DrawFilled();
                        break;
                    case 6:
                        iz_PointList.Add(new iz_Ellipse(iz_Xh, iz_Yh, iz_Random.Next(1, 500), iz_Random.Next(1, 500), iz_hBrush));
                        ((iz_Ellipse)iz_PointList[iz_PointList.Count - 1]).iz_DrawHatched();
                        break;
                    case 7:
                        iz_PointList.Add(new iz_Square(iz_Xh, iz_Yh, iz_Random.Next(1, 500), (int)iz_numThickness.Value, iz_lblColor.BackColor, iz_DashStyle));
                        ((iz_Square)iz_PointList[iz_PointList.Count - 1]).iz_Draw();
                        break;
                    case 8:
                        iz_PointList.Add(new iz_Square(iz_Xh, iz_Yh, iz_Random.Next(1, 500), new SolidBrush(iz_lblColor.BackColor)));
                        ((iz_Square)iz_PointList[iz_PointList.Count - 1]).iz_DrawFilled();
                        break;
                    case 9:
                        iz_PointList.Add(new iz_Square(iz_Xh, iz_Yh, iz_Random.Next(1, 500), iz_hBrush));
                        ((iz_Square)iz_PointList[iz_PointList.Count - 1]).iz_DrawHatched();
                        break;
                    case 10:
                        iz_PointList.Add(new iz_Rectangle(iz_Xh, iz_Yh, iz_Random.Next(1, 500), iz_Random.Next(1, 500), (int)iz_numThickness.Value, iz_lblColor.BackColor, iz_DashStyle));
                        ((iz_Rectangle)iz_PointList[iz_PointList.Count - 1]).iz_Draw();
                        break;
                    case 11:
                        iz_PointList.Add(new iz_Rectangle(iz_Xh, iz_Yh, iz_Random.Next(1, 500), iz_Random.Next(1, 500), new SolidBrush(iz_lblColor.BackColor)));
                        ((iz_Rectangle)iz_PointList[iz_PointList.Count - 1]).iz_DrawFilled();
                        break;
                    case 12:
                        iz_PointList.Add(new iz_Rectangle(iz_Xh, iz_Yh, iz_Random.Next(1, 500), iz_Random.Next(1, 500), iz_hBrush));
                        ((iz_Rectangle)iz_PointList[iz_PointList.Count - 1]).iz_DrawHatched();
                        break;
                }
            }

        }

        private void iz_btnMoveAll_Click(object sender, EventArgs e)
        {
            if (iz_PointList.Count == 0)
                return;
            Random iz_Random = new Random((int)DateTime.Now.Ticks * iz_RandomDistracter);
            iz_RandomDistracter = iz_Random.Next();

            iz_Graphics.Clear(Color.White);

            // Działa, ale nie pracujemy na warstwach, tylko metodą 'zagumkuj gdzie byłem', a to robi dziury w innych figurach :)
            // tak więc lepszy efekt będzie miało wyczyszczenie tablicy i narysowanie figur od początku

            foreach (iz_Point iz_moving in iz_PointList)
            {
                switch (iz_moving.iz_Type)
                {
                    case 0:
                        iz_moving.iz_Move(iz_Random.Next(1, 500), iz_Random.Next(1, 500)); break;
                    case 1:
                        ((iz_Circle)iz_moving).iz_Move(iz_Random.Next(1, 500), iz_Random.Next(1, 500)); break;
                    case 4:
                        ((iz_Ellipse)iz_moving).iz_Move(iz_Random.Next(1, 500), iz_Random.Next(1, 500)); break;
                    case 7:
                        ((iz_Square)iz_moving).iz_Move(iz_Random.Next(1, 500), iz_Random.Next(1, 500)); break;
                    case 10:
                        ((iz_Rectangle)iz_moving).iz_Move(iz_Random.Next(1, 500), iz_Random.Next(1, 500)); break;


                    case 2:
                        ((iz_Circle)iz_moving).iz_MoveFilled(iz_Random.Next(1, 500), iz_Random.Next(1, 500)); break;
                    case 5:
                        ((iz_Ellipse)iz_moving).iz_MoveFilled(iz_Random.Next(1, 500), iz_Random.Next(1, 500)); break;
                    case 8:
                        ((iz_Square)iz_moving).iz_MoveFilled(iz_Random.Next(1, 500), iz_Random.Next(1, 500)); break;
                    case 11:
                        ((iz_Rectangle)iz_moving).iz_MoveFilled(iz_Random.Next(1, 500), iz_Random.Next(1, 500)); break;


                    case 3:
                        ((iz_Circle)iz_moving).iz_MoveHatched(iz_Random.Next(1, 500), iz_Random.Next(1, 500)); break;
                    case 6:
                        ((iz_Ellipse)iz_moving).iz_MoveHatched(iz_Random.Next(1, 500), iz_Random.Next(1, 500)); break;
                    case 9:
                        ((iz_Square)iz_moving).iz_MoveHatched(iz_Random.Next(1, 500), iz_Random.Next(1, 500)); break;
                    case 12:
                        ((iz_Rectangle)iz_moving).iz_MoveHatched(iz_Random.Next(1, 500), iz_Random.Next(1, 500)); break;
                }
            }
        }

        private void iz_btnMoveAndChangeAll_Click(object sender, EventArgs e)
        {
            if (iz_PointList.Count < 1)
                return;

            for (int i = 0; i < iz_PointList.Count; i++)
            {
                Random iz_Random = new Random((int)DateTime.Now.Ticks * iz_RandomDistracter);
                iz_RandomDistracter = iz_Random.Next();


                switch (iz_PointList[i].iz_Type)
                {
                    case 0: iz_PointList[i].iz_Color = Color.FromArgb(iz_Random.Next(255), iz_Random.Next(255), iz_Random.Next(255)); break;

                    case 1:
                    case 4:
                    case 7:
                    case 10:
                        iz_PointList[i].iz_Color = Color.FromArgb(iz_Random.Next(255), iz_Random.Next(255), iz_Random.Next(255));
                        switch (iz_Random.Next(5))
                        {
                            case 0:
                                iz_PointList[i].iz_DashStyle = DashStyle.Solid; break;
                            case 1:
                                iz_PointList[i].iz_DashStyle = DashStyle.Dash; break;
                            case 2:
                                iz_PointList[i].iz_DashStyle = DashStyle.DashDot; break;
                            case 3:
                                iz_PointList[i].iz_DashStyle = DashStyle.DashDotDot; break;
                            case 4:
                                iz_PointList[i].iz_DashStyle = DashStyle.Dot; break;
                            default: iz_PointList[i].iz_DashStyle = DashStyle.Solid; break;
                        }
                        iz_PointList[i].iz_Thickness = iz_Random.Next(1, 20);
                        break;


                    case 2:
                    case 5:
                    case 8:
                    case 11:
                        Color iz_Color = Color.FromArgb(iz_Random.Next(255), iz_Random.Next(255), iz_Random.Next(255));
                        iz_PointList[i].iz_sBrush = new SolidBrush(iz_Color); break;


                    case 3:
                    case 6:
                    case 9:
                    case 12:
                        HatchStyle iz_hStyle = (HatchStyle)iz_Random.Next(0, 52);    // HatchStyle to eNum o przedziale 0-52, tak więc skróciłem sobie męki pisania randomowego wyboru do tego prostego przypisania random liczby.
                        iz_PointList[i].iz_HatchBrush = new HatchBrush(iz_hStyle, Color.FromArgb(iz_Random.Next(255),
                                                   iz_Random.Next(255), iz_Random.Next(255)), Color.FromArgb(iz_Random.Next(255), iz_Random.Next(255), iz_Random.Next(255))); break;

                }

            }
            iz_btnMoveAll_Click(sender, e);
        }

        private void iz_btnChangeAll_Click(object sender, EventArgs e)
        {
            if (iz_PointList.Count < 1)
                return;

            iz_Graphics.Clear(Color.White);
            for (int i = 0; i < iz_PointList.Count; i++)
            {
                Random iz_Random = new Random((int)DateTime.Now.Ticks * iz_RandomDistracter);
                iz_RandomDistracter = iz_Random.Next();


                switch (iz_PointList[i].iz_Type)
                {
                    case 0: iz_PointList[i].iz_Color = Color.FromArgb(iz_Random.Next(255), iz_Random.Next(255), iz_Random.Next(255)); break;

                    case 1:
                    case 4:
                    case 7:
                    case 10:
                        iz_PointList[i].iz_Color = Color.FromArgb(iz_Random.Next(255), iz_Random.Next(255), iz_Random.Next(255));
                        switch (iz_Random.Next(5))
                        {
                            case 0:
                                iz_PointList[i].iz_DashStyle = DashStyle.Solid; break;
                            case 1:
                                iz_PointList[i].iz_DashStyle = DashStyle.Dash; break;
                            case 2:
                                iz_PointList[i].iz_DashStyle = DashStyle.DashDot; break;
                            case 3:
                                iz_PointList[i].iz_DashStyle = DashStyle.DashDotDot; break;
                            case 4:
                                iz_PointList[i].iz_DashStyle = DashStyle.Dot; break;
                            default: iz_PointList[i].iz_DashStyle = DashStyle.Solid; break;
                        }
                        iz_PointList[i].iz_Thickness = iz_Random.Next(1, 20);
                        break;


                    case 2:
                    case 5:
                    case 8:
                    case 11:
                        Color iz_Color = Color.FromArgb(iz_Random.Next(255), iz_Random.Next(255), iz_Random.Next(255));
                        iz_PointList[i].iz_sBrush = new SolidBrush(iz_Color); break;


                    case 3:
                    case 6:
                    case 9:
                    case 12:
                        HatchStyle iz_hStyle = (HatchStyle)iz_Random.Next(0, 52);    // HatchStyle to eNum o przedziale 0-52, tak więc skróciłem sobie męki pisania randomowego wyboru do tego prostego przypisania random liczby.
                        iz_PointList[i].iz_HatchBrush = new HatchBrush(iz_hStyle, Color.FromArgb(iz_Random.Next(255),
                                                   iz_Random.Next(255), iz_Random.Next(255)), Color.FromArgb(iz_Random.Next(255), iz_Random.Next(255), iz_Random.Next(255))); break;

                }

                switch (iz_PointList[i].iz_Type)
                {
                    case 0:
                        iz_PointList[i].iz_Draw(); break;
                    case 1:
                        ((iz_Circle)iz_PointList[i]).iz_Draw(); break;
                    case 4:
                        ((iz_Ellipse)iz_PointList[i]).iz_Draw(); break;
                    case 7:
                        ((iz_Square)iz_PointList[i]).iz_Draw(); break;
                    case 10:
                        ((iz_Rectangle)iz_PointList[i]).iz_Draw(); break;


                    case 2:
                        ((iz_Circle)iz_PointList[i]).iz_DrawFilled(); break;
                    case 5:
                        ((iz_Ellipse)iz_PointList[i]).iz_DrawFilled(); break;
                    case 8:
                        ((iz_Square)iz_PointList[i]).iz_DrawFilled(); break;
                    case 11:
                        ((iz_Rectangle)iz_PointList[i]).iz_DrawFilled(); break;


                    case 3:
                        ((iz_Circle)iz_PointList[i]).iz_DrawHatched(); break;
                    case 6:
                        ((iz_Ellipse)iz_PointList[i]).iz_DrawHatched(); break;
                    case 9:
                        ((iz_Square)iz_PointList[i]).iz_DrawHatched(); break;
                    case 12:
                        ((iz_Rectangle)iz_PointList[i]).iz_DrawHatched(); break;
                }
            }
        }

        private void iz_lblColor_Click(object sender, EventArgs e)
        {
            iz_ColorDialog.ShowDialog();

            iz_lblColor.BackColor = iz_ColorDialog.Color;
        }

        private void iz_lblBrush_Click(object sender, EventArgs e)
        {
            iz_ColorDialog.ShowDialog();
            iz_lblBrush.BackColor = iz_ColorDialog.Color;
        }

        private void iz_btnClear_Click(object sender, EventArgs e)
        {
            iz_Graphics.Clear(Color.White);
            iz_PointList.Clear();
        }

        private void iz_btnCyfry_Click(object sender, EventArgs e)
        {
            Font iz_Font = new Font(iz_btnCyfry.Font.Name, 10.0f);
            for (int i = 0; i < iz_PointList.Count; i++)
                iz_Graphics.DrawString(i.ToString(), iz_Font, (new SolidBrush(Color.Black)), iz_PointList[i].iz_X, iz_PointList[i].iz_Y);
        }

        private void iz_btnDelete_Click(object sender, EventArgs e)
        {
            if (iz_PointList.Count < 1)
                return;

            if ((int)iz_numDelete.Value > iz_PointList.Count -1 )
                return;

              iz_Graphics.Clear(Color.White);
              iz_PointList.Remove(iz_PointList[(int)iz_numDelete.Value]);
              for (int i = 0; i < iz_PointList.Count; i++)
              {

                  switch (iz_PointList[i].iz_Type)
                  {
                      case 0:
                          iz_PointList[i].iz_Draw(); break;
                      case 1:
                          ((iz_Circle)iz_PointList[i]).iz_Draw(); break;
                      case 4:
                          ((iz_Ellipse)iz_PointList[i]).iz_Draw(); break;
                      case 7:
                          ((iz_Square)iz_PointList[i]).iz_Draw(); break;
                      case 10:
                          ((iz_Rectangle)iz_PointList[i]).iz_Draw(); break;


                      case 2:
                          ((iz_Circle)iz_PointList[i]).iz_DrawFilled(); break;
                      case 5:
                          ((iz_Ellipse)iz_PointList[i]).iz_DrawFilled(); break;
                      case 8:
                          ((iz_Square)iz_PointList[i]).iz_DrawFilled(); break;
                      case 11:
                          ((iz_Rectangle)iz_PointList[i]).iz_DrawFilled(); break;


                      case 3:
                          ((iz_Circle)iz_PointList[i]).iz_DrawHatched(); break;
                      case 6:
                          ((iz_Ellipse)iz_PointList[i]).iz_DrawHatched(); break;
                      case 9:
                          ((iz_Square)iz_PointList[i]).iz_DrawHatched(); break;
                      case 12:
                          ((iz_Rectangle)iz_PointList[i]).iz_DrawHatched(); break;
                  }
              }

        }







    }
}



