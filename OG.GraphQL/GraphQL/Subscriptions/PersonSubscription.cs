using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using OG.GraphQL.Application.Common.DTOs;

namespace OG.GraphQL.API.GraphQL.Subscriptions
{
    [ExtendObjectType(OperationTypeNames.Subscription)]
    public class PersonSubscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<PersonDTO>> OnPersonsChanges([Service] ITopicEventReceiver topicEventReceiver, CancellationToken cancellationToken)
            => await topicEventReceiver.SubscribeAsync<string, PersonDTO>("persons", cancellationToken);
    }
}
