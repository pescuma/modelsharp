$if(it.IsCollection)$
$it.FieldName$.AddRange(other.$it.Name$);$\n$
$else$
$it.FieldName$ = other.$it.Name$;$\n$
$endif$
