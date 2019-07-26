using GraphQL.Api.Data.Entities;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace GraphQL.Api.GraphQL.Messaging
{
    public class CustomerMessageService
    {
        private readonly ISubject<CustomerAddedMessage> _messageStream = new ReplaySubject<CustomerAddedMessage>(1);

        public CustomerAddedMessage AddCustomerAddedMessage(Customer customer)
        {
            var message = new CustomerAddedMessage
            {
                CustomerId = customer.Id,
                Name = customer.Name,
                Surname = customer.Surname
            };
            _messageStream.OnNext(message);
            return message;
        }

        public IObservable<CustomerAddedMessage> GetMessages()
        {
            return _messageStream.AsObservable();
        }
    }
}
