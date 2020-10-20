using System;
using System.Collections.Generic;
using System.Text;

namespace Lecii.Pool {
    public interface IPool<T> {
        int Count { get; }
        int Max { get; }
        void Return(T entity);
        T Get();
    }

}
