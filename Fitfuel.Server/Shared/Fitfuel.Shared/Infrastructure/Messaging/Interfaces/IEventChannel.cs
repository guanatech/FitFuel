using System.Threading.Channels;
using Fitfuel.Shared.Events;

namespace Fitfuel.Shared.Infrastructure.Messaging.Interfaces;

public interface IEventChannel
{
    ChannelReader<IEvent> Reader { get;}
    ChannelWriter<IEvent> Writer { get;}
}