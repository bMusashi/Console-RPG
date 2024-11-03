namespace Console_RPG.Items
{
    internal abstract class Item
    {
        internal string Name { get; set; }
        internal string Description { get; set; }
        internal Item()
        {

        }
        internal abstract void ItemDescription();        
    }
}
