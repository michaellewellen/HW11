using Avalonia;
using Avalonia.Markup.Xaml;

namespace HW11.Avalonia
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
   }
}