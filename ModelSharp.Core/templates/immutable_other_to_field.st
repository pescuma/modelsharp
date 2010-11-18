$if(it.IsCollection)$
$it.Name$ = new ReadOnlyCollection<$it.Contents$>(new List<$it.Contents$>(other.$it.Name$));$\n$
$else$
$it.Name$ = other.$it.Name$;$\n$
$endif$
