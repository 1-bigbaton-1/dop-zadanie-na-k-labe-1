using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class SportCar
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
        /// Левая координата отрисовки автомобиля
        private float _startPosX;

        /// Правая кооридната отрисовки автомобиля
        private float _startPosY;

        /// Ширина окна отрисовки
        private int _pictureWidth;

        /// Высота окна отрисовки
        private int _pictureHeight;

        /// Ширина отрисовки автомобиля
        private const int carWidth = 100;

        /// Ширина отрисовки автомобиля
        private const int carHeight = 60;

        /// Максимальная скорость
        public int MaxSpeed { private set; get; }

        /// Вес автомобиля
        public float Weight { private set; get; }

        /// Основной цвет кузова
        public Color MainColor { private set; get; }

        /// Дополнительный цвет
        public Color DopColor { private set; get; }

        /// Признак наличия переднего спойлера
        public bool FrontSpoiler { private set; get; }

        /// Признак наличия боковых спойлеров
        public bool SideSpoiler { private set; get; }

        public bool BackSpoiler { private set; get; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автомобиля</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        /// <param name="dopColor">Дополнительный цвет</param>
        /// <param name="frontSpoiler">Признак наличия переднего спойлера</param>
        /// <param name="sideSpoiler">Признак наличия боковых спойлеров</param>
        /// <param name="backSpoiler">Признак наличия заднего спойлера</param>
        public SportCar(int maxSpeed, float weight, Color mainColor, Color dopColor,
        bool frontSpoiler, bool sideSpoiler, bool backSpoiler)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
            FrontSpoiler = frontSpoiler;
            SideSpoiler = sideSpoiler;
            BackSpoiler = backSpoiler;
        }

        /// <summary>
        /// Установка позиции автомобиля
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="width">Ширина картинки</param>
        /// <param name="height">Высота картинки</param>
        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;
        }

        /// <summary>
        /// Изменение направления пермещения
        /// </summary>
        /// <param name="direction">Направление</param>
        public void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                // вправо
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - carWidth)
                    {
                        _startPosX += step;
                    }
                    break;
                //влево
                case Direction.Left:
                    if (_startPosX - step > 0)
                    {
                        _startPosX -= step;
                    }
                    break;
                //вверх
                case Direction.Up:
                    if (_startPosY - step > 0)
                    {
                        _startPosY -= step;
                    }
                    break;
                //вниз
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - carHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }
        /// <summary>
        /// Отрисовка автомобиля
        /// </summary>
        /// <param name="g"></param>
        public void DrawCar(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            // отрисуем сперва передний спойлер автомобиля (чтобы потом отрисовка автомобиля на него "легла")
            //if (FrontSpoiler)
            //{
            //    g.DrawEllipse(pen, _startPosX + 80, _startPosY - 6, 20, 20);
            //    g.DrawEllipse(pen, _startPosX + 80, _startPosY + 35, 20, 20);
            //    g.DrawEllipse(pen, _startPosX - 5, _startPosY - 6, 20, 20);
            //    g.DrawEllipse(pen, _startPosX - 5, _startPosY + 35, 20, 20);
            //    g.DrawRectangle(pen, _startPosX + 80, _startPosY - 6, 15, 15);
            //    g.DrawRectangle(pen, _startPosX + 80, _startPosY + 40, 15, 15);
            //    g.DrawRectangle(pen, _startPosX, _startPosY - 6, 14, 15);
            //    g.DrawRectangle(pen, _startPosX, _startPosY + 40, 14, 15);
            //    Brush spoiler = new SolidBrush(DopColor);
            //    g.FillEllipse(spoiler, _startPosX + 80, _startPosY - 5, 20, 20);
            //    g.FillEllipse(spoiler, _startPosX + 80, _startPosY + 35, 20, 20);
            //    g.FillRectangle(spoiler, _startPosX + 75, _startPosY, 25, 40);
            //    g.FillRectangle(spoiler, _startPosX + 80, _startPosY - 5, 15, 15);
            //    g.FillRectangle(spoiler, _startPosX + 80, _startPosY + 40, 15, 15);
            //    g.FillEllipse(spoiler, _startPosX - 5, _startPosY - 5, 20, 20);
            //    g.FillEllipse(spoiler, _startPosX - 5, _startPosY + 35, 20, 20);
            //    g.FillRectangle(spoiler, _startPosX - 5, _startPosY, 25, 40);
            //    g.FillRectangle(spoiler, _startPosX, _startPosY - 5, 15, 15);
            //    g.FillRectangle(spoiler, _startPosX, _startPosY + 40, 15, 15);
            //}
            // и боковые
            //if (SideSpoiler)
            //{
            //    g.DrawRectangle(pen, _startPosX + 25, _startPosY - 6, 39, 10);
            //    g.DrawRectangle(pen, _startPosX + 25, _startPosY + 45, 39, 10);
            //    Brush spoiler = new SolidBrush(DopColor);
            //    g.FillRectangle(spoiler, _startPosX + 25, _startPosY - 5, 40, 10);
            //    g.FillRectangle(spoiler, _startPosX + 25, _startPosY + 45, 40, 10);
            //}
            // теперь отрисуем основной кузов автомобиля
            //границы автомобиля
            //g.DrawEllipse(pen, _startPosX, _startPosY, 20, 20);
            //g.DrawEllipse(pen, _startPosX, _startPosY + 30, 20, 20);
            //g.DrawEllipse(pen, _startPosX + 70, _startPosY, 20, 20);
            //g.DrawEllipse(pen, _startPosX + 70, _startPosY + 30, 20, 20);
            //g.DrawRectangle(pen, _startPosX - 1, _startPosY + 10, 10, 30);
            //g.DrawRectangle(pen, _startPosX + 80, _startPosY + 10, 10, 30);
            g.DrawRectangle(pen, _startPosX + 10, _startPosY - 1, 150, 30);
            g.DrawRectangle(pen, _startPosX + 10, _startPosY - 30, 50, 30);
            g.DrawRectangle(pen, _startPosX + 70, _startPosY - 10, 10, 10 );
            g.DrawRectangle(pen, _startPosX + 90, _startPosY - 10, 10, 10);
            g.DrawRectangle(pen, _startPosX + 110, _startPosY - 10, 10, 10);
            g.DrawRectangle(pen, _startPosX + 130, _startPosY - 10, 10, 10);
            g.DrawRectangle(pen, _startPosX + 150, _startPosY - 10, 10, 10);
            //задние фары
            ////////Brush brRed = new SolidBrush(Color.Red);
            //////////g.FillEllipse(brRed, _startPosX, _startPosY, 20, 20);
            ////////g.FillEllipse(brRed, _startPosX, _startPosY - 30, 50, 30);
            ////передние фары
            //Brush brYellow = new SolidBrush(Color.Yellow);
            //g.FillEllipse(brYellow, _startPosX + 70, _startPosY, 20, 20);
            //g.FillEllipse(brYellow, _startPosX + 70, _startPosY + 30, 20, 20);
            ////кузов
            //Brush br = new SolidBrush(MainColor);
            //g.FillRectangle(br, _startPosX, _startPosY + 10, 10, 30);
            //g.FillRectangle(br, _startPosX + 80, _startPosY + 10, 10, 30);
            //g.FillRectangle(br, _startPosX + 10, _startPosY, 70, 50);
            ////стекла
            //Brush brBlue = new SolidBrush(Color.LightBlue);
            //g.FillRectangle(brBlue, _startPosX + 60, _startPosY + 5, 5, 40);
            //g.FillRectangle(brBlue, _startPosX + 20, _startPosY + 5, 5, 40);
            //g.FillRectangle(brBlue, _startPosX + 25, _startPosY + 3, 35, 2);
            //g.FillRectangle(brBlue, _startPosX + 25, _startPosY + 46, 35, 2);
            ////выделяем рамкой крышу
            //g.DrawRectangle(pen, _startPosX + 25, _startPosY + 5, 35, 40);
            //g.DrawRectangle(pen, _startPosX + 65, _startPosY + 10, 25, 30);
            //g.DrawRectangle(pen, _startPosX, _startPosY + 10, 15, 30);
            //// рисуем гоночные полоски
            //br = new SolidBrush(DopColor);
            //g.FillRectangle(br, _startPosX + 65, _startPosY + 18, 25, 15);
            //g.FillRectangle(br, _startPosX + 25, _startPosY + 18, 35, 15);
            //g.FillRectangle(br, _startPosX, _startPosY + 18, 20, 15);
            //// рисуем задний спойлер автомобиля
            //if (BackSpoiler)
            //{
            //    Brush spoiler = new SolidBrush(DopColor);
            //    g.FillRectangle(spoiler, _startPosX - 5, _startPosY, 10, 50);
            //    g.DrawRectangle(pen, _startPosX - 5, _startPosY, 10, 50);
            //}
        }
        }
    }
