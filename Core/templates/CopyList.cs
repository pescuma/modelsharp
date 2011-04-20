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
    
    
    #line 1 "X:\c#\modelsharp\Core\templates\CopyList.tt"
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "10.0.0.0")]
    public partial class CopyList : TemplateUtils
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
            
            #line 5 "X:\c#\modelsharp\Core\templates\CopyList.tt"
 	if (!it.DeepCopy) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t");
            
            #line 6 "X:\c#\modelsharp\Core\templates\CopyList.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(target));
            
            #line default
            #line hidden
            this.Write(".AddRange(other.");
            
            #line 6 "X:\c#\modelsharp\Core\templates\CopyList.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.Name));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 7 "X:\c#\modelsharp\Core\templates\CopyList.tt"
 	} else if (it.ContentsType.IsPrimitive) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t");
            
            #line 8 "X:\c#\modelsharp\Core\templates\CopyList.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(target));
            
            #line default
            #line hidden
            this.Write(".AddRange(other.");
            
            #line 8 "X:\c#\modelsharp\Core\templates\CopyList.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.Name));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 9 "X:\c#\modelsharp\Core\templates\CopyList.tt"
 	} else if (it.ContentsType.CreateExternalCopyMethod("otherItem") != null) { 
            
            #line default
            #line hidden
            this.Write("\t\t\tforeach (");
            
            #line 10 "X:\c#\modelsharp\Core\templates\CopyList.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.Contents));
            
            #line default
            #line hidden
            this.Write(" otherItem in other.");
            
            #line 10 "X:\c#\modelsharp\Core\templates\CopyList.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.Name));
            
            #line default
            #line hidden
            this.Write(")\r\n\t\t\t\t");
            
            #line 11 "X:\c#\modelsharp\Core\templates\CopyList.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(target));
            
            #line default
            #line hidden
            this.Write(".Add(otherItem == null ? null : ");
            
            #line 11 "X:\c#\modelsharp\Core\templates\CopyList.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.ContentsType.CreateExternalCopyMethod("otherItem")));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 12 "X:\c#\modelsharp\Core\templates\CopyList.tt"
 	} else  { 
            
            #line default
            #line hidden
            this.Write("\t\t\tforeach (");
            
            #line 13 "X:\c#\modelsharp\Core\templates\CopyList.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.Contents));
            
            #line default
            #line hidden
            this.Write(" otherItem in other.");
            
            #line 13 "X:\c#\modelsharp\Core\templates\CopyList.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.Name));
            
            #line default
            #line hidden
            this.Write(")\r\n");
            
            #line 14 "X:\c#\modelsharp\Core\templates\CopyList.tt"
		if (it.ContentsType.HasCopyConstructor) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t");
            
            #line 15 "X:\c#\modelsharp\Core\templates\CopyList.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(target));
            
            #line default
            #line hidden
            this.Write(".Add(otherItem == null ? null : new ");
            
            #line 15 "X:\c#\modelsharp\Core\templates\CopyList.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.Contents));
            
            #line default
            #line hidden
            this.Write("(otherItem));\r\n");
            
            #line 16 "X:\c#\modelsharp\Core\templates\CopyList.tt"
 		} else { 
            
            #line default
            #line hidden
            this.Write("\t\t\t{\r\n\t\t\t\tif (otherItem == null)\r\n\t\t\t\t\t");
            
            #line 19 "X:\c#\modelsharp\Core\templates\CopyList.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(target));
            
            #line default
            #line hidden
            this.Write(".Add(null);\r\n// ReSharper disable ConditionIsAlwaysTrueOrFalse\r\n\t\t\t\telse if (othe" +
                    "rItem is ICloneable)\r\n// ReSharper restore ConditionIsAlwaysTrueOrFalse\r\n\t\t\t\t\t");
            
            #line 23 "X:\c#\modelsharp\Core\templates\CopyList.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(target));
            
            #line default
            #line hidden
            this.Write(".Add((");
            
            #line 23 "X:\c#\modelsharp\Core\templates\CopyList.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(it.ContentsType.TypeName));
            
            #line default
            #line hidden
            this.Write(") ((ICloneable) otherItem).Clone());\r\n\t\t\t\telse\r\n\t\t\t\t\tthrow new InvalidOperationEx" +
                    "ception();\r\n\t\t\t}\r\n");
            
            #line 27 "X:\c#\modelsharp\Core\templates\CopyList.tt"
		} 
            
            #line default
            #line hidden
            
            #line 28 "X:\c#\modelsharp\Core\templates\CopyList.tt"
 	} 
            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "X:\c#\modelsharp\Core\templates\CopyList.tt"

private global::org.pescuma.ModelSharp.Core.model.CollectionInfo _itField;

/// <summary>
/// Access the it parameter of the template.
/// </summary>
private global::org.pescuma.ModelSharp.Core.model.CollectionInfo it
{
    get
    {
        return this._itField;
    }
}

private string _targetField;

/// <summary>
/// Access the target parameter of the template.
/// </summary>
private string target
{
    get
    {
        return this._targetField;
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
    if ((typeof(global::org.pescuma.ModelSharp.Core.model.CollectionInfo).IsAssignableFrom(this.Session["it"].GetType()) == false))
    {
        this.Error("The type \'org.pescuma.ModelSharp.Core.model.CollectionInfo\' of the parameter \'it\'" +
                " did not match the type of the data passed to the template.");
    }
    else
    {
        this._itField = ((global::org.pescuma.ModelSharp.Core.model.CollectionInfo)(this.Session["it"]));
        itValueAcquired = true;
    }
}
if ((itValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("it");
    if ((data != null))
    {
        if ((typeof(global::org.pescuma.ModelSharp.Core.model.CollectionInfo).IsAssignableFrom(data.GetType()) == false))
        {
            this.Error("The type \'org.pescuma.ModelSharp.Core.model.CollectionInfo\' of the parameter \'it\'" +
                    " did not match the type of the data passed to the template.");
        }
        else
        {
            this._itField = ((global::org.pescuma.ModelSharp.Core.model.CollectionInfo)(data));
        }
    }
}
bool targetValueAcquired = false;
if (this.Session.ContainsKey("target"))
{
    if ((typeof(string).IsAssignableFrom(this.Session["target"].GetType()) == false))
    {
        this.Error("The type \'System.String\' of the parameter \'target\' did not match the type of the " +
                "data passed to the template.");
    }
    else
    {
        this._targetField = ((string)(this.Session["target"]));
        targetValueAcquired = true;
    }
}
if ((targetValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("target");
    if ((data != null))
    {
        if ((typeof(string).IsAssignableFrom(data.GetType()) == false))
        {
            this.Error("The type \'System.String\' of the parameter \'target\' did not match the type of the " +
                    "data passed to the template.");
        }
        else
        {
            this._targetField = ((string)(data));
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
