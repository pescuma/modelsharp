$it.Annotations:annotation()$
$if(it.Public)$
	public
$else$
	private
$endif$
$if(it.ReadOnly)$
	readonly
$endif$

$it.TypeName$ $it.Name$
$if(it.DefaultValue)$
	= $it.DefaultValue$
$endif$
;
