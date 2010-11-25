$if(!it.LazyInitializer)$
$if(it.DefaultValue)$
	$it.FieldName$ = $it.DefaultValue$;
	$if(it.CanListenTo)$
		Add$it.Name$Listeners($it.FieldName$);$\n$
	$endif$
$elseif(it.IsCollection)$
	$it.FieldName$ = new $it.TypeName$();
$elseif(it.IsComponent)$
	$it.FieldName$ = new $it.TypeName$();
	$if(it.CanListenTo)$
		Add$it.Name$Listeners($it.FieldName$);$\n$
	$endif$
$endif$
$endif$