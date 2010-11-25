$if(it.IsCollection)$
	$it.Name$ = new ReadOnlyCollection<$it.Contents$>(new List<$it.Contents$>(other.$it.Name$));$\n$
$elseif(it.IsComponent)$
	$it.Name$ = new $it.TypeName$(other.$it.Name$);$\n$
$else$
	$it.Name$ = other.$it.Name$;$\n$
$endif$