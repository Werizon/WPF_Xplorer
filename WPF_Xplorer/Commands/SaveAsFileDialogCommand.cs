﻿using Microsoft.Win32;
using WPF_Xplorer.Interfaces;
using WPF_Xplorer.Services;
using WPF_Xplorer.ViewModels;

namespace WPF_Xplorer.Commands
{
    public class SaveAsFileDialogCommand : BaseCommand
    {
        BookmarkUpdateViewModel bookmarkUpdateViewModel { get; set; }
        IMessageBox messageBox;

        public SaveAsFileDialogCommand(BookmarkUpdateViewModel bookmarkViewModel)
        {
            bookmarkUpdateViewModel = bookmarkViewModel;
            messageBox = new MessageBoxWrapper();
        }

        public override void Execute(object parameter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pdf file  (*.pdf) | *.pdf";
            if (saveFileDialog.ShowDialog() == true)
            {
                bookmarkUpdateViewModel.BookService.SaveBookmarks(saveFileDialog.FileName);
                messageBox.MessageBoxShow("Файл сохранен", "Ok");
            }
        }
    }
}
