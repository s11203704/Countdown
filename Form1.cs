namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        private int countdownSeconds = 0;
        private bool isCounting = false;
        public Form1()
        {
            InitializeComponent();
        }
        // ����s�Q���U
        private void button1_Click(object sender, EventArgs e)
        {
            if (!isCounting)
            {
                // ��l�˼Ƭ�Ƭ�100
                countdownSeconds = 100;
                // �N���ҳ]����l���
                label1.Text = countdownSeconds.ToString();
                // �}�l�˼ƭp�ɾ�
                isCounting = true;
                Thread countdownThread = new Thread(new ThreadStart(Countdown));
                countdownThread.Start();
            }
        }
        private void Countdown()
        {
            while (countdownSeconds > 0)
            {
                //��s���Ҫ���r
                label1.Invoke((MethodInvoker)delegate
                {
                    label1.Text = countdownSeconds.ToString();
                });

                // ���� 1 ��
                Thread.Sleep(1000);

                // ��֭˼Ƭ��
                countdownSeconds--;
            }

            // �˼ƭp�ɵ����A�����s����
            isCounting = false;
            // ��ܹ�ܮ�"�ɶ���I"
            MessageBox.Show("�ɶ���I");
        }
    }
}