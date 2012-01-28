using System;
using System.Globalization;
using System.Reflection;

namespace fd.Base.Types
{
    /// <summary>A property info that can be used to pretend that a property is defined on a type when in fact it isn't.</summary>
    public class GetterSetterPropertyInfo : PropertyInfo
    {
        private readonly Type _declaringType;
        private readonly MethodInfo _getter;
        private readonly string _propertyName;
        private readonly Type _propertyType;
        private readonly MethodInfo _setter;

        /// <summary>Initializes a new instance of the <see cref="GetterSetterPropertyInfo" /> class.</summary>
        /// <param name="declaringType">The type this property pretends to be defined on.</param>
        /// <param name="propertyType">The type of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="getter">The getter.</param>
        /// <param name="setter">The setter.</param>
        public GetterSetterPropertyInfo(Type declaringType, Type propertyType, string propertyName, MethodInfo getter, MethodInfo setter)
        {
            if (declaringType == null)
                throw new ArgumentNullException("declaringType");
            if (propertyType == null)
                throw new ArgumentNullException("propertyType");
            if (propertyName == null)
                throw new ArgumentNullException("propertyName");
            if (getter == null && setter == null)
                throw new ArgumentException("At least one of the parameters setter and getter must be non-null.");

            _declaringType = declaringType;
            _propertyType = propertyType;
            _propertyName = propertyName;
            _getter = getter;
            _setter = setter;
        }

        /// <summary>Gets the attributes for this property.</summary>
        /// <returns><see cref="fd.Base.Types.GetterSetterPropertyInfo.Attributes" /> of this property.</returns>
        public override PropertyAttributes Attributes
        {
            get { return PropertyAttributes.None; }
        }

        /// <summary>Gets a value indicating whether the property can be read.</summary>
        /// <returns><see langword="true" /> if this property can be read; otherwise, false.</returns>
        public override bool CanRead
        {
            get { return _getter != null; }
        }

        /// <summary>Gets a value indicating whether the property can be written to.</summary>
        /// <returns><see langword="true" /> if this property can be written to; otherwise, false.</returns>
        public override bool CanWrite
        {
            get { return _setter != null; }
        }

        /// <summary>Gets the class that declares this member.</summary>
        /// <returns>The Type object for the class that declares this member.</returns>
        public override Type DeclaringType
        {
            get { return _declaringType; }
        }

        /// <summary>Gets a value that identifies a metadata element.</summary>
        /// <exception cref="InvalidOperationException">
        /// The current <see cref="T:System.Reflection.MemberInfo" /> represents an array method, such as Address, on an array type whose element type is a
        /// dynamic type that has not been completed. To get a metadata token in this case, pass the <see cref="MemberInfo" /> object to the
        /// <see cref="System.Reflection.Emit.ModuleBuilder" /> method; or use the <see cref="System.Reflection.Emit.ModuleBuilder" /> method to get the token
        /// directly, instead of using the <see cref="System.Reflection.Emit.ModuleBuilder" /> method to get a <see cref="MethodInfo" /> first.
        /// </exception>
        /// <returns>A value which, in combination with <see cref="System.Reflection.MemberInfo.Module" /> , uniquely identifies a metadata element.</returns>
        public override int MetadataToken
        {
            get { return Name.GetHashCode(); }
        }

        /// <summary>
        /// Gets the module in which the type that declares the member represented by the current <see cref="T:System.Reflection.MemberInfo" /> is defined.
        /// </summary>
        /// <exception cref="T:System.NotImplementedException">This method is not implemented.</exception>
        /// <returns>
        /// The <see cref="T:System.Reflection.Module" /> in which the type that declares the member represented by the current
        /// <see cref="T:System.Reflection.MemberInfo" /> is defined.
        /// </returns>
        public override Module Module
        {
            get { return _declaringType.Module; }
        }

        /// <summary>Gets the name of the current member.</summary>
        /// <returns>A <see cref="T:System.String" /> containing the name of this member.</returns>
        public override string Name
        {
            get { return _propertyName; }
        }

        /// <summary>Gets the type of this property.</summary>
        /// <returns>The type of this property.</returns>
        public override Type PropertyType
        {
            get { return _propertyType; }
        }

        /// <summary>Gets the class object that was used to obtain this instance of MemberInfo.</summary>
        /// <returns>The Type object through which this MemberInfo object was obtained.</returns>
        public override Type ReflectedType
        {
            get { return _declaringType; }
        }

        /// <summary>
        /// Returns an array whose elements reflect the <see langword="public" /> and, if specified, non-public get, set, and other accessors of the property
        /// reflected by the current instance.
        /// </summary>
        /// <param name="nonPublic">
        /// Indicates whether non-public methods should be returned in the MethodInfo array. <see langword="true" /> if non-public methods are to be included;
        /// otherwise, false.
        /// </param>
        /// <returns>
        /// An array of <see cref="T:System.Reflection.MethodInfo" /> objects whose elements reflect the get, set, and other accessors of the property reflected
        /// by the current instance. If <paramref name="nonPublic" /> is true, this array contains <see langword="public" /> and non-public get, set, and other
        /// accessors. If <paramref name="nonPublic" /> is false, this array contains only <see langword="public" /> get, set, and other accessors. If no
        /// accessors with the specified visibility are found, this method returns an array with zero (0) elements.
        /// </returns>
        public override MethodInfo[] GetAccessors(bool nonPublic)
        {
            if (_getter == null)
                return new[] { _setter };
            else if (_setter == null)
                return new[] { _getter };
            return new[] { _getter, _setter };
        }

