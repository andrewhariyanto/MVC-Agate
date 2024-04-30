namespace Example.Scene.Gameplay.Message
{
    public struct UpdateMoneyMessage
    {
        public float Money { get; private set; }
        public UpdateMoneyMessage(float money)
        {
            Money = money;
        }
    }
}
