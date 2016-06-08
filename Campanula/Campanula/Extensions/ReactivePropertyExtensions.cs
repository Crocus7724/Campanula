using System;
using Reactive.Bindings;
using StatefulModel;

namespace Campanula.Extensions
{
    public static class ReactivePropertyExtensions
    {
        public static ReadOnlyReactiveCollection<U> ToReadOnlyReactiveCollection<T, U>(
            this ObservableSynchronizedCollection<T> self, Func<T, U> converter = null)
            => self
                .ToReadOnlyReactiveCollection(self.ToCollectionChanged<T>(),
                    converter,
                    null);
    }
}