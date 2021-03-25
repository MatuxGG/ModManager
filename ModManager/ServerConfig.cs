namespace ModManager
{
    public class ServerConfig
    {
        public bool enabled;
        public bool texturesEnabled;
        public bool serversEnabled;
        

        public ServerConfig(bool enabled, bool texturesEnabled, bool serversEnabled)
        {
            this.enabled = enabled;
            this.texturesEnabled = texturesEnabled;
            this.serversEnabled = serversEnabled;
        }
    }
}