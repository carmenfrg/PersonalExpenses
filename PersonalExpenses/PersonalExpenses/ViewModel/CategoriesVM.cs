using PCLStorage;
using PersonalExpenses.Model;
using PersonalExpenses.ViewModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PersonalExpenses.ViewModel
{
    class CategoriesVM : INotifyPropertyChanged
    {
        public ICommand DownloadCategoriesCommand { get; set; }

        public class Progress
        {
            public string Name { get; set; }
            public double ProgressValue { get; set; }
        }

        private bool hasProgress;

        public bool HasProgress
        {
            get { return hasProgress; }
            set { hasProgress = value; OnPropertyChanged("HasProgress"); }
        }

        public ObservableCollection<Progress> Progresses { get; set; }

        public CategoriesVM()
        {
            HasProgress = false;

            Progresses = new ObservableCollection<Progress>();
            DownloadCategoriesCommand = new Command<bool>(ListCategories, ShareCommandCanExecute);
            //GetProgress();
        }

        
        private bool ShareCommandCanExecute(bool arg)
        {
            return arg;
        }

        public async void ListCategories(bool obj)
        {
            IFileSystem fileSystem = FileSystem.Current;
            var rootFolder = fileSystem.LocalStorage;
            var reportsFolder = await rootFolder.CreateFolderAsync("reports", CreationCollisionOption.OpenIfExists);
            var reportFile = await reportsFolder.CreateFileAsync("report.txt", CreationCollisionOption.ReplaceExisting);

            using(StreamWriter sw = new StreamWriter(reportFile.Path))
            {
                foreach (var progress in Progresses)
                {
                    sw.WriteLine($"{progress.Name} - {progress.ProgressValue:p}");
                }
            }

            IShare shareDependency = DependencyService.Get<IShare>();
            await shareDependency.Show("Reporte de Gastos", "Reporte de gastos por categoria", reportFile.Path);

        }


        public void GetProgress()
        {
            var categories = Category.GetCategories();
            var expenses = Expense.GetExpenses();

            double totalExpenses = expenses.Sum(e => e.Amount);
            Progresses.Clear();
            foreach (var category in categories)
            {
                var totalAmount = expenses.Where(x => x.Category == category).Sum(e => e.Amount);
                Progresses.Add(new Progress() { Name = category, ProgressValue = totalAmount / totalExpenses });
            }

            HasProgress = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
