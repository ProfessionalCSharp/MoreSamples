using System;

namespace DynamicTabLib.Framework
{
    public sealed class SubscriptionToken : IEquatable<SubscriptionToken>, IDisposable
    {
        private readonly Guid _token;
        private Action<SubscriptionToken> _unsubscribeAction;

        public SubscriptionToken(Action<SubscriptionToken> unsubscribeAction)
        {
            _unsubscribeAction = unsubscribeAction;
            _token = Guid.NewGuid();
        }

        public bool Equals(SubscriptionToken other)
        {
            if (other == null) return false;
            return Equals(_token, other._token);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as SubscriptionToken);
        }

        public override int GetHashCode() => _token.GetHashCode();

        public void Dispose()
        {
            _unsubscribeAction?.Invoke(this);
            _unsubscribeAction = null;
        }
    }
}
