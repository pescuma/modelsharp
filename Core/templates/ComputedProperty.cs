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
    
    
    #line 1 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "10.0.0.0")]
    public partial class ComputedProperty : TemplateUtils
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
            
            #line 4 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
 var computed = (ComputedPropertyInfo) it; 
            
            #line default
            #line hidden
            
            #line 5 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
 if (computed.Cached) { 
            
            #line default
            #line hidden
            
            #line 6 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
 ForEach("Annotation", computed.FieldAnnotations); 
            
            #line default
            #line hidden
            this.Write("\t\tprivate ");
            
            #line 7 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(computed.TypeName));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 7 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(computed.FieldName));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 8 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
 ForEach("Annotation", computed.InvalidFieldAnnotations); 
            
            #line default
            #line hidden
            this.Write("\t\tprivate bool ");
            
            #line 9 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(computed.ValidFieldName));
            
            #line default
            #line hidden
            this.Write(";\r\n\r\n");
            
            #line 11 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
 } 
            
            #line default
            #line hidden
            
            #line 12 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
 if (it.Documentation != null) { 
            
            #line default
            #line hidden
            this.Write("\t\t/// <summary>\r\n\t\t/// ");
            
            #line 14 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.Documentation));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t/// </summary>\r\n");
            
            #line 16 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
 } 
            
            #line default
            #line hidden
            
            #line 17 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
 ForEach("Annotation", it.Annotations); 
            
            #line default
            #line hidden
            this.Write("\t\t");
            
            #line 18 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
 if (it.GetterVisibility != null) { 
            
            #line default
            #line hidden
            
            #line 18 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.GetterVisibility));
            
            #line default
            #line hidden
            
            #line 18 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
 } else { 
            
            #line default
            #line hidden
            this.Write("public");
            
            #line 18 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
 } 
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 18 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.TypeName));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 18 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.Name));
            
            #line default
            #line hidden
            this.Write(" \r\n\t\t{\r\n");
            
            #line 20 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
 ForEach("Annotation", it.PropGetAnnotations); 
            
            #line default
            #line hidden
            this.Write("\t\t\tget { return ");
            
            #line 21 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(computed.Cacher.Name));
            
            #line default
            #line hidden
            this.Write("(); }\r\n\t\t}\r\n");
            
            #line 23 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
 if (computed.Cached) { 
            
            #line default
            #line hidden
            this.Write("\t\t\r\n");
            
            #line 25 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
 if (!it.Owner.Immutable) { 
            
            #line default
            #line hidden
            this.Write("\t\t/// Do not call this method directly. Instead, call NotifyPropertyChanged(() =>" +
                    " ");
            
            #line 26 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.Name));
            
            #line default
            #line hidden
            this.Write(")\r\n");
            
            #line 27 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
 } 
            
            #line default
            #line hidden
            
            #line 28 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
 ForEach("Annotation", computed.Invalidate.Annotations); 
            
            #line default
            #line hidden
            this.Write("\t\t");
            
            #line 29 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
 if (it.Owner.Immutable) { 
            
            #line default
            #line hidden
            this.Write("protected virtual");
            
            #line 29 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
 } else { 
            
            #line default
            #line hidden
            this.Write("private");
            
            #line 29 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
 } 
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 29 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(computed.Invalidate.TypeName));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 29 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(computed.Invalidate.Name));
            
            #line default
            #line hidden
            this.Write("()\r\n\t\t{\r\n\t\t\t");
            
            #line 31 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(computed.ValidFieldName));
            
            #line default
            #line hidden
            this.Write(" = false;\r\n\t\t}\r\n\r\n");
            
            #line 34 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
 ForEach("Annotation", computed.Cacher.Annotations); 
            
            #line default
            #line hidden
            this.Write("\t\tprivate ");
            
            #line 35 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(computed.Cacher.TypeName));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 35 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(computed.Cacher.Name));
            
            #line default
            #line hidden
            this.Write("()\r\n\t\t{\r\n\t\t\tif (!");
            
            #line 37 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(computed.ValidFieldName));
            
            #line default
            #line hidden
            this.Write(")\r\n\t\t\t{\r\n\t\t\t\tthis.");
            
            #line 39 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(computed.FieldName));
            
            #line default
            #line hidden
            this.Write(" = ");
            
            #line 39 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(computed.Getter.Name));
            
            #line default
            #line hidden
            this.Write("();\r\n\t\t\t\tthis.");
            
            #line 40 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(computed.ValidFieldName));
            
            #line default
            #line hidden
            this.Write(" = true;\r\n\t\t\t}\r\n\r\n\t\t\treturn this.");
            
            #line 43 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.FieldName));
            
            #line default
            #line hidden
            this.Write(";\r\n\t\t}\r\n");
            
            #line 45 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
 } 
            
            #line default
            #line hidden
            
            #line 46 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
 if (computed.Formula != null) { 
            
            #line default
            #line hidden
            this.Write("\t\t\r\n");
            
            #line 48 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
 ForEach("Annotation", it.Getter.Annotations); 
            
            #line default
            #line hidden
            this.Write("\t\tprotected virtual ");
            
            #line 49 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.Getter.TypeName));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 49 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.Getter.Name));
            
            #line default
            #line hidden
            this.Write("()\r\n\t\t{\r\n\t\t\treturn ");
            
            #line 51 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(computed.Formula));
            
            #line default
            #line hidden
            this.Write(";\r\n\t\t}\r\n");
            
            #line 53 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
 } else { 
            
            #line default
            #line hidden
            this.Write("\t\t\r\n");
            
            #line 55 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
 ForEach("Annotation", it.Getter.Annotations); 
            
            #line default
            #line hidden
            this.Write("\t\tprotected abstract ");
            
            #line 56 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.Getter.TypeName));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 56 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.Getter.Name));
            
            #line default
            #line hidden
            this.Write("();\r\n");
            
            #line 57 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"
 } 
            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "X:\c#\modelsharp\Core\templates\ComputedProperty.tt"

private global::org.pescuma.ModelSharp.Core.model.PropertyInfo _itField;

/// <summary>
/// Access the it parameter of the template.
/// </summary>
private global::org.pescuma.ModelSharp.Core.model.PropertyInfo it
{
    get
    {
        return this._itField;
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
    if ((typeof(global::org.pescuma.ModelSharp.Core.model.PropertyInfo).IsAssignableFrom(this.Session["it"].GetType()) == false))
    {
        this.Error("The type \'org.pescuma.ModelSharp.Core.model.PropertyInfo\' of the parameter \'it\' d" +
                "id not match the type of the data passed to the template.");
    }
    else
    {
        this._itField = ((global::org.pescuma.ModelSharp.Core.model.PropertyInfo)(this.Session["it"]));
        itValueAcquired = true;
    }
}
if ((itValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("it");
    if ((data != null))
    {
        if ((typeof(global::org.pescuma.ModelSharp.Core.model.PropertyInfo).IsAssignableFrom(data.GetType()) == false))
        {
            this.Error("The type \'org.pescuma.ModelSharp.Core.model.PropertyInfo\' of the parameter \'it\' d" +
                    "id not match the type of the data passed to the template.");
        }
        else
        {
            this._itField = ((global::org.pescuma.ModelSharp.Core.model.PropertyInfo)(data));
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
