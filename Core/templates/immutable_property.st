$if(it.WithSetter)$
		$it.WithSetter.Annotations:annotation()$
		public virtual $it.WithSetter.TypeName$ $it.WithSetter.Name$($first(it.WithSetter.Parameters)$ $it.VarName$) 
		{
			return new $it.Parent.Name$($it.Parent.Properties:var_name_or_property(parent=it); separator=", "$);
		}

$endif$