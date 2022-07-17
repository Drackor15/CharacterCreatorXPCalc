using System.Windows;
using EdArcCharacterCreatorXPCalc.Model;
using EdArcCharacterCreatorXPCalc.ViewModel;

namespace EdArcCharacterCreatorXPCalc.View {
    /// <summary>
    /// Interaction logic for EditorWindow.xaml
    /// </summary>
    public partial class EditorWindow : Window {
        public EditorWindow(object character) {
            var editorViewModel = new EditorViewModel((Character)character);

            DataContext = editorViewModel;
            InitializeComponent();
        }
    }
}