        /// <summary>When overridden in a derived class, returns an array containing all the custom attributes.</summary>
        /// <param name="inherit">Specifies whether to search this member's inheritance chain to find the attributes.</param>
        /// <exception cref="T:System.InvalidOperationException">
        /// This member belongs to a type that is loaded into the reflection-only context. See How to: Load Assemblies into the Reflection-Only Context.
        /// </exception>
        /// <exception cref="T:System.TypeLoadException">A custom attribute type cannot be loaded.</exception>
        /// <returns>An array that contains all the custom attributes, or an array with zero elements if no attributes are defined.</returns>
        public override object[] GetCustomAttributes(bool inherit)
        {
            return new object[0];
        }

        /// <summary>When overridden in a derived class, returns an array of custom attributes identified by <see cref="T:System.Type" /> .</summary>
        /// <param name="attributeType">The type of attribute to search for. Only attributes that are assignable to this type are returned.</param>
        /// <param name="inherit">Specifies whether to search this member's inheritance chain to find the attributes.</param>
        /// <exception cref="T:System.TypeLoadException">A custom attribute type cannot be loaded.</exception>
        /// <exception cref="T:System.ArgumentNullException">If <paramref name="attributeType" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">
        /// This member belongs to a type that is loaded into the reflection-only context. See How to: Load Assemblies into the Reflection-Only Context.
        /// </exception>
        /// <returns>An array of custom attributes applied to this member, or an array with zero (0) elements if no attributes have been applied.</returns>
        public override object[] GetCustomAttributes(Type attributeType, bool inherit)
        {
            return new object[0];
        }

        /// <summary>When overridden in a derived class, returns the <see langword="public" /> or non-public get accessor for this property.</summary>
        /// <param name="nonPublic">
        /// Indicates whether a non-public get accessor should be returned. <see langword="true" /> if a non-public accessor is to be returned; otherwise,
        /// false.
        /// </param>
        /// <exception cref="T:System.Security.SecurityException">
        /// The requested method is non-public and the caller does not have <see cref="T:System.Security.Permissions.ReflectionPermission" /> to reflect on this
        /// non-public method.
        /// </exception>
        /// <returns>
        /// A MethodInfo object representing the get accessor for this property, if <paramref name="nonPublic" /> is true. Returns <see langword="null" /> if
        /// <paramref name="nonPublic" /> is <see langword="false" /> and the get accessor is non-public, or if <paramref name="nonPublic" /> is
        /// <see langword="true" /> but no get accessors exist.
        /// </returns>
        public override MethodInfo GetGetMethod(bool nonPublic)
        {
            return _getter;
        }

        /// <summary>When overridden in a derived class, returns an array of all the index parameters for the property.</summary>
        /// <returns>An array of type ParameterInfo containing the parameters for the indexes.</returns>
        public override ParameterInfo[] GetIndexParameters()
        {
            return new ParameterInfo[0];
        }

        /// <summary>When overridden in a derived class, returns the set accessor for this property.</summary>
        /// <param name="nonPublic">
        /// Indicates whether the accessor should be returned if it is non-public. <see langword="true" /> if a non-public accessor is to be returned;
        /// otherwise, false.
        /// </param>
        /// <exception cref="T:System.Security.SecurityException">
        /// The requested method is non-public and the caller does not have <see cref="T:System.Security.Permissions.ReflectionPermission" /> to reflect on this
        /// non-public method.
        /// </exception>
        /// <returns>
        /// Value Condition A <see cref="T:System.Reflection.MethodInfo" /> object representing the Set method for this property. The set accessor is
        /// public.-or- <paramref name="nonPublic" /> is <see langword="true" /> and the set accessor is non-public. <see langword="null" />
        /// <paramref name="nonPublic" /> is true, but the property is read-only.-or- <paramref name="nonPublic" /> is <see langword="false" /> and the set
        /// accessor is non-public.-or- There is no set accessor.
        /// </returns>
        public override MethodInfo GetSetMethod(bool nonPublic)
        {
            return _setter;
        }

