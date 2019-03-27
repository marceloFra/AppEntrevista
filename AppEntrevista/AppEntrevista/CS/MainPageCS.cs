using System;
using Xamarin.Forms;

namespace AppEntrevista
{
    public class MainPageCS : MasterDetailPage
    {
        private MasterPageCS masterPage = new MasterPageCS();

        public MainPageCS()
        {
           
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MasterPageItem item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
