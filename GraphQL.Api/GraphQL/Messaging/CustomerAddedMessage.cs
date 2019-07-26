namespace GraphQL.Api.GraphQL.Messaging
{
    public class CustomerAddedMessage
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
