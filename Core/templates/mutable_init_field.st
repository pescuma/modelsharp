$if(!it.LazyInitializer)$
$if(it.DefaultValue)$
	$it.FieldName$ = $it.DefaultValue$;
$elseif(it.IsCollection)$
	$it.FieldName$ = new $it.TypeName$();
$elseif(it.IsComponent)$
	$it.FieldName$ = new $it.TypeName$();$\n$
$endif$
$endif$