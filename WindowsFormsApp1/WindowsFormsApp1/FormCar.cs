using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp1.SportCar;

namespace WindowsFormsApp1
{
    public partial class FormCar : Form
    {
        private SportCar car;
        public FormCar()
        {
            InitializeComponent();
        }

        /// Метод отрисовки машины
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxCars.Width, pictureBoxCars.Height);
            Graphics gr = Graphics.FromImage(bmp);
            car.DrawCar(gr);
            pictureBoxCars.Image = bmp;
        }

        /// Обработка нажатия кнопки "Создать"
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            car = new SportCar(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue,
            Color.Yellow, true, true, true);
            car.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxCars.Width,
            pictureBoxCars.Height);
            Draw();
        }

        /// Обработка нажатия кнопок управления
        private void buttonMove_Click(object sender, EventArgs e)
        {
            //получаем имя кнопки
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    car.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    car.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    car.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    car.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }

        private void FormCar_Load(object sender, EventArgs e)
        {

        }
    }
}
