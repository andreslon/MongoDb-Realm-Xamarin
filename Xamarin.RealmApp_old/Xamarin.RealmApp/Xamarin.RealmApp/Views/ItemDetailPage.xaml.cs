using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.RealmApp.ViewModels;

namespace Xamarin.RealmApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}