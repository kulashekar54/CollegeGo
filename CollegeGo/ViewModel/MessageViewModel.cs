using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CollegeGo.Model;

namespace CollegeGo.ViewModel
{
    public class MessageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MessageItem> Items { get; set; } = new();
        public ObservableCollection<int> SkeletonItems { get; set; } = new();

        private const int PageSize = 50;
        private const int MaxItems = 1000;
        private int _currentIndex = 0;

        private bool _isBusy;

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set { _isLoading = value; OnPropertyChanged(); }
        }

        public ICommand LoadMoreCommand { get; }

        public MessageViewModel()
        {
            // Create skeleton placeholders
            for (int i = 0; i < 10; i++)
                SkeletonItems.Add(i);

            LoadMoreCommand = new Command(async () => await LoadMoreData());

            LoadInitialData();
        }

        private async void LoadInitialData()
        {
            IsLoading = true;

            await Task.Delay(1000);

            await LoadMoreData();

            await Task.Delay(200);

            IsLoading = false;
        }

        public async Task LoadMoreData()
        {
            if (_currentIndex >= MaxItems || _isBusy)
                return;

            _isBusy = true;

            await Task.Delay(500); 

            var newItems = new List<MessageItem>();

            for (int i = 0; i < PageSize; i++)
            {
                if (_currentIndex >= MaxItems) break;

                newItems.Add(new MessageItem
                {
                    Name = $"User {_currentIndex}",
                    Email = $"user{_currentIndex}@gmail.com",
                    MobileNumber = $"+91 98765{_currentIndex:D4}",
                    Duration = TimeSpan.FromMinutes(_currentIndex % 60),
                    Time = DateTime.Now.AddMinutes(-_currentIndex)
                });

                _currentIndex++;
            }

            foreach (var item in newItems)
                Items.Add(item);

            _isBusy = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
    
}

