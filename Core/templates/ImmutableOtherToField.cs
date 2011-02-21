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
    
    
    #line 1 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "10.0.0.0")]
    public partial class ImmutableOtherToField : TemplateUtils
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
            
            #line 4 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
 if (it is CollectionInfo) { 
	var col = (CollectionInfo) it; 
            
            #line default
            #line hidden
            this.Write("\t\t\tvar ");
            
            #line 6 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.VarName));
            
            #line default
            #line hidden
            this.Write(" = new List<");
            
            #line 6 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.Contents));
            
            #line default
            #line hidden
            this.Write(">();\r\n");
            
            #line 7 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
		if (!col.DeepCopy) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t");
            
            #line 8 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.VarName));
            
            #line default
            #line hidden
            this.Write(".AddRange(other.");
            
            #line 8 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.Name));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 9 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
		} else if (col.ContentsType.HasCopyConstructor) { 
            
            #line default
            #line hidden
            this.Write("\t\t\tforeach (");
            
            #line 10 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.Contents));
            
            #line default
            #line hidden
            this.Write(" otherItem in other.");
            
            #line 10 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.Name));
            
            #line default
            #line hidden
            this.Write(")\r\n\t\t\t\t");
            
            #line 11 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.VarName));
            
            #line default
            #line hidden
            this.Write(".Add(new ");
            
            #line 11 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.Contents));
            
            #line default
            #line hidden
            this.Write("(otherItem));\r\n");
            
            #line 12 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
		} else if (col.ContentsType.CreateExternalCopyMethod("otherItem") != null) { 
            
            #line default
            #line hidden
            this.Write("\t\t\tforeach (");
            
            #line 13 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.Contents));
            
            #line default
            #line hidden
            this.Write(" otherItem in other.");
            
            #line 13 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.Name));
            
            #line default
            #line hidden
            this.Write(")\r\n\t\t\t\t");
            
            #line 14 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.VarName));
            
            #line default
            #line hidden
            this.Write(".Add(");
            
            #line 14 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.ContentsType.CreateExternalCopyMethod("otherItem")));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 15 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
		} else  { 
            
            #line default
            #line hidden
            this.Write("\t\t\t???;\r\n");
            
            #line 17 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
		} 
            
            #line default
            #line hidden
            this.Write("\t\t\t");
            
            #line 18 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.Name));
            
            #line default
            #line hidden
            this.Write(" = new ReadOnlyCollection<");
            
            #line 18 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.Contents));
            
            #line default
            #line hidden
            this.Write(">(");
            
            #line 18 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.VarName));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 19 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
 } else if (it is ComponentInfo)  { 
            
            #line default
            #line hidden
            
            #line 20 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
		if (it.HasCopyConstructor) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t");
            
            #line 21 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.FieldName));
            
            #line default
            #line hidden
            this.Write(" = new ");
            
            #line 21 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.TypeName));
            
            #line default
            #line hidden
            this.Write("(other.");
            
            #line 21 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.Name));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 22 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
		} else if (it.CreateExternalCopyMethod("other." + it.Name) != null) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t");
            
            #line 23 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.FieldName));
            
            #line default
            #line hidden
            this.Write(".Add(");
            
            #line 23 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.CreateExternalCopyMethod("other." + it.Name)));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 24 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
		} else  { 
            
            #line default
            #line hidden
            this.Write("\t\t\t???;\r\n");
            
            #line 26 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
		} 
            
            #line default
            #line hidden
            
            #line 27 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
 } else if (it.IsComputedAndCached) {
	var computed = (ComputedPropertyInfo) it; 
            
            #line default
            #line hidden
            this.Write("\t\t\t");
            
            #line 29 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(computed.ValidFieldName));
            
            #line default
            #line hidden
            this.Write(" = false;\r\n");
            
            #line 30 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
 } else if (!it.IsComputed) { 
            
            #line default
            #line hidden
            
            #line 31 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
		if (!it.DeepCopy) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t");
            
            #line 32 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.FieldName));
            
            #line default
            #line hidden
            this.Write(" = other.");
            
            #line 32 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.Name));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 33 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
		} else if (it.HasCopyConstructor) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t");
            
            #line 34 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.FieldName));
            
            #line default
            #line hidden
            this.Write(" = new ");
            
            #line 34 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.TypeName));
            
            #line default
            #line hidden
            this.Write("(other.");
            
            #line 34 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.Name));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 35 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
		} else if (it.CreateExternalCopyMethod("other." + it.Name) != null) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t");
            
            #line 36 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.FieldName));
            
            #line default
            #line hidden
            this.Write(" = ");
            
            #line 36 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.CreateExternalCopyMethod("other." + it.Name)));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 37 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
		} else  { 
            
            #line default
            #line hidden
            this.Write("\t\t\t???;\r\n");
            
            #line 39 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
		} 
            
            #line default
            #line hidden
            
            #line 40 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"
 } 
            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "X:\c#\modelsharp\Core\templates\ImmutableOtherToField.tt"

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
