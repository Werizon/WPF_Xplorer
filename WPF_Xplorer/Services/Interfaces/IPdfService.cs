﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF_Xplorer.Services.Interfaces
{
    public interface IPdfService
    {
        void GetDocumentNode(string path, TreeView ancestor);
        void AddCatalogNode(TreeViewItem ancestor);
        void AddInfoNode(TreeViewItem ancestor);
        void AddInfoStrings(TreeViewItem ancestor);
        void AddKidNodes(TreeViewItem ancestor);
        //TODO: test
        ObservableCollection<StringBuilder> GetGridListItemKey();
    }
}
