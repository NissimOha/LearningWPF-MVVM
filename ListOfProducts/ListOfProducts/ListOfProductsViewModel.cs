using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ListOfProducts
{
    // The ViewModel class.
    // Implements INotifyPropertyChanged to help DataBinding.
    public class ListOfProductsViewModel : INotifyPropertyChanged
    {
        // The Products property.
        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Products"));
            }
        }

        // Constructor
        public ListOfProductsViewModel()
        {
            // Create a new product service.
            service = new ListOfProductsModel();

            // initialize the command
            ShowProductsCommand = new RelayCommand(ShowProducts);
        }

        public void ShowProducts()
        {
            var productList = service.GetAllProducts();

            Products = new ObservableCollection<Product>(productList);
        }
        
        private ListOfProductsModel service;
        public event PropertyChangedEventHandler PropertyChanged;
        // Property for the Command. (RelayCommand is a helper class that wraps ICommand).
        public RelayCommand ShowProductsCommand { get; set; }
    }
}
