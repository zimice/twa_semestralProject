namespace Ppt23
{
    public class SharedStateService
    {
        public bool SharedVariable { get; private set; }

        public event Action OnChange;

        public void SetSharedVariable(bool value)
        {
            SharedVariable = value;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }

}