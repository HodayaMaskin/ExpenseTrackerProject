using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp2.Views;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        NorthwindEntities _context = new NorthwindEntities();
        public List<City> CityProperty { get; set; }

        public List<City> HodayaProp { get; set; }

        public List<Revenue> HodayaRevenue { get; set; }
        public Home(NorthwindEntities context)
        {
           // HomeViewModel viewModel = new HomeViewModel();
            _context = context;
            InitializeComponent();
            SetChartsSourceData();
        }

        private void SetChartsSourceData()
        {
            HodayaProp = new List<City>();
            HodayaProp = _context.Cities.ToList();
            HodayaProp.Add(new City() { CityId = 5, NameCity = "TelAviv" });
            HodayaProp.Add(new City() { CityId = 5, NameCity = "Ashkelon" });
            HodayaRevenue = _context.Revenues.ToList();
            HodayaRevenue.Add(new Revenue() { Mounth = 1, Sum = 1000, UserId = 1 });
            HodayaRevenue.Add(new Revenue() { Mounth = 2, Sum = 3000, UserId = 1 });
            HodayaRevenue.Add(new Revenue() { Mounth = 3, Sum = 2500, UserId = 1 });
            HodayaRevenue.Add(new Revenue() { Mounth = 4, Sum = 1000, UserId = 1 });
            HodayaRevenue.Add(new Revenue() { Mounth = 5, Sum = 1800, UserId = 1 });
            HodayaRevenue.Add(new Revenue() { Mounth = 6, Sum = 2500, UserId = 1 });
            HodayaRevenue.Add(new Revenue() { Mounth = 7, Sum = 3400, UserId = 1 });
            HodayaRevenue.Add(new Revenue() { Mounth = 8, Sum = 1900, UserId = 1 });

            ChartSeries.ItemsSource = HodayaProp;
            DoughnutChart.ItemsSource = HodayaRevenue;
            column.ItemsSource = HodayaProp;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var homeWindow = new Home(_context);
            homeWindow.Show();
            this.Close();
        }

        private void Expense_Button_Click(object sender, RoutedEventArgs e)
        {
            var expensesWindow = new Expenses();
            expensesWindow.Show();
            this.Close();
        }
    }
}
