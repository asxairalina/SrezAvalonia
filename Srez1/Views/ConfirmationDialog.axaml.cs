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
            Title = title; // ������������� �������� �������� Title ����
            DialogMessage = message;
            DialogDetails = details;
        }

        // �������� ��� ��������� ���������
        public static readonly StyledProperty<string> DialogMessageProperty =
            AvaloniaProperty.Register<ConfirmationDialog, string>(nameof(DialogMessage), "�� �������, ��� ������ ��������� ��� ��������?");

        public string DialogMessage
        {
            get => GetValue(DialogMessageProperty);
            set => SetValue(DialogMessageProperty, value);
        }

        // �������� ��� �������������� �������
        public static readonly StyledProperty<string> DialogDetailsProperty =
            AvaloniaProperty.Register<ConfirmationDialog, string>(nameof(DialogDetails));

        public string DialogDetails
        {
            get => GetValue(DialogDetailsProperty);
            set => SetValue(DialogDetailsProperty, value);
        }

        // ����� ��� �������� ������ �������
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

        // ����������� ����� ��� ������� ��������
        public static async Task<bool> ShowDeleteConfirmation(Window parent, string itemName = "���� �������", string details = "")
        {
            return await Show(
                parent,
                "������������� ��������",
                $"�� �������, ��� ������ ������� {itemName}?",
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