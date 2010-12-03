$if(it.LazyInitializer)$
if (other.$it.FieldName$ != null) 
{
$endif$
$if(it.IsCollection)$
	$it.FieldName$ = new $it.TypeName$(other.$it.Name$);
	Add$it.Name$ListListeners($it.FieldName$);
$elseif(it.IsComponent)$
	$it.FieldName$ = new $it.TypeName$(other.$it.Name$);
$else$
	$it.FieldName$ = other.$it.Name$;
$endif$
$if(it.CanListenTo)$
	Add$it.Name$Listeners($it.FieldName$);
$endif$
$if(it.LazyInitializer)$
}
$endif$