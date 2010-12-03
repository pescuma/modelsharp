$if(it.IsCollection)$
	$it.Name$ = new ReadOnlyCollection<$it.Contents$>(new List<$it.Contents$>(other.$it.Name$));
$elseif(it.IsComponent)$
	$it.Name$ = new $it.TypeName$(other.$it.Name$);
$else$
	$it.Name$ = other.$it.Name$;
$endif$