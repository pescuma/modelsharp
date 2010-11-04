$it.FieldAnnotations:annotation()$
private 
$if(it.ReadOnly)$
	readonly 
$endif$
$it.TypeName$ $it.FieldName$$if(it.DefaultValue)$ = $it.DefaultValue$$endif$;
