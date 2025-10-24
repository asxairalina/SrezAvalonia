using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Threading.Tasks;

namespace Srez1.Views
{
    public partial class ConfirmationDialog : Window
    {
        public ConfirmationDialog()
        {
            InitializeComponent();
            DataContext = this;
        }

        public ConfirmationDialog(string title, string message, string details = "") : this()
        {
            Title = title; // Устанавливаем напрямую свойство Title окна
            DialogMessage = message;
            DialogDetails = details;
        }

        // Свойство для основного сообщения
        public static readonly StyledProperty<string> DialogMessageProperty =
            AvaloniaProperty.Register<ConfirmationDialog, string>(nameof(DialogMessage), "Вы уверены, что хотите выполнить это действие?");

        public string DialogMessage
        {
            get => GetValue(DialogMessageProperty);
            set => SetValue(DialogMessageProperty, value);
        }

        // Свойство для дополнительных деталей
        public static readonly StyledProperty<string> DialogDetailsProperty =
            AvaloniaProperty.Register<ConfirmationDialog, string>(nameof(DialogDetails));

        public string DialogDetails
        {
            get => GetValue(DialogDetailsProperty);
            set => SetValue(DialogDetailsProperty, value);
        }

        // Метод для удобного вызова диалога
        public static async Task<bool> Show(Window parent, string title, string message, string details = "")
        {
            var dialog = new ConfirmationDialog
            {
                Title = title,
                DialogMessage = message,
                DialogDetails = details
            };
            var result = await dialog.ShowDialog<bool?>(parent);
            return result == true;
        }

        // Статический метод для диалога удаления
        public static async Task<bool> ShowDeleteConfirmation(Window parent, string itemName = "этот элемент", string details = "")
        {
            return await Show(
                parent,
                "Подтверждение удаления",
                $"Вы уверены, что хотите удалить {itemName}?",
                details
            );
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            Close(false);
        }

        private void ConfirmClick(object sender, RoutedEventArgs e)
        {
            Close(true);
        }
    }
}