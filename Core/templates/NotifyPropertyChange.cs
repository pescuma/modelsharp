﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 10.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace org.pescuma.ModelSharp.Core.templates
{
    using System.Linq;
    using org.pescuma.ModelSharp.Core.model;
    using System;
    
    
    #line 1 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "10.0.0.0")]
    public partial class NotifyPropertyChange : TemplateUtils
    {
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
        public override string TransformText()
        {
            this.GenerationEnvironment = null;
            
            #line 6 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
	if (!it.BaseClass.HasPropertyChange(type)) { 
            
            #line default
            #line hidden
            this.Write("\t\tpublic event Property");
            
            #line 7 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(type));
            
            #line default
            #line hidden
            this.Write("EventHandler Property");
            
            #line 7 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(type));
            
            #line default
            #line hidden
            this.Write(";\r\n\r\n\t\tprotected virtual void NotifyProperty");
            
            #line 9 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(type));
            
            #line default
            #line hidden
            this.Write("(string propertyName)\r\n\t\t{\r\n");
            
            #line 11 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
		if (type == "Changed") { 
            
            #line default
            #line hidden
            
            #line 12 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
			ForEach("InvalidateComputedDependenciesCache", it.PropertiesWithCachedComputedDependencies); 
            
            #line default
            #line hidden
            
            #line 13 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
			ForEach("InvalidateComputedProperty", it.CachedComputedProperties); 
            
            #line default
            #line hidden
            
            #line 14 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
			if (it.HasCachedComputedProperties) { 
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 16 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
			} 
            
            #line default
            #line hidden
            
            #line 17 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
		} 
            
            #line default
            #line hidden
            this.Write("\t\t\tProperty");
            
            #line 18 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(type));
            
            #line default
            #line hidden
            this.Write("EventHandler handler = Property");
            
            #line 18 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(type));
            
            #line default
            #line hidden
            this.Write(";\r\n\t\t\tif (handler != null)\r\n\t\t\t\thandler(this, new Property");
            
            #line 20 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(type));
            
            #line default
            #line hidden
            this.Write("EventArgs(propertyName));\r\n");
            
            #line 21 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
		ForEach("NotifyDependenciesChange", it.PropertiesWithDependencies, "", "type", type); 
            
            #line default
            #line hidden
            this.Write("\t\t}\r\n\r\n");
            
            #line 24 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
	} else if (it.PropertiesWithDependencies.Count > 0) { 
            
            #line default
            #line hidden
            this.Write("\t\tprotected override void NotifyProperty");
            
            #line 25 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(type));
            
            #line default
            #line hidden
            this.Write("(string propertyName)\r\n\t\t{\r\n");
            
            #line 27 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
		if (type == "Changed") { 
            
            #line default
            #line hidden
            
            #line 28 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
			ForEach("InvalidateComputedDependenciesCache", it.PropertiesWithCachedComputedDependencies); 
            
            #line default
            #line hidden
            
            #line 29 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
			ForEach("InvalidateComputedProperty", it.CachedComputedProperties); 
            
            #line default
            #line hidden
            
            #line 30 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
			if (it.HasCachedComputedProperties) { 
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 32 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
			} 
            
            #line default
            #line hidden
            
            #line 33 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
		} 
            
            #line default
            #line hidden
            this.Write("\t\t\tbase.NotifyProperty");
            
            #line 34 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(type));
            
            #line default
            #line hidden
            this.Write("(propertyName);\r\n");
            
            #line 35 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
		ForEach("NotifyDependenciesChange", it.PropertiesWithDependencies, "", "type", type); 
            
            #line default
            #line hidden
            this.Write("\t\t}\r\n\r\n");
            
            #line 38 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
	} 
            
            #line default
            #line hidden
            
            #line 39 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
	if (!it.BaseClass.HasChildPropertyChange(type)) { 
            
            #line default
            #line hidden
            this.Write("\t\tpublic event ChildProperty");
            
            #line 40 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(type));
            
            #line default
            #line hidden
            this.Write("EventHandler ChildProperty");
            
            #line 40 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(type));
            
            #line default
            #line hidden
            this.Write(";\r\n\t\t\r\n\t\tprotected virtual void NotifyChildProperty");
            
            #line 42 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(type));
            
            #line default
            #line hidden
            this.Write("(string propertyName, object sender, Property");
            
            #line 42 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(type));
            
            #line default
            #line hidden
            this.Write("EventArgs e)\r\n\t\t{\r\n");
            
            #line 44 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
		if (type == "Changed") { 
            
            #line default
            #line hidden
            
            #line 45 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
			ForEach("InvalidateChildComputedDependenciesCache", it.PropertiesWithCachedComputedDependenciesOnChildren, "", "type", type); 
            
            #line default
            #line hidden
            
            #line 46 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
			if (it.PropertiesWithCachedComputedDependencies.Count() > 0) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\r\n");
            
            #line 48 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
			} 
            
            #line default
            #line hidden
            
            #line 49 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
		} 
            
            #line default
            #line hidden
            this.Write("\t\t\tChildProperty");
            
            #line 50 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(type));
            
            #line default
            #line hidden
            this.Write("EventHandler handler = ChildProperty");
            
            #line 50 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(type));
            
            #line default
            #line hidden
            this.Write(";\r\n\t\t\tif (handler != null)\r\n\t\t\t\thandler(sender, new ChildProperty");
            
            #line 52 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(type));
            
            #line default
            #line hidden
            this.Write("EventArgs(this, propertyName, sender, e));\r\n");
            
            #line 53 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
		ForEach("NotifyChildDependenciesChange", it.PropertiesWithDependenciesOnChildren, "", "type", type); 
            
            #line default
            #line hidden
            this.Write("\t\t}\r\n\r\n");
            
            #line 56 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
	} else if (it.PropertiesWithDependencies.Count > 0) { 
            
            #line default
            #line hidden
            this.Write("\t\tprotected override void NotifyChildProperty");
            
            #line 57 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(type));
            
            #line default
            #line hidden
            this.Write("(string propertyName, object sender, Property");
            
            #line 57 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(type));
            
            #line default
            #line hidden
            this.Write("EventArgs e)\r\n\t\t{\r\n");
            
            #line 59 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
		if (type == "Changed") { 
            
            #line default
            #line hidden
            
            #line 60 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
			ForEach("InvalidateChildComputedDependenciesCache", it.PropertiesWithCachedComputedDependenciesOnChildren, "", "type", type); 
            
            #line default
            #line hidden
            
            #line 61 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
			if (it.PropertiesWithCachedComputedDependencies.Count() > 0) { 
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 63 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
			} 
            
            #line default
            #line hidden
            
            #line 64 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
		} 
            
            #line default
            #line hidden
            this.Write("\t\t\tbase.NotifyChildProperty");
            
            #line 65 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(type));
            
            #line default
            #line hidden
            this.Write("(propertyName, sender, e);\r\n");
            
            #line 66 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
		ForEach("NotifyChildDependenciesChange", it.PropertiesWithDependenciesOnChildren, "", "type", type); 
            
            #line default
            #line hidden
            this.Write("\t\t}\r\n\r\n");
            
            #line 69 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"
	} 
            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "X:\c#\modelsharp\Core\templates\NotifyPropertyChange.tt"

private global::org.pescuma.ModelSharp.Core.model.TypeInfo _itField;

/// <summary>
/// Access the it parameter of the template.
/// </summary>
private global::org.pescuma.ModelSharp.Core.model.TypeInfo it
{
    get
    {
        return this._itField;
    }
}

private string _typeField;

/// <summary>
/// Access the type parameter of the template.
/// </summary>
private string type
{
    get
    {
        return this._typeField;
    }
}


public override void Initialize()
{
    base.Initialize();
    if ((this.Errors.HasErrors == false))
    {
bool itValueAcquired = false;
if (this.Session.ContainsKey("it"))
{
    if ((typeof(global::org.pescuma.ModelSharp.Core.model.TypeInfo).IsAssignableFrom(this.Session["it"].GetType()) == false))
    {
        this.Error("The type \'org.pescuma.ModelSharp.Core.model.TypeInfo\' of the parameter \'it\' did n" +
                "ot match the type of the data passed to the template.");
    }
    else
    {
        this._itField = ((global::org.pescuma.ModelSharp.Core.model.TypeInfo)(this.Session["it"]));
        itValueAcquired = true;
    }
}
if ((itValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("it");
    if ((data != null))
    {
        if ((typeof(global::org.pescuma.ModelSharp.Core.model.TypeInfo).IsAssignableFrom(data.GetType()) == false))
        {
            this.Error("The type \'org.pescuma.ModelSharp.Core.model.TypeInfo\' of the parameter \'it\' did n" +
                    "ot match the type of the data passed to the template.");
        }
        else
        {
            this._itField = ((global::org.pescuma.ModelSharp.Core.model.TypeInfo)(data));
        }
    }
}
bool typeValueAcquired = false;
if (this.Session.ContainsKey("type"))
{
    if ((typeof(string).IsAssignableFrom(this.Session["type"].GetType()) == false))
    {
        this.Error("The type \'System.String\' of the parameter \'type\' did not match the type of the da" +
                "ta passed to the template.");
    }
    else
    {
        this._typeField = ((string)(this.Session["type"]));
        typeValueAcquired = true;
    }
}
if ((typeValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("type");
    if ((data != null))
    {
        if ((typeof(string).IsAssignableFrom(data.GetType()) == false))
        {
            this.Error("The type \'System.String\' of the parameter \'type\' did not match the type of the da" +
                    "ta passed to the template.");
        }
        else
        {
            this._typeField = ((string)(data));
        }
    }
}


    }
}


        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
}