        /// <summary>
        /// When overridden in a derived class, returns the value of a property having the specified binding, index, and
        /// <see cref="T:System.Globalization.CultureInfo" /> .
        /// </summary>
        /// <param name="obj">The object whose property value will be returned.</param>
        /// <param name="invokeAttr">
        /// The invocation attribute. This must be a bit flag from BindingFlags : InvokeMethod, CreateInstance, Static, GetField, SetField, GetProperty, or
        /// SetProperty. A suitable invocation attribute must be specified. If a <see langword="static" /> member is to be invoked, the Static flag of
        /// BindingFlags must be set.
        /// </param>
        /// <param name="binder">
        /// An object that enables the binding, coercion of argument types, invocation of members, and retrieval of MemberInfo objects via reflection. If
        /// <paramref name="binder" /> is null, the default binder is used.
        /// </param>
        /// <param name="index">Optional index values for indexed properties. This value should be <see langword="null" /> for non-indexed properties.</param>
        /// <param name="culture">
        /// The CultureInfo object that represents the culture for which the resource is to be localized. Note that if the resource is not localized for this
        /// culture, the CultureInfo.Parent method will be called successively in search of a match. If this value is null, the CultureInfo is obtained from the
        /// CultureInfo.CurrentUICulture property.
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        /// The <paramref name="index" /> array does not contain the type of arguments needed.-or- The property's get accessor is not found.
        /// </exception>
        /// <exception cref="T:System.Reflection.TargetException">
        /// The object does not match the target type, or a property is an instance property but <paramref name="obj" /> is null.
        /// </exception>
        /// <exception cref="T:System.Reflection.TargetParameterCountException">
        /// The number of parameters in <paramref name="index" /> does not match the number of parameters the indexed property takes.
        /// </exception>
        /// <exception cref="T:System.MethodAccessException">
        /// There was an illegal attempt to access a <see langword="private" /> or <see langword="protected" /> method inside a class.
        /// </exception>
        /// <exception cref="T:System.Reflection.TargetInvocationException">
        /// An error occurred while retrieving the property value. For example, an <paramref name="index" /> value specified for an indexed property is out of
        /// range. The <see cref="P:System.Exception.InnerException" /> property indicates the reason for the error.
        /// </exception>
        /// <returns>The property value for <paramref name="obj" /> .</returns>
        public override object GetValue(object obj, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture)
        {
            if (_getter != null)
                return _getter.Invoke(obj, null);
            throw new ArgumentException();
        }

        /// <summary>
        /// When overridden in a derived class, indicates whether one or more instance of <paramref name="attributeType" /> is applied to this member.
        /// </summary>
        /// <param name="attributeType">The Type object to which the custom attributes are applied.</param>
        /// <param name="inherit">Specifies whether to search this member's inheritance chain to find the attributes.</param>
        /// <returns><see langword="true" /> if one or more instance of <paramref name="attributeType" /> is applied to this member; otherwise false.</returns>
        public override bool IsDefined(Type attributeType, bool inherit)
        {
            return false;
        }

        /// <summary>When overridden in a derived class, sets the property <paramref name="value" /> for the given object to the given value.</summary>
        /// <param name="obj">The object whose property <paramref name="value" /> will be set.</param>
        /// <param name="value">The new value for this property.</param>
        /// <param name="invokeAttr">
        /// The invocation attribute. This must be a bit flag from <see cref="T:System.Reflection.BindingFlags" /> : InvokeMethod, CreateInstance, Static,
        /// GetField, SetField, GetProperty, or SetProperty. A suitable invocation attribute must be specified. If a <see langword="static" /> member is to be
        /// invoked, the Static flag of BindingFlags must be set.
        /// </param>
        /// <param name="binder">
        /// An object that enables the binding, coercion of argument types, invocation of members, and retrieval of
        /// <see cref="T:System.Reflection.MemberInfo" /> objects through reflection. If <paramref name="binder" /> is null, the default binder is used.
        /// </param>
        /// <param name="index">
        /// Optional index values for indexed properties. This <paramref name="value" /> should be <see langword="null" /> for non-indexed properties.
        /// </param>
        /// <param name="culture">
        /// The <see cref="T:System.Globalization.CultureInfo" /> object that represents the culture for which the resource is to be localized. Note that if the
        /// resource is not localized for this culture, the CultureInfo.Parent method will be called successively in search of a match. If this
        /// <paramref name="value" /> is null, the CultureInfo is obtained from the CultureInfo.CurrentUICulture property.
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        /// The <paramref name="index" /> array does not contain the type of arguments needed.-or- The property's set accessor is not found.
        /// </exception>
        /// <exception cref="T:System.Reflection.TargetException">
        /// The object does not match the target type, or a property is an instance property but <paramref name="obj" /> is null.
        /// </exception>
        /// <exception cref="T:System.Reflection.TargetParameterCountException">
        /// The number of parameters in <paramref name="index" /> does not match the number of parameters the indexed property takes.
        /// </exception>
        /// <exception cref="T:System.MethodAccessException">
        /// There was an illegal attempt to access a <see langword="private" /> or <see langword="protected" /> method inside a class.
        /// </exception>
        /// <exception cref="T:System.Reflection.TargetInvocationException">
        /// An error occurred while setting the property value. For example, an <paramref name="index" /> <paramref name="value" /> specified for an indexed
        /// property is out of range. The <see cref="P:System.Exception.InnerException" /> property indicates the reason for the error.
        /// </exception>
        public override void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture)
        {
            if (_setter != null)
                _setter.Invoke(obj, new[] { value });
            else
                throw new ArgumentException();
        }
    }
}
