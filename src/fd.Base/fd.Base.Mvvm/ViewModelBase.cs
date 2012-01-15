using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using fd.Base.Common;

namespace fd.Base.Mvvm
{
    /// <summary>
    ///   The base class for all ViewModels.
    /// </summary>
    public abstract class ViewModelBase : GalaSoft.MvvmLight.ViewModelBase
    {
        /// <summary>
        ///   Raises the <see cref="INotifyPropertyChanged.PropertyChanged" /> event for the specified property.
        /// </summary>
        /// <typeparam name="TProperty"> The type of the property for which the event should be raised. </typeparam>
        /// <param name="propertyName"> The name of the property for which the event should be raised. </param>
        /// <param name="oldValue"> The old value of the property. </param>
        /// <param name="newValue"> The new value of the property. </param>
        protected virtual void RaisePropertyChanged<TProperty>(string propertyName, TProperty oldValue, TProperty newValue)
        {
            RaisePropertyChanged(propertyName, oldValue, newValue, true);
        }

        /// <summary>
        ///   Raises the <see cref="INotifyPropertyChanged.PropertyChanged" /> event for the specified property.
        /// </summary>
        /// <typeparam name="TProperty"> The type of the property for which the event should be raised. </typeparam>
        /// <param name="propertyExpression"> The expression that contains the name of the property for which the event should be raised. </param>
        /// <param name="oldValue"> The old value of the property. </param>
        /// <param name="newValue"> The new value of the property. </param>
        protected virtual void RaisePropertyChanged<TProperty>(Expression<Func<TProperty>> propertyExpression, TProperty oldValue, TProperty newValue)
        {
            RaisePropertyChanged(ExpressionsHelper.GetPropertyName(propertyExpression), oldValue, newValue, true);
        }

        /// <summary>
        ///   Sets the value of and raises the <see cref="INotifyPropertyChanged.PropertyChanged" /> event for the specified property.
        /// </summary>
        /// <typeparam name="TProperty"> The type of the property for which the event should be raised. </typeparam>
        /// <param name="propertyExpression"> The expression that contains the name of the property for which the event should be raised. </param>
        /// <param name="field"> The backing field of the property. The new value will be assigned to this field. </param>
        /// <param name="newValue"> The new value of the property. </param>
        protected void SetValueAndRaisePropertyChanged<TProperty>(Expression<Func<TProperty>> propertyExpression, ref TProperty field, TProperty newValue)
        {
            SetValueAndRaisePropertyChanged(ExpressionsHelper.GetPropertyInfo(propertyExpression), ref field, newValue);
        }

        /// <summary>
        ///   Sets the value of and raises the <see cref="INotifyPropertyChanged.PropertyChanged" /> event for the specified property.
        /// </summary>
        /// <typeparam name="TProperty"> The type of the property for which the event should be raised. </typeparam>
        /// <param name="propertyInfo"> The <see cref="PropertyInfo" /> that represents the property for which the event should be raised. </param>
        /// <param name="field"> The backing field of the property. The new value will be assigned to this field. </param>
        /// <param name="newValue"> The new value of the property. </param>
        protected virtual void SetValueAndRaisePropertyChanged<TProperty>(PropertyInfo propertyInfo, ref TProperty field, TProperty newValue)
        {
            var oldValue = field;
            field = newValue;

            RaisePropertyChanged(propertyInfo.Name, oldValue, newValue, true);
        }
    }
}
