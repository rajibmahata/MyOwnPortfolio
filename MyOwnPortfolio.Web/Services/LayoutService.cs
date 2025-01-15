using MyOwnPortfolio.Web.Components.Layout;

namespace MyOwnPortfolio.Web.Services
{
    public class LayoutService
    {
        public event Action<Type> OnLayoutChanged;

        public void ChangeLayout(Type newLayout)
        {
            OnLayoutChanged?.Invoke(newLayout);

        }
        public Type CurrentLayout { get; private set; } = typeof(MainLayout);

        public void SetLayout(Type layoutType)
        {
            CurrentLayout = layoutType;
        }
    }
}
