﻿using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestRevitApi
{
    /// <summary>
    /// Interaction logic for ListBoxColumn.xaml
    /// </summary>
    public partial class ListBoxColumn : Window
    {
        public ListBoxColumn(IList<FamilyData> listFamilyType)
        {
            InitializeComponent();
            listViewColumn.ItemsSource = listFamilyType;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listViewColumn.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("FamilyName");
            view.GroupDescriptions.Add(groupDescription);
            

        }
    }
}
