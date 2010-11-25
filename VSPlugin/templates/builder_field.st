$if(it.IsCollection)$
	$it.Annotations:annotation()$
	private readonly List<$it.Contents$> $it.PrivateName$ = new List<$it.Contents$>();
$else$
	$it.Annotations:annotation()$
	private $it.TypeName$ $it.PrivateName$$if(it.DefaultValue)$ = $it.DefaultValue$$endif$;
$endif$