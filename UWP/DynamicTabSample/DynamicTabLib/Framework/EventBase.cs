using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DynamicTabLib.Framework
{
    public abstract class EventBase
    {
        private readonly object _subscriptionsLock = new object();
        private readonly List<IEventSubscription> _subscriptions = new List<IEventSubscription>();
        public SynchronizationContext SynchronizationContext { get; set; }

        protected ICollection<IEventSubscription> Subscriptions => _subscriptions;

        protected virtual SubscriptionToken InternalSubscribe(IEventSubscription eventSubscription)
        {
            if (eventSubscription == null) throw new ArgumentNullException(nameof(eventSubscription));

            eventSubscription.SubscriptionToken = new SubscriptionToken(Unsubscribe);

            lock (_subscriptionsLock)
            {
                Subscriptions.Add(eventSubscription);
            }
            return eventSubscription.SubscriptionToken;
        }

        protected virtual void InternalPublish(params object[] arguments)
        {
            List<Action<object[]>> executionStrategies = PruneAndReturnStrategies();
            foreach (var executionStrategy in executionStrategies)
            {
                executionStrategy(arguments);
            }
        }


        public virtual void Unsubscribe(SubscriptionToken token)
        {
            lock (_subscriptionsLock)
            {
                IEventSubscription subscription = Subscriptions.FirstOrDefault(evt => evt.SubscriptionToken == token);

                Subscriptions?.Remove(subscription);
            }
        }

        public virtual bool Contains(SubscriptionToken token)
        {
            lock (_subscriptionsLock)
            {
                IEventSubscription subscription = Subscriptions.FirstOrDefault(evt => evt.SubscriptionToken == token);
                return subscription != null;
            }
        }

        private List<Action<object[]>> PruneAndReturnStrategies()
        {
            var returnList = new List<Action<object[]>>();

            lock (_subscriptionsLock)
            {
                for (var i = Subscriptions.Count - 1; i >= 0; i--)
                {
                    Action<object[]> listItem =
                        _subscriptions[i].GetExecutionStrategy();

                    if (listItem == null)
                    {
                        // Prune from main list. Log?
                        _subscriptions.RemoveAt(i);
                    }
                    else
                    {
                        returnList.Add(listItem);
                    }
                }
            }

            return returnList;
        }
    }
}
