namespace DelegatesEventsHomework
{
    public class ExampleModel
    {
        public float ElementVal { get; set; }

        public override string ToString()
        {
            return System.Text.Json.JsonSerializer.Serialize(this);
        }
    }
}
