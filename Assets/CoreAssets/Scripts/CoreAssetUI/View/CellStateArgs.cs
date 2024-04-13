namespace CoreAssetUI.View
{
    public struct CellStateArg
    {
        public int index;
        public string title;
        public bool isOn;

        public CellStateArg( int index, string title, bool isOn )
        {
            this.index = index;
            this.title = title;
            this.isOn = isOn;
        }
    }
}
