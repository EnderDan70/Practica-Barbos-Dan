using System;
using System.Windows.Forms;

namespace st.ind2
{
    public partial class LoadingForm : Form
    {
        private int cartX;
        private int cartDirection = 1; // 1 - вправо, -1 - влево
        private int cartSpeed = 4; // пикселей за тик
        private int loadingStep = 0;
        private int loadingMax = 300; // 10 секунд при interval=20

        public LoadingForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            progressBar1.Value = 0;
            loadingStep = 0;
            // Ставим тележку в начало панели (по X)
            cartX = 0;
            pictureBoxCart.Left = cartX;
            // Тележка над надписью
            pictureBoxCart.Top = labelLoading.Top - pictureBoxCart.Height - 10;
            cartDirection = 1;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Двигаем тележку туда-сюда по всей ширине панели
            int leftLimit = 0;
            int rightLimit = panelProgressContainer.Width - pictureBoxCart.Width;

            cartX += cartDirection * cartSpeed;
            if (cartX <= leftLimit)
            {
                cartX = leftLimit;
                cartDirection = 1;
            }
            else if (cartX >= rightLimit)
            {
                cartX = rightLimit;
                cartDirection = -1;
            }
            pictureBoxCart.Left = cartX;

            // Плавная загрузка (НЕ связана с тележкой)
            if (loadingStep < loadingMax)
            {
                loadingStep++;
                progressBar1.Value = (int)((double)loadingStep / loadingMax * progressBar1.Maximum);
            }
            else
            {
                timer1.Stop();
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
        }

        private void labelLoading_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxCart_Click(object sender, EventArgs e)
        {

        }
    }
}
