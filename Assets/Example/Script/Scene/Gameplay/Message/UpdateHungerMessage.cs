namespace Example.Scene.Gameplay.Message
{
    public struct UpdateHungerMessage
    {
        public float Hunger { get; private set; }
        public UpdateHungerMessage(float hunger)
        {
            Hunger = hunger;
        }
    }
}
