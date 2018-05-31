using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TheProductiveFamily.Views
{
    public partial class HomeMasterDetailPage : MasterDetailPage
    {
        public HomeMasterDetailPage()
        {
            InitializeComponent();

            ToolbarItems.Add(new ToolbarItem() { Icon = "shopping_cart" });
        }
    }
}
