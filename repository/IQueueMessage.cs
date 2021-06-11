namespace tempaastapi.repository {
    public interface IQueueMessage {
        void Post(string message);
    }
}