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
    using org.pescuma.ModelSharp.Core.model;
    using System;
    
    
    #line 1 "X:\c#\modelsharp\Core\templates\InvalidateComputedProperty.tt"
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "10.0.0.0")]
    public partial class InvalidateComputedProperty : TemplateUtils
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
            this.Write("\t\t\t");
            
            #line 5 "X:\c#\modelsharp\Core\templates\InvalidateComputedProperty.tt"
 if (index > 0) { 
            
            #line default
            #line hidden
            this.Write("else ");
            
            #line 5 "X:\c#\modelsharp\Core\templates\InvalidateComputedProperty.tt"
 } 
            
            #line default
            #line hidden
            this.Write("if (propertyName == ModelUtils.NameOfProperty(() => ");
            
            #line 5 "X:\c#\modelsharp\Core\templates\InvalidateComputedProperty.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.Name));
            
            #line default
            #line hidden
            this.Write("))\r\n\t\t\t{\r\n\t\t\t\t");
            
            #line 7 "X:\c#\modelsharp\Core\templates\InvalidateComputedProperty.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.Invalidate.Name));
            
            #line default
            #line hidden
            this.Write("();\r\n\t\t\t}\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "X:\c#\modelsharp\Core\templates\InvalidateComputedProperty.tt"

private global::org.pescuma.ModelSharp.Core.model.ComputedPropertyInfo _itField;

/// <summary>
/// Access the it parameter of the template.
/// </summary>
private global::org.pescuma.ModelSharp.Core.model.ComputedPropertyInfo it
{
    get
    {
        return this._itField;
    }
}

private int _indexField;

/// <summary>
/// Access the index parameter of the template.
/// </summary>
private int index
{
    get
    {
        return this._indexField;
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
    if ((typeof(global::org.pescuma.ModelSharp.Core.model.ComputedPropertyInfo).IsAssignableFrom(this.Session["it"].GetType()) == false))
    {
        this.Error("The type \'org.pescuma.ModelSharp.Core.model.ComputedPropertyInfo\' of the paramete" +
                "r \'it\' did not match the type of the data passed to the template.");
    }
    else
    {
        this._itField = ((global::org.pescuma.ModelSharp.Core.model.ComputedPropertyInfo)(this.Session["it"]));
        itValueAcquired = true;
    }
}
if ((itValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("it");
    if ((data != null))
    {
        if ((typeof(global::org.pescuma.ModelSharp.Core.model.ComputedPropertyInfo).IsAssignableFrom(data.GetType()) == false))
        {
            this.Error("The type \'org.pescuma.ModelSharp.Core.model.ComputedPropertyInfo\' of the paramete" +
                    "r \'it\' did not match the type of the data passed to the template.");
        }
        else
        {
            this._itField = ((global::org.pescuma.ModelSharp.Core.model.ComputedPropertyInfo)(data));
        }
    }
}
bool indexValueAcquired = false;
if (this.Session.ContainsKey("index"))
{
    if ((typeof(int).IsAssignableFrom(this.Session["index"].GetType()) == false))
    {
        this.Error("The type \'System.Int32\' of the parameter \'index\' did not match the type of the da" +
                "ta passed to the template.");
    }
    else
    {
        this._indexField = ((int)(this.Session["index"]));
        indexValueAcquired = true;
    }
}
if ((indexValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("index");
    if ((data != null))
    {
        if ((typeof(int).IsAssignableFrom(data.GetType()) == false))
        {
            this.Error("The type \'System.Int32\' of the parameter \'index\' did not match the type of the da" +
                    "ta passed to the template.");
        }
        else
        {
            this._indexField = ((int)(data));
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
