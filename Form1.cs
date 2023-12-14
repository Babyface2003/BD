namespace Курсач_по_бд
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ResultButton_Click(object sender, EventArgs e)
        {
            check_null();
            double N_ = Convert.ToDouble(N.Text);
            double n_1 = Convert.ToDouble(n1.Text);
            double Fi_ = Convert.ToDouble(Fi.Text);
            double n_2 = Convert.ToDouble(n2.Text);
            double z_1 = Convert.ToDouble(z1.Text);
            double q_ = Convert.ToDouble(q.Text);
            double i_ = Convert.ToDouble(i.Text);


            double Calculate_m_ = Calculate_m(N_, n_1);
            double Calculate_b_ = Calculate_b(Fi_, Calculate_m_);
            double Calculate_u_ = Calculate_u(n_1, n_2);
            double Calculate_z_2_ = Calculate_z_2(z_1, Calculate_u_);
            double Calculate_F_ = Calculate_F(z_1, Calculate_m_, N_, n_1);
            double Calculate_C_1_ = Calculate_C_1(Calculate_F_, i_, z_1, Calculate_b_);
            double Calculate_C_2_ = Calculate_C_2(Calculate_F_, i_, Calculate_z_2_, Calculate_b_);
            double Calculate_d_1_ = Calculate_d_1(z_1, Calculate_m_, q_, Calculate_C_1_);
            double Calculate_d_2_ = Calculate_d_2(Calculate_z_2_, Calculate_m_, q_, Calculate_C_2_);

            m.Text = " m = " + Calculate_m_.ToString("F2");
            b.Text = " b = " + Calculate_b_.ToString("F2");
            u.Text = " u = " + Calculate_u_.ToString("F2");
            F.Text = " F = " + Calculate_F_.ToString("F2");
            C1.Text = " C1 = " + Calculate_C_1_.ToString("F2");
            C2.Text = " C2 = " + Calculate_C_2_.ToString("F2");
            d1.Text = " d1 = " + Calculate_d_1_.ToString("F2");
            d2.Text = " d2 = " + Calculate_d_2_.ToString("F2");
        }
        private double Calculate_m(double N, double n1)
        {
            return (35 * Math.Pow(Convert.ToDouble(N) / Convert.ToDouble(n1), 1.0 / 3.0));
        }
        private double Calculate_b(double Fi, double Calculate_m)
        {
            return (Convert.ToDouble(Fi) * Convert.ToDouble(Calculate_m));
        }
        private double Calculate_u(double n1, double n2)
        {
            return (Convert.ToDouble(n1) / Convert.ToDouble(n2));
        }
        private double Calculate_z_2(double z1, double Calculate_u)
        {
            return (Convert.ToDouble(z1) * Convert.ToDouble(Calculate_u));
        }
        private double Calculate_F(double z1, double Calculate_m, double N, double n1)
        {
            return ((1.91 * Math.Pow(10, 7) * Convert.ToDouble(N)) / (Convert.ToDouble(Calculate_m) * Convert.ToDouble(z1) * Convert.ToDouble(n1)));
        }
        private double Calculate_C_1(double Calculate_F, double i, double z1, double Calculate_b)
        {
            return ((0.15 * Convert.ToDouble(Calculate_F) * Convert.ToDouble(i) * Convert.ToDouble(z1)) / Convert.ToDouble(Calculate_b));
        }
        private double Calculate_C_2(double Calculate_F, double i, double z2, double Calculate_b)
        {
            return ((0.15 * Convert.ToDouble(Calculate_F) * Convert.ToDouble(i) * Convert.ToDouble(z2)) / Convert.ToDouble(Calculate_b));
        }
        private double Calculate_d_1(double z1, double Calculate_m, double q, double Calculate_C_1)
        {
            return (Convert.ToDouble(Calculate_m) * Convert.ToDouble(z1) - 2 * Convert.ToDouble(q) + Convert.ToDouble(Calculate_C_1));
        }
        private double Calculate_d_2(double Calculate_z_2, double Calculate_m, double q, double Calculate_C_2)
        {
            return (Convert.ToDouble(Calculate_m) * Convert.ToDouble(Calculate_z_2) - 2 * Convert.ToDouble(q) + Convert.ToDouble(Calculate_C_2));
        }
        private void check_null()
        {
            TextBox[] textBoxes = { N, n1, Fi, n2, q };

            foreach (TextBox textBox in textBoxes)
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    textBox.Text = "1,00";
                }
            }

            ComboBox[] comboBoxes = { z1, i };

            foreach (ComboBox comboBox in comboBoxes)
            {
                if (comboBox.SelectedItem == null)
                {
                    comboBox.SelectedIndex = 0;
                }
            }
        }
    }
}