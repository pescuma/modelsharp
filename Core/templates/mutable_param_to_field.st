	$it.FieldName$ = $it.VarName$;
$if(it.CanListenTo)$
	Add$it.Name$Listeners($it.FieldName$);
$endif$