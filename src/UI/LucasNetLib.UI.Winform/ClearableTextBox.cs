using System.ComponentModel;

namespace LucasNetLib.UI.Winform
{
    [DefaultEvent(nameof(TextChanged))]
    public partial class ClearableTextBox : UserControl
    {
        public ClearableTextBox()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        public new event EventHandler? TextChanged
        {
            add => txtValue.TextChanged += value;
            remove => txtValue.TextChanged -= value;
        }

        [Browsable(true)]
        public new string Text
        {
            get => txtValue.Text;
            set => txtValue.Text = value;
        }

        [Browsable(true)]
        public string Title
        {
            get => lblTitle.Text;
            set => lblTitle.Text = value;
        }

        private void btnClear_Click(object sender, EventArgs e) =>
            Text = "";
    }
}
