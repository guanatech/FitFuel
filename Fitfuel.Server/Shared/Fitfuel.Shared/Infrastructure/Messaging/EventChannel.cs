using System.Threading.Channels;
using Fitfuel.Shared.Events;
using Fitfuel.Shared.Infrastructure.Messaging.Interfaces;

namespace Fitfuel.Shared.Infrastructure.Messaging;

public class EventChannel : IEventChannel
{
    private readonly Channel<IEvent> _messages = Channel.CreateUnbounded<IEvent>();

    public ChannelReader<IEvent> Reader => _messages.Reader;
    public ChannelWriter<IEvent> Writer => _messages.Writer;
}