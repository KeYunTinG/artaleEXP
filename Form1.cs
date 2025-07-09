
using System.Text.RegularExpressions;
using Tesseract;

namespace expTool
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer _expTimer = new System.Windows.Forms.Timer();
        private Rectangle? _selectedArea = null;

        private int ���j���� = 0;
        private int EXP�l = 0;
        private int EXP�� = 0;
        private double EXP�ʤ���l = 0;
        private double EXP�ʤ���� = 0;
        public Form1()
        {
            InitializeComponent();
            int.TryParse(���j�ɶ�.Text, out ���j����);
            _expTimer.Interval = ���j���� * 60 *  1000; // �C 1000 �@�����@���]1 ��^
            _expTimer.Tick += (s, e) => �{���Ұ�(); // �j�w��k
        }

        private void button1_Click(object sender, EventArgs e)
        {
            �^���e��();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (_selectedArea == null)
            {
                MessageBox.Show("�Х���ܵe���d��");
                _expTimer.Stop();
                return;
            }
            reset();
            if (!_expTimer.Enabled)
            {
                _expTimer.Start(); // �Ұʩw���^��
                button2.Text = "����p��"; // �i��G����s��r
            }
            else
            {
                _expTimer.Stop();  // ����
                button2.Text = "�}�l�p��";
            }
        }

        public void �^���e��()
        {
            try
            {
                using (var selector = new SelectionForm())
                {
                    if (selector.ShowDialog() == DialogResult.OK)
                    {
                        _selectedArea = selector.SelectedArea;
                        MessageBox.Show("�e���d��w��������C");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("���~�G" + ex.Message);
            }
        }

        public void �{���Ұ�()
        {
            �e������();
            if ((EXP�� > 0) && (EXP�ʤ���� > 0))
            {
                �p��g��();
            }
        }

        public void �e������()
        {
            try
            {
                if (_selectedArea == null)
                {
                    return;
                }
                // �^���e��
                Bitmap bmp = CaptureScreenArea(_selectedArea.Value);

                // OCR ����
                string text = ReadTextFromImage(bmp);

                // �^�� EXP �ƭ�
                var expMatch = Regex.Match(text, @"\s*(\d+)");
                int? expValue = expMatch.Success ? int.Parse(expMatch.Groups[1].Value) : null;

                // �^���ʤ���
                var percentMatch = Regex.Match(text, @"\[(\d+(\.\d+)?)%");
                double? percentValue = percentMatch.Success ? double.Parse(percentMatch.Groups[1].Value) : null;

                // ��ܵ��G
                info.Text = $"EXP: {expValue?.ToString() ?? "���ѧO"}�A" +
                              $"�ʤ���: {percentValue?.ToString("0.0") ?? "���ѧO"}%";
                if ((EXP�l == 0) || (EXP�ʤ���l == 0))
                {
                    EXP�l = expValue ?? 0;
                    EXP�ʤ���l = percentValue ?? 0;
                }
                else
                {
                    EXP�� = expValue ?? 0;
                    EXP�ʤ���� = percentValue ?? 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("���~�G" + ex.Message);
            }
        }

        public string ReadTextFromImage(Bitmap image)
        {
            using (var engine = new Tesseract.TesseractEngine(@"./tessdata", "eng", Tesseract.EngineMode.Default))
            {
                // ����u�ѧO�Y�Ǧr���]�i��^
                engine.SetVariable("tessedit_char_whitelist", "0123456789.%[]");

                using (var pix = PixConverter.ToPix(image))
                using (var page = engine.Process(pix))
                {
                    return page.GetText().Trim();
                }
            }
        }

        // �^���e�����w�ϰ�
        public Bitmap CaptureScreenArea(Rectangle area)
        {
            Bitmap bmp = new Bitmap(area.Width, area.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(area.Location, Point.Empty, area.Size);
            }
            return bmp;
        }
        public void �p��g��()
        {
            double �C�����w�� = (30.8 - 15.2) / ((���j����/ ���j����));
            double �C�Q�����w�� = �C�����w�� * 10;
            double �ɯŭ˼Ʈɶ� = (100 - EXP�ʤ����) / �C�����w��;

            �C�����g��.Text = �C�����w��.ToString("F2");
            �C�Q�����g��.Text = �C�Q�����w��.ToString("F2");
            TimeSpan ts = TimeSpan.FromSeconds(�ɯŭ˼Ʈɶ�);
            �ɯŭ˼�.Text = ts.ToString(@"hh\:mm\:ss");
        }
        private void ���j�ɶ�_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(���j�ɶ�.Text, out int value))
            {
                if (value < 1) // �]�w�̤p��1
                {
                    value = 1;
                }
                else if (value > 10) // �]�w�̤j��60
                {
                    value = 10;
                }
                ���j�ɶ�.Text = value.ToString();
            }
            else
            {
                MessageBox.Show("�п�J���Ī����");
                ���j�ɶ�.Text = "1"; // �w�]��
            }
        }
        public void reset()
        {
            info.Text = "";
            �C�����g��.Text = "";
            �C�Q�����g��.Text = "";
            �ɯŭ˼�.Text = "";
            EXP�l = 0;
            EXP�� = 0;
            EXP�ʤ���l = 0;
            EXP�ʤ���� = 0;
        }
    }
}
