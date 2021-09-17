namespace Project.Saving
{
    [System.Serializable]
    public class SaveDataLevel
    {
        public bool WasCompleted = false;
        public bool DiamondWasCollected = false;

        public SaveDataLevel() { }

        public SaveDataLevel(bool wasCompleted, bool diamondWasCollected)
        {
            WasCompleted = wasCompleted;
            DiamondWasCollected = diamondWasCollected;
        }
    }
}
