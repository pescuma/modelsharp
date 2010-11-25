$if(it.IsCollection)$
	$it.Name$ = new ReadOnlyCollection<$it.Contents$>(new List<$it.Contents$>($it.VarName$));
$else$
	$it.Name$ = $it.VarName$;$\n$
$endif$