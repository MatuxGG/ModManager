namespace ModManager
{
    internal class Mod
    {
        private string id;
        private string name;

        public Mod(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public string getId()
        {
            return this.id;
        }
        public string getName()
        {
            return this.name;
        }
    }
}