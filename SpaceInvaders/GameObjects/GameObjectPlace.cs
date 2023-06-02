namespace SpaceInvaders
{
    class GameObjectPlace
    {
        public int XCoordination
        {
            get; set;
        }

        public int YCoordination
        {
            get; set;
        }

        public override bool Equals(object? obj)
        {
            GameObjectPlace newObj = obj as GameObjectPlace;
            if (newObj != null && this.YCoordination == newObj.YCoordination && this.XCoordination == newObj.XCoordination)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
