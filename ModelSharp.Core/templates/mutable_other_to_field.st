$if(it.LazyInitializer)$
	if (other.$it.FieldName$ != null) 
$endif$
$if(it.IsCollection)$
	$it.FieldName$ = new $it.TypeName$(other.$it.Name$);
$elseif(it.IsComponent)$
	$it.FieldName$ = new $it.TypeName$(other.$it.Name$);$\n$
$else$
	$it.FieldName$ = other.$it.Name$;$\n$
$endif$
