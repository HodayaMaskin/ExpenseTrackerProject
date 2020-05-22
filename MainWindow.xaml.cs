using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NorthwindEntities context = new NorthwindEntities();
        public MainWindow()
        {
            InitializeComponent();

            var listCity = from p in context.Cities select p.NameCity;
            ObservableCollection<string> cities = new ObservableCollection<string>(listCity);
            lstCities.DataContext = cities;

            var listStatus = from p in context.Status select p.NameStatus;
            ObservableCollection<string> status = new ObservableCollection<string>(listStatus);
            lstStatus.DataContext = status;
        }

        private void connect_Click(object sender, RoutedEventArgs e)
        {
            

            //if (int.Parse(personalIDTextBox.Text) != 0) 
                if (personalIDTextBox.Text==null || personalIDTextBox.Text=="")
                {
                var list = from p in context.Personals select p;
                ObservableCollection<Personal> personals = new ObservableCollection<Personal>(list);
                Personal personal = new Personal();
                foreach (var per in personals)
                {
                    if (per.UserID == int.Parse(personalIDTextBox.Text))
                    {
                        MessageBox.Show("personal ID is valid");
                        //var newForm = new MainPersonal(per); //create your new form.
                        ////var newForm = new MainPerson(int.Parse(personalIDTextBox.Text)); //create your new form.
                        //newForm.Show(); //show the new form
                    }
                }
            }
            else
            {
                //
                MessageBox.Show("personal ID is not valid");
            }

            MainPersonal newForm = new MainPersonal(); //create your new form.
            this.Hide();
            newForm.Show(); //show the new form

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            NorthwindEntities context = new NorthwindEntities();

            //if (int.Parse(personalIDTextBox.Text) != 0) 
            if (personalIDTextBox.Text != null && personalIDTextBox.Text != "")
            {
                var list = from p in context.Personals select p;
                ObservableCollection<Personal> personals = new ObservableCollection<Personal>(list);
                Personal personal = new Personal();
                foreach (var per in personals)
                {
                    if (per.UserID == int.Parse(personalIDTextBox.Text))
                    {
                        MessageBox.Show("personal ID is exit");
                        //var newForm = new MainPersonal(per); //create your new form.
                        ////var newForm = new MainPerson(int.Parse(personalIDTextBox.Text)); //create your new form.
                        //newForm.Show(); //show the new form
                    }
                    else
                    {
                        //personal.UserID
                        //personal.FirstName
                        //personal.LastName
                        //personal.Gender
                        //personal.Status
                        //personal.CityId
                        //personal.Age
                        //personal.Children
                       
                        //context.Expenses.Add(expense);
                        context.SaveChanges();
                        context.SaveChanges();

                        // Refresh the grids so the database generated values show up.
                        //this.p.Items.Refresh();
                        //this.productsDataGrid.Items.Refresh();
                    }
                }
            }
            else
            {
                //
                MessageBox.Show("personal ID is not valid");
            }

            MainPersonal newForm = new MainPersonal(); //create your new form.
            this.Hide();
            newForm.Show(); //show the new form

        }

        private void RadioButton_Checked_Exist(object sender, RoutedEventArgs e)
        {
            radioExit.IsChecked = true;
            radioNew.IsChecked = false;
        }

        private void Hodaya_Click(object sender, RoutedEventArgs e)
        {
            var homeWindow = new Home(context);
            homeWindow.Show();
            this.Close();
        }
    }
}
