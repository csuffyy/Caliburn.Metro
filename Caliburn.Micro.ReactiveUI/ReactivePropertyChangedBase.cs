using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Caliburn.Micro;
using ReactiveUI;

namespace Caliburn.ReactiveUI
{
    public class ReactivePropertyChangedBase : ReactiveObject, INotifyPropertyChangedEx
    {
        public bool IsNotifying
        {
            get { return AreChangeNotificationsEnabled(); }
            set { throw new NotSupportedException(); }
        }

        /// <summary>
        /// Notifies subscribers of the property change.
        /// </summary>
        /// <typeparam name = "TProperty">The type of the property.</typeparam>
        /// <param name = "property">The property expression.</param>
        public virtual void NotifyOfPropertyChange<TProperty>(Expression<Func<TProperty>> property)
        {
            NotifyOfPropertyChange(ExpressionExtensions.GetMemberInfo(property).Name);
        }

        /// <summary>
        /// Notifies subscribers of the property change.
        /// </summary>
        /// <param name = "propertyName">Name of the property.</param>
        public virtual void NotifyOfPropertyChange([CallerMemberName] string propertyName = null)
        {
            this.RaisePropertyChanged(propertyName);
        }

        public void Refresh()
        {
            NotifyOfPropertyChange(string.Empty);
        }
    }
}
