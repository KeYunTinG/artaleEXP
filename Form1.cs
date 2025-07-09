
using System.Text.RegularExpressions;
using Tesseract;

namespace expTool
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer _expTimer = new System.Windows.Forms.Timer();
        private Rectangle? _selectedArea = null;

        private int 間隔分鐘 = 0;
        private int EXP始 = 0;
        private int EXP終 = 0;
        private double EXP百分比始 = 0;
        private double EXP百分比終 = 0;
        public Form1()
        {
            InitializeComponent();
            int.TryParse(間隔時間.Text, out 間隔分鐘);
            _expTimer.Interval = 間隔分鐘 * 60 *  1000; // 每 1000 毫秒執行一次（1 秒）
            _expTimer.Tick += (s, e) => 程式啟動(); // 綁定方法
        }

        private void button1_Click(object sender, EventArgs e)
        {
            擷取畫面();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (_selectedArea == null)
            {
                MessageBox.Show("請先選擇畫面範圍");
                _expTimer.Stop();
                return;
            }
            reset();
            if (!_expTimer.Enabled)
            {
                _expTimer.Start(); // 啟動定時擷取
                button2.Text = "停止計算"; // 可選：改按鈕文字
            }
            else
            {
                _expTimer.Stop();  // 停止
                button2.Text = "開始計算";
            }
        }

        public void 擷取畫面()
        {
            try
            {
                using (var selector = new SelectionForm())
                {
                    if (selector.ShowDialog() == DialogResult.OK)
                    {
                        _selectedArea = selector.SelectedArea;
                        MessageBox.Show("畫面範圍已選取完畢。");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤：" + ex.Message);
            }
        }

        public void 程式啟動()
        {
            畫面轉資料();
            if ((EXP終 > 0) && (EXP百分比終 > 0))
            {
                計算經驗();
            }
        }

        public void 畫面轉資料()
        {
            try
            {
                if (_selectedArea == null)
                {
                    return;
                }
                // 擷取畫面
                Bitmap bmp = CaptureScreenArea(_selectedArea.Value);

                // OCR 辨識
                string text = ReadTextFromImage(bmp);

                // 擷取 EXP 數值
                var expMatch = Regex.Match(text, @"\s*(\d+)");
                int? expValue = expMatch.Success ? int.Parse(expMatch.Groups[1].Value) : null;

                // 擷取百分比
                var percentMatch = Regex.Match(text, @"\[(\d+(\.\d+)?)%");
                double? percentValue = percentMatch.Success ? double.Parse(percentMatch.Groups[1].Value) : null;

                // 顯示結果
                info.Text = $"EXP: {expValue?.ToString() ?? "未識別"}，" +
                              $"百分比: {percentValue?.ToString("0.0") ?? "未識別"}%";
                if ((EXP始 == 0) || (EXP百分比始 == 0))
                {
                    EXP始 = expValue ?? 0;
                    EXP百分比始 = percentValue ?? 0;
                }
                else
                {
                    EXP終 = expValue ?? 0;
                    EXP百分比終 = percentValue ?? 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤：" + ex.Message);
            }
        }

        public string ReadTextFromImage(Bitmap image)
        {
            using (var engine = new Tesseract.TesseractEngine(@"./tessdata", "eng", Tesseract.EngineMode.Default))
            {
                // 限制只識別某些字元（可選）
                engine.SetVariable("tessedit_char_whitelist", "0123456789.%[]");

                using (var pix = PixConverter.ToPix(image))
                using (var page = engine.Process(pix))
                {
                    return page.GetText().Trim();
                }
            }
        }

        // 擷取畫面指定區域
        public Bitmap CaptureScreenArea(Rectangle area)
        {
            Bitmap bmp = new Bitmap(area.Width, area.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(area.Location, Point.Empty, area.Size);
            }
            return bmp;
        }
        public void 計算經驗()
        {
            double 每分鐘趴數 = (30.8 - 15.2) / ((間隔分鐘/ 間隔分鐘));
            double 每十分鐘趴數 = 每分鐘趴數 * 10;
            double 升級倒數時間 = (100 - EXP百分比終) / 每分鐘趴數;

            每分鐘經驗.Text = 每分鐘趴數.ToString("F2");
            每十分鐘經驗.Text = 每十分鐘趴數.ToString("F2");
            TimeSpan ts = TimeSpan.FromSeconds(升級倒數時間);
            升級倒數.Text = ts.ToString(@"hh\:mm\:ss");
        }
        private void 間隔時間_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(間隔時間.Text, out int value))
            {
                if (value < 1) // 設定最小值1
                {
                    value = 1;
                }
                else if (value > 10) // 設定最大值60
                {
                    value = 10;
                }
                間隔時間.Text = value.ToString();
            }
            else
            {
                MessageBox.Show("請輸入有效的整數");
                間隔時間.Text = "1"; // 預設值
            }
        }
        public void reset()
        {
            info.Text = "";
            每分鐘經驗.Text = "";
            每十分鐘經驗.Text = "";
            升級倒數.Text = "";
            EXP始 = 0;
            EXP終 = 0;
            EXP百分比始 = 0;
            EXP百分比終 = 0;
        }
    }
}
