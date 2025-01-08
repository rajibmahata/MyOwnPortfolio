namespace MyOwnPortfolio.Services
{
    public class LayoutService
    {
        public event Action<Type> OnLayoutChanged;

        public void ChangeLayout(Type newLayout)
        {
            OnLayoutChanged?.Invoke(newLayout);

        }
    }
}
