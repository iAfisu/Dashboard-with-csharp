using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
//using System.Data;

namespace Dashboard
{
    public partial class Main : Form
    {
        Connection connect = new Connection();
        Home home = new Home();
        public Main()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            this.Hide();
            login.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            renderBarchart();
            renderPieChart();

            //retrieveBarChartData();
            //renderLineChart();

            showTable();

            button1.BackColor = Color.FromArgb(0, 0, 192);
        }

        //to show register form in mainform
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_main.Controls.Add(childForm);
            panel_main.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        void renderBarchart()
        {
            Bunifu.Charts.WinForms.ChartTypes.BunifuBarChart bunifuBarChart = new Bunifu.Charts.WinForms.ChartTypes.BunifuBarChart();
            /*
             * For this example we will use random numbers
             */
            var r = new Random();

            /*
             * Add your data from your source - accepts double list
             * Below is an example from a random number
             */
            List<double> data = new List<double>();

            for (int i = 0; i < 5; i++)
            {
                data.Add(r.Next(0, 50));
            }
            /*
             * Set your data             
             */
            bunifuBarChart.Data = data;

            /*
             * Specify the target canvas
             */
            bunifuBarChart.TargetCanvas = bunifuChartCanvas1;

            /*
             * Add labels to your canvas
             * Label count should correspond to data count for charts like Bar charts
             */
            bunifuChartCanvas1.Labels = new string[] { "Label1", "Label2", "Label3", "Label4", "Label5" };

            /*
             * Beautify the chart by sepcifying the colors
             * Color count should correspond to data count
             */
            List<Color> bgColors = new List<Color>();
            for (int i = 0; i < data.Count; i++)
            {
                bgColors.Add(Color.FromArgb(r.Next(256), r.Next(256), r.Next(256)));
            }
            bunifuBarChart.BackgroundColor = bgColors;
        }

        void renderPieChart()
        {
            Bunifu.Charts.WinForms.ChartTypes.BunifuPieChart bunifuPieChart = new Bunifu.Charts.WinForms.ChartTypes.BunifuPieChart();
            /*
             * For this example we will use random numbers
             */
            var r = new Random();

            /*
             * Add your data from your source - accepts double list
             * Below is an example from a random number
             */
            List<double> data = new List<double>();

            for (int i = 0; i < 5; i++)
            {
                data.Add(r.Next(0, 50));

            }
            /*
             * Set your data             
             */
            bunifuPieChart.Data = data;

            /*
             * Specify the target canvas
             */
            bunifuPieChart.TargetCanvas = bunifuChartCanvas2;

            /*
             * Hide grid lines
             */
            bunifuChartCanvas2.XAxesGridLines = false;
            bunifuChartCanvas2.YAxesGridLines = false;

            /*
             * Add labels to your canvas
             * Label count should correspond to data count for charts like Bar charts
             */
            bunifuChartCanvas2.Labels = new string[] { "Label1", "Label2", "Label3", "Label4", "Label5" };


            /*
             * Beautify the chart by sepcifying the colors
             * Color count should correspond to data count
             */
            List<Color> bgColors = new List<Color>();
            for (int i = 0; i < data.Count; i++)
            {
                bgColors.Add(Color.FromArgb(r.Next(256), r.Next(256), r.Next(256)));
            }

            bunifuPieChart.BackgroundColor = bgColors;
        }

        public void showTable()
        {
             dataGridView1.DataSource = home.getDataList(new MySqlCommand("SELECT * FROM `sample_sales_records`"));
            //DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            //imageColumn = (DataGridViewImageColumn)dataGridView1.Columns[11];
            //imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

            //dataGridView1.AutoResizeColumns();
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
                panel_main.Controls.Add(dashboard_panel);

            button1.BackColor = Color.FromArgb(0, 0, 192);
            button2.BackColor = Color.FromArgb(0, 0, 64);
            button3.BackColor = Color.FromArgb(0, 0, 64);
            button4.BackColor = Color.FromArgb(0, 0, 64);
            button5.BackColor = Color.FromArgb(0, 0, 64);
            button6.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new Analysis());
            
            button1.BackColor = Color.FromArgb(0, 0, 64);
            button2.BackColor = Color.FromArgb(0, 0, 192);
            button3.BackColor = Color.FromArgb(0, 0, 64);
            button4.BackColor = Color.FromArgb(0, 0, 64);
            button5.BackColor = Color.FromArgb(0, 0, 64);
            button6.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuChartCanvas2_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new Report());

            button1.BackColor = Color.FromArgb(0, 0, 64);
            button2.BackColor = Color.FromArgb(0, 0, 64);
            button3.BackColor = Color.FromArgb(0, 0, 192);
            button4.BackColor = Color.FromArgb(0, 0, 64);
            button5.BackColor = Color.FromArgb(0, 0, 64);
            button6.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChildForm(new Users());

            button1.BackColor = Color.FromArgb(0, 0, 64);
            button2.BackColor = Color.FromArgb(0, 0, 64);
            button3.BackColor = Color.FromArgb(0, 0, 64);
            button4.BackColor = Color.FromArgb(0, 0, 192);
            button5.BackColor = Color.FromArgb(0, 0, 64);
            button6.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openChildForm(new Settings());

            button1.BackColor = Color.FromArgb(0, 0, 64);
            button2.BackColor = Color.FromArgb(0, 0, 64);
            button3.BackColor = Color.FromArgb(0, 0, 64);
            button4.BackColor = Color.FromArgb(0, 0, 64);
            button5.BackColor = Color.FromArgb(0, 0, 192);
            button6.BackColor = Color.FromArgb(0, 0, 64);
        }
    }
}

