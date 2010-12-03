$if(!it.LazyInitializer)$
$if(it.DefaultValue)$
	$it.FieldName$ = $it.DefaultValue$;
$elseif(it.IsCollection)$
	$it.FieldName$ = new $it.TypeName$();
	Add$it.Name$ListListeners($it.FieldName$);
$elseif(it.IsComponent)$
	$it.FieldName$ = new $it.TypeName$();
$endif$
$if(it.CanListenTo)$
	Add$it.Name$Listeners($it.FieldName$);
$endif$
$endif$