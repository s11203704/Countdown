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
        // 當按鈕被按下
        private void button1_Click(object sender, EventArgs e)
        {
            if (!isCounting)
            {
                // 初始倒數秒數為100
                countdownSeconds = 100;
                // 將標籤設為初始秒數
                label1.Text = countdownSeconds.ToString();
                // 開始倒數計時器
                isCounting = true;
                Thread countdownThread = new Thread(new ThreadStart(Countdown));
                countdownThread.Start();
            }
        }
        private void Countdown()
        {
            while (countdownSeconds > 0)
            {
                //更新標籤的文字
                label1.Invoke((MethodInvoker)delegate
                {
                    label1.Text = countdownSeconds.ToString();
                });

                // 等待 1 秒
                Thread.Sleep(1000);

                // 減少倒數秒數
                countdownSeconds--;
            }

            // 倒數計時結束，停止更新標籤
            isCounting = false;
            // 顯示對話框"時間到！"
            MessageBox.Show("時間到！");
        }
    }
}