$it.FieldAnnotations:annotation()$
private 
$if(it.ReadOnly)$
	readonly 
$endif$
$it.TypeName$ $it.FieldName$$if(it.DefaultValue)$$if(!it.LazyInitializer)$ = $it.DefaultValue$$endif$$endif$;
