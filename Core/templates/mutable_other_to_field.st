$if(it.LazyInitializer)$
if (other.$it.FieldName$ != null) 
{$\n$
$endif$
$if(it.IsCollection)$
	$it.FieldName$ = new $it.TypeName$(other.$it.Name$);
	Add$it.Name$ListListeners($it.FieldName$);
$elseif(it.IsComponent)$
	$it.FieldName$ = new $it.TypeName$(other.$it.Name$);$\n$
$else$
	$it.FieldName$ = other.$it.Name$;$\n$
$endif$
$if(it.CanListenTo)$
	Add$it.Name$Listeners($it.FieldName$);$\n$
$endif$
$if(it.LazyInitializer)$
}$\n$
$endif$