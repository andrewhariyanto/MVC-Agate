namespace Example.Scene.Gameplay.Message
{
    public struct UpdateEnergyMessage
    {
        public float Energy { get; private set; }
        public UpdateEnergyMessage(float energy)
        {
            Energy = energy;
        }
    }
}
